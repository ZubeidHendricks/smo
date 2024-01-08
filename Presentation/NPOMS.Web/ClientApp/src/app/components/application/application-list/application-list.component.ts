import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ActionSequence } from 'protractor';
import { AccessStatusEnum, ApplicationTypeEnum, PermissionsEnum, RoleEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IApplicationPeriod, ICapturedResponse, INpo, IUser } from 'src/app/models/interfaces';
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
  capturedResponses: ICapturedResponse[];
  isSystemAdmin: boolean = true;
  isAdmin: boolean = false;
  hasAdminRole: boolean = false;
  headerTitle: string;

  allNpos: INpo[];

  buttonItems: MenuItem[];
  optionItems: MenuItem[];

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  canShowOptions: boolean = false;

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
        this._spinner.show();
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewApplications))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.isAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.Admin });

        if (this.isSystemAdmin || this.isAdmin)
          this.hasAdminRole = true;

        this.loadNpos();

        var splitUrl = window.location.href.split('/');
        this.headerTitle = splitUrl[5];

      }
    });

    this.cols = [
      { field: 'refNo', header: 'Ref. No.', width: '10%' },
      { field: 'npo.name', header: 'Organisation', width: '15%' },
      { field: 'applicationPeriod.applicationType.name', header: 'Type', width: '8%' },
      { field: 'applicationPeriod.name', header: 'Application Name', width: '11%' },
      { field: 'applicationPeriod.subProgramme.name', header: 'Sub-Programme', width: '10%' },
      { field: 'applicationPeriod.financialYear.name', header: 'Financial Year', width: '10%' },
      { field: 'applicationPeriod.closingDate', header: 'Closing Date', width: '10%' },
      { field: 'status.name', header: 'Application Status', width: '11%' }
    ];
  }

  private loadNpos() {
    this._npoRepo.getAllNpos(AccessStatusEnum.AllStatuses).subscribe(
      (results) => {
        this.allNpos = results;
        this.loadApplications();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadApplications() {
    this._applicationRepo.getAllApplications().subscribe(
      (results) => {
        results.forEach(application => {
          this.setStatus(application.applicationPeriod);
        });

        this.allApplications = results;
        this.canShowOptions = this.allApplications.some(function (item) { return item.statusId === StatusEnum.AcceptedSLA });

        this.buildButtonItems();
        this.buildOptionItems();

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
        label: 'Actions',
        items: []
      }];

      /* Service Provision Actions */
      if (this.IsAuthorized(PermissionsEnum.EditApplication)) {
        this.buttonItems[0].items.push({
          label: 'Edit Application',
          target: 'Service Provision',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/edit/' + this.selectedApplication.id + '/0');
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ReviewApplication)) {
        this.buttonItems[0].items.push({
          label: 'Review Application',
          target: 'Service Provision',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/review/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveApplication)) {
        this.buttonItems[0].items.push({
          label: 'Approve Application',
          target: 'Service Provision',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/approve/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.UploadSLA)) {
        this.buttonItems[0].items.push({
          label: 'Upload SLA',
          target: 'Service Provision',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/upload-sla/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewAcceptedApplication)) {
        this.buttonItems[0].items.push({
          label: 'View Application',
          target: 'Service Provision',
          icon: 'fa fa-file-text-o',
          command: () => {
            this._router.navigateByUrl('sp-application/view/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DeleteOption)) {
        this.buttonItems[0].items.push({
          label: 'Delete Application',
          target: 'Service Provision',
          icon: 'fa fa-trash',
          command: () => {
            this.deleteApplication();
          }
        });
      }

      /* Funding Application Actions */
      if (this.IsAuthorized(PermissionsEnum.EditOption)) {
        this.buttonItems[0].items.push({
          label: 'Edit Application',
          target: 'Funding Application',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            if (!this.selectedApplication.isQuickCapture)
              this._router.navigateByUrl('application/edit/' + this.selectedApplication.id + '/0');
            else
              this._router.navigateByUrl('quick-captures-editList/edit/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.PreEvaluateOption)) {
        this.buttonItems[0].items.push({
          label: 'Pre-Evaluate Application',
          target: 'Funding Application',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/pre-evaluate/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.AdjudicateOption)) {
        this.buttonItems[0].items.push({
          label: 'Adjudicate Application',
          target: 'Funding Application',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/adjudicate/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.EvaluateOption)) {
        this.buttonItems[0].items.push({
          label: 'Evaluate Application',
          target: 'Funding Application',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/evaluate/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveOption)) {
        this.buttonItems[0].items.push({
          label: 'Approve Application',
          target: 'Funding Application',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl('application/approval/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewOption)) {
        this.buttonItems[0].items.push({
          label: 'View Application',
          target: 'Funding Application',
          icon: 'fa fa-file-text-o',
          command: () => {
            this._router.navigateByUrl('fa-application/view/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DownloadOption)) {
        this.buttonItems[0].items.push({
          label: 'Download Application',
          target: 'Funding Application',
          icon: 'fa fa-download',
          command: () => {
            this._router.navigate(['/', { outlets: { 'print': ['print', this.selectedApplication.id, 0] } }]);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DownloadOption)) {
        this.buttonItems[0].items.push({
          label: 'Download Assessment',
          target: 'Workflow Application',
          icon: 'fa fa-download',
          command: () => {
            this._router.navigate(['/', { outlets: { 'print': ['print', this.selectedApplication.id, 1] } }]);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewOption)) {
        this.buttonItems[0].items.push({
          label: 'Review Application',
          target: 'Funded Npo',
          icon: 'fa fa-file-text-o',
          command: () => {
            this._router.navigateByUrl('quick-captures-doh/review/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.EditApplication)) {
        this.buttonItems[0].items.push({
          label: 'Edit Application',
          target: 'Funded Npo',
          icon: 'fa fa-file-text-o',
          command: () => {
            this._router.navigateByUrl('quick-captures-editList-doh/edit/' + this.selectedApplication.id );
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DeleteOption)) {
        this.buttonItems[0].items.push({
          label: 'Delete Application',
          target: 'Funded Npo',
          icon: 'fa fa-trash',
          command: () => {
            this.deleteApplication();
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewOption)) {
        this.buttonItems[0].items.push({
          label: 'View Application',
          target: 'Funded Npo',
          icon: 'fa fa-file-text-o',
          command: () => {
            this._router.navigateByUrl('quick-captures-doh/view/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DownloadOption)) {
        this.buttonItems[0].items.push({
          label: 'Download Application',
          target: 'Funded Npo',
          icon: 'fa fa-download',
          command: () => {
            this._router.navigate(['/', { outlets: { 'print': ['print', this.selectedApplication.id, 3] } }]);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DeleteOption)) {
        this.buttonItems[0].items.push({
          label: 'Delete Application',
          target: 'Funding Application',
          icon: 'fa fa-trash',
          command: () => {
            this.deleteApplication();
          }
        });
      }
    }
  }

  private deleteApplication() {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._spinner.show();
        this._applicationRepo.deleteApplicationById(this.selectedApplication.id).subscribe(
          (resp) => {
            this.loadApplications();
            this._messageService.add({ severity: 'success', detail: 'Record ' + this.selectedApplication.refNo + ' deleted.' });
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

  // get canShowOptions() {
  //   return this.IsAuthorized(PermissionsEnum.EditOption) || this.IsAuthorized(PermissionsEnum.ViewOptions) || this.IsAuthorized(PermissionsEnum.DownloadOption);
  // }

  public updateButtonItems() {
    // Show all buttons
    this.buttonItems[0].items.forEach(option => {
      option.visible = true;
    });

    // Hide buttons based on status
    if (this.selectedApplication.applicationPeriod.applicationTypeId === ApplicationTypeEnum.SP) {

      // Hide Funding Application actions
      this.buttonItemExists('Edit Application', 'Funding Application');
      this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
      this.buttonItemExists('Adjudicate Application', 'Funding Application');
      this.buttonItemExists('Evaluate Application', 'Funding Application');
      this.buttonItemExists('Approve Application', 'Funding Application');
      this.buttonItemExists('Download Application', 'Funding Application');
      this.buttonItemExists('View Application', 'Funding Application');
      this.buttonItemExists('Delete Application', 'Funding Application');
      this.buttonItemExists('Download Assessment', 'Workflow Application');
      this.buttonItemExists('Edit Application', 'Funded Npo');
      this.buttonItemExists('Review Application', 'Funded Npo');
      this.buttonItemExists('Delete Application', 'Funded Npo');
      this.buttonItemExists('View Application', 'Funded Npo');
      this.buttonItemExists('Download Application', 'Funded Npo');
      // this.buttonItemExists('Score Card', 'Service Provision');

      switch (this.selectedApplication.statusId) {
        case StatusEnum.Saved:
        case StatusEnum.AmendmentsRequired: {
          if (this.selectedApplication.applicationPeriod.status === 'Closed')
            this.buttonItemExists('Edit Application', 'Service Provision');

          if (this.selectedApplication.applicationPeriod.status === 'Open')
            this.buttonItemExists('View Application', 'Service Provision');

          this.buttonItemExists('Review Application', 'Service Provision');
          this.buttonItemExists('Approve Application', 'Service Provision');
          this.buttonItemExists('Upload SLA', 'Service Provision');
          break;
        }
        case StatusEnum.PendingReview:
        case StatusEnum.PendingReviewerSatisfaction: {
          this.buttonItemExists('Edit Application', 'Service Provision');
          this.buttonItemExists('Approve Application', 'Service Provision');
          this.buttonItemExists('Upload SLA', 'Service Provision');
          break;
        }
        case StatusEnum.PendingApproval:
        case StatusEnum.ApprovalInProgress: {
          this.buttonItemExists('Edit Application', 'Service Provision');
          this.buttonItemExists('Review Application', 'Service Provision');
          this.buttonItemExists('Upload SLA', 'Service Provision');
          break;
        }
        case StatusEnum.PendingSLA:
        case StatusEnum.PendingSignedSLA:
        case StatusEnum.DeptComments:
        case StatusEnum.OrgComments: {
          this.buttonItemExists('Edit Application', 'Service Provision');
          this.buttonItemExists('Review Application', 'Service Provision');
          this.buttonItemExists('Approve Application', 'Service Provision');
          break;
        }
        case StatusEnum.AcceptedSLA:
        case StatusEnum.Declined: {
          this.buttonItemExists('Edit Application', 'Service Provision');
          this.buttonItemExists('Review Application', 'Service Provision');
          this.buttonItemExists('Approve Application', 'Service Provision');
          this.buttonItemExists('Upload SLA', 'Service Provision');
          break;
        }
      }
    }

    if (this.selectedApplication.applicationPeriod.applicationTypeId === ApplicationTypeEnum.FA) {

      // Hide Service Provision actions
      this.buttonItemExists('Edit Application', 'Service Provision');
      this.buttonItemExists('Review Application', 'Service Provision');
      this.buttonItemExists('Approve Application', 'Service Provision');
      this.buttonItemExists('Upload SLA', 'Service Provision');
      this.buttonItemExists('View Application', 'Service Provision');
      this.buttonItemExists('Delete Application', 'Service Provision');

      this.buttonItemExists('Edit Application', 'Funded Npo');
      this.buttonItemExists('Review Application', 'Funded Npo');
      this.buttonItemExists('Delete Application', 'Funded Npo');
      this.buttonItemExists('View Application', 'Funded Npo');
      this.buttonItemExists('Download Application', 'Funded Npo');
      //this.buttonItemExists('Score Card', 'Service Provision');

      if (this.selectedApplication.isQuickCapture)
        this.buttonItemExists('Download Application', 'Funding Application');

      if (this.selectedApplication.step === 2)
        this.buttonItemExists('Adjudicate Application', 'Funding Application');

      if (this.selectedApplication.step === 3 && this.selectedApplication.statusId == StatusEnum.Declined) {
        this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
        this.buttonItemExists('Adjudicate Application', 'Funding Application');
        this.buttonItemExists('Evaluate Application', 'Funding Application');
        this.buttonItemExists('Approve Application', 'Funding Application');
      }

      if (this.selectedApplication.step === 1 && this.selectedApplication.statusId == StatusEnum.Declined) {
        this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
        this.buttonItemExists('Evaluate Application', 'Funding Application');
        this.buttonItemExists('Approve Application', 'Funding Application');
      }

      if (this.selectedApplication.step === 2 && this.selectedApplication.statusId == StatusEnum.Declined) {
        this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
        this.buttonItemExists('Evaluate Application', 'Funding Application');
        this.buttonItemExists('Adjudicate Application', 'Funding Application');
      }

      switch (this.selectedApplication.statusId) {
        case StatusEnum.Saved: {
          this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
          this.buttonItemExists('Adjudicate Application', 'Funding Application');
          this.buttonItemExists('Evaluate Application', 'Funding Application');
          this.buttonItemExists('Approve Application', 'Funding Application');
          this.buttonItemExists('Download Assessment', 'Workflow Application');
          break;
        }
        case StatusEnum.PendingReview: {
          this.buttonItemExists('Edit Application', 'Funding Application');
          this.buttonItemExists('Adjudicate Application', 'Funding Application');
          this.buttonItemExists('Evaluate Application', 'Funding Application');
          this.buttonItemExists('Approve Application', 'Funding Application');
          this.buttonItemExists('Download Assessment', 'Workflow Application');
          break;
        }
        case StatusEnum.Verified: {
          this.buttonItemExists('Edit Application', 'Funding Application');
          this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
          this.buttonItemExists('Adjudicate Application', 'Funding Application');
          this.buttonItemExists('Approve Application', 'Funding Application');
          break;
        }
        case StatusEnum.Evaluated: {
          this.buttonItemExists('Edit Application', 'Funding Application');
          this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
          this.buttonItemExists('Evaluate Application', 'Funding Application');
          this.buttonItemExists('Approve Application', 'Funding Application');
          break;
        }
        case StatusEnum.Adjudicated: {
          this.buttonItemExists('Edit Application', 'Funding Application');
          this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
          this.buttonItemExists('Adjudicate Application', 'Funding Application');
          this.buttonItemExists('Evaluate Application', 'Funding Application');
          break;
        }
        case StatusEnum.Approved: {
          this.buttonItemExists('Edit Application', 'Funding Application');
          this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
          this.buttonItemExists('Adjudicate Application', 'Funding Application');
          this.buttonItemExists('Evaluate Application', 'Funding Application');
          this.buttonItemExists('Approve Application', 'Funding Application');
          break;
        }
        case StatusEnum.NonCompliance: {
          this.buttonItemExists('Edit Application', 'Funding Application');
          this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
          this.buttonItemExists('Evaluate Application', 'Funding Application');
          this.buttonItemExists('Approve Application', 'Funding Application');
          break;
        }

        case StatusEnum.Declined: {
          this.buttonItemExists('Edit Application', 'Funding Application');
          this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
          this.buttonItemExists('Evaluate Application', 'Funding Application');
          break;
        }
      }
    }

    if (this.selectedApplication.applicationPeriod.applicationTypeId === ApplicationTypeEnum.QC && this.selectedApplication.applicationPeriod.departmentId === 11) {

      // Hide Service Provision actions
      this.buttonItemExists('Edit Application', 'Service Provision');
      this.buttonItemExists('Review Application', 'Service Provision');
      this.buttonItemExists('Approve Application', 'Service Provision');
      this.buttonItemExists('Upload SLA', 'Service Provision');
      this.buttonItemExists('View Application', 'Service Provision');
      this.buttonItemExists('Download Assessment', 'Workflow Application');
      this.buttonItemExists('Delete Application', 'Service Provision');
      this.buttonItemExists('Edit Application', 'Funding Application');
      this.buttonItemExists('Download Application', 'Funding Application');
      this.buttonItemExists('View Application', 'Funding Application');
      this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
      this.buttonItemExists('Adjudicate Application', 'Funding Application');
      this.buttonItemExists('Evaluate Application', 'Funding Application');
      this.buttonItemExists('Approve Application', 'Funding Application');
      this.buttonItemExists('Edit Application', 'Funding Application');
      this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
      this.buttonItemExists('Adjudicate Application', 'Funding Application');
      this.buttonItemExists('Evaluate Application', 'Funding Application');
      this.buttonItemExists('Approve Application', 'Funding Application');
      this.buttonItemExists('Delete Application', 'Funding Application');

     switch (this.selectedApplication.statusId) {
        case StatusEnum.PendingReview: {
          this.buttonItemExists('Delete Application', 'Funded Npo');
          this.buttonItemExists('Edit Application', 'Funded Npo');
         break;
       }
     }

     switch (this.selectedApplication.statusId) {
      case StatusEnum.Saved: {
        this.buttonItemExists('Review Application', 'Funded Npo');
       break;
     }
   }

     if(this.selectedApplication.statusId !== StatusEnum.Saved)
     {
      this.buttonItemExists('Edit Application', 'Funded Npo');
     }
    }
  }

  private buttonItemExists(label: string, target: string) {
    let buttonItem = this.buttonItems[0].items.find(x => x.label === label && x.target === target);

    if (buttonItem)
      buttonItem.visible = false;
  }

  private buildOptionItems() {
    this.optionItems = [];

    if (this.profile) {

      this.optionItems = [{
        label: 'Options',
        items: []
      }];

      if (this.IsAuthorized(PermissionsEnum.ViewOptions) && this.IsAuthorized(PermissionsEnum.ViewManageIndicatorsOption)) {
        this.optionItems[0].items.push({
          label: 'Manage Indicators',
          icon: 'fa fa-tags wcg-icon',
          command: () => {
            this._router.navigateByUrl('workplan-indicator/manage/' + this.selectedApplication.npoId);
          }
        });
      }


      if (this.IsAuthorized(PermissionsEnum.AddScorecard)) {
        this.optionItems[0].items.push({
          label: 'Add Score Card',
          icon: 'fa fa-file-text-o',
          command: () => {
            this._router.navigateByUrl('scorecard/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ReviewScorecard) || this.IsAuthorized(PermissionsEnum.ViewScorecard)) {
        this.optionItems[0].items.push({
          label: 'Review Score Card',
          icon: 'fa fa-file-text-o',
          command: () => {
            this._router.navigateByUrl('reviewScorecard/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewOptions) && this.IsAuthorized(PermissionsEnum.ViewSummaryOption)) {
        this.optionItems[0].items.push({
          label: 'Summary',
          icon: 'fa fa-tasks wcg-icon',
          command: () => {
            this._router.navigateByUrl('workplan-indicator/summary/' + this.selectedApplication.npoId);
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
}
