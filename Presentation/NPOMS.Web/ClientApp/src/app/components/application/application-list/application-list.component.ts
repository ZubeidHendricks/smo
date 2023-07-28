import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
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

  //canShowOptions: boolean = false;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _npoRepo: NpoService,
    private _loggerService: LoggerService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService
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
      { field: 'refNo', header: 'Ref. No.', width: '10%' },
      { field: 'npo.name', header: 'Organisation', width: '20%' },
      { field: 'applicationPeriod.applicationType.name', header: 'Type', width: '10%' },
      { field: 'applicationPeriod.name', header: 'Application Name', width: '12%' },      
      { field: 'applicationPeriod.subProgramme.name', header: 'Sub-Programme', width: '11%' },
      { field: 'applicationPeriod.financialYear.name', header: 'Financial Year', width: '10%' },
      { field: 'applicationPeriod.closingDate', header: 'Closing Date', width: '10%' },
      { field: 'status.name', header: 'Application Status', width: '12%' }
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
      //  this.canShowOptions = this.allApplications.some(function (item) { return item.statusId === StatusEnum.AcceptedSLA });
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

      if (this.IsAuthorized(PermissionsEnum.ViewOptions)) {
        this.buttonItems[0].items.push({
          label: 'View Application',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/view/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.EditOption)) {
        this.buttonItems[0].items.push({
          label: 'Edit Application',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/edit/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.PreAdjudicateOption)) {
        this.buttonItems[0].items.push({
          label: 'Pre-adjudicate Application',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/pre-adjudicate/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.AdjudicateOption)) {
        this.buttonItems[0].items.push({
          label: 'Adjiducate Application',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/evaluate/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.EvaluateOption)) {
        this.buttonItems[0].items.push({
          label: 'Evaluate Application',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/adjudicate/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveOPtion)) {
        this.buttonItems[0].items.push({
          label: 'Approve Application',
          icon: 'fa fa-file',
          command: () => {
            this._router.navigateByUrl('application/view/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DownloadOption)) {
        this.buttonItems[0].items.push({
          label: 'Download Application',
          icon: 'fa fa-download',
          command: () => {
            this._router.navigate(['/', { outlets: { 'print': ['print', this.selectedApplication.id] } }]);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DeleteOption)) {
        this.buttonItems[0].items.push({
          label: 'Delete Application',
          icon: 'fa fa-trash',
          command: () => {
            this._confirmationService.confirm({
              message: 'Are you sure that you want to delete this item?',
              header: 'Confirmation',
              icon: 'pi pi-info-circle',
              accept: () => {
                this._spinner.show();
                this._applicationRepo.deleteFundingApplication(this.selectedApplication.id).subscribe(
                  (resp) => {
                    this.loadApplications();
                    this._messageService.add({ severity: 'info', detail: 'Record ' + this.selectedApplication.refNo + ' deleted.' });
                    this._spinner.hide();
                  },
                  (err) => {
                    this._loggerService.logException(err);
                    this._spinner.hide();
                  }
                );
              },
              reject: () => {
              }
            });
          }
        });
      }
    }
  }
  
  get canShowOptions() {
    return this.IsAuthorized(PermissionsEnum.EditOption) || this.IsAuthorized(PermissionsEnum.ViewOptions) || this.IsAuthorized(PermissionsEnum.DownloadOption) || this.IsAuthorized(PermissionsEnum.DeleteOption);
  }
  public updateButtonItems() {
    // Show all buttons
    this.buttonItems[0].items.forEach(option => {
      option.visible = true;
    });

    // Hide buttons based on status
    switch (this.selectedApplication.statusId) {
      case StatusEnum.Saved:
      case StatusEnum.AmendmentsRequired: {
        this.buttonItemExists('Pre-evaluate Application');
        this.buttonItemExists('Evaluate Application');
        this.buttonItemExists('Adjudicate Application');
        this.buttonItemExists('View Application');
        this.buttonItemExists('Download Application');
        break;
      }
      case StatusEnum.Submitted:
      case StatusEnum.Submitted: {
        this.buttonItemExists('Edit Application');
        this.buttonItemExists('Evaluate Application');
        this.buttonItemExists('Adjudicate Application');
        this.buttonItemExists('Delete Application');
        break;
      }
      case StatusEnum.Submitted:
      case StatusEnum.Submitted: {
        this.buttonItemExists('Edit Application');
        this.buttonItemExists('Pre-evaluate Application');
        this.buttonItemExists('Adjudicate Application');
        this.buttonItemExists('Delete Application');
        break;
      }
      case StatusEnum.Submitted:
      case StatusEnum.Evaluated:
      case StatusEnum.Submitted: {
        this.buttonItemExists('Edit Application');
        this.buttonItemExists('Pre-evaluate Application');
        this.buttonItemExists('Evaluate Application');
        this.buttonItemExists('Delete Application');
        break;
      }
      case StatusEnum.Submitted:
      case StatusEnum.Submitted:
      case StatusEnum.Submitted:
      case StatusEnum.Submitted: {
        this.buttonItemExists('Edit Application');
        this.buttonItemExists('Pre-evaluate Application');
        this.buttonItemExists('Evaluate Application');
        this.buttonItemExists('Adjudicate Application');
        this.buttonItemExists('Delete Application');
        break;
      }
    }
  }

  private buttonItemExists(label: string) {
    let buttonItem = this.buttonItems[0].items.find(x => x.label === label);

    if (buttonItem)
      buttonItem.visible = false;
  }

  // private buildButtonItems() {
  //   this.buttonItems = [];

  //   if (this.profile) {

  //     this.buttonItems = [{
  //       label: 'Options',
  //       items: []
  //     }];

  //     if (this.IsAuthorized(PermissionsEnum.ViewOptions) && this.IsAuthorized(PermissionsEnum.ViewManageIndicatorsOption)) {
  //       this.buttonItems[0].items.push({
  //         label: 'Manage Indicators',
  //         icon: 'fa fa-tags wcg-icon',
  //         command: () => {
  //           this._router.navigateByUrl('workplan-indicator/manage/' + this.selectedApplication.npoId);
  //         }
  //       });
  //     }

  //     if (this.IsAuthorized(PermissionsEnum.ViewOptions) && this.IsAuthorized(PermissionsEnum.ViewSummaryOption)) {
  //       this.buttonItems[0].items.push({
  //         label: 'Summary',
  //         icon: 'fa fa-tasks wcg-icon',
  //         command: () => {
  //           this._router.navigateByUrl('workplan-indicator/summary/' + this.selectedApplication.npoId);
  //         }
  //       });
  //     }
  //   }
  // }

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

  download(application: IApplication) {
    this._router.navigate(['/', { outlets: { 'print': ['print', application.id] } }]);
  }
}
