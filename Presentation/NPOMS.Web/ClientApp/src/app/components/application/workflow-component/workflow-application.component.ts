import { ProjectImplementationComponent } from './../application-steps/funding-application/project-implementation/project-implementation.component';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ApplicationTypeEnum, DropdownTypeEnum, EntityTypeEnum, FacilityTypeEnum, IQuestionResponseViewModel, IResponseHistory, IResponseOption, PermissionsEnum, QuestionCategoryEnum, ServiceProvisionStepsEnum, StatusEnum, ResponseTypeEnum, IResponseType, RoleEnum, EntityEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationApproval, IApplicationAudit, IApplicationComment, IApplicationDetails, ICapturedResponse, IDepartment, IDocumentStore, IFacilityList, IMonitoringAndEvaluation, INpo, INpoProfile, IObjective, IProgramme, IProjectImplementation, IProjectInformation, IResource, IStatus, ISubProgramme, ISustainabilityPlan, IUser, IResponse, IQuestionCategory } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { EvaluationService } from 'src/app/services/evaluation/evaluation.service';
import { DatePipe } from '@angular/common';
import { style } from '@angular/animations';

@Component({
  selector: 'app-workflow-application',
  templateUrl: './workflow-application.component.html',
  styleUrls: ['./workflow-application.component.css']
})
export class WorkflowApplicationComponent implements OnInit {
  isSystemAdmin: boolean;
  isAdmin: boolean;
  hasAdminRole: boolean;
 

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

  public get ServiceProvisionStepsEnum(): typeof ServiceProvisionStepsEnum {
    return ServiceProvisionStepsEnum;
  }

  public get FacilityTypeEnum(): typeof FacilityTypeEnum {
    return FacilityTypeEnum;
  }

  _recommendation: boolean = false;
  isChecked: boolean = false;
  isEvalDeclarationChecked: boolean = false;
  isAdjDeclarationChecked: boolean = false;
  isAprDeclarationChecked: boolean = false;
 

  capturedPreEvaluationComment: string;
  capturedEvaluationComment: string;
  capturedAdjudicationComment: string;
  capturedApprovalComment: string;
  preEvalSignedByUser: string;
  evalSignedByUser: string;
  adjSignedByUser: string;
  aprSignedByUser: string;
  headerTitle: string;

  evalVerificationDate: Date;
  adjVerificationDate: Date;
  aprVerificationDate: Date;

  paramSubcriptions: Subscription;
  id: string;
  preEvaluatedComment: string;
  signedByUser: string;
  verificationDate: Date;
  selectedApplication: IApplication;
  profile: IUser;
  application: IApplication;
  isApplicationAvailable: boolean;
  isDataAvailable: boolean;
  npo: INpo;
  npoProfile: INpoProfile;

  applicationDetailView: IApplicationDetails;
  projInfoView:IProjectInformation;
  projImplView:IProjectImplementation;

  isObjectivesAvailable: boolean;
  isActivitiesAvailable: boolean;
  isSustainabilityAvailable: boolean;
  isResourcesAvailable: boolean;

  isApplicationDetailsAvailable: boolean;
  isProjectInformationAvailable: boolean;
  isProjectImplementationAvailable: boolean;
  isMonAndEvalAvailable: boolean;

  objectives: IObjective[] = [];
  activities: IActivity[] = [];
  sustainabilityPlans: ISustainabilityPlan[] = [];
  resources: IResource[] = [];

  applicationDetails: IApplicationDetails[] = [];
  projectInformations: IProjectInformation[] = [];
  projectImplementations: IProjectImplementation[] =[];
  monitoringAndEvaluations: IMonitoringAndEvaluation[] =[];

  applicationDetailsCols: any[];
  projectInformationCols: any[];
  projectImplementationCols: any[];
  monitoringAndEvaluationCols: any[];

  objectiveCols: any[];
  commentCols: any;
  activityCols: any[];
  sustainabilityPlanCols: any[];
  resourceCols: any[];
  auditCols: any[];
  documentCols: any[];
  documentCols1: any[];


  objective: IObjective = {} as IObjective;
  activity: IActivity = {} as IActivity;
  sustainabilityPlan: ISustainabilityPlan = {} as ISustainabilityPlan;
  resource: IResource = {} as IResource;

  applicationDetail: IApplicationDetails = {} as IApplicationDetails;
  projectInformation: IProjectInformation = {} as IProjectInformation;
  projectImplementation: IProjectImplementation = {} as IProjectImplementation;
  monitoringAndEvaluation: IMonitoringAndEvaluation = {} as IMonitoringAndEvaluation;

  displayObjectiveDialog: boolean;
  displayActivityDialog: boolean;
  displaySustainabilityPlanDialog: boolean;
  displayResourceDialog: boolean;
  displayAllCommentDialog: boolean;
  displayHistory: boolean;
  totalAverageScore: number;
  displayApplicationDetaileDialog: boolean;
  displayProjectInformationDialog: boolean;
  displayProjectImplementationDialog: boolean;
  displayMonitoringAndEvaluationDialog: boolean;

  allProgrammes: IProgramme[];
  programmes: IProgramme[] = [];
  selectedProgrammes: IProgramme[];
  allSubProgrammes: ISubProgramme[];
  subProgrammes: ISubProgramme[] = [];
  selectedSubProgrammes: ISubProgramme[];
  selectedProgrammesText: string;
  selectedSubProgrammesText: string;

  selectedFacilities: IFacilityList[];
  QuestionCategoryentities: IQuestionCategory[];
  allApplicationComments: IApplicationComment[] = [];
  filteredApplicationComments: IApplicationComment[] = [];
  ResponseTypeentities: IResponseType[];
  selectedObjective: IObjective;
  selectedActivity: IActivity;

  rowGroupMetadataActivities: any[];
  rowGroupMetadataSustainability: any[];
  rowGroupMetadataResources: any[];

  allAssignedFacilities: IFacilityList[];

  applicationAudits: IApplicationAudit[];
  documents: IDocumentStore[];

  mainReview: IApplicationAudit;
  approveFromCoCT: IApplicationApproval;
  approveFromDoH: IApplicationApproval;

  selectedFacilitiesText: string;

  allQuestionnaires: IQuestionResponseViewModel[];
  preEvaluationQuestionnaire: IQuestionResponseViewModel[];
  evaluationQuestionnaire: IQuestionResponseViewModel[];
  adjudicationQuestionnaire: IQuestionResponseViewModel[];
  approveQuestionnaire: IQuestionResponseViewModel[];

  allCompletedQuestionnaires: IQuestionResponseViewModel[];
  completedPreEvaluationQuestionnaires: IQuestionResponseViewModel[];
  completedEvaluationQuestionnaires: IQuestionResponseViewModel[];
  completedAdjudicationQuestionnaires: IQuestionResponseViewModel[];

  responseOptions: IResponseOption[];
  responseHistory: IResponseHistory[];
  displayHistoryDialog: boolean;
  historyCols: any[];

  allCapturedResponses: ICapturedResponse[];
  capturedResponses: ICapturedResponse[];
  capturedResponse = {} as ICapturedResponse;
  PreEvaluatedCapturedResponses: ICapturedResponse[];
  EvaluatedCapturedResponses: ICapturedResponse[];
  AdjudicationCapturedResponses: ICapturedResponse[];
  ApprovalCapturedResponses: ICapturedResponse[];

  weightExceedingMessage: Message[] = [];
  zeroWeightingMessage: Message[] = [];

  statuses: IStatus[];
  evaluationStatuses: IStatus[];
  adjudicationStatuses: IStatus[];
  approvalStatuses: IStatus[];
  selectedStatus: IStatus;
  adjSelectedStatus: IStatus;
  aprSelectedStatus: IStatus;
  

  hasCapturedPreEvaluation: boolean = false;  
  hasCapturedAdjudication: boolean = false;
  hasCapturedEvaluation: boolean = false;
  hasCapturedApproval: boolean = false;
  setDisable: boolean = true;
  isApprovalDisable: boolean = false;
  isAdjudicationDisable: boolean = false;
  isEvaluationDisable: boolean = false;
  isPreEvaluationDisable: boolean = false;
  setVisible: boolean = false;

  constructor(

   
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _dropdownRepo: DropdownService,
    private _applicationPeriodRepo: ApplicationPeriodService,
    private _evaluationService: EvaluationService,
    private _documentStore: DocumentStoreService,
    private _loggerService: LoggerService,
    private _dropdownService: DropdownService,
    private confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private _datepipe: DatePipe
  ) { 
 
  }

  ngOnInit(): void {


    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');      
    });

    var splitUrl = window.location.href.split('/');
    this.headerTitle = splitUrl[5];

    this.loadApplication();

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewApplications))
        this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.isAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.Admin });

        if (this.isSystemAdmin || this.isAdmin)
          this.hasAdminRole = true;
      }
    });

    this.getQuestionCategory();
    this.getResponseType();

    this.objectiveCols = [
      { header: 'Objective Name', width: '20%' },
      { header: 'Funding Source', width: '15%' },
      { header: 'Funding Period', width: '25%' },
      { header: 'Recipient Type', width: '15%' },
      { header: 'Budget', width: '15%' }
    ];

    this.projectImplementationCols = [
      { header: 'Description', width: '45%' },
      { header: 'Beneficiaries', width: '25%' },
      { header: 'Budget', width: '15%' },
      { header: 'Actions', width: '10%' }
    ];

    this.commentCols = [
      { header: '', width: '5%' },
      { header: 'Comment', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];

    this.activityCols = [
      { header: 'Activity Name', width: '20%' },
      { header: 'Activity Type', width: '10%' },
      { header: 'Timeline', width: '15%' },
      { header: 'Target', width: '10%' },
      { header: 'Facilities and/or Community Places', width: '38%' }
    ];

    this.sustainabilityPlanCols = [
      { header: 'Risk', width: '47%' },
      { header: 'Mitigation', width: '46%' }
    ];

    this.resourceCols = [
      { field: 'resourceType.name', header: 'Resource Type', width: '10%' },
      { field: 'serviceType.name', header: 'Service Type', width: '15%' },
      { field: 'allocationType.name', header: 'Allocation Type', width: '10%' },
      { field: 'provisionType.name', header: 'Provided vs Required', width: '12%' },
      { field: 'resourceList.name', header: 'Resource', width: '35%' },
      { field: 'numberOfResources', header: 'Number of Resources', width: '11%' }
    ];

    this.auditCols = [
      { header: '', width: '5%' },
      { header: 'Status', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];

    this.documentCols = [
      { header: '', width: '5%' },
      { header: 'Document Name', width: '45%' },
      { header: 'Document Type', width: '25%' },
      { header: 'Size', width: '10%' },
      { header: 'Uploaded Date', width: '10%' },
      { header: 'Actions', width: '5%' }
    ];
    this.documentCols1 = [
      { header: 'Id', width: '5%' },
      {  field: 'name', header: 'Document Type', width: '35%' },
      { header: 'Document Name', width: '45%' },
      // { header: 'Size', width: '10%' },
      // { header: 'Uploaded Date', width: '10%' },
      { header: 'Actions', width: '10%' }
    ];
    this.applicationDetailsCols = [
      { header: 'Objective Name', width: '20%' },
      { header: 'Funding Source', width: '15%' },
      { header: 'Funding Period', width: '25%' },
      { header: 'Recipient Type', width: '15%' },
      { header: 'Budget', width: '15%' }
    ];


    this.historyCols = [
      { field: 'responseOption.name', header: 'Response', width: '10%' },
      { field: 'comment', header: 'Comment', width: '50%' },
      { field: 'createdUser.fullName', header: 'Created By', width: '20%' },
      { field: 'createdDateTime', header: 'Created Date', width: '20%' }
    ];

  }


  private loadApplication() {
    //this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        this.application = results;
       
        if(this.application.statusId <= 3)
        {
          this.setDisable = false;
        }
        this.loadQuestionnaire();
       
        this.loadAllProgrammes();
        this.loadAllSubProgrammes();
        this.loadFacilities();

        this.loadObjectives();
        this.loadActivities();
        this.loadSustainabilityPlans();
        this.loadResources();

        this.loadApplicationComments();
    //    this.getDocuments();
        this.getAuditHistory();
        this.loadApplicationApprovals();

      

      },
    );
  }

  
  onCheckboxChange(event: any) {
    this.isChecked = event.target.checked;
    if (this.isChecked == true) {
      this._recommendation = true;
    } else {
      this._recommendation = false;
    }
  }

  onDeclarationCheckboxChange(event: any) {
    this.isEvalDeclarationChecked = event.target.checked;
    if (this.isEvalDeclarationChecked) {
      this._recommendation = true;
      this.setVisible = true;
    } else {
      this._recommendation = false;
      this.setVisible = false;
    }
  }
 
  onEvlCheckboxChange(event: any) {    
    var pnlEvaluation = document.getElementById("pnlEvaluation");
    var pnlEvaluation1 = document.getElementById("pnlEvaluation1");
    this.isEvalDeclarationChecked = event == false ? event : event.target.checked;
    if (this.isEvalDeclarationChecked == true) {
      pnlEvaluation.style.display = "block";
      pnlEvaluation1.style.display = "block";
    } else {
      pnlEvaluation.style.display = "none";
      pnlEvaluation1.style.display = "none";
  }
}


onAdjCheckboxChange(event: any) {
  var pnlAdjudication = document.getElementById("pnlAdjudication");
  this.isAdjDeclarationChecked = event.target.checked;
  if (this.isAdjDeclarationChecked) {
    pnlAdjudication.style.display = "block";
  } else {
    pnlAdjudication.style.display = "none";
}
}

onAprCheckboxChange(event: any) { 

  var pnlApproval = document.getElementById("pnlApproval");
  this.isAprDeclarationChecked = event.target.checked;
  if (this.isAprDeclarationChecked) {
    pnlApproval.style.display = "block";
  } else {
    pnlApproval.style.display = "none";
}
}
  private loadApplicationApprovals() {
    this._applicationRepo.getApplicationApprovals(this.application.id).subscribe(
      (results) => {
        this.approveFromCoCT = results.filter(x => x.approvedFrom === 'CoCT')[0];
        this.approveFromDoH = results.filter(x => x.approvedFrom === 'DoH')[0];
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  private getAuditHistory() {
    this._applicationRepo.getApplicationAudits(this.application.id).subscribe(
      (results) => {
        this.applicationAudits = results;
        this.mainReview = results.filter(x => x.statusId === StatusEnum.PendingApproval)[0];
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private getDocuments() {
    this._documentStore.get(Number(this.application.id), EntityTypeEnum.SLA).subscribe(
      (res) => {
        this.documents = res.filter(x => x.entity === EntityEnum.Application);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadApplicationComments() {
    this._applicationRepo.getAllApplicationComments(this.application.id).subscribe(
      (results) => {
        this.allApplicationComments = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSustainabilityPlans() {
    this._applicationRepo.getAllSustainabilityPlans(this.application).subscribe(
      (results) => {
        this.sustainabilityPlans = results.filter(x => x.isActive === true);
        this.updateRowGroupMetaData1(ServiceProvisionStepsEnum.Sustainability);
        this.isSustainabilityAvailable = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadResources() {
    this._applicationRepo.getAllResources(this.application).subscribe(
      (results) => {
        this.resources = results.filter(x => x.isActive === true);
        this.updateRowGroupMetaData1(ServiceProvisionStepsEnum.Resourcing);
        this.isResourcesAvailable = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadFacilities() {
    this._applicationRepo.getAssignedFacilities(this.application).subscribe(
      (results) => {
        this.allAssignedFacilities = results;
        this.allDataLoaded();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadAllSubProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
      (results) => {
        this.allSubProgrammes = results;
        this.allDataLoaded();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadAllProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
      (results) => {
        this.allProgrammes = results;
        this.loadApplicationPeriod();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadApplicationPeriod() {
    this._applicationPeriodRepo.getApplicationPeriodById(Number(this.application.applicationPeriodId)).subscribe(
      (results) => {
        this.loadProgrammesForDepartment(results.department);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProgrammesForDepartment(department: IDepartment) {
    this.programmes = [];
    this.subProgrammes = [];

    if (department.id != null) {
      for (var i = 0; i < this.allProgrammes.length; i++) {
        if (this.allProgrammes[i].departmentId == department.id) {
          this.programmes.push(this.allProgrammes[i]);
        }
      }
    }
  }

  private loadObjectives() {
    this._applicationRepo.getAllObjectives(this.application).subscribe(
      (results) => {
        this.objectives = results.filter(x => x.isActive === true);
        this.isObjectivesAvailable = true;
        this.allDataLoaded();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  private allDataLoaded() {
    if (this.allProgrammes && this.allSubProgrammes && this.allAssignedFacilities && this.objectives && this.activities && this.sustainabilityPlans && this.resources) {
      this.isApplicationAvailable = true;
      this._spinner.hide();
    }
  }
  private loadActivities() {
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.activities = results.filter(x => x.isActive === true);
        this.getFacilityListText(results);
        this.updateRowGroupMetaData1(ServiceProvisionStepsEnum.Activities);
        this.isActivitiesAvailable = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  updateRowGroupMetaData1(serviceProvisionStepId: ServiceProvisionStepsEnum) {

    switch (serviceProvisionStepId) {
      case ServiceProvisionStepsEnum.Activities:
        this.rowGroupMetadataActivities = [];
        this.activities = this.activities.sort((a, b) => a.objectiveId - b.objectiveId);

        if (this.activities) {
          this.activities.forEach(element => {
            var itemExists = this.rowGroupMetadataActivities.some(function (data) { return data.itemName === element.objective.name });

            this.rowGroupMetadataActivities.push({
              itemName: element.objective.name,
              itemExists: itemExists
            });
          });
        }
        break;
      case ServiceProvisionStepsEnum.Sustainability:
        this.rowGroupMetadataSustainability = [];
        this.sustainabilityPlans = this.sustainabilityPlans.sort((a, b) => a.activityId - b.activityId);

        if (this.sustainabilityPlans) {
          this.sustainabilityPlans.forEach(element => {
            var itemExists = this.rowGroupMetadataSustainability.some(function (data) { return data.itemName === element.activity.activityList.description });

            this.rowGroupMetadataSustainability.push({
              itemName: element.activity.activityList.description,
              itemExists: itemExists
            });
          });
        }
        break;
      case ServiceProvisionStepsEnum.Resourcing:
        this.rowGroupMetadataResources = [];
        this.resources = this.resources.sort((a, b) => a.activityId - b.activityId);

        if (this.resources) {
          this.resources.forEach(element => {
            var itemExists = this.rowGroupMetadataResources.some(function (data) { return data.itemName === element.activity.activityList.description });

            this.rowGroupMetadataResources.push({
              itemName: element.activity.activityList.description,
              itemExists: itemExists
            });
          });
        }
        break;
    }

    this.allDataLoaded();
  }

  private getFacilityListText(activities: IActivity[]) {
    activities.forEach(activity => {
      let allFacilityLists: string = "";

      activity.activityFacilityLists.forEach(item => {
        allFacilityLists += item.facilityList.name + "; ";
      });

      activity.facilityListText = allFacilityLists.slice(0, -2);
    });
  }

  public hasComment(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return item.hasComment === true });
  }

  public hasDocument(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return item.hasDocument === true });
  }

  public getColspan(questionnaire: IQuestionResponseViewModel[], defaultColspan: number) {
    let colspan = defaultColspan;

    colspan = this.hasComment(questionnaire) ? colspan + 1 : colspan;
    colspan = this.hasDocument(questionnaire) ? colspan + 1 : colspan;

    return colspan;
  }

  public getQuestionCategory()
  {
    
    this._dropdownService.getEntities(DropdownTypeEnum.QuestionCategory, true).subscribe(
      (results) => {
        this.QuestionCategoryentities  = results;       
      },
    );
  }

  private getResponseType() {
    this._dropdownService.getEntities(DropdownTypeEnum.ResponseType, true).subscribe(
      (results) => {
        this.ResponseTypeentities = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide()
      }
    );
  }

 

  public submit(questionnaire: IQuestionResponseViewModel[], questionCategory: QuestionCategoryEnum) {
    // if (this.canContinue(questionnaire)) {
    //   this._spinner.show();
    //   this.createCapturedResponse(questionCategory);
    // }

    this.createCapturedResponse(questionCategory);
  }

  private createCapturedResponse(questionCategoryId: QuestionCategoryEnum) {
    let id = this.QuestionCategoryentities.filter(x=> x.name === questionCategoryId.toString());
    let status: number;
    let declaration: boolean;
    let comment: string;
    let selectedStatus: number
    switch (questionCategoryId.toString()) {
      case "PreEvaluation": {
        status = 14;
        comment = this.capturedPreEvaluationComment
        break;
      }
      case "Evaluation": {
        if( this.selectedStatus.id === 6)
        {
          status = 6;
        }
        else{
          status = 15;
        }       
        declaration = true;
        comment = this.capturedEvaluationComment
        selectedStatus = this.selectedStatus.id
         break;
      }
      case "Adjudication": {
        if( this.adjSelectedStatus.id === 6)
        {
          status = 6;
        }
        else{
          status = 18;
        }  
        declaration = true;
        comment = this.capturedAdjudicationComment
        selectedStatus = this.adjSelectedStatus.id
        break;
      }
      case "Approval": {
        if( this.selectedStatus.id === 6)
        {
          status = 6;
        }
        else{
          status = 13;
        }  
        declaration = true;
        comment = this.capturedApprovalComment
        selectedStatus = this.aprSelectedStatus.id
        break;
      }
    }
    
    let capturedResponse = {
      fundingApplicationId: this.application.id,     
      statusId: status,
      questionCategoryId: id[0].id,
      comments: comment,
      isActive: true,
      isSignedOff: this.isChecked ? true : false,
      isDeclarationAccepted: true,
      selectedStatus: selectedStatus
    } as ICapturedResponse;
   
    this._evaluationService.createCapturedResponse(capturedResponse).subscribe(
      (results) => {
        this._spinner.hide();
        this._router.navigateByUrl('applications');
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private createCapturedResponseNonCompliance() {
        let id = this.QuestionCategoryentities.filter(x=> x.name === 'Evaluation');
        let capturedResponse = {
          fundingApplicationId: this.application.id,     
          statusId: 22,
          questionCategoryId: id[0].id,  
          comments: 'Non Compliance',
          isActive: true,
          isSignedOff: this.isChecked ? true : false,
          isDeclarationAccepted: true,
          selectedStatus: 22 // No Compliance
        } as ICapturedResponse;
       
        this._evaluationService.createCapturedResponse(capturedResponse).subscribe(
          (results) => {
            this._spinner.hide();
            this._router.navigateByUrl('applications');
          },
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
          }
        );
      }

  private canContinue(questionnaire: IQuestionResponseViewModel[]) {
    let canUpdateStatus = [];
    if (this.hasComment(questionnaire)) {
      questionnaire.forEach(item => {
        if (!item.responseOptionId)
          canUpdateStatus.push(false); 

        if (item.commentRequired)
          if (!item.comment)
            canUpdateStatus.push(false);
      });
    }

    if (questionnaire[0].questionCategoryId === QuestionCategoryEnum.Evaluation) {
      if (!this.selectedStatus)
        canUpdateStatus.push(false);
    }

    if (questionnaire[0].questionCategoryId === QuestionCategoryEnum.Adjudication) {
      if (!this.adjSelectedStatus)
        canUpdateStatus.push(false);
    }

    if (questionnaire[0].questionCategoryId === QuestionCategoryEnum.Approval) {
      if (!this.aprSelectedStatus)
        canUpdateStatus.push(false);
    }

    if (canUpdateStatus.includes(false))
      this._messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Please ensure all fields are captured.' });

    return canUpdateStatus.includes(false) ? false : true;
  }

  private loadQuestionnaire() {
    this._evaluationService.getQuestionnaire(Number(this.id)).subscribe(
      (results) => {
        this.allQuestionnaires = results;
        
        this.preEvaluationQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "PreEvaluation");
        console.log('preEvaluationQuestionnaire', this.preEvaluationQuestionnaire);
        this.evaluationQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Evaluation");
        this.adjudicationQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Adjudication");
        this.approveQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Approval");
        this.loadResponseOptions();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadResponseOptions() {
    this._dropdownService.getEntities(DropdownTypeEnum.ResponseOption, true).subscribe(
      (results) => {
        this.responseOptions = results;
        this.loadStatuses();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadStatuses() {
    this._dropdownService.getEntities(DropdownTypeEnum.Statuses, true).subscribe(
      (results) => {
        this.statuses = results;
        this.evaluationStatuses = results.filter(x => x.name.includes('Recommended') || x.name.includes('NonCompliance') || x.name.includes('StronglyRecommended') || x.name.includes('Declined'));
        this.adjudicationStatuses = results.filter(x => x.name.includes('Declined') || x.name.includes('NonCompliance') || x.name.includes('Recommended') || x.name.includes('StronglyRecommended'));
        this.approvalStatuses = results.filter(x => x.name.includes('Declined') || x.name.includes('Recommended') || x.name.includes('StronglyRecommended'));
        this.loadCapturedResponses();
        this.isDataAvailable = true;
        this._spinner.hide();
        
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  private getCapturedResponse(questionCategoryId: QuestionCategoryEnum) {
    return this.capturedResponses.find(x => x.fundingApplicationId === this.application.id && x.questionCategoryId === questionCategoryId);
  }

  public capturePreEvaluation() {
    switch (this.application.statusId) {
        case StatusEnum.PendingReview:
        case StatusEnum.Verified:
        case StatusEnum.Evaluated:
        case StatusEnum.Adjudicated: 
        case StatusEnum.Approved:
        case StatusEnum.Declined: 
        case StatusEnum.NonCompliance: 
     {
        return true;
      }
    }

    return false;
  }


  public captureEvaluation() {
    switch (this.application.statusId) {
        case StatusEnum.Verified:
        case StatusEnum.Evaluated:
        case StatusEnum.Adjudicated: 
        case StatusEnum.Approved:
        case StatusEnum.Declined: 
        case StatusEnum.NonCompliance: 
      {
        return true;
      }
    }

    return false;
  }

  public captureAdjudicate() {
    switch (this.application.statusId) {
        case StatusEnum.Evaluated:
        case StatusEnum.Adjudicated: 
        case StatusEnum.Approved:
        case StatusEnum.Declined: 
        case StatusEnum.NonCompliance: 
      {
        return true;
      }
    }

    return false;
  }

  public captureApprove() {
    switch (this.application.statusId) {
      case StatusEnum.Adjudicated:
      case StatusEnum.Approved:
      case StatusEnum.Declined:
      {
        return true;
      }
    }

    return false;
  }


  public displayPreEvaluate() {
    switch (this.application.statusId) {
      case StatusEnum.PendingReview:
      case StatusEnum.Verified:
      case StatusEnum.Evaluated:
      case StatusEnum.Adjudicated:
      case StatusEnum.Approved: 
      case StatusEnum.Declined: 
      case StatusEnum.NonCompliance: 
      {
        return true;
      }
    }

    return false;
  }

  public displayEvaluation() {
    switch (this.application.statusId) {
      case StatusEnum.Verified:
        case StatusEnum.Evaluated:
        case StatusEnum.Adjudicated:
        case StatusEnum.Approved:
        case StatusEnum.Declined:
        case StatusEnum.NonCompliance:
      {
        return true;
      }
    }

    return false;
  }

  public displayAdjudicate() {
    switch (this.application.statusId) {
      case StatusEnum.Evaluated:
      case StatusEnum.Adjudicated:
      case StatusEnum.Approved:
      case StatusEnum.Declined:
      case StatusEnum.NonCompliance:
      {
        return true;
      }
    }

    return false;
  }

  public displayApprove() {
    if(this.application.step === 2)
    {
      switch (this.application.statusId) {
        case StatusEnum.Adjudicated:
        case StatusEnum.Approved:
        case StatusEnum.Declined:
        {
          return true;
        }
      }
      return false;
    }
   
  }
  

  public getCompletedQuestionnaire(capturedResponse: ICapturedResponse) {
    var questionnaires = this.capturedResponses.find(x => x.id === capturedResponse.id).questionnaires;
    this.updateRowGroupMetaData(questionnaires);
    return questionnaires;
  }

  public captureAdjudication() {
    switch (this.application.statusId) {
      case StatusEnum.Evaluated:
      case StatusEnum.AdjudicationInProgress: {
        return true;
      }
    }

    return false;
  }

  public captureApproval() {
    switch (this.application.statusId) {
      case StatusEnum.Adjudicated:{
        return true;
      }
    }

    return false;
  }

  private loadCapturedResponses() {
    this._evaluationService.getCapturedResponses(this.application.id).subscribe(
      (results) => {
        this.capturedResponses = results;

        let preAdId = this.QuestionCategoryentities.filter(x=> x.name === "PreEvaluation");
        let evalId = this.QuestionCategoryentities.filter(x=> x.name === "Evaluation");
        let adjId = this.QuestionCategoryentities.filter(x=> x.name === "Adjudication");
        let appId = this.QuestionCategoryentities.filter(x=> x.name === "Approval");

        this.PreEvaluatedCapturedResponses = this.capturedResponses.filter(x => x.questionCategoryId === preAdId[0].id);
        this.EvaluatedCapturedResponses = this.capturedResponses.filter(x => x.questionCategoryId === evalId[0].id);
        this.AdjudicationCapturedResponses = this.capturedResponses.filter(x => x.questionCategoryId === adjId[0].id);
        this.ApprovalCapturedResponses = this.capturedResponses.filter(x => x.questionCategoryId === appId[0].id);

        this.hasCapturedPreEvaluation = this.getCapturedResponse(preAdId[0].id) ? true : false;
        this.hasCapturedEvaluation = this.getCapturedResponse(evalId[0].id) ? true : false;
        this.hasCapturedAdjudication = this.getCapturedResponse(adjId[0].id) ? true : false;
        this.hasCapturedApproval = this.getCapturedResponse(appId[0].id) ? true : false;

        if(this.capturePreEvaluation)
          this.capturedResponse = this.getCapturedResponse(preAdId[0].id);

        if (this.captureEvaluation() && this.hasCapturedEvaluation)
          this.capturedResponse = this.getCapturedResponse(evalId[0].id);

        if (this.captureAdjudication() && this.hasCapturedAdjudication)
          this.capturedResponse = this.getCapturedResponse(adjId[0].id);

        if (this.captureApproval() && this.hasCapturedApproval)
        this.capturedResponse = this.getCapturedResponse(appId[0].id);

        if (this.capturedResponse && this.capturedResponse.statusId)
          this.selectedStatus = this.statuses.find(x => x.id === this.capturedResponse.statusId);

          if(this.PreEvaluatedCapturedResponses.length > 0)
          {
            this.isPreEvaluationDisable = true
            this.capturedPreEvaluationComment = this.PreEvaluatedCapturedResponses[0].comments;
            this.isChecked = this.PreEvaluatedCapturedResponses[0].isSignedOff;
            this.signedByUser = this.PreEvaluatedCapturedResponses[0].createdUser.fullName;
            this.verificationDate = this.PreEvaluatedCapturedResponses[0].createdDateTime;
          }
  
          if(this.EvaluatedCapturedResponses.length > 0)
          {
            this.isEvaluationDisable = true;
            this.capturedEvaluationComment = this.EvaluatedCapturedResponses[0].comments;
            this.isEvalDeclarationChecked = this.EvaluatedCapturedResponses[0].isDeclarationAccepted;
 
            let num  = this.EvaluatedCapturedResponses[0].selectedStatus;
            switch (num) {
              case Number(StatusEnum.NonCompliance):
                this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.NonCompliance); 
                this.totalAverageScore = -1;
                this.updateEvaluationStatus(this.totalAverageScore);
                break;
              case Number(StatusEnum.Declined):
                this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.Declined);
                break;
              case Number(StatusEnum.Recommended):
                this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.Recommended);
                break;
              case Number(StatusEnum.StronglyRecommended):
                this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.StronglyRecommended);
                break;
            }
  
            this.evalSignedByUser = this.EvaluatedCapturedResponses[0].createdUser.fullName;
            this.evalVerificationDate = this.EvaluatedCapturedResponses[0].createdDateTime;
          }
          else{
            var pnlEvaluation = document.getElementById("pnlEvaluation");
            var pnlEvaluation1 = document.getElementById("pnlEvaluation1");
            pnlEvaluation.style.display = "none";
            pnlEvaluation1.style.display = "none";
          }
  
          if(this.AdjudicationCapturedResponses.length > 0)
          {
           
            this.isAdjudicationDisable = true;
            this.capturedAdjudicationComment = this.AdjudicationCapturedResponses[0].comments;
            this.isAdjDeclarationChecked = this.AdjudicationCapturedResponses[0].isDeclarationAccepted;          
            let num  = this.AdjudicationCapturedResponses[0].selectedStatus;
            switch (num) {
              case Number(StatusEnum.NonCompliance):
                this.adjSelectedStatus = this.adjudicationStatuses.find(x => x.id === StatusEnum.NonCompliance); 
                break;
              case Number(StatusEnum.Declined):
                this.adjSelectedStatus = this.adjudicationStatuses.find(x => x.id === StatusEnum.Declined);
                break;
              case Number(StatusEnum.Recommended):
                this.adjSelectedStatus = this.adjudicationStatuses.find(x => x.id === StatusEnum.Recommended);
                break;
              case Number(StatusEnum.StronglyRecommended):
                this.adjSelectedStatus = this.adjudicationStatuses.find(x => x.id === StatusEnum.StronglyRecommended);
                break;
            }
           
            this.adjSignedByUser = this.AdjudicationCapturedResponses[0].createdUser.fullName;
            this.adjVerificationDate = this.AdjudicationCapturedResponses[0].createdDateTime;
            
            if (this.isAdjDeclarationChecked) {
              var pnlAdjudication = document.getElementById("pnlAdjudication");
              pnlAdjudication.style.display = "block";
            }
            else{
              pnlAdjudication.style.display = "none";
            }
          }
          else{
              var pnlAdjudication = document.getElementById("pnlAdjudication");
              pnlAdjudication.style.display = "none";
          }

          if(this.ApprovalCapturedResponses.length > 0)
          {
            this.isApprovalDisable = true;
            this.capturedApprovalComment = this.ApprovalCapturedResponses[0].comments;
            this.isAprDeclarationChecked = this.ApprovalCapturedResponses[0].isDeclarationAccepted;
            let num  = this.ApprovalCapturedResponses[0].selectedStatus;
            switch (num) {
              case Number(StatusEnum.Declined):
                this.aprSelectedStatus = this.approvalStatuses.find(x => x.id === StatusEnum.Declined);
                break;
              case Number(StatusEnum.Recommended):
                this.aprSelectedStatus = this.approvalStatuses.find(x => x.id === StatusEnum.Recommended);
                break;
              case Number(StatusEnum.StronglyRecommended):
                this.aprSelectedStatus = this.approvalStatuses.find(x => x.id === StatusEnum.StronglyRecommended);
                break;
            }
            this.aprSignedByUser = this.ApprovalCapturedResponses[0].createdUser.fullName;
            this.aprVerificationDate = this.ApprovalCapturedResponses[0].createdDateTime;
  
            if (this.isAprDeclarationChecked) {
              var pnlApproval = document.getElementById("pnlApproval");
              pnlApproval.style.display = "block";
            }
            else{
              pnlApproval.style.display = "none";
            }
          }
          else{
            var pnlApproval = document.getElementById("pnlApproval");
            pnlApproval.style.display = "none";
          }

        this.capturedResponses.forEach(capturedResponse => {
          this._evaluationService.getCompletedQuestionnaires(capturedResponse.fundingApplicationId, capturedResponse.questionCategoryId, capturedResponse.createdUser.id).subscribe(
            (results) => {
              capturedResponse.questionnaires = results;

             
              this.updateRowGroupMetaData(capturedResponse.questionnaires);

              // Check if capturedResponse is last object in capturedResponses array
              if (this.capturedResponses.indexOf(capturedResponse) === this.capturedResponses.length - 1)
                this.allCapturedResponses = this.capturedResponses;
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        });

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public disableElement(questionnaire: IQuestionResponseViewModel[], questionCategory: string) {
    let canCaptureQuestionnaire = false;
    switch (questionCategory) {
      case 'PreEvaluation':
        canCaptureQuestionnaire = this.capturePreEvaluation();
        break;
      case 'Evaluation':
        canCaptureQuestionnaire = this.captureEvaluation();
        break;
      case 'Adjudication':
        canCaptureQuestionnaire = this.captureAdjudication();
        break; 
      case 'Approval':
        canCaptureQuestionnaire = this.captureApproval();
        break;    
    }
    if (questionnaire) {

      if (this.displayErrorMessages(questionnaire))
        return true;

      let questions = questionnaire;
      let countReviewed = questions.filter(x => x.isSaved === true).length;
      let commentRequired = questions.filter(x => x.commentRequired === true).length;
      let commentProvided = questions.filter(x => x.comment !== '').length;
     
      return ((questions.length === countReviewed) && (commentProvided >= commentRequired) && ( this._recommendation == true)) ? false : true;      
    }
    else
      return true;
  }

  public disableEvaluateElement(questionnaire: IQuestionResponseViewModel[]) {
    let canCaptureQuestionnaire = false;
    canCaptureQuestionnaire = this.captureEvaluation();
    let questions = questionnaire;
    let countReviewed = questions.filter(x => x.isSaved === true).length;
    let commentRequired = questions.filter(x => x.commentRequired === true).length;
    let commentProvided = questions.filter(x => x.comment !== '').length;
    return ((questions.length === countReviewed) && (commentRequired === commentProvided)) ? false : true;  
  }


  public getStatusText(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {
    let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    let countReviewed = questions.filter(x => x.isSaved === true).length;
    return `${countReviewed} of ${questions.length} answered`;
  }

  public getRagColour(question: IQuestionResponseViewModel) {
    let ragColour = 'rag-not-saved';

    if (question.isSaved && question.commentRequired === false)
      ragColour = 'rag-saved';

    if (question.isSaved && question.commentRequired === true) {
      if (question.comment === '')
      {
        ragColour = 'rag-partial';
        this._recommendation = false;
      }
      else
      {
        ragColour = 'rag-saved';       
      }
    }
    // else if (!question.isSaved)
    //   ragColour = 'rag-not-saved';

    return ragColour;
  }

 



  public displayField(question: IQuestionResponseViewModel) {
    let canDisplayField: boolean;
    switch (question.responseTypeId) {
      case ResponseTypeEnum.CloseEnded:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.Score:
        canDisplayField = true; //question.weighting !== 0 ? true : false;
        break;
      case ResponseTypeEnum.CloseEnded2:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.CloseEnded3:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.CloseEnded4:
        canDisplayField = true;
        break;
    }

    return canDisplayField;
  }

  public getResponseOptions(responseTypeId: number) {
    return this.responseOptions.filter(x => x.responseTypeId === responseTypeId && x.isActive);
  }

  public updateRowGroupMetaData(questionnaire: IQuestionResponseViewModel[]) {
    let rowGroupMetadata = {};
    if (questionnaire) {
      for (let i = 0; i < questionnaire.length; i++) {
        let rowData = questionnaire[i];
        let questionSectionName = rowData.questionSectionName;
        if (i == 0) {
          rowGroupMetadata[questionSectionName] = { index: 0, size: 1 };
        }
        else {
          let previousRowData = questionnaire[i - 1];
          let previousRowGroup = previousRowData.questionSectionName;
          if (questionSectionName === previousRowGroup)
            rowGroupMetadata[questionSectionName].size++;
          else
            rowGroupMetadata[questionSectionName] = { index: i, size: 1 };
        }
      }
    }

    return rowGroupMetadata;
  }

  


  public displayErrorMessages(questionnaire: IQuestionResponseViewModel[]) {
    let hasErrors: boolean[] = [];

    if (this.getWeightingTotal(questionnaire) > 100)
      hasErrors.push(true);

    if (this.hasZeroWeighting(questionnaire))
      hasErrors.push(true);

    return hasErrors.includes(true) ? true : false;
  }

  public getWeightingTotal(questionnaire: IQuestionResponseViewModel[]) {
    let totalWeighting = 0;

    questionnaire.forEach(item => {
      totalWeighting += item.weighting;
    });

    if (totalWeighting > 100)
      this.weightExceedingMessage.push({ severity: 'warn', summary: "Warning:", detail: "Total weight exceeding 100. Please contact DEDAT administrator team to rectify the weightings." });

    return totalWeighting;
  }

  public hasZeroWeighting(questionnaire: IQuestionResponseViewModel[]) {
    let zeroWeightingQuestions: boolean[] = [];

    questionnaire.forEach(question => {
      switch (question.responseTypeId) {
        case ResponseTypeEnum.Score:
          question.weighting === 0 ? zeroWeightingQuestions.push(true) : zeroWeightingQuestions.push(false);
          break;
      }
    });

    if (zeroWeightingQuestions.includes(true))
      this.zeroWeightingMessage.push({ severity: 'warn', summary: "Warning:", detail: "Weight cannot be 0. Please contact administrator team to rectify the weightings." });

    return zeroWeightingQuestions.includes(true) ? true : false;
  }

  public hasWeighting(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return item.responseTypeId === ResponseTypeEnum.Score });
  }

  public onSaveResponse(event, question: IQuestionResponseViewModel) {
    question.responseOptionId = event.value.id;
    this.onSave(question);
    if(question.questionCategoryName === 'Evaluation' && question.responseOption.name === 'Yes')
    {

    }
    //if question is yes
    //find question to update in list of questions
    //update the response for found question
  }

  public onSaveComment(event, question: IQuestionResponseViewModel) {
    question.isSaved = false;
    this.onSave(question);
  }

  public getAverageScoreTotal(questionnaire: IQuestionResponseViewModel[]) 
  {
    questionnaire.forEach(item => {
      if(Number(item.responseOption.name) >= 0)
      {
        this.totalAverageScore += Number(item.responseOption.name);
      }
      else{
        this.totalAverageScore = 0;
      }
    });

    if (questionnaire[0].questionCategoryId === QuestionCategoryEnum.Evaluation)
    this.updateEvaluationStatus(this.totalAverageScore);

    return this.totalAverageScore;
  }

  private updateEvaluationStatus(totalAverageScore: number) {

      if(totalAverageScore >= 40)
      {
        this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.StronglyRecommended);
      }
      else if(totalAverageScore >= 30 && totalAverageScore <= 39)
      {
        this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.Recommended);
      }
      else if(totalAverageScore >= 1 && totalAverageScore <= 29)
      {
        this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.Declined);
      }
      else{
        this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.NonCompliance);
      }   
  }
  
  public onInputCommentChange(question: IQuestionResponseViewModel) {
    question.isSaved = false;
  }

  public onSave(question: IQuestionResponseViewModel) {
    if (question.responseOptionId != 0) {
    
      let response = {} as IResponse;
      response.fundingApplicationId = this.application.id;
      response.questionId = question.questionId;
      response.responseOptionId = question.responseOptionId;
      response.comment = question.comment == null ? "" : question.comment;

      this._evaluationService.updateResponse(response).subscribe(
        (results) => {
          let returnValue = results as IQuestionResponseViewModel;
          question.responseId = returnValue.responseId;
          question.isSaved = returnValue.isSaved;
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }

      );

      if(question.questionCategoryName === 'Evaluation' && question.responseOption.name === 'No')
      {
        let text = "Application noncompliant?";
        if (confirm(text) == true)
        {
          this.totalAverageScore = -1;
          this.updateEvaluationStatus(this.totalAverageScore);
          this.createCapturedResponseNonCompliance();
        } 
        else
        {
          return false;
        }         
      }
     
    }
  }

  public onSelectViewHistory(question: IQuestionResponseViewModel) {
    this._spinner.show();
    this.responseHistory = [];

    this._evaluationService.getResponseHistory(this.application.id, question.questionId).subscribe(
      (results) => {
        this.responseHistory = results;
        this.displayHistoryDialog = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public onCapturedResponseViewHistory(question: IQuestionResponseViewModel) {
    this._spinner.show();
    this.responseHistory = [];

    this._evaluationService.getCapturedResponseHistory(this.application.id, question.questionId, question.createdUserId).subscribe(
      (results) => {
        this.responseHistory = results;
        this.displayHistoryDialog = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  public getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];
    }

    if (col.field == 'createdDateTime')
      value = this._datepipe.transform(value, 'yyyy-MM-dd HH:mm:ss');

    return value;
  }

  public getStatus(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {
    let status = '';
    let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    let countReviewed = questions.filter(x => x.isSaved === true).length;

    // If true, document is required but no documents were uploaded... 
    // var documentRequired = questions.some(function (question) { return question.documentRequired === true && question.documentCount === 0 });
    var documentRequired = false;

    if (questions.length === countReviewed && !documentRequired)
      status = 'complete';
    else if (questions.length === countReviewed && documentRequired)
      status = 'partially-complete';
    else if (questions.length !== countReviewed)
      status = 'pending';

    return status;
  }

  editObjective(data: IObjective) {
    this.objective = this.cloneObjective(data);
    this.displayObjectiveDialog = true;
  }

  private cloneObjective(data: IObjective): IObjective {
    let obj = {} as IObjective;

    for (let prop in data)
      obj[prop] = data[prop];

    const programmeIds = data.objectiveProgrammes.map(({ programmeId }) => programmeId);
    this.selectedProgrammes = this.programmes.filter(item => programmeIds.includes(item.id));
    this.programmeChange(this.selectedProgrammes);

    const subProgrammeIds = data.objectiveProgrammes.map(({ subProgrammeId }) => subProgrammeId);
    this.selectedSubProgrammes = this.subProgrammes.filter(item => subProgrammeIds.includes(item.id));

    this.getTextValues(ServiceProvisionStepsEnum.Objectives);

    return obj;
  }

  private getTextValues(serviceProvisionStepId: ServiceProvisionStepsEnum) {
    if (serviceProvisionStepId === ServiceProvisionStepsEnum.Objectives) {
      let allProgrammes: string = "";

      this.selectedProgrammes.forEach(item => {
        allProgrammes += item.name + ";\n";
      });

      this.selectedProgrammesText = allProgrammes;
    }

    if (serviceProvisionStepId === ServiceProvisionStepsEnum.Activities) {
      let allFacilities: string = "";

      this.selectedFacilities.forEach(item => {
        allFacilities += item.name + ";\n";
      });

      this.selectedFacilitiesText = allFacilities;
    }

    let allSubProgrammes: string = "";

    this.selectedSubProgrammes.forEach(item => {
      allSubProgrammes += item.name + ";\n";
    });

    this.selectedSubProgrammesText = allSubProgrammes;
  }

  programmeChange(programmes: IProgramme[]) {
    this.subProgrammes = [];

    programmes.forEach(item => {
      if (item.id != null) {
        for (var i = 0; i < this.allSubProgrammes.length; i++) {
          if (this.allSubProgrammes[i].programmeId == item.id) {
            this.subProgrammes.push(this.allSubProgrammes[i]);
          }
        }
      }
    });
  }

  viewComments(data: any, serviceProvisionStepId: ServiceProvisionStepsEnum) {
    this.filteredApplicationComments = [];
    this.filteredApplicationComments = this.allApplicationComments.filter(x => x.serviceProvisionStepId === serviceProvisionStepId && x.entityId === data.id);
    this.displayAllCommentDialog = true;
  }

  editActivity(data: IActivity) {
    this.activity = this.cloneActivity(data);
    this.displayActivityDialog = true;
  }

  private cloneActivity(data: IActivity): IActivity {
    data.name = data.activityList.name;
    data.description = data.activityList.description;

    let activity = {} as IActivity;

    for (let prop in data)
      activity[prop] = data[prop];

    this.selectedObjective = this.objectives.find(x => x.id === data.objectiveId);
    this.objectiveChange(this.selectedObjective);

    const facilityListIds = data.activityFacilityLists.map(({ facilityListId }) => facilityListId);
    this.selectedFacilities = this.allAssignedFacilities.filter(item => facilityListIds.includes(item.id));

    const subProgrammeIds = data.activitySubProgrammes.map(({ subProgrammeId }) => subProgrammeId);
    this.selectedSubProgrammes = this.subProgrammes.filter(item => subProgrammeIds.includes(item.id));

    this.getTextValues(ServiceProvisionStepsEnum.Activities);

    return activity;
  }

  objectiveChange(objective: IObjective) {
    this.subProgrammes = [];

    const subProgrammeIds = objective.objectiveProgrammes.map(({ subProgrammeId }) => subProgrammeId);
    this.subProgrammes = this.allSubProgrammes.filter(item => subProgrammeIds.includes(item.id));
  }

  editSustainabilityPlan(data: ISustainabilityPlan) {
    this.sustainabilityPlan = this.cloneSustainabilityPlan(data);
    this.displaySustainabilityPlanDialog = true;
  }

  private cloneSustainabilityPlan(data: ISustainabilityPlan): ISustainabilityPlan {
    let plan = {} as ISustainabilityPlan;

    for (let prop in data)
      plan[prop] = data[prop];

    this.selectedActivity = this.activities.find(x => x.id === data.activityId);

    return plan;
  }

  editResource(data: IResource) {
    this.resource = this.cloneResource(data);
    this.displayResourceDialog = true;
  }

  private cloneResource(data: IResource): IResource {
    data.name = data.resourceList.name;
    data.description = data.resourceList.description;

    let resource = {} as IResource;

    for (let prop in data)
      resource[prop] = data[prop];

    this.selectedActivity = this.activities.find(x => x.id === data.activityId);

    return resource;
  }

  viewAuditHistory() {
    this.displayHistory = true;
  }

}
