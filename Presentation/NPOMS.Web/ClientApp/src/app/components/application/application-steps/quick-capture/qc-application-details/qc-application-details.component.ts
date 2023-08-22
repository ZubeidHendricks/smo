import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { IAffiliatedOrganisation, ISourceOfInformation } from 'src/app/models/FinancialMatters';
import { PermissionsEnum, DropdownTypeEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IPlace, ISubPlace, IApplicationPeriod, IUser, IDistrictCouncil, IFinancialYear, IDepartment, IProgramme, ISubProgramme, IApplicationType, ILocalMunicipality, IRegion, ISDA, IQuickCaptureDetails, IFundingApplicationDetails, IProjectInformation, IMonitoringAndEvaluation } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-qc-application-details',
  templateUrl: './qc-application-details.component.html',
  styleUrls: ['./qc-application-details.component.css']
})
export class QcApplicationDetailsComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() applicationPeriod: IApplicationPeriod;

  // @Input() activeStep: number;
  // @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

  // @Input() newlySavedApplicationId: number;
  // @Output() newlySavedApplicationIdChange: EventEmitter<number> = new EventEmitter<number>();

  // @Input() applnPeriodId: number;
  // @Output() applnPeriodIdChange: EventEmitter<number> = new EventEmitter<number>();


  // @Input() isReadOnly: boolean;
  // @Input() Amount: number;

  amount: number;

  // @Output() AmountChange = new EventEmitter();
  // @Input() fundingApplicationDetails: IFundingApplicationDetails;


  // application: IApplication;
  // canEdit: boolean = false;

  // @Output() getPlace = new EventEmitter<IPlace[]>(); // try to send data from child to child via parent
  // @Output() getSubPlace = new EventEmitter<ISubPlace[]>();

  // dropdownTouched: boolean = false;

  /* Permission logic */
  // public IsAuthorized(permission: PermissionsEnum): boolean {
  //   if (this.profile != null && this.profile.permissions.length > 0) {
  //     return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
  //   }
  // }

  // public get PermissionsEnum(): typeof PermissionsEnum {
  //   return PermissionsEnum;
  // }

  // applicationPeriod: IApplicationPeriod = {} as IApplicationPeriod;

  // amountApplyingFor: number;
  // menuActions: MenuItem[];
  profile: IUser;

  isDataAvailable: boolean;
  department: IDepartment;
  programme: IProgramme;
  subProgramme: ISubProgramme;
  applicationType: IApplicationType;
  financialYear: IFinancialYear;

  allDistrictCouncils: IDistrictCouncil[];
  selectedDistrictCouncil: IDistrictCouncil;

  allLocalMunicipalities: ILocalMunicipality[];
  filteredLocalMunicipalities: ILocalMunicipality[];
  selectedLocalMunicipality: ILocalMunicipality;

  allRegions: IRegion[];
  filteredRegions: IRegion[];
  selectedRegions: IRegion[];

  allServiceDeliveryAreas: ISDA[];
  filteredServiceDeliveryAreas: ISDA[];
  selectedSDAs: ISDA[];

  // validationErrors: Message[];
  // selectedApplicationId: any;
  // applicationPeriodId: number;
  // paramSubcriptions: Subscription;
  // isDataAvailable: boolean = false;
  specify: string;
  // affiliatedOrganisation: string;
  // contactPerson: string;
  // EmailAddress: string;
  // telephone: string;
  // website: string;
  affliatedOrganisationInfo: IAffiliatedOrganisation[];
  // sourceOfInformation: ISourceOfInformation[];
  sourceOfInformations: ISourceOfInformation = {} as ISourceOfInformation;
  // entities: IDistrictCouncil[];
  // entity: IDistrictCouncil = {} as IDistrictCouncil;
  // sourceOfInformationText: string;
  // financialYears: IFinancialYear[];

  // selectedFinancialYear: IFinancialYear;
  // departments: IDepartment[];
  // selectedDepartment: IDepartment;
  // allProgrammes: IProgramme[];
  // programmes: IProgramme[] = [];

  // selectedProgramme: IProgramme;
  // allSubProgrammes: ISubProgramme[];
  // subProgrammes: ISubProgramme[] = [];
  // selectedSubProgramme: ISubProgramme;
  // applicationTypes: IApplicationType[];
  // selectedApplicationType: IApplicationType;
  stateOptions: any[];

  // finYearRange: string;

  // Highlight required fields on validate click
  // validated: boolean = false;
  // allDistrictCouncils: IDistrictCouncil[];
  // selectedDistrictCouncil: IDistrictCouncil;

  // localMunicipalitiesAll: ILocalMunicipality[];
  // localMunicipalities: ILocalMunicipality[] = [];
  // selectedLocalMunicipality: ILocalMunicipality;

  // regionsAll: IRegion[];
  // regions: IRegion[] = [];
  // selectedRegions: IRegion[];
  // selectedRegs: IRegion[] = [];
  // selectedLocalMunicipalitiesText: string;
  // selectedRegionsText: string;
  // selectedSDAsText: string;
  selectedDropdownValue: string;
  // sdasAll: ISDA[];
  // sdas: ISDA[] = [];
  // selectedSdas: ISDA[];
  // selected: ISDA[] = [];

  // places: IPlace[] = [];
  // subPlacesAll: ISubPlace[];

  // @Output() applicationDetailsChange: EventEmitter<IQuickCaptureDetails> = new EventEmitter<IQuickCaptureDetails>();
  // selectedOption: string = '';

  constructor(
    // private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    // private _applicationRepo: ApplicationService,
    private _applicationPeriodRepo: ApplicationPeriodService,
    // private _activeRouter: ActivatedRoute,
    // private _fundAppService: FundingApplicationService,
    // private _bidService: BidService,
    // private _messageService: MessageService,
    private _loggerService: LoggerService,
    private _npoProfile: NpoProfileService
  ) { }

  ngOnInit(): void {

    // this._spinner.show();

    // this.selectedApplicationId = this.newlySavedApplicationId;

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this._spinner.show();
        this.profile = profile;

        console.log('applicationPeriod', this.applicationPeriod);
        this.loadApplicationPeriod();

        // this.loadDepartments();
        //     this.loadApplicationTypes();
        //     this.loadApplicationPeriod();
        //     this.buildMenu();
        //     let amountStringId = (<HTMLInputElement>document.getElementById("amountApplyingFor"));
        //     amountStringId.focus();
        //     //Get all district councils
        //     this.loadDistrictCouncils();
        //     //Gel all local municipalities
        //     this.loadMunicipalities();
        //     //Get all regions
        //     this.regionDropdown();
        //     //Get all service delivery areas
        //     this.loadServiceDeliveryAreas();
        //     this.GetAffiliatedOrganisation();
        //     this.GetSourceOfInformation();
        //     this.loadApplication();
      }
    });

    this.stateOptions = [
      { label: 'Yes', value: 'Yes' },
      { label: 'No', value: 'No' }
    ];
  }

  private loadApplicationPeriod() {
    this._applicationPeriodRepo.getApplicationPeriodById(this.applicationPeriod.id).subscribe(
      (results) => {
        this.department = results.department;
        this.programme = results.programme;
        this.subProgramme = results.subProgramme;
        this.applicationType = results.applicationType;
        this.financialYear = results.financialYear;
        this.loadDistrictCouncils();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadDistrictCouncils() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DistrictCouncil, false).subscribe(
      (results) => {
        this.allDistrictCouncils = results;
        this.loadMunicipalities();
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
        this.loadRegions();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadRegions() {

    this._dropdownRepo.getEntities(DropdownTypeEnum.Region, false).subscribe(
      (results) => {
        this.allRegions = results;
        this.loadServiceDeliveryAreas();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadServiceDeliveryAreas() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.ServiceDeliveryArea, false).subscribe(
      (results) => {
        this.allServiceDeliveryAreas = results;
        this.isDataAvailable = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  // private loadApplication() {
  //   this._spinner.show();
  //   this._applicationRepo.getApplicationById(Number(this.selectedApplicationId)).subscribe(
  //     (results) => {
  //       if (results != null) {
  //         this.application = results;
  //         this._bidService.getApplicationBiId(results.id).subscribe(response => {
  //           //if (response.id != null) {
  //           this.getFundingApplicationDetails(response);
  //           //}
  //         });
  //       }
  //       this._spinner.hide();
  //     },
  //     (err) => this._spinner.hide()
  //   );
  // }


  // private getFundingApplicationDetails(data) {
  //   this._bidService.getBid(data.id).subscribe(response => {

  //     this.getBidFullObject(response)
  //   });

  // }



  // private getBidFullObject(data) {
  //   this.fundingApplicationDetails = data;
  //   this.fundingApplicationDetails.id = data.id;
  //   this.fundingApplicationDetails.applicationDetails.amountApplyingFor = data.applicationDetails.amountApplyingFor;
  //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail = data.applicationDetails.fundAppSDADetail;
  //   this.allDropdownsLoaded();
  // }


  // private bidForm(status: StatusEnum) {
  //   this.application.status = null;
  //   this.application.statusId = status;
  //   const applicationIdOnBid = this.fundingApplicationDetails;

  //   if (applicationIdOnBid.id == null) {
  //     this._bidService.addBid(this.fundingApplicationDetails).subscribe(resp => {
  //       this.menuActions[1].visible = false;
  //       this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
  //       resp;
  //     });
  //   }

  //   else {
  //     this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => {
  //       if (resp) {
  //         this._router.navigateByUrl(`application/edit/${this.application.id}/${this.activeStep}`);
  //         this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
  //       }
  //     });
  //   }

  //   if (status == StatusEnum.PendingReview) {

  //     this.application.statusId = status;
  //     this._applicationRepo.updateApplication(this.application).subscribe();
  //     this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
  //     this._router.navigateByUrl('applications');
  //   };
  //   // }
  // }


  // onAmountChange(event) {
  //   let amount = Number(event).valueOf();
  //   this.Amount = amount;
  //   this.AmountChange.emit(this.Amount);
  // }
  // private buildMenu() {
  //   if (this.profile) {
  //     this.menuActions = [
  //       {
  //         label: 'Validate',
  //         icon: 'fa fa-check',
  //         command: () => {
  //           this.formValidate();
  //         },
  //         visible: false
  //       },
  //       {
  //         label: 'Clear Messages',
  //         icon: 'fa fa-undo',
  //         command: () => {
  //           this.clearMessages();
  //         },
  //         visible: false
  //       },
  //       {
  //         label: 'Save',
  //         icon: 'fa fa-floppy-o',
  //         command: () => {
  //           //            this.saveFundingApplicationDetails();
  //         }
  //       },
  //       {
  //         label: 'Go Back',
  //         icon: 'fa fa-step-backward',
  //         command: () => {
  //           this._router.navigateByUrl('application-periods');
  //         }
  //       }
  //     ];
  //   }
  // }

  showTable(obj: any) {
    if (obj.value === "Yes")
      document.getElementById('affliatedOrganisationInfoTable').hidden = false;
    else
      document.getElementById('affliatedOrganisationInfoTable').hidden = true;
  }

  // private formValidate() {
  //   this.validated = true;
  //   this.validationErrors = [];

  //   let data = this.applicationPeriod;

  //   if (!this.selectedDepartment || !this.selectedProgramme || !this.selectedSubProgramme || !this.selectedApplicationType || !data.name || !data.description || !this.selectedFinancialYear)
  //     this.validationErrors.push({ severity: 'error', summary: "Application Details:", detail: "Missing detail required." });

  //   if (this.validationErrors.length == 0)
  //     this.menuActions[1].visible = false;
  //   else
  //     this.menuActions[1].visible = true;
  // }

  // private clearMessages() {
  //   this.validated = false;
  //   this.validationErrors = [];
  //   this.menuActions[1].visible = false;
  // }

  // private saveItems() {
  //   if (this.canContinue()) {
  //     this._spinner.show();
  //     let data = this.applicationPeriod;

  //     data.departmentId = this.selectedDepartment.id;
  //     data.programmeId = this.selectedProgramme.id;
  //     data.subProgrammeId = this.selectedSubProgramme.id;
  //     data.financialYearId = this.selectedFinancialYear.id;
  //     data.applicationTypeId = this.selectedApplicationType.id;



  //     this._applicationPeriodRepo.updateApplicationPeriod(data).subscribe(
  //       (resp) => {
  //         this._spinner.hide();
  //         this._router.navigateByUrl('application-periods');
  //       },
  //       (err) => {
  //         this._loggerService.logException(err);
  //         this._spinner.hide();
  //       }
  //     );
  //   }
  // }

  // private canContinue() {
  //   this.formValidate();

  //   if (this.validationErrors.length == 0)
  //     return true;

  //   return false;
  // }

  // private loadFinancialYears(financialYear: IFinancialYear) {
  //   this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
  //     (results) => {
  //       this.financialYears = results;
  //       this.getFinancialYearRange(financialYear);
  //     },
  //     (err) => {
  //       this._loggerService.logException(err);
  //       this._spinner.hide();
  //     }
  //   );
  // }

  // private loadDepartments() {
  //   this._dropdownRepo.getEntities(DropdownTypeEnum.Departments, false).subscribe(
  //     (results) => {
  //       this.departments = results;
  //     },
  //     (err) => {
  //       this._loggerService.logException(err);
  //       this._spinner.hide();
  //     }
  //   );
  // }

  // private loadApplicationTypes() {
  //   this._dropdownRepo.getEntities(DropdownTypeEnum.ApplicationTypes, false).subscribe(
  //     (results) => {
  //       this.applicationTypes = results;
  //     },
  //     (err) => {
  //       this._loggerService.logException(err);
  //       this._spinner.hide();
  //     }
  //   );
  // }

  // private loadProgrammes(departmentId: number) {
  //   if (departmentId != null) {
  //     this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
  //       (results) => {
  //         this.allProgrammes = results;
  //         this.programmes = results.filter(x => x.departmentId === departmentId);
  //       },
  //       (err) => {
  //         this._loggerService.logException(err);
  //         this._spinner.hide();
  //       }
  //     );
  //   }
  // }

  // private loadSubProgrammes(programmeId: number) {
  //   if (programmeId != null) {
  //     this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
  //       (results) => {
  //         this.allSubProgrammes = results;
  //         this.subProgrammes = results.filter(x => x.programmeId === programmeId);
  //       },
  //       (err) => {
  //         this._loggerService.logException(err);
  //         this._spinner.hide();
  //       }
  //     );
  //   }
  // }



  // private loadApplicationPeriod() {
  //   this._applicationRepo.getApplicationById(Number(this.selectedApplicationId)).subscribe(

  //     //this._applicationRepo.getApplicationById(this.newlySavedApplicationId).subscribe(
  //     (results) => {
  //       if (results != null) {
  //         this.applicationPeriodId = results.applicationPeriodId;
  //         this.loadApplicationPeriodById(this.applicationPeriodId);
  //       } this._spinner.hide();
  //     },
  //     (err) => {
  //       this._loggerService.logException(err);
  //     });
  // }
  // private loadApplicationPeriodById(applnPeriodId: number) {
  //   if (this.applicationPeriodId != null) {
  //     this._applicationPeriodRepo.getApplicationPeriodById(this.applicationPeriodId).subscribe(
  //       (results) => {
  //         this.loadFinancialYears(results.financialYear);
  //         this.loadProgrammes(results.departmentId);
  //         this.loadSubProgrammes(results.programmeId);

  //         this.selectedDepartment = results.department;
  //         this.selectedProgramme = results.programme;
  //         this.selectedSubProgramme = results.subProgramme;
  //         this.selectedFinancialYear = results.financialYear;
  //         this.selectedApplicationType = results.applicationType;

  //         this.applicationPeriod = results;
  //         this.isDataAvailable = true;
  //         this._spinner.hide();
  //       },
  //       (err) => {
  //         this._loggerService.logException(err);
  //         //this._spinner.hide();
  //       }
  //     );
  //   }
  // }
  // departmentChange(department: IDepartment) {
  //   this.selectedProgramme = null;
  //   this.selectedSubProgramme = null;

  //   this.programmes = [];
  //   this.subProgrammes = [];

  //   if (department.id != null) {
  //     for (var i = 0; i < this.allProgrammes.length; i++) {
  //       if (this.allProgrammes[i].departmentId == department.id) {
  //         this.programmes.push(this.allProgrammes[i]);
  //       }
  //     }
  //   }
  // }

  // programmeChange(programme: IProgramme) {
  //   this.selectedSubProgramme = null;

  //   this.subProgrammes = [];

  //   if (programme.id != null) {
  //     for (var i = 0; i < this.allSubProgrammes.length; i++) {
  //       if (this.allSubProgrammes[i].programmeId == programme.id) {
  //         this.subProgrammes.push(this.allSubProgrammes[i]);
  //       }
  //     }
  //   }
  // }


  // financialYearChange(finYear: IFinancialYear) {

  //   this.getFinancialYearRange(finYear);

  // }



  // private getFinancialYearRange(finYear: IFinancialYear) {
  //   if (this.financialYears.length > 0) {
  //     let start = this.financialYears.find(x => x.id === finYear.id);
  //     let end = this.financialYears[this.financialYears.length - 1];
  //     this.finYearRange = `${start.year}:${end.year}`;
  //   }
  // }

  readonly(): boolean {
    // if (this.application.statusId ==StatusEnum.PendingReview ||
    //  this.application.statusId == StatusEnum.Approved )
    //  return true;
    // else return false;
    return false;
  }

  nextPage() {

    //   // if (this.Amount > 0 && this.fundingApplicationDetails?.id != undefined) {

    //   this.activeStep = this.activeStep + 1;
    //   this.bidForm(StatusEnum.Saved);

    //   this.activeStepChange.emit(this.activeStep);

    //   // }
    //   // else
    //   //   this._messageService.add({ severity: 'warn', summary: 'Warning', detail: '  Please capture application details info and Save first' });
  }


  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  // private allDropdownsLoaded() {
  //   if (this.allDistrictCouncils?.length > 0 &&
  //     this.localMunicipalitiesAll?.length > 0 &&
  //     this.regionsAll?.length > 0 && this.sdasAll?.length > 0) {

  //     if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil.id != undefined)
  //       this.OnDistrictCouncilChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil);

  //     if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality.id != undefined)
  //       this.onLocalMunicipalityChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality);

  //     if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions?.length > 0)
  //       this.onRegionChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions);

  //     if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas?.length > 0)
  //       this.onSdaChange(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas);
  //   }
  // }

  // onLocalMunicipalityChange(localMunicipality: ILocalMunicipality) {
  //   this.selectedLocalMunicipality = this.localMunicipalitiesAll.find(x => x.id === localMunicipality.id);
  //   this.regions = [];
  //   this.sdas = [];

  //   if (localMunicipality.id != undefined &&
  //     this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality?.id != localMunicipality.id) {
  //     this.selectedRegions = [];
  //     this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = null;
  //     this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = [];
  //     this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = [];
  //   }

  //   if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality?.name != localMunicipality.name) {
  //     this.selectedRegions = [];
  //     this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = [];
  //     this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = [];
  //   }

  //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = localMunicipality;

  //   if (localMunicipality.id != undefined) {
  //     this.regions = this.regionsAll?.filter(x => x.localMunicipalityId == localMunicipality.id);
  //   }
  // }

  public districtCouncilChange(districtCouncil: IDistrictCouncil) {
    this.selectedLocalMunicipality = null;
    this.selectedRegions = [];
    this.selectedSDAs = [];
    this.filteredLocalMunicipalities = [];
    this.filteredRegions = [];
    this.filteredServiceDeliveryAreas = [];

    if (districtCouncil.id != null) {
      for (var i = 0; i < this.allLocalMunicipalities.length; i++) {
        if (this.allLocalMunicipalities[i].districtCouncilId == districtCouncil.id) {
          this.filteredLocalMunicipalities.push(this.allLocalMunicipalities[i]);
        }
      }
    }
  }

  public localMunicipalityChange(localMunicipality: ILocalMunicipality) {
    this.selectedRegions = [];
    this.selectedSDAs = [];
    this.filteredRegions = [];
    this.filteredServiceDeliveryAreas = [];

    if (localMunicipality.id != null) {
      for (var i = 0; i < this.allRegions.length; i++) {
        if (this.allRegions[i].localMunicipalityId == localMunicipality.id) {
          this.filteredRegions.push(this.allRegions[i]);
        }
      }
    }
  }

  public regionChange(regions: IRegion[]) {
    this.selectedSDAs = [];
    this.filteredServiceDeliveryAreas = [];

    if (regions.length > 0) {
      for (var i = 0; i < this.allServiceDeliveryAreas.length; i++) {
        if (regions.filter(x => x.id === this.allServiceDeliveryAreas[i].regionId).length != 0) {
          this.filteredServiceDeliveryAreas.push(this.allServiceDeliveryAreas[i]);
        }
      }
    }
  }

  // OnDistrictCouncilChange(districtCouncil: IDistrictCouncil) {
  //   this.selectedDistrictCouncil = this.allDistrictCouncils.find(x => x.id === districtCouncil.id);
  //   this.localMunicipalities = [];
  //   this.regions = [];
  //   this.sdas = [];

  //   // if (districtCouncil.id != undefined && this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil?.id != districtCouncil.id)
  //   //  {
  //   //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality =  { name: 'Select Type', id: null, districtCouncilId: null };
  //   //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = [];
  //   //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = [];
  //   //  }

  //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil = districtCouncil;

  //   if (districtCouncil.id != undefined) {

  //     this.localMunicipalities = this.localMunicipalitiesAll?.filter(x => x.districtCouncilId == districtCouncil.id);
  //     this.localMunicipalities.unshift({ name: 'Select Type', id: null, districtCouncilId: null });
  //   }
  // }


  // onRegionChange(regions: IRegion[]) {
  //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = regions;
  //   this.selectedRegions = [];

  //   regions.forEach(item => {
  //     this.selectedRegions = this.selectedRegions.concat(this.regionsAll.find(x => x.id === item.id));
  //   });
  //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = this.selectedRegions;
  //   this.sdas = [];

  //   // filter items matching the selected regions
  //   if (regions != null && regions.length != 0) {
  //     for (var i = 0; i < this.sdasAll.length; i++) {
  //       if (regions.filter(r => r.id === this.sdasAll[i].regionId).length != 0) {
  //         this.sdas.push(this.sdasAll[i]);

  //       }
  //     }
  //   }
  //   this.selected = [];
  //   for (var i = 0; i < regions?.length; i++) {
  //     for (var j = 0; j < this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas.length; j++) {
  //       if (this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas[j].regionId == regions[i].id) {
  //         this.selected.push(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas[j]);
  //       }

  //     }
  //   }

  //   // make sure the selected is not redundant!!
  //   const ids = this.selected.map(o => o.id) // remove duplicate
  //   const filtered = this.selected.filter(({ id }, index) => !ids.includes(id, index + 1))
  //   // end  make sure the selected is not redundant!!
  //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = filtered;
  //   this.selectedSdas = filtered;
  // }


  // onSdaChange(sdas: ISDA[]) {

  //   this.places = [];
  //   this.subPlacesAll = [];
  //   this.selectedSdas = [];
  //   this.setPlaces(sdas); // populate specific locations where the service will be delivered to
  //   sdas.forEach(item => {
  //     this.selectedSdas = this.selectedSdas.concat(this.sdasAll.find(x => x.id === item.id));
  //   });

  //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = this.selectedSdas;

  //   let count = 0;
  //   if (this.fundingApplicationDetails.implementations) { // when sds change make sure that fundingApplicationDetails contains correct places 
  //     let isPlace = [];
  //     this.fundingApplicationDetails.implementations.find(x => {
  //       x.places;
  //       isPlace = x.places
  //     });

  //     if (isPlace != null) {
  //       this.fundingApplicationDetails.implementations.forEach(x => {
  //         sdas.forEach(i => {
  //           // place already pushed to fundingApplicationDetails must be cleared out  if sda is no longer selected
  //           x.places.forEach(o => {
  //             if (o.serviceDeliveryAreaId == i.id) {
  //               count++;
  //             }
  //           })
  //         })
  //       })
  //     }
  //   }

  //   if (count == 0)
  //     this.fundingApplicationDetails.implementations.filter(x => { x.places = []; x.subPlaces = []; });

  // }

  // private setPlaces(sdas: ISDA[]): void {

  //   if (sdas && sdas.length != 0) {
  //     this._bidService.getPlaces(sdas).subscribe(res => {
  //       this.places = res;
  //       this.getPlace.emit(this.places)
  //       this._bidService.getSubPlaces(this.places).subscribe(res => {
  //         this.subPlacesAll = res;
  //         this.getSubPlace.emit(this.subPlacesAll)
  //       });
  //     });
  //   }
  // }

  // private GetSourceOfInformation() {
  //   this._npoProfile.getSourceOfInformationById(this.selectedApplicationId).subscribe(
  //     (results) => {
  //       this.sourceOfInformation = results;
  //       this.sourceOfInformationText = "Printed newspaper";
  //       if (results.find(results => results.selectedSourceValue === 1)) {
  //         this.sourceOfInformationText = "Printed newspaper";
  //       }
  //       if (results.find(results => results.selectedSourceValue === 2)) {
  //         this.sourceOfInformationText = "Online";
  //       }
  //       if (results.find(results => results.selectedSourceValue === 3)) {
  //         this.sourceOfInformationText = "DSD circular to NPOs";
  //       }
  //       if (results.find(results => results.selectedSourceValue === 4)) {
  //         this.sourceOfInformationText = "Other (specify)";
  //       }
  //     },
  //     (err) => {
  //       //
  //     }
  //   );
  // }

  // private GetAffiliatedOrganisation() {
  //   this._npoProfile.getAffiliatedOrganisationById(this.selectedApplicationId).subscribe(
  //     (results) => {
  //       this.affliatedOrganisationInfo = results;
  //       if (results.length > 0) {
  //         document.getElementById('affliatedOrganisationInfoTable').hidden = false;
  //       }
  //     },
  //     (err) => {
  //       //
  //     }
  //   );
  // }

  // updateDetail(rowData: IAffiliatedOrganisation) {

  //   this._npoProfile.updateAffiliatedOrganisationData(this.affliatedOrganisationInfo, this.selectedApplicationId).subscribe(
  //     (resp) => {
  //       this.GetAffiliatedOrganisation();
  //     },
  //     (err) => {
  //       //
  //     }
  //   );
  // }




  addNewRow() {
    this.affliatedOrganisationInfo.push({} as IAffiliatedOrganisation);
  }

  save() {
    //   var today = this.getCurrentDateTime();
    //   this.sourceOfInformations.npoProfileId = Number(this.selectedApplicationId);
    this.sourceOfInformations.selectedSourceValue = Number(this.selectedDropdownValue);
    this.sourceOfInformations.additionalSourceInformation = this.specify;
    console.log('sourceOfInformations', this.sourceOfInformations);
    //   this.updateSourceOfInformation(this.sourceOfInformations);

  }

  private updateSourceOfInformation(sourceOfInfo: ISourceOfInformation) {
    //selectedApplicationId is the funding application id
    // this._npoProfile.updateSourceOfInformation(sourceOfInfo, this.selectedApplicationId).subscribe(
    //   (resp) => {
    //     this.GetSourceOfInformation();
    //   },
    //   (err) => {
    //     //
    //   }
    // );
  }

  // private getCurrentDateTime() {
  //   let today = new Date();
  //   let nextTwoHours = today.getHours() + 2;
  //   today.setHours(nextTwoHours);

  //   return today;
  // }



  getSelectedValue(value: string) {
    this.selectedDropdownValue = value;
  }
}
