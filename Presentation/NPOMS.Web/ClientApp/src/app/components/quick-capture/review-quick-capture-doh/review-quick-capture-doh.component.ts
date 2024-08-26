import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PermissionsEnum, AccessStatusEnum, ApplicationTypeEnum, QCStepsEnum, FundingApplicationStepsEnum, StatusEnum, DropdownTypeEnum, QCStepsFundedEnum, RoleEnum } from 'src/app/models/enums';
import { IUser, INpo, IApplicationPeriod, IFundingApplicationDetails, IDistrictCouncil, ILocalMunicipality, IFundAppSDADetail, IApplicationDetails, IApplication, IPlace, ISubPlace, ISDA, IRegion, IObjective, IActivity, ISustainabilityPlan, IResource, IQuickCaptureDetails, IFinancialYear, IProjectInformation, IApplicationApproval } from 'src/app/models/interfaces';
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
  status: StatusEnum;

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
            this.formValidate();
          },
          disabled: !this.canReviewOrApprove,
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
            this._router.navigateByUrl('applications');
          }
        },
        {
          label: 'Submit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            if (this.status)
              this.saveItems(this.status);
            else
              this._messageService.add({ severity: 'error', summary: "Confirmation:", detail: "Please select an option." });
          },
          disabled: !this.canReviewOrApprove
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

  private formValidate() {
    this.validationErrors = [];

    if (!this.status)
      this.validationErrors.push({ severity: 'error', summary: "Confirmation:", detail: "Please select an option." });

    if (this.validationErrors.length == 0)
      this.menuActions[1].visible = false;
    else
      this.menuActions[1].visible = true;
  }

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[1].visible = false;
  }

  private saveItems(status: StatusEnum) {
    if (this.canContinue()) {
      this._spinner.show();
      this.application.statusId = status;

      let applicationApproval = {
        applicationId: this.application.id
      } as IApplicationApproval;

      this._applicationRepo.updateApplicationApproval(applicationApproval).subscribe(
        (resp) => {
          this._applicationRepo.updateApplication(this.application).subscribe(
            (resp) => {
              this._spinner.hide();
              this._router.navigateByUrl('applications');
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

  private canContinue() {
    this.validationErrors = [];
    this.formValidate();

    if (this.validationErrors.length == 0)
      return true;

    return false;
  }

  private bidCanContinue(status: StatusEnum) {
    this.validationErrors = [];
    this.menuActions[1].visible = this.validationErrors.length > 0 ? true : false;
    return this.validationErrors.length === 0 ? true : false;
  }
  

  private qCSteps() {
    this.qcItems = [
      { label: 'Applications' },  
      { label: 'Organisation Details' },        
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
          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.Applications: {
          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.ApplicationDetail: {
          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.Objectives: {
          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.Activities: {
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
