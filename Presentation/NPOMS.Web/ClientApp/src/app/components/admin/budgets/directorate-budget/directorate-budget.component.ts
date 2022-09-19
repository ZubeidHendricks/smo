import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDepartment, IDirectorate, IDirectorateBudget, IFinancialYear, IProgramme, IUser } from 'src/app/models/interfaces';
import { BudgetService } from 'src/app/services/api-services/budget/budget.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-directorate-budget',
  templateUrl: './directorate-budget.component.html',
  styleUrls: ['./directorate-budget.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class DirectorateBudgetComponent implements OnInit {

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

  directorates: IDirectorate[];
  filteredDirectorates: IDirectorate[];
  selectedDirectorate: IDirectorate;

  displayNewDialog: boolean;
  displayEditDialog: boolean;

  newDirectorateBudget: boolean;
  editDirectorateBudget: boolean;

  departments: IDepartment[];
  selectedDepartmentSummary: IDepartment;
  selectedDepartment: IDepartment;

  isSystemAdmin: boolean;

  directorateBudgets: IDirectorateBudget[];
  directorateBudget: IDirectorateBudget = {} as IDirectorateBudget;

  programmes: IProgramme[];

  // Details displayed in summary
  totalBudget: number;
  totalAllocated: number;
  totalPaid: number;
  totalBalance: number;

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

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

        if (!this.IsAuthorized(PermissionsEnum.ViewDirectorateBudget))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.loadFinancialYears();
        this.loadDepartments();
        this.loadDirectorates();
        this.loadProgrammes();
      }
    });

    this.budgetCols = [
      { header: 'Financial Year', width: '16%' },
      { header: 'Directorate', width: '37%' },
      { header: 'Amount (R)', width: '37%' }
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

        // In Directorate Budget Summary...
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

  private loadDirectorates() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Directorates, false).subscribe(
      (results) => {
        this.directorates = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProgrammes() {
    this._spinner.show();
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

  add() {
    this.newDirectorateBudget = true;
    this.editDirectorateBudget = false;
    this.directorateBudget = {} as IDirectorateBudget;
    this.selectedFinancialYear = null;
    this.selectedDepartment = this.isSystemAdmin ? null : this.departments.find(x => x.id === this.profile.departments[0].id);
    this.selectedDirectorate = null;
    this.filteredDirectorates = [];
    this.displayNewDialog = true;
  }

  disableSave() {
    if (!this.selectedFinancialYear || !this.selectedDirectorate || !this.directorateBudget.amount)
      return true;

    if (this.isSystemAdmin && !this.selectedDepartment)
      return true;

    return false;
  }

  saveNewBudget() {
    this.directorateBudget.departmentId = this.selectedDepartment.id;
    this.directorateBudget.financialYearId = this.selectedFinancialYear.id;
    this.directorateBudget.directorateId = this.selectedDirectorate.id;
    this.saveDirectorateBudget('new');
  }

  // The budgetType with either be new or updating an existing directorate budget
  private saveDirectorateBudget(budgetType: string) {

    // Get the Department Budgets by departmentID and financialYearId
    this._budgetRepo.getDepartmentBudgetsByIds(this.directorateBudget.departmentId, this.directorateBudget.financialYearId).subscribe(
      (deptBudgets) => {
        if (deptBudgets != null && deptBudgets.length > 0) {

          // Get the Directorate Budget by departmentId and financialYearId
          this._budgetRepo.getDirectorateBudgetsByIds(this.directorateBudget.departmentId, this.directorateBudget.financialYearId).subscribe(
            (directorateBudgets) => {
              let totalDirectorateBudget: number = 0;

              if (budgetType === 'new') {
                // Add directorate budget to array
                directorateBudgets.push({ amount: this.directorateBudget.amount } as IDirectorateBudget);
              }

              if (budgetType === 'existing') {
                // Update the array with the updated directorate budget amount
                directorateBudgets.find(x => x.id === this.directorateBudget.id).amount = this.directorateBudget.amount;
              }

              // Calculate total amount of directorate budgets
              if (directorateBudgets != null && directorateBudgets.length > 0) {
                totalDirectorateBudget = directorateBudgets.map(x => x.amount).reduce(function (a, b) {
                  return a + b;
                });
              }

              // Create directorate budget if total of directorate budget does not exceed the amount for department budget
              if (deptBudgets[0].amount >= totalDirectorateBudget) {
                this.directorateBudget.departmentBudgetId = deptBudgets[0].id;
                this.directorateBudget.isActive = true;

                if (budgetType === 'new') {
                  if (!this.directorateBudgetExists(directorateBudgets, this.directorateBudget)) {
                    this._budgetRepo.createDirectorateBudget(this.directorateBudget).subscribe(
                      (resp) => {
                        this.loadDepartmentBudgets();
                        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Directorate Budget successfully created.' });
                        this.displayNewDialog = false;
                      },
                      (err) => {
                        this._loggerService.logException(err);
                        this._spinner.hide();
                      }
                    );
                  }
                  else {
                    this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Directorate Budget already exists.' });
                  }
                }

                if (budgetType === 'existing') {
                  this._budgetRepo.updateDirectorateBudget(this.directorateBudget).subscribe(
                    (resp) => {
                      this.loadDepartmentBudgets();
                      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Directorate Budget successfully updated.' });
                      this.displayEditDialog = false;
                    },
                    (err) => {
                      this._loggerService.logException(err);
                      this._spinner.hide();
                    }
                  );
                }
              }
              else {
                this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Sum of Directorate Budgets is greater than Department Budget.' });
              }
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        }
        else {
          this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Department Budget for the selected financial year does not exist.' });
        }
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private directorateBudgetExists(directorateBudgets: IDirectorateBudget[], directorateBudget: IDirectorateBudget) {
    // Checks whether a directorate budget already exists.
    // Found at https://www.codegrepper.com/code-examples/javascript/angular+check+if+value+exists+in+array+of+objects
    return directorateBudgets.some(function (budget) {
      return budget.directorateId === directorateBudget.directorateId;
    });
  }

  edit(data: IDirectorateBudget) {
    this.newDirectorateBudget = false;
    this.editDirectorateBudget = true;
    this.directorateBudget = this.cloneDirectorateBudget(data);
    this.displayEditDialog = true;
  }

  private cloneDirectorateBudget(data: IDirectorateBudget): IDirectorateBudget {
    let directorateBudget = {} as IDirectorateBudget;

    for (let prop in data)
      directorateBudget[prop] = data[prop];

    this.selectedDepartment = this.departments.find(x => x.id === data.departmentId);
    this.selectedFinancialYear = data.financialYear;
    this.selectedDirectorate = data.directorate;
    this.departmentChange();

    return directorateBudget;
  }

  saveEditBudget() {
    this.directorateBudget.financialYear = null;
    this.directorateBudget.directorate = null;
    this.saveDirectorateBudget('existing');
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
          if (results != null && results.length > 0) {

            // Calculate total budget, found at https://expertcodeblog.wordpress.com/2018/10/31/typescript-sum-of-object-properties/
            this.totalBudget = results.map(x => x.amount).reduce(function (a, b) {
              return a + b;
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
            this.directorateBudgets = results;

            this.directorateBudgets.forEach(item => {
              item.financialYear = this.financialYears.find(x => x.id === item.financialYearId);
              item.directorate = this.directorates.find(x => x.id === item.directorateId);
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

    // Filter programmes based on selected department
    let filteredProgrammes = this.programmes.filter(x => x.departmentId === this.selectedDepartment.id);

    // Get Directorate Ids from programmes filtered by Department Id
    let directorateIds = filteredProgrammes.map(programme => programme.directorateId);

    // Filter directorates based on directorate ids obtained above
    this.filteredDirectorates = this.directorates.filter(x => directorateIds.includes(x.id));
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }
}
