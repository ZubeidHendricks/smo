import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDepartment, IDepartmentBudget, IFinancialYear, IUser } from 'src/app/models/interfaces';
import { BudgetService } from 'src/app/services/api-services/budget/budget.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-department-budget',
  templateUrl: './department-budget.component.html',
  styleUrls: ['./department-budget.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class DepartmentBudgetComponent implements OnInit {

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

  financialYears: IFinancialYear[];
  selectedFinancialYearSummary: IFinancialYear;
  selectedFinancialYear: IFinancialYear;

  displayNewDialog: boolean;
  displayEditDialog: boolean;

  newDeptBudget: boolean;
  editDeptBudget: boolean;

  departments: IDepartment[];
  selectedDepartmentSummary: IDepartment;
  selectedDepartment: IDepartment;

  isSystemAdmin: boolean;

  departmentBudgets: IDepartmentBudget[];
  departmentBudget: IDepartmentBudget = {} as IDepartmentBudget;

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
    this._spinner.show();
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewDepartmentBudget))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.loadFinancialYears();
        this.loadDepartments();
      }
    });

    this.budgetCols = [
      { header: 'Financial Year', width: '15%' },
      { header: 'Budget (R)', width: '25%' },
      { header: 'Allocated Amount (R)', width: '25%' },
      { header: 'Balance Amount (R)', width: '25%' }
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
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadDepartments() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Departments, false).subscribe(
      (results) => {
        this.departments = results;

        // In Department Budget Summary...
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

  add() {
    this.newDeptBudget = true;
    this.editDeptBudget = false;
    this.departmentBudget = {} as IDepartmentBudget;
    this.selectedFinancialYear = null;
    this.selectedDepartment = this.isSystemAdmin ? null : this.departments.find(x => x.id === this.profile.departments[0].id);
    this.displayNewDialog = true;
  }

  disableSave() {
    if (!this.selectedFinancialYear || !this.departmentBudget.amount)
      return true;

    if (this.isSystemAdmin && !this.selectedDepartment)
      return true;

    return false;
  }

  saveNewBudget() {
    this.departmentBudget.departmentId = this.selectedDepartment.id;
    this.departmentBudget.financialYearId = this.selectedFinancialYear.id;
    this.departmentBudget.isActive = true;

    this._budgetRepo.getDepartmentBudgetsByIds(this.departmentBudget.departmentId, this.departmentBudget.financialYearId).subscribe(
      (results) => {
        if (results != null && results.length > 0) {
          this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Department Budget already exists.' });
        }
        else {
          this._budgetRepo.createDepartmentBudget(this.departmentBudget).subscribe(
            (resp) => {
              this.loadDepartmentBudgets();
              this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Department Budget successfully created.' });
              this.displayNewDialog = false;
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        }
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  edit(data: IDepartmentBudget) {
    this.newDeptBudget = false;
    this.editDeptBudget = true;
    this.departmentBudget = this.cloneDepartmentBudget(data);
    this.displayEditDialog = true;
  }

  private cloneDepartmentBudget(data: IDepartmentBudget): IDepartmentBudget {
    let departmentBudget = {} as IDepartmentBudget;

    for (let prop in data)
      departmentBudget[prop] = data[prop];

    this.selectedDepartment = this.departments.find(x => x.id === data.departmentId);
    this.selectedFinancialYear = data.financialYear;

    return departmentBudget;
  }

  saveEditBudget() {
    this.departmentBudget.financialYear = null;

    this._budgetRepo.updateDepartmentBudget(this.departmentBudget).subscribe(
      (resp) => {
        this.loadDepartmentBudgets();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Department Budget successfully updated.' });
        this.displayEditDialog = false;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  delete() {

  }

  departmentSummaryChange() {
    this.loadDepartmentBudgets();
  }

  financialYearSummaryChange() {
    this.loadDepartmentBudgets();
  }

  private loadDepartmentBudgets() {
    if (this.selectedDepartmentSummary && this.selectedFinancialYearSummary) {

      this.totalBudget = 0;
      this.totalAllocated = 0;
      this.totalPaid = 0;
      this.totalBalance = 0;

      this._spinner.show();
      this._budgetRepo.getDepartmentBudgetsByIds(this.selectedDepartmentSummary.id, this.selectedFinancialYearSummary.id).subscribe(
        (results) => {
          if (results != null) {
            this.departmentBudgets = results;

            this.departmentBudgets.forEach(item => {
              item.financialYear = this.financialYears.find(x => x.id === item.financialYearId);
              this.totalBudget += item.amount;
            });

            this.loadDirectorateBudgets();
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

  private loadDirectorateBudgets() {
    if (this.selectedDepartmentSummary && this.selectedFinancialYearSummary) {

      this._spinner.show();
      this._budgetRepo.getDirectorateBudgetsByIds(this.selectedDepartmentSummary.id, this.selectedFinancialYearSummary.id).subscribe(
        (results) => {
          if (results != null && results.length > 0) {

            results.forEach(item => {
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
}
