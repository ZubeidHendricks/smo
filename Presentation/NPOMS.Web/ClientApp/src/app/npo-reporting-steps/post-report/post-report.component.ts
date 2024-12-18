
import { DatePipe } from '@angular/common';
import { ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { DepartmentEnum, DropdownTypeEnum, FacilityTypeEnum, PermissionsEnum, RecipientEntityEnum, RoleEnum, ServiceProvisionStepsEnum, StaffCategoryEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IActivityDistrict, IActivityFacilityList, IActivityList, IActivityManicipality, IActivityRecipient, IActivitySubDistrict, IActivitySubProgramme, IActivitySubStructure, IActivityType, IApplication, IApplicationComment, IApplicationPeriod, IApplicationReviewerSatisfaction, IApplicationType, IBaseCompleteViewModel, IDepartment, IDistrictDemographic, IFacilityDistrict, IFacilityList, IFacilitySubDistrict, IFacilitySubStructure, IFinancialYear, IManicipalityDemographic, INpo, IObjective, IPostAudit, IPosts, IProgramme, IRecipientType, IStaffCategory, IStatus, ISubDistrictDemographic, ISubProgramme, ISubProgrammeType, ISubstructureDemographic, IUser } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { FilterService } from 'primeng/api';
import { Router } from '@angular/router';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { AuthService } from 'src/app/services/auth/auth.service';



@Component({
  selector: 'app-post-report',
  templateUrl: './post-report.component.html',
  styleUrls: ['./post-report.component.css'],
  providers: [FilterService]
})

export class PostReportComponent implements OnInit {
  @Input() selectedQuarter!: number;
  @Input() selectedsda!: number;
  @Input() selectedGroup: string;
  quarterId: number;

  
  @Output() rightHeaderChangepost = new EventEmitter<string>();
  displayVieHistoryDialog: boolean;
  addOther: boolean = true;
   isLoading: boolean = false;

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
    this.loadPosts();
  }
  
  applicationPeriod: IApplicationPeriod = {} as IApplicationPeriod;
  baseCompleteViewModel: IBaseCompleteViewModel = {} as IBaseCompleteViewModel;
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
  serviceDeliveryAreaId: number;
  group:string;
  posts: IPosts[] = [];
  filteredposts: IPosts[] = [];
  post: IPosts = {} as IPosts;
  selectedPost: IPosts;


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
  auditCols: any[];
  postCols: any[];
  displayPostDialog: boolean;
  displayHistory: boolean;
  newActivity: boolean;
  newPost: boolean;
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
  //activeActivities: any[] = []; // All activities
  filteredActivities: any[] = []; // Filtered activities
  filteredData: any[] = [];
  staffCategories: IStaffCategory[];
  buttonItems: MenuItem[];

  public get StaffCategoryEnum(): typeof StaffCategoryEnum {
    return StaffCategoryEnum;
  }

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
    private cdr: ChangeDetectorRef
  ) {  }

  ngOnInit(): void {

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;
        this._spinner.show();
        this.registerCustomFilters();
        this.loadNpo();
        this.setYearRange();
        this.loadFinancialYears();
        this.loadPosts();
        this.loadStaffCategories();
        this.buildButtonItems();
      }
    });

    this.auditCols = [
      { header: '', width: '5%' },
      { header: 'Status', width: '55%' },
      { header: 'User', width: '20%' },
      { header: 'Date', width: '20%' }
    ];
    
    this.postCols = [
      { header: 'Post Classification', width: '20%' },
      { header: 'Number of Posts', width: '10%' },
      { header: 'Number Filled', width: '10%' },
      { header: 'Months in which filled', width: '10%' },
      { header: 'Vacant', width: '10%' },
      { header: 'Date of Vacancies', width: '10%' },
      { header: 'Reason for vacancies', width: '10%' },
      { header: 'Plans to fill vacancies', width: '20%' },

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

      // if (this.IsAuthorized(PermissionsEnum.CaptureWorkplanActual)) {
      //   this.buttonItems[0].items.push({
      //     label: 'Submit',
      //     icon: 'fa fa-thumbs-o-up',
      //     command: () => {
      //       this.updatePostData(this.selectedPost, StatusEnum.PendingReview);
      //     }
      //   });
      // }

      if (this.IsAuthorized(PermissionsEnum.ReviewWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Edit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.enableEditing(this.selectedPost);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Comments',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.addComment();
            // if(this.selectedPost.comments != null)
            // {
            //   this.canEdit = true;
            // };

            //this.updatePostData(this.selectedPost, StatusEnum.Approved);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'View History',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
           this.viewHistory(this.selectedPost);
          }
        });
      }
    }
  }


  enableEditing(rowData: any) {
    this.filteredposts.forEach(post => post.isEditable = false);
    rowData.isEditable = true;
  }


  private viewHistory(rowData: IPosts) {
    this.displayVieHistoryDialog = true;
  }

  updateButtonItems() {
    this.buttonItems[0].items.forEach(option => {
      option.visible = true;
    });

    switch (this.selectedPost.statusId) {
      case StatusEnum.Submitted: {
        this.buttonItems[0].items[0].visible = false;
        break;
      }
    }
  }
    private updatePostData(rowData: IPosts, status: number) {
      rowData.statusId = status;
      this.savePost(rowData);
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

  completeAction() {
    this._spinner.show();
    this.baseCompleteViewModel.applicationId = this.application.id;
    this.baseCompleteViewModel.quarterId = this.quarterId;
    this.baseCompleteViewModel.serviceDeliveryAreaId = this.serviceDeliveryAreaId;
    this.baseCompleteViewModel.finYear = this.application.applicationPeriod.financialYear.id;

    this._applicationRepo.completePostAction(this.baseCompleteViewModel).subscribe(
      (resp) => {
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Action successfully completed.' });
        this.loadPosts();
        // this.filterDataByQuarter(this.quarterId)
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

  getSubDistrictNames(activityDemoName: any): string {
    if (!activityDemoName || !activityDemoName) {
      return '';
    }

    return activityDemoName.map((subDistrict: any) => subDistrict.name).join(', ');
  }


  editPost(data: IPosts) {
    this.newPost = false;
    this.post = this.clonePost(data);
    this.displayPostDialog = true;
  }

  private clonePost(data: IPosts): IPosts {
    let obj = {} as IPosts;

    for (let prop in data)
      obj[prop] = data[prop];
    return obj;
  }

 
  savePost(rowData: any) {
  let postobj = {} as IPosts;
  postobj.staffCategoryId = rowData.staffCategoryId
  postobj.numberOfPosts = rowData.numberOfPosts;
  postobj.monthsFilled = rowData.monthsFilled;
  postobj.numberFilled = rowData.numberFilled;
  postobj.vacant = rowData.vacant.toString();
  postobj.statusId = rowData.statusId;
  postobj.plans = rowData.plans;
  postobj.comments = rowData.comments;
  if (rowData.dateOfVacancies instanceof Date) {
    const year = rowData.dateOfVacancies.getFullYear();
    const month = ('0' + (rowData.dateOfVacancies.getMonth() + 1)).slice(-2); // Adding 1 to month as it's 0-based
    const day = ('0' + rowData.dateOfVacancies.getDate()).slice(-2);
    postobj.dateofVacancies = `${year}-${month}-${day}`;
  }
  else {
    postobj.dateofVacancies = rowData.dateOfVacancies;
  }

  postobj.vacancyReasons = rowData.vacancyReasons;
  postobj.applicationId = this.application.id;
  postobj.financialYearId = this.application.applicationPeriod.financialYear.id;
  postobj.qaurterId = this.quarterId;
  postobj.serviceDeliveryAreaId = this.serviceDeliveryAreaId;


  postobj.isActive = true;
  postobj.id = rowData.id

  if (rowData.id === 0) {
    this.createPost(postobj);
  } else {
    this.updatePost(postobj);
  }
}

createPost(post: IPosts) {
  if(post.numberOfPosts === 0 || post.staffCategoryId === 0 || post.monthsFilled === '' || post.dateofVacancies === '' || post.vacancyReasons === '' || post.plans === '')  
  {
    return;
  }
    this._spinner.show();
    this._applicationRepo.createPost(post).subscribe(
      (resp) => {
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: ' Successfully added.' });
        this.loadPosts();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  
updatePost(post: IPosts) {
    this._applicationRepo.updatePost(post).subscribe(
      (resp) => {
       // this.loadPosts();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Successfully updated.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  
private loadPosts() {
    this._spinner.show();
    this._applicationRepo.getAllPosts(this.application).subscribe(
      (results) => {
        this.posts = results;
        if(this.quarterId > 0)
        {
          this.filteredposts = this.posts.filter(x => x.qaurterId === this.quarterId && x.serviceDeliveryAreaId === this.serviceDeliveryAreaId );
          this.filteredposts.forEach(row => {
            row.isEditable = !(row.id > 0);
          });
          this.rightHeaderChangepost.emit('Pending');
          this.addOther = true;
          const allComplete = this.filteredposts.length > 0 && this.filteredposts.every(dip => dip.statusId === 24);
          const allSubmitted = this.filteredposts.length > 0 && this.filteredposts.every(dip => dip.statusId === 19);
          if (allComplete) {
            this.rightHeaderChangepost.emit('Completed');
            this.addOther = true;
          }
          if (allSubmitted) {
            this.rightHeaderChangepost.emit('Submitted');
            this.addOther = false;
          }
        
          this.cdr.detectChanges();
        }
        });

        this._spinner.hide();
}

onKeyUp(row: any) {
  row.vacant = row.numberOfPosts - row.numberFilled;
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
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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


private setYearRange() {
    let currentDate = new Date;
    let startYear = currentDate.getFullYear() - 5;
    let endYear = currentDate.getFullYear() + 5;

    this.yearRange = `${startYear}:${endYear}`;
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

deletePost(data: IPosts) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.post = this.clonePost(data);
        this.post.isActive = false;
        this.updatePost(this.post);
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

addNewRow() {
    const newRow: IPosts = {
      id: 0,
      staffCategory: {} as IStaffCategory,
      staffCategoryId :0,
      numberOfPosts: 0,
      numberFilled: 0,
      monthsFilled: '',              // Initialized as number
      vacant: '',                 // Default value could be 'Yes' or 'No'
      dateofVacancies: '',           // Can be a string in the form of a date, e.g. '2024-10-01'
      vacancyReasons: '',
      plans: '',
      qaurterId: 0,
      financialYearId: 0,
      applicationId: 0,
      serviceDeliveryAreaId: 0,
      isActive: true,  
      comments: '', 
      status: {} as IStatus,
      statusId :0,
      isEditable:true,
      postAudits:  {} as IPostAudit[]           // Default to active
    };
    this.filteredposts.push(newRow); // Add the new row to the posts array
}

onBlurAdjustedPost(rowData: IPosts) {
    this.savePost(rowData);
}

disableSubProgrammeType(): boolean {
    if (this.filteredSubProgrammeTypes.length > 0)
      return false;

    return true;
}

addComment() {
  if (this.selectedPost.comments != null) {
    this.comment = this.selectedPost.comments;
  }
  else{
    this.comment= null;
  }

  this.displayCommentDialog = true;
  this.canEdit = true;
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
    // if (!this.comment)
    //   return true;

    return false;
}

saveComment(changesRequired: boolean, origin: string) {
  this.selectedPost.comments = this.comment;
  this.savePost(this.selectedPost);
  this.displayCommentDialog = false;
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

private loadStaffCategories() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.StaffCategory, false).subscribe(
      (results) => {
        // Map the results to the format expected by the p-dropdown
        this.staffCategories = results.map((item: IStaffCategory) => ({
          label: item.name,   // Display the staff category name in the dropdown
          value: item.id      // Bind the staff category ID as the value
        }));
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
}

  // private loadStaffCategories() {
  //   this._dropdownRepo.getEntities(DropdownTypeEnum.StaffCategory, false).subscribe(
  //     (results) => {
  //       this.staffCategories = results;
  //       console.log('staff', this.staffCategories);

  //     },
  //     (err) => {
  //       this._loggerService.logException(err);
  //       this._spinner.hide();
  //     }
  //   );
  // }

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



