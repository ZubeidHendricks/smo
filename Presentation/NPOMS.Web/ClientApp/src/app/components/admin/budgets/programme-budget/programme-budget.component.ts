import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDepartment, IDirectorate, IDirectorateBudget, IFinancialYear, IProgramme, IProgrammeBudget, IUser } from 'src/app/models/interfaces';
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

  financialYears: IFinancialYear[];
  selectedFinancialYearSummary: IFinancialYear;
  selectedFinancialYear: IFinancialYear;

  directorates: IDirectorate[];
  filteredDirectorates: IDirectorate[];
  selectedDirectorate: IDirectorate;

  programmes: IProgramme[];
  filteredProgrammes: IProgramme[];
  selectedProgramme: IProgramme;

  displayNewDialog: boolean;
  displayEditDialog: boolean;

  newProgrammeBudget: boolean;
  editProgrammeBudget: boolean;

  departments: IDepartment[];
  selectedDepartmentSummary: IDepartment;
  selectedDepartment: IDepartment;

  isSystemAdmin: boolean;

  directorateBudgets: IDirectorateBudget[];
  directorateBudget: IDirectorateBudget = {} as IDirectorateBudget;

  programmeBudgets: IProgrammeBudget[];
  programmeBudget: IProgrammeBudget = {} as IProgrammeBudget;

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

        if (!this.IsAuthorized(PermissionsEnum.ViewProgrammeBudget))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.loadFinancialYears();
        this.loadDepartments();
        this.loadDirectorates();
        this.loadProgrammes();
      }
    });

    this.budgetCols = [
      { header: 'Financial Year', width: '15%' },
      { header: 'Directorate', width: '25%' },
      { header: 'Programme', width: '25%' },
      { header: 'Amount (R)', width: '25%' }
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
        // Filter programmes based on departmentId assigned to user in user department table
        //this.programmes = results.filter(x => x.departmentId === this.profile.departments[0].id);
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
    this.newProgrammeBudget = true;
    this.editProgrammeBudget = false;
    this.programmeBudget = {} as IProgrammeBudget;
    this.selectedFinancialYear = null;
    this.selectedDepartment = this.isSystemAdmin ? null : this.departments.find(x => x.id === this.profile.departments[0].id);
    this.selectedDirectorate = null;
    this.selectedProgramme = null;
    this.departmentChange();
    this.displayNewDialog = true;
  }

  disableSave() {
    if (!this.selectedFinancialYear || !this.selectedDirectorate || !this.selectedProgramme || !this.programmeBudget.amount)
      return true;

    if (this.isSystemAdmin && !this.selectedDepartment)
      return true;

    return false;
  }

  saveNewBudget() {
    this.programmeBudget.departmentId = this.selectedDepartment.id;
    this.programmeBudget.financialYearId = this.selectedFinancialYear.id;
    this.programmeBudget.programmeId = this.selectedProgramme.id;
    this.saveProgrammeBudget('new');
  }

  // The budgetType with either be new or updating an existing programme budget
  private saveProgrammeBudget(budgetType: string) {

    // Get the Directorate Budgets by departmentID and financialYearId
    this._budgetRepo.getDirectorateBudgetsByIds(this.programmeBudget.departmentId, this.programmeBudget.financialYearId).subscribe(
      (directorateBudgets) => {
        if (directorateBudgets != null && directorateBudgets.length > 0) {

          let directorateBudget = directorateBudgets.find(x => x.directorateId === this.selectedDirectorate.id);

          // Get the Programme Budget by departmentId and financialYearId
          this._budgetRepo.getProgrammeBudgetsByIds(this.programmeBudget.departmentId, this.programmeBudget.financialYearId).subscribe(
            (programmeBudgets) => {
              let totalProgrammeBudget: number = 0;

              if (budgetType === 'new') {
                // Add programme budget to array
                programmeBudgets.push({ amount: this.programmeBudget.amount } as IProgrammeBudget);
              }

              if (budgetType === 'existing') {
                // Update the array with the updated programme budget amount
                programmeBudgets.find(x => x.id === this.programmeBudget.id).amount = this.programmeBudget.amount;
              }

              // Calculate total amount of programme budgets
              if (programmeBudgets != null && programmeBudgets.length > 0) {
                totalProgrammeBudget = programmeBudgets.map(x => x.amount).reduce(function (a, b) {
                  return a + b;
                });
              }

              // Create programme budget if total of programme budget does not exceed the amount for directorate budget
              if (directorateBudget.amount >= totalProgrammeBudget) {
                this.programmeBudget.directorateBudgetId = directorateBudget.id;
                this.programmeBudget.isActive = true;

                if (budgetType === 'new') {
                  if (!this.programmeBudgetExists(programmeBudgets, this.programmeBudget)) {
                    this._budgetRepo.createProgrammeBudget(this.programmeBudget).subscribe(
                      (resp) => {
                        this.loadDirectorateBudgets();
                        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Programme Budget successfully created.' });
                        this.displayNewDialog = false;
                      },
                      (err) => {
                        this._loggerService.logException(err);
                        this._spinner.hide();
                      }
                    );
                  }
                  else {
                    this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Programme Budget already exists.' });
                  }
                }

                if (budgetType === 'existing') {
                  this._budgetRepo.updateProgrammeBudget(this.programmeBudget).subscribe(
                    (resp) => {
                      this.loadDirectorateBudgets();
                      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Programme Budget successfully updated.' });
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
                this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Sum of Programme Budgets is greater than Directorate Budget.' });
              }
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        }
        else {
          this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Directorate Budget for the selected financial year does not exist.' });
        }
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private programmeBudgetExists(programmeBudgets: IProgrammeBudget[], programmeBudget: IProgrammeBudget) {
    // Checks whether a programme budget already exists.
    // Found at https://www.codegrepper.com/code-examples/javascript/angular+check+if+value+exists+in+array+of+objects
    return programmeBudgets.some(function (budget) {
      return budget.programmeId === programmeBudget.programmeId;
    });
  }

  edit(data: IProgrammeBudget) {
    this.newProgrammeBudget = false;
    this.editProgrammeBudget = true;
    this.programmeBudget = this.cloneProgrammeBudget(data);
    this.displayEditDialog = true;
  }

  private cloneProgrammeBudget(data: IProgrammeBudget): IProgrammeBudget {
    let programmeBudget = {} as IProgrammeBudget;

    for (let prop in data)
      programmeBudget[prop] = data[prop];

    this.selectedDepartment = this.departments.find(x => x.id === data.departmentId);
    this.selectedFinancialYear = data.financialYear;
    this.selectedDirectorate = data.directorate;
    this.selectedProgramme = data.programme;
    this.departmentChange();

    return programmeBudget;
  }

  saveEditBudget() {
    this.programmeBudget.financialYear = null;
    this.programmeBudget.directorate = null;
    this.programmeBudget.programme = null;
    this.saveProgrammeBudget('existing');
  }

  delete() {

  }

  departmentSummaryChange() {
    // this.loadDepartmentBudgets();
    this.loadDirectorateBudgets();
  }

  financialYearSummaryChange() {
    // this.loadDepartmentBudgets();
    this.loadDirectorateBudgets();
  }

  /*private loadDepartmentBudgets() {
    if (this.selectedDepartmentSummary && this.selectedFinancialYearSummary) {

      this.totalBudget = 0;

      this._spinner.show();
      this._budgetRepo.getDepartmentBudgetsByIds(this.selectedDepartmentSummary.id, this.selectedFinancialYearSummary.id).subscribe(
        (results) => {
          if (results != null && results.length > 0) {

            // Calculate total budget, found at https://expertcodeblog.wordpress.com/2018/10/31/typescript-sum-of-object-properties/
            this.totalBudget = results.map(x => x.amount).reduce(function (a, b) {
              return a + b;
            });
          }

          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }*/

  private loadDirectorateBudgets() {
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
  }
}
