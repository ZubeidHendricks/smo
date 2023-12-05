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
import { IActivity, IApplication, IApplicationAudit, ICapturedResponse, IFinancialYear, INpo, IObjective, IQuestionCategory, IResponse, IResponseOption, IResponseOptions, IGetResponseOptions, IStatus, IUser, IWorkplanIndicator, IWorkplanIndicatorSummary } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { EvaluationService } from 'src/app/services/evaluation/evaluation.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { QuestionCategoryComponent } from '../../admin/utilities/question-category/question-category.component';

export interface IResp {
  name: string
}

@Component({
  selector: 'app-review-scorecard',
  templateUrl: './review-scorecard.component.html',
  styleUrls: ['./review-scorecard.component.css']
})
export class ReviewScorecardComponent implements OnInit {

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
  //npoId: string;
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
  name: IResp[] = [];
  _name: IResp[] = [];
  userId: number;
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
    private _npoRepo: NpoService

  ) { }

  ngOnInit(): void {
    this._spinner.show();

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

    //this.loadApplication();
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

        this.loadQuestionnaire();
        this.loadObjectives();
      },
    );
  }

  private loadQuestionnaire() {
    this._evaluationService.getScorecardQuestionnaire(Number(this.id)).subscribe(
      (results) => {
        this.allQuestionnaires = results.filter(x => x.questionCategoryName === "Engagement" || x.questionCategoryName === "Timely Work Plan Submission"
          || x.questionCategoryName === "Impact" || x.questionCategoryName === "Risk Mitigation" || x.questionCategoryName === "Appropriation of Resources");
        this.engagementQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Engagement");
        this.timeWorkPlanQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Timely Work Plan Submission");
        this.impactQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Impact");
        this.riskMitigationQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Risk Mitigation");
        this.appropriationOfResourcesQuestionnaire = this.allQuestionnaires.filter(x => x.questionCategoryName === "Appropriation of Resources");
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
        this.statuses = results;
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

  public getRagText(questionnaire: IQuestionResponseViewModel[]) {

    let ragText = '';

    questionnaire.forEach(item => {
      if (Number(item.responseOption.name) >= 1 && Number(item.responseOption.name) <= 4) {
        ragText = 'Below Expectations';
      }
      else if (Number(item.responseOption.name) >= 5 && Number(item.responseOption.name) <= 8) {
        ragText = 'Meet Expectations';
      }
      else if (Number(item.responseOption.name) > 8) {
        ragText = 'Exceeds  Expectations';
      }
    });

    return ragText;
  }

  public getRagColour1(num: Number) {

    let ragColour = 'rag-not-saved';
    if (num !== undefined) {
      if (Number(num) >= 0 && Number(num) <= 5) {
        ragColour = 'rag-not-saved';
      }
      else if (Number(num) > 5 && Number(num) <= 8) {
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

  public getRagBackgroundColour1(num: Number) {

    let ragColour = 'rag-not-saved-background';
    if (num !== undefined) {
      if (Number(num) >= 0 && Number(num) <= 5) {
        ragColour = 'rag-not-saved-background';
      }
      else if (Number(num) > 5 && Number(num) <= 8) {
        ragColour = 'rag-partial-background';
      }
      else if (Number(num) > 8) {
        ragColour = 'rag-saved-background';
      }
      else {
        ragColour = '';
      }
    }

    return ragColour;
  }

  public getRagBackgroundColour(num: string) {

    let ragColour = 'rag-not-saved-background';
    if (num !== undefined) {
      if (Number(num) >= 0 && Number(num) < 50) {
        ragColour = 'rag-not-saved-background';
      }
      else if (Number(num) > 50 && Number(num) < 80) {
        ragColour = 'rag-partial-background';
      }
      else if (Number(num) > 80) {
        ragColour = 'rag-saved-background';
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
      if (Number(num) >= 1 && Number(num) <= 4) {
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
          totalAvg: totalActuals === 0 || totalTargets === 0 ? 0 : ((totalActuals / totalTargets)/10) * 100
        } as IWorkplanIndicatorSummary);
      });

      this.updateRowGroupMetaDataAct();
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

      overallPerformancePercentage = overallPerformancePercentage / uniqueObjectives.length;
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
    return performanceAvg;
  }

  updateRowGroupMetaDataAct() {
    this.rowGroupMetadataActivities = [];

    if (this.filteredWorkplanIndicators) {
      this.filteredWorkplanIndicators.forEach(element => {
        var itemExists = this.rowGroupMetadataActivities.some(function (data) {
          return data.itemName === element.ObjectiveName
        });

        this.rowGroupMetadataActivities.push({
          itemName: element.ObjectiveName,
          itemExists: itemExists
        });

      });
    }

    this.allDataLoaded();
  }

  private allDataLoaded() {
    if (this.objectives && this.activities) {
      this._spinner.hide();
    }
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

        let length = this._responses.length;

        this._responses.forEach(item => {
          if (Number(item.responseOption.name) >= 0) {
            if (user[0] != undefined) {
              this.scorer1 = Number(user[0].createdUserId);
              if (Number(item.createdUserId) == Number(user[0].createdUserId))
                scorer1OverallTotalScores += Number(item.responseOption.name);
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
        this.scorer1OverallAvgScore = Number((scorer1OverallTotalScores / 5).toFixed(2));
        this.scorer2OverallAvgScore = Number((scorer2OverallTotalScores / 5).toFixed(2));
        this.scorer3OverallAvgScore = Number((scorer3OverallTotalScores / 5).toFixed(2));
        this.scorer4OverallAvgScore = Number((scorer4OverallTotalScores / 5).toFixed(2));
        this.allScorerOverallAvgScore = Number(((this.scorer1OverallAvgScore + this.scorer2OverallAvgScore + this.scorer3OverallAvgScore + this.scorer4OverallAvgScore) / 4).toFixed(2));

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
      statusId: 0,
      questionCategoryId: 100,
      comments: this.captureImprovementArea + '/' + this.captureRequiredAction,
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
        this.capturedResponses = results.filter(x => x.questionCategoryId === 100 && x.createdUser.id === this.userId);
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
      })
  }

  public onSelectViewComment(question: IQuestionResponseViewModel) {
    this._spinner.show();
    this._responseUsers = [];
    this._evaluationService.getResponses(Number(this.id), question.questionId).subscribe(
      (results) => {
        this._responseUsers = results;
        this.displayCommentDialog = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public performanceComment(v: number) {

    this._evaluationService.getCapturedResponses(Number(this.id)).subscribe(
      (results) => {
        if (v === 1)
          this.capturedResponses = results.filter(x => x.questionCategoryId === 0 && x.createdUser.id === this.scorer1);
        if (v === 2)
          this.capturedResponses = results.filter(x => x.questionCategoryId === 0 && x.createdUser.id === this.scorer2);
        if (v === 3)
          this.capturedResponses = results.filter(x => x.questionCategoryId === 0 && x.createdUser.id === this.scorer3);
        if (v === 4)
          this.capturedResponses = results.filter(x => x.questionCategoryId === 0 && x.createdUser.id === this.scorer4);

        if (this.capturedResponses.length > 0) {
          this.displayDialog = true;
          let requiredAction = this.capturedResponses[0].comments.slice(this.capturedResponses[0].comments.indexOf('/') + 1);
          let improvementArea = this.capturedResponses[0].comments.substring(0, this.capturedResponses[0].comments.indexOf("/"));
          this.captureImprovementArea = improvementArea;
          this.captureRequiredAction = requiredAction;
          this.signedByUser = this.capturedResponses[0].createdUser.fullName;
          this.submittedDate = this.capturedResponses[0].createdDateTime;
          // this.hascapturedImprovementArea = true;
          // this.hasCapturedRequiredAction = true;   
          // this.hasScorecardSubmitted = true;      
        }
      })

  }

  public disableElement() {

    return ((this.captureImprovementArea != undefined && this.captureImprovementArea != '') && (this.captureRequiredAction != undefined && this.captureRequiredAction != '')) ? false : true;
  }

  public download() {

    this._router.navigate(['/', { outlets: { 'print': ['print', this.id, 2] } }]);

  }

}
