import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Table } from 'primeng/table';
import { AccessStatusEnum, ApplicationTypeEnum, PermissionsEnum, RoleEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IApplicationPeriod, IFinancialYear, INpo, IUser } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-application-period-list',
  templateUrl: './application-period-list.component.html',
  styleUrls: ['./application-period-list.component.css']
})
export class ApplicationPeriodListComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get ApplicationTypeEnum(): typeof ApplicationTypeEnum {
    return ApplicationTypeEnum;
  }

  profile: IUser;

  cols: any[];
  allApplicationPeriods: IApplicationPeriod[];
  applicationPeriodId: number;
  displayDialog: boolean;

  isSystemAdmin: boolean = true;
  isAdmin: boolean = false;
  hasAdminRole: boolean = false;

  allNpos: INpo[];
  selectedNPO: INpo;

  application: IApplication = {} as IApplication;

  selectedApplicationPeriod: IApplicationPeriod;
  stateOptions: any[];
  selectedOption: boolean;

  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _applicationPeriodRepo: ApplicationPeriodService,
    private _npoRepo: NpoService,
    private _datepipe: DatePipe,
    private _applicationRepo: ApplicationService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewApplicationPeriods))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.isAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.Admin });

        if (this.isSystemAdmin || this.isAdmin)
          this.hasAdminRole = true;

        this.loadNpos();
        this.loadApplicationPeriods();
      }
    });

    this.cols = [
      // { field: 'refNo', header: 'Ref. No.', width: '10%' },
      { field: 'department.name', header: 'Department', width: '10%' },
      { field: 'applicationType.name', header: 'Type', width: '15%' },
      { field: 'name', header: 'Name', width: '20%' },
      { field: 'financialYear.name', header: 'Financial Year', width: '8%' },
      { field: 'openingDate', header: 'Opening Date', width: '10%' },
      { field: 'closingDate', header: 'Closing Date', width: '10%' },
      { field: 'status', header: 'Status', width: '5%' }
    ];

    this.stateOptions = [
      { label: 'Create New Workplan', value: true },
      { label: 'Use Existing Workplan', value: false }
    ];
  }

  private loadNpos() {
    this._spinner.show();
    this._npoRepo.getAllNpos(AccessStatusEnum.Approved).subscribe(
      (results) => {
        this.allNpos = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadApplicationPeriods() {
    this._spinner.show();
    this._applicationPeriodRepo.getAllApplicationPeriods().subscribe(
      (results) => {

        results.forEach(period => {
          this.setStatus(period);
        });

        this.allApplicationPeriods = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private setStatus(applicationPeriod: IApplicationPeriod) {
    let openingDate = new Date(applicationPeriod.openingDate);
    let closingDate = new Date(applicationPeriod.closingDate);
    let today = new Date();

    if (today >= openingDate && today <= closingDate)
      applicationPeriod.status = 'Open';
    else
      applicationPeriod.status = 'Closed';
  }

  getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];

      if (col.field == 'openingDate' || col.field == 'closingDate')
        value = this._datepipe.transform(value, 'yyyy-MM-dd HH:mm:ss');
    }

    return value;
  }

  add() {
    this._router.navigateByUrl('application-period/create');
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  edit(applicationPeriod: IApplicationPeriod) {
    this._router.navigateByUrl('application-period/edit/' + applicationPeriod.id);
  }

  onRowSelect(applicationPeriod: IApplicationPeriod) {
    console.log('Selected Application Period', applicationPeriod);
    this.selectedApplicationPeriod = applicationPeriod;
    this.applicationPeriodId = applicationPeriod.id;
    this.selectedOption = true;
    this.selectedFinancialYear = null;
    this.selectedNPO = null;
    this.displayDialog = true;
  }

  disableSelect() {
    if (!this.selectedNPO)
      return true;

    if (this.selectedApplicationPeriod.applicationType.id === ApplicationTypeEnum.SP && !this.selectedOption) {
      if (!this.selectedFinancialYear)
        return true
    }
    return false;
  }

  selectNPO() {
    this.displayDialog = false;
    this._spinner.show();
    this.autoCreateApplication();
  }

  private autoCreateApplication() {
    this.application.npoId = this.selectedNPO.id;
    this.application.applicationPeriodId = this.applicationPeriodId;
    this.application.statusId = StatusEnum.New;

    this._applicationRepo.createApplication(this.application, this.selectedOption, this.selectedFinancialYear).subscribe(
      (resp) => {
        this._router.navigateByUrl('application/create/' + resp.id);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  search(event) {
    let query = event.query;
    this._npoRepo.getNpoByName(query).subscribe((results) => {
      this.allNpos = results;
    });
  }

  selectedOptionChange() {
    this.financialYears = [];
    this.selectedFinancialYear = null;
    this.getExistingWorkplanFinancialYear();
  }

  selectedNPOChange() {
    this.getExistingWorkplanFinancialYear();
  }

  private getExistingWorkplanFinancialYear() {
    if (!this.selectedOption && this.selectedNPO) {
      this._spinner.show();
      this._applicationRepo.getApplicationsByNpoId(this.selectedNPO.id).subscribe(
        (results) => {
          let filteredApplications = results.filter(x => x.applicationPeriod.applicationTypeId === ApplicationTypeEnum.SP);

          filteredApplications.forEach(item => {
            var isPresent = this.financialYears.some(function (financialYear) { return financialYear === item.applicationPeriod.financialYear });
            if (!isPresent)
              this.financialYears.push(item.applicationPeriod.financialYear);
          });

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
