import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DropdownTypeEnum, FacilityTypeEnum, RecipientEntityEnum, RoleEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IActivityFacilityList, IActivityList, IActivityRecipient, IActivitySubProgramme, IActivityType, IApplication, IApplicationComment, IApplicationReviewerSatisfaction, IFacilityList, IFinancialYear, IFundingApplicationDetails, INpo, IObjective, IPlace, IProjectImplementation, IRecipientType, ISDA, ISubPlace, ISubProgramme } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { Subscription } from 'rxjs';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-qc-activities',
  templateUrl: './qc-activities.component.html',
  styleUrls: ['./qc-activities.component.css']
})
export class QCActivitiesComponent implements OnInit {

  public get RoleEnum(): typeof RoleEnum {
    return RoleEnum;
  }

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Output() activityChange: EventEmitter<IActivity> = new EventEmitter<IActivity>();
  @Input() canAddComments: boolean;
  @Input() isReview: boolean;

  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Input() implementations: IProjectImplementation[];
  @Output() implementationsChange = new EventEmitter();
  

  @Input() places: IPlace[];
  @Input() allsubPlaces: ISubPlace[];
  subPlaces: ISubPlace[];
  subPlacesAll: ISubPlace[];
  selectedSubPlaces: ISubPlace[];
  selectedPlaces: IPlace[];
  selectedSdas: ISDA[];
  sdasAll: ISDA[];
  private subscriptions: Subscription[] = [];
  @Output() getPlace = new EventEmitter<IPlace[]>(); // try to send data from child to child via parent
  @Output() getSubPlace = new EventEmitter<ISubPlace[]>();
  
  yearRange: string;
  displayDialogImpl: boolean;
  newImplementation: boolean;
  implementation: IProjectImplementation = {} as IProjectImplementation;
  selectedImplementation: IProjectImplementation;
  selectedApplicationId: string;
  paramSubcriptions: Subscription;
  rangeDates: Date[];
  timeframes: Date[] = [];

  allActivities: IActivity[];
  activeActivities: IActivity[];
  deletedActivities: IActivity[];

  activityCols: any[];
  displayActivityDialog: boolean;
  newActivity: boolean;
  activity: IActivity = {} as IActivity;

  objectives: IObjective[];
  selectedObjective: IObjective;

  activityTypes: IActivityType[];
  selectedActivityType: IActivityType;

  rowGroupMetadata: any[];
  deletedRowGroupMetadata: any[];

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

  showReviewerSatisfaction: boolean;
  applicationReviewerSatisfaction: IApplicationReviewerSatisfaction[] = [];
  displayReviewerSatisfactionDialog: boolean;
  reviewerSatisfactionCols: any;

  displayDeletedActivityDialog: boolean;

  npo: INpo;
  recipientTypes: IRecipientType[];

  recipients: IActivityRecipient[];
  selectedRecipients: IActivityRecipient[] = [];
  selectedRecipientsText: string;
  selectedFinancialYear: IFinancialYear;
  financialYears: IFinancialYear[];

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
    private _loggerService: LoggerService,
    private _npoRepo: NpoService,
    private _npoProfile: NpoProfileService,
    private _bidService: BidService,
    private _router: Router,
  ) { }

  ngOnInit(): void {
    this._spinner.show();

    this.canEdit = (this.application.statusId === StatusEnum.PendingReview ||
      this.application.statusId === StatusEnum.PendingApproval ||
      this.application.statusId === StatusEnum.ApprovalInProgress ||
      this.application.statusId === StatusEnum.PendingSLA ||
      this.application.statusId === StatusEnum.PendingSignedSLA ||
      this.application.statusId === StatusEnum.DeptComments ||
      this.application.statusId === StatusEnum.OrgComments)
      ? false : true;

    this.showReviewerSatisfaction = this.application.statusId === StatusEnum.PendingReview ? true : false;
    this.tooltip = this.canEdit ? 'Edit' : 'View';

    this.loadNpo();
    this.loadActivityTypes();
    this.loadFacilities();
    this.setYearRange();
    this.loadAllSubProgrammes();
    this.loadFinancialYears();

    this.activityCols = [
      { header: 'Activity Name', width: '20%' },
      { header: 'Activity Type', width: '10%' },
      { header: 'SuccessIndicator', width: '36%' },
      { header: 'FinancialYear', width: '10%' },
      { header: 'Quarter', width: '10%' }
    ];

    this.commentCols = [
      { header: '', width: '5%' },
      { header: 'Comment', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];

    this.reviewerSatisfactionCols = [
      { header: '', width: '5%' },
      { header: 'Is Satisfied', width: '25%' },
      { header: 'Created User', width: '35%' },
      { header: 'Created Date', width: '35%' }
    ];
  }

  private loadNpo() {
    this._npoRepo.getNpoById(this.application.npoId).subscribe(
      (results) => {
        this.npo = results;
        this.loadRecipientTypes();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadActivityTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.ActivityTypes, false).subscribe(
      (results) => {
        this.activityTypes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadRecipientTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.RecipientTypes, false).subscribe(
      (results) => {
        this.recipientTypes = results.filter(x => x.isActive);
        this.loadObjectives();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadObjectives() {
    this._applicationRepo.getAllObjectives(this.application).subscribe(
      (results) => {
        this.objectives = results.filter(x => x.isActive === true);
        this.loadActivities();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadActivities() {
    this._spinner.show();
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.allActivities = results;
        this.activeActivities = this.allActivities.filter(x => x.isActive === true);
        this.getFacilityListText(results);
        this.updateRowGroupMetaData();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public GetDifference(isNew: boolean) {
    switch (isNew) {
      case undefined:
        return '';
      case true:
        return 'New';
      case false:
        return 'Changed';
    }
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
    this._applicationRepo.getAssignedFacilities(this.application).subscribe(
      (results) => {
        this.facilities = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private setYearRange() {
    let currentDate = new Date;
    let startYear = currentDate.getFullYear() - 5;
    let endYear = currentDate.getFullYear() + 5;

    this.yearRange = `${startYear}:${endYear}`;
  }

  private loadAllSubProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
      (results) => {
        this.allSubProgrammes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  nextPage() {
    if (this.activeActivities.length > 0) {
      let canContinue: boolean[] = [];

      this.objectives.forEach(item => {
        var isPresent = this.activeActivities.some(function (activity) { return activity.objectiveId === item.id });
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

    this.recipients = [];
    this.selectedRecipients = [];

    this.displayActivityDialog = true;

    if (this.application.isCloned)
      this.activity.isNew = this.activity.isNew == undefined ? true : this.activity.isNew;
  }

  editActivity(data: IActivity) {
    this.newActivity = false;
    this.activity = this.cloneActivity(data);
    this.selectedActivity = null;

    if (this.application.isCloned)
      this.activity.isNew = this.activity.isNew == undefined ? false : this.activity.isNew;

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

    this.buildRecipientDropdown(this.selectedObjective, data);
    
    this.selectedRecipients = this.recipients.filter(item => {
      return data.activityRecipients.some(recipient => {
        return recipient.activityId === item.activityId && recipient.entityId === item.entityId && recipient.recipientTypeId === item.recipientTypeId
      })
    });

    this.getTextValues();

    return activity;
  }

  getTextValues() {
    let allSubProgrammes: string = "";
    let allFacilities: string = "";
    let allRecipients: string = "";

    this.selectedSubProgrammes.forEach(item => {
      allSubProgrammes += item.name + ", ";
    });

    this.selectedFacilities.forEach(item => {
      allFacilities += item.name + ";\n";
    });

    this.selectedRecipients.forEach(item => {
      allRecipients += item.recipientName + ";\n";
    });

    this.selectedSubProgrammesText = allSubProgrammes.slice(0, -2);
    this.selectedFacilitiesText = allFacilities;
    this.selectedRecipientsText = allRecipients;
  }

  private buildRecipientDropdown(objective: IObjective, activity: IActivity) {
    this.recipients = [];

    //Primary Recipient
    this.recipients.push({
      activityId: activity.id ? activity.id : 0,
      entity: RecipientEntityEnum.Objective,
      entityId: objective.id,
      recipientTypeId: objective.recipientTypeId,
      recipientName: `${this.npo.name} (${objective.recipientType.name} Recipient)`
    } as IActivityRecipient);

    objective.subRecipients.forEach(sr => {
      sr.recipientType = this.recipientTypes.find(x => x.id === sr.recipientTypeId);

      //Sub Recipient
      this.recipients.push({
        activityId: activity.id ? activity.id : 0,
        entity: RecipientEntityEnum.SubRecipient,
        entityId: sr.id,
        recipientTypeId: sr.recipientTypeId,
        recipientName: `${sr.organisationName} (${sr.recipientType.name})`
      } as IActivityRecipient);

      sr.subSubRecipients.forEach(ssr => {
        ssr.recipientType = this.recipientTypes.find(x => x.id === ssr.recipientTypeId);

        //Sub Sub Recipient
        this.recipients.push({
          activityId: activity.id ? activity.id : 0,
          entity: RecipientEntityEnum.SubSubRecipient,
          entityId: ssr.id,
          recipientTypeId: ssr.recipientTypeId,
          recipientName: `${ssr.organisationName} (${ssr.recipientType.name})`
        } as IActivityRecipient);
      });
    });
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

    if (!this.selectedObjective || !data.name || !data.description || !data.successIndicator)
      return true;

    return false;
  }

  saveActivity() {
    this.activity.financialYear = this.selectedFinancialYear.name;
    this.activity.objective = null;
    this.activity.activityType = null;
    this.activity.changesRequired = this.activity.changesRequired == null ? null : false;
    this.activity.activityList = null;

    this.activity.objectiveId = this.selectedObjective.id;
    this.activity.activityTypeId = this.selectedActivityType == null ? 0 : this.selectedActivityType.id;
    this.activity.isActive = true;

    this.activity.timelineStartDate = this.activity.timelineStartDate == null ? '' : this._datepipe.transform(this.activity.timelineStartDate, 'yyyy-MM-dd');
    this.activity.timelineEndDate = this.activity.timelineEndDate == null ? '' :  this._datepipe.transform(this.activity.timelineEndDate, 'yyyy-MM-dd');

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

    this.activity.activityRecipients = this.selectedRecipients;

    this._dropdownRepo.createActivityList({ name: this.activity.name, description: this.activity.description, isActive: true } as IActivityList).subscribe(
      (resp) => {
        this.activity.activityListId = resp.id;
        this.newActivity ? this.createActivity() : this.updateActivity();
        this.displayActivityDialog = false;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private createActivity() {
    this._applicationRepo.createActivity(this.activity, this.application).subscribe(
      (resp) => {
        this.loadActivities();
        this.activityChange.emit(this.activity);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateActivity() {
    this._applicationRepo.updateActivity(this.activity).subscribe(
      (resp) => {
        this.loadActivities();
        this.activityChange.emit(this.activity);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateRowGroupMetaData() {
    this.rowGroupMetadata = [];

    this.activeActivities = this.activeActivities.sort((a, b) => a.objectiveId - b.objectiveId);

    if (this.activeActivities) {

      this.activeActivities.forEach(element => {

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

    this.buildRecipientDropdown(objective, this.activity);
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
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
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

    this._applicationRepo.createApplicationComment(model, changesRequired).subscribe(
      (resp) => {
        this.loadActivities();

        let entity = {
          id: model.entityId
        } as IActivity;
        this.viewComments(entity, origin);

        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Comment successfully added.' });
        this.displayCommentDialog = false;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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

  viewReviewerSatisfaction(data: IActivity) {
    this.activity = data;

    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Activities,
      entityId: data.id
    } as IApplicationReviewerSatisfaction;

    this._applicationRepo.getApplicationReviewerSatisfactions(model).subscribe(
      (results) => {
        this.applicationReviewerSatisfaction = results;
        this.displayReviewerSatisfactionDialog = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  createReviewerSatisfaction(isSatisfied: boolean) {
    this._confirmationService.confirm({
      message: 'Are you sure that you selected the correct option?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {

        let model = {
          applicationId: this.application.id,
          serviceProvisionStepId: ServiceProvisionStepsEnum.Activities,
          entityId: this.activity.id,
          isSatisfied: isSatisfied
        } as IApplicationReviewerSatisfaction;

        this._applicationRepo.createApplicationReviewerSatisfaction(model).subscribe(
          (resp) => {
            this.loadActivities();

            let entity = {
              id: model.entityId
            } as IActivity;
            this.viewReviewerSatisfaction(entity);

            this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Item successfully added.' });
            this.displayReviewerSatisfactionDialog = false;
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

  public getColspan() {
    return this.application.isCloned && this.isReview ? 7 : 6;
  }

  public viewDeletedActivities() {
    this.deletedActivities = this.allActivities.filter(x => x.isActive === false);
    this.deletedRowGroupMetadata = [];

    let activities = this.deletedActivities.sort((a, b) => a.objectiveId - b.objectiveId);

    if (activities) {

      activities.forEach(element => {

        var itemExists = this.deletedRowGroupMetadata.some(function (data) { return data.itemName === element.objective.name });

        this.deletedRowGroupMetadata.push({
          itemName: element.objective.name,
          itemExists: itemExists
        });
      });
    }

    this.displayDeletedActivityDialog = true;
  }

  public reviewAllItems() {

    this._confirmationService.confirm({
      message: 'Are you sure you are satisfied with the details contained in all the Activities?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {

        this.activeActivities.forEach(item => {
          let model = {
            applicationId: this.application.id,
            serviceProvisionStepId: ServiceProvisionStepsEnum.Activities,
            entityId: item.id,
            isSatisfied: true
          } as IApplicationReviewerSatisfaction;

          let lastObjectInArray = this.activeActivities[this.activeActivities.length - 1];

          this._applicationRepo.createApplicationReviewerSatisfaction(model).subscribe(
            (resp) => {

              if (item === lastObjectInArray) {
                this.loadActivities();
                this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Reviewer Satisfaction completed for all activities.' });
              }
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        });
      },
      reject: () => {
      }
    });
  }

  private loadFinancialYears() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        this.financialYears = results;
        //this.getFinancialYearRange(financialYear);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }


  disableSubPlacesOrPlace(): boolean {

    if (this.places && this.allsubPlaces) {
      return false;
    }
    return true;
  }

  readonly(): boolean {

    if (this.application.statusId == StatusEnum.PendingReview ||
      this.application.statusId == StatusEnum.Approved)
      return true;
    else return false;
  }

  

  onRowSelect(event) {
    this.selectedPlaces = [];
    this.selectedSubPlaces = [];
    this.newImplementation = false;
    this.implementation = this.cloneImplementation(event.data);
    this.implementation.places = this.implementation.places;
    this.implementation.subPlaces = this.implementation.subPlaces;
    this.placesChange(this.implementation.places);
    this.subPlacesChange(this.implementation.subPlaces);
    this.displayDialogImpl = true;
  }

  editProjImpl(data: IProjectImplementation) {
    this.selectedImplementation = data;
    this.selectedPlaces = [];
    this.selectedSubPlaces = [];
    this.newImplementation = false;
    this.implementation = this.cloneImplementation(data);
    this.implementation.places = this.implementation.places;
    this.implementation.subPlaces = this.implementation.subPlaces;
    this.placesChange(this.implementation.places);
    this.subPlacesChange(this.implementation.subPlaces);
    this.displayDialogImpl = true;
  }

  deleteProjImpl(data: IProjectImplementation) {

    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._npoProfile.deleteProjImpl(data.id).subscribe(
          (resp) => {
            this._bidService.getBid(data.fundingApplicationDetailId).subscribe(response => {

              this.fundingApplicationDetails.implementations = response.implementations;
            });
       // this.activeStepChange.emit(this.activeStep);
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Data deleted successfully.' });
      },
          (err) => {
            //
          }
        );
       
      },
      reject: () => {
        //
      }
    });
  }


  showDialogToAdd() {
    this.selectedPlaces = [];
    this.selectedSubPlaces = [];
    this.newImplementation = true;
    this.implementation = {
      places: [],
      subPlaces: []
    } as IProjectImplementation;
    this.displayDialogImpl = true;
  }

  disableSave(): boolean {
    if (
      !this.implementation.beneficiaries || !this.implementation.budget ||
      !this.implementation.results! || !this.implementation.projectObjective ||
      !this.implementation.resources ||
      !this.implementation.description ||
      (this.places.length > 0 && this.selectedPlaces.length == 0) ||
      (this.allsubPlaces.length > 0 && this.selectedSubPlaces.length == 0)
    )
      return true;

    return false;

  }

  save() {

    this.displayDialogImpl = false;
    this.implementation.beneficiaries = Number(this.implementation.beneficiaries).valueOf();
    this.implementation.budget = Number(this.implementation.budget).valueOf();

    this.implementation.npoProfileId = Number(this.selectedApplicationId);

    let implementation = [...this.implementations];
    if (this.newImplementation) {
      implementation.push(this.implementation);
    }
    else {
       implementation[this.implementations.indexOf(this.selectedImplementation)] = this.implementation;
    }

    this.implementations = implementation;
    this.fundingApplicationDetails.implementations.length = 0;
    this.fundingApplicationDetails.implementations = this.implementations;
    this.implementationsChange.emit(this.implementations);

    this.activeStep = this.activeStep + 1;
    this.bidForm(StatusEnum.Saved);
  }

  cloneImplementation(c: IProjectImplementation): IProjectImplementation {
    let addFun = {} as IProjectImplementation;
    for (let prop in c) {
      addFun[prop] = c[prop];
    }
    return addFun;
  }

  closeDialog() {
    this.displayDialogImpl = false;
  }

  placesChange(p: IPlace[]) {
    this.selectedPlaces = [];
    p.forEach(item => {
      this.selectedPlaces = this.selectedPlaces.concat(this.places.find(x => x.id === item.id));
    });
    this.implementation.places = this.selectedPlaces;
    this.subPlaces = [];

    if (p != null && p.length != 0) {
      for (var i = 0; i < this.subPlacesAll.length; i++) {
        if (this.selectedPlaces.filter(r => r.id === this.subPlacesAll[i].placeId).length != 0) {
          this.subPlaces.push(this.subPlacesAll[i]);

        }
      }
    }
  }

  subPlacesChange(sub: ISubPlace[]) { 
    // create dropdown with data for subPlaces
    this.selectedSubPlaces = [];
    sub.forEach(item => {
      this.selectedSubPlaces = this.selectedSubPlaces.concat(this.subPlacesAll.find(x => x.id == item.id))
    });
    this.implementation.subPlaces = this.selectedSubPlaces;
  }

  onSdaChange(sdas: ISDA[]) {
    this.places = [];
    this.subPlacesAll = [];
    this.selectedSdas = [];
    // this.sdas =[];

    this.setPlaces(sdas); // populate specific locations where the service will be delivered to
    sdas.forEach(item => {
      this.selectedSdas = this.selectedSdas.concat(this.sdasAll.find(x => x.id === item.id));
    });
    this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = this.selectedSdas;
    let count = 0;
    if (this.fundingApplicationDetails.implementations) { // when sds change make sure that fundingApplicationDetails contains correct places 
      let isPlace = [];
      this.fundingApplicationDetails.implementations.find(x => {
        x.places;
        isPlace = x.places
      });

      if (isPlace != null) {
        this.fundingApplicationDetails.implementations.forEach(x => {
          sdas.forEach(i => {
            // place already pushed to fundingApplicationDetails must be cleared out  if sda is no longer selected
            x.places.forEach(o => {
              if (o.serviceDeliveryAreaId == i.id) {
                count++;
              }
            })
          })
        })
      }

      if (this.implementation.places?.length > 0) {
        this.placesChange(this.implementation.places);
      }

    }

    if (count == 0)
      this.fundingApplicationDetails.implementations.filter(x => { x.places = []; x.subPlaces = []; });
  }

  private setPlaces(sdas: ISDA[]): void {
    if (sdas && sdas.length != 0) {     
      this._bidService.getPlaces(sdas).subscribe(res => {
        this.places = res;
        this.getPlace.emit(this.places)
        this._bidService.getSubPlaces(this.places).subscribe(res => {        
          this.subPlacesAll = res;         
          this.getSubPlace.emit(this.subPlacesAll)
        });
      });
    }
  }

  private allDropdownsLoaded() {  // use for edit purposes if implementation has places and sub places or not

    if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas?.length > 0)
     {
      this.onSdaChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas);
     }

    if (this.places?.length > 0 && this.subPlacesAll?.length > 0) {
      let plc: IPlace[];
      let subplc: ISubPlace[];
      this.fundingApplicationDetails.implementations.map(c => { plc = c.places });
      this.implementation.places = plc;
      if (this.implementation.places?.length > 0) {
        this.placesChange(this.implementation.places);
      }

      this.fundingApplicationDetails.implementations.forEach(c => { subplc = c.subPlaces; this.implementation.subPlaces = subplc; });

      if (this.implementation.subPlaces !== undefined) {
       
        this.subPlacesChange(this.implementation.subPlaces);
      }
    }
  }


  private bidForm(status: StatusEnum) {
    this.application.status = null;
    this.application.statusId = status;
    const applicationIdOnBid = this.fundingApplicationDetails;

    if (applicationIdOnBid.id == null) {
      this._bidService.addBid(this.fundingApplicationDetails).subscribe(resp => {
        //this._menuActions[1].visible = false;
        this._router.navigateByUrl(`application/edit/${this.application.id}/${this.activeStep}`);
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
        resp;
      });
    }
    else {
      this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => {
        if (resp) {
          this._router.navigateByUrl(`application/edit/${this.application.id}/${this.activeStep}`);
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
        }
      });
      
    }
    if (status == StatusEnum.PendingReview) {

      this.application.statusId = status;
      this._applicationRepo.updateApplication(this.application).subscribe();
      this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
      this._router.navigateByUrl('applications');
    };
  }
  
}
