import { ProjectImplementationComponent } from './../application-steps/funding-application/project-implementation/project-implementation.component';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ApplicationTypeEnum, DropdownTypeEnum, EntityTypeEnum, FacilityTypeEnum, PermissionsEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationApproval, IApplicationAudit, IApplicationComment, IApplicationDetails, IDepartment, IDocumentStore, IFacilityList, IMonitoringAndEvaluation, INpo, INpoProfile, IObjective, IProgramme, IProjectImplementation, IProjectInformation, IResource, ISubProgramme, ISustainabilityPlan, IUser } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

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

  paramSubcriptions: Subscription;
  id: string;
  selectedApplication: IApplication;
  profile: IUser;
  application: IApplication;
  isApplicationAvailable: boolean;

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

  allApplicationComments: IApplicationComment[] = [];
  filteredApplicationComments: IApplicationComment[] = [];

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

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _dropdownRepo: DropdownService,
    private _applicationPeriodRepo: ApplicationPeriodService,
    private _documentStore: DocumentStoreService,
  ) { }

  ngOnInit(): void {

    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
      this.loadApplication();
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewAcceptedApplication))
          this._router.navigate(['401']);
      }
    });

  }

  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        this.application = results;
        alert(this.application.statusId);
        // this.loadAllProgrammes();
        // this.loadAllSubProgrammes();
        // this.loadFacilities();

        // this.loadObjectives();
        // this.loadActivities();
        // this.loadSustainabilityPlans();
        // this.loadResources();

        // this.loadApplicationComments();
        // this.getDocuments();
        // this.getAuditHistory();
        // this.loadApplicationApprovals();
      },
    );
  }

  // private loadQuestionnaire() {
  //   this._evaluationService.getQuestionnaire(this.fundingApplication.id).subscribe(
  //     (results) => {
  //       this.allQuestionnaires = results;
  //       this.preEvaluationQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryId === QuestionCategoryEnum.PreEvaluation);
  //       this.evaluationQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryId === QuestionCategoryEnum.Evaluation);
  //       this.adjudicationQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryId === QuestionCategoryEnum.Adjudication);

  //       this.loadResponseOptions();
  //     },
  //     (err) => {
  //       this._loggerService.logException(err);
  //       this._spinner.hide();
  //     }
  //   );
  // }

  public capturePreEvaluation() {
    switch (this.application.statusId) {
      case StatusEnum.Submitted:
      case StatusEnum.PreEvaluationInProgress: {
        return true;
      }
    }

    return false;
  }
  public displayPreEvaluate() {
    switch (this.application.statusId) {
      case StatusEnum.Submitted:
      case StatusEnum.PendingReview:
      case StatusEnum.PreEvaluationInProgress:
      case StatusEnum.PreEvaluated:
      case StatusEnum.EvaluationInProgress:
      case StatusEnum.EvaluationNotRecommended:
      case StatusEnum.EvaluationRecommended:
      case StatusEnum.Evaluated:
      case StatusEnum.AdjudicationInProgress:
      case StatusEnum.AdjudicationApproved:
      case StatusEnum.AdjudicationNotApproved:
      case StatusEnum.Adjudicated: {
        return true;
      }
    }

    return false;
  }

}
