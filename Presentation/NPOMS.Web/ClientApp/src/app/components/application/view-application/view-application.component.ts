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
  selector: 'app-view-application',
  templateUrl: './view-application.component.html',
  styleUrls: ['./view-application.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ViewApplicationComponent implements OnInit {

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
    private _confirmationService: ConfirmationService,
    private _documentStore: DocumentStoreService,
    private _loggerService: LoggerService
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

  }

  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        this.application = results;
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

  private loadActivities() {
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.activities = results.filter(x => x.isActive === true);
        this.getFacilityListText(results);
        this.updateRowGroupMetaData(ServiceProvisionStepsEnum.Activities);
        this.isActivitiesAvailable = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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

  private loadSustainabilityPlans() {
    this._applicationRepo.getAllSustainabilityPlans(this.application).subscribe(
      (results) => {
        this.sustainabilityPlans = results.filter(x => x.isActive === true);
        this.updateRowGroupMetaData(ServiceProvisionStepsEnum.Sustainability);
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
        this.updateRowGroupMetaData(ServiceProvisionStepsEnum.Resourcing);
        this.isResourcesAvailable = true;
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

    this.allDataLoaded();
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

  updateNpo(data) {
    this.npo = data
  }

  updateNpoProfile(data) {
    this.npoProfile = data;
  }

  updateApplicationDetail(data) {
    this.applicationDetail = data
  }

  updateProjInfo(data) {
    this.projInfoView = data
  }

  updateProjImpl(data) {
    this.projImplView = data
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

  private 
  
  updateRowGroupMetaData(serviceProvisionStepId: ServiceProvisionStepsEnum) {

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

  getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];
    }

    return value;
  }

  viewComments(data: any, serviceProvisionStepId: ServiceProvisionStepsEnum) {
    this.filteredApplicationComments = [];
    this.filteredApplicationComments = this.allApplicationComments.filter(x => x.serviceProvisionStepId === serviceProvisionStepId && x.entityId === data.id);
    this.displayAllCommentDialog = true;
  }

  viewAuditHistory() {
    this.displayHistory = true;
  }

  private getDocuments() {
    this._documentStore.get(Number(this.application.id), EntityTypeEnum.SLA).subscribe(
      (res) => {
        this.documents = res;
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

  onDownloadDocument(doc: any) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to download document?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._documentStore.download(doc).subscribe();
      },
      reject: () => {
      }
    });
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
} 
