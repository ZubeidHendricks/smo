import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { ICompliantCycle, IDepartment, IFinancialYear, IPaymentSchedule, IUser } from 'src/app/models/interfaces';
import { AdminService } from 'src/app/services/api-services/admin/admin.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-payment-schedules',
  templateUrl: './payment-schedules.component.html',
  styleUrls: ['./payment-schedules.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class PaymentSchedulesComponent implements OnInit {

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

  compliantCycles: ICompliantCycle[];
  selectedCompliantCycleFilter: ICompliantCycle;
  selectedCompliantCycle: ICompliantCycle;

  paymentSchedules: IPaymentSchedule[];
  filteredPaymentSchedules: IPaymentSchedule[];

  cols: any[];

  isEdit: boolean;
  isNew: boolean;
  paymentSchedule: IPaymentSchedule = {} as IPaymentSchedule;
  selectedPaymentSchedule: IPaymentSchedule;
  displayDialog: boolean;

  minDate: Date;
  maxDate: Date;
  disableDate: boolean = true;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _dropdownRepo: DropdownService,
    private _loggerService: LoggerService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private _adminRepo: AdminService,
    private _datepipe: DatePipe
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewPaymentSchedule))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.loadFinancialYears();
        this.loadDepartments();
      }
    });

    this.cols = [
      { header: 'Financial Year', width: '15%' },
      { header: 'Compliant Cycle', width: '15%' },
      { header: 'Start Date', width: '20%' },
      { header: 'Release Date', width: '20%' },
      { header: 'Payment Date', width: '20%' },
      { header: 'Actions', width: '10%' }
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
        this.loadPaymentSchedules();
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
        this.loadPaymentSchedules();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadPaymentSchedules() {
    if (this.selectedDepartment && this.selectedFinancialYear && this.compliantCycles && this.financialYears) {
      this._spinner.show();
      this._adminRepo.getPaymentSchedulesByIds(this.selectedDepartment.id, this.selectedFinancialYear.id).subscribe(
        (results) => {
          results.forEach(item => {
            item.compliantCycle = this.compliantCycles.find(x => x.id === item.compliantCycleId);
            item.compliantCycle.financialYear = this.financialYears.find(x => x.id === item.compliantCycle.financialYearId);
            item.startDate = new Date(item.startDate);
            item.releaseDate = new Date(item.releaseDate);
            item.paymentDate = new Date(item.paymentDate);
          });

          this.paymentSchedules = results;
          this.filteredPaymentSchedules = results;

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
    this.loadCompliantCycles();
  }

  financialYearChange() {
    this.loadCompliantCycles();
  }

  compliantCycleFilterChange() {
    if (this.selectedCompliantCycleFilter) {
      this.filteredPaymentSchedules = this.paymentSchedules.filter(x => x.compliantCycleId === this.selectedCompliantCycleFilter.id);
    }
  }

  private loadCompliantCycles() {
    if (this.selectedDepartment && this.selectedFinancialYear) {
      this._spinner.show();
      this._adminRepo.getCompliantCyclesByIds(this.selectedDepartment.id, this.selectedFinancialYear.id).subscribe(
        (results) => {
          results.forEach(item => {
            let startDate = this._datepipe.transform(item.startDate, 'yyyy-MM-dd');
            let endDate = this._datepipe.transform(item.endDate, 'yyyy-MM-dd');

            // Join start date and end date with separator
            item.name = [startDate, endDate].join(' - ');
          });

          this.compliantCycles = results;
          this.loadPaymentSchedules();
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  add() {
    this.isEdit = false;
    this.isNew = true;
    this.paymentSchedule = {} as IPaymentSchedule;
    this.selectedCompliantCycle = null;
    this.disableDate = true;
    this.displayDialog = true;
  }

  edit(data: IPaymentSchedule) {
    this.selectedPaymentSchedule = data;
    this.isEdit = true;
    this.isNew = false;
    this.paymentSchedule = this.clonePaymentSchedule(data);
    this.disableDate = false;
    this.displayDialog = true;
  }

  private clonePaymentSchedule(data: IPaymentSchedule): IPaymentSchedule {
    let paymentSchedule = {} as IPaymentSchedule;

    for (let prop in data)
      paymentSchedule[prop] = data[prop];

    this.selectedCompliantCycle = this.compliantCycles.find(x => x.id === data.compliantCycleId);
    this.compliantCycleChange();

    return paymentSchedule;
  }

  delete(data: IPaymentSchedule) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        data.isActive = false;
        this.updatePaymentSchedule(data);
      },
      reject: () => {
      }
    });
  }

  save() {
    this.paymentSchedule.compliantCycleId = this.selectedCompliantCycle.id;
    this.paymentSchedule.startDate = this.addTwoHours(this.paymentSchedule.startDate);
    this.paymentSchedule.releaseDate = this.addTwoHours(this.paymentSchedule.releaseDate);
    this.paymentSchedule.paymentDate = this.addTwoHours(this.paymentSchedule.paymentDate);
    this.paymentSchedule.isActive = true;

    this.isNew ? this.createPaymentSchedule(this.paymentSchedule) : this.updatePaymentSchedule(this.paymentSchedule);
    this.displayDialog = false;
  }

  private addTwoHours(date: Date) {
    let newDate = new Date(date);
    let nextTwoHours = newDate.getHours() + 2;
    newDate.setHours(nextTwoHours);

    return newDate;
  }

  private createPaymentSchedule(paymentSchedule: IPaymentSchedule) {
    this._adminRepo.createPaymentSchedule(paymentSchedule).subscribe(
      (resp) => {
        this.loadPaymentSchedules();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Payment Schedule successfully created.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updatePaymentSchedule(paymentSchedule: IPaymentSchedule) {
    this._adminRepo.updatePaymentSchedule(paymentSchedule).subscribe(
      (resp) => {
        this.loadPaymentSchedules();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Payment Schedule successfully updated.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  disableSave() {
    if (!this.selectedFinancialYear || !this.selectedCompliantCycle || !this.paymentSchedule.startDate || !this.paymentSchedule.releaseDate || !this.paymentSchedule.paymentDate)
      return true;

    if (this.isSystemAdmin && !this.selectedDepartment)
      return true;

    return false;
  }

  compliantCycleChange() {
    if (this.selectedCompliantCycle) {
      this.minDate = new Date(this.selectedCompliantCycle.startDate);

      // Add 7 days to complaint cycle end date
      this.maxDate = this.addDays(this.selectedCompliantCycle.endDate, 7);

      this.disableDate = false;
    }
  }

  private addDays(endDate: Date, days: number): Date {
    var futureDate = new Date(endDate);
    futureDate.setDate(futureDate.getDate() + days);
    return futureDate;
  }
}
