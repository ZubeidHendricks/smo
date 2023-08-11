import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { PermissionsEnum, AccessStatusEnum, ApplicationTypeEnum, QCStepsEnum, FundingApplicationStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IUser, INpo, IApplicationPeriod, IFundingApplicationDetails, IDistrictCouncil, ILocalMunicipality, IFundAppSDADetail, IApplicationDetails, IApplication, IPlace, ISubPlace, ISDA, IRegion, IObjective, IActivity, ISustainabilityPlan, IResource, IQuickCaptureDetails, IFinancialYear } from 'src/app/models/interfaces';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { MenuItem, Message, MessageService } from 'primeng/api';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-quick-capture-list',
  templateUrl: './quick-capture-list.component.html',
  styleUrls: ['./quick-capture-list.component.css']
})
export class QuickCaptureListComponent implements OnInit {


  @Input() newlySavedApplicationId: number;
  @Output() newlySavedApplicationIdChange: EventEmitter<number> = new EventEmitter<number>();

  canEdit: boolean = false;
  applicationIdOnBid: any;

  placesAll: IPlace[] = [];
  subPlacesAll: ISubPlace[] = [];
  
  dropdownTouched: boolean = false;  

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }
  public get ApplicationTypeEnum(): typeof ApplicationTypeEnum {
    return ApplicationTypeEnum;
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get QCStepsEnum(): typeof QCStepsEnum {
    return QCStepsEnum;
  }

  public get FundingApplicationStepsEnum(): typeof FundingApplicationStepsEnum {
    return FundingApplicationStepsEnum;
  }

  profile: IUser;
  cols: any[];
  allNPOs: INpo[];

  paramSubcriptions: Subscription;
  npoId: string;
  applicationPeriodId: number;
  id: string;

  menuActions: MenuItem[];
  validationErrors: Message[];

  applicationPeriod: IApplicationPeriod;
  isApplicationAvailable: boolean;
  placeAll: IPlace[] = [];

  // funding dropdowns
  // funding dropdowns
  districtCouncils: IDistrictCouncil[] = [];
  localMunicipalitiesAll: ILocalMunicipality[] = [];
  localMunicipalities: ILocalMunicipality[] = [];
  regions: IRegion[] = [];
  regionsAll: IRegion[] = [];
  sdasAll: ISDA[] = [];
  sdas: ISDA[] = [];
  // end of funding dropdowns

  items: MenuItem[];
  faItems: MenuItem[];
  qcItems: MenuItem[];

  activeStep: number = 0;
  application: IApplication;
 
  selectedOption: boolean;

  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  // funding dropdowns

  fundingApplicationDetails: IFundingApplicationDetails = {
    applicationDetails: {
      fundAppSDADetail: {
        districtCouncil: {} as IDistrictCouncil,
        localMunicipality: {} as ILocalMunicipality,
        regions: [],
        serviceDeliveryAreas: [],
      } as IFundAppSDADetail,
    } as IApplicationDetails,   

    financialMatters: [],
    implementations: [],

  } as IFundingApplicationDetails;

  // quickCaptureDetails: IQuickCaptureDetails = {
  //   fundingApplicationDetails: {
  //     applicationDetails: {
  //       fundAppSDADetail: {
  //         districtCouncil: {} as IDistrictCouncil,
  //         localMunicipality: {} as ILocalMunicipality,
  //         regions: [],
  //         serviceDeliveryAreas: [],
  //       } as IFundAppSDADetail,
  //     } as IApplicationDetails,   
  
  //     financialMatters: [],
  //     implementations: [],
  
  //   } as IFundingApplicationDetails,
  //   npo:{}  as INpo,

  // } as IQuickCaptureDetails;  

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _npoRepo: NpoService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _messageService: MessageService,
    private _fundAppService: FundingApplicationService,
    private _bidService: BidService
  ) { }

  ngOnInit(): void {
    // this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
    //   this.id = params.get('id');
    //   this.loadfundingDropdowns();
    //   this.applicationPeriodId = +this.id;
    //   this.fundingApplicationDetails.applicationPeriodId = +this.id;
    //   this._bidService.getApplicationBiId(+this.id).subscribe(resp => {
    //   });
    // });
console.log('ng onInit');
console.log('newlySavedApplicationId',this.newlySavedApplicationId);

this.loadfundingDropdowns();
    this.qCSteps();
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.AddApplication))
          this._router.navigate(['401']);

        this.buildMenu();
      }
    });
  }

  private loadfundingDropdowns() {
    debugger;
    this._spinner.show();
    
    this._applicationRepo.getApplicationById(this.newlySavedApplicationId).subscribe(
      (results) => {
        console.log('results',results);
        if (results != null) {
          this.application = results;
          this.fundingApplicationDetails.applicationPeriodId = this.application?.applicationPeriodId;
          //this.fundingApplicationDetails.applicationPeriod.applicationTypeId =3;
          this.qCSteps();
          this.isApplicationAvailable = true;
        }
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
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
            //if (this.application.applicationPeriod.applicationTypeId === ApplicationTypeEnum.FA) {
              this.bidForm(StatusEnum.Saved);
           // }
          }
        },

        {
          label: 'Submit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            if (this.application.applicationPeriod.applicationTypeId === ApplicationTypeEnum.FA) {
              this.bidForm(StatusEnum.PendingReview);
            }
          },
          disabled: true
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

  private bidForm(status: StatusEnum) {
    debugger;
    this.application.status = null;
    if (status === StatusEnum.Saved) {
      this.application.statusId = status;
    }
    if (status === StatusEnum.PendingReview) {
      this.application.statusId = status;
    }
    if (this.bidCanContinue(status)) {
      this.application.statusId = status;
      if (this.validationErrors.length == 0) {
        this._applicationRepo.updateApplication(this.application).subscribe();
      }
    }
        this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });

      if (status == StatusEnum.PendingReview) {
        this.application.status.name = "PendingReview";
             this._router.navigateByUrl('applications');
      }
    
  }


  private bidCanContinue(status: StatusEnum) {
    this.validationErrors = [];
    if (status === StatusEnum.PendingReview)
      this.formValidate();
    if (this.validationErrors.length == 0)
      return true;

    return false;
  }


  private formValidate() {
    this.validationErrors = [];  }

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[1].visible = false;
  }

  private saveItems(status: StatusEnum) {
    if (this.canContinue(status)) {
      this._spinner.show();
      this.application.statusId = status;

      this._applicationRepo.updateApplication(this.application).subscribe(
        (resp) => {
          if (resp.statusId === StatusEnum.Saved) {
            this.menuActions[3].visible = true;
            this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
          }

          if (resp.statusId === StatusEnum.PendingReview) {
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



  private canContinue(status: StatusEnum) {
    this.validationErrors = [];

    if (status === StatusEnum.PendingReview)
      this.formValidate();

    if (this.validationErrors.length == 0)
      return true;

    return false;
  }



  places(place: IPlace[]) {
    this.placeAll = place;
  }

  subPlaces(subPlaces: ISubPlace[]) {
    this.subPlacesAll = subPlaces;
  }


  getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];
    }

    return value;
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  add() {
    this._router.navigateByUrl('npo/create');
  }

  edit(npo: INpo) {
    this._router.navigateByUrl('npo/edit/' + npo.id);
  }

  private qCSteps() {
    debugger;
   
        this.qcItems = [
          { label: 'Organisation Details', command: (event: any) => { this.activeStep = 0; } },
          { label: 'Applications', command: (event: any) => { this.activeStep = 1; } },
          { label: 'Application Details', command: (event: any) => { this.activeStep = 2; } },
          { label: 'Application Document', command: (event: any) => { this.activeStep = 3; } }
        ];
      }  

}
