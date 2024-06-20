import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DepartmentEnum, DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDenodoBudget, IDepartment, IFinancialYear, IProgramme, IProgrammeBudget, ISegmentCode, ISubProgramme, ISubProgrammeType, IUser } from 'src/app/models/interfaces';
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

      this._budgetRepo.importBudget(this.selectedDepartmentSummary.denodoDepartmentName, this.selectedFinancialYearSummary.year).subscribe(
        (results) => {

          this.budgets = results ? results.elements : [];

          this.budgets.forEach(application => {
            this.setProgrammeName(application);
          });

          this.denodoBudgets = this.budgets ? this.budgets.filter(x => Number(x.originalbudget) > 0) : [];
          this.totalBudget = this.denodoBudgets.reduce((n, {originalbudget}) => n + Number(originalbudget), 0);

          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private setProgrammeName(data: IDenodoBudget) {
    let responsibilityCode = data.responsibilitylowestlevelcode;
    let objectiveCode = data.objectivelowestlevelcode;
    let id =  this.segmentCode.filter(x=> x.responsibilityCode === responsibilityCode && x.objectiveCode === objectiveCode);
   // alert(id.length);
    if(id.length > 0)
    {     
      let programmeName = this.programmes.filter(x=> x.id === id[0].programmeId);
      let subProgrammeName = this.subProgrammes.filter(x=> x.programmeId === programmeName[0].id);
      let subProgrammeTypeName = this.subProgrammeType.filter(x=> x.subProgrammeId === subProgrammeName[0].id)
      data.programme = programmeName[0].name;
      
      if(subProgrammeName.length > 0)
        data.subProgramme = subProgrammeName[0].name;
      
      if(subProgrammeTypeName.length > 0)
        data.subProgrammeType = subProgrammeTypeName[0].name;
    }    
  }

  getColumnSum(columnIndex: number): number {
    let sum = 0;
     
        sum += columnIndex;
    
    return sum;
}


  edit(data: IProgrammeBudget) {
    this.editProgrammeBudget = true;
    this.displayEditDialog = true;
  }

}
