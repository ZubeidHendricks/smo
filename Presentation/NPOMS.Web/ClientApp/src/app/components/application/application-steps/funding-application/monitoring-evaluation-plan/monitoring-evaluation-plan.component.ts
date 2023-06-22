import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { StatusEnum } from 'src/app/models/enums';
import { IApplication, IFundingApplicationDetails } from 'src/app/models/interfaces';

@Component({
  selector: 'app-monitoring-evaluation-plan',
  templateUrl: './monitoring-evaluation-plan.component.html',
  styleUrls: ['./monitoring-evaluation-plan.component.css']
})
export class MonitoringEvaluationPlanComponent implements OnInit {
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Input() monEvalDescription: string;
  @Input() isReadOnly: boolean;
  @Output() monEvalDescriptionChange = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
    let amountStringId = (<HTMLInputElement>document.getElementById("monEvalDescription"));
    amountStringId.focus();

  }

  readonly(): boolean {
    if (this.application.statusId == StatusEnum.PendingReview ||
      this.application.statusId == StatusEnum.Approved)
      return true;
    else return false;
  }

  onMonEvalDescription($event) {
    this.monEvalDescriptionChange.emit($event);
  }

  nextPage() {

    this.activeStep = this.activeStep + 1;
    this.activeStepChange.emit(this.activeStep);
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }
}
