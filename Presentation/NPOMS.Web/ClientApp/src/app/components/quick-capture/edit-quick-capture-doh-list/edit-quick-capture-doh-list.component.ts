import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PermissionsEnum, AccessStatusEnum, ApplicationTypeEnum, QCStepsEnum, FundingApplicationStepsEnum, StatusEnum, DropdownTypeEnum, QCStepsFundedEnum } from 'src/app/models/enums';
import { IUser, INpo, IApplicationPeriod, IFundingApplicationDetails, IDistrictCouncil, ILocalMunicipality, IFundAppSDADetail, IApplicationDetails, IApplication, IPlace, ISubPlace, ISDA, IRegion, IObjective, IActivity, ISustainabilityPlan, IResource, IQuickCaptureDetails, IFinancialYear, IProjectInformation } from 'src/app/models/interfaces';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { MenuItem, Message, MessageService } from 'primeng/api';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { Subscription } from 'rxjs';
import { IAffiliatedOrganisation, ISourceOfInformation } from 'src/app/models/FinancialMatters';
import { CreateQuickCaptureComponent } from '../create-quick-capture/create-quick-capture.component';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { UserService } from 'src/app/services/api-services/user/user.service';


@Component({
  selector: 'app-edit-quick-capture-doh-list',
  templateUrl: './edit-quick-capture-doh-list.component.html',
  styleUrls: ['./edit-quick-capture-doh-list.component.css']
})
export class EditQuickCaptureDohListComponent implements OnInit {

  // canEdit: boolean = false;
  // applicationIdOnBid: any;
  // subPlacesAll: ISubPlace[];
  // place: IPlace[];

  // placesAll: IPlace[] = [];
  // subPlacesAll: ISubPlace[] = [];

  // dropdownTouched: boolean = false;

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }
  // public get ApplicationTypeEnum(): typeof ApplicationTypeEnum {
  //   return ApplicationTypeEnum;
  // }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }
  
  public get QCStepsEnum(): typeof QCStepsEnum {
    return QCStepsEnum;
  }
  public get QCStepsFundedEnum(): typeof QCStepsFundedEnum {
    return QCStepsFundedEnum;
  }
  // public get FundingApplicationStepsEnum(): typeof FundingApplicationStepsEnum {
  //   return FundingApplicationStepsEnum;
  // }

  profile: IUser;

  paramSubcriptions: Subscription;
  applicationId: string;

  npo: INpo;
  applicationPeriod: IApplicationPeriod;
  application: IApplication;

  districtCouncil: IDistrictCouncil;
  localMunicipality: ILocalMunicipality;
  regions: IRegion[];
  sdas: ISDA[];
  projectInformation: IProjectInformation;
  menuActions: MenuItem[];
  validationErrors: Message[];
  qcItems: MenuItem[];

  amount: number;
  sourceOfInformation: ISourceOfInformation[];
  affliatedOrganisationInfo: IAffiliatedOrganisation[];

 // fundingApplicationDetails: IFundingApplicationDetails;

  fundingApplicationDetails: IFundingApplicationDetails = {
    applicationDetails: {
      fundAppSDADetail: {
        districtCouncil: {} as IDistrictCouncil,
        localMunicipality: {} as ILocalMunicipality,
        regions: [],
        serviceDeliveryAreas: [],
      } as IFundAppSDADetail
    } as IApplicationDetails,
    projectInformation: {} as IProjectInformation
  } as IFundingApplicationDetails;

  activeStep: number = 0;

  @ViewChild(CreateQuickCaptureComponent) organisationDetails: CreateQuickCaptureComponent;

  isDataAvailable: boolean;

  // cols: any[];
  // allNPOs: INpo[];

  // paramSubcriptions: Subscription;
  // npoId: string;
  // applicationPeriodId: number;
  // id: string;

  // menuActions: MenuItem[];
  // validationErrors: Message[];

  // applicationPeriod: IApplicationPeriod;
  // isApplicationAvailable: boolean;
  // placeAll: IPlace[] = [];

  // funding dropdowns
  // districtCouncils: IDistrictCouncil[] = [];
  // localMunicipalitiesAll: ILocalMunicipality[] = [];
  // localMunicipalities: ILocalMunicipality[] = [];
  // regions: IRegion[] = [];
  // regionsAll: IRegion[] = [];
  // sdasAll: ISDA[] = [];
  // sdas: ISDA[] = [];
  // end of funding dropdowns

  // items: MenuItem[];
  // faItems: MenuItem[];
  // qcItems: MenuItem[];

  // activeStep: number = 0;
  // application: IApplication;

  // selectedOption: boolean;

  // financialYears: IFinancialYear[];
  // selectedFinancialYear: IFinancialYear;

  // Used for table filtering
  // @ViewChild('dt') dt: Table | undefined;

  // funding dropdowns

  // fundingApplicationDetails: IFundingApplicationDetails = {
  //   applicationDetails: {
  //     fundAppSDADetail: {
  //       districtCouncil: {} as IDistrictCouncil,
  //       localMunicipality: {} as ILocalMunicipality,
  //       regions: [],
  //       serviceDeliveryAreas: [],
  //     } as IFundAppSDADetail,
  //   } as IApplicationDetails,

  //   financialMatters: [],
  //   implementations: [],

  // } as IFundingApplicationDetails;



  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _npoRepo: NpoService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _messageService: MessageService,
    private _fundAppService: FundingApplicationService,
    private _npoProfile: NpoProfileService,
    private _userRepo: UserService
    // private _bidService: BidService
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.applicationId = params.get('id');
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;
        this._spinner.show();

        if (!this.IsAuthorized(PermissionsEnum.EditApplication))
          this._router.navigate(['401']);

        this.loadApplication();
        this.qCSteps();
        this.buildMenu();
      }
    });
  }

  private loadApplication() {
    if (this.applicationId != null) {
      this._applicationRepo.getApplicationById(Number(this.applicationId)).subscribe(
        (results) => {
          this.application = results;
          this.applicationPeriod = this.application.applicationPeriod;
          this.loadNpo();
          this.loadCreatedUser();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadCreatedUser() {
    this._userRepo.getUserById(this.application.createdUserId).subscribe(
      (results) => {
        this.application.createdUser = results;
        this.loadUpdatedUser();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadUpdatedUser() {
    if (this.application.updatedUserId) {
      this._userRepo.getUserById(this.application.updatedUserId).subscribe(
        (results) => {
          this.application.updatedUser = results;
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
    else {
      this.application.updatedUser = {} as IUser;
    }
  }

  private loadNpo() {
    this._npoRepo.getNpoById(this.application.npoId).subscribe(
      (results) => {
        this.npo = results;
        this.loadFundingApplicationDetails();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadFundingApplicationDetails() {
    this._fundAppService.getFundingApplicationDetails(this.application.id).subscribe(
      (results) => {
        this.fundingApplicationDetails = results;
        this.amount = this.fundingApplicationDetails.applicationDetails.amountApplyingFor;
        this.districtCouncil = this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil;
        this.localMunicipality = this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality;
        if (this.fundingApplicationDetails.projectInformation != null) {
          this.projectInformation = this.fundingApplicationDetails.projectInformation;
        }
        else {
          this.fundingApplicationDetails.projectInformation = {} as IProjectInformation;
        }
        // this.regions = this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions;
        // this.sdas = this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas;

        this.loadRegions();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadRegions() {
    this._fundAppService.getRegions(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.id).subscribe(
      (results) => {
        this.regions = results;
        this.loadServiceDeliveryAreas();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadServiceDeliveryAreas() {
    this._fundAppService.getSdas(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.id).subscribe(
      (results) => {
        this.sdas = results;
        this.loadSourceOfInformation();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSourceOfInformation() {
    this._npoProfile.getSourceOfInformationById(this.application.id).subscribe(
      (results) => {
        this.sourceOfInformation = results;
        this.loadAffiliatedOrganisation();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadAffiliatedOrganisation() {
    this._npoProfile.getAffiliatedOrganisationById(this.application.id).subscribe(
      (results) => {
        this.affliatedOrganisationInfo = results;
        this.isDataAvailable = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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
            this._router.navigateByUrl('applications');
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

              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil = this.districtCouncil;
              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = this.localMunicipality;
              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = this.regions;
              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = this.sdas;

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

    // if (!this.amount)
    //   applicationDetailsError.push("Please specify the Rand amount you applying for");

    return applicationDetailsError;
  }

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[1].visible = false;
    this.organisationDetails.setValidated(false);
  }

  // private bidForm(status: StatusEnum) {
  //   this.application.status = null;
  //   if (status === StatusEnum.Saved) {
  //     this.application.statusId = status;
  //   }
  //   if (status === StatusEnum.PendingReview) {
  //     this.application.statusId = status;
  //   }
  //   if (this.bidCanContinue(status)) {
  //     this.application.statusId = status;
  //     if (this.validationErrors.length == 0) {
  //       this._applicationRepo.updateApplication(this.application).subscribe();
  //     }
  //     this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
  //     this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });

  //     if (status == StatusEnum.PendingReview) {
  //       this.application.status.name = "PendingReview";
  //       this._applicationRepo.updateApplication(this.application).subscribe();

  //       this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
  //       this._router.navigateByUrl('applications');
  //     };
  //   }
  // }


  // private bidCanContinue(status: StatusEnum) {
  //   this.validationErrors = [];
  //   if (status === StatusEnum.PendingReview)
  //     this.formValidate();
  //   if (this.validationErrors.length == 0)
  //     return true;

  //   return false;
  // }


  // private formValidate() {
  //   this.validationErrors = [];
  // }

  // private clearMessages() {
  //   this.validationErrors = [];
  //   this.menuActions[1].visible = false;
  // }




  // private canContinue(status: StatusEnum) {
  //   this.validationErrors = [];

  //   if (status === StatusEnum.PendingReview)
  //     this.formValidate();

  //   if (this.validationErrors.length == 0)
  //     return true;

  //   return false;
  // }



  // places(place: IPlace[]) {
  //   this.placeAll = place;
  // }

  // subPlaces(subPlaces: ISubPlace[]) {
  //   this.subPlacesAll = subPlaces;
  // }


  // getCellData(row: any, col: any): any {
  //   const nestedProperties: string[] = col.field.split('.');
  //   let value: any = row;

  //   for (const prop of nestedProperties) {
  //     value = value[prop];
  //   }

  //   return value;
  // }

  // applyFilterGlobal($event: any, stringVal: any) {
  //   this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  // }

  // add() {
  //   this._router.navigateByUrl('npo/create');
  // }

  // edit(npo: INpo) {
  //   this._router.navigateByUrl('npo/edit/' + npo.id);
  // }

  private qCSteps() {
    this.qcItems = [
      { label: 'Organisation Details' },   
      { label: 'Applications' },  
      { label: 'Application Detail' },
      { label: 'Objectives' },
      { label: 'Activities' },
      { label: 'Application Document' }
    ];
  }

  public validateStep(goToStep: number, currentStep: number) {
    if (goToStep > currentStep) {
      switch (currentStep) {
        case QCStepsFundedEnum.NpoCreate: {
          var orgDetailsError = this.validateOrganisationDetails();

          if (orgDetailsError.length > 0) {
            this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });
            this.organisationDetails.setValidated(true);
            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.Applications: {
          var orgDetailsError = this.validateOrganisationDetails();
          var applicationError = this.validateApplications();

          if (orgDetailsError.length > 0 || applicationError.length > 0) {

            if (orgDetailsError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });

            if (applicationError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });

            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.ApplicationDetail: {
          var orgDetailsError = this.validateOrganisationDetails();
          var applicationError = this.validateApplications();
          var applicationDetailsError = this.validateApplicationDetails();

          if (orgDetailsError.length > 0 || applicationError.length > 0 || applicationDetailsError.length > 0) {

            if (orgDetailsError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });

            if (applicationError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });

            if (applicationDetailsError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Application Details:", detail: applicationDetailsError.join('; ') });

            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.Objectives: {
          // var orgDetailsError = this.validateOrganisationDetails();
          // var applicationError = this.validateApplications();
          // var applicationDetailsError = this.validateApplicationDetails();

          // if (orgDetailsError.length > 0 || applicationError.length > 0 || applicationDetailsError.length > 0) {

          //   if (orgDetailsError.length > 0)
          //     this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });

          //   if (applicationError.length > 0)
          //     this._messageService.add({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });

          //   if (applicationDetailsError.length > 0)
          //     this._messageService.add({ severity: 'error', summary: "Application Details:", detail: applicationDetailsError.join('; ') });

          //   break;
          // }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.Activities: {
          var orgDetailsError = this.validateOrganisationDetails();
          var applicationError = this.validateApplications();
          var applicationDetailsError = this.validateApplicationDetails();

          if (orgDetailsError.length > 0 || applicationError.length > 0 || applicationDetailsError.length > 0) {

            if (orgDetailsError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });

            if (applicationError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });

            if (applicationDetailsError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Application Details:", detail: applicationDetailsError.join('; ') });

            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.ApplicationFundedDocument: {
          this.activeStep = goToStep;
          break;
        }
      }
    }
    else
      this.activeStep = goToStep;
  }
}
