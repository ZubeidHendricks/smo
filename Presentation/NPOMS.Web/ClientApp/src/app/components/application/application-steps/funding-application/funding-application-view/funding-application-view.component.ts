import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { IAffiliatedOrganisation, ISourceOfInformation } from 'src/app/models/FinancialMatters';
import { DropdownTypeEnum, PermissionsEnum, StatusEnum } from 'src/app/models/enums';
import { IApplicationPeriod, IUser, IDistrictCouncil, IFinancialYear, IDepartment, IProgramme, ISubProgramme, IApplicationType, ILocalMunicipality, IRegion, ISDA, IPlace, ISubPlace, IApplication, IFundingApplicationDetails } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-funding-application-view',
  templateUrl: './funding-application-view.component.html',
  styleUrls: ['./funding-application-view.component.css']
})
export class FundingApplicationViewComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

  @Input() isReadOnly: boolean;
  @Input() Amount: number;

  @Output() AmountChange = new EventEmitter();
  @Input() fundingApplicationDetails: IFundingApplicationDetails;

  @Input() application: IApplication;
  canEdit: boolean = false;

  @Output() getPlace = new EventEmitter<IPlace[]>(); // try to send data from child to child via parent
  @Output() getSubPlace = new EventEmitter<ISubPlace[]>();

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
  dropdownTouched: boolean = false;
  finYearRange: string;

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
  places: IPlace[] = [];
  subPlacesAll: ISubPlace[];

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

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
        let amountStringId = (<HTMLInputElement>document.getElementById("amountApplyingFor"));
        amountStringId.focus();
        this.loadDistrictCouncils();
        this.loadMunicipalities();
        this.regionDropdown();
        this.loadServiceDeliveryAreas();
        this.GetAffiliatedOrganisation();
        this.GetSourceOfInformation();
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
  }

  save() {
    var today = this.getCurrentDateTime();
    this.sourceOfInformations.npoProfileId = Number(this.selectedApplicationId);
    this.sourceOfInformations.selectedSourceValue = Number(this.selectedDropdownValue);
    this.sourceOfInformations.additionalSourceInformation = this.specify;
    this.updateSourceOfInformation(this.sourceOfInformations);
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

  private getCurrentDateTime() {
    let today = new Date();
    let nextTwoHours = today.getHours() + 2;
    today.setHours(nextTwoHours);
    return today;
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
    if (this.applicationPeriodId != null) {
      this._applicationPeriodRepo.getApplicationPeriodById(this.applicationPeriodId).subscribe(
        (results) => {
          this.loadFinancialYears(results.financialYear);
          this.loadProgrammes(results.departmentId);
          this.loadSubProgrammes(results.programmeId);
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

  private allDropdownsLoaded() {
    if (this.allDistrictCouncils?.length > 0 &&
      this.localMunicipalitiesAll?.length > 0 &&
      this.regionsAll?.length > 0 && this.sdasAll?.length > 0) {

      if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail != null)
        this.OnDistrictCouncilChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil);

      if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail != null)
        this.onLocalMunicipalityChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality);

      if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail != null)
        this.onRegionChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions);

      if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail != null)
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

    if (localMunicipality.id != null) {
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

    if (districtCouncil.id != null) {
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

  readonly(): boolean {
    if (this.application.statusId == StatusEnum.PendingReview ||
      this.application.statusId == StatusEnum.Approved)
      return true;
    else return false;
    //return false;
  }
  onAmountChange(event) {
    let amount = Number(event).valueOf();
    this.Amount = amount;
    this.AmountChange.emit(this.Amount);
  }

  nextPage() {
    if (this.Amount > 0 && this.fundingApplicationDetails?.id != undefined) {
      this.activeStep = this.activeStep + 1;
      this.activeStepChange.emit(this.activeStep);
    }
    else
      this._messageService.add({ severity: 'warn', summary: 'Warning', detail: '  Please capture application details info and Save first' });
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  public addNewRow() {
    
  }

  public showTable(value) {

  }
}
