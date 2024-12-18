import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DropdownTypeEnum, FacilityTypeEnum, RecipientEntityEnum, RoleEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IActivityDistrict, IActivityFacilityList, IActivityList, IActivityManicipality, IActivityRecipient, IActivitySubDistrict, IActivitySubProgramme, IActivitySubStructure, IActivityType, IApplication, IApplicationComment, IApplicationReviewerSatisfaction, IArea, IDistrictDemographic, IFacilityDistrict, IFacilityList, IFacilitySubDistrict, IFacilitySubStructure, IManicipalityDemographic, INpo, IObjective, IRecipientType, ISubDistrictDemographic, ISubProgramme, ISubstructureDemographic } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { FilterService } from 'primeng/api';

@Component({
  selector: 'app-activities',
  templateUrl: './activities.component.html',
  styleUrls: ['./activities.component.css'],
  providers: [FilterService]
})
export class ActivitiesComponent implements OnInit {

  // districts: any[] = [
  //   { name: 'District 1', code: 'D1' },
  //   { name: 'District 2', code: 'D2' }
  // ];

  // subDistricts: any[] = [];
  // subStructures: any[] = [];

  // allSubDistricts: any[] = [
  //   { name: 'Sub District 1-1', code: 'SD1', districtCode: 'D1' },
  //   { name: 'Sub District 1-2', code: 'SD2', districtCode: 'D1' },
  //   { name: 'Sub District 2-1', code: 'SD3', districtCode: 'D2' }
  // ];

  // allSubStructures: any[] = [
  //   { name: 'Sub Structure 1-1-1', code: 'SS1', subDistrictCode: 'SD1' },
  //   { name: 'Sub Structure 1-1-2', code: 'SS2', subDistrictCode: 'SD1' },
  //   { name: 'Sub Structure 2-1-1', code: 'SS3', subDistrictCode: 'SD3' }
  // ];

  // selectedDistricts: any[] = [];
  // selectedSubDistricts: any[] = [];
  // selectedSubStructures: any[] = [];

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
  originalActiveActivities: IActivity[];
  deletedActivities: IActivity[];

  activityCols: any[];
  displayActivityDialog: boolean;
  newActivity: boolean;
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

  allSubProgrammes: ISubProgramme[];
  subProgrammes: ISubProgramme[] = [];
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
  SubDistrictDemographicsBeforeFilter: ISubDistrictDemographic[];

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
  allAreas : IArea[];
  selectedAreas: IArea[];
  AreaDemographics: IArea[];
  SubDistrictDemographics: ISubDistrictDemographic[];
  selectedSubDistrictDemographics: ISubDistrictDemographic[];

  allSubstructureDemographics: ISubstructureDemographic[];
  SubstructureDemographics: ISubstructureDemographic[];
  selectedSubstructureDemographics: ISubstructureDemographic[];

  allManicipalityDemographics: IManicipalityDemographic[];
  ManicipalityDemographics: IManicipalityDemographic[];
  selectedManicipalityDemographics: IManicipalityDemographic[];

  showSubstructureDemographics: boolean = false;  // Control visibility for Sub Structures
  showAreaDemographics: boolean = false;  // Control visibility for Area

  //activeActivities: any[] = []; // All activities
  filteredActivities: any[] = []; // Filtered activities
  filteredData: any[] = [];

  public get FacilityTypeEnum(): typeof FacilityTypeEnum {
    return FacilityTypeEnum;
  }
  //
  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private _applicationRepo: ApplicationService,
    private _datepipe: DatePipe,
    private _loggerService: LoggerService,
    private _npoRepo: NpoService,
    private filterService: FilterService
  ) { }

  ngOnInit(): void {
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
    this.loadActivityTypes();
    this.loadFacilities();
    this.setYearRange();
    this.loadAllSubProgrammes();
    this.loadFacilityDistricts();
    this.loadFacilitySubDistricts();
    this.loadFacilitySubStructures();
    this.loadDemographicDistricts();
    this.loadDemographicSubStructures();
    this.loadDemographicManicipalities();
    this.loadDemographicSubDistricts();
    this.loadAreas();

    this.activityCols = [
      { header: 'Activity Name', width: '15%' },
      { header: 'Activity Type', width: '10%' },
      { header: 'Timeline', width: '10%' },
      { header: 'Target', width: '10%' },
      { header: 'Facilities and/or Community Places', width: '15%' },


      { header: 'District Name', width: '10%' },
      { header: 'Municipalities', width: '10%' },
      { header: 'Areas', width: '10%' },
      { header: 'Sub Structures ', width: '10%' },
      { header: 'Sub Districts', width: '10%' },
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
  
    // Reset the table when no items are selected (i.e., deselect all)
    if (!selectedItems || selectedItems.length === 0) {
      this.filteredData = [...this.originalActiveActivities];  // Reset to the original data
    } else {
      // Apply the filter
      this.filteredData = this.filterService.filter(this.originalActiveActivities, filterFields, selectedItems, 'custom');
    }
  
    // Reapply filters
    this.applyCustomFilters();
  }
  

  // onCustomFilterChange(selectedItems: any[], field: string) {
  //   const filterFields = [field];
  //   this.filteredData = this.filterService.filter(this.activeActivities, filterFields, selectedItems || [], 'custom');

  //   this.applyCustomFilters();
  // }
  
  applyCustomFilters() {
    this.activeActivities = this.filteredData;
    this.updateRowGroupMetaData();  // Update metadata based on the filtered data
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  private loadDemographicDistricts() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DemographicDistrict, false).subscribe(
      (results) => {
        this.allIDistrictDemographics = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadDemographicManicipalities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DemographicManicipality, false).subscribe(
      (results) => {
        this.allManicipalityDemographics = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  
  private loadDemographicSubStructures() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DemographicSubStructure, false).subscribe(
      (results) => {
        this.allSubstructureDemographics = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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
        // if (this.selectedFacilities.length === 0) {
        //     this.facilities = [];
        // }
        
    // let allFacilities: string = "";
    // this.selectedFacilities.forEach(item => {
    //   allFacilities += item.name + "\n";
    // });
    // this.selectedFacilitiesText = allFacilities;


    } else {

    }
}

preventChange(event: any): void {
  event.originalEvent.preventDefault(); 
  event.value = [...this.selectedFacilities];
}

  private loadDemographicSubDistricts() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DemographicSubDistrict, false).subscribe(
      (results) => {
        this.allSubDistrictDemographics = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadAreas() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Area, false).subscribe(
      (results) => {
        this.allAreas = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

// Method to handle changes when Demographic District is changed
onDemographicDistrictChange() {
  if(this.selectedIDistrictDemographics.isSubParent)
  {
    this.showSubstructureDemographics = false;
    this.showAreaDemographics = true;
  }
  else {
    this.showSubstructureDemographics = true;
    this.showAreaDemographics = false;
  }

  this.selectedManicipalityDemographics = [];
  this.selectedSubstructureDemographics = [];
  this.selectedSubDistrictDemographics = [];
  this.selectedAreas = [];

  if (this.selectedIDistrictDemographics) {
    // Filter ManicipalityDemographics based on selected District

  if(this.selectedIDistrictDemographics.isSubParent) {
      this.ManicipalityDemographics = this.allManicipalityDemographics.filter(md =>
        md.subParentiId === this.selectedIDistrictDemographics.id
      );
  } else {
    this.ManicipalityDemographics = this.allManicipalityDemographics.filter(md =>
      md.districtDemographicId === this.selectedIDistrictDemographics.id
    );
  }

  this.AreaDemographics = this.allAreas.filter(md =>
    md.districtId === this.selectedIDistrictDemographics.id
  );

    // Reset other arrays
    this.SubDistrictDemographics = [];
    this.SubstructureDemographics = [];
  } else {
    // Reset all arrays if no district is selected
    this.ManicipalityDemographics = [];
    this.AreaDemographics = [];
    this.SubDistrictDemographics = [];
    this.SubstructureDemographics = [];
  }
}

onAreaChange() {
  this.selectedSubDistrictDemographics = [];
  if (this.selectedAreas && this.selectedAreas.length > 0) {
    this.SubDistrictDemographics = this.allSubDistrictDemographics.filter(sd =>
      this.selectedAreas.some(ss => ss.id === sd.areaId)
    );
  } else {
    this.SubDistrictDemographics = [];
  }
}

onDemographicSubStructuresChange() {
  this.selectedSubDistrictDemographics = [];
  if (this.selectedSubstructureDemographics && this.selectedSubstructureDemographics.length > 0) {
    this.SubDistrictDemographics = this.allSubDistrictDemographics.filter(sd =>
      this.selectedSubstructureDemographics.some(ss => ss.id === sd.subSctrcureDemographicId)
    );
  } else {
    // Reset all arrays if no sub-structure demographic is selected
    this.SubDistrictDemographics = [];
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


  private loadFacilitySubStructures() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilitySubStructure, false).subscribe(
      (results) => {
        this.allFacilitySubStructures = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadFacilityDistricts() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilityDistricts, false).subscribe(
      (results) => {
        this.facilityDistricts = results;
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

  private loadFacilitySubDistricts() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilitySubDistricts, false).subscribe(
      (results) => {
        this.allFacilitySubDistricts = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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
        this.loadRecipientTypes();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadActivityTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.ActivityTypes, false).subscribe(
      (results) => {
        this.activityTypes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadRecipientTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.RecipientTypes, false).subscribe(
      (results) => {
        this.recipientTypes = results.filter(x => x.isActive);
        this.loadObjectives();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadObjectives() {
    this._applicationRepo.getAllObjectives(this.application).subscribe(
      (results) => {
        this.objectives = results.filter(x => x.isActive === true);
        this.loadActivities();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadActivities() {
    this._spinner.show();
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.allActivities = results;
        this.activeActivities = this.allActivities.filter(x => x.isActive === true);
        this.activeActivities.forEach(item => {
          item.mappedDistrict = this.getSubDistrictNames(item?.activityDistrict),
          item.mappedManicipality = this.getSubDistrictNames(item?.activityManicipality),
          item.mappedSubstructure = this.getSubDistrictNames(item?.activitySubStructure),
          item.mappedSubdistrict =this.getSubDistrictNames(item?.activitySubDistrict),
          item.mappedArea =this.getSubDistrictNames(item?.activityArea)
        });

        this.originalActiveActivities =  this.activeActivities;

        this.getFacilityListText(results);
        this.updateRowGroupMetaData();
        this._spinner.hide();
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

  addActivity() {
    this.newActivity = true;
    this.activity = {
      activitySubProgrammes: [] as IActivitySubProgramme[],
      activityFacilityLists: [] as IActivityFacilityList[],
      activityDistrict: [] as IActivityDistrict[],
      activityManicipality: [] as IActivityManicipality[],
      activitySubDistrict: [] as IActivitySubDistrict[],
      activitySubStructure: [] as IActivitySubStructure[],
    } as IActivity;
    
    this.selectedObjective = null;
    this.selectedActivityType = null;
    this.selectedFacilities = [];
    this.subProgrammes = [];
    this.selectedSubProgrammes = [];
    this.selectedActivity = null;

    this.recipients = [];
    this.selectedRecipients = [];

    this.displayActivityDialog = true;

    if (this.application.isCloned)
      this.activity.isNew = this.activity.isNew == undefined ? true : this.activity.isNew;
  }

  editActivity(data: IActivity) {
    this.newActivity = false;
    this.activity = this.cloneActivity(data);
    this.selectedActivity = null;

    if (this.application.isCloned)
      this.activity.isNew = this.activity.isNew == undefined ? false : this.activity.isNew;

    this.displayActivityDialog = true;
  }

  private cloneActivity(data: IActivity): IActivity {
    data.name = data.activityList.name;
    data.description = data.activityList.description;

    let activity = {} as IActivity;

    for (let prop in data)
      activity[prop] = data[prop];

    this.selectedObjective = this.objectives.find(x => x.id === data.objectiveId);
    this.objectiveChange(this.selectedObjective);
    this.selectedActivityType = data.activityType;

    const facilityListIds = data.activityFacilityLists.map(({ facilityListId }) => facilityListId);
    this.selectedFacilities = this.facilities.filter(item => facilityListIds.includes(item.id));

    const subProgrammeIds = data.activitySubProgrammes.map(({ subProgrammeId }) => subProgrammeId);
    this.selectedSubProgrammes = this.subProgrammes.filter(item => subProgrammeIds.includes(item.id));

    this.buildRecipientDropdown(this.selectedObjective, data);
    
    this.selectedRecipients = this.recipients.filter(item => {
      return data.activityRecipients.some(recipient => {
        return recipient.activityId === item.activityId && recipient.entityId === item.entityId && recipient.recipientTypeId === item.recipientTypeId
      })
    });

    this.getTextValues();
    // Handle selected district
    const districtId = data?.activityDistrict?.find(district => district.isActive)?.demographicDistrictId;
    this.selectedIDistrictDemographics = this.allIDistrictDemographics.find(item => item.id === districtId);
    
    if (this.selectedIDistrictDemographics) {
      this.ManicipalityDemographics = this.allManicipalityDemographics.filter(md =>
        md.districtDemographicId === this.selectedIDistrictDemographics.id
      );

      this.AreaDemographics = this.allAreas.filter(md =>
        md.districtId === this.selectedIDistrictDemographics.id
      );

      if(this.selectedIDistrictDemographics.isSubParent)
        {
          this.showSubstructureDemographics = false;
          this.showAreaDemographics = true;
        }
        else {
          this.showSubstructureDemographics = true;
          this.showAreaDemographics = false;
        }

      if(this.selectedIDistrictDemographics.isSubParent) {
        this.ManicipalityDemographics = this.allManicipalityDemographics
        ?.filter(md =>
          md.subParentiId === this.selectedIDistrictDemographics.id
        );
        } else {
          this.ManicipalityDemographics = this.allManicipalityDemographics?.filter(md =>
            md.districtDemographicId === this.selectedIDistrictDemographics.id
          );
        }
      this.SubDistrictDemographics = [];
      this.SubstructureDemographics = [];
    } else {
      this.ManicipalityDemographics = [];
      this.SubDistrictDemographics = [];
      this.SubstructureDemographics = [];
    }

    const demographicDistrictIds = data?.activityManicipality?.map(({ demographicDistrictId }) => demographicDistrictId);
    this.selectedManicipalityDemographics = this.ManicipalityDemographics?.filter(item =>
        demographicDistrictIds.includes(item.districtDemographicId) && 
        data.activityManicipality.some(({ name }) => name === item.name)
    );
    const demographicDistrictIds1 = data?.activityArea?.map(({ demographicDistrictId }) => demographicDistrictId);
    this.selectedAreas = this.AreaDemographics?.filter(item =>
      demographicDistrictIds1.includes(item.districtId) && 
        data.activityArea?.some(({ name }) => name === item.name)
    );
    
    this.onDemographicManicipalitiesChange();
    if(this.selectedIDistrictDemographics?.isSubParent) {
      this.onAreaChange();
      }

    const subStructureIds = data?.activitySubStructure?.map(({ municipalityId }) => municipalityId);
    this.selectedSubstructureDemographics = this.SubstructureDemographics?.filter(item =>
        subStructureIds.includes(item.manicipalityDemographicId) && 
        data.activitySubStructure.some(({ name }) => name === item.name)
    );
    if(!this.selectedIDistrictDemographics?.isSubParent) {
      this.onDemographicSubStructuresChange();
      }
    const substructureId = data?.activitySubDistrict?.map(({ substructureId }) => substructureId);
    const areaid = data?.activitySubDistrict?.map(({ areaId }) => areaId);

    if(areaid.length > 0) {
      this.selectedSubDistrictDemographics = this.SubDistrictDemographics?.filter(item =>
        areaid.includes(item.areaId) && 
      data.activitySubDistrict.some(({ name }) => name === item.name)
     );
    }else{
      this.selectedSubDistrictDemographics = this.SubDistrictDemographics?.filter(item =>
        substructureId.includes(item.subSctrcureDemographicId) && 
      data.activitySubDistrict.some(({ name }) => name === item.name)
     );
    }
    return activity;
  }

  getTextValues() {
    let allSubProgrammes: string = "";
    let allFacilities: string = "";
    let allRecipients: string = "";

    this.selectedSubProgrammes.forEach(item => {
      allSubProgrammes += item.name + ", ";
    });

    this.selectedFacilities.forEach(item => {
      allFacilities += item.name + ";\n";
    });

    this.selectedRecipients.forEach(item => {
      allRecipients += item.recipientName + ";\n";
    });

    this.selectedSubProgrammesText = allSubProgrammes.slice(0, -2);
    this.selectedFacilitiesText = allFacilities;
    this.selectedRecipientsText = allRecipients;
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

  deleteActivity(data: IActivity) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.activity = this.cloneActivity(data);
        this.activity.isActive = false;
        this.updateActivity();
      },
      reject: () => {
      }
    });
  }

  disableSaveActivity() {
    let data = this.activity;

    if (!this.selectedObjective || this.selectedSubProgrammes.length === 0 || !data.name || !data.description || !this.selectedActivityType || !data.timelineStartDate || !data.timelineEndDate || !data.target || this.selectedFacilities.length === 0 || this.selectedRecipients.length === 0)
      return true;

    return false;
  }

  saveActivity() {
    this.activity.objective = null;
    this.activity.activityType = null;
    this.activity.changesRequired = this.activity.changesRequired == null ? null : false;
    this.activity.activityList = null;

    this.activity.objectiveId = this.selectedObjective.id;
    this.activity.activityTypeId = this.selectedActivityType.id;
    this.activity.isActive = true;

    this.activity.timelineStartDate = this._datepipe.transform(this.activity.timelineStartDate, 'yyyy-MM-dd');
    this.activity.timelineEndDate = this._datepipe.transform(this.activity.timelineEndDate, 'yyyy-MM-dd');

    // this.activity.activitySubProgrammes = [];
    // this.selectedSubProgrammes.forEach(item => {
    //   let activitySubProgramme = {
    //     activityId: this.activity.id,
    //     subProgrammeId: item.id,
    //     isActive: true
    //   } as IActivitySubProgramme;

    //   this.activity.activitySubProgrammes.push(activitySubProgramme);
    // });

    this.activity.activityFacilityLists = [];
    this.selectedFacilities.forEach(item => {
      let activityFacilityList = {
        activityId: this.activity.id,
        facilityListId: item.id,
        isActive: true
      } as IActivityFacilityList;

      this.activity.activityFacilityLists.push(activityFacilityList);
    });

this.activity.activityRecipients = this.selectedRecipients;

// Initialize the array
this.activity.activityDistrict = [];

//Check if selectedIDistrictDemographics is not null
if (this.selectedIDistrictDemographics) {
  // Create the IActivityDistrict object from the selected district
  let activityDistrict = {
    demographicDistrictId: this.selectedIDistrictDemographics.id,
    name: this.selectedIDistrictDemographics.name,
    isActive: this.selectedIDistrictDemographics.isActive,
    activityId: this.activity.id,
  } as IActivityDistrict;

//   // Push the object into the array
  this.activity.activityDistrict.push(activityDistrict);
}

  this.activity.activityManicipality = [];

  this.selectedManicipalityDemographics.forEach(item => {
    let activityManicipality = {
      demographicDistrictId: item.districtDemographicId,
      name: item.name,
      isActive: item.isActive,
      activityId: this.activity.id,
    } as IActivityManicipality;

    this.activity.activityManicipality.push(activityManicipality);
  });
  
  this.activity.activitySubStructure = [];
  this.selectedSubstructureDemographics.forEach(item => {
    let selectedSubStructure = {
      name: item.name,
      municipalityId: item.manicipalityDemographicId,
      isActive: item.isActive,
      activityId: this.activity.id,
    } as IActivitySubStructure;

    this.activity.activitySubStructure.push(selectedSubStructure);
  });
  
  this.activity.activityArea = [];
  this.selectedAreas.forEach(item => {
    let selectedArea = {
      name: item.name,
      isActive: item.isActive,
      activityId: this.activity.id,
      demographicDistrictId: item.districtId,
    } as IArea;

    this.activity.activityArea.push(selectedArea);
  });
  

  this.activity.activitySubDistrict = [];
  this.selectedSubDistrictDemographics.forEach(item => {
    if(item.areaId > 0)
    {
      let selectedSubDistrict = {
        name: item.name,
        areaId: item.areaId,
        isActive: item.isActive,
        activityId: this.activity.id
      } as IActivitySubDistrict;
      this.activity.activitySubDistrict.push(selectedSubDistrict);
    }
    else {
      let selectedSubDistrict = {
        name: item.name,
        substructureId: item.subSctrcureDemographicId,
        isActive: item.isActive,
        activityId: this.activity.id
      } as IActivitySubDistrict;
      this.activity.activitySubDistrict.push(selectedSubDistrict);
    }
  });


this._dropdownRepo.createActivityList({ name: this.activity.name, description: this.activity.description, isActive: true } as IActivityList).subscribe(
  (resp) => {
    this.activity.activityListId = resp.id;
    this.newActivity ? this.createActivity() : this.updateActivity();
    this.displayActivityDialog = false;

    let allFacilities: string = "";
    this.selectedFacilities.forEach(item => {
      allFacilities += item.name + "\n";
    });
    this.selectedFacilitiesText = allFacilities;
  },
  (err) => {
    this._loggerService.logException(err);
    this._spinner.hide();
  }
);
}

  private createActivity() {
    this._applicationRepo.createActivity(this.activity, this.application).subscribe(
      (resp) => {
        this.loadActivities();
        this.activityChange.emit(this.activity);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateActivity() {
    this._applicationRepo.updateActivity(this.activity).subscribe(
      (resp) => {
        this.loadActivities();
        this.activityChange.emit(this.activity);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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
        this.loadActivities();

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
            this.loadActivities();

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
    return this.application.isCloned && this.isReview ? 12 : 15;
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
                this.loadActivities();
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
