import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { PermissionsEnum, QCStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IUser, INpo, IContactInformation, IApplicationPeriod, IApplication, IDistrictCouncil, ILocalMunicipality, IRegion, ISDA, IFundingApplicationDetails, IFundAppSDADetail, IApplicationDetails } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';
import { MenuItem, Message, MessageService } from 'primeng/api';
import { CreateQuickCaptureComponent } from '../create-quick-capture/create-quick-capture.component';
import { IAffiliatedOrganisation, ISourceOfInformation } from 'src/app/models/FinancialMatters';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';

@Component({
  selector: 'app-quick-capture-list',
  templateUrl: './quick-capture-list.component.html',
  styleUrls: ['./quick-capture-list.component.css']
})
export class QuickCaptureListComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get QCStepsEnum(): typeof QCStepsEnum {
    return QCStepsEnum;
  }

  profile: IUser;

  npo: INpo = {
    section18Receipts: false,
    contactInformation: [] as IContactInformation[]
  } as INpo;

  applicationPeriod: IApplicationPeriod;
  application: IApplication;

  districtCouncil: IDistrictCouncil;
  localMunicipality: ILocalMunicipality;
  regions: IRegion[];
  sdas: ISDA[];

  menuActions: MenuItem[];
  validationErrors: Message[];
  qcItems: MenuItem[];

  amount: number;
  sourceOfInformation: ISourceOfInformation[];
  affliatedOrganisationInfo: IAffiliatedOrganisation[];

  fundingApplicationDetails: IFundingApplicationDetails = {
    applicationDetails: {
      fundAppSDADetail: {
        districtCouncil: {} as IDistrictCouncil,
        localMunicipality: {} as ILocalMunicipality,
        regions: [],
        serviceDeliveryAreas: [],
      } as IFundAppSDADetail
    } as IApplicationDetails
  } as IFundingApplicationDetails;

  activeStep: number = 0;

  @ViewChild(CreateQuickCaptureComponent) organisationDetails: CreateQuickCaptureComponent;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _npoRepo: NpoService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    // private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _messageService: MessageService,
    private _fundAppService: FundingApplicationService
    // private _bidService: BidService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.AddApplication))
          this._router.navigate(['401']);

        this.qCSteps();
        this.buildMenu();
      }
    });
  }

  private buildMenu() {
    if (this.profile) {
      this.menuActions = [
        {
          label: 'Validate',
          icon: 'fa fa-check',
          command: () => {
            // this.formValidate();
          },
          visible: false
        },
        {
          label: 'Clear Messages',
          icon: 'fa fa-undo',
          command: () => {
            this.clearMessages();
          },
          visible: false
        },
        {
          label: 'Save',
          icon: 'fa fa-floppy-o',
          command: () => {
            this.bidForm(StatusEnum.Saved);
          }
        },
        {
          label: 'Submit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.bidForm(StatusEnum.PendingReview);
          }
        },
        {
          label: 'Go Back',
          icon: 'fa fa-step-backward',
          command: () => {
            this._router.navigateByUrl('application-periods');
          }
        }
      ];
    }
  }

  private bidForm(status: StatusEnum) {

    if (this.bidCanContinue(status)) {
      this._spinner.show();

      let data = this.npo;

      data.contactInformation.forEach(item => {
        item.titleId = item.title.id;
        item.positionId = item.position.id;
        item.genderId = item.gender ? item.gender.id : null;
        item.raceId = item.race ? item.race.id : null;
        item.languageId = item.language ? item.language.id : null;
      });

      this._npoRepo.createNpo(data).subscribe(
        (resp) => {

          this.application.statusId = status;

          this._applicationRepo.createApplication(this.application, true, null).subscribe(
            (resp) => {

              if (!this.fundingApplicationDetails.id) {
                this._fundAppService.addFundingApplicationDetails(this.fundingApplicationDetails).subscribe(
                  (resp) => {
                    this._spinner.hide();

                    if (status === StatusEnum.Saved)
                      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });

                    if (status === StatusEnum.PendingReview)
                      this._router.navigateByUrl('applications');
                  },
                  (err) => {
                    this._loggerService.logException(err);
                    this._spinner.hide();
                  }
                );
              }
              else {
                this._fundAppService.editFundingApplicationDetails(this.fundingApplicationDetails).subscribe(
                  (resp) => {
                    this._spinner.hide();

                    if (status === StatusEnum.Saved)
                      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });

                    if (status === StatusEnum.PendingReview)
                      this._router.navigateByUrl('applications');
                  },
                  (err) => {
                    this._loggerService.logException(err);
                    this._spinner.hide();
                  }
                );
              }
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }

    /*this.application.status = null;
    if (status === StatusEnum.Saved) {
      this.application.statusId = status;
    }

    if (status === StatusEnum.PendingReview) {
      this.application.statusId = status;
    }

    if (this.bidCanContinue(status)) {
      this.application.statusId = status;
      if (this.validationErrors.length == 0) {
        this._applicationRepo.updateApplication(this.application).subscribe();
      }
    }

    this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
    this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });

    if (status == StatusEnum.PendingReview) {
      this.application.status.name = "PendingReview";
      this._router.navigateByUrl('applications');
    }*/
  }

  private bidCanContinue(status: StatusEnum) {
    this.validationErrors = [];

    if (status === StatusEnum.Saved)
      var orgDetailsError = this.validateOrganisationDetails();

    if (status === StatusEnum.PendingReview) {
      var orgDetailsError = this.validateOrganisationDetails();
      var applicationError = this.validateApplications();
      var applicationDetailsError = this.validateApplicationDetails();
    }

    if (orgDetailsError.length > 0) {
      this.validationErrors.push({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });
      this.organisationDetails.setValidated(true);
    }

    if (status === StatusEnum.PendingReview) {
      if (applicationError.length > 0) {
        this.validationErrors.push({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });
      }

      if (applicationDetailsError.length > 0)
        this.validationErrors.push({ severity: 'error', summary: "Application Details:", detail: applicationDetailsError.join('; ') });
    }

    if (this.validationErrors.length > 0)
      this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Please scroll to top to view errors.' });

    this.menuActions[1].visible = this.validationErrors.length > 0 ? true : false;
    return this.validationErrors.length === 0 ? true : false;
  }

  private validateOrganisationDetails() {
    let data = this.npo;
    let orgDetailsError: string[] = [];

    if (!data.name || !data.organisationTypeId || !data.registrationStatusId)
      orgDetailsError.push("Missing detail required under General Information");

    if (data.contactInformation.length === 0)
      orgDetailsError.push("The Organisation Contact List cannot be empty under Contact / Stakeholder Details");

    if (data.contactInformation.length > 0 && data.contactInformation.filter(x => x.isPrimaryContact === true).length === 0)
      orgDetailsError.push("Please specify the primary contact under Contact / Stakeholder Details");

    return orgDetailsError;
  }

  private validateApplications() {
    let data = this.applicationPeriod;
    let applicationError: string[] = [];

    if (!data)
      applicationError.push("Please select a programme from the list provided");

    return applicationError;
  }

  private validateApplicationDetails() {
    let applicationDetailsError: string[] = [];

    if (!this.districtCouncil || !this.localMunicipality || this.regions.length === 0 || this.sdas.length === 0)
      applicationDetailsError.push("Please select a District Council, Local Municipality, Region(s) and/or Service Delivery Area(s)");

    if (!this.amount)
      applicationDetailsError.push("Please specify the Rand amount you applying for");

    return applicationDetailsError;
  }

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[1].visible = false;
    this.organisationDetails.setValidated(false);
  }

  /*private saveItems(status: StatusEnum) {
    if (this.canContinue(status)) {
      this._spinner.show();
      this.application.statusId = status;

      this._applicationRepo.updateApplication(this.application).subscribe(
        (resp) => {
          if (resp.statusId === StatusEnum.Saved) {
            this.menuActions[3].visible = true;
            this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
          }

          if (resp.statusId === StatusEnum.PendingReview) {
            this._router.navigateByUrl('applications');
          }
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }*/

  /*private canContinue(status: StatusEnum) {
    this.validationErrors = [];

    if (status === StatusEnum.PendingReview)
      this.formValidate();

    if (this.validationErrors.length == 0)
      return true;

    return false;
  }*/

  /*places(place: IPlace[]) {
    this.placeAll = place;
  }*/

  /*subPlaces(subPlaces: ISubPlace[]) {
    this.subPlacesAll = subPlaces;
  }*/

  /*getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];
    }

    return value;
  }*/

  private qCSteps() {
    this.qcItems = [
      { label: 'Organisation Details' },
      { label: 'Applications' },
      { label: 'Application Details' },
      { label: 'Application Document' }
    ];
  }

  public validateStep(goToStep: number, currentStep: number) {
    if (goToStep > currentStep) {
      switch (currentStep) {
        case QCStepsEnum.NpoCreate: {
          var orgDetailsError = this.validateOrganisationDetails();

          if (orgDetailsError.length > 0) {
            this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });
            this.organisationDetails.setValidated(true);
            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsEnum.Applications: {
          var applicationError = this.validateApplications();

          if (applicationError.length > 0) {
            this._messageService.add({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });
            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsEnum.AmountYouApplyingFor: {
          var applicationDetailsError = this.validateApplicationDetails();

          if (applicationDetailsError.length > 0) {
            this._messageService.add({ severity: 'error', summary: "Application Details:", detail: applicationDetailsError.join('; ') });
            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsEnum.ApplicationDocument: {
          this.activeStep = goToStep;
          break;
        }
      }
    }
    else
      this.activeStep = goToStep;
  }
}
