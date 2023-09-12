import { ProjectImplementationComponent } from './../application-steps/funding-application/project-implementation/project-implementation.component';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ApplicationTypeEnum, DropdownTypeEnum, EntityTypeEnum, FacilityTypeEnum, IQuestionResponseViewModel, IResponseHistory, IResponseOption, PermissionsEnum, QuestionCategoryEnum, ServiceProvisionStepsEnum, StatusEnum, ResponseTypeEnum, IResponseType, EntityEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationApproval, IApplicationAudit, IApplicationComment, IApplicationDetails, ICapturedResponse, IDepartment, IDocumentStore, IFacilityList, IMonitoringAndEvaluation, INpo, INpoProfile, IObjective, IProgramme, IProjectImplementation, IProjectInformation, IResource, IStatus, ISubProgramme, ISustainabilityPlan, IUser, IResponse, IQuestionCategory } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { EvaluationService } from 'src/app/services/evaluation/evaluation.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-workflow-application',
  templateUrl: './workflow-application.component.html',
  styleUrls: ['./workflow-application.component.css']
})
export class WorkflowApplicationComponent implements OnInit {
  

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

  weightExceedingMessage: Message[] = [];
  zeroWeightingMessage: Message[] = [];

  statuses: IStatus[];
  evaluationStatuses: IStatus[];
  adjudicationStatuses: IStatus[];
  selectedStatus: IStatus;

  hasCapturedPreEvaluation: boolean;  
  hasCapturedAdjudication: boolean;
  hasCapturedEvaluation: boolean;
  hasCapturedApproval: boolean;
  setDisable: boolean = true;

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
    private _messageService: MessageService,
    private _datepipe: DatePipe
  ) { }

  ngOnInit(): void {

    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');      
    });

    this.loadApplication();
    this.getQuestionCategory();
    this.getResponseType();
    
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewAcceptedApplication))
          this._router.navigate(['401']);
      }
    });

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
        this.getDocuments();
        this.getAuditHistory();
        this.loadApplicationApprovals();

      },
    );
  }

  
  onCheckboxChange(event: any) {
    this.isChecked = event.target.checked;
    if (this.isChecked) {
      this._recommendation = true;
    } else {
      this._recommendation = false;
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


  public displayEvaluate() {
    switch (this.application.statusId) {
      case StatusEnum.PendingReview:
      case StatusEnum.Verified:
      case StatusEnum.PendingApproval:
      case StatusEnum.EvaluationInProgress:
      case StatusEnum.AdjudicationInProgress:
     
      case StatusEnum.Adjudicated: {
        return true;
      }
    }

    return false;
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
    let capturedResponse = {
      fundingApplicationId: this.application.id,     
      statusId: 26, // questionCategoryId == QuestionCategoryEnum.PreAdjudication ? StatusEnum.PreEvaluated : this.selectedStatus.id,
      questionCategoryId: id[0].id, //questionCategoryId,
      comments: questionCategoryId == QuestionCategoryEnum.PreEvaluation ? "" : this.capturedResponse.comments,
      isActive: true,
      isSignedOff: this.isChecked ? true : false
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

    if (questionnaire[0].questionCategoryId !== QuestionCategoryEnum.PreEvaluation) {
      if (!this.selectedStatus)
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
        this.evaluationStatuses = this.statuses.filter(x => x.systemName.includes('Recommended'));
        this.adjudicationStatuses = this.statuses.filter(x => x.systemName.includes('Adjudication') && x.systemName.includes('Approved'));
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
    return this.capturedResponses.find(x => x.fundingApplicationId === this.application.id && x.questionCategoryId === questionCategoryId && x.createdUser.id === this.profile.id);
  }


  public captureEvaluation() {
    switch (this.application.statusId) {
      case StatusEnum.PendingReview:
      case StatusEnum.PendingApproval:
      case StatusEnum.Verified:
      case StatusEnum.EvaluationInProgress: 
      case StatusEnum.Approved:
      {
        return true;
      }
    }

    return false;
  }

  public displayAdjudicate() {
    switch (this.application.statusId) {
      case StatusEnum.PendingReview:
      case StatusEnum.Verified:
      case StatusEnum.Adjudicated:
      case StatusEnum.AdjudicationInProgress:
      case StatusEnum.Approved:
      {
        return true;
      }
    }

    return false;
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

  private loadCapturedResponses() {
    this._evaluationService.getCapturedResponses(this.application.id).subscribe(
      (results) => {
        this.capturedResponses = results;

        let preAdId = this.QuestionCategoryentities.filter(x=> x.name === "PreEvaluation");

        this.PreEvaluatedCapturedResponses = this.capturedResponses.filter(x => x.questionCategoryId === preAdId[0].id);
       
        if(this.PreEvaluatedCapturedResponses.length > 0)
        {
          this.capturedResponse.comments = this.PreEvaluatedCapturedResponses[0].comments;
          this.isChecked = this.PreEvaluatedCapturedResponses[0].isSignedOff;
          this.signedByUser = this.PreEvaluatedCapturedResponses[0].createdUser.fullName;
          this.verificationDate = this.PreEvaluatedCapturedResponses[0].createdDateTime;
        }

        this.hasCapturedPreEvaluation = this.getCapturedResponse(QuestionCategoryEnum.PreEvaluation) ? true : false;
        this.hasCapturedAdjudication = this.getCapturedResponse(QuestionCategoryEnum.Adjudication) ? true : false;
        this.hasCapturedEvaluation = this.getCapturedResponse(QuestionCategoryEnum.Evaluation) ? true : false;
        this.hasCapturedApproval = this.getCapturedResponse(QuestionCategoryEnum.Approval) ? true : false;

        if(this.hasCapturedPreEvaluation)
       //   this.capturedResponse = this.getCapturedResponse(QuestionCategoryEnum.PreAdjudication);

        if (this.captureEvaluation() && this.hasCapturedEvaluation)
          this.capturedResponse = this.getCapturedResponse(QuestionCategoryEnum.Evaluation);

        if (this.captureAdjudication() && this.hasCapturedAdjudication)
          this.capturedResponse = this.getCapturedResponse(QuestionCategoryEnum.Adjudication);

        if (this.capturedResponse && this.capturedResponse.statusId)
          this.selectedStatus = this.statuses.find(x => x.id === this.capturedResponse.statusId);

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

  public getStatusText(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {
    let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    let countReviewed = questions.filter(x => x.isSaved === true).length;
    return `${countReviewed} of ${questions.length} answered`;
  }

  public getRagColour(question: IQuestionResponseViewModel) {
    let ragColour = '';

    if (question.isSaved && question.documentRequired === false)
      ragColour = 'rag-saved';
    // else if (question.isSaved && question.documentRequired === true) {
    //   if (question.documentCount === 0)
    //     ragColour = 'rag-partial';
    //   else
    //     ragColour = 'rag-saved';
    // }
    else if (!question.isSaved)
      ragColour = 'rag-not-saved';

    return ragColour;
  }

  public displayField(question: IQuestionResponseViewModel) {
    let canDisplayField: boolean;
    switch (question.responseTypeId) {
      case ResponseTypeEnum.CloseEnded:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.Score:
        canDisplayField = question.weighting !== 0 ? true : false;
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

  public capturePreEvaluation() {
    switch (this.application.statusId) {
        case StatusEnum.PendingReview:
        case StatusEnum.Verified:
        case StatusEnum.EvaluationInProgress:
        case StatusEnum.Evaluated:
        case StatusEnum.AdjudicationInProgress:
        case StatusEnum.Adjudicated: 
        case StatusEnum.Approved:
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
      case StatusEnum.EvaluationInProgress:
      case StatusEnum.Evaluated:
      case StatusEnum.AdjudicationInProgress:
      case StatusEnum.Adjudicated:
      case StatusEnum.Approved: 
      {
        return true;
      }
    }

    return false;
  }

  public disableElement(questionnaire: IQuestionResponseViewModel[], questionCategory: QuestionCategoryEnum) {
    let canCaptureQuestionnaire = false;
    switch (questionCategory) {
      case QuestionCategoryEnum.PreEvaluation:
        canCaptureQuestionnaire = this.capturePreEvaluation();
        break;
      case QuestionCategoryEnum.Evaluation:
        canCaptureQuestionnaire = this.captureEvaluation();
        break;
      case QuestionCategoryEnum.Adjudication:
        canCaptureQuestionnaire = this.captureAdjudication();
        break;    
    }

    if (questionnaire) {

      if (this.displayErrorMessages(questionnaire))
        return true;

      let questions = questionnaire;
      let countReviewed = questions.filter(x => x.isSaved === true).length;
     
     // return questions.length === countReviewed && canCaptureQuestionnaire ? false : true;
     return questions.length === countReviewed ? false : true;
    }
    else
      return true;
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
      this.zeroWeightingMessage.push({ severity: 'warn', summary: "Warning:", detail: "Weight cannot be 0. Please contact DEDAT administrator team to rectify the weightings." });

    return zeroWeightingQuestions.includes(true) ? true : false;
  }

  public hasWeighting(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return item.responseTypeId === ResponseTypeEnum.Score });
  }

  public onSaveResponse(event, question: IQuestionResponseViewModel) {
    question.responseOptionId = event.value.id;
    this.onSave(question);
  }

  public onSaveComment(event, question: IQuestionResponseViewModel) {
    question.isSaved = false;
    this.onSave(question);
  }

  public getAverageScoreTotal(questionnaire: IQuestionResponseViewModel[]) {
    let totalAverageScore = 0;

    questionnaire.forEach(item => {
      item.averageScore = item.responseOptionId ? (Number(item.responseOption.name) / 5) * item.weighting : 0;
      totalAverageScore += item.averageScore;
    });

    if (questionnaire[0].questionCategoryId === QuestionCategoryEnum.Evaluation)
      this.updateEvaluationStatus(totalAverageScore);

    return totalAverageScore;
  }

  private updateEvaluationStatus(totalAverageScore: number) {
    this.selectedStatus = totalAverageScore >= 70 ? this.evaluationStatuses.find(x => x.id === StatusEnum.EvaluationRecommended) : this.evaluationStatuses.find(x => x.id === StatusEnum.EvaluationNotRecommended);
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
          // question.disableDocumentUpload = returnValue.disableDocumentUpload;
          // question.documentCount = returnValue.documentCount;
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
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

}
