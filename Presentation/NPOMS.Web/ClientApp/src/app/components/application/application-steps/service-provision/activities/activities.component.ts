import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DropdownTypeEnum, FacilityTypeEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IActivityFacilityList, IActivityList, IActivitySubProgramme, IActivityType, IApplication, IApplicationComment, IFacilityList, IFacilityType, IObjective, ISubProgramme } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-activities',
  templateUrl: './activities.component.html',
  styleUrls: ['./activities.component.css']
})
export class ActivitiesComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Output() activityChange: EventEmitter<IActivity> = new EventEmitter<IActivity>();
  @Input() canAddComments: boolean;

  activities: IActivity[];
  activityCols: any[];
  displayActivityDialog: boolean;
  newActivity: boolean;
  activity: IActivity = {} as IActivity;

  objectives: IObjective[];
  selectedObjective: IObjective;

  activityTypes: IActivityType[];
  selectedActivityType: IActivityType;

  yearRange: string;
  rowGroupMetadata: any[];

  facilities: IFacilityList[];
  selectedFacilities: IFacilityList[];
  selectedFacilitiesText: string;

  allSubProgrammes: ISubProgramme[];
  subProgrammes: ISubProgramme[] = [];
  selectedSubProgrammes: ISubProgramme[];

  canEdit: boolean;
  selectedSubProgrammesText: string;

  displayAllCommentDialog: boolean;
  displayCommentDialog: boolean;
  comment: string;
  commentCols: any;
  applicationComments: IApplicationComment[] = [];

  tooltip: string;

  activityList: IActivityList[];
  selectedActivity: IActivityList;

  maxChars = 50;

  public get FacilityTypeEnum(): typeof FacilityTypeEnum {
    return FacilityTypeEnum;
  }

  constructor(
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private _applicationRepo: ApplicationService,
    private _datepipe: DatePipe,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this.canEdit = (this.application.statusId === StatusEnum.PendingReview ||
      this.application.statusId === StatusEnum.PendingApproval ||
      this.application.statusId === StatusEnum.ApprovalInProgress ||
      this.application.statusId === StatusEnum.PendingSLA ||
      this.application.statusId === StatusEnum.PendingSignedSLA ||
      this.application.statusId === StatusEnum.DeptComments ||
      this.application.statusId === StatusEnum.OrgComments)
      ? false : true;

    this.tooltip = this.canEdit ? 'Edit' : 'View';

    this.loadActivityTypes();
    this.loadObjectives();
    this.loadActivities();
    this.loadFacilities();
    this.setYearRange();
    this.loadAllSubProgrammes();

    this.activityCols = [
      { header: 'Activity Name', width: '20%' },
      { header: 'Activity Type', width: '10%' },
      { header: 'Timeline', width: '15%' },
      { header: 'Target', width: '10%' },
      { header: 'Facilities and/or Community Places', width: '38%' }
    ];

    this.commentCols = [
      { header: '', width: '5%' },
      { header: 'Comment', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];
  }

  private loadActivityTypes() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.ActivityTypes, false).subscribe(
      (results) => {
        this.activityTypes = results;
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private loadObjectives() {
    this._spinner.show();
    this._applicationRepo.getAllObjectives(this.application).subscribe(
      (results) => {
        this.objectives = results;
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private loadActivities() {
    this._spinner.show();
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.activities = results;
        this.getFacilityListText(results);
        this.updateRowGroupMetaData();
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
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

  private loadFacilities() {
    this._spinner.show();
    this._applicationRepo.getAssignedFacilities(this.application).subscribe(
      (results) => {
        this.facilities = results;
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private setYearRange() {
    let currentDate = new Date;
    let startYear = currentDate.getFullYear() - 5;
    let endYear = currentDate.getFullYear() + 5;

    this.yearRange = `${startYear}:${endYear}`;
  }

  private loadAllSubProgrammes() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
      (results) => {
        this.allSubProgrammes = results;
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  nextPage() {
    if (this.activities.length > 0) {
      let canContinue: boolean[] = [];

      this.objectives.forEach(item => {
        var isPresent = this.activities.some(function (activity) { return activity.objectiveId === item.id });
        canContinue.push(isPresent);
      });

      if (!canContinue.includes(false)) {
        this.activeStep = this.activeStep + 1;
        this.activeStepChange.emit(this.activeStep);
      }
      else
        this._messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Please capture an activity for each objective.' });
    }
    else
      this._messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Activity table cannot be empty.' });
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  addActivity() {
    this.newActivity = true;
    this.activity = {
      activitySubProgrammes: [] as IActivitySubProgramme[],
      activityFacilityLists: [] as IActivityFacilityList[]
    } as IActivity;
    this.selectedObjective = null;
    this.selectedActivityType = null;
    this.selectedFacilities = [];
    this.subProgrammes = [];
    this.selectedSubProgrammes = [];
    this.selectedActivity = null;
    this.displayActivityDialog = true;
  }

  editActivity(data: IActivity) {
    this.newActivity = false;
    this.activity = this.cloneActivity(data);
    this.selectedActivity = null;
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
    this.selectedActivityType = data.activityType;

    const facilityListIds = data.activityFacilityLists.map(({ facilityListId }) => facilityListId);
    this.selectedFacilities = this.facilities.filter(item => facilityListIds.includes(item.id));

    const subProgrammeIds = data.activitySubProgrammes.map(({ subProgrammeId }) => subProgrammeId);
    this.selectedSubProgrammes = this.subProgrammes.filter(item => subProgrammeIds.includes(item.id));

    this.getTextValues();

    return activity;
  }

  getTextValues() {
    let allSubProgrammes: string = "";
    let allFacilities: string = "";

    this.selectedSubProgrammes.forEach(item => {
      allSubProgrammes += item.name + ", ";
    });

    this.selectedFacilities.forEach(item => {
      allFacilities += item.name + ";\n";
    });

    this.selectedSubProgrammesText = allSubProgrammes.slice(0, -2);
    this.selectedFacilitiesText = allFacilities;
  }

  deleteActivity(data: IActivity) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.activity = this.cloneActivity(data);
        this.activity.isActive = false;
        this.updateActivity();
      },
      reject: () => {
      }
    });
  }

  disableSaveActivity() {
    let data = this.activity;

    if (!this.selectedObjective || this.selectedSubProgrammes.length === 0 || !data.name || !data.description || !this.selectedActivityType || !data.timelineStartDate || !data.timelineEndDate || !data.target || this.selectedFacilities.length === 0)
      return true;

    return false;
  }

  saveActivity() {
    this.activity.objective = null;
    this.activity.activityType = null;
    this.activity.changesRequired = this.activity.changesRequired == null ? null : false;
    this.activity.activityList = null;

    this.activity.objectiveId = this.selectedObjective.id;
    this.activity.activityTypeId = this.selectedActivityType.id;
    this.activity.isActive = true;

    this.activity.timelineStartDate = this._datepipe.transform(this.activity.timelineStartDate, 'yyyy-MM-dd');
    this.activity.timelineEndDate = this._datepipe.transform(this.activity.timelineEndDate, 'yyyy-MM-dd');

    this.activity.activitySubProgrammes = [];
    this.selectedSubProgrammes.forEach(item => {
      let activitySubProgramme = {
        activityId: this.activity.id,
        subProgrammeId: item.id,
        isActive: true
      } as IActivitySubProgramme;

      this.activity.activitySubProgrammes.push(activitySubProgramme);
    });

    this.activity.activityFacilityLists = [];
    this.selectedFacilities.forEach(item => {
      let activityFacilityList = {
        activityId: this.activity.id,
        facilityListId: item.id,
        isActive: true
      } as IActivityFacilityList;

      this.activity.activityFacilityLists.push(activityFacilityList);
    });

    this._dropdownRepo.createActivityList({ name: this.activity.name, description: this.activity.description, isActive: true } as IActivityList).subscribe(resp => {
      this.activity.activityListId = resp.id;
      this.newActivity ? this.createActivity() : this.updateActivity();
      this.displayActivityDialog = false;
    });
  }

  private createActivity() {
    this._applicationRepo.createActivity(this.activity, this.application).subscribe(resp => {
      this.loadActivities();
      this.activityChange.emit(this.activity);
    });
  }

  private updateActivity() {
    this._applicationRepo.updateActivity(this.activity).subscribe(resp => {
      this.loadActivities();
      this.activityChange.emit(this.activity);
    });
  }

  private updateRowGroupMetaData() {
    this.rowGroupMetadata = [];

    this.activities = this.activities.sort((a, b) => a.objectiveId - b.objectiveId);

    if (this.activities) {

      this.activities.forEach(element => {

        var itemExists = this.rowGroupMetadata.some(function (data) { return data.itemName === element.objective.name });

        this.rowGroupMetadata.push({
          itemName: element.objective.name,
          itemExists: itemExists
        });
      });
    }
  }

  disableSubProgramme(): boolean {
    if (this.subProgrammes.length > 0)
      return false;

    return true;
  }

  objectiveChange(objective: IObjective) {
    this.subProgrammes = [];

    const subProgrammeIds = objective.objectiveProgrammes.map(({ subProgrammeId }) => subProgrammeId);
    this.subProgrammes = this.allSubProgrammes.filter(item => subProgrammeIds.includes(item.id));
  }

  addComment() {
    this.comment = null;
    this.displayCommentDialog = true;
  }

  viewComments(data: IActivity, origin: string) {
    this.activity = data;

    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Activities,
      entityId: data.id
    } as IApplicationComment;

    this._applicationRepo.getApplicationComments(model).subscribe(
      (results) => {
        this.applicationComments = results;

        if (origin === 'allComments')
          this.displayAllCommentDialog = true;
      },
      (err) => this._loggerService.logException(err)
    );
  }

  disableSaveComment() {
    if (!this.comment)
      return true;

    return false;
  }

  saveComment(changesRequired: boolean, origin: string) {
    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Activities,
      entityId: this.activity.id,
      comment: this.comment
    } as IApplicationComment;

    this._applicationRepo.createApplicationComment(model, changesRequired).subscribe(resp => {
      this.loadActivities();

      let entity = {
        id: model.entityId
      } as IActivity;
      this.viewComments(entity, origin);

      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Comment successfully added.' });
      this.displayCommentDialog = false;
    });
  }

  search(event) {
    let query = event.query;
    this._dropdownRepo.getActivityByName(query).subscribe((results) => {
      this.activityList = results;
    });
  }

  selectActivity(item: IActivityList) {
    this.activity.name = item.name;
    this.activity.description = item.description;
  }
}
