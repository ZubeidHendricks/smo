import { IApplicationDetails, IFundAppSDADetail, IPlace, IProgrammeServiceDelivery, ISDA, ISubPlace, ISubProgrammeType, } from './../../../../../models/interfaces';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { AccessStatusEnum, DropdownTypeEnum, PermissionsEnum, StatusEnum } from 'src/app/models/enums';
import {
  IFinancialYear, IProgramme, IDepartment, ISubProgramme, IApplicationType, IApplicationPeriod,
  IMonitoringAndEvaluation, IProjectInformation, IUser, IDistrictCouncil, ILocalMunicipality, IFundingApplicationDetails, IApplication, IRegion
} from 'src/app/models/interfaces';
import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { FinancialMatters, IPreviousFinancialYear, ISourceOfInformation, IAffiliatedOrganisation } from 'src/app/models/FinancialMatters';
import { Table } from 'primeng/table';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-application-details',
  templateUrl: './application-details.component.html',
  styleUrls: ['./application-details.component.css']
})
export class ApplicationDetailsComponent implements OnInit {
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

  @Input() isReadOnly: boolean;
  @Input() Amount: number;

  @Output() AmountChange = new EventEmitter();
  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Output() fundingApplicationDetailsChange: EventEmitter<IFundingApplicationDetails> = new EventEmitter<IFundingApplicationDetails>();
  application: IApplication;
  canEdit: boolean = false;

  @Output() getPlace = new EventEmitter<IPlace[]>(); // try to send data from child to child via parent
  @Output() getSubPlace = new EventEmitter<ISubPlace[]>();

  @Input() isEdit: boolean;

  dropdownTouched: boolean = false;
  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  applicationPeriod: IApplicationPeriod = {} as IApplicationPeriod;

  amountApplyingFor: number;
  menuActions: MenuItem[];
  profile: IUser;
  validationErrors: Message[];
  selectedApplicationId: string;
  applicationPeriodId: number;
  paramSubcriptions: Subscription;
  isDataAvailable: boolean = false;
  specify: string;
  affiliatedOrganisation: string;
  contactPerson: string;
  EmailAddress: string;
  telephone: string;
  website: string;
  affliatedOrganisationInfo: IAffiliatedOrganisation[];
  sourceOfInformation: ISourceOfInformation[];
  sourceOfInformations: ISourceOfInformation = {} as ISourceOfInformation;
  entities: IDistrictCouncil[];
  entity: IDistrictCouncil = {} as IDistrictCouncil;
  sourceOfInformationText: string;
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
  applicationTypes: IApplicationType[];
  selectedApplicationType: IApplicationType;
  stateOptions: any[];

  finYearRange: string;

  subProgrammeType: ISubProgrammeType[];
  filteredSubProgrammeType: ISubProgrammeType[];
  selectedSubProgrammeType: ISubProgrammeType;

  // Highlight required fields on validate click
  validated: boolean = false;
  allDistrictCouncils: IDistrictCouncil[];
  selectedDistrictCouncil: IDistrictCouncil;

  localMunicipalitiesAll: ILocalMunicipality[];
  localMunicipalities: ILocalMunicipality[] = [];
  selectedLocalMunicipality: ILocalMunicipality;

  regionsAll: IRegion[];
  regions: IRegion[] = [];
  selectedRegions: IRegion[];
  selectedRegs: IRegion[] = [];
  selectedLocalMunicipalitiesText: string;
  selectedRegionsText: string;
  selectedSDAsText: string;
  selectedDropdownValue: string;
  sdasAll: ISDA[];
  sdas: ISDA[] = [];
  selectedSdas: ISDA[];
  selected: ISDA[] = [];
  programDeliveryDetails : IProgrammeServiceDelivery[];

  places: IPlace[] = [];
  subPlacesAll: ISubPlace[];

  @Output() applicationDetailsChange: EventEmitter<IFundingApplicationDetails> = new EventEmitter<IFundingApplicationDetails>();
  selectedOption: string = '';

  allApplicationPeriods: IApplicationPeriod[];
  cols: any[];

  selectedSubProgram: any;
  filterSubProgramIds: string;
  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _applicationPeriodRepo: ApplicationPeriodService,
    private _activeRouter: ActivatedRoute,
    private _fundAppService: FundingApplicationService,
    private _bidService: BidService,
    private _messageService: MessageService,
    private _loggerService: LoggerService,
    private _npoProfile: NpoProfileService,
    private _datepipe: DatePipe
  ) { }

  getSelectedValue(value: string) {
    this.selectedDropdownValue = value;
  }
  ngOnInit(): void {
    this._spinner.show();
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.selectedApplicationId = params.get('id');
    });
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;
        this.loadDepartments();
        this.loadApplicationTypes();
        this.loadApplicationPeriod();
        this.loadApplicationPeriods();
        this.buildMenu();
        let amountStringId = (<HTMLInputElement>document.getElementById("amountApplyingFor"));
        amountStringId.focus();
        //Get all district councils
        this.loadDistrictCouncils();
        //Gel all local municipalities
        this.loadMunicipalities();
        //Get all regions
        this.regionDropdown();
        //Get all service delivery areas
        this.loadServiceDeliveryAreas();
        this.GetAffiliatedOrganisation();
        this.GetSourceOfInformation();
        this.loadApplication();
      }
    });

    this.stateOptions = [
      {
        label: 'Yes',
        value: 'Yes'
      },
      {
        label: 'No',
        value: 'No'
      }
    ];

    this.cols = [
      { field: 'refNo', header: 'Ref. No.', width: '10%' },
      { field: 'name', header: 'Name', width: '30%' },
      { field: 'applicationType.name', header: 'Type', width: '15%' },
      { field: 'financialYear.name', header: 'Financial Year', width: '8%' },
      { field: 'openingDate', header: 'Opening Date', width: '10%' },
      { field: 'closingDate', header: 'Closing Date', width: '10%' },
      { field: 'status', header: 'Status', width: '5%' }
    ];
  }




  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.selectedApplicationId)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
          this._bidService.getApplicationBiId(results.id).subscribe(response => {
            if (response.id != null) {
              this.getFundingApplicationDetails(response);
            }
          });
        }
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private getFundingApplicationDetails(data) {
    this._bidService.getBid(data.id).subscribe(response => {

      this.getBidFullObject(response)
    });

  }

  private getBidFullObject(data) {
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

  private bidForm(status: StatusEnum) {
    this.application.status = null;
    this.application.statusId = status;
    const applicationIdOnBid = this.fundingApplicationDetails;

    if (applicationIdOnBid.id == null) {
      this._bidService.addBid(this.fundingApplicationDetails).subscribe(resp => {
      //  this._menuActions[1].visible = false;
      this._router.navigateByUrl(`application/edit/${this.application.id}/${this.activeStep}`); 
      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
        resp;
      });
    }
    else {
      this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => {
        if (resp) {
          this._router.navigateByUrl(`application/edit/${this.application.id}/${this.activeStep}`);
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
        }
      });
    }
    if (status == StatusEnum.PendingReview) {

      this.application.statusId = status;
      this._applicationRepo.updateApplication(this.application).subscribe();
      this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
      this._router.navigateByUrl('applications');
    };
  }

  onAmountChange(event) {
    let amount = Number(event).valueOf();
    this.Amount = amount;
    this.AmountChange.emit(this.Amount);
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
            //            this.saveFundingApplicationDetails();
          }
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

  showTable(obj: any) {
    if (obj.value === "Yes")
      document.getElementById('affliatedOrganisationInfoTable').hidden = false;
    else
      document.getElementById('affliatedOrganisationInfoTable').hidden = true;
  }

  private formValidate() {
    this.validated = true;
    this.validationErrors = [];

    let data = this.applicationPeriod;

    if (!this.selectedDepartment || !this.selectedProgramme || !this.selectedSubProgramme || !this.selectedApplicationType || !data.name || !data.description || !this.selectedFinancialYear)
      this.validationErrors.push({ severity: 'error', summary: "Application Details:", detail: "Missing detail required." });

    if (this.validationErrors.length == 0)
      this.menuActions[1].visible = false;
    else
      this.menuActions[1].visible = true;
  }

  private clearMessages() {
    this.validated = false;
    this.validationErrors = [];
    this.menuActions[1].visible = false;
  }

  private saveItems() {
    if (this.canContinue()) {
      this._spinner.show();

      this.application.statusId = StatusEnum.Saved;

      this._applicationRepo.updateApplication(this.application).subscribe(
        (resp) => {
          //  if (resp.statusId === StatusEnum.Saved) {
          this._spinner.hide();
          this.menuActions[1].visible = false;
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
          //   }

          if (resp.statusId === StatusEnum.PendingReview) {
            this._spinner.hide();
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

  private canContinue() {
    this.formValidate();

    if (this.validationErrors.length == 0)
      return true;

    return false;
  }

  private loadFinancialYears(financialYear: IFinancialYear) {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        this.financialYears = results;
        this.getFinancialYearRange(financialYear);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadDepartments() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Departments, false).subscribe(
      (results) => {
        this.departments = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadApplicationTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.ApplicationTypes, false).subscribe(
      (results) => {
        this.applicationTypes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProgrammes(departmentId: number) {
    if (departmentId != null) {
      this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
        (results) => {
          this.allProgrammes = results;
          this.programmes = results.filter(x => x.departmentId === departmentId);
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadSubProgrammes(programmeId: number) {
    if (programmeId != null) {
      this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
        (results) => {
          this.allSubProgrammes = results;
          this.subProgrammes = results.filter(x => x.programmeId === programmeId);
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadApplicationPeriod() {
    this._applicationRepo.getApplicationById(Number(this.selectedApplicationId)).subscribe(
      (results) => {
        if (results != null) {
          this.applicationPeriodId = results.applicationPeriodId;
          this.loadApplicationPeriodById(this.applicationPeriodId);
        } this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
      });
  }

  private loadApplicationPeriodById(applnPeriodId: number) {
    if (applnPeriodId != null) {
      this._applicationPeriodRepo.getApplicationPeriodById(applnPeriodId).subscribe(
        (results) => {
          this.loadFinancialYears(results.financialYear);
          this.loadProgrammes(results.departmentId);
          this.loadSubProgrammes(results.programmeId);
          this.loadSubProgrammeTypes(results.subProgrammeId);
          this.selectedDepartment = results.department;
          this.selectedProgramme = results.programme;
          this.selectedSubProgramme = results.subProgramme;
          this.selectedFinancialYear = results.financialYear;
          this.selectedApplicationType = results.applicationType;
          this.applicationPeriod = results;
          this.isDataAvailable = true;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          //this._spinner.hide();
        }
      );
    }
  }
  departmentChange(department: IDepartment) {
    this.selectedProgramme = null;
    this.selectedSubProgramme = null;
    this.programmes = [];
    this.subProgrammes = [];
    if (department.id != null) {
      for (var i = 0; i < this.allProgrammes.length; i++) {
        if (this.allProgrammes[i].departmentId == department.id) {
          this.programmes.push(this.allProgrammes[i]);
        }
      }
    }
  }

  programmeChange(programme: IProgramme) {
    this.selectedSubProgramme = null;
    this.subProgrammes = [];
    if (programme.id != null) {
      for (var i = 0; i < this.allSubProgrammes.length; i++) {
        if (this.allSubProgrammes[i].programmeId == programme.id) {
          this.subProgrammes.push(this.allSubProgrammes[i]);
        }
      }
    }
  }
  financialYearChange(finYear: IFinancialYear) {
    this.getFinancialYearRange(finYear);
  }

  private getProgrammeDeliveryDetails() {
    this._npoProfile.getProgrammeDeliveryDetails(Number(this.selectedApplicationId)).subscribe(
      (results) => {
        if (results != null) {
          this.programDeliveryDetails = results.filter(deliveryDetail => deliveryDetail.approvalStatus.id === AccessStatusEnum.Approved);
        } this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
      });
  }

  getNames(array: any[]): string {
    const names = array.map(item => item.name) // Access 'name' directly
                       .filter(name => name !== undefined && name.trim() !== '') // Filter out undefined or empty strings
                       .join(', '); // Join the names with a comma
  
    return names; // Return the joined names as a string
  }

  private getFinancialYearRange(finYear: IFinancialYear) {
    if (this.financialYears.length > 0) {
      let start = this.financialYears.find(x => x.id === finYear.id);
      let end = this.financialYears[this.financialYears.length - 1];
      this.finYearRange = `${start.year}:${end.year}`;
    }
  }

  private loadDistrictCouncils() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DistrictCouncil, false).subscribe(
      (results) => {
        this.allDistrictCouncils = results;
        this.allDropdownsLoaded();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadMunicipalities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.LocalMunicipality, false).subscribe(
      (results) => {
        this.localMunicipalitiesAll = results;
        this.allDropdownsLoaded();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  private regionDropdown() {

    this._dropdownRepo.getEntities(DropdownTypeEnum.Region, false).subscribe(
      (results) => {
        this.regionsAll = results;
        this.allDropdownsLoaded();
      },
      (err) => err
    );
  }

  private loadServiceDeliveryAreas() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.ServiceDeliveryArea, false).subscribe(
      (results) => {
        this.sdasAll = results;
        this.allDropdownsLoaded();

      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  readonly(): boolean {
    // if (this.application.statusId == StatusEnum.PendingReview ||
    //  this.application.statusId == StatusEnum.Approved )
    //  return true;
    // else return false;
    return false;
  }



  nextPage() {
    this.activeStep = this.activeStep + 1;
    this.bidForm(StatusEnum.Saved);
    this.activeStepChange.emit(this.activeStep);
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  private allDropdownsLoaded() {
    if (this.allDistrictCouncils?.length > 0 &&
      this.localMunicipalitiesAll?.length > 0 &&
      this.regionsAll?.length > 0 && this.sdasAll?.length > 0) {

      if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil.id != undefined)
        this.OnDistrictCouncilChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil);

      if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality.id != undefined)
        this.onLocalMunicipalityChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality);

      if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions?.length > 0)
        this.onRegionChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions);

      if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas?.length > 0)
        this.onSdaChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas);
    }
  }

  onLocalMunicipalityChange(localMunicipality: ILocalMunicipality) {
    this.selectedLocalMunicipality = this.localMunicipalitiesAll.find(x => x.id === localMunicipality.id);
    if (this.selectedLocalMunicipality == null) {
      this.regions = null;
      this.sdas = null;
    }
    if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail != null)
      this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = localMunicipality;

    if (localMunicipality.id != undefined) {

      this.regions = this.regionsAll?.filter(x => x.localMunicipalityId == localMunicipality.id);
    }
  }


  OnDistrictCouncilChange(districtCouncil: IDistrictCouncil) {
    this.selectedDistrictCouncil = this.allDistrictCouncils.find(x => x.id === districtCouncil.id);
    this.localMunicipalities = [];
    this.sdas = null;
    this.selectedRegions = null;
    this.selectedSdas = null;
    this.selected = null;
    this.regions = null;
    this.sdas = null;

    if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail != null)
      this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil = districtCouncil;

    if (districtCouncil.id != undefined) {

      this.localMunicipalities = this.localMunicipalitiesAll?.filter(x => x.districtCouncilId == districtCouncil.id);
    }
  }


  onRegionChange(regions: IRegion[]) {

    // this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = regions;
    this.selectedRegions = [];
    this.selectedSdas = [];
    this.selected = [];
    this.sdas = [];

    regions.forEach(item => {
      this.selectedRegions = this.selectedRegions.concat(this.regionsAll.find(x => x.id === item.id));
    });
    if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail != null)
      this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = this.selectedRegions;

    // filter items matching the selected regions
    if (regions != null && regions.length != 0) {
      for (var i = 0; i < this.sdasAll.length; i++) {
        if (regions.filter(r => r.id === this.sdasAll[i].regionId).length != 0) {
          this.sdas.push(this.sdasAll[i]);
        }
      }
    }

    this.selected = [];
    for (var i = 0; i < regions?.length; i++) {
      for (var j = 0; j < this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas.length; j++) {
        if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas[j].regionId == regions[i].id) {
          this.selected.push(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas[j]);
        }
      }
    }
    // make sure the selected is not redundant!!
    const ids = this.selected.map(o => o.id) // remove duplicate
    const filtered = this.selected.filter(({ id }, index) => !ids.includes(id, index + 1))
    // end  make sure the selected is not redundant!!
    this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = filtered;
    this.selectedSdas = filtered;
  }


  onSdaChange(sdas: ISDA[]) {
    this.places = [];
    this.subPlacesAll = [];
    this.selectedSdas = [];
    // this.sdas =[];

    this.setPlaces(sdas); // populate specific locations where the service will be delivered to
    sdas.forEach(item => {
      this.selectedSdas = this.selectedSdas.concat(this.sdasAll.find(x => x.id === item.id));
    });
        
    this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = this.selectedSdas;
    
    this.fundingApplicationDetailsChange.emit(this.fundingApplicationDetails);
    let count = 0;
    if (this.fundingApplicationDetails.implementations) { // when sds change make sure that fundingApplicationDetails contains correct places 
      let isPlace = [];
      this.fundingApplicationDetails.implementations.find(x => {
        x.places;
        isPlace = x.places
      });

      if (isPlace != null) {
        this.fundingApplicationDetails.implementations.forEach(x => {
          sdas.forEach(i => { 
            // place already pushed to fundingApplicationDetails must be cleared out  if sda is no longer selected
            x.places.forEach(o => {
              if (o.serviceDeliveryAreaId == i.id) {
                count++;
              }
            })
          })
        })
      }
    }

    if (count == 0)
      this.fundingApplicationDetails.implementations.filter(x => { x.places = []; x.subPlaces = []; });
  }

  private setPlaces(sdas: ISDA[]): void {
    if (sdas && sdas.length != 0) {
      this._bidService.getPlaces(sdas).subscribe(res => {
        this.places = res;
        this.getPlace.emit(this.places)
        this._bidService.getSubPlaces(this.places).subscribe(res => {
          this.subPlacesAll = res;
          this.getSubPlace.emit(this.subPlacesAll)
        });
      });
    }
  }

  private GetSourceOfInformation() {
    this._npoProfile.getSourceOfInformationById(Number(this.selectedApplicationId)).subscribe(
      (results) => {
        this.sourceOfInformation = results;
        this.sourceOfInformationText = "Printed newspaper";
        if (results.find(results => results.selectedSourceValue === 1)) {
          this.sourceOfInformationText = "Printed newspaper";
        }
        if (results.find(results => results.selectedSourceValue === 2)) {
          this.sourceOfInformationText = "Online";
        }
        if (results.find(results => results.selectedSourceValue === 3)) {
          this.sourceOfInformationText = "DSD circular to NPOs";
        }
        if (results.find(results => results.selectedSourceValue === 4)) {
          this.sourceOfInformationText = "Other (specify)";
        }
      },
      (err) => {
        //
      }
    );
  }

  private GetAffiliatedOrganisation() {
    this._npoProfile.getAffiliatedOrganisationById(Number(this.selectedApplicationId)).subscribe(
      (results) => {
        this.affliatedOrganisationInfo = results;
        if (results.length > 0) {
          document.getElementById('affliatedOrganisationInfoTable').hidden = false;
        }
      },
      (err) => {
        //
      }
    );
  }

  updateDetail(rowData: IAffiliatedOrganisation) {

    this._npoProfile.updateAffiliatedOrganisationData(rowData, this.selectedApplicationId).subscribe(
      (resp) => {
        this.GetAffiliatedOrganisation();
      },
      (err) => {
        //
      }
    );
  }

  updateSourceOfInformation(sourceOfInfo: ISourceOfInformation) {
    this._npoProfile.updateSourceOfInformation(sourceOfInfo, this.selectedApplicationId).subscribe(
      (resp) => {
        this.GetSourceOfInformation();
      },
      (err) => {
        //
      }
    );
  }

  addNewRow() {
    this.affliatedOrganisationInfo.push({
    } as IAffiliatedOrganisation);
  }

  save() {
    var today = this.getCurrentDateTime();
    this.sourceOfInformations.npoProfileId = Number(this.selectedApplicationId);
    this.sourceOfInformations.selectedSourceValue = Number(this.selectedDropdownValue);
    this.sourceOfInformations.additionalSourceInformation = this.specify;
    this.updateSourceOfInformation(this.sourceOfInformations);
  }

  private getCurrentDateTime() {
    let today = new Date();
    let nextTwoHours = today.getHours() + 2;
    today.setHours(nextTwoHours);
    return today;
  }

  private loadApplicationPeriods() {
    this._spinner.show();
    this._applicationPeriodRepo.getAllApplicationPeriods().subscribe(
      (results) => {

        results.forEach(period => {
          this.setStatus(period);
        });

        this.allApplicationPeriods = results.filter(X => X.status === "Open");
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSubProgrammeTypes(subProgramId: number) {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgrammeTypes, false).subscribe(
      (results) => {
        this.subProgrammeType = results;
       this.filteredSubProgrammeType = this.subProgrammeType.filter(x=> x.subProgrammeId === subProgramId);
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  // subProgrammeChange(subProgram: any[])
  // {
  //   let selectedSubProgrammes = [];
  //   selectedSubProgrammes.push(subProgram); 
  //   if (selectedSubProgrammes.length > 0)
  //   {
  //     this.selectedSubProgram = selectedSubProgrammes.join(",");
  //     this.filterSubProgramIds = this.selectedSubProgram;
  //     const subProgrammeIds = this.filterSubProgramIds.split(',').map(Number);
      
  //     this.filteredSubProgrammeType = this.subProgrammeType.filter(item =>
  //       subProgrammeIds.includes(item.subProgrammeId)
  //     );     
  //   }  
  //   else
  //   this.filterSubProgramIds = "0";
  // }

  private setStatus(applicationPeriod: IApplicationPeriod) {
    let openingDate = new Date(applicationPeriod.openingDate);
    let closingDate = new Date(applicationPeriod.closingDate);
    let today = new Date();

    if (today >= openingDate && today <= closingDate)
      applicationPeriod.status = 'Open';
    else
      applicationPeriod.status = 'Closed';
  }

  onRowSelect(applicationPeriod: IApplicationPeriod) {
    if (applicationPeriod.id != this.applicationPeriod.id) {
      this._spinner.show();

      let application = {
        applicationPeriodId: applicationPeriod.id,
        npoId: this.application.npoId
      } as IApplication;

      this.applicationExists(application);
    }
  }

  private applicationExists(application: IApplication) {
    this._spinner.show();
    this._applicationRepo.getApplicationByNpoIdAndPeriodId(application).subscribe(
      (results) => {
        if (results == null) {
          this.application.applicationPeriodId = application.applicationPeriodId;
          this.application.applicationPeriod = null;

          this._applicationRepo.updateApplication(this.application).subscribe(
            (resp) => {
              this.loadApplicationPeriodById(this.application.applicationPeriodId);
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        }
        else {
          this._messageService.add({ severity: 'warn', summary: "Warning:", detail: "Application already captured for the selected programme. Please go to 'Submissions' to access this application." });
          this._spinner.hide();
        }
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public getSelectedApplicationPeriod(rowData: IApplicationPeriod) {
    if (this.applicationPeriod && rowData.id === this.applicationPeriod.id)
      return 'green';

    return 'default';
  }

  getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];

      if (col.field == 'openingDate' || col.field == 'closingDate')
        value = this._datepipe.transform(value, 'yyyy-MM-dd HH:mm:ss');
    }

    return value;
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }
}
