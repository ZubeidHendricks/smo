import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subscription } from 'rxjs';
import {
  ApplicationTypeEnum, DropdownTypeEnum, FacilityTypeEnum, IQuestionResponseViewModel, IResponseHistory,
  ResponseTypeEnum, PermissionsEnum, ServiceProvisionStepsEnum, IResponseType, FrequencyEnum, FrequencyPeriodEnum, StatusEnum
} from 'src/app/models/enums';
import {
  IActivity, IApplication, IApplicationAudit, ICapturedResponse, IFinancialYear, INpo, IObjective, IQuestionCategory,
  IResponse, IResponseOption, IResponseOptions, IStatus, IUser, IWorkflowAssessment, IWorkplanIndicator, IWorkplanIndicatorSummary
} from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { EvaluationService } from 'src/app/services/evaluation/evaluation.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-scorecard-action',
  templateUrl: './scorecard-action.component.html',
  styleUrls: ['./scorecard-action.component.css']
})
export class ScorecardActionComponent implements OnInit {

  isSystemAdmin: boolean;
  isAdmin: boolean;
  hasAdminRole: boolean;
  profile: IUser;

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

  public get FacilityTypeEnum(): typeof FacilityTypeEnum {
    return FacilityTypeEnum;
  }
  public get FrequencyEnum(): typeof FrequencyEnum {
    return FrequencyEnum;
  }

  public get FrequencyPeriodEnum(): typeof FrequencyPeriodEnum {
    return FrequencyPeriodEnum;
  }

  applicationAudits: IApplicationAudit[];
  _recommendation: boolean = false;
  responseOptions: IResponseOption[];
  _responses: IResponseOptions[];
  responseHistory: IResponseHistory[];
  displayHistoryDialog: boolean;
  historyCols: any[];
  displayHistory: boolean;
  paramSubcriptions: Subscription;
  id: string;
  application: IApplication;
  allQuestionnaires: IQuestionResponseViewModel[] = [];
  engagementQuestionnaire: IQuestionResponseViewModel[];
  timeWorkPlanQuestionnaire: IQuestionResponseViewModel[];
  impactQuestionnaire: IQuestionResponseViewModel[];
  riskMitigationQuestionnaire: IQuestionResponseViewModel[];
  appropriationOfResourcesQuestionnaire: IQuestionResponseViewModel[];
  overallAverageScore: number = 0;
  QuestionCategoryentities: IQuestionCategory[];
  ResponseTypeentities: IResponseType[];
  auditCols: any[];
  workplanIndicators: IWorkplanIndicator[];
  filteredWorkplanIndicators: IWorkplanIndicatorSummary[];
  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;
  scrollableCols: any[];
  finYear: number;
  fincYear: string;
  frozenCols: any[];
  objectives: IObjective[] = [];
  activities: IActivity[];
  applications: IApplication;
  statuses: IStatus[];
  rowGroupMetadataActivities: any[];
  overallTotalScores: number = 0;
  overallAvgScore: number = 0;

  captureImprovementArea: string;
  captureRequiredAction: string;

  hascapturedImprovementArea: boolean = false;
  hasCapturedRequiredAction: boolean = false;
  hasScorecardSubmitted: boolean = false;

  signedByUser: string;
  submittedDate: Date;
  npo: INpo;
  organisation: string;
  capturedResponses: ICapturedResponse[];
  capturedResponsesCount: ICapturedResponse[];
  capturedResponseCount: ICapturedResponse[];
  userId: number;
  workFlowCount: IWorkflowAssessment[];
  headerTitle: string;

  constructor(

    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _evaluationService: EvaluationService,
    private _loggerService: LoggerService,
    private _dropdownService: DropdownService,
    private _indicatorRepo: IndicatorService,
    private _npoRepo: NpoService,

  ) { }

  ngOnInit(): void {
    this._spinner.show();

    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
    });

    var splitUrl = window.location.href.split('/');
    this.headerTitle = splitUrl[4];

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        this.userId = this.profile.id;
      }
    });

    if(this.headerTitle === 'initiate')
    {
      this.UpdateInitiateScorecardValue();
    }
    else{
      this.UpdateCloseScorecardValue();
    }
  } 

  private UpdateInitiateScorecardValue() {
    this._applicationRepo.UpdateInitiateScorecardValue(Number(this.id)).subscribe(
      (results) => {
        this.application = results;
        this._router.navigateByUrl('applications');
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private UpdateCloseScorecardValue() {
    this._applicationRepo.UpdateCloseScorecardValue(Number(this.id)).subscribe(
      (results) => {
        this.application = results;
        this._router.navigateByUrl('applications');
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
}
