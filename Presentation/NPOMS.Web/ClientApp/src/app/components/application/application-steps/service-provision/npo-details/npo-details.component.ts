import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, Message, MessageService } from 'primeng/api';
import { StatusEnum } from 'src/app/models/enums';
import { IApplication, INpo, INpoProfile } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-npo-details',
  templateUrl: './npo-details.component.html',
  styleUrls: ['./npo-details.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class NpoDetailsComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Input() newApplication: boolean;
  @Input() programId: number;
  @Input() subProgramId: number;
  @Input() subProgramTypeId: number;
  
  public get StatusEnum(): typeof StatusEnum {
    return StatusEnum;
  }

  npo: INpo;
  npoProfile: INpoProfile;

  validationErrors: Message[] = [];

  showWarningMessage: boolean;
  showConfirmationButton: boolean;
  source: string = 'NPO Details';
  constructor(
    private _messageService: MessageService,
    private _applicationRepo: ApplicationService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this.loadApplication();
    this.validationErrors.push({ severity: 'warn', summary: "Warning:", detail: "Application already captured. Please go to 'Submissions' to access this application." });
  }

  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationByNpoIdAndPeriodId(this.application).subscribe(
      (results) => {
        if (this.newApplication) {
          if (results == null)
            this.showConfirmationButton = true;
          else if (results != null && results.statusId == StatusEnum.New) {
            this.showConfirmationButton = true;
            this.showWarningMessage = false;
          }
          else
            this.showWarningMessage = true;
        }
        else {
          this.showConfirmationButton = true;
        }

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  nextPage() {
    if (this.validateNpoInformation()) {
      this.activeStep = this.activeStep + 1;
      this.activeStepChange.emit(this.activeStep);
    }
  }

  private validateNpoInformation() {
    let validationErrors = [];

    if (!this.npo.name || !this.npo.organisationTypeId) {
      validationErrors.push('Errors in General Information');
      this._messageService.add({ severity: 'error', summary: "General Information:", detail: "Missing detail required. This can be updated on the Organisations tab." });
    }

    if (this.npo.contactInformation.length === 0) {
      validationErrors.push('Errors in Contact / Stakeholder Details');
      this._messageService.add({ severity: 'error', summary: "Contact / Stakeholder Details:", detail: "The Organisation Contact List cannot be empty. This can be updated on the Organisations tab." });
    }

    if (!this.npoProfile.addressInformation.physicalAddress || !this.npoProfile.addressInformation.postalSameAsPhysical || !this.npoProfile.addressInformation.postalAddress) {
      validationErrors.push('Errors in Address Information');
      this._messageService.add({ severity: 'error', summary: "Address Information:", detail: "Missing detail required. This can be updated on the Profiles tab." });
    }

    /*if (this.npoProfile.npoProfileFacilityLists.length === 0) {
      validationErrors.push('Errors in Facility Information');
      this._messageService.add({ severity: 'error', summary: "Facility Information:", detail: "The Facility Information table cannot be empty. This can be updated on the Profiles tab." });
    }*/

    if (validationErrors.length == 0)
      return true;
    else
      return false;
  }

  updateNpo(data) {
    this.npo = data
  }

  updateNpoProfile(data) {
    this.npoProfile = data;
  }
}
