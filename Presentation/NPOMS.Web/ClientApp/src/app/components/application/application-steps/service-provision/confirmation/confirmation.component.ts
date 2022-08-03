import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { StatusEnum } from 'src/app/models/enums';
import { IApplication, IApplicationAudit, IUser } from 'src/app/models/interfaces';
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

  constructor(
    private _applicationRepo: ApplicationService,
    private _loggerService: LoggerService
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
      (err) => this._loggerService.logException(err)
    );
  }

  private buildStatusOptions() {
    this.statuses.push({ name: 'Amendments Required', value: StatusEnum.AmendmentsRequired });

    if (this.application.statusId === StatusEnum.PendingReview)
      this.statuses.push({ name: 'Accept Application (Send for Approval)', value: StatusEnum.PendingApproval });

    if (this.application.statusId === StatusEnum.PendingApproval || this.application.statusId === StatusEnum.ApprovalInProgress)
      this.statuses.push({ name: 'Approve Application', value: StatusEnum.PendingSLA });

    this.statuses.push({ name: 'Reject Application', value: StatusEnum.Rejected });
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
      (err) => this._loggerService.logException(err)
    );
  }
}
