
import { DatePipe } from '@angular/common';
import { ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { DepartmentEnum, DropdownTypeEnum, FacilityTypeEnum, PermissionsEnum, RecipientEntityEnum, RoleEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IActivityDistrict, IActivityFacilityList, IActivityList, IActivityManicipality, IActivityRecipient, IActivitySubDistrict, IActivitySubProgramme, IActivitySubStructure, IActivityType, IApplication, IApplicationComment, IApplicationPeriod, IApplicationReviewerSatisfaction, IApplicationType, IBaseCompleteViewModel, IDepartment, IDistrictDemographic, IFacilityDistrict, IFacilityList, IFacilitySubDistrict, IFacilitySubStructure, IFinancialYear, IGovernance, IManicipalityDemographic, INpo, IObjective, IOtherInfor, IProgramme, IRecipientType, IStatus, ISubDistrictDemographic, ISubProgramme, ISubProgrammeType, ISubstructureDemographic, IUser } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { FilterService } from 'primeng/api';
import { Router } from '@angular/router';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-any-other-information-report',
  templateUrl: './any-other-information-report.component.html',
  styleUrls: ['./any-other-information-report.component.css'],
  providers: [FilterService]
})

export class AnyOtherInformationReportComponent implements OnInit {
  
  @Input() selectedQuarter!: number;

  @Output() otherrightHeaderChange = new EventEmitter<string>();

  quarterId: number;
  filteredotherInfors: IOtherInfor[];

  ngOnChanges(changes: SimpleChanges) {
      if (changes['selectedQuarter'] && changes['selectedQuarter'].currentValue) {
          const quarter = changes['selectedQuarter'].currentValue;
          this.quarterId = quarter;
          this.filterDataByQuarter(quarter);
      }
  }

  filterDataByQuarter(quarter: number) {
     this.filteredotherInfors = this.otherInfors.filter(x => x.qaurterId === quarter);
     this.otherrightHeaderChange.emit('Pending');
     const allComplete = this.filteredotherInfors.length > 0 && this.filteredotherInfors.every(dip => dip.statusId === 24);
     if (allComplete) {
       this.otherrightHeaderChange.emit('Completed');
     }
     this.cdr.detectChanges();
  }
  applicationPeriod: IApplicationPeriod = {} as IApplicationPeriod;

  menuActions: MenuItem[];
  profile: IUser;
  validationErrors: Message[];
  filteredProgrammes: IProgramme[] = [];
  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;
  departments: IDepartment[];
  selectedDepartment: IDepartment;
  allProgrammes: IProgramme[];
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
  public get RoleEnum(): typeof RoleEnum {
    return RoleEnum;
  }

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Output() activityChange: EventEmitter<IActivity> = new EventEmitter<IActivity>();
  @Input() canAddComments: boolean;
  @Input() isReview: boolean;

  allActivities: IActivity[];
  activeActivities: IActivity[];
  deletedActivities: IActivity[];

  anyOtherCols: any[];
  displayAnyOtherDialog: boolean;
  newActivity: boolean;
  newOtherInfor: boolean;
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

  otherInfors: IOtherInfor[];
  otherInfor: IOtherInfor = {} as IOtherInfor;

  selectedotherInfor: IOtherInfor;
  buttonItems: MenuItem[];
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

  @ViewChild('dt') dt: Table | undefined;
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  constructor(
    private cdr: ChangeDetectorRef,
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
    private _applicationPeriodRepo: ApplicationPeriodService
    
   
  ) {  }

  ngOnInit(): void {

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;
        this._spinner.show();
        this.registerCustomFilters();
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
    
        this.loadNpo();
        this.setYearRange();
        this.loadFinancialYears();
        this.loadotherInfor();
        this.buildButtonItems();
      }
    });


    this.anyOtherCols = [
      { header: 'Highlights', width: '50%' },
      { header: 'Challenges', width: '50%' },
      { header: 'Status', width: '50%' },
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
  }

  private buildButtonItems() {
    this.buttonItems = [];
    if (this.profile) {
      this.buttonItems = [{
        label: 'Options',
        items: []
      }];

      if (this.IsAuthorized(PermissionsEnum.CaptureWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Submit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.updateselectedotherInforData(this.selectedotherInfor, StatusEnum.PendingReview);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ReviewWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Edit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.updateselectedotherInforData(this.selectedotherInfor, StatusEnum.PendingApproval);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Comments',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.displayCommentDialog=true;
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'View History',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.updateselectedotherInforData(this.selectedotherInfor, StatusEnum.Approved);
          }
        });
      }
    }
  }

  updateButtonItems() {
    // Show all buttons
    this.buttonItems[0].items.forEach(option => {
      option.visible = true;
    });

    // switch (this.selectedIndicator.workplanActuals[0].statusId) {
    //   case StatusEnum.New:
    //   case StatusEnum.Saved:
    //   case StatusEnum.AmendmentsRequired: {
    //     this.buttonItems[0].items[2].visible = false;
    //     this.buttonItems[0].items[3].visible = false;
    //     this.buttonItems[0].items[4].visible = false;
    //     break;
    //   }
    //   case StatusEnum.PendingReview: {
    //     this.buttonItems[0].items[0].visible = false;
    //     this.buttonItems[0].items[1].visible = false;
    //     this.buttonItems[0].items[3].visible = false;
    //     break;
    //   }
    //   case StatusEnum.PendingApproval: {
    //     this.buttonItems[0].items[0].visible = false;
    //     this.buttonItems[0].items[1].visible = false;
    //     this.buttonItems[0].items[2].visible = false;
    //     break;
    //   }
    //   case StatusEnum.Approved: {
    //     this.buttonItems[0].items[0].visible = false;
    //     this.buttonItems[0].items[1].visible = false;
    //     this.buttonItems[0].items[2].visible = false;
    //     this.buttonItems[0].items[3].visible = false;
    //     this.buttonItems[0].items[4].visible = false;
    //     break;
    //   }
    // }
  }

  private updateselectedotherInforData(rowData: IOtherInfor, status: number) {
    rowData.statusId = status;
   this.onBlurAdjustedAny(rowData);
  }  

  status(data: any) {
    return data?.status?.name || 'New';
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

  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        this.financialYears = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }


preventChange(event: any): void {
  event.originalEvent.preventDefault(); 
  event.value = [...this.selectedFacilities];
}

  private loadNpo() {
    this._npoRepo.getNpoById(this.application.npoId).subscribe(
      (results) => {
        this.npo = results;
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

  saveOtherInfor(rowData: any) {
    let otherInforobj = {} as IOtherInfor;
    otherInforobj.applicationId = this.application.id;
    otherInforobj.qaurterId = this.quarterId;
    otherInforobj.financialYearId = this.application.applicationPeriod.financialYear.id;
    otherInforobj.challenges = rowData.challenges;
    otherInforobj.highlights = rowData.highlights;
    otherInforobj.id = rowData.id;
    otherInforobj.statusId = rowData.statusId;
    otherInforobj.isActive = true;

    if (rowData.id === 0) {
      this.createOtherInfor(otherInforobj);
    } else {
      this.updateOtherInfor(otherInforobj);
    }
   }


  updateOtherInfor(otherInfor: IOtherInfor) {
    this._applicationRepo.updateOtherInfor(otherInfor).subscribe(
      (resp) => {
        this.loadotherInfor();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  createOtherInfor(otherInfor: IOtherInfor) {
    this._applicationRepo.createOtherInforReport(otherInfor).subscribe(
      (resp) => {
        this.loadotherInfor();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  onBlurAdjustedAny(rowdata){
    this.saveOtherInfor(rowdata);
  }

addNewRow() {
  const newRow : IOtherInfor = {
    id: 0,
    highlights: '',
    challenges: '',
    isActive: true,
    applicationId: 0,
    statusId: 0,
    financialYearId: 0,
    qaurterId: 0,
    status: {} as IStatus
  };
  
  this.filteredotherInfors.push(newRow);  // Add the new row to the expenditures array
}

  private loadotherInfor() {
    this._spinner.show();
    this._applicationRepo.GetOtherInforReportsByAppid(this.application).subscribe(
      (results) => {
        this.otherInfors = results; 
        if(this.quarterId > 0)
        {
            this.filteredotherInfors = this.otherInfors.filter(x => x.qaurterId === this.quarterId);
        }
        });
        this._spinner.hide();
        
  }

  editAnyOther(data: IOtherInfor) {
    this.newOtherInfor = false;
    this.otherInfor = this.cloneAnyOther(data);
    this.displayAnyOtherDialog = true;
  }

  private cloneAnyOther(data: IOtherInfor): IOtherInfor {
    let obj = {} as IOtherInfor;

    for (let prop in data)
      obj[prop] = data[prop];
    return obj;
  }

  deleteOtherInfor(data: IOtherInfor) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.otherInfor = this.cloneAnyOther(data);
        this.otherInfor.isActive = false;
        this.updateOtherInfor( this.otherInfor);
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

  addComment() {
    this.comment = null;
    this.displayCommentDialog = true;
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

  saveComment(changesRequired: boolean, origin: string) {
    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Activities,
      entityId: this.activity.id,
      comment: this.comment
    } as IApplicationComment;

    this._applicationRepo.createApplicationComment(model, changesRequired).subscribe(
      (resp) => {
        //this.loadActivities();

        let entity = {
          id: model.entityId
        } as IActivity;
        this.viewComments(entity, origin);

        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Comment successfully added.' });
        this.displayCommentDialog = false;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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
           // this.loadActivities();

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

  completeAction() {
    this._spinner.show();
    this.baseCompleteViewModel.applicationId = this.application.id;
    this.baseCompleteViewModel.quarterId = this.quarterId;
    this.baseCompleteViewModel.finYear = this.application.applicationPeriod.financialYear.id;

    this._applicationRepo.completeOtherInfoAction(this.baseCompleteViewModel).subscribe(
      (resp) => {
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Action successfully completed.' });
        this.loadotherInfor();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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
                //this.loadActivities();
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





