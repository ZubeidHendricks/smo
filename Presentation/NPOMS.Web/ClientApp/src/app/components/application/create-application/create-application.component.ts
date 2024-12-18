import { IApplicationDetails, IDistrictCouncil, IFundAppSDADetail, ILocalMunicipality, IPlace, IProjectInformation, IQuickCaptureDetails, IRegion, ISDA, ISubPlace } from './../../../models/interfaces';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'; 
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ApplicationTypeEnum, PermissionsEnum, QuickCaptureStepsEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationPeriod, IFundingApplicationDetails, IObjective, IResource, ISustainabilityPlan, IUser } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { FundingApplicationStepsEnum } from '../../../models/enums';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { IFinancialMattersIncome } from 'src/app/models/FinancialMatters';

@Component({
  selector: 'app-create-application',
  templateUrl: './create-application.component.html',
  styleUrls: ['./create-application.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class CreateApplicationComponent implements OnInit {
  canEdit: boolean = false;
  applicationIdOnBid: any;
  // subPlacesAll: ISubPlace[];
  // place: IPlace[];
  
  placesAll: IPlace[] = [];
  subPlacesAll: ISubPlace[] = [];
  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get ApplicationTypeEnum(): typeof ApplicationTypeEnum {
    return ApplicationTypeEnum;
  }

  public get ServiceProvisionStepsEnum(): typeof ServiceProvisionStepsEnum {
    return ServiceProvisionStepsEnum;
  }

  public get FundingApplicationStepsEnum(): typeof FundingApplicationStepsEnum {
    return FundingApplicationStepsEnum;
  }

  public get QuickCaptureStepsEnum(): typeof QuickCaptureStepsEnum {
    return QuickCaptureStepsEnum;
  }

  paramSubcriptions: Subscription;
  npoId: string;
  applicationPeriodId: number;
  id: string;

  menuActions: MenuItem[];
  profile: IUser;
  validationErrors: Message[];
  items: MenuItem[];
  faItems: MenuItem[];
  qcItems: MenuItem[];
  financialMattersIncome: IFinancialMattersIncome[];
  activeStep: number = 0;
  application: IApplication;
  applicationPeriod: IApplicationPeriod;
  isApplicationAvailable: boolean;

  objectives: IObjective[] = [];
  activities: IActivity[] = [];
  sustainabilityPlans: ISustainabilityPlan[] = [];
  resources: IResource[] = [];

  // funding dropdowns
  // funding dropdowns
  districtCouncils: IDistrictCouncil[] = [];
  localMunicipalitiesAll: ILocalMunicipality[] = [];
  localMunicipalities: ILocalMunicipality[] = [];
  regions: IRegion[] = [];
  regionsAll: IRegion[] = [];
  sdasAll: ISDA[] = [];
  sdas: ISDA[] = [];
  // end of funding dropdowns

  fundingApplicationDetails: IFundingApplicationDetails = {
    applicationDetails: {
      fundAppSDADetail: {
        districtCouncil: {} as IDistrictCouncil,
        localMunicipality: {} as ILocalMunicipality,
        regions: [],
        serviceDeliveryAreas: [],
      } as IFundAppSDADetail,
    } as IApplicationDetails,

    financialMatters: [],
    implementations: [],

  } as IFundingApplicationDetails;

  // quickCaptureDetails: IQuickCaptureDetails = {
  //   applicationDetails: {
  //     fundAppSDADetail: {
  //       districtCouncil: {} as IDistrictCouncil,
  //       localMunicipality: {} as ILocalMunicipality,
  //       regions: [],
  //       serviceDeliveryAreas: [],
  //     } as IFundAppSDADetail,
  //   } as IApplicationDetails,    

  // } as IQuickCaptureDetails;  

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _messageService: MessageService,
    private _loggerService: LoggerService,
    private _fundAppService: FundingApplicationService,
    private _bidService: BidService
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
      this.loadApplication();
      this.loadfundingDropdowns();
      this.applicationPeriodId = +this.id;
      this.fundingApplicationDetails.applicationPeriodId = +this.id;
      this._bidService.getApplicationBiId(+this.id).subscribe(resp => {
      });
      this.loadQuickCaptureDropdowns();
      //this.quickCaptureDetails.applicationPeriodId = +this.id;
    });
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.AddApplication))
          this._router.navigate(['401']);

        this.buildMenu();
      }
    });
  }
  private loadfundingDropdowns() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {

        if (results != null) {
          this.application = results;
          this.fundingApplicationDetails.applicationPeriodId = this.application?.applicationPeriodId;
          this.fundingApplicationDetails.applicationId = this.application?.id;
          this.fASteps(results.applicationPeriod);
          this.isApplicationAvailable = true;
        }
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private fASteps(applicationPeriod: IApplicationPeriod) {
    if (applicationPeriod != null) {
      if (applicationPeriod.applicationTypeId === ApplicationTypeEnum.FA) {
        this.faItems = [
          { label: 'Organisation Details', command: (event: any) => { this.activeStep = 0; } },
          { label: 'Application Details', command: (event: any) => { this.activeStep = 1; } },
          { label: 'Financial Matters', disabled: true },
          { label: 'Project Information' , disabled: true},
          { label: 'Monitoring and Evaluation', disabled: true},
          { label: 'Project Implementation Plan', disabled: true},
          { label: 'Application Document', disabled: true}
        ];
      }
    }
  }



  private loadQuickCaptureDropdowns() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {

        if (results != null) {
          this.application = results;
          // this.quickCaptureDetails.applicationPeriodId = this.application?.applicationPeriodId;
          // this.quickCaptureDetails.applicationId = this.application?.id;
          this.qCSteps(results.applicationPeriod);
          this.isApplicationAvailable = true;
        }
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private qCSteps(applicationPeriod: IApplicationPeriod) {
    if (applicationPeriod != null) {
      if (applicationPeriod.applicationTypeId === ApplicationTypeEnum.QC) {
        this.qcItems = [
          { label: 'Organisation Details', command: (event: any) => { this.activeStep = 0; } },
          { label: 'Application Details', command: (event: any) => { this.activeStep = 1; } },
          { label: 'Application Document', command: (event: any) => { this.activeStep = 2; } }
        ];
      }
    }
  }

  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
          this.buildSteps(results.applicationPeriod);
          this.loadObjectives();
          this.loadActivities();
          this.loadSustainabilityPlans();
          this.loadResources();
          this.isApplicationAvailable = true;
        }

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private buildSteps(applicationPeriod: IApplicationPeriod) {
    if (applicationPeriod != null) {
      if (applicationPeriod.applicationTypeId === ApplicationTypeEnum.SP) {
        this.items = [
          { label: 'Organisation Details' },
          { label: 'Objectives' },
          { label: 'Activities' },
          { label: 'Sustainability' },
          { label: 'Resourcing' }
        ];
      }
    }
  }

  public loadObjectives() {
    this._applicationRepo.getAllObjectives(this.application).subscribe(
      (results) => {
        this.objectives = results.filter(x => x.isActive === true);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public loadActivities() {
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.activities = results.filter(x => x.isActive === true);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public loadSustainabilityPlans() {
    this._applicationRepo.getAllSustainabilityPlans(this.application).subscribe(
      (results) => {
        this.sustainabilityPlans = results.filter(x => x.isActive === true);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public loadResources() {
    this._applicationRepo.getAllResources(this.application).subscribe(
      (results) => {
        this.resources = results.filter(x => x.isActive === true);
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
          // visible: false
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
            if (this.application.applicationPeriod.applicationTypeId === ApplicationTypeEnum.SP) {
              this.saveItems(StatusEnum.Saved);
            }

            if (this.application.applicationPeriod.applicationTypeId === ApplicationTypeEnum.FA) {
              this.bidForm(StatusEnum.Saved);
            }


            if (this.application.applicationPeriod.applicationTypeId === ApplicationTypeEnum.QC) {
              this.bidForm(StatusEnum.Saved);
            }
          }
        },

        {
          label: 'Submit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            if (this.application.applicationPeriod.applicationTypeId === ApplicationTypeEnum.SP) {
              this.saveItems(StatusEnum.PendingReview);
            }

            if (this.application.applicationPeriod.applicationTypeId === ApplicationTypeEnum.FA) {
              this.bidForm(StatusEnum.PendingReview);
            }

            if (this.application.applicationPeriod.applicationTypeId === ApplicationTypeEnum.QC) {
              this.bidForm(StatusEnum.PendingReview);
            }

          },
          disabled: true
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
    
    this.application.status = null;
    this.fundingApplicationDetails.programId = this.application.applicationPeriod.programmeId
    this.fundingApplicationDetails.subProgramId = this.application.applicationPeriod.subProgrammeId
    this.fundingApplicationDetails.subProgramTypeId = this.application.applicationPeriod.subProgrammeTypeId
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
      if (!this.applicationIdOnBid) {
        this.fundingApplicationDetails.implementations = null;
        this._bidService.addBid(this.fundingApplicationDetails).subscribe(resp => {
          this.menuActions[1].visible = false;
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
         //this._router.navigateByUrl(`application/create/${this.application.id}`);
         this._router.navigateByUrl(`application/edit/${this.application.id}/${this.activeStep}`); 
          resp;
        });
      }
      else {
        this.fundingApplicationDetails.implementations = null;
        this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });

      }

      if (status == StatusEnum.PendingReview) {
        
        this.application.status.name = "PendingReview";
        this._applicationRepo.updateApplication(this.application).subscribe();

        this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
        this._router.navigateByUrl('applications');
      };
    }
  }


  private bidCanContinue(status: StatusEnum) {
    this.validationErrors = [];
    if (status === StatusEnum.PendingReview)
      this.formValidate();
    if (this.validationErrors.length == 0)
      return true;

    return false;
  }

  private formValidate() {
    this.validationErrors = [];
    if (this.application.applicationPeriod.applicationTypeId === ApplicationTypeEnum.SP) {

      if (this.objectives.length === 0)
        this.validationErrors.push({ severity: 'error', summary: "Objectives:", detail: "Objective table cannot be empty." });

      if (this.objectives.length > 0) {
        let changesRequiredOnObjectives = this.objectives.filter(x => x.changesRequired === true);

        if (changesRequiredOnObjectives.length > 0)
          this.validationErrors.push({ severity: 'warn', summary: "Objectives:", detail: "New comments added." });
      }

      if (this.activities.length === 0)
        this.validationErrors.push({ severity: 'error', summary: "Activities:", detail: "Activity table cannot be empty." });
      else {
        let hasActivityErrors: boolean[] = [];

        this.objectives.forEach(item => {
          var isPresent = this.activities.some(function (activity) { return activity.objectiveId === item.id });
          hasActivityErrors.push(isPresent);
        });

        if (hasActivityErrors.includes(false))
          this.validationErrors.push({ severity: 'warn', summary: "Activities:", detail: "Please capture an activity for each objective." });
      }

      if (this.activities.length > 0) {
        let changesRequiredOnActivities = this.activities.filter(x => x.changesRequired === true);

        if (changesRequiredOnActivities.length > 0)
          this.validationErrors.push({ severity: 'warn', summary: "Activities:", detail: "New comments added." });
      }

      if (this.sustainabilityPlans.length === 0)
        this.validationErrors.push({ severity: 'error', summary: "Sustainability:", detail: "Sustainability Plan table cannot be empty." });
      else {
        let hasSustainabilityErrors: boolean[] = [];

        this.activities.forEach(item => {
          var isPresent = this.sustainabilityPlans.some(function (sustainabilityPlan) { return sustainabilityPlan.activityId === item.id });
          hasSustainabilityErrors.push(isPresent);
        });

        if (hasSustainabilityErrors.includes(false))
          this.validationErrors.push({ severity: 'warn', summary: "Sustainability:", detail: "Please capture a sustainability plan for each activity." });
      }

      if (this.sustainabilityPlans.length > 0) {
        let changesRequiredOnSustainabilityPlans = this.sustainabilityPlans.filter(x => x.changesRequired === true);

        if (changesRequiredOnSustainabilityPlans.length > 0)
          this.validationErrors.push({ severity: 'warn', summary: "Sustainability:", detail: "New comments added." });
      }

      if (this.resources.length === 0)
        this.validationErrors.push({ severity: 'error', summary: "Resourcing:", detail: "Resourcing table cannot be empty." });
      else {
        let hasResourcingErrors: boolean[] = [];

        this.activities.forEach(item => {
          var isPresent = this.resources.some(function (resource) { return resource.activityId === item.id });
          hasResourcingErrors.push(isPresent);
        });

        if (hasResourcingErrors.includes(false))
          this.validationErrors.push({ severity: 'warn', summary: "Resourcing:", detail: "Please capture a resource for each activity." });
      }

      if (this.resources.length > 0) {
        let changesRequiredOnResources = this.resources.filter(x => x.changesRequired === true);

        if (changesRequiredOnResources.length > 0)
          this.validationErrors.push({ severity: 'warn', summary: "Resourcing:", detail: "New comments added." });
      }

    }


    if (this.application.applicationPeriod.applicationTypeId === ApplicationTypeEnum.FA) {

      // if (this.fundingApplicationDetails.implementations.length === 0)
      //   this.validationErrors.push({ severity: 'error', summary: "Implementations:", detail: "Please capture implementations." });
      // if (this.fundingApplicationDetails.projectInformation.initiatedQuestion == null && this.fundingApplicationDetails.projectInformation.considerQuestion == null &&
      //   this.fundingApplicationDetails.projectInformation.purposeQuestion == null)
      //   this.validationErrors.push({ severity: 'error', summary: "Project Info:", detail: "Please capture Project Information." });

      // if (this.fundingApplicationDetails.monitoringEvaluation.monEvalDescription == null)
      //   this.validationErrors.push({ severity: 'error', summary: "Monitoring:", detail: "Please capture Monitoring and Evaluation." });
      if (this.fundingApplicationDetails.applicationDetails.amountApplyingFor == undefined)
        this.validationErrors.push({ severity: 'error', summary: "Application Details:", detail: "Please specify the Rand amount you applying for." });
      // if (this.financialMattersIncome.length === 0)
      //   this.validationErrors.push({ severity: 'error', summary: "Financial Matters:", detail: "Please capture financial matters." });

      if (this.fundingApplicationDetails.implementations.length === 0)
        this.validationErrors.push({ severity: 'error', summary: "Implementations:", detail: "Please capture implementations." });
      if (this.fundingApplicationDetails.projectInformation?.purposeQuestion == undefined)
        this.validationErrors.push({ severity: 'error', summary: "Project Info:", detail: "Please capture Project Information." });

      if (this.fundingApplicationDetails.monitoringEvaluation?.monEvalDescription == undefined)
        this.validationErrors.push({ severity: 'error', summary: "Monitoring:", detail: "Please capture Monitoring and Evaluation." });
  
    
    }

    // if (this.validationErrors.length == 0)
    //   this.menuActions[1].visible = false;
    // else
    //   this.menuActions[1].visible = true;
    if (this.validationErrors.length == 0) {
      this.menuActions[3].disabled = false;
      this.menuActions[1].visible = false;
    }
    else {
      this.menuActions[3].disabled = true;
      this.menuActions[1].visible = true;
    }
  }

  // private formValidate() {
  //   this.validationErrors = [];
  //   if (this.application.applicationPeriodId === ApplicationTypeEnum.SP) {

  //     if (this.objectives.length === 0)
  //       this.validationErrors.push({ severity: 'error', summary: "Objectives:", detail: "Objective table cannot be empty." });

  //     if (this.activities.length === 0)
  //       this.validationErrors.push({ severity: 'error', summary: "Activities:", detail: "Activity table cannot be empty." });
  //     else {
  //       let hasActivityErrors: boolean[] = [];

  //       this.objectives.forEach(item => {
  //         var isPresent = this.activities.some(function (activity) { return activity.objectiveId === item.id });
  //         hasActivityErrors.push(isPresent);
  //       });

  //       if (hasActivityErrors.includes(false))
  //         this.validationErrors.push({ severity: 'warn', summary: "Activities:", detail: "Please capture an activity for each objective." });
  //     }

  //     if (this.sustainabilityPlans.length === 0)
  //       this.validationErrors.push({ severity: 'error', summary: "Sustainability:", detail: "Sustainability Plan table cannot be empty." });
  //     else {
  //       let hasSustainabilityErrors: boolean[] = [];

  //       this.activities.forEach(item => {
  //         var isPresent = this.sustainabilityPlans.some(function (sustainabilityPlan) { return sustainabilityPlan.activityId === item.id });
  //         hasSustainabilityErrors.push(isPresent);
  //       });

  //       if (hasSustainabilityErrors.includes(false))
  //         this.validationErrors.push({ severity: 'warn', summary: "Sustainability:", detail: "Please capture a sustainability plan for each activity." });
  //     }

  //     if (this.resources.length === 0)
  //       this.validationErrors.push({ severity: 'error', summary: "Resourcing:", detail: "Resourcing table cannot be empty." });
  //     else {
  //       let hasResourcingErrors: boolean[] = [];

  //       this.activities.forEach(item => {
  //         var isPresent = this.resources.some(function (resource) { return resource.activityId === item.id });
  //         hasResourcingErrors.push(isPresent);
  //       });

  //       if (hasResourcingErrors.includes(false))
  //         this.validationErrors.push({ severity: 'warn', summary: "Resourcing:", detail: "Please capture a resource for each activity." });
  //     }
  //   }

  //   if (this.application.applicationPeriodId === ApplicationTypeEnum.FA) {
  //     if (this.fundingApplicationDetails.applicationDetails.amountApplyingFor == undefined)
  //       this.validationErrors.push({ severity: 'error', summary: "Application Details:", detail: "Please specify the Rand amount you applying for." });
  //     // if (this.financialMattersIncome.length === 0)
  //     //   this.validationErrors.push({ severity: 'error', summary: "Financial Matters:", detail: "Please capture financial matters." });

  //     if (this.fundingApplicationDetails.implementations.length === 0)
  //       this.validationErrors.push({ severity: 'error', summary: "Implementations:", detail: "Please capture implementations." });
  //     if (this.fundingApplicationDetails.projectInformation?.purposeQuestion == undefined)
  //       this.validationErrors.push({ severity: 'error', summary: "Project Info:", detail: "Please capture Project Information." });

  //     if (this.fundingApplicationDetails.monitoringEvaluation?.monEvalDescription == undefined)
  //       this.validationErrors.push({ severity: 'error', summary: "Monitoring:", detail: "Please capture Monitoring and Evaluation." });
  //   }

  //   if (this.validationErrors.length == 0) {
  //     this.menuActions[3].disabled = false;
  //     this.menuActions[1].visible = false;
  //   }
  //   else {
  //     this.menuActions[3].disabled = true;
  //     this.menuActions[1].visible = true;
  //   }

  // }

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[1].visible = false;
  }

  private saveItems(status: StatusEnum) {
    if (this.canContinue(status)) {
      this._spinner.show();
      this.application.statusId = status;

      this._applicationRepo.updateApplication(this.application).subscribe(
        (resp) => {
          if (resp.statusId === StatusEnum.Saved) {
            this._spinner.hide();
            this.menuActions[1].visible = false;
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
  }



  private canContinue(status: StatusEnum) {
    this.validationErrors = [];

    if (status === StatusEnum.PendingReview)
      this.formValidate();

    if (this.validationErrors.length == 0)
      return true;

    return false;
  }


  places(place: IPlace[]) {
    this.placesAll = place;
  }

  subPlaces(subPlacesAll: ISubPlace[]) {
    this.subPlacesAll = subPlacesAll;
  }
  public saveFundingApplication()
  {
    this.bidForm(StatusEnum.Saved);
  }
}
