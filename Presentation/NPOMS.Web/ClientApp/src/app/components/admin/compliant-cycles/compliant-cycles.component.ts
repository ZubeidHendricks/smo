import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { ICompliantCycle, ICompliantCycleRule, IDepartment, IFinancialYear, IUser } from 'src/app/models/interfaces';
import { AdminService } from 'src/app/services/api-services/admin/admin.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-compliant-cycles',
  templateUrl: './compliant-cycles.component.html',
  styleUrls: ['./compliant-cycles.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class CompliantCyclesComponent implements OnInit {

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

  isSystemAdmin: boolean;
  departments: IDepartment[];
  selectedDepartment: IDepartment;

  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  compliantCycleRules: ICompliantCycleRule[];
  selectedCompliantCycleRule: ICompliantCycleRule;

  compliantCycles: ICompliantCycle[];

  cols: any[];
  stateOptions: any[];

  isEdit: boolean;
  isNew: boolean;
  compliantCycle: ICompliantCycle = {} as ICompliantCycle;
  selectedCompliantCycle: ICompliantCycle;
  displayDialog: boolean;

  minStartDate: Date;
  maxStartDate: Date;
  minEndDate: Date;
  maxEndDate: Date;
  disableStartDate: boolean = false;
  disableEndDate: boolean = true;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _dropdownRepo: DropdownService,
    private _loggerService: LoggerService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private _adminRepo: AdminService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewCompliantCycles))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.loadFinancialYears();
        this.loadDepartments();
        this.loadCompliantCycleRules();
      }
    });

    this.cols = [
      { header: 'Financial Year', width: '15%' },
      { header: 'Compliant Cycle', width: '15%' },
      { header: 'Start Date', width: '30%' },
      { header: 'End Date', width: '30%' },
      { header: 'Actions', width: '10%' }
    ];

    this.stateOptions = [
      {
        label: 'Yes',
        value: true
      },
      {
        label: 'No',
        value: false
      }
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

        // Select last financial year in list
        this.selectedFinancialYear = this.financialYears[this.financialYears.length - 1];

        this.loadCompliantCycles();
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
        this.selectedDepartment = this.isSystemAdmin ? null : this.departments.find(x => x.id === this.profile.departments[0].id);
        this.loadCompliantCycles();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadCompliantCycleRules() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.CompliantCycleRules, false).subscribe(
      (results) => {
        this.compliantCycleRules = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadCompliantCycles() {
    if (this.selectedDepartment && this.selectedFinancialYear) {
      this._spinner.show();
      this._adminRepo.getCompliantCyclesByIds(this.selectedDepartment.id, this.selectedFinancialYear.id).subscribe(
        (results) => {
          this.compliantCycles = results;
          this.updateCompliantCycleObject();
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private updateCompliantCycleObject() {
    if (this.financialYears && this.compliantCycles) {
      this.compliantCycles.forEach(item => {
        item.financialYear = this.financialYears.find(x => x.id === item.financialYearId);
        item.startDate = new Date(item.startDate);
        item.endDate = new Date(item.endDate);
      });
    }
  }

  departmentChange() {
    this.loadCompliantCycles();
  }

  financialYearChange() {
    this.loadCompliantCycles();
  }

  private updateDateField(startDate: Date, endDate: Date, dateField: string) {
    let newStartDate = new Date(startDate);
    let newEndDate = new Date(endDate);

    var minDate: Date;
    var maxDate: Date;

    minDate = newStartDate;
    maxDate = newEndDate;

    if (dateField == 'start date') {

      this.minStartDate = minDate;
      this.maxStartDate = maxDate;
    }
    else {
      this.minEndDate = minDate;
      this.maxEndDate = maxDate;
    }
  }

  startDateChanged() {
    this.compliantCycle.endDate = null;
    this.updateDateField(this.compliantCycle.startDate, this.maxStartDate, 'end date');
    this.disableEndDate = false;
  }

  add() {
    this.isEdit = false;
    this.isNew = true;
    this.compliantCycle = {
      hasSignedTPA: false,
      hasProgressReport: false,
      hasFinancialStatement: false
    } as ICompliantCycle;

    this.updateDateField(this.selectedFinancialYear.startDate, this.selectedFinancialYear.endDate, 'start date');

    this.selectedCompliantCycleRule = null;
    this.displayDialog = true;
  }

  edit(data: ICompliantCycle) {
    this.selectedCompliantCycle = data;
    this.isEdit = true;
    this.isNew = false;
    this.compliantCycle = this.cloneCompliantCycle(data);
    this.disableEndDate = false;
    this.displayDialog = true;
  }

  private cloneCompliantCycle(data: ICompliantCycle): ICompliantCycle {
    let compliantCycle = {} as ICompliantCycle;

    for (let prop in data)
      compliantCycle[prop] = data[prop];

    this.selectedDepartment = this.departments.find(x => x.id === data.departmentId);
    this.selectedFinancialYear = this.financialYears.find(x => x.id === data.financialYearId);
    this.selectedCompliantCycleRule = this.compliantCycleRules.find(x => x.id === data.compliantCycleRuleId);

    this.updateDateField(this.selectedFinancialYear.startDate, this.selectedFinancialYear.endDate, 'start date');
    this.updateDateField(compliantCycle.startDate, this.maxStartDate, 'end date');

    return compliantCycle;
  }

  delete(data: ICompliantCycle) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        data.isActive = false;
        this.updateCompliantCycle(data);
      },
      reject: () => {
      }
    });
  }

  save() {
    this.compliantCycle.startDate = this.addTwoHours(this.compliantCycle.startDate);
    this.compliantCycle.endDate = this.addTwoHours(this.compliantCycle.endDate);

    this.compliantCycle.compliantCycleRuleId = this.selectedCompliantCycleRule.id;
    this.compliantCycle.departmentId = this.selectedDepartment.id;
    this.compliantCycle.financialYearId = this.selectedFinancialYear.id;
    this.compliantCycle.isActive = true;

    this.isNew ? this.createCompliantCycle(this.compliantCycle) : this.updateCompliantCycle(this.compliantCycle);
    this.displayDialog = false;
  }

  private addTwoHours(date: Date) {
    let newDate = new Date(date);
    let nextTwoHours = newDate.getHours() + 2;
    newDate.setHours(nextTwoHours);

    return newDate;
  }

  private createCompliantCycle(compliantCycle: ICompliantCycle) {
    this._adminRepo.createCompliantCycle(compliantCycle).subscribe(
      (resp) => {
        this.loadCompliantCycles();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Compliant Cycle successfully created.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateCompliantCycle(compliantCycle: ICompliantCycle) {
    this._adminRepo.updateCompliantCycle(compliantCycle).subscribe(
      (resp) => {
        this.loadCompliantCycles();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Compliant Cycle successfully updated.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  disableSave() {
    if (!this.selectedFinancialYear || !this.selectedCompliantCycleRule || !this.compliantCycle.startDate || !this.compliantCycle.endDate)
      return true;

    if (this.isSystemAdmin && !this.selectedDepartment)
      return true;

    return false;
  }
}
