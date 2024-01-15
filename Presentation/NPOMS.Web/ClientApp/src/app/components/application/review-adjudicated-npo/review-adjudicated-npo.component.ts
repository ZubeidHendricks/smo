import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import {
  ApplicationTypeEnum, DropdownTypeEnum, FacilityTypeEnum, IQuestionResponseViewModel, IResponseHistory,
  ResponseTypeEnum, PermissionsEnum, ServiceProvisionStepsEnum, IResponseType, FrequencyEnum, FrequencyPeriodEnum, StatusEnum
} from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationAudit, ICapturedResponse, IFinancialYear, INpo, IObjective, IQuestionCategory, IResponse, IResponseOption, IResponseOptions, IGetResponseOptions, IStatus, IUser, IWorkplanIndicator, IWorkplanIndicatorSummary, IApplicationPeriod, IDistrictCouncil, IApplicationDetails, IFundAppSDADetail, IFundingApplicationDetails, ILocalMunicipality, IProjectInformation, IRegion, ISDA } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { EvaluationService } from 'src/app/services/evaluation/evaluation.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { ISourceOfInformation, IAffiliatedOrganisation } from 'src/app/models/FinancialMatters';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { UserService } from 'src/app/services/api-services/user/user.service';

export interface IResp {
  name: string
}

@Component({
  selector: 'app-review-adjudicated-npo',
  templateUrl: './review-adjudicated-npo.component.html',
  styleUrls: ['./review-adjudicated-npo.component.css']
})
export class ReviewAdjudicatedNpoComponent implements OnInit {

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
  _responseUsers: IGetResponseOptions[];
  responseHistory: IResponseHistory[];
  displayCommentDialog: boolean;
  displayDialog: boolean;
  historyCols: any[];
  displayHistory: boolean;
  paramSubcriptions: Subscription;
  id: string;
  application: IApplication;
  allQuestionnaires: IQuestionResponseViewModel[];
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
  frozenCols: any[];
  objectives: IObjective[] = [];
  activities: IActivity[];
  applications: IApplication;
  evaluationStatuses: IStatus[];
  selectedStatus: IStatus;
  statuses: IStatus[];
  rowGroupMetadataActivities: any[];
  scorer1: number;
  scorer2: number;
  scorer3: number;
  scorer4: number;
  socrer1OverallTotalScore: number;
  socrer2OverallTotalScore: number;
  socrer3OverallTotalScore: number;
  socrer4OverallTotalScore: number;
  allSocrerOverallTotalScore: number;
  scorer1OverallAvgScore: number;
  scorer2OverallAvgScore: number;
  scorer3OverallAvgScore: number;
  scorer4OverallAvgScore: number;
  allScorerOverallAvgScore: number;
  objectiveTarget: number;
  objectiveActual: number;
  objectiveAverage: number;

  reasonOfNonRecommendation: string;
  captureRequiredAction: string;
  captureImprovementAreaComment: string;
  captureRequiredActionComment: string;

  hascapturedImprovementArea: boolean = false;
  hasCapturedRequiredAction: boolean = false;
  hasScorecardSubmitted: boolean = false;
  isDataAvailable: boolean;
  signedByUser: string;
  submittedDate: Date;
  signedByUserScorecardUser: string;
  submittedDateByScorecardUser: Date;
  npo: INpo;
  organisation: string;
  capturedResponses: ICapturedResponse[];
  name: IResp[] = [];
  _name: IResp[] = [];
  userId: number;


  isMainReviewer: boolean;
  canReviewOrApprove: boolean = false;

  applicationId: string;

  applicationPeriod: IApplicationPeriod;
  status: StatusEnum;

  districtCouncil: IDistrictCouncil;
  localMunicipality: ILocalMunicipality;
  regions: IRegion[];
  sdas: ISDA[];
  projectInformation: IProjectInformation;
  purposeQuestion: string;
  menuActions: MenuItem[];
  validationErrors: Message[];
  qcItems: MenuItem[];
  isStepsAvailable: boolean;

  amount: number;
  sourceOfInformation: ISourceOfInformation[];
  affliatedOrganisationInfo: IAffiliatedOrganisation[];

  fundingApplicationDetails: IFundingApplicationDetails = {
    applicationDetails: {
      fundAppSDADetail: {
        districtCouncil: {} as IDistrictCouncil,
        localMunicipality: {} as ILocalMunicipality,
        regions: [],
        serviceDeliveryAreas: [],
      } as IFundAppSDADetail
    } as IApplicationDetails,
    projectInformation: {} as IProjectInformation
  } as IFundingApplicationDetails;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _dropdownRepo: DropdownService,
    private _applicationPeriodRepo: ApplicationPeriodService,
    private _evaluationService: EvaluationService,
    private _documentStore: DocumentStoreService,
    private _loggerService: LoggerService,
    private _dropdownService: DropdownService,
    private confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private _datepipe: DatePipe,
    private _indicatorRepo: IndicatorService,
    private _fundAppService: FundingApplicationService,
    private _npoProfile: NpoProfileService,
    private _userRepo: UserService,
    private _npoRepo: NpoService,

  ) { }

  ngOnInit(): void {
   // this._spinner.show();

    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        this.userId = this.profile.id;
        this.loadCapturedResponses();
      }
    });

    this.getQuestionCategory();
    this.getResponseType();

    this.loadApplication();
    this.loadApplications();
    this.selectedResponses();
    this.loadQuestionnaire();
    this.loadCapturedResponses();
    this.auditCols = [
      { header: '', width: '5%' },
      { header: 'Status', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];

  }

  private loadApplication() {
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        this.application = results;
        this.applicationPeriod = this.application.applicationPeriod;
        this.loadNpo();

      },
    );
  }

  private loadQuestionnaire() {
    this._evaluationService.getScorecardQuestionnaire(Number(this.id)).subscribe(
      (results) => {
        this.allQuestionnaires = results.filter(x => x.questionCategoryName === "Adjudication2");
        this.loadResponseOptions();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadResponseOptions() {
    this._dropdownService.getEntities(DropdownTypeEnum.ResponseOption, true).subscribe(
      (results) => {
        this.responseOptions = results;
        this.selectedResponses();
        this.loadStatuses();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadStatuses() {
    this._dropdownService.getEntities(DropdownTypeEnum.Statuses, true).subscribe(
      (results) => {
        this.statuses = results.filter(x => x.name.includes('Recommended') || x.name.includes('Declined') && x.name != 'StronglyRecommended');
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public hasWeighting(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return item.responseTypeId === ResponseTypeEnum.Score2 });
  }

  public getRagPercent(questionnaire: IQuestionResponseViewModel) {

    let ragPercent = '';
     
      if(questionnaire.responseTypeId ===  ResponseTypeEnum.Score2)
      {
        if (Number(questionnaire.responseOption.name) === 1){
          ragPercent = ((Number(questionnaire.responseOption.name)/5) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 2){
        ragPercent = ((Number(questionnaire.responseOption.name)/5) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 3){
          ragPercent = ((Number(questionnaire.responseOption.name)/5) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 4){
          ragPercent = ((Number(questionnaire.responseOption.name)/5) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 5){
          ragPercent = ((Number(questionnaire.responseOption.name)/5) * 100).toFixed(2).toString();
        }
      }
      if(questionnaire.responseTypeId ===  ResponseTypeEnum.Score3)
      {
        if (Number(questionnaire.responseOption.name) === 1){
          ragPercent = ((Number(questionnaire.responseOption.name)/10) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 2){
        ragPercent = ((Number(questionnaire.responseOption.name)/10) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 3){
          ragPercent = ((Number(questionnaire.responseOption.name)/10) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 4){
          ragPercent = ((Number(questionnaire.responseOption.name)/10) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 5){
          ragPercent = ((Number(questionnaire.responseOption.name)/10) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 6){
          ragPercent = ((Number(questionnaire.responseOption.name)/10) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 7){
        ragPercent = ((Number(questionnaire.responseOption.name)/10) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 8){
          ragPercent = ((Number(questionnaire.responseOption.name)/10) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 9){
          ragPercent = ((Number(questionnaire.responseOption.name)/10) * 100).toFixed(2).toString();
        }
        if (Number(questionnaire.responseOption.name) === 10){
          ragPercent = ((Number(questionnaire.responseOption.name)/10) * 100).toFixed(2).toString();
        }
      }
     
    return ragPercent;
  }

  public updateRowGroupMetaData(questionnaire: IQuestionResponseViewModel[]) {
    let rowGroupMetadata = {};
    if (questionnaire) {
      for (let i = 0; i < questionnaire.length; i++) {
        let rowData = questionnaire[i];
        let questionSectionName = rowData.questionSectionName;
        if (i == 0) {
          rowGroupMetadata[questionSectionName] = { index: 0, size: 1 };
        }
        else {
          let previousRowData = questionnaire[i - 1];
          let previousRowGroup = previousRowData.questionSectionName;
          if (questionSectionName === previousRowGroup)
            rowGroupMetadata[questionSectionName].size++;
          else
            rowGroupMetadata[questionSectionName] = { index: i, size: 1 };
        }
      }
    }

    return rowGroupMetadata;
  }

  public getStatusText(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {
    let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    let countReviewed = questions.filter(x => x.isSaved === true).length;
    return `${countReviewed} of ${questions.length} answered`;
  }

  public getStatus(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {
    let status = '';
    let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    let countReviewed = questions.filter(x => x.isSaved === true).length;

    // If true, document is required but no documents were uploaded... 
    // var documentRequired = questions.some(function (question) { return question.documentRequired === true && question.documentCount === 0 });
    var documentRequired = false;

    if (questions.length === countReviewed && !documentRequired)
      status = 'complete';
    else if (questions.length === countReviewed && documentRequired)
      status = 'partially-complete';
    else if (questions.length !== countReviewed)
      status = 'pending';

    return status;
  }

  public getRagColour(questionnaire: IQuestionResponseViewModel[]) {

    let ragColour = 'rag-not-saved';

    questionnaire.forEach(item => {
      if (Number(item.responseOption.name) >= 1 && Number(item.responseOption.name) < 5) {
        ragColour = 'rag-not-saved';
      }
      else if (Number(item.responseOption.name) >= 5 && Number(item.responseOption.name) < 8) {
        ragColour = 'rag-partial';
      }
      else if (Number(item.responseOption.name) >= 8) {
        ragColour = 'rag-saved';
      }
      else {
        ragColour = '';
      }
    });

    return ragColour;
  }

  public getRagText(questionnaire: IQuestionResponseViewModel[]) {

    let ragText = '';

    questionnaire.forEach(item => {
      if (Number(item.responseOption.name) >= 1 && Number(item.responseOption.name) < 5) {
        ragText = 'Below Expectations';
      }
      else if (Number(item.responseOption.name) >= 5 && Number(item.responseOption.name) < 8) {
        ragText = 'Meet Expectations';
      }
      else if (Number(item.responseOption.name) >= 8) {
        ragText = 'Exceeds  Expectations';
      }
    });

    return ragText;
  }

  public getRagColour1(num: Number) {

    let ragColour = 'rag-not-saved';
    if (num !== undefined) {
      if (Number(num) >= 0 && Number(num) < 5) {
        ragColour = 'rag-not-saved';
      }
      else if (Number(num) >= 5 && Number(num) < 8) {
        ragColour = 'rag-partial';
      }
      else if (Number(num) >= 8) {
        ragColour = 'rag-saved';
      }
      else {
        ragColour = '';
      }
    }

    return ragColour;
  }

  public getRagBackgroundColour1(num: Number) {

    let ragColour = 'rag-not-saved-background';
    if (num !== undefined) {
      if (Number(num) >= 0 && Number(num) <= 20) {
        ragColour = 'rag-very-poor-background';
      }
      if (Number(num) > 20 && Number(num) <= 40) {
        ragColour = 'rag-poor-background';
      }
      if (Number(num) > 40 && Number(num) <= 60) {
        ragColour = 'rag-average-background';
      }
      if (Number(num) > 60 && Number(num) <= 80) {
        ragColour = 'rag-good-background';
      }
      if (Number(num) > 80) {
        ragColour = 'rag-saved-background';
      }
    }

    return ragColour;
  }

  public getRagBackgroundColour(num: string) {

    let ragColour = 'rag-not-saved-background';
    if (num !== undefined) {
      if (Number(num) >= 0 && Number(num) < 5) {
        ragColour = 'rag-not-saved-background';
      }
      else if (Number(num) >= 5 && Number(num) < 8) {
        ragColour = 'rag-partial-background';
      }
      else if (Number(num) >= 8) {
        ragColour = 'rag-saved-background';
      }
      else {
        ragColour = '';
      }
    }

    return ragColour;
  }

  public getRagText1(num: string) {

    let ragText = '';
    if (num !== undefined) {
      if (Number(num) >= 0 && Number(num) <= 20) {
        ragText = 'Very Poor';
      }
      if (Number(num) > 20 && Number(num) <= 40) {
        ragText = 'Poor';
      }
      if (Number(num) > 40 && Number(num) <= 60) {
        ragText = 'Average';
      }
      if (Number(num) > 60 && Number(num) <= 80) {
        ragText = 'Good';
      }
      if (Number(num) > 80) {
        ragText = 'Excellent';
      }
    }

    return ragText;
  }

  public displayField(question: IQuestionResponseViewModel) {
    let canDisplayField: boolean;
    switch (question.responseTypeId) {
      case ResponseTypeEnum.CloseEnded:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.Score:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.CloseEnded2:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.CloseEnded3:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.CloseEnded4:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.Score2:
        canDisplayField = true;
        break;
    }

    return canDisplayField;
  }

  public getResponseOptions(responseTypeId: number) {
    return this.responseOptions.filter(x => x.responseTypeId === responseTypeId && x.isActive);
  }

  public onSaveComment(event, question: IQuestionResponseViewModel) {
    question.isSaved = false;
    this.onSave(question);
  }


  public getAverageScoreTotal(questionnaire: IQuestionResponseViewModel[]) {
    let totalAverageScore = 0;
    questionnaire.forEach(item => {

      if (Number(item.responseOption.name) >= 0 && item.questionCategoryId) {
        totalAverageScore += Number(item.responseOption.name);
      }
      else {
        totalAverageScore = 0;
      }
    });

    return totalAverageScore;
  }


  public getOverallScoreTotal(questionnaire: IQuestionResponseViewModel[]) {
    let overAllScore = 0;

    questionnaire.forEach(item => {
      if (Number(item.responseOption.name) >= 0) {
        this.overallAverageScore += Number(item.responseOption.name);
      }
      else {
        this.overallAverageScore = 0;
      }
    });

    return this.overallAverageScore;
  }


  public onSave(question: IQuestionResponseViewModel) {
    if (question.responseOptionId != 0) {

      let response = {} as IResponse;
      response.fundingApplicationId = this.application.id;
      response.questionId = question.questionId;
      response.responseOptionId = question.responseOptionId;
      response.comment = question.comment == null ? "" : question.comment;

      this._evaluationService.updateResponse(response).subscribe(
        (results) => {
          let returnValue = results as IQuestionResponseViewModel;
          question.responseId = returnValue.responseId;
          question.isSaved = returnValue.isSaved;
          this.selectedResponses();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }

      );

    }
  }

  public getQuestionCategory() {
    this._dropdownService.getEntities(DropdownTypeEnum.QuestionCategory, true).subscribe(
      (results) => {
        this.QuestionCategoryentities = results;
      },
    );
  }

  private getResponseType() {
    this._dropdownService.getEntities(DropdownTypeEnum.ResponseType, true).subscribe(
      (results) => {
        this.ResponseTypeentities = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public onSaveResponse(event, question: IQuestionResponseViewModel) {
    question.responseOptionId = event.value.id;
    this.onSave(question);
    this.selectedResponses();
  }

  private loadApplications() {
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        this.application = results;        
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadNpo() {
    this._npoRepo.getNpoById(Number(this.application.npoId)).subscribe(
      (results) => {
        this.npo = results;
        this.organisation = this.npo.name;
        this.loadFundingApplicationDetails();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public selectedResponses() {
    this._evaluationService.getResponse(Number(this.id)).subscribe(
      (results) => {
        this._responses = results;
        var user = this._responses.filter((item, i, arr) => arr.findIndex((t) => t.createdUserId === item.createdUserId) === i);


        let scorer1OverallTotalScores = 0;
        let scorer2OverallTotalScores = 0;
        let scorer3OverallTotalScores = 0;
        let scorer4OverallTotalScores = 0;
        let allScorerOverallTotalScores = 0;
        let totalScoreUser1 = 0;
        let totalScoreUser2 = 0;
        let totalScoreUser3 = 0;
        let totalScoreUser4 = 0;
        let length = user.length;

        
        this._responses.forEach(item => {
          if (Number(item.responseOption.name) >= 0) {
            if (user[0] != undefined) {
              this.scorer1 = Number(user[0].createdUserId);
              if (Number(item.createdUserId) == Number(user[0].createdUserId))
                scorer1OverallTotalScores += Number(item.responseOption.name);
                if(Number(item.responseOption.responseTypeId) === 7)
                {
                  totalScoreUser1 += 5;
                }
                if(Number(item.responseOption.responseTypeId) === 8)
                {
                  totalScoreUser1 += 10;
                }
            }
          }
          else {
            scorer1OverallTotalScores = 0;
          }
        });

        this._responses.forEach(item => {
          if (Number(item.responseOption.name) >= 0) {
            if (user[1] != undefined) {
              this.scorer2 = Number(user[1].createdUserId);
              if (Number(item.createdUserId) == Number(user[1].createdUserId))
                scorer2OverallTotalScores += Number(item.responseOption.name);
                if(Number(item.responseOption.responseTypeId) === 7)
                {
                  totalScoreUser2 += 5;
                }
                if(Number(item.responseOption.responseTypeId) === 8)
                {
                  totalScoreUser2 += 10;
                }
            }
          }
          else {
            scorer2OverallTotalScores = 0;
          }
        });

        this._responses.forEach(item => {
          if (Number(item.responseOption.name) >= 0) {
            if (user[2] != undefined) {
              this.scorer3 = Number(user[2].createdUserId);
              if (Number(item.createdUserId) == Number(user[2].createdUserId))
                scorer3OverallTotalScores += Number(item.responseOption.name);
                if(Number(item.responseOption.responseTypeId) === 7)
                {
                  totalScoreUser3 += 5;
                }
                if(Number(item.responseOption.responseTypeId) === 8)
                {
                  totalScoreUser3 += 10;
                }
            }
          }
          else {
            scorer3OverallTotalScores = 0;
          }
        });

        this._responses.forEach(item => {
          if (Number(item.responseOption.name) >= 0) {
            if (user[3] != undefined) {
              this.scorer4 = Number(user[3].createdUserId);
              if (Number(item.createdUserId) == Number(user[3].createdUserId))
                scorer4OverallTotalScores += Number(item.responseOption.name);
                if(Number(item.responseOption.responseTypeId) === 7)
                {
                  totalScoreUser4 += 5;
                }
                if(Number(item.responseOption.responseTypeId) === 8)
                {
                  totalScoreUser4 += 10;
                }
            }
          }
          else {
            scorer4OverallTotalScores = 0;
          }
        });

        this._responses.forEach(item => {
          if (Number(item.responseOption.name) >= 0) {
            allScorerOverallTotalScores += Number(item.responseOption.name);
          }
          else {
            allScorerOverallTotalScores = 0;
          }
        });
       
        this.socrer1OverallTotalScore = scorer1OverallTotalScores;
        this.socrer2OverallTotalScore = scorer2OverallTotalScores;
        this.socrer3OverallTotalScore = scorer3OverallTotalScores;
        this.socrer4OverallTotalScore = scorer4OverallTotalScores;
        this.allSocrerOverallTotalScore = allScorerOverallTotalScores;
        this.scorer1OverallAvgScore = totalScoreUser1 !== 0? Number(((scorer1OverallTotalScores / totalScoreUser1)*100).toFixed(2)): 0;
        this.scorer2OverallAvgScore = totalScoreUser2 !== 0? Number(((scorer2OverallTotalScores / totalScoreUser2)*100).toFixed(2)): 0;
        this.scorer3OverallAvgScore = totalScoreUser3 !== 0? Number(((scorer3OverallTotalScores / totalScoreUser3)*100).toFixed(2)): 0;
        this.scorer4OverallAvgScore = totalScoreUser4 !== 0? Number(((scorer4OverallTotalScores / totalScoreUser4)*100).toFixed(2)): 0;
        this.allScorerOverallAvgScore = Number(((this.scorer1OverallAvgScore + this.scorer2OverallAvgScore + this.scorer3OverallAvgScore + this.scorer4OverallAvgScore) / 4).toFixed(2));
        
        if (isNaN(this.allScorerOverallAvgScore)) {
          this.allScorerOverallAvgScore = 0;
        }
      },
      (err) => {
        this._loggerService.logException(err);
      }
    );
  }

  public disableSubmit() {
    return false;
  }

  public submit() {

    this.createCapturedResponse();
  }

  private createCapturedResponse() {
    let capturedResponse = {
      fundingApplicationId: this.application.id,
       
      statusId: this.selectedStatus.id,
      questionCategoryId: 200,
      comments: this.reasonOfNonRecommendation,
      isActive: true,
      isSignedOff: true,
      isDeclarationAccepted: true,
      selectedStatus: 0
    } as ICapturedResponse;

    this._evaluationService.createScorecardResponse(capturedResponse).subscribe(
      (results) => {
        this._spinner.hide();
        this._router.navigateByUrl('applications');
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadCapturedResponses() {
    this._evaluationService.getCapturedResponses(Number(this.id)).subscribe(
      (results) => {
        this.capturedResponses = results.filter(x => x.questionCategoryId === 200 && x.createdUser.id === this.userId);
        if (this.capturedResponses.length > 0) {
          let num  = this.capturedResponses[0].selectedStatus;
          switch (num) {
            case Number(StatusEnum.Declined):
              this.selectedStatus = this.statuses.find(x => x.id === StatusEnum.Declined);
              break;
            case Number(StatusEnum.Recommended):
              this.selectedStatus = this.statuses.find(x => x.id === StatusEnum.Recommended);
              break;
            case Number(StatusEnum.StronglyRecommended):
              this.selectedStatus = this.statuses.find(x => x.id === StatusEnum.StronglyRecommended);
              break;
          }
        //  this.selectedStatus = this.capturedResponses[0].statusId
          this.reasonOfNonRecommendation = this.capturedResponses[0].comments;
          this.signedByUser = this.capturedResponses[0].createdUser.fullName;
          this.submittedDate = this.capturedResponses[0].createdDateTime;
          this.hascapturedImprovementArea = true;
          this.hasCapturedRequiredAction = true;
          this.hasScorecardSubmitted = true;
        }
      })
  }

  public disableElement() {

    return ((this.selectedStatus != undefined && !this.selectedStatus)) ? false : true;
  }

  public download() {

    this._router.navigate(['/', { outlets: { 'print': ['print', this.id, 2] } }]);

  }

  
  private loadUpdatedUser() {
    if (this.application.updatedUserId) {
      this._userRepo.getUserById(this.application.updatedUserId).subscribe(
        (results) => {
          this.application.updatedUser = results;
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
    else {
      this.application.updatedUser = {} as IUser;
    }
  }

  private loadFundingApplicationDetails() {
    this._fundAppService.getFundingApplicationDetails(this.application.id).subscribe(
      (results) => {
        this.fundingApplicationDetails = results;
        this.amount = this.fundingApplicationDetails.applicationDetails.amountApplyingFor;
        this.districtCouncil = this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.districtCouncil;
        this.localMunicipality = this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.localMunicipality;
        if (this.fundingApplicationDetails.projectInformation != null) {
          this.purposeQuestion = this.fundingApplicationDetails.projectInformation.purposeQuestion;
        }
        else {
          this.fundingApplicationDetails.projectInformation = {} as IProjectInformation;
        }
       
        this.loadRegions();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadRegions() {
    this._fundAppService.getRegions(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.id).subscribe(
      (results) => {
        this.regions = results;
        this.loadServiceDeliveryAreas();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadServiceDeliveryAreas() {
    this._fundAppService.getSdas(this.fundingApplicationDetails.applicationDetails.fundAppSDADetail.id).subscribe(
      (results) => {
        this.sdas = results;
        this.loadSourceOfInformation();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSourceOfInformation() {
    this._npoProfile.getSourceOfInformationById(this.application.id).subscribe(
      (results) => {
        this.sourceOfInformation = results;
        this.loadAffiliatedOrganisation();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadAffiliatedOrganisation() {
    this._npoProfile.getAffiliatedOrganisationById(this.application.id).subscribe(
      (results) => {
        this.affliatedOrganisationInfo = results;
        this.isDataAvailable = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

}
