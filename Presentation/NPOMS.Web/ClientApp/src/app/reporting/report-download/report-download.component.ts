import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { BehaviorSubject, Subscription } from 'rxjs';
import { FinancialMatters, IFinancialMattersIncome } from 'src/app/models/FinancialMatters';
import { ApplicationTypeEnum, DocumentUploadLocationsEnum, DropdownTypeEnum, FundingApplicationStepsEnum, NPOReportingStepsEnum, PermissionsEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationDetails, IApplicationPeriod, IDocumentType, 
  IFundingApplicationDetails, IMonitoringAndEvaluation, IObjective, IPlace,
  IProjectInformation, IResource, ISubPlace, ISustainabilityPlan, IUser,
  IFinancialYear,
  INpo,
  ISDA} from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { UserService } from 'src/app/services/api-services/user/user.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';

@Component({
  selector: 'app-report-download',
  templateUrl: './report-download.component.html',
  styleUrls: ['./report-download.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ReportDownloadComponent implements OnInit {

  dynamicHeaderText: string = '';
  postdynamicHeaderText: string = '';
  incomedynamicHeaderText: string = '';
  govnencedynamicHeaderText: string = '';
  otherdynamicHeaderText: string = '';
  indicatordynamicHeaderText: string = '';
  activeIndexes: number[] = [0, 1, 2, 3, 4, 5]; 
  
  public govnencedynamicHeaderText$ = new BehaviorSubject<string>(this.govnencedynamicHeaderText);
  public indicatordynamicHeaderText$ = new BehaviorSubject<string>(this.indicatordynamicHeaderText);
  public incomedynamicHeaderText$ = new BehaviorSubject<string>(this.incomedynamicHeaderText);
  public postdynamicHeaderText$ = new BehaviorSubject<string>(this.postdynamicHeaderText);
  public otherdynamicHeaderText$ = new BehaviorSubject<string>(this.otherdynamicHeaderText);
  public dynamicHeaderText$ = new BehaviorSubject<string>(this.dynamicHeaderText);

  selectedOptionId: number = 0;

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
  sdas:ISDA[] = [];
  selectedOption: ISDA;
  applicationPeriodId: number;
  paramSubcriptions: Subscription;
  id: string;
  sda: number;
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
  selectedApplication: IApplication;
  headerTitle: string;
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
    private _npoProfileRepo: NpoProfileService,
    private cdr: ChangeDetectorRef
  ) { }

  places(place: IPlace[]) {
    this.placeAll = place;
  }

  subPlaces(subPlaces: ISubPlace[]) {
    this.subPlacesAll = subPlaces;
  }

  ngOnInit(): void {
      this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      const quarterNumber = Number(params.get('qtr')) || 0; // Convert to number, default to 0 if invalid
      this.id = params.get('id');
      this.selectedOptionId = Number(params.get('sda')) || 0;
      this.toggleButton(quarterNumber);
      this.subscribeToHeaderTextChanges();
      this.loadApplication();
      this.loadDocumentTypes();
      this.loadFinancialYears();
    });

    var splitUrl = window.location.href.split('/');
    this.headerTitle = splitUrl[5];
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

    setTimeout(() => {
      document.title = "Indicator Report";
      window.print();
      this._router.navigate([{ outlets: { print: null } }]);
    }, 2500);
  }

  onRightHeaderChange(value: string,  headerType: string) {
    if (headerType === 'other') {
      this.otherdynamicHeaderText = value;
      this.otherdynamicHeaderText$.next(this.otherdynamicHeaderText);
    } else if (headerType === 'sdip') {
      this.dynamicHeaderText = value;
      this.dynamicHeaderText$.next(this.dynamicHeaderText);
    }
    else if (headerType === 'post') {
      this.postdynamicHeaderText = value;
      this.postdynamicHeaderText$.next(this.postdynamicHeaderText);
    }
    else if (headerType === 'income') {
      this.incomedynamicHeaderText = value;
      this.incomedynamicHeaderText$.next(this.incomedynamicHeaderText);
    }else if (headerType === 'govnence') {
      this.govnencedynamicHeaderText = value;
      this.govnencedynamicHeaderText$.next(this.govnencedynamicHeaderText);
    }else if (headerType === 'indicator') {
      console.log('indicator',value);
      this.indicatordynamicHeaderText = value;
      this.indicatordynamicHeaderText$.next(this.indicatordynamicHeaderText);
    }
    this.updateHeaderText();
    this.buildMenu();
  }

  private updateHeaderText() {
    this.govnencedynamicHeaderText$.next(this.govnencedynamicHeaderText);
    this.incomedynamicHeaderText$.next(this.incomedynamicHeaderText);
    this.postdynamicHeaderText$.next(this.postdynamicHeaderText);
    this.otherdynamicHeaderText$.next(this.otherdynamicHeaderText);
    this.dynamicHeaderText$.next(this.dynamicHeaderText);
    this.indicatordynamicHeaderText$.next(this.indicatordynamicHeaderText);
  }

  private subscribeToHeaderTextChanges() {
    this.govnencedynamicHeaderText$.subscribe(() => this.buildMenu());
    this.incomedynamicHeaderText$.subscribe(() => this.buildMenu());
    this.postdynamicHeaderText$.subscribe(() => this.buildMenu());
    this.otherdynamicHeaderText$.subscribe(() => this.buildMenu());
    this.dynamicHeaderText$.subscribe(() => this.buildMenu());
    this.indicatordynamicHeaderText$.subscribe(() => this.buildMenu());
  }

  private loadNpo() {
    this._npoRepo.getNpoById(this.application?.npoId).subscribe(
      (results) => {
        this.npo = results;
        this.MasterServiceDelivery()
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }


  
  private MasterServiceDelivery() {
    this. _npoProfileRepo.getProgrammeMasterDeliveryDetailsById(this.application.applicationPeriod.programmeId,this.application?.npoId).subscribe(
     (results) => {
       this.sdas = results;
       this.selectedOption = this.sdas.find(x => x.id === this.selectedOptionId);
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
          console.log('application',this.isApplicationAvailable);
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
      const areAllComplete = 
      this.govnencedynamicHeaderText === 'Completed' && 
      this.incomedynamicHeaderText === 'Completed' && 
      this.postdynamicHeaderText === 'Completed' && 
      this.otherdynamicHeaderText === 'Completed' && 
      this.dynamicHeaderText === 'Completed'&&
      this.indicatordynamicHeaderText === 'Completed';
      this.menuActions = [
        {
          label: 'Clear Messages',
          icon: 'fa fa-undo',
          command: () => {
            this.clearMessages();
          },
          visible: false
        },
        {
          label: 'Submit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.saveItems(StatusEnum.PendingReview);
          },
          disabled: !areAllComplete
        },
        {
          label: 'Go Back',
          icon: 'fa fa-step-backward',
          command: () => {
            this._router.navigateByUrl('applications');
          }
        }
      ];

      this.cdr.detectChanges();
    }
  }
  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[1].visible = false;
  }
  private saveItems(status: StatusEnum) {
    this._spinner.show();
    this._applicationRepo.submitReport(this.application).subscribe(
      (resp) => {
        this._spinner.hide();
        this._messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Information successfully saved.'
        });
        
        // Reload the page after a successful save
        window.location.reload();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
}

