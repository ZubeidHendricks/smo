import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { RoleEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationComment, IApplicationReviewerSatisfaction, ISustainabilityPlan } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-sustainability',
  templateUrl: './sustainability.component.html',
  styleUrls: ['./sustainability.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class SustainabilityComponent implements OnInit {

  public get RoleEnum(): typeof RoleEnum {
    return RoleEnum;
  }

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Output() sustainabilityPlanChange: EventEmitter<ISustainabilityPlan> = new EventEmitter<ISustainabilityPlan>();
  @Input() canAddComments: boolean;

  sustainabilityPlans: ISustainabilityPlan[];
  sustainabilityPlan: ISustainabilityPlan = {} as ISustainabilityPlan;
  sustainabilityPlanCols: any[];
  displaySustainabilityPlanDialog: boolean;
  newSustainabilityPlan: boolean;

  activities: IActivity[];
  selectedActivity: IActivity;
  rowGroupMetadata: any[];

  canEdit: boolean;

  displayAllCommentDialog: boolean;
  displayCommentDialog: boolean;
  comment: string;
  commentCols: any;
  applicationComments: IApplicationComment[] = [];

  tooltip: string;

  showReviewerSatisfaction: boolean;
  applicationReviewerSatisfaction: IApplicationReviewerSatisfaction[] = [];
  displayReviewerSatisfactionDialog: boolean;
  reviewerSatisfactionCols: any;

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService,
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

    this.showReviewerSatisfaction = this.application.statusId === StatusEnum.PendingReview ? true : false;
    this.tooltip = this.canEdit ? 'Edit' : 'View';

    this.loadActivities();
    this.loadSustainabilityPlans();

    this.sustainabilityPlanCols = [
      { header: 'Risk', width: '47%' },
      { header: 'Mitigation', width: '46%' }
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

  private loadActivities() {
    this._spinner.show();
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.activities = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSustainabilityPlans() {
    this._spinner.show();
    this._applicationRepo.getAllSustainabilityPlans(this.application).subscribe(
      (results) => {
        this.sustainabilityPlans = results;
        this.updateRowGroupMetaData();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  nextPage() {
    if (this.sustainabilityPlans.length > 0) {
      let canContinue: boolean[] = [];

      this.activities.forEach(item => {
        var isPresent = this.sustainabilityPlans.some(function (sustainabilityPlan) { return sustainabilityPlan.activityId === item.id });
        canContinue.push(isPresent);
      });

      if (!canContinue.includes(false)) {
        this.activeStep = this.activeStep + 1;
        this.activeStepChange.emit(this.activeStep);
      }
      else
        this._messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Please capture a sustainability plan for each activity.' });
    }
    else
      this._messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Sustainability Plan table cannot be empty.' });
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  addSustainabilityPlan() {
    this.newSustainabilityPlan = true;
    this.sustainabilityPlan = {} as ISustainabilityPlan;
    this.selectedActivity = null;
    this.displaySustainabilityPlanDialog = true;
  }

  editSustainabilityPlan(data: ISustainabilityPlan) {
    this.newSustainabilityPlan = false;
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

  deleteSustainabilityPlan(data: ISustainabilityPlan) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.sustainabilityPlan = this.cloneSustainabilityPlan(data);
        this.sustainabilityPlan.isActive = false;
        this.updateSustainabilityPlan();
      },
      reject: () => {
      }
    });
  }

  disableSaveSustainabilityPlan() {
    let data = this.sustainabilityPlan;

    if (!this.selectedActivity || !data.risk || !data.mitigation)
      return true;

    return false;
  }

  saveSustainabilityPlan() {
    this.sustainabilityPlan.activity = null;
    this.sustainabilityPlan.activityId = this.selectedActivity.id;
    this.sustainabilityPlan.isActive = true;
    this.sustainabilityPlan.changesRequired = this.sustainabilityPlan.changesRequired == null ? null : false;

    this.newSustainabilityPlan ? this.createSustainabilityPlan() : this.updateSustainabilityPlan();
    this.displaySustainabilityPlanDialog = false;
  }

  private createSustainabilityPlan() {
    this._applicationRepo.createSustainabilityPlan(this.sustainabilityPlan, this.application).subscribe(
      (resp) => {
        this.loadSustainabilityPlans();
        this.sustainabilityPlanChange.emit(this.sustainabilityPlan);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateSustainabilityPlan() {
    this._applicationRepo.updateSustainabilityPlan(this.sustainabilityPlan).subscribe(
      (resp) => {
        this.loadSustainabilityPlans();
        this.sustainabilityPlanChange.emit(this.sustainabilityPlan);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateRowGroupMetaData() {
    this.rowGroupMetadata = [];

    this.sustainabilityPlans = this.sustainabilityPlans.sort((a, b) => a.activityId - b.activityId);

    if (this.sustainabilityPlans) {

      this.sustainabilityPlans.forEach(element => {

        var itemExists = this.rowGroupMetadata.some(function (data) { return data.itemName === element.activity.activityList.description });

        this.rowGroupMetadata.push({
          itemName: element.activity.activityList.description,
          itemExists: itemExists
        });
      });
    }
  }

  addComment() {
    this.comment = null;
    this.displayCommentDialog = true;
  }

  viewComments(data: ISustainabilityPlan, origin: string) {
    this.sustainabilityPlan = data;

    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Sustainability,
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
      serviceProvisionStepId: ServiceProvisionStepsEnum.Sustainability,
      entityId: this.sustainabilityPlan.id,
      comment: this.comment
    } as IApplicationComment;

    this._applicationRepo.createApplicationComment(model, changesRequired).subscribe(
      (resp) => {
        this.loadSustainabilityPlans();

        let entity = {
          id: model.entityId
        } as ISustainabilityPlan;
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

  viewReviewerSatisfaction(data: ISustainabilityPlan) {
    this.sustainabilityPlan = data;

    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Sustainability,
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
          serviceProvisionStepId: ServiceProvisionStepsEnum.Sustainability,
          entityId: this.sustainabilityPlan.id,
          isSatisfied: isSatisfied
        } as IApplicationReviewerSatisfaction;

        this._applicationRepo.createApplicationReviewerSatisfaction(model).subscribe(
          (resp) => {
            this.loadSustainabilityPlans();

            let entity = {
              id: model.entityId
            } as ISustainabilityPlan;
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
}
