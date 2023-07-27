import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { StatusEnum } from 'src/app/models/enums';
import { IApplication, IFundingApplicationDetails } from 'src/app/models/interfaces';

@Component({
  selector: 'app-view-monitoring-evaluation',
  templateUrl: './view-monitoring-evaluation.component.html',
  styleUrls: ['./view-monitoring-evaluation.component.css']
})
export class ViewMonitoringEvaluationComponent implements OnInit {
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Input() monEvalDescription: string;
  @Input() isReadOnly: boolean;
  @Output() monEvalDescriptionChange = new EventEmitter();

  constructor(
    private _spinner: NgxSpinnerService,
  ) { }

  ngOnInit(): void {
  
    //let monEvalDescription = (<HTMLInputElement>document.getElementById("monEvalDescription"));

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
