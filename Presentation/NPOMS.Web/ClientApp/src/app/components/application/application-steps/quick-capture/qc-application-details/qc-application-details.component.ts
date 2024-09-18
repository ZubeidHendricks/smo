import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { IAffiliatedOrganisation, ISourceOfInformation } from 'src/app/models/FinancialMatters';
import { PermissionsEnum, DropdownTypeEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IPlace, ISubPlace, IApplicationPeriod, IUser, IDistrictCouncil, IFinancialYear, IDepartment, IProgramme, ISubProgramme, IApplicationType, ILocalMunicipality, IRegion, ISDA, IQuickCaptureDetails, IFundingApplicationDetails, IProjectInformation, IMonitoringAndEvaluation, IFundAppSDADetail, IApplicationDetails, ISubProgrammeType, IProgrammeServiceDelivery, INpo } from 'src/app/models/interfaces';
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
  @Input() application: IApplication;
  @Output() applicationChange: EventEmitter<IApplication> = new EventEmitter<IApplication>();
  @Input() fundingApplicationDetails: IFundingApplicationDetails;

  @Input() districtCouncil: IDistrictCouncil;
  @Output() districtCouncilChange: EventEmitter<IDistrictCouncil> = new EventEmitter<IDistrictCouncil>();
  @Input() localMunicipality: ILocalMunicipality;
  @Output() localMunicipalityChange: EventEmitter<ILocalMunicipality> = new EventEmitter<ILocalMunicipality>();
  @Input() regions: IRegion[];
  @Output() regionsChange: EventEmitter<IRegion[]> = new EventEmitter<IRegion[]>();
  @Input() sdas: ISDA[];
  @Output() sdasChange: EventEmitter<ISDA[]> = new EventEmitter<ISDA[]>();
  @Input() npo: INpo;
  @Input() programId: number;
  @Input() subProgramId: number;
  @Input() subProgramTypeId: number;

  @Input() amount: number;
  @Output() amountChange: EventEmitter<number> = new EventEmitter<number>();

  @Input() sourceOfInformation: ISourceOfInformation[];
  @Output() sourceOfInformationChange: EventEmitter<ISourceOfInformation[]> = new EventEmitter<ISourceOfInformation[]>();

  @Input() affliatedOrganisationInfo: IAffiliatedOrganisation[];
  @Output() affliatedOrganisationInfoChange: EventEmitter<IAffiliatedOrganisation[]> = new EventEmitter<IAffiliatedOrganisation[]>();

  @Output() fundingApplicationDetailsChange: EventEmitter<IFundingApplicationDetails> = new EventEmitter<IFundingApplicationDetails>();

  profile: IUser;

  isDataAvailable: boolean;
  department: IDepartment;
  programme: IProgramme;
  subProgramme: ISubProgramme;
  subProgrammeType: ISubProgrammeType;
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

  specify: string;
  isSDASelected: boolean;

  stateOptions: any[];

  selectedDropdownValue: string;

  programDeliveryDetails : IProgrammeServiceDelivery[];
  selectedProgramDeliveryDetails : IProgrammeServiceDelivery[];

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _applicationPeriodRepo: ApplicationPeriodService,
    private _fundAppService: FundingApplicationService,
    private _messageService: MessageService,
    private _loggerService: LoggerService,
    private _npoProfile: NpoProfileService,
    private _applicationRepo: ApplicationService
  ) { }

  ngOnInit(): void {

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        this.loadApplicationPeriod();
      }
    });
    
    this.stateOptions = [
      { label: 'Yes', value: 'Yes' },
      { label: 'No', value: 'No' }
    ];

    this.getProgrammeDeliveryDetails();
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
      //  this.updateDropdownSelections();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateDropdownSelections() {
    if (this.districtCouncil) {
      this.districtCouncilDropdownChange(this.districtCouncil);
      this.selectedDistrictCouncil = this.allDistrictCouncils.find(x => x.id === this.districtCouncil.id);
    }

    if (this.localMunicipality) {
      this.localMunicipalityDropdownChange(this.localMunicipality);
      this.selectedLocalMunicipality = this.filteredLocalMunicipalities.find(x => x.id === this.localMunicipality.id);
    }

    if (this.regions) {
      this.regionDropdownChange(this.regions);
      this.selectedRegions = this.filteredRegions.filter(x => {
        return this.regions.some(y => {
          return y.id === x.id;
        });
      });
    }

    if (this.sdas)
      this.selectedSDAs = this.filteredServiceDeliveryAreas.filter(x => {
        return this.sdas.some(y => {
          return y.id === x.id;
        });
      });

   // this.GetSourceOfInformation();
  }

  private GetSourceOfInformation() {
    this.sourceOfInformation = [];

    if (this.application) {
      this._npoProfile.getSourceOfInformationById(this.application.id).subscribe(
        (results) => {
          this.sourceOfInformation = results;
          this.sourceOfInformationChange.emit(this.sourceOfInformation);

          this.sourceOfInformation.forEach(item => {
            switch (item.selectedSourceValue) {
              case 1:
                item.sourceOfInformationText = "Printed newspaper";
                break;
              case 2:
                item.sourceOfInformationText = "Online";
                break;
              case 3:
                item.sourceOfInformationText = "DSD circular to NPOs";
                break;
              case 4:
                item.sourceOfInformationText = "Other (specify)";
                break;
            }
          });

          this.GetAffiliatedOrganisation();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
    else
      this.GetAffiliatedOrganisation();
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

  private getProgrammeDeliveryDetails() {
    this._npoProfile.getProgrammeDeliveryDetailsQC(Number(this.npo.id)).subscribe(
      (results) => {
        if (results != null) {
          this.programDeliveryDetails =  results.filter(deliveryDetail => deliveryDetail.isActive && deliveryDetail.programId === this.programId && deliveryDetail.subProgrammeId === this.subProgramId && deliveryDetail.subProgrammeTypeId === this.subProgramTypeId);
          this.selectedProgramDeliveryDetails = results.filter(deliveryDetail => deliveryDetail.isActive && deliveryDetail.programId === this.programId && deliveryDetail.subProgrammeId === this.subProgramId && deliveryDetail.subProgrammeTypeId === this.subProgramTypeId && deliveryDetail.isSelected === true);
        } 
        this._spinner.hide();
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


  onAmountChange(value) {
    this.amountChange.emit(value);
  }


  showTable(obj: any) {
    if (obj.value === "Yes")
      document.getElementById('affliatedOrganisationInfoTable').hidden = false;
    else
      document.getElementById('affliatedOrganisationInfoTable').hidden = true;
  }

 

  readonly(): boolean {
    // if (this.application.statusId ==StatusEnum.PendingReview ||
    //  this.application.statusId == StatusEnum.Approved )
    //  return true;
    // else return false;
    return false;
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
              this.fundingApplicationDetails.applicationDetails.amountApplyingFor = this.amount;
              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil = this.allDistrictCouncils.find(x => x.id === this.programDeliveryDetails[0].districtCouncil.id);
              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = this.allLocalMunicipalities.find(x => x.id === this.programDeliveryDetails[0].localMunicipality.id);
              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions =  this.allRegions.filter(x => x.localMunicipalityId === this.programDeliveryDetails[0].localMunicipalityId);
              this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = this.allServiceDeliveryAreas.filter(x => x.regionId === this.programDeliveryDetails[0].regionId);
              this._fundAppService.addFundingApplicationDetails(this.fundingApplicationDetails).subscribe(
                (resp) => {
                  this._spinner.hide();
                  this.fundingApplicationDetails.id = resp.id;
                  this.fundingApplicationDetailsChange.emit(resp);
                  this._router.navigateByUrl(`quick-captures-editList/edit/${this.fundingApplicationDetails.applicationId}/${this.activeStep}`); 
                  
                 // this.activeStep = this.activeStep + 1;
                 // this.activeStepChange.emit(this.activeStep);
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
        this.fundingApplicationDetails.applicationDetails.amountApplyingFor = this.amount;
        this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil = this.allDistrictCouncils.find(x => x.id === this.programDeliveryDetails[0].districtCouncil.id);
        this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality = this.allLocalMunicipalities.find(x => x.id === this.programDeliveryDetails[0].localMunicipality.id);
        this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.regions =  this.allRegions.filter(x => x.localMunicipalityId === this.programDeliveryDetails[0].localMunicipalityId);
        this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.serviceDeliveryAreas = this.allServiceDeliveryAreas.filter(x => x.regionId === this.programDeliveryDetails[0].regionId);
      
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

  setValue(event, value) {  
    if(event.target.checked)
      {
        this.isSDASelected = true;
      }
      else
      {
        this.isSDASelected = false;
      }  
      
      this._npoProfile.updateProgrammeDeliveryServiceSelection(value, this.isSDASelected).subscribe(resp => {    
        this.getProgrammeDeliveryDetails();    
      },
      (err) => {
        this._loggerService.logException(err);
      });
  }


  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  private canContinue() {
    let applicationDetailsError: string[] = [];

    if(this.selectedProgramDeliveryDetails.length === 0)
    {
      applicationDetailsError.push("Please select a Service Delivery Area");
    }
    
    if (!this.amount)
      applicationDetailsError.push("Please specify the Rand amount you applying for");

    if (applicationDetailsError.length > 0)
      this._messageService.add({ severity: 'error', summary: "Application Details:", detail: applicationDetailsError.join('; ') });

    return applicationDetailsError.length > 0 ? false : true;
  }

  public districtCouncilDropdownChange(districtCouncil: IDistrictCouncil) {
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

    this.districtCouncilChange.emit(districtCouncil);
  }

  public localMunicipalityDropdownChange(localMunicipality: ILocalMunicipality) {
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

    this.localMunicipalityChange.emit(localMunicipality);
  }

  public regionDropdownChange(regions: IRegion[]) {
    this.selectedSDAs = [];
    this.filteredServiceDeliveryAreas = [];

    if (regions.length > 0) {
      for (var i = 0; i < this.allServiceDeliveryAreas.length; i++) {
        if (regions.filter(x => x.id === this.allServiceDeliveryAreas[i].regionId).length != 0) {
          this.filteredServiceDeliveryAreas.push(this.allServiceDeliveryAreas[i]);
        }
      }
    }

    this.regionsChange.emit(regions);
  }

  public sdaDropdownChange(sdas: ISDA[]) {
    this.sdasChange.emit(sdas);
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

      this.updateSourceOfInformation(data);
    }
  }

  private updateSourceOfInformation(sourceOfInfo: ISourceOfInformation) {
    this._npoProfile.updateSourceOfInformation(sourceOfInfo, this.application.id.toString()).subscribe(
      (resp) => {
        this.GetSourceOfInformation();
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
}
