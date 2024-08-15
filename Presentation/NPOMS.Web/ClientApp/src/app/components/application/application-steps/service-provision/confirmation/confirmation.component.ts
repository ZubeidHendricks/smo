import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PermissionsEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
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
  @Output() selectedReviewersChange: EventEmitter<{ fullName: string, email: string, id: number }[]> = new EventEmitter();
  //main
  @Output() selectedMainReviewersChange: EventEmitter<{ fullName: string, email: string, id: number }[]> = new EventEmitter();

  auditCols: any[];
  statuses: any[] = [];
  selectedStatus: any;

  applicationAudits: IApplicationAudit[];
  displayHistory: boolean;

  approvalFromOptions: any[];

  reviewerSatisfaction: IApplicationReviewerSatisfaction[];

  objectives: IObjective[];
  activities: IActivity[];
  sustainabilityPlans: ISustainabilityPlan[];
  resources: IResource[];
  showReviewerSatisfaction: boolean;
  reviewerSatisfactionCols: any;

  reviewerlist: IUser[];
  selectedreviewerlist: IUser[] = [];
  displayDialog: boolean;
  reviewerForm: FormGroup;

  //main
  mainReviewerlist: IUser[];
  selectedMainreviewerlist: IUser[] = [];
  displaySatisfactionDialog: boolean;
  mainReviewerForm: FormGroup;

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get StatusEnum(): typeof StatusEnum {
    return StatusEnum;
  }

  constructor(
    private _applicationRepo: ApplicationService,
    private _router: Router,
    private _loggerService: LoggerService,
    private _spinner: NgxSpinnerService,
    private _formBuilder: FormBuilder,
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
    this.reviewerForm = this._formBuilder.group({});
    this.mainReviewerForm = this._formBuilder.group({});
    this.loadApplicationApprovals();
    this.reviewers();
    this.mainReviewers();
  }

  reviewers() {
    this._applicationRepo.depReviewers(this.application.applicationPeriod.departmentId).subscribe(
     (results) => {
       this.reviewerlist = results;
     },
     (err) => {
       this._loggerService.logException(err);
       this._spinner.hide();
     }
   );
 }

 mainReviewers() {
  this._applicationRepo.workplanMainReviewers(this.application.applicationPeriod.departmentId).subscribe(
   (results) => {
     this.mainReviewerlist = results;
   },
   (err) => {
     this._loggerService.logException(err);
     this._spinner.hide();
   }
 );
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

    if (this.application.statusId === StatusEnum.PendingReview || this.application.statusId === StatusEnum.PendingReviewerSatisfaction) {
      this.statuses.push({ name: 'Pending Reviewer Satisfaction', value: StatusEnum.PendingReviewerSatisfaction });
      this.statuses.push({ name: 'Accept Application (Send for Approval)', value: StatusEnum.PendingApproval });
    }

    if (this.application.statusId === StatusEnum.PendingApproval || this.application.statusId === StatusEnum.ApprovalInProgress)
      this.statuses.push({ name: 'Approve Application', value: StatusEnum.PendingSLA });

    this.statuses.push({ name: 'Declined Application', value: StatusEnum.Declined });
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  submit() {
      const users = this.selectedreviewerlist.map(user => ({
        fullName: user.fullName,
        email: user.email,
        id: user.id
    }));
    this.selectedReviewersChange.emit(users);
    this.statusChange.emit(this.selectedStatus);
    this.displayDialog = false;
  }

  //main
  submitMainReviewers() {
    const users = this.selectedMainreviewerlist.map(user => ({
      fullName: user.fullName,
      email: user.email,
      id: user.id
  }));
  this.selectedReviewersChange.emit(users);
  this.statusChange.emit(this.selectedStatus);
  this.displaySatisfactionDialog = false;
}

disableSubmit() {
  if (this.selectedreviewerlist.length == 0)
    return true;

  return false;
}

disableMainReviewerSubmit() {

  if (this.selectedMainreviewerlist.length == 0)
    return true;

  return false;
}

//main
statusEnumChange(status: any) {
    this.selectedreviewerlist = [];
    this.selectedMainreviewerlist = [];
    this.statusChange.emit(status.value);
    // if(status.value === StatusEnum.PendingApproval) {
    //   this.selectedStatus = status.value;
    //   this.displayDialog = true;
    // }
    // else if(status.value === StatusEnum.PendingReviewerSatisfaction) {
    //   this.selectedStatus = status.value;
    //   this.displaySatisfactionDialog = true;
    // }
    // else{
    //     const users = this.selectedreviewerlist.map(user => ({
    //       fullName: user.fullName,
    //       email: user.email,
    //       id: user.id
    //   }));
    //   this.selectedReviewersChange.emit(users);
    //   this.statusChange.emit(status.value);
    // }
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

  public getReviewerSatisfactionObjective(objective: IObjective) {
    return this.reviewerSatisfaction.filter(x => x.entityId === objective.id && x.serviceProvisionStepId === ServiceProvisionStepsEnum.Objectives);
  }

  public getReviewerSatisfactionActivity(activity: IActivity) {
    return this.reviewerSatisfaction.filter(x => x.entityId === activity.id && x.serviceProvisionStepId === ServiceProvisionStepsEnum.Activities);
  }

  public getReviewerSatisfactionSustainability(plan: ISustainabilityPlan) {
    return this.reviewerSatisfaction.filter(x => x.entityId === plan.id && x.serviceProvisionStepId === ServiceProvisionStepsEnum.Sustainability);
  }

  public getReviewerSatisfactionResourcing(resource: IResource) {
    return this.reviewerSatisfaction.filter(x => x.entityId === resource.id && x.serviceProvisionStepId === ServiceProvisionStepsEnum.Resourcing);
  }
}
