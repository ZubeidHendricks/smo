import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Editor } from 'primeng/editor';
import { StatusEnum } from 'src/app/models/enums';
import { IFundingApplicationDetails, IApplication } from 'src/app/models/interfaces';

@Component({
  selector: 'app-view-project-information',
  templateUrl: './view-project-information.component.html',
  styleUrls: ['./view-project-information.component.css']
})
export class ViewProjectInformationComponent implements OnInit {

  @Input() isReadOnly: boolean;
  @Input() initiatedQuestion: string;
  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Input() application: IApplication;
  @Input() purposeQuestion: string;
  @Output() purposeQuestionChange = new EventEmitter();
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {
  }

  onPurposeQuestionChange($event) {
    this.purposeQuestionChange.emit($event);
  }

  readonly(): boolean {

    if (this.application.statusId == StatusEnum.PendingReview ||
      this.application.statusId == StatusEnum.Approved)
      return true;
    else return false;
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
