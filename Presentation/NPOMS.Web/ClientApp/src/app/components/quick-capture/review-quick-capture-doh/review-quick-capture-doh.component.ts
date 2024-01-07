import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PermissionsEnum, AccessStatusEnum, ApplicationTypeEnum, QCStepsEnum, FundingApplicationStepsEnum, StatusEnum, DropdownTypeEnum, QCStepsFundedEnum, RoleEnum } from 'src/app/models/enums';
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
  selector: 'app-review-quick-capture-doh',
  templateUrl: './review-quick-capture-doh.component.html',
  styleUrls: ['./review-quick-capture-doh.component.css']
})
export class ReviewQuickCaptureDohComponent implements OnInit {

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
  public get QCStepsFundedEnum(): typeof QCStepsFundedEnum {
    return QCStepsFundedEnum;
  }

  profile: IUser;

  isMainReviewer: boolean;
  isSystemAdmin: boolean;
  isAdmin: boolean;
  canReviewOrApprove: boolean = false;

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
  purposeQuestion: string;
  menuActions: MenuItem[];
  validationErrors: Message[];
  qcItems: MenuItem[];
  isStepsAvailable: boolean;

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
    } as IApplicationDetails,
    projectInformation: {} as IProjectInformation
  } as IFundingApplicationDetails;

  activeStep: number = 0;

  @ViewChild(CreateQuickCaptureComponent) organisationDetails: CreateQuickCaptureComponent;

  isDataAvailable: boolean;

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

        // if (!this.IsAuthorized(PermissionsEnum.EditApplication))
        //   this._router.navigate(['401']);

          this.isSystemAdmin = this.profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
          this.isAdmin = this.profile.roles.some(function (role) { return role.id === RoleEnum.Admin });
          this.isMainReviewer = this.profile.roles.some(function (role) { return role.id === RoleEnum.MainReviewer });
    
          // Add confirmation step if Main Reviewer
          if (this.isSystemAdmin || this.isAdmin || this.isMainReviewer) {
           // this.qcItems.push({ label: 'Confirmation' });
            this.canReviewOrApprove = true;
          }

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
          this.purposeQuestion = this.fundingApplicationDetails.projectInformation.purposeQuestion;
        }
        else {
          this.fundingApplicationDetails.projectInformation = {} as IProjectInformation;
        }
       
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

    return applicationDetailsError;
  }

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[1].visible = false;
    this.organisationDetails.setValidated(false);
  }


  private qCSteps() {
    this.qcItems = [
      { label: 'Organisation Details' },   
      { label: 'Applications' },  
      { label: 'Application Detail' },
      { label: 'Objectives' },
      { label: 'Activities' },
      { label: 'Application Document' }
    ];
    this.updateSteps();
  }

  private updateSteps() {
    if (this.profile != null) {
      this.isSystemAdmin = this.profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
      this.isAdmin = this.profile.roles.some(function (role) { return role.id === RoleEnum.Admin });
      this.isMainReviewer = this.profile.roles.some(function (role) { return role.id === RoleEnum.MainReviewer });

      // Add confirmation step if Main Reviewer
      if (this.isSystemAdmin || this.isAdmin || this.isMainReviewer) {
        this.qcItems.push({ label: 'Confirmation' });
        this.canReviewOrApprove = true;
      }

      this.isStepsAvailable = true;
    }
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
