import { IFundAppSDADetail, LocalMunicipality } from './../../../../../models/interfaces';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IFinancialYear, IProgramme, IDepartment, ISubProgramme, IApplicationType, IApplicationPeriod, IUser, IDistrictCouncil, ILocalMunicipality, IFundingApplicationDetails, IApplication, IRegion, IServiceDeliveryArea } from 'src/app/models/interfaces';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, Message } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';

@Component({
  selector: 'app-application-details',
  templateUrl: './application-details.component.html',
  styleUrls: ['./application-details.component.css']
})
export class ApplicationDetailsComponent implements OnInit {
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
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
  selectedDistrict: IDistrictCouncil;

  allLocalMunicipalities: ILocalMunicipality[];
  localMunicipalities: ILocalMunicipality[] =[];
  selectedLocalMunicipalities: ILocalMunicipality[];

  selectedLocalMunicipalitiesText: string;
  selectedRegionsText: string;

  allRegions: IRegion[];
  regions: IRegion[] =[];
  selectedRegions: IRegion[];
 
  
  allServiceDeliveryAreas: IServiceDeliveryArea[];
  serviceDeliveryAreas: IServiceDeliveryArea[];
  selectedServiceDeliveryArea: IServiceDeliveryArea;
  canEdit :boolean;

  @Input() Amount: number;
  @Output() AmountChange = new EventEmitter();
  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _applicationPeriodRepo: ApplicationPeriodService,
    private _activeRouter: ActivatedRoute,
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
        this.loadDistrictCouncils();
        this.loadMunicipalities();
        this.loadRegions();
        this.loadServiceDeliveryAreas();
        this.buildMenu();
      }
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
            this.saveItems();
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
        console.log('DistrictCouncilResults', results);
        this.districtCouncils = results;
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
        this.allLocalMunicipalities = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  districtChange(district: IDistrictCouncil) {
  debugger;
    this.localMunicipalities = [];

    if (district.id != null) {
      // for (var i = 0; i < this.allLocalMunicipalities.length; i++) {
      //   if (this.allLocalMunicipalities[i].districtCouncilId == district.id) {
      //     this.localMunicipalities.push(this.allLocalMunicipalities[i]);
      //   }
      // }
      this.localMunicipalities = this.allLocalMunicipalities?.filter(x => x.districtCouncilId == district.id);

    }
  }

  localMunicipalityChange(localMunicipalities: ILocalMunicipality[]) {
    debugger;
    this.regions = [];

    localMunicipalities.forEach(item => {
      if (item.id != null) {
        for (var i = 0; i < this.allRegions.length; i++) {
          if (this.allRegions[i].localMunicipalityId == item.id) {
            this.regions.push(this.allRegions[i]);
          }
        }
      }
    });
  }

 private loadRegions() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Region, false).subscribe(
      (results) => {
        this.allRegions = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  regionChange(regions: IRegion[]) {
    debugger;
    this.selectedRegions = null;
    this.regions = [];

    regions.forEach(item => {
      if (item.id != null) {
        for (var i = 0; i < this.allRegions.length; i++) {
          if (this.allRegions[i].localMunicipalityId == item.id) {
            this.regions.push(this.allRegions[i]);
          }
        }
      }
    });
  }

  private loadServiceDeliveryAreas() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.ServiceDeliveryArea, false).subscribe(
      (results) => {
        this.allServiceDeliveryAreas = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  serviceDeliveryAreaChange(region: IRegion) {
    this.selectedServiceDeliveryArea = null;
    this.serviceDeliveryAreas = [];

    if (region.id != null) {
      for (var i = 0; i < this.allServiceDeliveryAreas.length; i++) {
        if (this.allServiceDeliveryAreas[i].regionId == region.id) {
          this.serviceDeliveryAreas.push(this.allServiceDeliveryAreas[i]);
        }
      }
    }
  }

  nextPage() {
    // if (this.Amount > 0) {
    //   this.activeStep = this.activeStep + 1;
    //   this.activeStepChange.emit(this.activeStep);
    // }
    // else
    // {}
      //this._messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Capture Funding Application Details.' });

      this.activeStep = this.activeStep + 1;
      this.activeStepChange.emit(this.activeStep);
            
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }


  fundAppDetails: IFundingApplicationDetails = {} as IFundingApplicationDetails;
  @Input() application: IApplication;
  @Output() applicationDetailsChange: EventEmitter<IFundingApplicationDetails> = new EventEmitter<IFundingApplicationDetails>();

  private createObjective() {
    this._applicationRepo.createFundingApplicationDetails(this.fundAppDetails, this.application).subscribe(
      (resp) => {
        //this.loadObjectives();
        this.applicationDetailsChange.emit(this.fundAppDetails);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  newFundAppln: boolean;
  fundingApplicationDetails: IFundingApplicationDetails = {} as IFundingApplicationDetails;

  addFundingApplicationDetails() {
    this.newFundAppln = true;
    this.fundingApplicationDetails = {
      localMunicipalities: [] as ILocalMunicipality[],
      regions: [] as IRegion[],
      serviceDeliveryAreas :[] as IServiceDeliveryArea[]
    } as IFundingApplicationDetails;
    this.selectedLocalMunicipalities = [];
    this.regions = [];
    this.selectedRegions = [];

    if (this.application.isCloned)
      this.fundingApplicationDetails.isNew = this.fundingApplicationDetails.isNew == undefined ? true : this.fundingApplicationDetails.isNew;
  }
  
  editFundingApplicationDetails(data: IFundingApplicationDetails) {
    this.newFundAppln = false;
    this.fundingApplicationDetails = this.cloneObjective(data);

    if (this.application.isCloned)
      this.fundingApplicationDetails.isNew = this.fundingApplicationDetails.isNew == undefined ? false : this.fundingApplicationDetails.isNew;
  }

  private cloneObjective(data: IFundingApplicationDetails): IFundingApplicationDetails {
    let obj = {} as IFundingApplicationDetails;

    for (let prop in data)
      obj[prop] = data[prop];


    const localMuncipalityIds = data.localMunicipalities.map(({ districtCouncilId }) => districtCouncilId);
    this.selectedLocalMunicipalities = this.localMunicipalities.filter(item => localMuncipalityIds.includes(item.id));
    this.localMunicipalityChange(this.selectedLocalMunicipalities);

    const regionIds = data.regions.map(({ localMunicipalityId }) => localMunicipalityId);
    this.selectedRegions = this.regions.filter(item => regionIds.includes(item.id));
    this.regionChange(this.selectedRegions);

    this.getTextValues();

    return obj;
  }
  
  getTextValues() {
    let allLocalMunicipalities: string = "";
    let allRegions: string = "";

    this.selectedLocalMunicipalities.forEach(item => {
      allLocalMunicipalities += item.name + ", ";
    });

    this.selectedRegions.forEach(item => {
      allRegions += item.name + ", ";
    });

    this.selectedLocalMunicipalitiesText = allLocalMunicipalities.slice(0, -2);
    this.selectedRegionsText = allRegions.slice(0, -2);
  }

  saveObjective() {
    this.fundingApplicationDetails.amountApplyingFor = null;
    this.fundingApplicationDetails.isActive = true;
    this.fundingApplicationDetails.changesRequired = this.fundingApplicationDetails.changesRequired == null ? null : false;


    this.fundingApplicationDetails.fundAppSDADetails = [];
    // this.selectedSubProgrammes.forEach(item => {
    //   let fundAppSDADetail = {
    //     fundingApplicationDetailsId?: = this.fundingApplicationDetails.id


    //   } as IFundAppSDADetail;

    //   this.fundingApplicationDetails.fundAppSDADetails.push(fundAppSDADetail);
    // });

    this.newFundAppln ? this.createObjective() : this.updateFundingApplicationDetails();

  }  

  @Output() objectiveChange: EventEmitter<IFundingApplicationDetails> = new EventEmitter<IFundingApplicationDetails>();

  private updateFundingApplicationDetails() {
    this._applicationRepo.updateFundingApplicationDetails(this.fundingApplicationDetails).subscribe(
      (resp) => {
        //this.loadObjectives();
        this.objectiveChange.emit(this.fundingApplicationDetails);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

}
