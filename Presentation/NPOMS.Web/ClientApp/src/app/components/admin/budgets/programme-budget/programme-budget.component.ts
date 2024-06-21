import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DepartmentEnum, DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDenodoBudget, IDepartment, IFinancialYear, IProgramme, IProgrammeBudget, IProgrammeBudgets, ISegmentCode, ISubProgramme, ISubProgrammeType, IUser } from 'src/app/models/interfaces';
import { BudgetService } from 'src/app/services/api-services/budget/budget.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-programme-budget',
  templateUrl: './programme-budget.component.html',
  styleUrls: ['./programme-budget.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ProgrammeBudgetComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  profile: IUser;
  budgetCols: any[];
  denodoBudgets: IDenodoBudget[];
  budgets: IDenodoBudget[];
  programmeBudgets: IProgrammeBudgets[];
  financialYears: IFinancialYear[];
  selectedFinancialYearSummary: IFinancialYear;

  displayEditDialog: boolean;
  editProgrammeBudget: boolean;

  departments: IDepartment[];
  selectedDepartmentSummary: IDepartment;

  isSystemAdmin: boolean;

  // Details displayed in summary
  totalBudget: number;
  totalAllocated: number;
  totalPaid: number;
  totalBalance: number;

  programmes: IProgramme[];
  filteredProgrammes: IProgramme[];
  selectedProgrammes: IProgramme;
  subProgrammes: ISubProgramme[];
  filteredSubProgrammes: ISubProgramme[];
  selectedSubProgrammes: ISubProgramme;
  subProgrammeType: ISubProgrammeType[];
  filteredSubProgrammeType: ISubProgrammeType[];
  selectedSubProgrammeType: ISubProgrammeType;
  segmentCode: ISegmentCode[] = [];
  filteredSegmentCode: ISegmentCode[] = [];
  AdjustmentAmount: string;
  budgetId: number;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _dropdownRepo: DropdownService,
    private _loggerService: LoggerService,
    private _budgetRepo: BudgetService,
    private _messageService: MessageService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;
        console.log('profile', profile);

        if (!this.IsAuthorized(PermissionsEnum.ViewProgrammeBudget))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });

        this.loadProgrammes();
        this.loadSubProgrammes();
        this.loadProgrammeTypes();
        this.loadSegmentCode();
        this.loadFinancialYears();
      }
    });

    this.budgetCols = [
      // { header: 'Directorate', width: '15%' },
      { header: 'Programme', width: '20%' },
      { header: 'Sub Program', width: '20%' },
      { header: 'Sub Program Type', width: '20%' },
      { header: 'Original Approved Budget', width: '20%' },
      { header: 'Adjusted Budget', width: '20%' }
    ];
  }

  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        //Get until current financial year
        let currentDate = new Date();
        let currentFinancialYear = results.find(x => new Date(x.startDate) <= currentDate && new Date(x.endDate) >= currentDate);
        this.financialYears = results.filter(x => x.id <= currentFinancialYear.id);
        this.loadDepartments();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadDepartments() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Departments, false).subscribe(
      (results) => {
        this.departments = results.filter(x => x.id != DepartmentEnum.ALL && x.id != DepartmentEnum.NONE);

        // In Programme Budget Summary...
        // If user is system admin, show department dropdown
        // If user is not system admin, default department to assigned department in user department table
        this.selectedDepartmentSummary = this.isSystemAdmin ? null : this.departments.find(x => x.id === this.profile.departments[0].id);

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  departmentSummaryChange() {
    this.loadBudgets();
  }

  financialYearSummaryChange() {
    this.loadBudgets();
  }

  private loadProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
      (results) => {
        this.programmes = results;

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSubProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
      (results) => {
        this.subProgrammes = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProgrammeTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgrammeTypes, false).subscribe(
      (results) => {
        this.subProgrammeType = results;
       
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSegmentCode() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SegmentCode, false).subscribe(
      (results) => {       
        this.segmentCode = results;
        this._spinner.hide();
      }, 
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadBudgets() {
    if (this.selectedDepartmentSummary && this.selectedFinancialYearSummary) {
      this._spinner.show();

      this.totalBudget = 0;
      this.totalAllocated = 0;
      this.totalPaid = 0;
      this.totalBalance = 0;

      this._budgetRepo.getFilteredBudgets(this.selectedDepartmentSummary.id, this.selectedFinancialYearSummary.year).subscribe(
        (results) => {

          this.programmeBudgets = results ? results : [];

          // this.programmeBudgets.forEach(application => {
          //   this.setSubProgrammeTypeName(application);
          // });

          this.programmeBudgets = this.programmeBudgets ? this.programmeBudgets.filter(x => Number(x.originalBudgetAmount) > 0) : [];
          this.totalBudget = this.programmeBudgets.reduce((n, {originalBudgetAmount}) => n + Number(originalBudgetAmount), 0);

          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private setSubProgrammeTypeName(data: IProgrammeBudgets) {
    var subProgTypeName = this.subProgrammeType.filter(x=> x.id = data.subProgrammeTypeId);
    data.subProgrammeTypeName = subProgTypeName[0].name;
  }

  getColumnSum(columnIndex: number): number {
    let sum = 0;
     
        sum += columnIndex;
    
    return sum;
}


  edit(data: IProgrammeBudget) {
    this.budgetId = data.id;
    this.editProgrammeBudget = true;
    this.displayEditDialog = true;
  }

  SaveData(changesRequired: boolean, origin: string) {

    this._budgetRepo.addAdjustmentAmount(this.AdjustmentAmount, this.budgetId).subscribe(
      (results) => {

       // this.programmeBudgets = results ? results : [];

        // this.programmeBudgets.forEach(application => {
        //   this.setSubProgrammeTypeName(application);
        // });

       // this.programmeBudgets = this.programmeBudgets ? this.programmeBudgets.filter(x => Number(x.originalBudgetAmount) > 0) : [];
       // this.totalBudget = this.programmeBudgets.reduce((n, {originalBudgetAmount}) => n + Number(originalBudgetAmount), 0);
       this.displayEditDialog = false;
       this._router.navigateByUrl('admin/programme-budget');
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );

  }

}
