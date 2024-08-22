import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { ActionSequence } from 'protractor';
import { AccessStatusEnum, ApplicationTypeEnum, PermissionsEnum, RoleEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IApplicationPeriod, ICapturedResponse, INpo, IResponseOptions, IStatus, IUser } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { EvaluationService } from 'src/app/services/evaluation/evaluation.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-application-list',
  templateUrl: './application-list.component.html',
  styleUrls: ['./application-list.component.css']
})
export class ApplicationListComponent implements OnInit {
  displayDialog: boolean;
  displayReviewDialog: boolean;
  

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

  reviewerlist: IUser[];
  selectedreviewerlist: IUser[] = [];

  cols: any[];
  allApplications: IApplication[];

  // This is the selected application when clicking on option buttons...
  selectedApplication: IApplication;
  capturedResponses: ICapturedResponse[];
  capturedResponse: ICapturedResponse[];
  isSystemAdmin: boolean = true;
  isAdmin: boolean = false;
  isMainReviewer: boolean = false;
  hasAdminRole: boolean = false;
  headerTitle: string;
  statusName: string;
  allNpos: INpo[];

  buttonItems: MenuItem[];
  optionItems: MenuItem[];
  _responses: IResponseOptions[];
  _response: IResponseOptions[];
  response: number;

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  canShowOptions: boolean = false;
  canShowOptionsNpo: boolean = false;
  reviewerForm: FormGroup;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _npoRepo: NpoService,
    private _loggerService: LoggerService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private _evaluationService: EvaluationService,
    private _formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this._spinner.show();
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewApplications))
          this._router.navigate(['401']);

        console.log('ReviewApplication', this.IsAuthorized(PermissionsEnum.ReviewApplication));

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.isAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.Admin });
        this.isMainReviewer = profile.roles.some(function (role) { return role.id === RoleEnum.MainReviewer });

        if (this.isSystemAdmin || this.isAdmin)
          this.hasAdminRole = true;

        this.loadNpos();
        this.reviewers();
        this.getAllCapturedResponses();
        this.getAllResponses();
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

    this.reviewerForm = this._formBuilder.group({});
  }

  reviewers() {
     this._applicationRepo.reviewers().subscribe(
      (results) => {
        this.reviewerlist = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  btnSubmitReviewers(){
    this.submitReviewers();
  }

  private submitReviewers() {
    const users = this.selectedreviewerlist.map(user => ({
        fullName: user.fullName,
        email: user.email,
        id: user.id
    }));
    
    this._applicationRepo.UpdateReviewers(Number(this.selectedApplication.id), users).subscribe(
      (results) => {
        this.displayReviewDialog = false;
        this._router.navigateByUrl('applications');
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
}

  submit() {
    this.UpdateInitiateScorecardValue();
  }

  private UpdateInitiateScorecardValue() {
    const users = this.selectedreviewerlist.map(user => ({
        fullName: user.fullName,
        email: user.email,
        id: user.id
    }));
    
    this._applicationRepo.UpdateInitiateScorecardValueAndEmail(Number(this.selectedApplication.id), users).subscribe(
      (results) => {
        this.displayDialog = false;
        this._router.navigateByUrl('applications');
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
}


  disableSubmit() {

    if (this.selectedreviewerlist.length == 0)
      return true;

    return false;
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

        results.forEach(
          application => {
           this.updateStatus(application.status, application.statusId, application.applicationPeriod.applicationType.name);     
          }
        )

        results.forEach(
          application => {
           this.getRejectedInformation(application, application.id);     
          }
        )

        results.forEach(
          application => {
           this.getSummarySubmissionStatus(application, application.id);     
          }
        )
        
        this.allApplications = results;       
        this.canShowOptions = this.allApplications.some(function (item) { return item.statusId === StatusEnum.AcceptedSLA});
        this.canShowOptionsNpo = this.allApplications.some(function (item) { return item.statusId === StatusEnum.Approved 
          && item.applicationPeriod.applicationTypeId === ApplicationTypeEnum.QC && item.applicationPeriod.departmentId === 11});
              
        
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

  private updateStatus(status: IStatus, statusId: number, appType: string) {
    if(appType != 'Service Provision')
    {
      if(statusId === 6 || statusId === 13 || statusId === 22)
      {
        status.name = 'In Progress';
      }
    }   
  }

  private getRejectedInformation(application: IApplication, applicationId: number) {
   if(this._response !== undefined)
   {
    this._response = this._responses?.filter(x => x.createdUserId === this.profile.id && x.rejectionFlag === 1 && x.fundingApplicationId === applicationId);
    application.rejectedScorecard = this._responses.length;
   }    
   else{
    application.rejectedScorecard = 0;
   }
   
  }

  private getAllResponses() {
    this._evaluationService.getAllResponses().subscribe(
      (results) => {
        this._responses = results;
      },
      (err) => {
        this._loggerService.logException(err);
      }
    );
  }

  private getSummarySubmissionStatus(application: IApplication, applicationId: number) {

    if(this.capturedResponses != undefined)
    {
      this.capturedResponse = this.capturedResponses.filter(x => x.questionCategoryId === 100 && x.isActive === true && x.fundingApplicationId === applicationId);
    }   
    if (this.capturedResponse.length > 0) {
      application.submittedScorecard = this.capturedResponses.length
    }
    else{
      application.submittedScorecard = 0;
    }
  }

  private getAllCapturedResponses() {
    this._evaluationService.getAllCapturedResponses().subscribe(
      (results) => {
        this.capturedResponses = results;
      })
  }

  public selectedResponses(fid: number) {
    this._evaluationService.getResponse(Number(fid)).subscribe(
      (results) => {
        this._responses = results.filter(x => x.createdUserId === this.profile.id && x.rejectionFlag === 1);
        this.response = this._responses.length;
      },
      (err) => {
        this._loggerService.logException(err);
      }
    );
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
          label: 'Download Workplan',
          target: 'Workplan',
          icon: 'fa fa-download',
          command: () => {
            this._router.navigate(['/', { outlets: { 'print': ['print', this.selectedApplication.id, 4] } }]);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DownloadAssessmentOption)) {
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

      //mainreviwer
      if (this.IsAuthorized(PermissionsEnum.ReviewApplication) && this.isMainReviewer) {
        this.buttonItems[0].items.push({
          label: 'Select Reviewers',
          target: 'Work Plan',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this.displayReviewDialog = true;
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

  public updateOptionItems()
  {
     // Show all options
     this.optionItems[0].items.forEach(option => {
      option.visible = true;
    });

    if (this.selectedApplication.applicationPeriod.applicationTypeId === ApplicationTypeEnum.QC && this.selectedApplication.applicationPeriod.departmentId === 11)
    {
      this.optionItemExists('Manage Indicators');  
      this.optionItemExists('Capture Scorecard');  
      this.optionItemExists('Review Score Card');  
      this.optionItemExists('Initiate Score Card');  
      this.optionItemExists('Conclude Scorecard');  
      this.optionItemExists('Summary');  
    }
    else{
      this.optionItemExists('Adjudicate Funded Npo');  
      this.optionItemExists('Review Adjudicated Funded Npo'); 
      this.optionItemExists('Businessplan Indicators'); 
      this.optionItemExists('BusinessPlan Summary');   
    }

    if (this.selectedApplication.npoUserTrackings.length > 0) {
      if (!this.selectedApplication.npoUserTrackings.some(item => item.userId === this.profile.id)) 
      {
          this.optionItemExists('Capture Scorecard'); 
      }  
    }

    if(this.selectedApplication.initiateScorecard === 1)
    {
      this.optionItemExists('Initiate Score Card');      
    } 
     
    if(this.selectedApplication.closeScorecard === 0)
    {
      this.optionItemExists('Conclude Scorecard');
    }  
    
    if(this.selectedApplication.initiateScorecard === 0 && this.selectedApplication.scorecardCount > 0)
    { 
      if(this.selectedApplication.rejectedScorecard === 0)
      {
        this.optionItemExists('Capture Scorecard');
      }
    }

    if(this.selectedApplication.initiateScorecard === 0 && this.selectedApplication.scorecardCount === 0)
    {
      if(this.selectedApplication.rejectedScorecard === 0)
      {
        this.optionItemExists('Capture Scorecard');
      }
    }

    if((this.profile.roles[0].id !== Number(RoleEnum.SystemAdmin)) || (this.profile.roles[0].id !== Number(RoleEnum.SystemAdmin)))
    {
      if(this.selectedApplication.submittedScorecard === 0)
      {
        this.optionItemExists('Review Score Card');
      }
    }
  }

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
      
      if (this.selectedApplication.npoWorkPlanReviewerTrackings.length > 0) {
        if (!this.selectedApplication.npoWorkPlanReviewerTrackings.some(item => item.userId === this.profile.id)) 
        {
          if(!this.isMainReviewer)
            {
              this.buttonItemExists('Review Application', 'Service Provision');
            }
        }  
      }

      if (this.selectedApplication.npoWorkPlanApproverTrackings.length > 0) {
        if (!this.selectedApplication.npoWorkPlanApproverTrackings.some(item => item.userId === this.profile.id)) 
        {
          this.buttonItemExists('Approve Application', 'Service Provision');
        }  
      }

      if (this.selectedApplication.statusId !== StatusEnum.PendingReview) {
        this.buttonItemExists('Select Reviewers', 'Work Plan');
       }

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

    if (this.selectedApplication.applicationPeriod.applicationTypeId === ApplicationTypeEnum.FA || (this.selectedApplication.applicationPeriod.applicationTypeId === ApplicationTypeEnum.QC && this.selectedApplication.applicationPeriod.departmentId !== 11)) {

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
      this.buttonItemExists('Download Workplan', 'Workplan');
      this.buttonItemExists('Select Reviewers', 'Work Plan');
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
        case StatusEnum.New: {
          this.buttonItemExists('Pre-Evaluate Application', 'Funding Application');
          this.buttonItemExists('Adjudicate Application', 'Funding Application');
          this.buttonItemExists('Evaluate Application', 'Funding Application');
          this.buttonItemExists('Approve Application', 'Funding Application');
          this.buttonItemExists('Adjudicate Application', 'Funding Application');
          this.buttonItemExists('Download Assessment', 'Workflow Application');
          this.buttonItemExists('Download Application', 'Funding Application');
          this.buttonItemExists('Delete Application', 'Funded Npo');
          break;
        }
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
      this.buttonItemExists('Download Workplan', 'Workplan');
      this.buttonItemExists('Select Reviewers', 'Work Plan');

      switch (this.selectedApplication.statusId) {
          case StatusEnum.PendingReview: {
            this.buttonItemExists('Delete Application', 'Funded Npo');
            this.buttonItemExists('Edit Application', 'Funded Npo');
          break;
        }
      }

      switch (this.selectedApplication.statusId) {
        case StatusEnum.Saved:
          case StatusEnum.Approved:
            case StatusEnum.Declined: {
          this.buttonItemExists('Review Application', 'Funded Npo');
        break;
      }
   }

   switch (this.selectedApplication.statusId) {
      case StatusEnum.Approved:
        case StatusEnum.Declined: {
      this.buttonItemExists('Edit Application', 'Funded Npo');
     break;
   }
 }

  }
  }

  private buttonItemExists(label: string, target: string) {
    let buttonItem = this.buttonItems[0].items.find(x => x.label === label && x.target === target);

    if (buttonItem)
      buttonItem.visible = false;
  }

  private optionItemExists(label: string) {
    let optionItem = this.optionItems[0].items.find(x => x.label === label);

    if (optionItem)
    optionItem.visible = false;
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

      if (this.IsAuthorized(PermissionsEnum.ViewOptions) && this.IsAuthorized(PermissionsEnum.ViewManageIndicatorsOption)) {
        this.optionItems[0].items.push({
          label: 'Businessplan Indicators',
          icon: 'fa fa-tags wcg-icon',
          command: () => {
            this._router.navigateByUrl('businessplan-indicator/manage/' + this.selectedApplication.npoId);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.AddScorecard)) {
        this.optionItems[0].items.push({
          label: 'Capture Scorecard',
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

      if (this.IsAuthorized(PermissionsEnum.InitiateScorecard)) {
          this.optionItems[0].items.push({
            label: 'Initiate Score Card',
            icon: 'fa fa-envelope-open-o',
            command: () => {
              this.displayDialog = true;
            }
          });
      }

      if (this.IsAuthorized(PermissionsEnum.CloseScorecard)) {
        this.optionItems[0].items.push({
          label: 'Conclude Scorecard',
          icon: 'fa fa-window-close-o',
          command: () => {
            this._router.navigateByUrl('close/' + this.selectedApplication.id);
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

      if (this.IsAuthorized(PermissionsEnum.ViewOptions) && this.IsAuthorized(PermissionsEnum.ViewSummaryOption)) {
        this.optionItems[0].items.push({
          label: 'BusinessPlan Summary',
          icon: 'fa fa-tasks wcg-icon',
          command: () => {
            this._router.navigateByUrl('businessplan-indicator/summary/' + this.selectedApplication.npoId);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.AdjudicateFundedNpo)) {
        this.optionItems[0].items.push({
          label: 'Adjudicate Funded Npo',
          icon: 'fa fa-file-text-o',
          command: () => {
            this._router.navigateByUrl('adjudicateNpo/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ReviewAdjudicatedFundedNpo)) {
        this.optionItems[0].items.push({
          label: 'Review Adjudicated Funded Npo',
          icon: 'fa fa-file-text-o',
          command: () => {
            this._router.navigateByUrl('reviewAdjudicatedNpo/' + this.selectedApplication.id);
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
