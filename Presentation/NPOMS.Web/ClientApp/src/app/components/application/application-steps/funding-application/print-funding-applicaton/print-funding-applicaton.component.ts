import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subscription } from 'rxjs';
import { PermissionsEnum, ApplicationTypeEnum, ServiceProvisionStepsEnum, FundingApplicationStepsEnum } from 'src/app/models/enums';
import { IUser, IApplication, IObjective, IActivity, ISustainabilityPlan, IResource, IApplicationDetails, 
  IMonitoringAndEvaluation, IProjectInformation, IFundingApplicationDetails, IPlace, ISubPlace } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-print-funding-applicaton',
  templateUrl: './print-funding-applicaton.component.html',
  styleUrls: ['./print-funding-applicaton.component.css']
})
export class PrintFundingApplicatonComponent implements OnInit {
 
  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get ApplicationTypeEnum(): typeof ApplicationTypeEnum {
    return ApplicationTypeEnum;
  }

  public get ServiceProvisionStepsEnum(): typeof ServiceProvisionStepsEnum {
    return ServiceProvisionStepsEnum;
  }

  public get FundingApplicationStepsEnum(): typeof FundingApplicationStepsEnum {
    return FundingApplicationStepsEnum;
  }

  applicationPeriodId: number;
  paramSubcriptions: Subscription;
  id: string;
  bidId: number;
  placeAll: IPlace[] = [];
  subPlacesAll: ISubPlace[] = [];
  applicationIdOnBid: any;
  selectedApplicationId: number;
  profile: IUser;
  activeStep: number = 0;
  application: IApplication;
  isApplicationAvailable: boolean;

  objectives: IObjective[] = [];
  activities: IActivity[] = [];
  sustainabilityPlans: ISustainabilityPlan[] = [];
  resources: IResource[] = [];


  fundingApplicationDetails: IFundingApplicationDetails = {
    financialMatters: [],
    implementations: [],
    projectInformation: {} as IProjectInformation,
    monitoringEvaluation: {} as IMonitoringAndEvaluation,
    applicationDetails: {} as IApplicationDetails
  } as IFundingApplicationDetails;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _bidService: BidService,
    private _loggerService: LoggerService
  ) { }
  places(place: IPlace[]) {
    this.placeAll = place;
  }

  subPlaces(subPlaces: ISubPlace[]) {
    this.subPlacesAll = subPlaces;
  }
  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
      this.loadApplication();
      this.loadfundingSteps();
    });


    this.applicationPeriodId = +this.id;
    this.fundingApplicationDetails.applicationPeriodId = +this.id;

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.EditApplication))
          this._router.navigate(['401']);
      }
      
    });
 }

  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
          this.isApplicationAvailable = true;
        }

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  //funding drop downs
  private loadfundingSteps() {

    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
          this._bidService.getApplicationBiId(results.id).subscribe(response => { // can you please return bid obj not DOM
            if (response.id != null) {
              this.getFundingApplicationDetails(response);
              console.log('data.result', response);
            }
          });
          this.isApplicationAvailable = true;
        
        setTimeout(() => {
          document.title = "DSD - Online Funding Application - " + results.applicationPeriod.name;
          window.print();
          this._router.navigate([{ outlets: { print: null } }]);
        }, 2500);
      }
    },
      (err) => 
      {
        this._spinner.hide()
      }
    );
  }

  private getFundingApplicationDetails(data) {
    this._bidService.getBid(data.id).subscribe(response => {
      this.getBidFullObject(response);
    });

  }

  private getBidFullObject(data) {
    debugger;
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
 
}
