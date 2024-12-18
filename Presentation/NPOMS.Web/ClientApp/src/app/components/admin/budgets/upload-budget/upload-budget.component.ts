import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DepartmentEnum, DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDenodoBudget, IDepartment, IFinancialYear, IProgrammeBudgets, IUser } from 'src/app/models/interfaces';
import { BudgetService } from 'src/app/services/api-services/budget/budget.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-upload-budget',
  templateUrl: './upload-budget.component.html',
  styleUrls: ['./upload-budget.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class UploadBudgetComponent implements OnInit {

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
  programmeBudgets: IProgrammeBudgets[];
  financialYears: IFinancialYear[];
  selectedFinancialYearSummary: IFinancialYear;

  departments: IDepartment[];
  selectedDepartmentSummary: IDepartment;
  displayMessage: string;

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
    private _budgetRepo: BudgetService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.UploadBudget))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        
        this.loadDepartments();
        this.loadFinancialYears();
      }
    });

    this.budgetCols = [
      { header: 'Budget', width: '33%' },
      { header: 'Allocated Amount', width: '33%' },
      { header: 'Balance Amount', width: '33%' }
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

        if(this.isSystemAdmin )
        {
          this.departments = results.filter(x => x.id != DepartmentEnum.ALL && x.id != DepartmentEnum.NONE);
        }
        else{
          this.departments = results.filter(x => x.id === this.profile.departments[0].id);
        }

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

  departmentSummaryChange() {
    this.ImportBudgets();
  }

  financialYearSummaryChange() {
    this.ImportBudgets();
  }

  private ImportBudgets() {
    if (this.selectedDepartmentSummary && this.selectedFinancialYearSummary) {
      this._spinner.show();
      this._budgetRepo.getFilteredBudgets(this.selectedDepartmentSummary.id, this.selectedFinancialYearSummary.year).subscribe(
        (results) => {
          this.programmeBudgets = results ? results : [];
          this.programmeBudgets = this.programmeBudgets ? this.programmeBudgets.filter(x => Number(x.originalBudgetAmount) > 0) : [];
          if(this.programmeBudgets.length > 0)
          {
              this.displayMessage = 'Budget for the selected department and selected year is already imported';
             
          }
          else{
            this._spinner.show();
            this._budgetRepo.importBudget(this.selectedDepartmentSummary.denodoDepartmentName, this.selectedFinancialYearSummary.year).subscribe(
              (results) => {
                this.programmeBudgets = results ? results : [];
                this.programmeBudgets = this.programmeBudgets ? this.programmeBudgets.filter(x => Number(x.originalBudgetAmount) > 0) : [];
      
                if(this.programmeBudgets.length > 0)
                {
                  this.displayMessage = 'Budget Imported Successfully';
                }
                
                this._spinner.hide();
              },
              (err) => {
                this._loggerService.logException(err);
                this.displayMessage = 'Error In Budget Import -' + err;
                this._spinner.hide();
              }
            );
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
