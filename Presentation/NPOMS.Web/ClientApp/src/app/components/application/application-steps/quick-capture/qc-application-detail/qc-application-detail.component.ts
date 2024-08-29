import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { IAffiliatedOrganisation, ISourceOfInformation } from 'src/app/models/FinancialMatters';
import { PermissionsEnum, DropdownTypeEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IPlace, ISubPlace, IApplicationPeriod, IUser, IDistrictCouncil, IFinancialYear, IDepartment, IProgramme, ISubProgramme, IApplicationType, ILocalMunicipality, IRegion, ISDA, IQuickCaptureDetails, IFundingApplicationDetails, IProjectInformation, IMonitoringAndEvaluation, IFundAppSDADetail, IApplicationDetails, INpoProfileFacilityList, INpo, INpoProfile, ISubProgrammeType } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-qc-application-detail',
  templateUrl: './qc-application-detail.component.html',
  styleUrls: ['./qc-application-detail.component.css']
})
export class QcApplicationDetailComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() applicationPeriod: IApplicationPeriod;
  @Input() application: IApplication;

  @Input() districtCouncil: IDistrictCouncil;
  @Output() districtCouncilChange: EventEmitter<IDistrictCouncil> = new EventEmitter<IDistrictCouncil>();
  @Input() localMunicipality: ILocalMunicipality;
  @Output() localMunicipalityChange: EventEmitter<ILocalMunicipality> = new EventEmitter<ILocalMunicipality>();
  @Input() regions: IRegion[];
  @Output() regionsChange: EventEmitter<IRegion[]> = new EventEmitter<IRegion[]>();
  @Input() sdas: ISDA[];
  @Output() sdasChange: EventEmitter<ISDA[]> = new EventEmitter<ISDA[]>();

  @Output() amountChange: EventEmitter<number> = new EventEmitter<number>();

  @Input() sourceOfInformation: ISourceOfInformation[];
  @Output() sourceOfInformationChange: EventEmitter<ISourceOfInformation[]> = new EventEmitter<ISourceOfInformation[]>();

  @Input() affliatedOrganisationInfo: IAffiliatedOrganisation[];
  @Output() affliatedOrganisationInfoChange: EventEmitter<IAffiliatedOrganisation[]> = new EventEmitter<IAffiliatedOrganisation[]>();

  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Output() fundingApplicationDetailsChange: EventEmitter<IFundingApplicationDetails> = new EventEmitter<IFundingApplicationDetails>();

  @Input() isReadOnly: boolean;
  @Input() initiatedQuestion: string;
  @Input() purposeQuestion: string;
  @Output() purposeQuestionChange = new EventEmitter();
  @Input() npo: INpo;
 //purposeQuestion: IProjectInformation;
 
  // fundingApplicationDetail: IFundingApplicationDetails = {
  //   financialMatters: [],
  //   implementations: [],
  //   projectInformation: {} as IProjectInformation,
  //   monitoringEvaluation: {} as IMonitoringAndEvaluation,
  //   applicationDetails: {} as IApplicationDetails
  // } as IFundingApplicationDetails;
  
  applicationNpoId: number;
  profile: IUser;
  facilityInfoCols: any[];
  isDataAvailable: boolean;
  department: IDepartment;
  programme: IProgramme;
  subProgramme: ISubProgramme;
  subProgrammeType: ISubProgrammeType;
  applicationType: IApplicationType;
  financialYear: IFinancialYear;
  projectInformation: IProjectInformation;

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
  cols: any[];
  npoProfileFacilityLists: INpoProfileFacilityList[];
  specify: string;
  npoProfile: INpoProfile;
  stateOptions: any[];
  selectedDropdownValue: string;
  rowGroupMetadata: any[];
  constructor(
     private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
     private _applicationRepo: ApplicationService,
    private _applicationPeriodRepo: ApplicationPeriodService,
    private _fundAppService: FundingApplicationService,
     private _bidService: BidService,
    private _messageService: MessageService,
    private _loggerService: LoggerService,
    private _npoProfile: NpoProfileService,
    
  ) { }

  ngOnInit(): void {

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
      //  this._spinner.show();
        this.profile = profile;

        if(this.npo !== undefined)
        {
          this.applicationNpoId = Number(this.npo.id);  
        }
        else{
          this.applicationNpoId = Number(this.application.npoId);
        }
        
        this.loadApplicationPeriod();  
        this.loadFacilities();
      }
    });

   
    
    this.cols = [
      { header: 'Description', width: '45%' },
      { header: 'Beneficiaries', width: '25%' },
      { header: 'Budget', width: '15%' },
      { header: 'Actions', width: '10%' }
    ];

    this.stateOptions = [
      { label: 'Yes', value: 'Yes' },
      { label: 'No', value: 'No' }
    ];

    this.facilityInfoCols = [
      { header: 'Sub-District', width: '18%' },
      { header: 'Facility or Community Place Name', width: '30%' },
      { header: 'Class', width: '15%' },
      { header: 'Address', width: '30%' }
    ];
  }

  private loadApplicationPeriod() {
    this._applicationPeriodRepo.getApplicationPeriodById(this.applicationPeriod.id).subscribe(
      (results) => {
        this.department = results.department;
        this.programme = results.programme;
        this.subProgramme = results.subProgramme;
        this.subProgrammeType = results.subProgrammeType;
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
        this.updateDropdownSelections();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateDropdownSelections() {
   
    //add default value as work around
    this.selectedDistrictCouncil = this.allDistrictCouncils.find(x => x.id === 1);
    this.selectedLocalMunicipality = this.filteredLocalMunicipalities.find(x => x.id === 1);
    if (this.sdas)
      this.selectedSDAs = this.filteredServiceDeliveryAreas.filter(x => {
        return this.sdas.some(y => {
          return y.id === x.id;
        });
      });
  }

  private GetAffiliatedOrganisation() {
    this.affliatedOrganisationInfo = [];

    if (this.application) {
      this._npoProfile.getAffiliatedOrganisationById(this.application.id).subscribe(
        (results) => {
          this.affliatedOrganisationInfo = results;
          this.affliatedOrganisationInfoChange.emit(this.affliatedOrganisationInfo);

          if (results.length > 0)
            document.getElementById('affliatedOrganisationInfoTable').hidden = false;

          this.isDataAvailable = true;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
    else {
      this.isDataAvailable = true;
      this._spinner.hide();
    }
  }


  onAmountChange(value) {
    this.amountChange.emit(value);
  }

  showTable(obj: any) {
    if (obj.value === "Yes")
      document.getElementById('affliatedOrganisationInfoTable').hidden = false;
    else
      document.getElementById('affliatedOrganisationInfoTable').hidden = true;
  }

  nextPage() {
    if (this.canContinue()) {
      if (!this.fundingApplicationDetails.id) {
        //create funding application details

        this.application.npoId = this.npo.id;
        this.application.applicationPeriodId = this.applicationPeriod.id;
        this.application.programmeId = this.applicationPeriod.programmeId;
        this.application.subProgrammeId = this.applicationPeriod.subProgrammeId;
        this.application.subProgrammeTypeId = this.applicationPeriod.subProgrammeTypeId;
        this.application.statusId = StatusEnum.Saved;
        this.application.applicationPeriod = this.applicationPeriod;
        this._applicationRepo.createQCApplication(this.application).subscribe(
          (resp) => {
            if(resp.id == undefined)
            {
              alert(resp.message);
              this._spinner.hide();
              return false;           
            }
            else{
              this.fundingApplicationDetails.applicationId = resp.id;
              this.fundingApplicationDetails.applicationPeriodId = this.applicationPeriod.id;
              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil = this.allDistrictCouncils[0];
              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = this.allLocalMunicipalities[0];
              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = this.allRegions.filter(x => x.isActive && x.localMunicipalityId === this.allLocalMunicipalities[0].id);
              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = this.allServiceDeliveryAreas.filter(x => x.isActive && x.regionId === this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions[0].id);        
              this.fundingApplicationDetails.projectInformation.purposeQuestion = this.purposeQuestion;
              this.fundingApplicationDetails.applicationDetails.amountApplyingFor = 1;
              this._fundAppService.addFundingApplicationDetails(this.fundingApplicationDetails).subscribe(
                (resp) => {
                  this._spinner.hide();
                  this.fundingApplicationDetails.id = resp.id;
                  this.fundingApplicationDetailsChange.emit(resp);
      
                  this.activeStep = this.activeStep + 1;
                  this.activeStepChange.emit(this.activeStep);
                },
                (err) => {
                  this._loggerService.logException(err);
                  this._spinner.hide();
                }
              );
            }   
          },
          (err) => {
            this._loggerService.logException(err);       
            this._spinner.hide();
          }
        );    
        
      }
      else {
        this.fundingApplicationDetails.applicationDetails.amountApplyingFor = 1;
        this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil = this.allDistrictCouncils[0]
        this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = this.allLocalMunicipalities[0];
        this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = this.allRegions;
        this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = this.allServiceDeliveryAreas;        
        this.fundingApplicationDetails.projectInformation.purposeQuestion = this.purposeQuestion;
        this._fundAppService.editFundingApplicationDetails(this.fundingApplicationDetails).subscribe(
          (resp) => {
            this._spinner.hide();
            this.fundingApplicationDetailsChange.emit(resp);

            this.activeStep = this.activeStep + 1;
            this.activeStepChange.emit(this.activeStep);
          },
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
          }
        );
      }
    }
}

  // nextPage1() {
  //   if (this.canContinue()) {

  //     if (!this.fundingApplicationDetails.id) {
  //       //create funding application details
  //       this.fundingApplicationDetails.applicationId = this.application.id;
  //       this.fundingApplicationDetails.applicationPeriodId = this.applicationPeriod.id;
  //       this.fundingApplicationDetails.applicationDetails.amountApplyingFor = 1;
  //       this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil = this.selectedDistrictCouncil;
  //       this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = this.selectedLocalMunicipality;
  //       this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = this.selectedRegions;
  //       this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = this.selectedSDAs;        
  //       this.fundingApplicationDetails.projectInformation.purposeQuestion = this.purposeQuestion;
  //       this._fundAppService.addFundingApplicationDetails(this.fundingApplicationDetails).subscribe(
  //         (resp) => {
  //           this._spinner.hide();
  //           this.fundingApplicationDetails.id = resp.id;
  //           this.fundingApplicationDetailsChange.emit(resp);

  //           this.activeStep = this.activeStep + 1;
  //           this.activeStepChange.emit(this.activeStep);
  //         },
  //         (err) => {
  //           this._loggerService.logException(err);
  //           this._spinner.hide();
  //         }
  //       );
  //     }
  //     else {
  //       this.fundingApplicationDetails.applicationDetails.amountApplyingFor = 1;
  //       this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil = this.selectedDistrictCouncil;
  //       this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = this.selectedLocalMunicipality;
  //       this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions = this.selectedRegions;
  //       this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = this.selectedSDAs;
  //       this.fundingApplicationDetails.projectInformation.purposeQuestion = this.purposeQuestion;
  //       this._fundAppService.editFundingApplicationDetails(this.fundingApplicationDetails).subscribe(
  //         (resp) => {
  //           this._spinner.hide();
  //           this.fundingApplicationDetailsChange.emit(resp);

  //           this.activeStep = this.activeStep + 1;
  //           this.activeStepChange.emit(this.activeStep);
  //         },
  //         (err) => {
  //           this._loggerService.logException(err);
  //           this._spinner.hide();
  //         }
  //       );
  //     }
  //     this.bidForm(StatusEnum.Saved);
  //   }

  //  }


  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  private canContinue() {
    let applicationDetailsError: string[] = [];

    if (applicationDetailsError.length > 0)
      this._messageService.add({ severity: 'error', summary: "Application Details:", detail: applicationDetailsError.join('; ') });

    return applicationDetailsError.length > 0 ? false : true;
  }

  addNewRow() {
    this._spinner.show();
    this.updateAffiliatedOrganisationData({} as IAffiliatedOrganisation);
  }

  updateDetail(rowData: IAffiliatedOrganisation) {
    this.updateAffiliatedOrganisationData(rowData);
  }

  private updateAffiliatedOrganisationData(data: IAffiliatedOrganisation) {
    this._npoProfile.updateAffiliatedOrganisationData(data, this.application.id.toString()).subscribe(
      (resp) => {
        this.GetAffiliatedOrganisation();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  save() {
    if (this.application) {
      let data = {
        npoProfileId: this.application.id,
        selectedSourceValue: Number(this.selectedDropdownValue),
        additionalSourceInformation: this.specify
      } as ISourceOfInformation;

     // this.updateSourceOfInformation(data);
    }
  }

  private updateSourceOfInformation(sourceOfInfo: ISourceOfInformation) {
    this._npoProfile.updateSourceOfInformation(sourceOfInfo, this.application.id.toString()).subscribe(
      (resp) => {
      //  this.GetSourceOfInformation();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  getSelectedValue(value: string) {
    this.selectedDropdownValue = value;
  }

  readonly(): boolean {

    if (this.application.statusId == StatusEnum.PendingReview ||
      this.application.statusId == StatusEnum.Approved)
      return true;
    else return false;
  }

  onPurposeQuestionChange($event) {
    this.purposeQuestionChange.emit($event);
  }

  private loadFacilities() {
    this._npoProfile.getFacilitiesByNpoId(this.applicationNpoId).subscribe(
      (results) => {
        this.npoProfileFacilityLists = results;
        this.updateRowGroupMetaData();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  } 

  private updateRowGroupMetaData() {
    this.rowGroupMetadata = [];

    this.npoProfileFacilityLists = this.npoProfileFacilityLists.sort((a, b) => a.facilityList.facilityType.id - b.facilityList.facilityType.id);

    if (this.npoProfileFacilityLists) {

      this.npoProfileFacilityLists.forEach(element => {

        var itemExists = this.rowGroupMetadata.some(function (data) { return data.itemName === element.facilityList.facilityType.name });

        this.rowGroupMetadata.push({
          itemName: element.facilityList.facilityType.name,
          itemExists: itemExists
        });
      });
    }
  }

  private bidForm(status: StatusEnum) {
      this.application.statusId = status;

      if (!this.fundingApplicationDetails.id) {
        this._bidService.addBid(this.fundingApplicationDetails).subscribe(resp => {
        //  this._menuActions[1].visible = false;
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
          resp;
        });
      }
     else {
        this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => {
          if (resp) {
           // this._router.navigateByUrl(`application/edit/${this.application.id}/${this.activeStep}`);
            this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
          }
        });
     }

  }
}
