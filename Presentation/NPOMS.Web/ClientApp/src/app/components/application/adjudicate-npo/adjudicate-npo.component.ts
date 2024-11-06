import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import {
  ApplicationTypeEnum, DropdownTypeEnum, FacilityTypeEnum, IQuestionResponseViewModel, IResponseHistory,
  ResponseTypeEnum, PermissionsEnum, ServiceProvisionStepsEnum, IResponseType, FrequencyEnum, FrequencyPeriodEnum, StatusEnum
} from 'src/app/models/enums';
import {
  IActivity, IApplication, IApplicationAudit, ICapturedResponse, IFinancialYear, INpo, IObjective, IQuestionCategory,
  IResponse, IResponseOption, IResponseOptions, IStatus, IUser, IWorkflowAssessment, IWorkplanIndicator, IWorkplanIndicatorSummary
} from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { EvaluationService } from 'src/app/services/evaluation/evaluation.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-adjudicate-npo',
  templateUrl: './adjudicate-npo.component.html',
  styleUrls: ['./adjudicate-npo.component.css']
})
export class AdjudicateNpoComponent implements OnInit {

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
  npoAdjudication: IQuestionResponseViewModel[];
  engagementQuestionnaire: IQuestionResponseViewModel[];
  timeWorkPlanQuestionnaire: IQuestionResponseViewModel[];
  impactQuestionnaire: IQuestionResponseViewModel[];
  riskMitigationQuestionnaire: IQuestionResponseViewModel[];
  appropriationOfResourcesQuestionnaire: IQuestionResponseViewModel[];
  totalQuestionValue: number = 0;
  overallAverageScore: number = 0;
  totalLegend: string;
  totalPercentage: number;
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
    //this._spinner.show();

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
   // this.loadApplications();
   
    this.loadQuestionnaire();
    this.selectedResponses();
  }

  private loadQuestionnaire() {
    this._evaluationService.getAddScoreQuestionnaire(Number(this.id)).subscribe(
      (results) => {
        this.allQuestionnaires = results;
        this.npoAdjudication = this.allQuestionnaires.filter(x => x.questionCategoryName === "Adjudication2");
        this.loadResponseOptions();
        this.updateRowGroupMetaDataAct();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private getWorkflowCount() {
    if (this.engagementQuestionnaire && this.engagementQuestionnaire[0]) {
      this._evaluationService.workflowAssessmentCount(Number(this.engagementQuestionnaire[0].questionCategoryId)).subscribe(
        (res) => {

          if (this.capturedResponsesCount && this.capturedResponsesCount.length === 4) {
            alert('Adjudication limit reached.');
            this._router.navigateByUrl('applications');
          }

          if (this.capturedResponseCount && this.capturedResponseCount.length > 0) {
            alert('Application adjudicated. Process closed');
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

  private loadResponseOptions() {
    this._dropdownService.getEntities(DropdownTypeEnum.ResponseOption, true).subscribe(
      (results) => {
        this.responseOptions = results;
        //  this.selectedResponses();     
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
        this.statuses = results;

      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public hasWeighting(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return (item.responseTypeId === ResponseTypeEnum.Score2) || (item.responseTypeId === ResponseTypeEnum.Score3)});
  }

  
  public getCompletedQuestionnaire(capturedResponse: ICapturedResponse) {
    var questionnaires = this.capturedResponses.find(x => x.id === capturedResponse.id).questionnaires;
    this.updateRowGroupMetaData(questionnaires);
    return questionnaires;
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

  public hasComment(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return item.hasComment === true });
  }

  public hasDocument(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return item.hasDocument === true });
  }

  public getColspan(questionnaire: IQuestionResponseViewModel[], defaultColspan: number) {
    let colspan = defaultColspan;

    colspan = this.hasComment(questionnaire) ? colspan + 1 : colspan;
    colspan = this.hasDocument(questionnaire) ? colspan + 1 : colspan;

    return colspan;
  }
  public getStatusText(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {
    let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    // let countReviewed = questions.filter(x => x.isSaved === true && x.createdUserId == this.userId).length;
    let countReviewed = questions.filter(x => x.isSaved === true).length;
    return `${countReviewed} of ${questions.length} answered`;
  }

  public getStatus(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {
    let status = '';
    let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    let countReviewed = questions.filter(x => x.isSaved === true).length;
    // If true, document is required but no documents were uploaded... 
    var documentRequired = false;

    if (questions.length === countReviewed && !documentRequired) 
      status = 'complete';
    else if (questions.length === countReviewed && documentRequired)
      status = 'partially-complete';
    else if (questions.length !== countReviewed)
      status = 'pending';

    return status;
  }

  public getTotalQuestionValue(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) 
  {
    let questionValue = 0;
    let qs = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    qs.forEach(item => {
      if(item.responseTypeId === ResponseTypeEnum.Score2)
      {
        if (Number(item.responseOption.name) >= 0) {
          questionValue += 5;
        }
        else {
          questionValue = 0;
        }
      }
      if(item.responseTypeId === ResponseTypeEnum.Score3)
      {
        if (Number(item.responseOption.name) >= 0) {
          questionValue += 10;
        }
        else {
          questionValue = 0;
        }
      }     
    });
    
    return questionValue;
  }

  public getAvgQuestionValue(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {
    let questionValue = 0;
    let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    questions.forEach(item => {
      if (Number(item.responseOption.name) > 0) {
        questionValue += Number(item.responseOption.name);
      }      
    });
    
    return questionValue;
  }

  public getSubTotalLegend(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {

    let subQuestionValue = 0;
    let subAvgQuestionValue = 0;
    let questionValue = 0;
    let legend = '';
    let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    
    questions.forEach(item => {
      if(item.responseTypeId === ResponseTypeEnum.Score2)
      {
        if (Number(item.responseOption.name) >= 0) {
          subQuestionValue += 5;
        }
        else {
          subQuestionValue = 0;
        }
      }
      if(item.responseTypeId === ResponseTypeEnum.Score3)
      {
        if (Number(item.responseOption.name) >= 0) {
          subQuestionValue += 10;
        }
        else {
          subQuestionValue = 0;
        }
      }     
    });

    questions.forEach(item => {
      if (Number(item.responseOption.name) > 0) {
        subAvgQuestionValue += Number(item.responseOption.name);
      }      
    });

    questionValue = ((Number(subAvgQuestionValue)/(subQuestionValue))*100);
    
    if (Number(questionValue) > 0 && Number(questionValue) <= 20) {
      legend = 'Very Poor';
    }
    else if (Number(questionValue) > 20 && Number(questionValue) <= 40) {
      legend = 'Poor';
    }
    else if (Number(questionValue) > 40 && Number(questionValue) <= 60) {
      legend = 'Average';
    }
    else if (Number(questionValue) > 60 && Number(questionValue) <= 80) {
      legend = 'Good';
    }
    else if (Number(questionValue) > 80 && Number(questionValue) <= 100) {
      legend = 'Excellent';
    }
    else {
      legend = '';
    }
    
    return legend;
  }

  public getSubTotalPercentage(questionnaire: IQuestionResponseViewModel[], question: IQuestionResponseViewModel) {
    let subQuestionValue = 0;
    let subAvgQuestionValue = 0;
    let subPercentage = '';
    let questions = questionnaire.filter(x => x.questionSectionName === question.questionSectionName && x.questionCategoryName == question.questionCategoryName);
    
    questions.forEach(item => {
      if(item.responseTypeId === ResponseTypeEnum.Score2)
      {
        if (Number(item.responseOption.name) >= 0) {
          subQuestionValue += 5;
        }
        else {
          subQuestionValue = 0;
        }
      }
      if(item.responseTypeId === ResponseTypeEnum.Score3)
      {
        if (Number(item.responseOption.name) >= 0) {
          subQuestionValue += 10;
        }
        else {
          subQuestionValue = 0;
        }
      }     
    });

    questions.forEach(item => {
      if (Number(item.responseOption.name) > 0) {
        subAvgQuestionValue += Number(item.responseOption.name);
      }      
    });
    subPercentage = ((Number(subAvgQuestionValue)/(subQuestionValue))*100).toFixed(2).toString();
    return subPercentage
  }

  public getRagColour(questionnaire: IQuestionResponseViewModel[]) {

    let ragColour = 'rag-not-saved';
 
    questionnaire.forEach(item => {
      if (Number(item.responseOption.name) >= 1 && Number(item.responseOption.name) <= 4) {
        ragColour = 'rag-not-saved';
      }
      else if (Number(item.responseOption.name) >= 5 && Number(item.responseOption.name) <= 8) {
        ragColour = 'rag-partial';
      }
      else if (Number(item.responseOption.name) > 5) {
        ragColour = 'rag-saved';
      }
      else {
        ragColour = '';
      }
    });

    return ragColour;
  }

  public getCapturedScore(questionnaire: IQuestionResponseViewModel) {
    let capturedScore = '';
   // questionnaire.forEach(item => {
      capturedScore = questionnaire.responseOption.name;
   // });
    return capturedScore;
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


  public getRagText(questionnaire: IQuestionResponseViewModel) {

    let ragText = '';
   // questionnaire.forEach(item => {
     
      if(questionnaire.responseTypeId ===  ResponseTypeEnum.Score2)
      {
        if (Number(questionnaire.responseOption.name) > 0 && Number(questionnaire.responseOption.name) <= 1){
          ragText = 'Very Poor';
        }
        else if (Number(questionnaire.responseOption.name) > 1 && Number(questionnaire.responseOption.name) <= 2) {
          ragText = 'Poor';
        }
        else if (Number(questionnaire.responseOption.name) > 2 && Number(questionnaire.responseOption.name) <= 3 ) {
          ragText = 'Average';
        }
        else if (Number(questionnaire.responseOption.name) > 3 && Number(questionnaire.responseOption.name) <= 4 ) {
          ragText = 'Good';
        }
        else if (Number(questionnaire.responseOption.name) > 4 && Number(questionnaire.responseOption.name) <= 5 ) {
          ragText = 'Excellent';
        }
        else{
          ragText = '';
        }
      }
      if(questionnaire.responseTypeId ===  ResponseTypeEnum.Score3)
      {
        if (Number(questionnaire.responseOption.name) < 3){
          ragText = 'Very Poor';
        }
        else if (Number(questionnaire.responseOption.name) >= 3 && Number(questionnaire.responseOption.name) < 5) {
          ragText = 'Poor';
        }
        else if (Number(questionnaire.responseOption.name) >= 5 && Number(questionnaire.responseOption.name) < 7 ) {
          ragText = 'Average';
        }
        else if (Number(questionnaire.responseOption.name) >= 7 && Number(questionnaire.responseOption.name) < 9 ) {
          ragText = 'Good';
        }
        else if (Number(questionnaire.responseOption.name) >= 9 && Number(questionnaire.responseOption.name) == 10 ) {
          ragText = 'Excellent';
        }
        else{
          ragText = '';
        }
      }
     
   // });

    return ragText;
  }

  public getRagColour1(num: Number) {

    let ragColour = 'rag-not-saved';
    if (num !== undefined) {
      if (Number(num) >= 1 && Number(num) < 5) {
        ragColour = 'rag-not-saved';
      }
      else if (Number(num) >= 5 && Number(num) <= 8) {
        ragColour = 'rag-partial';
      }
      else if (Number(num) > 8) {
        ragColour = 'rag-saved';
      }
      else {
        ragColour = '';
      }
    }

    return ragColour;
  }

  public getRagText1(num: Number) {

    let ragText = '';
    if (num !== undefined) {
      if (Number(num) >= 1 && Number(num) < 5) {
        ragText = 'Below Expectations';
      }
      else if (Number(num) >= 5 && Number(num) <= 8) {
        ragText = 'Meet Expectations';
      }
      else if (Number(num) > 8) {
        ragText = 'Exceeds  Expectations';
      }
      else {
        ragText = '';
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
      case ResponseTypeEnum.Score3:
        canDisplayField = true;
        break;
    }

    return canDisplayField;
  }

  public getResponseOptions(responseTypeId: number) {
    return this.responseOptions && this.responseOptions.length > 0 ? this.responseOptions.filter(x => x.responseTypeId === responseTypeId && x.isActive) : [];
  }

  public onSaveComment(event, question: IQuestionResponseViewModel) {
    question.isSaved = false;
    this.onSave(question);
  }

  public onInputCommentChange(question: IQuestionResponseViewModel) {
    question.isSaved = false;
  }

  public getOverallPercentage()
  {
    let overallPercentage = 0;
    overallPercentage = ((Number(this.overallAverageScore)/Number(this.totalQuestionValue))*100);

    this.totalPercentage = overallPercentage;
    return this.totalPercentage.toFixed(2);
  }
  public getOverallLegend()
  {
    let overallPercentage = 0;
    let legendDesc = '';
    overallPercentage = ((Number(this.overallAverageScore)/Number(this.totalQuestionValue))*100);

    this.totalPercentage = overallPercentage;

    if (Number(this.totalPercentage) > 0 && Number(this.totalPercentage) <= 20){
      legendDesc = 'Very Poor';
    }
    if (Number(this.totalPercentage) > 20 && Number(this.totalPercentage) <= 40){
      legendDesc = 'Poor';
    }
    if (Number(this.totalPercentage) > 40 && Number(this.totalPercentage) <= 60){
      legendDesc = 'Average';
    }
    if (Number(this.totalPercentage) > 60 && Number(this.totalPercentage) <= 80){
      legendDesc = 'Good';
    }
    if (Number(this.totalPercentage) > 80){
      legendDesc = 'Excellent';
    }

    this.totalLegend = legendDesc;
    return  this.totalLegend;
  }

  public getAverageScoreTotal(questionnaire: IQuestionResponseViewModel[]) {
    let totalAverageScore = 0;
    questionnaire.forEach(item => {
      if (Number(item.responseOption.name) >= 0) {
        totalAverageScore += Number(item.responseOption.name);
      }
      else {
        totalAverageScore = 0;
      }
    });
    this.overallAverageScore = totalAverageScore;

    return totalAverageScore;
  }

  public gettotalQuestionValue(questionnaire: IQuestionResponseViewModel[]) {
    let totalQuestionVal = 0;

    questionnaire.forEach(item => {
      if(item.responseTypeId === ResponseTypeEnum.Score2)
      {
        if (Number(item.responseOption.name) >= 0) {
          totalQuestionVal += 5;
        }
        else {
          totalQuestionVal = 0;
        }
      }
      if(item.responseTypeId === ResponseTypeEnum.Score3)
      {
        if (Number(item.responseOption.name) >= 0) {
          totalQuestionVal += 10;
        }
        else {
          totalQuestionVal = 0;
        }
      }     
    });

    this.totalQuestionValue = totalQuestionVal;

    return this.totalQuestionValue;
  }


  public onSave(question: IQuestionResponseViewModel) {
    if (question.responseOptionId != 0) {

      let response = {} as IResponse;
      response.fundingApplicationId = Number(this.id);
      response.questionId = question.questionId;
      response.responseOptionId = question.responseOptionId;
      response.comment = question.comment == null ? "" : question.comment;

      this._evaluationService.updateScorecardResponse(response).subscribe(
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
        this._spinner.hide()
      }
    );
  }

  public onSaveResponse(event, question: IQuestionResponseViewModel) {
    question.responseOptionId = event.value.id;
    this.onSave(question);


  }

  private loadApplications() {
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        this.financialYears = [];
        this.application = results;
        // var isPresent = this.financialYears.some(function (financialYear) { return financialYear === this.application.applicationPeriod.financialYear });

        // if (!isPresent)
        //   this.financialYears.push(this.application.applicationPeriod.financialYear);

        this.loadActivities();
        this.loadObjectives();
        this.loadNpo();
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
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadActivities() {

    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.activities = results.filter(x => x.isActive === true);
        this.workplanIndicators = [];

        this.activities.forEach(activity => {
          this.workplanIndicators.push({
            activity: activity,
            workplanTargets: [],
            workplanActuals: []
          } as IWorkplanIndicator);

          this.loadTargets(activity);
          this.loadActuals(activity);
        });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadObjectives() {
    this._applicationRepo.getAllObjectives(this.application).subscribe(
      (results) => {
        this.objectives = results.filter(x => x.isActive === true);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadTargets(activity: IActivity) {
    this._indicatorRepo.getTargetsByActivityId(activity.id).subscribe(
      (results) => {
        // Add WorkplanTargets to WorkplanIndicators at index of activity
        var index = this.workplanIndicators.findIndex(x => x.activity.id == activity.id);
        this.workplanIndicators[index].workplanTargets = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadActuals(activity: IActivity) {
    this._indicatorRepo.getActualsByActivityId(activity.id).subscribe(
      (results) => {
        // Add WorkplanActuals to WorkplanIndicators at index of activity
        var index = this.workplanIndicators.findIndex(x => x.activity.id == activity.id);
        this.workplanIndicators[index].workplanActuals = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public filterWorkplanIndicators() {
    this.filteredWorkplanIndicators = [];

    if (this.workplanIndicators && this.workplanIndicators.length > 0) {

      this.workplanIndicators.forEach(indicator => {

        let totalTargets = indicator.workplanTargets.length > 0 ? (indicator.workplanTargets[0].apr + indicator.workplanTargets[0].may + indicator.workplanTargets[0].jun + indicator.workplanTargets[0].jul + indicator.workplanTargets[0].aug + indicator.workplanTargets[0].sep + indicator.workplanTargets[0].oct + indicator.workplanTargets[0].nov + indicator.workplanTargets[0].dec + indicator.workplanTargets[0].jan + indicator.workplanTargets[0].feb + indicator.workplanTargets[0].mar) : 0;
        let totalActuals: number = 0;

        indicator.workplanActuals.forEach(item => {
          let actual = item.actual !== null && item.actual !== undefined ? item.actual : 0;
          totalActuals = totalActuals + actual;
        });

        this.filteredWorkplanIndicators.push({
          activity: indicator.activity,
          totalTargets: totalTargets,
          totalActuals: totalActuals,
          ObjectiveName: indicator.activity.objective.name,
         // totalAvg: totalActuals === 0 || totalTargets === 0 ? 0 : (totalActuals / totalTargets) * 100
         totalAvg: totalActuals === 0 || totalTargets === 0 ? 0 : ((totalActuals / totalTargets)/10) * 100
        } as IWorkplanIndicatorSummary);
      });

     // this.updateRowGroupMetaDataAct();
    }

    return this.filteredWorkplanIndicators;
  }

  public getOverallPerformancePercentage() {
    let overallPerformancePercentage = 0;

    if (this.rowGroupMetadataActivities && this.rowGroupMetadataActivities.length > 0 && this.filteredWorkplanIndicators && this.filteredWorkplanIndicators.length > 0) {

      let uniqueObjectives = this.rowGroupMetadataActivities.filter(x => x.itemExists === false);

      for (let i = 0; i < uniqueObjectives.length; i++) {
        let indicators = this.filteredWorkplanIndicators.filter(x => x.ObjectiveName === uniqueObjectives[i].itemName);

        // Sum property in array of objects...
        // Found at https://stackoverflow.com/questions/23247859/better-way-to-sum-a-property-value-in-an-array
        let targetTotal = indicators.reduce((n, { totalTargets }) => n + totalTargets, 0);
        let actualTotal = indicators.reduce((n, { totalActuals }) => n + totalActuals, 0);
        let averageTotal = actualTotal === 0 || targetTotal === 0 ? 0 : (actualTotal / targetTotal) * 100;

        overallPerformancePercentage = overallPerformancePercentage + averageTotal;
      }

      overallPerformancePercentage = ((overallPerformancePercentage / uniqueObjectives.length)/10) > 10 ? 10 : ((overallPerformancePercentage / uniqueObjectives.length)/10);
   }

    return overallPerformancePercentage;
  }

  public getObjectiveTargets(objective: IObjective) {
    let totalTarget = 0;
    let objectives = this.filteredWorkplanIndicators.filter(x => x.activity.objective.name === objective.name);

    objectives.forEach(obj => {
      if (obj.ObjectiveName === objective.name)
        totalTarget += obj.totalTargets;
    }
    );

    return totalTarget;
  }

  public getObjectiveActuals(objective: IObjective) {
    let totalActual = 0;
    let objectives = this.filteredWorkplanIndicators.filter(x => x.activity.objective.name === objective.name);

    objectives.forEach(obj => {
      if (obj.ObjectiveName === objective.name)
        totalActual += obj.totalActuals;
    }
    );

    return totalActual;
  }

  public getPerformanceAvg(objective: IObjective) {
    let totalTarget = 0;
    let totalActual = 0;
    let performanceAvg = '';
    let objectives = this.filteredWorkplanIndicators.filter(x => x.activity.objective.name === objective.name);
    objectives.forEach(obj => {
      if (obj.ObjectiveName === objective.name) {
        totalTarget += obj.totalTargets;
        totalActual += obj.totalActuals;
      }
    }
    );

    performanceAvg = (((totalActual / totalTarget)/10) * 100).toFixed(2);

    if (isNaN((((totalActual / totalTarget)/10) * 100))) {
      performanceAvg = '0';
    }

    if((((totalActual / totalTarget)/10) * 100) > 10)
    {
      performanceAvg = '10'
    }
    
    return performanceAvg;
  }

  updateRowGroupMetaDataAct() {
    this.rowGroupMetadataActivities = [];

  //  if (this.filteredWorkplanIndicators) {
      this.npoAdjudication.forEach(element => {
        var itemExists = this.rowGroupMetadataActivities.some(function (data) {
          return data.itemName === element.questionSectionName
        });

        this.rowGroupMetadataActivities.push({
          itemName: element.questionSectionName,
          itemExists: itemExists
        });

      });
   // }

   // this.allDataLoaded();
  }

  private allDataLoaded() {
    if (this.objectives && this.activities) {
      this._spinner.hide();
    }
  }

  public selectedResponses() {
    this._evaluationService.getResponse(Number(this.id)).subscribe(
      (results) => {
        this._responses = results.filter(x => x.createdUserId === this.userId);
        let overallTotalScore = 0;
        let length = this._responses.length;

        this._responses.forEach(item => {
          if (Number(item.responseOption.name) >= 0) {

            overallTotalScore += Number(item.responseOption.name);
          }
          else {
            overallTotalScore = 0;
          }
        });

        this.overallTotalScores = overallTotalScore;

        if (length !== 0)
          this.overallAvgScore = overallTotalScore / length;

      },
      (err) => {
        this._loggerService.logException(err);
      }
    );
  }

  public disableSubmit() {
    return ((this._responses.length === 5)) ? false : true;
  }

  public submit() {

    this.createCapturedResponse();
  }

  private createCapturedResponse() {

    let capturedResponse = {
      fundingApplicationId: Number(this.id),
      statusId: 0,
      questionCategoryId: 0,
      comments: this.captureImprovementArea + '/' + this.captureRequiredAction,
      isActive: true,
      isSignedOff: true,
      isDeclarationAccepted: true,
      selectedStatus: 0
    } as ICapturedResponse;

    this._evaluationService.createScorecardResponse(capturedResponse).subscribe(
      (results) => {
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
        this.capturedResponsesCount = results.filter(x => x.questionCategoryId === 0);
        this.capturedResponseCount = results.filter(x => x.questionCategoryId === 100);

        this.capturedResponses = results.filter(x => x.questionCategoryId === 0 && x.createdUser.id === this.userId);

        if (this.capturedResponses.length > 0) {
          let requiredAction = this.capturedResponses[0].comments.slice(this.capturedResponses[0].comments.indexOf('/') + 1);
          let improvementArea = this.capturedResponses[0].comments.substring(0, this.capturedResponses[0].comments.indexOf("/"));
          this.captureImprovementArea = improvementArea;
          this.captureRequiredAction = requiredAction;
          this.signedByUser = this.capturedResponses[0].createdUser.fullName;
          this.submittedDate = this.capturedResponses[0].createdDateTime;
          this.hascapturedImprovementArea = true;
          this.hasCapturedRequiredAction = true;
          this.hasScorecardSubmitted = true;
        }

        this.getWorkflowCount();
      })
  }

  public disableElement() {
    let questions = this.allQuestionnaires.filter(x => x.questionCategoryName === "Adjudication2");
    let countReviewed = questions.filter(x => x.isSaved === true).length;
    return (questions.length === countReviewed) ? false : true;
  }

}
