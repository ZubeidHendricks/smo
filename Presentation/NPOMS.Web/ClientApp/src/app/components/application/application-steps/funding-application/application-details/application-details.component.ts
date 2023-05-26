import { IApplicationDetails, IFundAppSDADetail, IPlace, ISDA, ISubPlace} from './../../../../../models/interfaces';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IFinancialYear, IProgramme, IDepartment, ISubProgramme, IApplicationType, IApplicationPeriod, IUser, IDistrictCouncil, ILocalMunicipality, IFundingApplicationDetails, IApplication, IRegion, IServiceDeliveryArea } from 'src/app/models/interfaces';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';

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

  @Input() application: IApplication;
  canEdit: boolean = false;

  @Output() getPlace = new EventEmitter<IPlace[]>(); // try to send data from child to child via parent
  @Output() getSubPlace = new EventEmitter<ISubPlace[]>();
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

  entities: IDistrictCouncil[];
  entity: IDistrictCouncil = {} as IDistrictCouncil;

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

  openingMinDate: Date;
  closingMinDate: Date;
  disableClosingDate: boolean = true;
  disableOpeningDate: boolean = true;
  finYearRange: string;

  // Highlight required fields on validate click
  validated: boolean = false;

  districtCouncils: IDistrictCouncil[]=[];
  selectedDistrictCouncil: IDistrictCouncil;

  allLocalMunicipalities: ILocalMunicipality[];
  localMunicipalities: ILocalMunicipality[] =[];
  selectedLocalMunicipalities: ILocalMunicipality[];

  localMunicipalitiesAll: ILocalMunicipality[];
  selectedLocalMunicipality: ILocalMunicipality;

  selectedLocalMunicipalitiesText: string;
  selectedRegionsText: string;
  selectedSDAsText: string;

  allRegions: IRegion[];
  regions: IRegion[] =[];
  selectedRegions: IRegion[];
 
  sdasAll: ISDA[];
  sdas: ISDA[] = [];
  selectedSdas: ISDA[];
  selected: ISDA[] = [];
  places: IPlace[] = [];
  subPlacesAll: ISubPlace[];
  allServiceDeliveryAreas: IServiceDeliveryArea[];
  serviceDeliveryAreas: IServiceDeliveryArea[]=[];
  selectedServiceDeliveryAreas: IServiceDeliveryArea[];

  allDistrictCouncils: IDistrictCouncil[];
  regionsAll: IRegion[];
  newFundAppln: boolean;

  localMun :   ILocalMunicipality;
  //fundingApplicationDetails: IFundingApplicationDetails = {} as IFundingApplicationDetails;

  @Output() applicationDetailsChange: EventEmitter<IFundingApplicationDetails> = new EventEmitter<IFundingApplicationDetails>();
  // fundingApplicationDetails: IFundingApplicationDetails = {
  //   applicationDetails: {
  //         fundAppSDADetail: {
  //           districtCouncil: {} as IDistrictCouncil,
  //           localMunicipality: {} as ILocalMunicipality,
  //           regions: [],
  //           serviceDeliveryAreas: [],
  //           } as IFundAppSDADetail,
  //   } as IApplicationDetails,

  //   financialMatters: [],
  //   implementations: [],

  // } as IFundingApplicationDetails;
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
    private _messageService:MessageService,  
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._spinner.show();
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.selectedApplicationId = params.get('id');
      console.log('id', params.get('id'));

    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        // if (!this.IsAuthorized(PermissionsEnum.EditApplicationPeriod))
        //   this._router.navigate(['401']);

        this.loadDepartments();
        this.loadApplicationTypes();
        this.loadApplicationPeriod();
        this.buildMenu();
        let amountStringId = (<HTMLInputElement>document.getElementById("amountApplyingFor"));
        //amountStringId.focus();
        //Get all district councils
        this.loadDistrictCouncils();
        //Gel all local municipalities
        this.loadMunicipalities();
        //Get all regions
        this.regionDropdown();
        //Get all service delivery areas
        this. loadServiceDeliveryAreas();      }
    });
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

  private formValidate() {
    this.validated = true;
    this.validationErrors = [];

    let data = this.applicationPeriod;

    if (!this.selectedDepartment || !this.selectedProgramme || !this.selectedSubProgramme || !this.selectedApplicationType || !data.name || !data.description || !this.selectedFinancialYear || !data.openingDate || !data.closingDate)
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
      let data = this.applicationPeriod;

      data.departmentId = this.selectedDepartment.id;
      data.programmeId = this.selectedProgramme.id;
      data.subProgrammeId = this.selectedSubProgramme.id;
      data.financialYearId = this.selectedFinancialYear.id;
      data.applicationTypeId = this.selectedApplicationType.id;

      data.openingDate = this.addTwoHours(data.openingDate);
      data.closingDate = this.addTwoHours(data.closingDate);

      this._applicationPeriodRepo.updateApplicationPeriod(data).subscribe(
        (resp) => {
          this._spinner.hide();
          this._router.navigateByUrl('application-periods');
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private addTwoHours(date: Date) {
    let newDate = new Date(date);
    let nextTwoHours = newDate.getHours() + 2;
    newDate.setHours(nextTwoHours);

    return newDate;
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
    debugger;
    console.log('selectedApplicationId', this.selectedApplicationId);
    this._applicationRepo.getApplicationById(Number(this.selectedApplicationId)).subscribe(
      (results) => {
        if (results != null) {
          console.log('results', results);
          this.applicationPeriodId = results.applicationPeriodId;
          console.log('this.applicationPeriodId', this.applicationPeriodId);
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
          console.log(results);
          console.log(results.financialYear);
          this.loadFinancialYears(results.financialYear);
          this.loadProgrammes(results.departmentId);
          this.loadSubProgrammes(results.programmeId);

          this.updateDateField(results.financialYear.startDate, 'opening date');
          this.updateDateField(results.openingDate, 'closing date');

          this.disableOpeningDate = false;
          this.disableClosingDate = false;

          this.selectedDepartment = results.department;
          this.selectedProgramme = results.programme;
          this.selectedSubProgramme = results.subProgramme;
          this.selectedFinancialYear = results.financialYear;
          this.selectedApplicationType = results.applicationType;

          results.openingDate = new Date(results.openingDate);
          results.closingDate = new Date(results.closingDate);

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

  openingDateSelected(date: Date) {
    this.applicationPeriod.closingDate = null;
    this.updateDateField(date, 'closing date');
    this.disableClosingDate = false;
  }

  closingDateSelected(date: Date) {
    if (this.applicationPeriod.openingDate > date)
      this.applicationPeriod.closingDate = this.applicationPeriod.openingDate;
  }

  financialYearChange(finYear: IFinancialYear) {
    this.applicationPeriod.openingDate = null;
    this.getFinancialYearRange(finYear);
    this.updateDateField(finYear.startDate, 'opening date');
    this.disableOpeningDate = false;
  }

  private updateDateField(date: Date, dateField: string) {
    let newDate = new Date(date);

    if (dateField === 'opening date')
      this.openingMinDate = new Date();
    else
      this.closingMinDate = newDate;
  }

  private getFinancialYearRange(finYear: IFinancialYear) {
    if (this.financialYears.length > 0) {
      let start = this.financialYears.find(x => x.id === finYear.id);
      let end = this.financialYears[this.financialYears.length - 1];
      this.finYearRange = `${start.year}:${end.year}`;
    }
  }

  private loadDistrictCouncils() {
    debugger;
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
        this._spinner.hide();

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
  districtChange(district: IDistrictCouncil) {
    this.localMunicipalities = [];

    if (district.id != null) {

      this.localMunicipalities = this.allLocalMunicipalities?.filter(x => x.districtCouncilId == district.id);

    }
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


  nextPage() {

      this.activeStep = this.activeStep + 1;
      this.activeStepChange.emit(this.activeStep);

   
  }


  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }


  

  private createFundingApplicationDetails() {
    console.log(JSON.stringify(this.fundingApplicationDetails));
    this._applicationRepo.createFundingApplicationDetails(this.fundingApplicationDetails, this.application).subscribe(
      (resp) => {
        this.applicationDetailsChange.emit(this.fundingApplicationDetails);
      },
      (err) => {
        this._loggerService.logException(err);
       
      }
    );
  }

 
  private allDropdownsLoaded() {
    if (this.allDistrictCouncils?.length > 0 && this.localMunicipalitiesAll?.length > 0 && this.regionsAll?.length > 0 && this.sdasAll?.length > 0) {
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

  OnDistrictCouncilChange(districtCouncil: IDistrictCouncil) {
    this.selectedDistrictCouncil = this.allDistrictCouncils.find(x => x.id === districtCouncil.id);
    this.localMunicipalities = [];
    this.regions = [];
    this.sdas = [];

    this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil = districtCouncil;
   // if (districtCouncil.id != undefined) {
      this.localMunicipalities = this.localMunicipalitiesAll?.filter(x => x.districtCouncilId == districtCouncil.id);    
    //}
  }

  onLocalMunicipalityChange(localMunicipality:ILocalMunicipality) {
    debugger;
    this.selectedLocalMunicipality = this.localMunicipalitiesAll.find(x => x.id === localMunicipality.id);
    // this.regions = [];
    // this.sdas = [];

    // if (localMunicipality.id != undefined && 
    //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality?.id != localMunicipality.id) {
    //   this.selectedRegions = [];
    //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = null;
    //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = [];
    //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = [];
    // }

    // if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality?.name != localMunicipality.name) {
    //   this.selectedRegions = [];
    //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = [];
    //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = [];
    // }

   // const object = localMunicipality.reduce((acc, { key, value }) => { acc[key] = value; return acc; }, {});


    this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = localMunicipality[0] ;

    //if (localMunicipality.id != undefined) {
      this.regions = this.regionsAll?.filter(x => x.localMunicipalityId == localMunicipality.id);
      console.log('this.selectedLocalMunicipality',  this.selectedLocalMunicipality);
      console.log('this.regions',  this.regions);
      console.log('this.regionsAll',  this.regionsAll);


    //}
  }

  onRegionChange(regions: IRegion[]) {
    debugger;
    this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = regions;
    this.selectedRegions = [];

    regions.forEach(item => {
      this.selectedRegions = this.selectedRegions.concat(this.regionsAll.find(x => x.id === item.id));
    });
    this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = this.selectedRegions;
    this.sdas = [];
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
debugger;
    this.places = [];
    this.subPlacesAll = [];
    this.selectedSdas = [];
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

}
