import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { StatusEnum } from 'src/app/models/enums';
import {  IApplication, IFundingApplicationDetails } from 'src/app/models/interfaces';

@Component({
  selector: 'app-project-information',
  templateUrl: './project-information.component.html',
  styleUrls: ['./project-information.component.css']
})
export class ProjectInformationComponent implements OnInit {
  @Input() isReadOnly: boolean;
  @Input() initiatedQuestion: string;
  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Input() application: IApplication;
  @Output() initiatedQuestionChange = new EventEmitter();
  @Input() purposeQuestion: string;
  @Output() purposeQuestionChange = new EventEmitter();
  @Input() considerQuestion: string;
  @Output() considerQuestionChange = new EventEmitter();
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {

console.log('bit status',this.fundingApplicationDetails)
  }

  onInitiatedQuestionChange($event) {
    this.initiatedQuestionChange.emit($event);
  }

  onPurposeQuestionChange($event) {
    this.purposeQuestionChange.emit($event);
  }

  onConsiderQuestionChange($event) {
    this.considerQuestionChange.emit($event);
  }

  readonly(): boolean {
   
        if (this.application.statusId ==StatusEnum.PendingReview ||  
          this.application.statusId == StatusEnum.Approved )
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
