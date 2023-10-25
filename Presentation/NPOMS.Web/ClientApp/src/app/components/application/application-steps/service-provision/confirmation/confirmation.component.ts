import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationAudit, IApplicationReviewerSatisfaction, IObjective, IResource, ISustainabilityPlan, IUser } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.css']
})
export class ConfirmationComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Input() status: StatusEnum;
  @Output() statusChange: EventEmitter<StatusEnum> = new EventEmitter<StatusEnum>();
  @Input() profile: IUser;
  @Input() approvalFrom: string;
  @Output() approvalFromChange: EventEmitter<string> = new EventEmitter<string>();
  @Input() approveApplication: boolean;

  auditCols: any[];
  statuses: any[] = [];

  applicationAudits: IApplicationAudit[];
  displayHistory: boolean;

  approvalFromOptions: any[];

  reviewerSatisfaction: IApplicationReviewerSatisfaction[];
  reviewerSatisfactionObjective: IApplicationReviewerSatisfaction[];
  reviewerSatisfactionActivity: IApplicationReviewerSatisfaction[];
  reviewerSatisfactionSustainability: IApplicationReviewerSatisfaction[];
  reviewerSatisfactionResourcing: IApplicationReviewerSatisfaction[];

  objectives: IObjective[];
  activities: IActivity[];
  sustainabilityPlans: ISustainabilityPlan[];
  resources: IResource[];
  showReviewerSatisfaction: boolean;
  reviewerSatisfactionCols: any;

  constructor(
    private _applicationRepo: ApplicationService,
    private _loggerService: LoggerService,
    private _spinner: NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this.buildStatusOptions();

    this.auditCols = [
      { header: '', width: '5%' },
      { header: 'Status', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];

    this.approvalFromOptions = [
      { name: 'City of Cape Town', value: 'CoCT' },
      { name: 'Department of Health', value: 'DoH' }
    ];

    this.reviewerSatisfactionCols = [
      { header: '', width: '5%' },
      { header: 'Is Satisfied', width: '25%' },
      { header: 'Created User', width: '35%' },
      { header: 'Created Date', width: '35%' }
    ];

    this.loadApplicationApprovals();
  }

  private loadApplicationApprovals() {
    this._applicationRepo.getApplicationApprovals(this.application.id).subscribe(
      (results) => {
        if (results.length > 0) {
          this.approvalFromOptions = this.approvalFromOptions.filter(function (object1) {
            return results.some(function (object2) {
              return object1.value !== object2.approvedFrom;
            })
          });
        }
      },
      (err) => {
        this._loggerService.logException(err);
      }
    );
  }

  private buildStatusOptions() {
    this.statuses.push({ name: 'Amendments Required', value: StatusEnum.AmendmentsRequired });

    if (this.application.statusId === StatusEnum.PendingReview)
      this.statuses.push({ name: 'Accept Application (Send for Approval)', value: StatusEnum.PendingApproval });

    if (this.application.statusId === StatusEnum.PendingApproval || this.application.statusId === StatusEnum.ApprovalInProgress)
      this.statuses.push({ name: 'Approve Application', value: StatusEnum.PendingSLA });

    this.statuses.push({ name: 'Declined Application', value: StatusEnum.Declined });
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  statusEnumChange(status: any) {
    this.statusChange.emit(status.value);
  }

  approvedFromChange(item: any) {
    this.approvalFromChange.emit(item.value);
  }

  viewAuditHistory() {
    this._applicationRepo.getApplicationAudits(this.application.id).subscribe(
      (results) => {
        this.applicationAudits = results;
        this.displayHistory = true;
      },
      (err) => {
        this._loggerService.logException(err);
      }
    );
  }

  public viewReviewerSatisfaction() {
    this._spinner.show();
    this._applicationRepo.getReviewerSatisfactionByApplicationId(this.application.id).subscribe(
      (results) => {
        this.reviewerSatisfaction = results;
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
        this.objectives = results.filter(x => x.isActive);
        this.loadActivities();
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
        this.loadSustainabilityPlans();
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
        this.loadResources();
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
        this.showReviewerSatisfaction = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public onOpenObjective(e) {
    let index = e.index;
    let object = this.objectives[index];

    this.reviewerSatisfactionObjective = [];
    this.reviewerSatisfactionObjective = this.reviewerSatisfaction.filter(x => x.entityId === object.id && x.serviceProvisionStepId === ServiceProvisionStepsEnum.Objectives);
  }

  public onOpenActivity(e) {
    let index = e.index;
    let object = this.activities[index];

    this.reviewerSatisfactionActivity = [];
    this.reviewerSatisfactionActivity = this.reviewerSatisfaction.filter(x => x.entityId === object.id && x.serviceProvisionStepId === ServiceProvisionStepsEnum.Activities);
  }

  public onOpenSustainability(e) {
    let index = e.index;
    let object = this.sustainabilityPlans[index];

    this.reviewerSatisfactionSustainability = [];
    this.reviewerSatisfactionSustainability = this.reviewerSatisfaction.filter(x => x.entityId === object.id && x.serviceProvisionStepId === ServiceProvisionStepsEnum.Sustainability);
  }

  public onOpenResourcing(e) {
    let index = e.index;
    let object = this.resources[index];

    this.reviewerSatisfactionResourcing = [];
    this.reviewerSatisfactionResourcing = this.reviewerSatisfaction.filter(x => x.entityId === object.id && x.serviceProvisionStepId === ServiceProvisionStepsEnum.Resourcing);
  }
}
