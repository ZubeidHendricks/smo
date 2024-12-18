import { DatePipe } from '@angular/common';
import { ChangeDetectorRef, Component, ElementRef, EventEmitter, Input, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { DepartmentEnum, DocumentUploadLocationsEnum, DropdownTypeEnum, EntityEnum, EntityTypeEnum, FacilityTypeEnum, PermissionsEnum, RecipientEntityEnum, RoleEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IActivityDistrict, IActivityFacilityList, IActivityList, IActivityManicipality, IActivityRecipient, IActivitySubDistrict, IActivitySubProgramme, IActivitySubStructure, IActivityType, IActuals, IActualsAudit, IApplication, IApplicationComment, IApplicationPeriod, IApplicationReviewerSatisfaction, IApplicationType, IBaseCompleteViewModel, IDepartment, IDistrictDemographic, IDocumentType, IFacilityDistrict, IFacilityList, IFacilitySubDistrict, IFacilitySubStructure, IFinancialYear, IFrequencyPeriod, IIndicator, IManicipalityDemographic, IndicatorReport, INpo, INPOIndicator, IObjective, IProgramme, IQuarterlyPeriod, IRecipientType, IStatus, ISubDistrictDemographic, ISubProgramme, ISubProgrammeType, ISubstructureDemographic, IUser, IVerifiedActuals, IWorkplanIndicator } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { FilterService } from 'primeng/api';
import { Router } from '@angular/router';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { HttpEventType } from '@angular/common/http';
import { group } from 'console';
import { BehaviorSubject, Observable } from 'rxjs';
import { finalize, tap } from 'rxjs/operators';

@Component({
  selector: 'app-indicator-report',
  templateUrl: './indicator-report.component.html',
  styleUrls: ['./indicator-report.component.css'],
  providers: [FilterService]
})

export class IndicatorReportComponent implements OnInit {
cancelVerifiedActual() {
  this.displayVerifyActualDialog = false;
}
  @Input() selectedQuarter!: number;
  @Input() selectedsda!: number;
 @Input() selectedGroup!: string;

  displayVerifyActualDialog: boolean;
  displayVieHistoryDialog: boolean;
  @Output() rightHeaderIndicatorChange = new EventEmitter<string>();
  verifyCols:any[];
  addOtherfield: boolean = true;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['selectedQuarter'] && changes['selectedQuarter'].currentValue) {
        const quarter = changes['selectedQuarter'].currentValue;
        this.quarterId = quarter;
        this.filterDataByQuarter(quarter);
    }

    if (changes['selectedsda'] && changes['selectedsda'].currentValue) {
      const selectedsda = changes['selectedsda'].currentValue;
      this.serviceDeliveryAreaId = selectedsda;
  }
  
  if (changes['selectedGroup'] && changes['selectedGroup'].currentValue) {
    const selectedGroup = changes['selectedGroup'].currentValue;
    this.group = selectedGroup;    
  }
}

filterDataByQuarter(quarter: number) {
  this.loadNpo();
}

  applicationPeriod: IApplicationPeriod = {} as IApplicationPeriod;
  auditCols: any[];
  menuActions: MenuItem[];
  profile: IUser;
  validationErrors: Message[];
  filteredProgrammes: IProgramme[] = [];
  //financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;
  departments: IDepartment[];
  selectedDepartment: IDepartment;
  allProgrammes: IProgramme[];
  allOrganisations: INpo[];
  programmes: IProgramme[] = [];
  selectedProgramme: IProgramme;
  allSubProgrammes: ISubProgramme[];  
  subProgrammes: ISubProgramme[] = [];
  selectedSubProgramme: ISubProgramme; 
  AllsubProgrammesTypes: ISubProgrammeType[];
  subProgrammesTypes: ISubProgrammeType[] = [];
  selectedSubProgrammeType: ISubProgrammeType;
  selectedApplicationType: IApplicationType; 
  applicationTypes: IApplicationType[];
  filteredSubProgrammeType: ISubProgrammeType[];
  openingMinDate: Date;
  closingMinDate: Date;
  disableClosingDate: boolean = true;
  disableOpeningDate: boolean = true;
  finYearRange: string;
  filteredSubProgrammes: ISubProgramme[] = []; 
  filteredSubProgrammeTypes: ISubProgrammeType[] = [];
  subProgrammeTypes: ISubProgrammeType[];
  departments1: IDepartment[];
  // Highlight required fields on validate click
  validated: boolean = false;
  isSystemAdmin: boolean;
  isDepartmentAdmin: boolean;
  selectedDepartmentSummary: IDepartment;
  selectedQuartersText: string = '';
  indicators: IIndicator[];
  iNPOIndicators: INPOIndicator[] = [];
  actuals: IActuals[] = [];
  verifiedActuals: IVerifiedActuals[] = []; 
  verifiedActual: IVerifiedActuals =  {} as IVerifiedActuals; 
  actual: IActuals = {} as IActuals;
  seletedAactuals: IActuals;
  @ViewChild('addDoc') element: ElementRef;
  displayUploadedFilesDialog: boolean;
  documentCols: any[];
  newActual: boolean;
  yearSelected: boolean = false;
  qselected: boolean = false;
  selectedSubStructures: any[] = [];
  mergedList: any[] = [];
  merged: any = null;
  npoName: string;
  quarterId: number;
  sdaId: number;
  targetGroup:string
  serviceDeliveryAreaId: number;
  group: string;
  public get RoleEnum(): typeof RoleEnum {
    return RoleEnum;
  }

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Output() activityChange: EventEmitter<IActivity> = new EventEmitter<IActivity>();
  @Input() canAddComments: boolean;
  @Input() isReview: boolean;
  private _financialYears: IFinancialYear[];
  @Input()
  get financialYears(): IFinancialYear[] { return this._financialYears; }
  set financialYears(financialYears: IFinancialYear[]) { this._financialYears = financialYears; }
  allActivities: IActivity[];
  activeActivities: IActivity[];
  deletedActivities: IActivity[];
  indicatorCols: any[];
  actualCols: any[];
  displayActualDialog: boolean;
  newActivity: boolean;
  newIndicatorReport: boolean;
  activity: IActivity = {} as IActivity;
  objectives: IObjective[];
  selectedObjective: IObjective;
  activityTypes: IActivityType[];
  selectedActivityType: IActivityType;
  yearRange: string;
  rowGroupMetadata: any[];
  deletedRowGroupMetadata: any[];
  facilities: IFacilityList[];
  facilitiesList: IFacilityList[];
  selectedFacilities: IFacilityList[];
  filteredFacilities: IFacilityList[] = [];
  selectedFacilitiesText: string;
  selectedSubProgrammes: ISubProgramme[];
  canEdit: boolean;
  selectedSubProgrammesText: string;
  displayAllCommentDialog: boolean;
  displayCommentDialog: boolean;
  comment: string;
  commentCols: any;
  cols: any[];
  applicationComments: IApplicationComment[] = [];
  tooltip: string;
  activityList: IActivityList[];
  selectedActivity: IActivityList;
  maxChars = 50;
  showReviewerSatisfaction: boolean;
  applicationReviewerSatisfaction: IApplicationReviewerSatisfaction[] = [];
  displayReviewerSatisfactionDialog: boolean;
  reviewerSatisfactionCols: any;
  displayDeletedActivityDialog: boolean;
  npo: INpo;
  recipientTypes: IRecipientType[];
  recipients: IActivityRecipient[];
  selectedRecipients: IActivityRecipient[] = [];
  selectedRecipientsText: string;
  facilityDistricts: IFacilityDistrict[];
  selectedDistricts: IFacilityDistrict;
  allFacilitySubDistricts: IFacilitySubDistrict[];
  facilitySubDistricts: IFacilitySubDistrict[];
  selectedSubDistricts: IFacilitySubDistrict[];
  allFacilitySubStructures: IFacilitySubStructure[];
  facilitySubStructures: IFacilitySubStructure[];
  selectedFacilitySubStructures: IFacilitySubStructure;
  allIDistrictDemographics: IDistrictDemographic[];
  selectedIDistrictDemographics: IDistrictDemographic;
  allSubDistrictDemographics: ISubDistrictDemographic[];
  SubDistrictDemographics: ISubDistrictDemographic[];
  selectedSubDistrictDemographics: ISubDistrictDemographic[];
  allSubstructureDemographics: ISubstructureDemographic[];
  SubstructureDemographics: ISubstructureDemographic[];
  selectedSubstructureDemographics: ISubstructureDemographic[];
  allManicipalityDemographics: IManicipalityDemographic[];
  ManicipalityDemographics: IManicipalityDemographic[];
  selectedManicipalityDemographics: IManicipalityDemographic[];
  filteredActivities: any[] = [];
  filteredData: any[] = [];
  applications: IApplication[];
  selectedFrequencyPeriod: IFrequencyPeriod;
  selectedOutputTitle:any={};
  workplanIndicators: IWorkplanIndicator[];
  buttonItems: MenuItem[];
  selectedActual: IActuals = {} as IActuals;
  documentTypes: IDocumentType[] = [];
  quartelyPeriods: IQuarterlyPeriod[];
  private financialYearsSubject = new BehaviorSubject<IFinancialYear[]>([]);
  private financialYears$ = this.financialYearsSubject.asObservable();
  baseCompleteViewModel: IBaseCompleteViewModel = {} as IBaseCompleteViewModel;

  public get FacilityTypeEnum(): typeof FacilityTypeEnum {
    return FacilityTypeEnum;
  }

  quarters = [
    { name: 'Q1 2024',  id: '1' },
    { name: 'Q2 2024', id: '2' },
    { name: 'Q3 2024', id: '3' },
    { name: 'Q4 2024', id: '4' }
  ];

  selectedQuarters = [];
  
  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  constructor(
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private _applicationRepo: ApplicationService,
    private _datepipe: DatePipe,
    private _loggerService: LoggerService,
    private _npoRepo: NpoService,
    private filterService: FilterService,
    private _router: Router,
    private _authService: AuthService,
    private _applicationPeriodRepo: ApplicationPeriodService,
    private _documentStore: DocumentStoreService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;
        this._spinner.show();
        this.loadDocumentTypes();
        this.registerCustomFilters();
        this.loadFinancialYears();
        this.canEdit = (this.application.statusId === StatusEnum.PendingReview ||
          this.application.statusId === StatusEnum.PendingApproval ||
          this.application.statusId === StatusEnum.ApprovalInProgress ||
          this.application.statusId === StatusEnum.PendingSLA ||
          this.application.statusId === StatusEnum.PendingSignedSLA ||
          this.application.statusId === StatusEnum.DeptComments ||
          this.application.statusId === StatusEnum.OrgComments)
          ? false : true;

        this.showReviewerSatisfaction = this.application.statusId === StatusEnum.PendingReview ? true : false;
        this.tooltip = this.canEdit ? 'Edit' : 'View';
        //this.loadIndicators();
        this.loadSubIndicators();
        this.loadProgrammes();
        this.loadSubProgrammes();
        this.loadSubProgrammeTypes();   
        this.loadFrequencyPeriods();
        this.buildButtonItems();
      }
    });

  

    this.npoName = this.npo?.name;
   // this.GetIndicatorReportsByAppid();
    this.indicatorCols = [
      { header: ' Indicator Id', width: '10%' },
      { header: 'Indicator Description/Title', width: '10%' },
      { header: 'Output Title', width: '10%' },
      { header: 'Annual Target', width: '10%' },
      { header: 'Quarter 1', width: '10%' },
      { header: 'Quarter 2', width: '10%' },
      { header: 'Quarter 3', width: '10%' },
      { header: 'Quarter 4', width: '10%' },
      { header: 'Short Definition', width: '10%' },
      { header: 'Purpose', width: '10%' },
    ];
    
    this.actualCols = [
      { header: 'Output Title', width: '10%' },
      { header: 'Indicator Id', width: '10%' },
      // { header: 'Output Description', width: '10%' },
      { header: 'DSD Targets', width: '10%' },
      { header: 'Actual', width: '10%' },
      { header: 'Variance ', width: '10%' },
      { header: 'Deviation Reason', width: '10%' },
      { header: 'Adjusted Actual ', width: '10%' },
      { header: 'Adjusted Variance ', width: '10%' },
      { header: 'Target Group ', width: '10%' },
      { header: 'Evidence', width: '10%' },
      { header: 'Status', width: '10%' },
    ];
    this.auditCols = [
      { header: '', width: '5%' },
      { header: 'Status', width: '55%' },
      { header: 'User', width: '20%' },
      { header: 'Date', width: '20%' }
    ];

        
    this.verifyCols = [
      {
        header: 'Quarterly Target', width: '10%'
      },
      { header: 'NPO Report', width: '15%', field: '' },
      { header: 'Verified', width: '15%', field: '' },
      { header: 'Not verified', width: '15%', field: '' },
      { header: 'Reasons for not verified numbers ', width: '15%', field: '' },
      { header: 'Variance from Target', width: '15%', field: '' },
      { header: 'Reason for variance from Targets', width: '10%',  field: '' },


    ];
    
    this.commentCols = [
      { header: '', width: '5%' },
      { header: 'Comment', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];

    this.reviewerSatisfactionCols = [
      { header: '', width: '5%' },
      { header: 'Is Satisfied', width: '25%' },
      { header: 'Created User', width: '35%' },
      { header: 'Created Date', width: '35%' }
    ];

    this.documentCols = [
      { header: '', width: '5%' },
      { header: 'Document Name', width: '60%' },
      { header: 'Size', width: '10%' },
      { header: 'Uploaded Date', width: '15%' },
      { header: 'Actions', width: '10%' }
    ];

    this.cols = [
      { field: 'activityList.name', header: 'Activity', width: '50%' },
      { field: 'successIndicator', header: 'Indicator', width: '30%' },
      { field: 'target', header: 'Target', width: '9%' },
    ];

  }

onKeyUp(rowData: any, event: any) {
const inputValue = event.target.value;
rowData.actual = Number(inputValue); // Ensure it's a number

// Calculate the variance
if (rowData.targets !== undefined && !isNaN(rowData.actual)) {
    rowData.variance = rowData.targets - rowData.actual;
} else {
    rowData.variance = 0; // Set to zero or handle it as per your requirement
}
}

onVerifiedKeyUp() {
  this.verifiedActual.notVerified = this.verifiedActual.verified - this.verifiedActual.quarterTargets;
  this.verifiedActual.targetVariance = this.verifiedActual.verified - this.verifiedActual.quarterTargets;
}

onKeyUpAdjustedActual(event: any, rowData: any) {
const inputValue = Number(event.target.value); // Convert the input to a number
rowData.adjustedActual = inputValue;

// Calculate adjusted variance if targets is defined
if (rowData.targets !== undefined) {
  rowData.adjustedVariance = rowData.targets - rowData.adjustedActual;
} else {
  rowData.adjustedVariance = 0; // Or handle this case as needed
}
}

onBlurAdjustedActual(rowData: any) {
   this.saveActual(rowData);
}

disableAdd(): any {
if(this.qselected === false || this.yearSelected === false)
  {
    return true
  }
}

private loadSubIndicators() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Indicator, false).subscribe(
      (results) => {
        this.indicators = results;
        //this.GetIndicatorReportsByAppid();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
}

createMergedList() {
  this.mergedList = [];
  this.iNPOIndicators.forEach(indicator => {
    // Find the matching actualData for this indicator
    const actualData = this.actuals.find(act => 
      act.indicatorId === +indicator.id && 
      act.financialYearId === this.selectedFinancialYear.id && 
      act.qaurterId === this.quarterId &&
      act.serviceDeliveryAreaId === this.serviceDeliveryAreaId 

    );
  
    // Safely handle the case where actualData is undefined, fallback to empty actual
    const actuals = actualData ? { ...actualData } : this.createEmptyActual(indicator);
  
    // Set targets based on frequency (ensure actuals object is populated)
    this.setTargetsBasedOnFrequency(actuals, indicator);

    // Push merged indicator and actuals into the mergedList if they are valid
    if (indicator && actuals) {
      // Merge indicator properties, and overwrite 'id' with actuals.id
      const mergedObject = {
        ...indicator,    // Spread the indicator object
        ...actuals,      // Spread actuals, this will overwrite the 'id' property from indicator
        id: actuals.id,
        indicatorValue: indicator.indicatorId,
        indicatorId:indicator.id   // Overwrite the id with the id from actuals
      };
  
      // Push the merged object into the list
      this.mergedList.push(mergedObject); 
    
    }
  });

  this.mergedList.forEach(row => {
    row.isEditable = !(row.id > 0);
  });

  this.rightHeaderIndicatorChange.emit('Pending');
  this.addOtherfield = true;
  const allComplete = this.mergedList.length > 0 && this.mergedList.every(dip => dip?.status?.id === 24);
  const allSubmitted = this.mergedList.length > 0 && this.mergedList.every(dip => dip?.status?.id === 19);

  if (allComplete) {
      this.rightHeaderIndicatorChange.emit('Completed');
      this.addOtherfield = false;
  }
  if (allSubmitted) {
      this.rightHeaderIndicatorChange.emit('Submitted');
      this.addOtherfield = false;
  }

  this.cdr.detectChanges(); // Trigger change detection
  // this.performPostMergeOperations();
}

status(data: any) {
  return data?.status?.name || 'New';
}
 
setTargetsBasedOnFrequency(actual: IActuals,indicator: INPOIndicator) {
    if (this.quarterId) {
       if(this.quarterId === 1)
      {
        actual.targets = indicator.q1;
      }
      if(this.quarterId === 2)
      {
       actual.targets = indicator.q2;
      }
      if(this.quarterId === 3)
      {
       actual.targets = indicator.q3;
      }
      if(this.quarterId === 4)
      {
        actual.targets = indicator.q4;
      }
    }
}

  createEmptyActual(indicator: INPOIndicator): IActuals {
    return {
      id: 0,
      programmeId: 0,
      subProgrammeId: 0,
      group: '',
      subProgrammeTypeId: 0,
      serviceDeliveryArea: '',
      outputTitle: '',
      targets: 0,
      financialYearId: new Date().getFullYear(),
      indicatorId: 0,
      indicatorValue: '',
      variance: 0,
      deviationReason: '',
      adjustedActual: 0,
      adjustedVariance: 0,
      applicationId: 0,
      serviceDeliveryAreaId: 0,
      qaurterId: 0,
      actual: 0,
      documents: [],
      isActive: true,
      statusId: 0,
      status: {} as IStatus,
      comments: '',
      indicatorReportAudits: {} as IActualsAudit[],
      verifyActual: {} as IVerifiedActuals[]
    };
  }

  updateButtonItems() {
    this.buttonItems[0].items.forEach(option => {
      option.visible = true;
    });

    switch (this.merged.statusId) {
      case StatusEnum.Submitted: {
        this.buttonItems[0].items[0].visible = false;
        break;
      }
    }
  }


  private buildButtonItems() {
    this.buttonItems = [];
    if (this.profile) {
      this.buttonItems = [{
        label: 'Options',
        items: []
      }];

      if (this.IsAuthorized(PermissionsEnum.ReviewWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Edit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
           this.enableEditing(this.merged);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Comments',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
           this.addComment(this.merged);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'View History',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
           this.viewHistory(this.merged);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Verify Actual',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
           this.verifyActual(this.merged);
          }
        });
      }
    }
  }

  private verifyActual(rowData: any) {
   this.GetVerifiedActualByActualId(rowData.id, rowData);
  }

  private viewHistory(rowData: any) {
    this.displayVieHistoryDialog = true;
  }

 private updateActualData(rowData: any, status: number) {
    rowData.statusId = status;
    this.saveActual(rowData);
  }  
 
  // Method to save the actuals
  saveActualz(mergedItem: any) {
    // Add your save logic here
  }
  private loadProgrammes() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
      (results) => {
        this.allProgrammes = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSubProgrammes() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
      (results) => {
        this.allSubProgrammes = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
 
  private loadSubProgrammeTypes() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgrammeTypes, false).subscribe(
      (results) => {
        this.AllsubProgrammesTypes = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadDocumentTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DocumentTypes, false).subscribe(
      (results) => {
        this.documentTypes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public uploadDocument(actuals: IActuals) {
    this.seletedAactuals = actuals;
    this.element.nativeElement.click();
  }

  
  public onUploadChange = (files) => {
    files[0].documentType = this.documentTypes.find(x => x.location === DocumentUploadLocationsEnum.ReportActuals);
    this._documentStore.upload(files, EntityTypeEnum.ReportActuals, Number(this.seletedAactuals.id), EntityEnum.IndicatorReports, this.application.refNo, files[0].documentType.id).subscribe(
      event => {
        if (event.type === HttpEventType.UploadProgress)
          this._spinner.show();
        else if (event.type === HttpEventType.Response) {
          this._spinner.hide();
          this.getDocuments(this.seletedAactuals);
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'File successfully uploaded.' });
        }
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public uploadedFiles(actual: IActuals) {
    this._spinner.show();
    this.actual = actual;
    this.getDocuments(actual);
    this.displayUploadedFilesDialog = true;
  }

  onDownloadDocument(doc: any) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to download document?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._spinner.show();
        this._documentStore.download(doc).subscribe(
          (event) => {
            this._spinner.hide();
            this._confirmationService.close();
          },
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
            this._confirmationService.close();
          }
        );
      },
      reject: () => {
        this._confirmationService.close();
      }
    });
  }

  onDeleteDocument(doc: any, actual: IActuals) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this document?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._spinner.show();

        this._documentStore.delete(doc.resourceId).subscribe(
          (event) => {
            this.getDocuments(actual);
            this._spinner.hide();
          },
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
          }
        );
      },
      reject: () => {
      }
    });
  }

  private getDocuments(actual: IActuals) {
    this._documentStore.get(Number(actual.id), EntityTypeEnum.ReportActuals).subscribe(
      (resp) => {
        actual.documents = resp.filter(x => x.entity === EntityEnum.IndicatorReports);
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  getOrganisationValue(): string {
    return this.npo?.name;  
  }

  getcCodeValue(): string {
    return this.npo?.cCode; 
  }

  getProgramValue(): string {
    return this.allProgrammes?.find(x => x.id === this.application.applicationPeriod.programmeId).name; 
  }
  getSubProgramValue(): string {
    return this.allSubProgrammes?.find(x => x.id === this.application.applicationPeriod.subProgrammeId).name; 
  }
  getSubProgramTypeValue(): string {
   return this.AllsubProgrammesTypes?.find(x => x.id === this.application.applicationPeriod.subProgrammeTypeId).name;
  }

  getGroupTypeValue(): string {
    return "This is the value"; 
  }

  getSDAValue(): string {
    return "This is the value"; 
  }

  getQuarterValue(): string {
    return `Quarter ${this.quarterId}`; 
}
disableQuarters(): boolean {
  // Logic to disable dropdown (return true to disable, false to enable)
  return false;
} 

registerCustomFilters() {
  this.filterService.register('custom', (value: string, filter: any[]) => {
    // If no filter selected, allow all results (true)
    if (!filter || filter.length === 0) {
      return true;
    }

    // If the value being filtered is a string, it needs to be handled as such
    if (!value || typeof value !== 'string') {
      return false;
    }

    // Convert the value into an array of items (e.g., if values are comma-separated)
    const rowItems = value.split(',').map((item: string) => item.trim());

    // Compare the selected filter values (array) to the row items (array of strings)
    return filter.some(selectedItem => rowItems.includes(selectedItem.name));
  });
}

onCustomFilterChange(selectedItems: any[], field: string) {
  const filterFields = [field];
  this.filteredData = this.filterService.filter(this.activeActivities, filterFields, selectedItems || [], 'custom');

  this.applyCustomFilters();
}
  
applyCustomFilters() {
  this.activeActivities = this.filteredData;
  this.updateRowGroupMetaData();  // Update metadata based on the filtered data
}

applyFilterGlobal($event: any, stringVal: any) {
  this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
}

private loadFrequencyPeriods() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.QuarterlyPeriod, false).subscribe(
      (results) => {
        results = results.sort((a, b) => a.id - b.id);
        this.quartelyPeriods = results;
        //this.isDataAvailable();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
}

private loadIndicators() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.HighLevelNPO, false).subscribe(
      (results) => {
        this.iNPOIndicators = results.filter(indicator => indicator.ccode === this.npo?.cCode);
        this.GetIndicatorReportsByAppid();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
}

private GetIndicatorReportsByAppid() {
  this._spinner.show();
  this._applicationRepo.GetIndicatorReportsByAppid(this.application).subscribe(
    (results) => {
     this.actuals = results;
      this._spinner.hide();
      this.createMergedList();
    },
    (err) => {
      this._loggerService.logException(err);
      this._spinner.hide();
    }
  );
}


private GetVerifiedActualByActualId(actualId: number, rowData: any) {
  this._spinner.show();
  this._applicationRepo.GetVerifiedByAppid(actualId, this.quarterId).subscribe(
    (result) => {
    this.verifiedActual = result;
    this._spinner.hide();
    if( this.verifiedActual === undefined || this.verifiedActual === null || this.verifiedActual.id === 0) 
    {
        this.verifiedActual = {} as IVerifiedActuals;
        this.verifiedActual.id = 0;
        // this.verifiedActual.quarterTargets = rowData.targets;
        this.verifiedActual.actualValue = rowData.actual;
        this.verifiedActual.IndicatorReportId = rowData.id;
        this.verifiedActual.indicatorValue = rowData.indicatorValue;
        // this.verifiedActual.actualNpoValue = rowData.actual;
    }

    this.verifiedActual.actualNpoValue = rowData.actual;

   if(this.quarterId === 1)
    {
      this.verifiedActual.quarterTargets = rowData.q1;
    }else 
    
    if(this.quarterId === 2){
      this.verifiedActual.quarterTargets = rowData.q2;
    }else
    
    if(this.quarterId === 3){
      this.verifiedActual.quarterTargets = rowData.q3;
    }
    else 
    
    if(this.quarterId === 4){
      this.verifiedActual.quarterTargets = rowData.q4;
    }
    
    this.displayVerifyActualDialog = true;

      // this.createMergedList();
    },
    (err) => {
      this._loggerService.logException(err);
      this._spinner.hide();
    }
  );
}


public financialYearChange() {
    this.yearSelected =  true;
}

captureTargets(activity) {
    this._router.navigateByUrl('workplan-indicator/targets/' + activity.id + '/financial-year/' + this.selectedFinancialYear.id);
}

getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];
    }
    return value;
}

private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        this.financialYearsSubject.next(results);
        const financialYearsdata = this.financialYearsSubject.getValue(); // Get the current value
        this.financialYears = financialYearsdata;
        this.selectedFinancialYear = financialYearsdata.find(x => x.id === this.application.applicationPeriod.financialYearId);
        this.yearSelected = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
}

  departmentChange(department: IDepartment) {
    this.selectedProgramme = null;
    this.selectedSubProgramme = null;
    this.selectedSubProgrammeType = null;

    this.programmes = [];
    this.subProgrammes = [];
    this.subProgrammesTypes = [];

    if (department.id != null) {
      for (var i = 0; i < this.allProgrammes.length; i++) {
        if (this.allProgrammes[i].departmentId == department.id) {
          this.programmes.push(this.allProgrammes[i]);
        }
      }
    }
  }

  applicationTypeChange(applicationType: IApplicationType)
  {
    if(this.selectedApplicationType.name === 'Quick Capture' && this.selectedDepartment.name === 'Health')
    {
      alert(this.selectedDepartment.name);
    }
  }

  loadDepartmentPrograms(id: number = 0) {
    this.filteredProgrammes = this.allProgrammes.filter(x => x.departmentId === id); 
  }

  programmeChange(programme: IProgramme) {
    this.selectedSubProgramme = null;
    this.selectedSubProgrammeType = null;
   
    this.filteredSubProgrammes = [];
    this.filteredSubProgrammeTypes = [];

    if (programme.id != null) {
      this.filteredSubProgrammes = this.allSubProgrammes.filter(x => x.programmeId === programme.id);
    }
  }

  subProgrammeChange(subProgramme: ISubProgramme) {
    this.selectedSubProgrammeType = null;
    this.filteredSubProgrammeTypes = [];

    if (subProgramme.id != null) {
      this.filteredSubProgrammeTypes = this.AllsubProgrammesTypes.filter(x => x.subProgrammeId === subProgramme.id);
    }
  }

  filterFacilityDistrict(selectedSubDistricts: any): void {
    this.loadFacilities();
    if (selectedSubDistricts && selectedSubDistricts.length > 0) {
        // Extract LinkIds from the selected ISubDistrictDemographic objects
        const selectedLinkIds = selectedSubDistricts.map(subDistrict => subDistrict.linkId);
        // Filter facilities based on the selected LinkIds
        this.facilitiesList = this.facilities.filter(facility =>
            selectedLinkIds.includes(facility.facilitySubDistrictId)
        );
    } else {

    }
}

preventChange(event: any): void {
  event.originalEvent.preventDefault(); 
  event.value = [...this.selectedFacilities];
}

// Method to handle changes when Demographic District is changed
onDemographicDistrictChange() {
  this.selectedManicipalityDemographics = [];
  this.selectedSubstructureDemographics = [];
  this.selectedSubDistrictDemographics = [];

  if (this.selectedIDistrictDemographics) {
    // Filter ManicipalityDemographics based on selected District
    this.ManicipalityDemographics = this.allManicipalityDemographics.filter(md =>
      md.districtDemographicId === this.selectedIDistrictDemographics.id
    );

    // Reset other arrays
    this.SubDistrictDemographics = [];
    this.SubstructureDemographics = [];
  } else {
    // Reset all arrays if no district is selected
    this.ManicipalityDemographics = [];
    this.SubDistrictDemographics = [];
    this.SubstructureDemographics = [];
  }
}

saveComment(changesRequired: boolean, origin: string) {
  this.seletedAactuals.comments = this.comment; 
  this.onBlurAdjustedActual(this.seletedAactuals);
  this.displayCommentDialog = false;
}

outputTitleChange(event: any) {
  this.selectedOutputTitle = event;
  this.QValue();
}

onDemographicManicipalitiesChange() {
  this.selectedSubstructureDemographics = [];
  this.selectedSubDistrictDemographics = [];

  if (this.selectedManicipalityDemographics && this.selectedManicipalityDemographics.length > 0) {
    this.SubstructureDemographics = this.allSubstructureDemographics.filter(ss =>
      this.selectedManicipalityDemographics.some(md => md.id === ss.manicipalityDemographicId)
    );

    // Reset other arrays
    this.SubDistrictDemographics = [];
  } else {
    // Reset all arrays if no manicipality demographic is selected
    this.SubstructureDemographics = [];
    this.SubDistrictDemographics = [];
  }
}

onDemographicSubStructuresChange() {
  this.selectedSubDistrictDemographics = [];

  if (this.selectedSubstructureDemographics && this.selectedSubstructureDemographics.length > 0) {
    // Filter SubDistrictDemographics based on selected SubstructureDemographics
    this.SubDistrictDemographics = this.allSubDistrictDemographics.filter(sd =>
      this.selectedSubstructureDemographics.some(ss => ss.id === sd.subSctrcureDemographicId)
    );
  } else {
    // Reset all arrays if no sub-structure demographic is selected
    this.SubDistrictDemographics = [];
  }
}

// In your component class
addOther() {
  // Define a blank row that follows the structure of your actuals array
  const newRow = {
    outputTitle: '',
    indicatorId: 0,
    targets: 0,
    actual: 0,
    variance: 0,
    deviationReason: '',
    adjustedActual: 0,
    adjustedVariance: 0,
    applicationId: 0,
    serviceDeliveryAreaId: 0,
    subProgrammeId: 0,
    programmeId: 0,
    subProgrammeTypeId: 0,
    isActive: true,
    id: 0,
    qaurterId: 0,
    groupId: '',
    financialYearId: 0,
    serviceDeliveryArea: '',
    group: '',
    indicatorValue: '',
    documents: [],
    statusId: 0,
    status: {} as IStatus,
    comments: '',
    indicatorReportAudits: [] as IActualsAudit[],
    verifyActual: {} as IVerifiedActuals[]
  };

  // Add this new row to the actuals array
  this.actuals = [...this.actuals, newRow];
}


editActual(data: IActuals) {
  this.newActual = false;
  this.actual = this.cloneActual(data);
  this.outputTitle(this.actual);
}

outputTitle(rowData: any) {
    return this.indicators.find(x => x.indicatorValue === rowData.indicatorValue)?.outputTitle;
}

IndicatorDescription(rowData: any) {
     return this.indicators.find(x => x.indicatorValue === rowData.indicatorValue)?.indicatorDesc;    
}

shortDefination(rowData: any) {
     return this.indicators.find(x => x.indicatorValue === rowData.indicatorValue)?.shortDefinition;     
}

 purpose(rowData: any) {
  return this.indicators.find(x => x.indicatorValue === rowData.indicatorValue)?.purpose;     
}

ttargets(rowData: any) {
  //return this.indicators.find(x => x.indicatorValue === rowData.indicatorId)?.;     
}

toutputTitle(rowData: any) {
  return this.indicators.find(x => x.indicatorValue === rowData.indicatorId)?.outputTitle;
}

tshortDefination(rowData: any) {
  return this.indicators.find(x => x.indicatorValue === rowData.indicatorId)?.shortDefinition;     
}
tIndicatorDescription(rowData: any) {
  return this.indicators.find(x => x.indicatorValue === rowData.indicatorId)?.indicatorDesc;    
}

tpurpose(rowData: any) {
  return this.indicators.find(x => x.indicatorValue === rowData.indicatorId)?.purpose;     
}

private cloneActual(data: IActuals): IActuals {
  let obj = {} as IActuals;

  for (let prop in data)
    obj[prop] = data[prop];
  return obj;
}

saveActual(rowData: any) {
  let actualobj = {} as IActuals;
  // Assign necessary fields
  actualobj.deviationReason = rowData.deviationReason
  actualobj.id = rowData.id;
  actualobj.statusId = rowData.statusId;
  actualobj.outputTitle = rowData.outputTitle;
  // actualobj.financialYear = this.selectedFinancialYear.id;
  actualobj.indicatorId = rowData.indicatorId;
  actualobj.indicatorValue = rowData.indicatorValue;
  actualobj.variance = rowData.variance;
  actualobj.actual = rowData.actual;
  actualobj.adjustedActual = rowData.adjustedActual;
  actualobj.adjustedVariance = rowData.adjustedVariance;
  actualobj.targets = rowData.targets;
  actualobj.subProgrammeId = this.application.applicationPeriod.subProgrammeId;
  actualobj.programmeId = this.application.applicationPeriod.programmeId;
  actualobj.subProgrammeTypeId = this.application.applicationPeriod.subProgrammeTypeId;
  actualobj.isActive = true;
  actualobj.applicationId = this.application.id;
  actualobj.financialYearId = this.application.applicationPeriod.financialYear.id;
  actualobj.qaurterId = this.quarterId;
  actualobj.serviceDeliveryAreaId = this.serviceDeliveryAreaId;
  actualobj.comments = rowData.comments;
  actualobj.group = rowData.group;

if(rowData.group===null || rowData.group===undefined || rowData.group===''){
  this._messageService.add({ severity: 'warning', summary: 'Warning', detail: 'Target Group Required' });
  return
  
} 
  // Check if it's a new actual or an update
  if (rowData.id === 0) {
    // Create new actual
    this.createActual(actualobj);
  } else {
    // Update existing actual
    this.updateActual(actualobj);
  }
};   

saveVerifiedActual() {
  let verifiedobj = {} as IVerifiedActuals;
  verifiedobj.id = this.verifiedActual.id;
  verifiedobj.quarterTargets = this.verifiedActual.quarterTargets;
  // actualobj.financialYear = this.selectedFinancialYear.id;
  verifiedobj.verified = this.verifiedActual.verified;
  verifiedobj.notVerified = this.verifiedActual.notVerified;
  verifiedobj.notVerifiedReason = this.verifiedActual.notVerifiedReason;
  verifiedobj.targets = this.verifiedActual.targets;
  verifiedobj.targetVarianceReason = this.verifiedActual.targetVarianceReason;
  verifiedobj.targetVariance = this.verifiedActual.targetVariance;
  verifiedobj.IndicatorReportId = this.verifiedActual.IndicatorReportId;
  verifiedobj.isActive = true;
  
  verifiedobj.actualValue= this.verifiedActual.actualValue;
  verifiedobj.qaurterId = this.quarterId;
  verifiedobj.applicationId = this.application.id;
  verifiedobj.financialYearId = this.application.applicationPeriod.financialYear.id;
  verifiedobj.serviceDeliveryAreaId = this.serviceDeliveryAreaId;

  verifiedobj.actualNpoValue= this.verifiedActual.actualNpoValue;
  verifiedobj.subProgrammeId = this.application.applicationPeriod.subProgrammeId;
  verifiedobj.programmeId = this.application.applicationPeriod.programmeId;
  verifiedobj.subProgrammeTypeId = this.application.applicationPeriod.subProgrammeTypeId;

  // Check if it's a new actual or an update
  if (this.verifiedActual.id === 0) {
    // Create new actual
    this.createVerifiedActual(verifiedobj);
  } else {
    // Update existing actual
    this.updateVerifiedActual(verifiedobj);
  }
}

getFinancialYear(id: number): string | undefined {
  const financialYear = this.financialYears?.find(year => year.id === id);
  return financialYear ? financialYear.name : undefined;
}

createVerifiedActual(verifiedactual: IVerifiedActuals) {
  this._applicationRepo.createVerifiedActual(verifiedactual).subscribe(
    (resp) => {
      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'successfully added.' });
      //this.GetVerifiedActualByAppid()
      this.displayVerifyActualDialog = false;
    },
    (err) => {
      this._loggerService.logException(err);
      this._spinner.hide();
    }
  );
}


updateVerifiedActual(verifiedactual: IVerifiedActuals) {
  this._applicationRepo.updateVerifiedActual(verifiedactual).subscribe(
    (resp) => {
      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'successfully updated.' });
      //this.GetVerifiedActualByAppid()
      //this.displayActualDialog = false;
    },
    (err) => {
      this._loggerService.logException(err);
      this._spinner.hide();
    }
  );
}



// Method to create a new actual
createActual(actual: IActuals) {
  this._applicationRepo.createActual(actual).subscribe(
    (resp) => {
      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'successfully added.' });
      this.GetIndicatorReportsByAppid()
      //this.displayActualDialog = false;
    },
    (err) => {
      this._loggerService.logException(err);
      this._spinner.hide();
    }
  );
}

// Method to update an existing actual
updateActual(actual: IActuals) {
  this._applicationRepo.updateActual(actual).subscribe(
    (resp) => {
      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'successfully updated.' });
      //this.GetIndicatorReportsByAppid()
      //this.displayActualDialog = false;
    },
    (err) => {
      this._loggerService.logException(err);
      this._spinner.hide();
    }
  );
}


  getSubDistrictNames(activityDemoName: any): string {
    if (!activityDemoName || !activityDemoName) {
      return '';
    }

    return activityDemoName.map((subDistrict: any) => subDistrict.name).join(', ');
  }

  onDistrictChange() {
    this.selectedSubDistricts = [];
    this.selectedFacilitySubStructures  = null;
    
    if (this.selectedDistricts) {
      this.facilitySubDistricts = this.allFacilitySubDistricts.filter(sd => 
        sd.facilityDistrictId === this.selectedDistricts.id
      );
  
      this.facilitySubStructures = this.allFacilitySubStructures.filter(ss => 
        ss.facilityDistrictId === this.selectedDistricts.id
      );

    } else {
      this.selectedSubDistricts = [];
      this.selectedFacilitySubStructures = null;
    }
  }
  

  private loadNpo() {
    this._npoRepo.getNpoById(this.application.npoId).subscribe(
      (results) => {
        this.npo = results;
        this.loadIndicators();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  frequencyPeriodChange() {
    this.qselected = true;
     if (this.yearSelected && this.qselected) {
      this.GetIndicatorReportsByAppid();
      // this.createMergedList();
     }
  }
  QValue() {
      if(this.selectedFrequencyPeriod.name === 'Quarter1')
      {
        this.actual.targets = this.selectedOutputTitle.q1;
      }
      if(this.selectedFrequencyPeriod.name === 'Quarter2')
      {
       this.actual.targets = this.selectedOutputTitle.q2;
      }
      if(this.selectedFrequencyPeriod.name === 'Quarter3')
      {
       this.actual.targets = this.selectedOutputTitle.q3;
      }
      if(this.selectedFrequencyPeriod.name === 'Quarter4')
      {
        this.actual.targets = this.selectedOutputTitle.q4;
      }
  }

  public GetDifference(isNew: boolean) {
    switch (isNew) {
      case undefined:
        return '';
      case true:
        return 'New';
      case false:
        return 'Changed';
    }
  }

  private getFacilityListText(activities: IActivity[]) {
    activities.forEach(activity => {
      let allFacilityLists: string = "";

      activity.activityFacilityLists.forEach(item => {
        allFacilityLists += item.facilityList.name + "; ";
      });

      activity.facilityListText = allFacilityLists.slice(0, -2);
    });
  }

  private loadFacilities() {
    this._applicationRepo.getAssignedFacilities(this.application).subscribe(
      (results) => {
        this.facilities = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private setYearRange() {
    let currentDate = new Date;
    let startYear = currentDate.getFullYear() - 5;
    let endYear = currentDate.getFullYear() + 5;

    this.yearRange = `${startYear}:${endYear}`;
  }

  private loadAllSubProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
      (results) => {
        this.allSubProgrammes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  nextPage() {
    if (this.activeActivities.length > 0) {
      let canContinue: boolean[] = [];

      this.objectives.forEach(item => {
        var isPresent = this.activeActivities.some(function (activity) { return activity.objectiveId === item.id });
        canContinue.push(isPresent);
      });

      if (!canContinue.includes(false)) {
        this.activeStep = this.activeStep + 1;
        this.activeStepChange.emit(this.activeStep);
      }
      else
        this._messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Please capture an activity for each objective.' });
    }
    else
      this._messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Activity table cannot be empty.' });
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }


  addActuals(){
    this.displayActualDialog = true;
  }


  private buildRecipientDropdown(objective: IObjective, activity: IActivity) {
    this.recipients = [];

    //Primary Recipient
    this.recipients.push({
      activityId: activity.id ? activity.id : 0,
      entity: RecipientEntityEnum.Objective,
      entityId: objective.id,
      recipientTypeId: objective.recipientTypeId,
      recipientName: `${this.npo.name} (${objective.recipientType.name} Recipient)`
    } as IActivityRecipient);

    objective.subRecipients.forEach(sr => {
      sr.recipientType = this.recipientTypes.find(x => x.id === sr.recipientTypeId);

      //Sub Recipient
      this.recipients.push({
        activityId: activity.id ? activity.id : 0,
        entity: RecipientEntityEnum.SubRecipient,
        entityId: sr.id,
        recipientTypeId: sr.recipientTypeId,
        recipientName: `${sr.organisationName} (${sr.recipientType.name})`
      } as IActivityRecipient);

      sr.subSubRecipients.forEach(ssr => {
        ssr.recipientType = this.recipientTypes.find(x => x.id === ssr.recipientTypeId);

        //Sub Sub Recipient
        this.recipients.push({
          activityId: activity.id ? activity.id : 0,
          entity: RecipientEntityEnum.SubSubRecipient,
          entityId: ssr.id,
          recipientTypeId: ssr.recipientTypeId,
          recipientName: `${ssr.organisationName} (${ssr.recipientType.name})`
        } as IActivityRecipient);
      });
    });
  }

  deleteActual(data: IActuals) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.actual = this.cloneActual(data);
        this.actual.isActive = false;
        this.updateActual( this.actual);
        this._confirmationService.close();
      },
      reject: () => {
        this._confirmationService.close();
      }
    });
  }

  disableSaveActivity() {
    let data = this.activity;

    if (!this.selectedObjective || this.selectedSubProgrammes.length === 0 || !data.name || !data.description || !this.selectedActivityType || !data.timelineStartDate || !data.timelineEndDate || !data.target || this.selectedFacilities.length === 0 || this.selectedRecipients.length === 0)
      return true;

    return false;
  }
  disableProgramme(): boolean {
    if (this.programmes.length > 0)
      return false;

    return true;
  }
  updateSelectedQuarterText() {
    // Update the text area content with the name of the selected quarter
    this.selectedQuartersText = this.selectedQuarters ? this.selectedQuarters.values.name : '';
  }
  


  disableSubProgrammeType(): boolean {
    if (this.filteredSubProgrammeTypes.length > 0)
      return false;

    return true;
  }

  private updateRowGroupMetaData() {
    this.rowGroupMetadata = [];

    this.activeActivities = this.activeActivities.sort((a, b) => a.objectiveId - b.objectiveId);

    if (this.activeActivities) {

      this.activeActivities.forEach(element => {

        var itemExists = this.rowGroupMetadata.some(function (data) { return data.itemName === element.objective.name });

        this.rowGroupMetadata.push({
          itemName: element.objective.name,
          itemExists: itemExists
        });
      });
    }
  }

  disableSubProgramme(): boolean {
    if (this.subProgrammes.length > 0)
      return false;

    return true;
  }

  objectiveChange(objective: IObjective) {
    this.subProgrammes = [];
    const subProgrammeIds = objective.objectiveProgrammes.map(({ subProgrammeId }) => subProgrammeId);
    this.subProgrammes = this.allSubProgrammes.filter(item => subProgrammeIds.includes(item.id));

    this.buildRecipientDropdown(objective, this.activity);
  }

  addComment(merged: any) {
    if(merged.id === 0 || merged.id === undefined || merged.id === null || merged.id < 0){
      this._messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Please actual data first.' });
      return;
    }

    this.seletedAactuals = this.actuals.filter(x => x.id === merged.id)[0];
    console.log('seletedAactuals', this.seletedAactuals);
    if (this.seletedAactuals?.comments != null) {
      this.comment = this.seletedAactuals.comments;
    }
    else{
      this.comment= null;
    }
  
    this.displayCommentDialog = true;
    this.canEdit = true;
  }

  enableEditing(rowData: any) {
    this.mergedList.forEach(post => post.isEditable = false);
    rowData.isEditable = true;
  }

  viewComments(data: IActivity, origin: string) {
    this.activity = data;

    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Activities,
      entityId: data.id
    } as IApplicationComment;

    this._applicationRepo.getApplicationComments(model).subscribe(
      (results) => {
        this.applicationComments = results;

        if (origin === 'allComments')
          this.displayAllCommentDialog = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  disableSaveComment() {
    if (!this.comment)
      return true;

    return false;
  }

  search(event) {
    let query = event.query;
    this._dropdownRepo.getActivityByName(query).subscribe((results) => {
      this.activityList = results;
    });
  }

  selectActivity(item: IActivityList) {
    this.activity.name = item.name;
    this.activity.description = item.description;
  }

  viewReviewerSatisfaction(data: IActivity) {
    this.activity = data;

    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Activities,
      entityId: data.id
    } as IApplicationReviewerSatisfaction;

    this._applicationRepo.getApplicationReviewerSatisfactions(model).subscribe(
      (results) => {
        this.applicationReviewerSatisfaction = results;
        this.displayReviewerSatisfactionDialog = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  createReviewerSatisfaction(isSatisfied: boolean) {
    this._confirmationService.confirm({
      message: 'Are you sure that you selected the correct option?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {

        let model = {
          applicationId: this.application.id,
          serviceProvisionStepId: ServiceProvisionStepsEnum.Activities,
          entityId: this.activity.id,
          isSatisfied: isSatisfied
        } as IApplicationReviewerSatisfaction;

        this._applicationRepo.createApplicationReviewerSatisfaction(model).subscribe(
          (resp) => {
            let entity = {
              id: model.entityId
            } as IActivity;
            this.viewReviewerSatisfaction(entity);

            this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Item successfully added.' });
            this.displayReviewerSatisfactionDialog = false;
          },
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
          }
        );
      },
      reject: () => {
      }
    });
  }

  public getColspan() {
    return this.application.isCloned && this.isReview ? 11 : 14;
  }

  public viewDeletedActivities() {
    this.deletedActivities = this.allActivities.filter(x => x.isActive === false);
    this.deletedRowGroupMetadata = [];

    let activities = this.deletedActivities.sort((a, b) => a.objectiveId - b.objectiveId);

    if (activities) {

      activities.forEach(element => {

        var itemExists = this.deletedRowGroupMetadata.some(function (data) { return data.itemName === element.objective.name });

        this.deletedRowGroupMetadata.push({
          itemName: element.objective.name,
          itemExists: itemExists
        });
      });
    }

    this.displayDeletedActivityDialog = true;
  }

  completeAction() {
    this._spinner.show();
    this.baseCompleteViewModel.applicationId = this.application.id;
    this.baseCompleteViewModel.quarterId = this.quarterId;
    this.baseCompleteViewModel.finYear = this.application.applicationPeriod.financialYear.id;

    this._applicationRepo.completeIndicatorAction(this.baseCompleteViewModel).subscribe(
      (resp) => {
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Action successfully completed.' });
        this.GetIndicatorReportsByAppid();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public reviewAllItems() {

    this._confirmationService.confirm({
      message: 'Are you sure you are satisfied with the details contained in all the Activities?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {

        this.activeActivities.forEach(item => {
          let model = {
            applicationId: this.application.id,
            serviceProvisionStepId: ServiceProvisionStepsEnum.Activities,
            entityId: item.id,
            isSatisfied: true
          } as IApplicationReviewerSatisfaction;

          let lastObjectInArray = this.activeActivities[this.activeActivities.length - 1];

          this._applicationRepo.createApplicationReviewerSatisfaction(model).subscribe(
            (resp) => {

              if (item === lastObjectInArray) {
                this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Reviewer Satisfaction completed for all activities.' });
              }
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        });
      },
      reject: () => {
      }
    });
  }
}



