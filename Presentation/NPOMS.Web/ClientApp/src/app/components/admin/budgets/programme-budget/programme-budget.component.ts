import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DepartmentEnum, DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDenodoBudget, IDepartment, IFinancialYear, IProgrammeBudget, IUser } from 'src/app/models/interfaces';
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
        this.loadFinancialYears();
      }
    });

    this.budgetCols = [
      // { header: 'Directorate', width: '15%' },
      { header: 'Programme', width: '15%' },
      { header: 'Sub Program', width: '15%' },
      { header: 'Sub Program Type', width: '15%' },
      { header: 'Original Approved Budget', width: '15%' },
      { header: 'Adjusted Budget', width: '15%' }
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

  private loadBudgets() {
    if (this.selectedDepartmentSummary && this.selectedFinancialYearSummary) {
      this._spinner.show();

      this.totalBudget = 0;
      this.totalAllocated = 0;
      this.totalPaid = 0;
      this.totalBalance = 0;

      this._budgetRepo.getFilteredBudgets(this.selectedDepartmentSummary.denodoDepartmentName, this.selectedFinancialYearSummary.year, '30075059', '30024059').subscribe(
        (results) => {

          // results.forEach(application => {
            // this.getColumnSum(application.originalbudget);
          // });

          this.denodoBudgets = results ? results.elements.filter(x => Number(x.originalbudget) > 0 && x.responsibilitylowestlevelcode === '30075059' && x.objectivelowestlevelcode === '30024059') : [];
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
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

  /*private loadDirectorateBudgets() {
    if (this.selectedDepartmentSummary && this.selectedFinancialYearSummary) {

      this.totalBudget = 0;
      this.totalAllocated = 0;
      this.totalPaid = 0;
      this.totalBalance = 0;

      this._spinner.show();
      this._budgetRepo.getDirectorateBudgetsByIds(this.selectedDepartmentSummary.id, this.selectedFinancialYearSummary.id).subscribe(
        (results) => {
          if (results != null && results.length > 0) {
            this.directorateBudgets = results;

            this.directorateBudgets.forEach(item => {
              item.financialYear = this.financialYears.find(x => x.id === item.financialYearId);
              item.directorate = this.directorates.find(x => x.id === item.directorateId);
              this.totalBudget += item.amount;
            });

            this.loadProgrammeBudgets();
          }

          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadProgrammeBudgets() {
    if (this.selectedDepartmentSummary && this.selectedFinancialYearSummary) {

      this._spinner.show();
      this._budgetRepo.getProgrammeBudgetsByIds(this.selectedDepartmentSummary.id, this.selectedFinancialYearSummary.id).subscribe(
        (results) => {
          if (results != null && results.length > 0) {
            this.programmeBudgets = results;

            this.programmeBudgets.forEach(item => {
              let directorateBudget = this.directorateBudgets.find(x => x.id === item.directorateBudgetId);

              item.financialYear = this.financialYears.find(x => x.id === item.financialYearId);
              item.directorate = this.directorates.find(x => x.id === directorateBudget.directorateId);
              item.programme = this.programmes.find(x => x.id === item.programmeId);
              this.totalAllocated += item.amount;
            });

            this.totalBalance = this.totalBudget - this.totalAllocated;
          }

          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  departmentChange() {
    this.filteredDirectorates = [];

    if (this.selectedDepartment) {
      // Filter programmes based on selected department
      let filteredProgrammes = this.programmes.filter(x => x.departmentId === this.selectedDepartment.id);

      // Get Directorate Ids from programmes filtered by Department Id
      let directorateIds = filteredProgrammes.map(programme => programme.directorateId);

      // Filter directorates based on directorate ids obtained above
      this.filteredDirectorates = this.directorates.filter(x => directorateIds.includes(x.id));

      this.populateFilteredProgrammes();
    }
  }

  directorateChange() {
    this.selectedProgramme = null;
    this.populateFilteredProgrammes();
  }

  // Get filtered programmes based on selected department and selected directorate
  private populateFilteredProgrammes() {
    if (this.selectedDepartment && this.selectedDirectorate) {
      this.filteredProgrammes = [];
      this.filteredProgrammes = this.programmes.filter(x => x.departmentId === this.selectedDepartment.id && x.directorateId === this.selectedDirectorate.id);
    }
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }*/
}
