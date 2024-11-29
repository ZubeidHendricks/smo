import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { BehaviorSubject, Subscription } from 'rxjs';
import { FinancialMatters, IFinancialMattersIncome } from 'src/app/models/FinancialMatters';
import { ApplicationTypeEnum, DocumentUploadLocationsEnum, DropdownTypeEnum, FundingApplicationStepsEnum, IQuestionResponseViewModel, IResponseHistory, IResponseOption, IResponseType, NPOReportingStepsEnum, PermissionsEnum, QuestionCategoryEnum, ResponseTypeEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationDetails, IApplicationPeriod, IDocumentType, 
  IFundingApplicationDetails, IMonitoringAndEvaluation, IObjective, IPlace,
  IProjectInformation, IResource, ISubPlace, ISustainabilityPlan, IUser,
  IFinancialYear,
  INpo,
  IProgrammeServiceDelivery,
  ISDA,
  IReportChecklist,
  IQuestionCategory,
  IStatus,
  ICapturedResponse,
  IResponse,
  IProgramme,
  ISubProgramme} from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { UserService } from 'src/app/services/api-services/user/user.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { EvaluationService } from 'src/app/services/evaluation/evaluation.service';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-npo-report-capture',
  templateUrl: './npo-report-capture.component.html',
  styleUrls: ['./npo-report-capture.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class NpoReportCaptureComponent implements OnInit {

  // dropdownOptions = [
  //   { label: 'Option 1', value: 1 },
  //   { label: 'Option 2', value: 2 },
  //   { label: 'Option 3', value: 3 }
  // ];
  selectedOption: ISDA;
  selectedOptionId: number = 0;
  targetGroup: string;
  dynamicHeaderText: string = '';
  postdynamicHeaderText: string = '';
  incomedynamicHeaderText: string = '';
  govnencedynamicHeaderText: string = '';
  otherdynamicHeaderText: string = '';
  indicatordynamicHeaderText: string = '';
  selectedYear: string | undefined;
  downloadEnabled: boolean = false;
  btnEnabled: boolean = false;
  isModalVisible: boolean = false;
  stateOptions: any[];
  objective: IObjective = {} as IObjective;
  displayObjectiveDialog: boolean;

  public govnencedynamicHeaderText$ = new BehaviorSubject<string>(this.govnencedynamicHeaderText);
  public indicatordynamicHeaderText$ = new BehaviorSubject<string>(this.indicatordynamicHeaderText);
  public incomedynamicHeaderText$ = new BehaviorSubject<string>(this.incomedynamicHeaderText);
  public postdynamicHeaderText$ = new BehaviorSubject<string>(this.postdynamicHeaderText);
  public otherdynamicHeaderText$ = new BehaviorSubject<string>(this.otherdynamicHeaderText);
  public dynamicHeaderText$ = new BehaviorSubject<string>(this.dynamicHeaderText);
  answers: { answer: string; comment: string; }[];

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

  capturedPreEvaluationComment: string;
  capturedEvaluationComment: string;
  capturedAdjudicationComment: string;
  capturedApprovalComment: string;
  preEvalSignedByUser: string;
  evalSignedByUser: string;
  adjSignedByUser: string;
  aprSignedByUser: string;
  preEvaluatedComment: string;
  signedByUser: string;

  evalVerificationDate: Date;
  adjVerificationDate: Date;
  aprVerificationDate: Date;
  verificationDate: Date;

  _recommendation: boolean = false;
  isChecked: boolean = false;
  isEvalDeclarationChecked: boolean = false;
  isAdjDeclarationChecked: boolean = false;
  isAprDeclarationChecked: boolean = false;
 

  allQuestionnaires: IQuestionResponseViewModel[];
  preEvaluationQuestionnaire: IQuestionResponseViewModel[];
  evaluationQuestionnaire: IQuestionResponseViewModel[];
  reportQuestionnaire: IQuestionResponseViewModel[];
  reportQuestionnaireBackup: IQuestionResponseViewModel[];
  
  adjudicationQuestionnaire: IQuestionResponseViewModel[];
  approveQuestionnaire: IQuestionResponseViewModel[];

  allCompletedQuestionnaires: IQuestionResponseViewModel[];
  completedPreEvaluationQuestionnaires: IQuestionResponseViewModel[];
  completedEvaluationQuestionnaires: IQuestionResponseViewModel[];
  completedAdjudicationQuestionnaires: IQuestionResponseViewModel[];

  QuestionCategoryentities: IQuestionCategory[];
  ResponseTypeentities: IResponseType[];

  statuses: IStatus[];
  evaluationStatuses: IStatus[];
  adjudicationStatuses: IStatus[];
  approvalStatuses: IStatus[];
  selectedStatus: IStatus;
  adjSelectedStatus: IStatus;
  aprSelectedStatus: IStatus;
  
  customText:string;
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
  isLoading: boolean = false;
  npo: INpo;
  sdas:ISDA[] = [];
  servicedeliveryAreas: ISDA[] = [];
  dropdownOptions: { label: string, value: number }[] = [];
  fundingApplicationDetails: IFundingApplicationDetails = {
    financialMatters: [],
    implementations: [],
    projectInformation: {} as IProjectInformation,
    monitoringEvaluation: {} as IMonitoringAndEvaluation,
    applicationDetails: {} as IApplicationDetails
  } as IFundingApplicationDetails;
  checklistCols: any[];
  yesNoOptions: { label: string, value: string }[];
  checklistData: { question: string, answer: string, comments: string }[];  
  displayChecklistDialog: boolean = false;

  reportChecklist: IReportChecklist = {
    requiresTPASubmission: false,
    verifiableReasonsProvided: false,
    reportedReportingPeriod: false,
    reportedServiceOutput: false,
    supportingDocuments: false,
    requiresTPASubmissionComments: '',
    verifiableReasonsProvidedComments: '',
    reportedReportingPeriodComments: '',
    reportedServiceOutputComments: '',
    supportingDocumentsComments: '',
    applicationId: 0,
    serviceDeliveryAreaId: 0,
    qaurterId: 0,
    isActive: true,
  } as IReportChecklist;

  private financialYearsSubject = new BehaviorSubject<IFinancialYear[]>([]);
  private financialYears$ = this.financialYearsSubject.asObservable();


  responseOptions: IResponseOption[];
  responseHistory: IResponseHistory[];
  displayHistoryDialog: boolean;
  historyCols: any[];

  allCapturedResponses: ICapturedResponse[];
  capturedResponses: ICapturedResponse[];
  capturedResponse = {} as ICapturedResponse;
  PreEvaluatedCapturedResponses: ICapturedResponse[];
  EvaluatedCapturedResponses: ICapturedResponse[];
  AdjudicationCapturedResponses: ICapturedResponse[];
  ApprovalCapturedResponses: ICapturedResponse[];
  isDataAvailable: boolean;
  totalAverageScore: number;

  hasCapturedPreEvaluation: boolean = false;  
  hasCapturedAdjudication: boolean = false;
  hasCapturedEvaluation: boolean = false;
  hasCapturedApproval: boolean = false;
  setDisable: boolean = true;
  isApprovalDisable: boolean = false;
  isAdjudicationDisable: boolean = false;
  isEvaluationDisable: boolean = false;
  isPreEvaluationDisable: boolean = false;
  setVisible: boolean = false;
  weightExceedingMessage: Message[] = [];
  zeroWeightingMessage: Message[] = [];

  allProgrammes: IProgramme[];
  programmes: IProgramme[] = [];
  selectedProgrammes: IProgramme[];
  allSubProgrammes: ISubProgramme[];
  subProgrammes: ISubProgramme[] = [];
  selectedSubProgrammes: ISubProgramme[];
  selectedProgrammesText: string;
  selectedSubProgrammesText: string;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _messageService: MessageService,
    private _dropdownRepo: DropdownService,
    private _loggerService: LoggerService,
    private _userRepo: UserService,
    private _npoRepo: NpoService,
    private _npoProfileRepo: NpoProfileService,
    private cdr: ChangeDetectorRef,
    private _dropdownService: DropdownService,
    private _evaluationService: EvaluationService,
    private _datepipe: DatePipe
  ) { }

  places(place: IPlace[]) {
    this.placeAll = place;
  }

  subPlaces(subPlaces: ISubPlace[]) {
    this.subPlacesAll = subPlaces;
  }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.subscribeToHeaderTextChanges();
      this.id = params.get('id');
      this.loadApplication();
      this.loadDocumentTypes();
      this.loadFinancialYears();
      this.getQuestionCategory();
      this.getResponseType();
      //this.loadQuestionnaire();
    });

    var splitUrl = window.location.href.split('/');
    this.headerTitle = splitUrl[5];

    // this.loadfundingSteps();
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

    this.checklistCols = [,
      { header: 'Reporting Checklist', width: '50%' },
      { header: 'Yes/No', width: '20%' },
      { header: 'Comments', width: '30%' }
    ];

    this.stateOptions = [
      {
        label: 'Yes',
        value: true
      },
      {
        label: 'No',
        value: false
      }
    ];

     // Yes/No options for dropdown
  this.yesNoOptions = [
    { label: 'Yes', value: 'Yes' },
    { label: 'No', value: 'No' }
  ];

 this.answers = [
    { answer: '', comment: '' }, // Question 1
    { answer: '', comment: '' }, // Question 2
    // Add more objects for additional questions
  ];
  

  // Table data
  this.checklistData = [
    { question: 'Did you complete the report?', answer: null, comments: '' },
    { question: 'Was the submission on time?', answer: null, comments: '' },
    { question: 'Are all sections reviewed?', answer: null, comments: '' }
  ];
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
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private MasterServiceDelivery() {
    this.isLoading = true;
    this._spinner.show();
     this. _npoProfileRepo.getProgrammeMasterDeliveryDetailsById(this.application.applicationPeriod.programmeId, this.application?.npoId).subscribe(
      (results) => {
        this.sdas = results;
        this.isLoading = false;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  
//   private MasterServiceDelivery() {
//     this._npoProfileRepo.getProgrammeMasterDeliveryDetailsById(
//         this.application.applicationPeriod.programmeId,
//         this.application?.npoId
//     ).subscribe(
//         (results) => {
//             this.sdas = results;
//             console.log('Service Delivery Areas:', this.sdas);

//             // Safely handle serviceDeliveryAreas to prevent errors
//             this.dropdownOptions = this.sdas
//                 .reduce((acc, psd) => {
//                     // Check if serviceDeliveryAreas is defined and is an array
//                     if (psd.serviceDeliveryAreas && Array.isArray(psd.serviceDeliveryAreas)) {
//                         const activeSDAs = psd.serviceDeliveryAreas
//                             .filter(sda => sda.isActive) // Only active service delivery areas
//                             .map(sda => ({
//                                 label: sda.name,        // Display name in dropdown
//                                 value: sda.id           // ID for the dropdown value
//                             }));
//                         acc.push(...activeSDAs);         // Add active entries to the accumulator
//                     }
//                     return acc;
//                 }, []);

//             console.log('Dropdown Options:', this.dropdownOptions);
//         },
//         (err) => {
//             this._loggerService.logException(err);
//             this._spinner.hide();
//         }
//     );
// }




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
  this.selectedYear = financialYear ? financialYear.name : undefined;;
  return financialYear ? financialYear.name : undefined;
}

toggleButton(buttonId: number) {
    this.activeButton = this.activeButton === buttonId ? null : buttonId;
    this.downloadEnabled = true;
}

getfinFund(event: FinancialMatters) {
}

  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
          this.MasterServiceDelivery();
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

  public hasComment(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return item.hasComment === true });
  }

  public hasDocument(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return item.hasDocument === true });
  }

  public getColspan(questionnaire: IQuestionResponseViewModel[], defaultColspan: number) {
    let colspan = defaultColspan;

    colspan = this.hasComment(questionnaire) ? colspan + 1 : colspan;
    colspan = this.hasDocument(questionnaire) ? colspan + 1 : colspan;

    return colspan;
  }

  public getQuestionCategory()
  {
    
    this._dropdownService.getEntities(DropdownTypeEnum.QuestionCategory, true).subscribe(
      (results) => {
        this.QuestionCategoryentities  = results;       
      },
    );
  }

  private getResponseType() {
    this._dropdownService.getEntities(DropdownTypeEnum.ResponseType, true).subscribe(
      (results) => {
        this.ResponseTypeentities = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide()
      }
    );
  }

 
//   onKeyUp(event: KeyboardEvent): void {
//     if(this.selectedOption?.id > 0){
//       this.btnEnabled = true;
//     }
//     else{
//       this.btnEnabled = false;
//     }
//     this.targetGroup = this.customText;
// }

  onDropdownChange(event: any) {
        this.btnEnabled = true;
 
  
    this.selectedOptionId = this.selectedOption.id;
  }

  onDownload(){
    this._router.navigate(
      [{ outlets: { print: ['print', this.application.id, this.selectedYear, this.activeButton,this.selectedOptionId, 5] } }]
    );
  }

  
  openModal() {
    this.loadQuestionnaireReport();
  }


  closeModal() {
    this.displayChecklistDialog = false;
  }

  disableSaveChecklist(): any {
     return false;
  }

  // saveChecklist() { 
  //   this.reportChecklist.applicationId = this.application.id;
  //   this.reportChecklist.serviceDeliveryAreaId = this.selectedOption.id;
  //   this.reportChecklist.qaurterId = this.activeButton;

  //   if(this.reportChecklist.id > 0)
  //   {
  //     this.updateChecklistReport()
  //   }
  //   else{
  //     this.saveChecklistData();
  //   }
  // }

  // private saveChecklistData() {
  //   this._spinner.show();
  //   this._applicationRepo.saveChecklistData(this.reportChecklist).subscribe(
  //     (resp) => {
  //       this._spinner.hide();
  //       this._messageService.add({
  //         severity: 'success',
  //         summary: 'Successful',
  //         detail: 'Information successfully saved.'
  //       });
  //       this.getReportChecklistByAppIdQtrId();
  //     },
  //     (err) => {
  //       this._loggerService.logException(err);
  //       this._spinner.hide();
  //     }
  //   );
  // }

  // private updateChecklistReport() {
  //   this._spinner.show();
  //   this._applicationRepo.updateChecklistData(this.reportChecklist).subscribe(
  //     (resp) => {
  //       this._spinner.hide();
  //       this._messageService.add({
  //         severity: 'success',
  //         summary: 'Successful',
  //         detail: 'Information successfully updated.'
  //       });
  //       this.getReportChecklistByAppIdQtrId();
  //     },
  //     (err) => {
  //       this._loggerService.logException(err);
  //       this._spinner.hide();
  //     }
  //   );
  // }

  // private getReportChecklistByAppIdQtrId() {
  //   this._spinner.show();
  //   this._applicationRepo.getReportChecklistByAppIdQtrId(this.application.id, this.activeButton).subscribe(
  //     (resp) => {
  //       if(resp?.id > 0)
  //       {
  //         this.reportChecklist.applicationId = resp.applicationId;
  //         this.reportChecklist.requiresTPASubmission = resp.requiresTPASubmission;
  //         this.reportChecklist.verifiableReasonsProvided = resp.verifiableReasonsProvided;
  //         this.reportChecklist.reportedReportingPeriod = resp.reportedReportingPeriod;
  //         this.reportChecklist.reportedServiceOutput = resp.reportedServiceOutput;
  //         this.reportChecklist.supportingDocuments = resp.supportingDocuments;
  //         this.reportChecklist.requiresTPASubmissionComments = resp.requiresTPASubmissionComments;
  //         this.reportChecklist.verifiableReasonsProvidedComments = resp.verifiableReasonsProvidedComments;
  //         this.reportChecklist.reportedReportingPeriodComments = resp.reportedReportingPeriodComments;
  //         this.reportChecklist.reportedServiceOutputComments = resp.reportedServiceOutputComments;
  //         this.reportChecklist.supportingDocumentsComments = resp.supportingDocumentsComments;
  //         this.reportChecklist.applicationId = resp.applicationId;
  //         this.reportChecklist.serviceDeliveryAreaId = resp.serviceDeliveryAreaId;
  //         this.reportChecklist.qaurterId = resp.qaurterId;
  //         this.reportChecklist.isActive = resp.isActive;
  //       }
  //       this.displayChecklistDialog = true;
  //       this._spinner.hide();
  //     },
  //     (err) => {
  //       this._loggerService.logException(err);
  //       this._spinner.hide();
  //     }
  //   );
  // }

  private loadQuestionnaireReport() {
    this._evaluationService.getQuestionnaireReport(Number(this.id), Number(this.activeButton)).subscribe(
      (results) => {
        this.allQuestionnaires = results;
        
        // this.preEvaluationQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "PreEvaluation");
        // this.evaluationQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Evaluation");
        // this.adjudicationQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Adjudication");
        // this.approveQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Approval");

        this.reportQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Application Report");

        this.loadResponseOptions();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadResponseOptions() {
    this._dropdownService.getEntities(DropdownTypeEnum.ResponseOption, true).subscribe(
      (results) => {
        this.responseOptions = results;
        this.loadStatuses();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadStatuses() {
    this._dropdownService.getEntities(DropdownTypeEnum.Statuses, true).subscribe(
      (results) => {
        this.statuses = results;
        this.evaluationStatuses = results.filter(x => x.name.includes('Recommended') || x.name.includes('NonCompliance') || x.name.includes('StronglyRecommended') || x.name.includes('Declined'));
        this.adjudicationStatuses = results.filter(x => x.name.includes('Declined') || x.name.includes('NonCompliance') || x.name.includes('Recommended') || x.name.includes('StronglyRecommended'));
        this.approvalStatuses = results.filter(x => x.name.includes('Declined') || x.name.includes('Recommended') || x.name.includes('StronglyRecommended'));
        this.loadCapturedResponses();
        this.isDataAvailable = true;
        this._spinner.hide();
        
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadCapturedResponses() {
    this._evaluationService.getCapturedResponses(this.application.id).subscribe(
      (results) => {
        this.capturedResponses = results;

        let preAdId = this.QuestionCategoryentities.filter(x=> x.name === "PreEvaluation");
        let evalId = this.QuestionCategoryentities.filter(x=> x.name === "Evaluation");
        let adjId = this.QuestionCategoryentities.filter(x=> x.name === "Adjudication");
        let appId = this.QuestionCategoryentities.filter(x=> x.name === "Approval");

        this.PreEvaluatedCapturedResponses = this.capturedResponses.filter(x => x.questionCategoryId === preAdId[0].id);
        this.EvaluatedCapturedResponses = this.capturedResponses.filter(x => x.questionCategoryId === evalId[0].id);
        this.AdjudicationCapturedResponses = this.capturedResponses.filter(x => x.questionCategoryId === adjId[0].id);
        this.ApprovalCapturedResponses = this.capturedResponses.filter(x => x.questionCategoryId === appId[0].id);

        this.hasCapturedPreEvaluation = this.getCapturedResponse(preAdId[0].id) ? true : false;
        this.hasCapturedEvaluation = this.getCapturedResponse(evalId[0].id) ? true : false;
        this.hasCapturedAdjudication = this.getCapturedResponse(adjId[0].id) ? true : false;
        this.hasCapturedApproval = this.getCapturedResponse(appId[0].id) ? true : false;

        if(this.capturePreEvaluation)
          this.capturedResponse = this.getCapturedResponse(preAdId[0].id);

        if (this.captureEvaluation() && this.hasCapturedEvaluation)
          this.capturedResponse = this.getCapturedResponse(evalId[0].id);

        if (this.captureAdjudication() && this.hasCapturedAdjudication)
          this.capturedResponse = this.getCapturedResponse(adjId[0].id);

        if (this.captureApproval() && this.hasCapturedApproval)
        this.capturedResponse = this.getCapturedResponse(appId[0].id);

        if (this.capturedResponse && this.capturedResponse.statusId)
          this.selectedStatus = this.statuses.find(x => x.id === this.capturedResponse.statusId);

          if(this.PreEvaluatedCapturedResponses.length > 0)
          {
            this.isPreEvaluationDisable = true
            this.capturedPreEvaluationComment = this.PreEvaluatedCapturedResponses[0].comments;
            this.isChecked = this.PreEvaluatedCapturedResponses[0].isSignedOff;
            this.signedByUser = this.PreEvaluatedCapturedResponses[0].createdUser.fullName;
            this.verificationDate = this.PreEvaluatedCapturedResponses[0].createdDateTime;
          }
  
          if(this.EvaluatedCapturedResponses.length > 0)
          {
            this.isEvaluationDisable = true;
            this.capturedEvaluationComment = this.EvaluatedCapturedResponses[0].comments;
            this.isEvalDeclarationChecked = this.EvaluatedCapturedResponses[0].isDeclarationAccepted;
 
            let num  = this.EvaluatedCapturedResponses[0].selectedStatus;
            switch (num) {
              case Number(StatusEnum.NonCompliance):
                this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.NonCompliance); 
                this.totalAverageScore = -1;
                this.updateEvaluationStatus(this.totalAverageScore);
                break;
              case Number(StatusEnum.Declined):
                this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.Declined);
                break;
              case Number(StatusEnum.Recommended):
                this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.Recommended);
                break;
              case Number(StatusEnum.StronglyRecommended):
                this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.StronglyRecommended);
                break;
            }
  
            this.evalSignedByUser = this.EvaluatedCapturedResponses[0].createdUser.fullName;
            this.evalVerificationDate = this.EvaluatedCapturedResponses[0].createdDateTime;
          }
          else{
            var pnlEvaluation = document.getElementById("pnlEvaluation");
            var pnlEvaluation1 = document.getElementById("pnlEvaluation1");
            pnlEvaluation.style.display = "none";
            pnlEvaluation1.style.display = "none";
          }
  
          if(this.AdjudicationCapturedResponses.length > 0)
          {
           
            this.isAdjudicationDisable = true;
            this.capturedAdjudicationComment = this.AdjudicationCapturedResponses[0].comments;
            this.isAdjDeclarationChecked = this.AdjudicationCapturedResponses[0].isDeclarationAccepted;          
            let num  = this.AdjudicationCapturedResponses[0].selectedStatus;
            switch (num) {
              case Number(StatusEnum.NonCompliance):
                this.adjSelectedStatus = this.adjudicationStatuses.find(x => x.id === StatusEnum.NonCompliance); 
                break;
              case Number(StatusEnum.Declined):
                this.adjSelectedStatus = this.adjudicationStatuses.find(x => x.id === StatusEnum.Declined);
                break;
              case Number(StatusEnum.Recommended):
                this.adjSelectedStatus = this.adjudicationStatuses.find(x => x.id === StatusEnum.Recommended);
                break;
              case Number(StatusEnum.StronglyRecommended):
                this.adjSelectedStatus = this.adjudicationStatuses.find(x => x.id === StatusEnum.StronglyRecommended);
                break;
            }
           
            this.adjSignedByUser = this.AdjudicationCapturedResponses[0].createdUser.fullName;
            this.adjVerificationDate = this.AdjudicationCapturedResponses[0].createdDateTime;
            
            // if (this.isAdjDeclarationChecked) {
            //   var pnlAdjudication = document.getElementById("pnlAdjudication");
            //   pnlAdjudication.style.display = "block";
            // }
            // else{
            //   pnlAdjudication.style.display = "none";
            // }
          }
          else{
              // var pnlAdjudication = document.getElementById("pnlAdjudication");
              // pnlAdjudication.style.display = "none";
          }

          if(this.ApprovalCapturedResponses.length > 0)
          {
            this.isApprovalDisable = true;
            this.capturedApprovalComment = this.ApprovalCapturedResponses[0].comments;
            this.isAprDeclarationChecked = this.ApprovalCapturedResponses[0].isDeclarationAccepted;
            let num  = this.ApprovalCapturedResponses[0].selectedStatus;
            switch (num) {
              case Number(StatusEnum.Declined):
                this.aprSelectedStatus = this.approvalStatuses.find(x => x.id === StatusEnum.Declined);
                break;
              case Number(StatusEnum.Recommended):
                this.aprSelectedStatus = this.approvalStatuses.find(x => x.id === StatusEnum.Recommended);
                break;
              case Number(StatusEnum.StronglyRecommended):
                this.aprSelectedStatus = this.approvalStatuses.find(x => x.id === StatusEnum.StronglyRecommended);
                break;
            }
            this.aprSignedByUser = this.ApprovalCapturedResponses[0].createdUser.fullName;
            this.aprVerificationDate = this.ApprovalCapturedResponses[0].createdDateTime;
  
            // if (this.isAprDeclarationChecked) {
            //   var pnlApproval = document.getElementById("pnlApproval");
            //   pnlApproval.style.display = "block";
            // }
            // else{
            //   pnlApproval.style.display = "none";
            // }
          }
          else{
            // var pnlApproval = document.getElementById("pnlApproval");
            // pnlApproval.style.display = "none";
          }

        this.capturedResponses.forEach(capturedResponse => {
          this._evaluationService.getCompletedQuestionnaires(capturedResponse.fundingApplicationId, capturedResponse.questionCategoryId, capturedResponse.createdUser.id).subscribe(
            (results) => {
              capturedResponse.questionnaires = results;

             
              this.updateRowGroupMetaData(capturedResponse.questionnaires);

              // Check if capturedResponse is last object in capturedResponses array
              if (this.capturedResponses.indexOf(capturedResponse) === this.capturedResponses.length - 1)
                this.allCapturedResponses = this.capturedResponses;
                      
             this.displayChecklistDialog = true;
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        });

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  

  public getCompletedQuestionnaire(capturedResponse: ICapturedResponse) {
    var questionnaires = this.capturedResponses.find(x => x.id === capturedResponse.id).questionnaires;
    this.updateRowGroupMetaData(questionnaires);
    return questionnaires;
  }

  public captureAdjudication() {
    switch (this.application.statusId) {
      case StatusEnum.Evaluated:
      case StatusEnum.AdjudicationInProgress: {
        return true;
      }
    }

    return false;
  }

  public captureApproval() {
    switch (this.application.statusId) {
      case StatusEnum.Adjudicated:{
        return true;
      }
    }

    return false;
  }

  public captureEvaluation() {
    switch (this.application?.statusId) {
        case StatusEnum.Verified:
        case StatusEnum.Evaluated:
        case StatusEnum.Adjudicated: 
        case StatusEnum.Approved:
        case StatusEnum.Declined: 
        case StatusEnum.NonCompliance: 
      {
        return true;
      }
    }

    return false;
  }

  public captureAdjudicate() {
    switch (this.application.statusId) {
        case StatusEnum.Evaluated:
        case StatusEnum.Adjudicated: 
        case StatusEnum.Approved:
        case StatusEnum.Declined: 
        case StatusEnum.NonCompliance: 
      {
        return true;
      }
    }

    return false;
  }

  public captureApprove() {
    switch (this.application.statusId) {
      case StatusEnum.Adjudicated:
      case StatusEnum.Approved:
      case StatusEnum.Declined:
      {
        return true;
      }
    }

    return false;
  }


  public displayPreEvaluate() {
    switch (this.application.statusId) {
      case StatusEnum.PendingReview:
      case StatusEnum.Verified:
      case StatusEnum.Evaluated:
      case StatusEnum.Adjudicated:
      case StatusEnum.Approved: 
      case StatusEnum.Declined: 
      case StatusEnum.NonCompliance: 
      {
        return true;
      }
    }

    return false;
  }

  public displayEvaluation() {
    switch (this.application.statusId) {
      case StatusEnum.Verified:
        case StatusEnum.Evaluated:
        case StatusEnum.Adjudicated:
        case StatusEnum.Approved:
        case StatusEnum.Declined:
        case StatusEnum.NonCompliance:
      {
        return true;
      }
    }

    return false;
  }

  public displayAdjudicate() {
    switch (this.application.statusId) {
      case StatusEnum.Evaluated:
      case StatusEnum.Adjudicated:
      case StatusEnum.Approved:
      case StatusEnum.Declined:
      case StatusEnum.NonCompliance:
      {
        return true;
      }
    }

    return false;
  }

  public displayApprove() {
    if(this.application.step === 2)
    {
      switch (this.application.statusId) {
        case StatusEnum.Adjudicated:
        case StatusEnum.Approved:
        case StatusEnum.Declined:
        {
          return true;
        }
      }
      return false;
    }
   
  }
  
  public capturePreEvaluation() {
    switch (this.application.statusId) {
        case StatusEnum.PendingReview:
        case StatusEnum.Verified:
        case StatusEnum.Evaluated:
        case StatusEnum.Adjudicated: 
        case StatusEnum.Approved:
        case StatusEnum.Declined: 
        case StatusEnum.NonCompliance: 
     {
        return true;
      }
    }

    return false;
  }

  private getCapturedResponse(questionCategoryId: QuestionCategoryEnum) {
    return this.capturedResponses.find(x => x.fundingApplicationId === this.application.id && x.questionCategoryId === questionCategoryId);
  }

  public getResponseOptions(responseTypeId: number) {
    return this.responseOptions?.filter(x => x.responseTypeId === responseTypeId && x.isActive);
  }
 public updateRowGroupMetaData(questionnaire: IQuestionResponseViewModel[]) {
    let rowGroupMetadata = {};
    if (questionnaire) {
      for (let i = 0; i < questionnaire.length; i++) {
        let rowData = questionnaire[i];
        let questionSectionName = rowData.questionSectionName;
        if (i == 0) {
          rowGroupMetadata[questionSectionName] = { index: 0, size: 1 };
        }
        else {
          let previousRowData = questionnaire[i - 1];
          let previousRowGroup = previousRowData.questionSectionName;
          if (questionSectionName === previousRowGroup)
            rowGroupMetadata[questionSectionName].size++;
          else
            rowGroupMetadata[questionSectionName] = { index: i, size: 1 };
        }
      }
    }

    return rowGroupMetadata;
  }

  


  public displayErrorMessages(questionnaire: IQuestionResponseViewModel[]) {
    let hasErrors: boolean[] = [];

    if (this.getWeightingTotal(questionnaire) > 100)
      hasErrors.push(true);

    if (this.hasZeroWeighting(questionnaire))
      hasErrors.push(true);

    return hasErrors.includes(true) ? true : false;
  }

  public getWeightingTotal(questionnaire: IQuestionResponseViewModel[]) {
    let totalWeighting = 0;

    questionnaire.forEach(item => {
      totalWeighting += item.weighting;
    });

    if (totalWeighting > 100)
      this.weightExceedingMessage.push({ severity: 'warn', summary: "Warning:", detail: "Total weight exceeding 100. Please contact DEDAT administrator team to rectify the weightings." });

    return totalWeighting;
  }

  public hasZeroWeighting(questionnaire: IQuestionResponseViewModel[]) {
    let zeroWeightingQuestions: boolean[] = [];

    questionnaire.forEach(question => {
      switch (question.responseTypeId) {
        case ResponseTypeEnum.Score:
          question.weighting === 0 ? zeroWeightingQuestions.push(true) : zeroWeightingQuestions.push(false);
          break;
      }
    });

    if (zeroWeightingQuestions.includes(true))
      this.zeroWeightingMessage.push({ severity: 'warn', summary: "Warning:", detail: "Weight cannot be 0. Please contact administrator team to rectify the weightings." });

    return zeroWeightingQuestions.includes(true) ? true : false;
  }

  public hasWeighting(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return item.responseTypeId === ResponseTypeEnum.Score });
  }

  public onSaveResponse(event, question: IQuestionResponseViewModel) {
    question.responseOptionId = event.value.id;
    this.onSave(question);
    if(question.questionCategoryName === 'Evaluation' && question.responseOption.name === 'Yes')
    {

    }
    //if question is yes
    //find question to update in list of questions
    //update the response for found question
  }

  public onSaveComment(event, question: IQuestionResponseViewModel) {
    question.isSaved = false;
    this.onSave(question);
  }

  public getAverageScoreTotal(questionnaire: IQuestionResponseViewModel[]) 
  {
    questionnaire.forEach(item => {
      if(Number(item.responseOption.name) >= 0)
      {
       
        this.totalAverageScore += Number(item.responseOption.name);
      }
      else{
        this.totalAverageScore = 0;
      }
    });
    if (questionnaire[0].questionCategoryId === QuestionCategoryEnum.Evaluation)
    this.updateEvaluationStatus(this.totalAverageScore);

    return this.totalAverageScore;
 }

  private updateEvaluationStatus(totalAverageScore: number) {

      if(totalAverageScore >= 40)
      {
        this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.StronglyRecommended);
      }
      else if(totalAverageScore >= 30 && totalAverageScore <= 39)
      {
        this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.Recommended);
      }
      else if(totalAverageScore >= 1 && totalAverageScore <= 29)
      {
        this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.Declined);
      }
      else{
        this.selectedStatus = this.evaluationStatuses.find(x => x.id === StatusEnum.NonCompliance);
      }   
  }
  
  public onInputCommentChange(question: IQuestionResponseViewModel) {
    question.isSaved = false;
  }

  public onSave(question: IQuestionResponseViewModel) {
    if (question.responseOptionId != 0) {
    
      let response = {} as IResponse;
      response.fundingApplicationId = this.application.id;
      response.questionId = question.questionId;
      response.responseOptionId = question.responseOptionId;
      response.qaurterId = this.activeButton;
      response.comment = question.comment == null ? "" : question.comment;

      this._evaluationService.updateResponse(response).subscribe(
        (results) => {
          let returnValue = results as IQuestionResponseViewModel;
          question.responseId = returnValue.responseId;
          question.isSaved = returnValue.isSaved;
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }

      );

      if(question.questionCategoryName === 'Evaluation' && question.responseOption.name === 'No')
      {
        let text = "Application noncompliant?";
        if (confirm(text) == true)
        {
          this.totalAverageScore = -1;
          this.updateEvaluationStatus(this.totalAverageScore);
          this.createCapturedResponseNonCompliance();
        } 
        else
        {
          return false;
        }         
      }
     
    }
  }


  public submit(questionnaire: IQuestionResponseViewModel[], questionCategory: string) {
    // if (this.canContinue(questionnaire)) {
    //   this._spinner.show();
    //   this.createCapturedResponse(questionCategory);
    // }
    
    this.createCapturedResponse(questionCategory);
  }

  private createCapturedResponse(questionCategoryId: string) {
   
    let id = this.QuestionCategoryentities.filter(x=> x.name === questionCategoryId);
    let status: number;
    let declaration: boolean;
    let comment: string;
    let selectedStatus: number;
    switch (questionCategoryId.toString()) {
      case "PreEvaluation": {       
        status = 14;
        comment = this.capturedPreEvaluationComment
        break;
      }
      case "Evaluation": {
        if( this.selectedStatus.id === 6)
        {
          status = 6;
        }
        else{
          status = 15;
        }       
        declaration = true;
        comment = this.capturedEvaluationComment
        selectedStatus = this.selectedStatus.id
         break;
      }
      case "Adjudication": {
        if( this.adjSelectedStatus.id === 6)
        {
          status = 6;
        }
        else{
          status = 18;
        }  
        declaration = true;
        comment = this.capturedAdjudicationComment
        selectedStatus = this.adjSelectedStatus.id
        break;
      }
      case "Approval": {
        if( this.selectedStatus.id === 6)
        {
          status = 6;
        }
        else{
          status = 13;
        }  
        declaration = true;
        comment = this.capturedApprovalComment
        selectedStatus = this.aprSelectedStatus.id
        break;
      }
    }
    
    let capturedResponse = {
      fundingApplicationId: this.application.id,     
      statusId: status,
      questionCategoryId: id[0].id,
      comments: comment,
      isActive: true,
      isSignedOff: this.isChecked ? true : false,
      isDeclarationAccepted: true,
      selectedStatus: selectedStatus
    } as ICapturedResponse;
   
    this._evaluationService.createCapturedResponse(capturedResponse).subscribe(
      (results) => {
        this._spinner.hide();
        this._router.navigateByUrl('applications');
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private createCapturedResponseNonCompliance() {
        let id = this.QuestionCategoryentities.filter(x=> x.name === 'Evaluation');
        let capturedResponse = {
          fundingApplicationId: this.application.id,     
          statusId: 22,
          questionCategoryId: id[0].id,  
          comments: 'Non Compliance',
          isActive: true,
          isSignedOff: this.isChecked ? true : false,
          isDeclarationAccepted: true,
          selectedStatus: 22 // No Compliance
        } as ICapturedResponse;
       
        this._evaluationService.createCapturedResponse(capturedResponse).subscribe(
          (results) => {
            this._spinner.hide();
            this._router.navigateByUrl('applications');
          },
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
          }
        );
      }


  public onSelectViewHistory(question: IQuestionResponseViewModel) {
    this._spinner.show();
    this.responseHistory = [];

    this._evaluationService.getResponseHistory(this.application.id, question.questionId).subscribe(
      (results) => {
        this.responseHistory = results;
        this.displayHistoryDialog = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public onCapturedResponseViewHistory(question: IQuestionResponseViewModel) {
    this._spinner.show();
    this.responseHistory = [];

    this._evaluationService.getCapturedResponseHistory(this.application.id, question.questionId, question.createdUserId).subscribe(
      (results) => {
        this.responseHistory = results;
        this.displayHistoryDialog = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  public getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];
    }

    if (col.field == 'createdDateTime')
      value = this._datepipe.transform(value, 'yyyy-MM-dd HH:mm:ss');

    return value;
  }

  public getStatus(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {
    let status = '';
    let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    let countReviewed = questions.filter(x => x.isSaved === true).length;

    // If true, document is required but no documents were uploaded... 
    // var documentRequired = questions.some(function (question) { return question.documentRequired === true && question.documentCount === 0 });
    var documentRequired = false;

    if (questions.length === countReviewed && !documentRequired)
      status = 'complete';
    else if (questions.length === countReviewed && documentRequired)
      status = 'partially-complete';
    else if (questions.length !== countReviewed)
      status = 'pending';

    return status;
  }

  editObjective(data: IObjective) {
    this.objective = this.cloneObjective(data);
    this.displayObjectiveDialog = true;
  }

  private cloneObjective(data: IObjective): IObjective {
    let obj = {} as IObjective;

    for (let prop in data)
      obj[prop] = data[prop];

    const programmeIds = data.objectiveProgrammes.map(({ programmeId }) => programmeId);
    this.selectedProgrammes = this.programmes.filter(item => programmeIds.includes(item.id));
    this.programmeChange(this.selectedProgrammes);

    const subProgrammeIds = data.objectiveProgrammes.map(({ subProgrammeId }) => subProgrammeId);
    this.selectedSubProgrammes = this.subProgrammes.filter(item => subProgrammeIds.includes(item.id));

    //this.getTextValues(ServiceProvisionStepsEnum.Objectives);

    return obj;
  }

  // private getTextValues(serviceProvisionStepId: ServiceProvisionStepsEnum) {
  //   if (serviceProvisionStepId === ServiceProvisionStepsEnum.Objectives) {
  //     let allProgrammes: string = "";

  //     this.selectedProgrammes.forEach(item => {
  //       allProgrammes += item.name + ";\n";
  //     });

  //     this.selectedProgrammesText = allProgrammes;
  //   }

  //   if (serviceProvisionStepId === ServiceProvisionStepsEnum.Activities) {
  //     let allFacilities: string = "";

  //     this.selectedFacilities.forEach(item => {
  //       allFacilities += item.name + ";\n";
  //     });

  //     this.selectedFacilitiesText = allFacilities;
  //   }

  //   let allSubProgrammes: string = "";

  //   this.selectedSubProgrammes.forEach(item => {
  //     allSubProgrammes += item.name + ";\n";
  //   });

  //   this.selectedSubProgrammesText = allSubProgrammes;
  // }

  programmeChange(programmes: IProgramme[]) {
    this.subProgrammes = [];

    programmes.forEach(item => {
      if (item.id != null) {
        for (var i = 0; i < this.allSubProgrammes.length; i++) {
          if (this.allSubProgrammes[i].programmeId == item.id) {
            this.subProgrammes.push(this.allSubProgrammes[i]);
          }
        }
      }
    });
  }

  public disableElement(questionnaire: IQuestionResponseViewModel[], questionCategory: string) {
    let canCaptureQuestionnaire = false;
    switch (questionCategory) {
      case 'PreEvaluation':
        canCaptureQuestionnaire = this.capturePreEvaluation();
        break;
      case 'Evaluation':
        canCaptureQuestionnaire = this.captureEvaluation();
        break;
      case 'Adjudication':
        canCaptureQuestionnaire = this.captureAdjudication();
        break; 
      case 'Approval':
        canCaptureQuestionnaire = this.captureApproval();
        break;    
    }
    if (questionnaire) {

      let questions = questionnaire;
      let countReviewed = questions.filter(x => x.isSaved === true).length;
      let commentRequired = questions.filter(x => x.commentRequired === true).length;
      let commentProvided = questions.filter(x => x.comment !== '').length;
      return ((questions.length === countReviewed) && (commentProvided >= commentRequired) && ( this._recommendation == true) && (this.capturedPreEvaluationComment !== '')) ? false : true;      
    }
    else
      return true;
  }

  public disableEvaluateElement(questionnaire: IQuestionResponseViewModel[]) {
    let canCaptureQuestionnaire = false;
    canCaptureQuestionnaire = this.captureEvaluation();
    let questions = questionnaire;
    let countReviewed = questions.filter(x => x.isSaved === true).length;
    let commentRequired = questions.filter(x => x.commentRequired === true).length;
    let commentProvided = questions.filter(x => x.comment !== '').length;

    return ((questions.length === countReviewed) && (commentProvided >= commentRequired) && (this.capturedEvaluationComment !== '')) ? false : true;      
   // return ((questions.length === countReviewed) && (commentRequired === commentProvided)) ? false : true;  
  }

  public displayField(question: IQuestionResponseViewModel) {
    let canDisplayField: boolean;
    switch (question.responseTypeId) {
      case ResponseTypeEnum.CloseEnded:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.Score:
        canDisplayField = true; //question.weighting !== 0 ? true : false;
        break;
      case ResponseTypeEnum.CloseEnded2:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.CloseEnded3:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.CloseEnded4:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.Score2:
        canDisplayField = true;
        break;
    }

    return canDisplayField;
  }

  onCheckboxChange(event: any) {
    this.isChecked = event.target.checked;
    if (this.isChecked == true) {
      this._recommendation = true;
    } else {
      this._recommendation = false;
    }
  }

  onDeclarationCheckboxChange(event: any) {
    this.isEvalDeclarationChecked = event.target.checked;
    if (this.isEvalDeclarationChecked) {
      this._recommendation = true;
      this.setVisible = true;
    } else {
      this._recommendation = false;
      this.setVisible = false;
    }
  }
 
  onEvlCheckboxChange(event: any) {    
    var pnlEvaluation = document.getElementById("pnlEvaluation");
    var pnlEvaluation1 = document.getElementById("pnlEvaluation1");
    this.isEvalDeclarationChecked = event == false ? event : event.target.checked;
    if (this.isEvalDeclarationChecked == true) {
      pnlEvaluation.style.display = "block";
      pnlEvaluation1.style.display = "block";
    } else {
      pnlEvaluation.style.display = "none";
      pnlEvaluation1.style.display = "none";
  }
}
//

onAdjCheckboxChange(event: any) {
  var pnlAdjudication = document.getElementById("pnlAdjudication");
  this.isAdjDeclarationChecked = event.target.checked;
  if (this.isAdjDeclarationChecked) {
    pnlAdjudication.style.display = "block";
  } else {
    pnlAdjudication.style.display = "none";
}
}

onAprCheckboxChange(event: any) { 

  var pnlApproval = document.getElementById("pnlApproval");
  this.isAprDeclarationChecked = event.target.checked;
  if (this.isAprDeclarationChecked) {
    pnlApproval.style.display = "block";
  } else {
    pnlApproval.style.display = "none";
}
}


public getStatusText(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {
  let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
  let countReviewed = questions.filter(x => x.isSaved === true).length;
  return `${countReviewed} of ${questions.length} answered`;
}

public getRagColour(question: IQuestionResponseViewModel) {
  let ragColour = 'rag-not-saved';

  if (question.isSaved && question.commentRequired === false)
    ragColour = 'rag-saved';

  if (question.isSaved && question.commentRequired === true) {
    if (question.comment === '')
    {
      ragColour = 'rag-partial';
      this._recommendation = false;
    }
    else
    {
      ragColour = 'rag-saved';       
    }
  }
  // else if (!question.isSaved)
  //   ragColour = 'rag-not-saved';

  return ragColour;
}

}

