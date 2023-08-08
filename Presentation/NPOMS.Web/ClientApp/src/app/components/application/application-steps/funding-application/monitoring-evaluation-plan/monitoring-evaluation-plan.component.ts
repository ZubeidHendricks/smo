import { NgxSpinnerService } from 'ngx-spinner';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { StatusEnum } from 'src/app/models/enums';
import { IApplication, IFundingApplicationDetails } from 'src/app/models/interfaces';
import { Router } from '@angular/router';
import { MenuItem, MessageService } from 'primeng/api';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';

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
  _menuActions: MenuItem[];

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _bidService: BidService,
    private _router: Router,
    private _messageService: MessageService
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
            this._router.navigateByUrl(`application/edit/${this.application.id}`);
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
