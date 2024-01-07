import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem, MessageService } from 'primeng/api';
import { StatusEnum } from 'src/app/models/enums';
import { IApplication, IFundingApplicationDetails } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';

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
  @Input() purposeQuestion: string;
  @Output() purposeQuestionChange = new EventEmitter();
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  _menuActions: MenuItem[];

  constructor(
    private _applicationRepo: ApplicationService,
    private _bidService: BidService,
    private _router: Router,
    private _messageService: MessageService
  ) { }

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
    this.bidForm(StatusEnum.Saved);
    this.activeStepChange.emit(this.activeStep);
  }

  prevPage() {

    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  private bidForm(status: StatusEnum) {
    this.application.status = null;
      this.application.statusId = status;
      const applicationIdOnBid = this.fundingApplicationDetails;

      if (applicationIdOnBid.id == null) {
        this._bidService.addBid(this.fundingApplicationDetails).subscribe(resp => {
          this._menuActions[1].visible = false;
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
