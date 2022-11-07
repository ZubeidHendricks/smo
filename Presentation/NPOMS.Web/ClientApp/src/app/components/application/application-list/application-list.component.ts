import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem } from 'primeng/api';
import { Table } from 'primeng/table';
import { AccessStatusEnum, PermissionsEnum, RoleEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IApplicationPeriod, INpo, IUser } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-application-list',
  templateUrl: './application-list.component.html',
  styleUrls: ['./application-list.component.css']
})
export class ApplicationListComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get StatusEnum(): typeof StatusEnum {
    return StatusEnum;
  }

  profile: IUser;

  cols: any[];
  allApplications: IApplication[];

  // This is the selected application when clicking on option buttons...
  selectedApplication: IApplication;

  isSystemAdmin: boolean = true;
  isAdmin: boolean = false;
  hasAdminRole: boolean = false;

  allNpos: INpo[];

  buttonItems: MenuItem[];

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _npoRepo: NpoService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewApplications))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.isAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.Admin });

        if (this.isSystemAdmin || this.isAdmin)
          this.hasAdminRole = true;

        this.loadNpos();
        this.loadApplications();
        this.buildButtonItems();
      }
    });

    this.cols = [
      { field: 'refNo', header: 'Ref. No.', width: '15%' },
      { field: 'npo.name', header: 'Organisation', width: '30%' },
      { field: 'applicationPeriod.applicationType.name', header: 'Type', width: '15%' },
      { field: 'applicationPeriod.closingDate', header: 'Closing Date', width: '15%' },
      { field: 'status.name', header: 'Application Status', width: '10%' }
    ];
  }

  private loadNpos() {
    this._spinner.show();
    this._npoRepo.getAllNpos(AccessStatusEnum.AllStatuses).subscribe(
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

  private loadApplications() {
    this._spinner.show();
    this._applicationRepo.getAllApplications().subscribe(
      (results) => {
        results.forEach(application => {
          this.setStatus(application.applicationPeriod);
        });

        this.allApplications = results;
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

  private buildButtonItems() {
    this.buttonItems = [];

    if (this.profile) {

      this.buttonItems = [{
        label: 'Options',
        items: []
      }];

      if (this.IsAuthorized(PermissionsEnum.ViewOptions) && this.IsAuthorized(PermissionsEnum.ViewManageIndicatorsOption)) {
        this.buttonItems[0].items.push({
          label: 'Manage Indicators',
          icon: 'fa fa-tags wcg-icon',
          command: () => {
            this._router.navigateByUrl('workplan-indicator/manage/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewOptions) && this.IsAuthorized(PermissionsEnum.ViewSummaryOption)) {
        this.buttonItems[0].items.push({
          label: 'Summary',
          icon: 'fa fa-tasks wcg-icon',
          command: () => {
            this._router.navigateByUrl('workplan-indicator/summary/' + this.selectedApplication.id);
          }
        });
      }
    }
  }

  getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];
    }

    return value;
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  edit(application: IApplication) {
    this._router.navigateByUrl('application/edit/' + application.id);
  }

  review(application: IApplication) {
    this._router.navigateByUrl('application/review/' + application.id);
  }

  approve(application: IApplication) {
    this._router.navigateByUrl('application/approve/' + application.id);
  }

  uploadSLA(application: IApplication) {
    this._router.navigateByUrl('application/upload-sla/' + application.id);
  }

  view(application: IApplication) {
    this._router.navigateByUrl('application/view/' + application.id);
  }
}
