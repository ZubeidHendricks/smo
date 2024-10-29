import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Console } from 'console';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { BehaviorSubject, Subscription } from 'rxjs';
import { FinancialMatters, IFinancialMattersIncome } from 'src/app/models/FinancialMatters';
import { ApplicationTypeEnum, DocumentUploadLocationsEnum, DropdownTypeEnum, FundingApplicationStepsEnum, NPOReportingStepsEnum, PermissionsEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationDetails, IApplicationPeriod, IDocumentType, 
  IFundingApplicationDetails, IMonitoringAndEvaluation, IObjective, IPlace, IProjectImplementation, 
  IProjectInformation, IResource, ISubPlace, ISustainabilityPlan, IUser,
  IDistrictCouncil,ILocalMunicipality,IRegion, IFundAppSDADetail, 
  IFinancialYear,
  INpo} from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { UserService } from 'src/app/services/api-services/user/user.service';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';


@Component({
  selector: 'app-npo-report-capture',
  templateUrl: './npo-report-capture.component.html',
  styleUrls: ['./npo-report-capture.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class NpoReportCaptureComponent implements OnInit {

  dynamicHeaderText: string = '';
  postdynamicHeaderText: string = '';
  incomedynamicHeaderText: string = '';
  govnencedynamicHeaderText: string = '';
  otherdynamicHeaderText: string = '';
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

  public get NPOReportingStepsEnum(): typeof NPOReportingStepsEnum {
    return NPOReportingStepsEnum;
  }
  public get FundingApplicationStepsEnum(): typeof FundingApplicationStepsEnum {
    return FundingApplicationStepsEnum;
  }
  @Input() source: string;
  @Input() programId: number;
  
  applicationPeriodId: number;
  paramSubcriptions: Subscription;
  id: string;
  financialMattersIncome: IFinancialMattersIncome[];
  bidId: number;
  placeAll: IPlace[] = [];
  subPlacesAll: ISubPlace[] = [];
  applicationIdOnBid: any;
  selectedApplicationId: number;
  menuActions: MenuItem[];
  profile: IUser;
  validationErrors: Message[];
  documentTypes: IDocumentType[] = [];

  items: MenuItem[];
  faItems: MenuItem[];

  activeStep: number = 0;
  application: IApplication;
  isApplicationAvailable: boolean;

  objectives: IObjective[] = [];
  activities: IActivity[] = [];
  sustainabilityPlans: ISustainabilityPlan[] = [];
  resources: IResource[] = [];

  activeButton: number | null = null;
  financialYears: IFinancialYear[];
  npo: INpo;

  fundingApplicationDetails: IFundingApplicationDetails = {
    financialMatters: [],
    implementations: [],
    projectInformation: {} as IProjectInformation,
    monitoringEvaluation: {} as IMonitoringAndEvaluation,
    applicationDetails: {} as IApplicationDetails
  } as IFundingApplicationDetails;


  private financialYearsSubject = new BehaviorSubject<IFinancialYear[]>([]);
  private financialYears$ = this.financialYearsSubject.asObservable();

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _messageService: MessageService,
    private _bidService: BidService,
    private _dropdownRepo: DropdownService,
    private _loggerService: LoggerService,
    private _userRepo: UserService,
    private _npoRepo: NpoService,
  ) { }

  places(place: IPlace[]) {
    this.placeAll = place;
  }

  subPlaces(subPlaces: ISubPlace[]) {
    this.subPlacesAll = subPlaces;
  }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      console.log('params', params);
      this.id = params.get('id');
      this.loadApplication();
      this.loadDocumentTypes();
      this.loadFinancialYears();
      if (Number(params.get('activeStep')) === 2) {
        this.activeStep = Number(params.get('activeStep'));
      }
      if (Number(params.get('activeStep')) === 9) {
        this._router.navigateByUrl(`application/edit/${this.application.id}/6`);
      }
    });

    this.loadfundingSteps();
    this.applicationPeriodId = +this.id;
    this.fundingApplicationDetails.applicationPeriodId = +this.id;
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;
        if (!this.IsAuthorized(PermissionsEnum.EditApplication))
          this._router.navigate(['401']);
        this.buildMenu();
      }
    });
  }

  private loadNpo() {
    console.log ('this.application', this.application);
    this._npoRepo.getNpoById(this.application?.npoId).subscribe(
      (results) => {
        this.npo = results;

        //this.loadIndicators();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }


  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        //this.financialYears = results;
        this.financialYearsSubject.next(results);
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

getFinancialYear(id: number): string | undefined {
  const financialYears = this.financialYearsSubject.getValue();
  const financialYear = financialYears.find(year => year.id === id);
  return financialYear ? financialYear.name : undefined;
}



toggleButton(buttonId: number) {
    this.activeButton = this.activeButton === buttonId ? null : buttonId;
}

getfinFund(event: FinancialMatters) {
    // console.log('event from Edit', JSON.stringify(event));
}

  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
          this.loadNpo();
          this.buildSteps(results.applicationPeriod);
          this.loadCreatedUser();
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
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
    else {
      this.application.updatedUser = {} as IUser;
      this._spinner.hide();
    }
  }

  private buildSteps(applicationPeriod: IApplicationPeriod) {
    if (applicationPeriod != null) {
      if (applicationPeriod.applicationTypeId === ApplicationTypeEnum.SP) {
        this.items = [
          { label: 'Indicator Report' },
          { label: 'Post Report' },
          { label: 'Details of Income and Expenditure' },
          { label: 'Governance' },
          { label: 'Any Other Information' },
          { label: 'Quartely SDIP Reporting' }
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



  public loadDocumentTypes() {
    this._dropdownRepo.GetEntitiesForDoc(DropdownTypeEnum.DocumentTypes, Number(this.id), false).subscribe(
      (results) => {
        this.documentTypes = results.filter(x => x.location === DocumentUploadLocationsEnum.FundApp && x.isCompulsory === true);

      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public fASteps(applicationPeriod: IApplicationPeriod) {

    if (applicationPeriod != null) {
      if (applicationPeriod.applicationTypeId === ApplicationTypeEnum.FA) {
        this.faItems = [
          { label: 'Indicator Report', command: (event: any) => { this.activeStep = 0; } },
          { label: 'Post Report', command: (event: any) => { this.activeStep = 1; } },
          { label: 'Details of Income and Expenditure', command: (event: any) => { this.activeStep = 2; } },
          { label: 'Governance', command: (event: any) => { this.activeStep = 3; } },
          { label: 'Any Other Information', command: (event: any) => { this.activeStep = 4; } },
          { label: 'Quartely SDIP Reporting', command: (event: any) => { this.activeStep = 5; } },
          { label: 'Application Document', command: (event: any) => { this.activeStep = 6; } }
        ];
      }
    }
  }


  private buildMenu() {
    if (this.profile) {
      this.menuActions = [
        // {
        //   label: 'Validate',
        //   icon: 'fa fa-check',
        //   command: () => {
        //     this.formValidate();
        //   }
        // },
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
            this.saveItems(StatusEnum.Saved);
          }
        },
        {
          label: 'Submit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.saveItems(StatusEnum.PendingReview);
          },
          disabled: true
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
    this.application.status = null;
    if (this.bidCanContinue(status)) {
      this.application.statusId = status;
      this.fundingApplicationDetails.implementations = null;
      const applicationIdOnBid = this.fundingApplicationDetails;
      this.fundingApplicationDetails.programId = this.application.applicationPeriod.programmeId;
      this.fundingApplicationDetails.subProgramId = this.application.applicationPeriod.subProgrammeId
      this.fundingApplicationDetails.subProgramTypeId = this.application.applicationPeriod.subProgrammeTypeId
      this.fundingApplicationDetails.applicationPeriodId = this.application.applicationPeriodId;
      this.fundingApplicationDetails.applicationId = Number(this.id);

      if (status == StatusEnum.PendingReview) {
        this.application.statusId = status;
        this._applicationRepo.updateApplication(this.application).subscribe();
        this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
        this._router.navigateByUrl('applications');
        this.fundingApplicationDetails.implementations = null;
      };

      this._applicationRepo.updateApplication(this.application).subscribe(resp => 
      { 
        this._applicationRepo.getApplicationById(Number(this.id)) });
        this.application.statusId = status;    

      if (applicationIdOnBid.id == null) {
        this._bidService.addBid(this.fundingApplicationDetails).subscribe(resp => {
          this.menuActions[1].visible = false;
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
          resp;
        });
      }
      else {
        this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => {
          if (resp) {
            if(status === StatusEnum.PendingReview)
            {
              this._router.navigateByUrl('applications');
            }
            else{
              this._router.navigateByUrl(`application/edit/${this.application.id}/${this.activeStep}`);
              this.loadfundingSteps();
              //this.getBidFullObject(resp);  //          
              this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
              this.fundingApplicationDetails.implementations = null;
            }
           
          }
        });
      }      
    }
  }
  // bid continue form
  private bidCanContinue(status: StatusEnum) {
    this.validationErrors = [];
    if (status === StatusEnum.PendingReview)
      this.formValidate();
    if (this.validationErrors.length == 0)
      return true;
    return false;
  }


  //funding drop downs
  private loadfundingSteps() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
          this._bidService.getApplicationBiId(results.id).subscribe(response => { // can you please return bid obj not DOM
            if (response && response.id != null) {
              this.getFundingApplicationDetails(response);
            }
          });
          this.fASteps(results.applicationPeriod);
          this.loadCreatedUser();
        }
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private getFundingApplicationDetails(data) {
    this._bidService.getBid(data.id).subscribe(response => {
      this.getBidFullObject(response);
    });
  }

  private getBidFullObject(data) {
    this.fundingApplicationDetails.implementations = null;
    this.fundingApplicationDetails = data;
    this.fundingApplicationDetails.id = data.id;
    this.fundingApplicationDetails.applicationDetails.amountApplyingFor = data.applicationDetails.amountApplyingFor;
    this.fundingApplicationDetails.implementations = data.implementations;
    if (this.fundingApplicationDetails.projectInformation != null) {
      this.fundingApplicationDetails.projectInformation.purposeQuestion = data.projectInformation.purposeQuestion;
    }
    else {
      this.fundingApplicationDetails.projectInformation = {} as IProjectInformation;
    }

    if (this.fundingApplicationDetails.monitoringEvaluation != null) {
      this.fundingApplicationDetails.monitoringEvaluation.monEvalDescription = data.monitoringEvaluation.monEvalDescription;

    }
    else {
      this.fundingApplicationDetails.monitoringEvaluation = {} as IMonitoringAndEvaluation;
    }
    this.fundingApplicationDetails.financialMatters = data.financialMatters;
    this.fundingApplicationDetails.applicationDetails.fundAppSDADetail = data.applicationDetails.fundAppSDADetail;

    this.fundingApplicationDetails.implementations?.forEach(c => {

      let a = new Date(c.timeframeFrom);
      c.timeframe?.push(new Date(c.timeframeTo));
      c.timeframe?.push(new Date(c.timeframeFrom))
    });

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

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[1].visible = false;
  }

  private saveItems(status: StatusEnum) {
    // if (this.canContinue(status)) {
    //   this._spinner.show();
    //   this.application.statusId = status;

    //   this._applicationRepo.updateApplication(this.application).subscribe(
    //     (resp) => {
    //       if (resp.statusId === StatusEnum.Saved) {
    //         this._spinner.hide();
    //         this.menuActions[1].visible = false;
    //         this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
    //       }

    //       if (resp.statusId === StatusEnum.PendingReview) {
    //         this._spinner.hide();
    //         this._router.navigateByUrl('applications');
    //       }
    //     },
    //     (err) => {
    //       this._loggerService.logException(err);
    //       this._spinner.hide();
    //     }
    //   );
    // }
  }

  private canContinue(status: StatusEnum) {
    this.validationErrors = [];

    if (status === StatusEnum.PendingReview)
      this.formValidate();

    if (this.validationErrors.length == 0)
      return true;

    return false;
  }

  public saveFundingApplication()
  {
    this.bidForm(StatusEnum.Saved);
  }
  
}

