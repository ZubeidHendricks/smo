import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ApplicationTypeEnum, DropdownTypeEnum, FacilityTypeEnum, IQuestionResponseViewModel, IResponseHistory,
  ResponseTypeEnum, PermissionsEnum, ServiceProvisionStepsEnum, IResponse, IResponseType, FrequencyEnum, FrequencyPeriodEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationAudit, IFinancialYear, IQuestionCategory, IResponseOption, IUser, IWorkplanIndicator } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { EvaluationService } from 'src/app/services/evaluation/evaluation.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-scorecard',
  templateUrl: './scorecard.component.html',
  styleUrls: ['./scorecard.component.css']
})
export class ScorecardComponent implements OnInit {

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
  responseHistory: IResponseHistory[];
  displayHistoryDialog: boolean;
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
  totalAverageScore: number;
  QuestionCategoryentities: IQuestionCategory[];
  ResponseTypeentities: IResponseType[];
  auditCols: any[];
  workplanIndicators: IWorkplanIndicator[];
  filteredWorkplanIndicators: IWorkplanIndicator[];
  lastWorkplanTarget: boolean;
  lastWorkplanActual: boolean;
  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;
  scrollableCols: any[];
  frozenCols: any[];
  activities: IActivity[];
  applications: IApplication[];
  //npoId: string;

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
    private _indicatorRepo: IndicatorService

  ) { }

  ngOnInit(): void {

    // this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
    //   this.npoId = params.get('npoId');
    // });

    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');      
    });

    this.getQuestionCategory();
    this.getResponseType();

    this.loadApplication();
    this.loadActivities();

    this.auditCols = [
      { header: '', width: '5%' },
      { header: 'Status', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];
  }

  private loadApplication() {
    //this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        this.application = results;
       
        this.loadQuestionnaire();
       
      },
    );
  }

  private loadQuestionnaire() {
    this._evaluationService.getQuestionnaire(Number(this.id)).subscribe(
      (results) => {
        this.allQuestionnaires = results;
        
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
      //  this.loadStatuses();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public hasWeighting(questionnaire: IQuestionResponseViewModel[]) {
    return questionnaire.some(function (item) { return item.responseTypeId === ResponseTypeEnum.Score });
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

  public getRagColour(question: IQuestionResponseViewModel) {
    let ragColour = 'rag-not-saved';

    if (question.isSaved && question.commentRequired === false)
      ragColour = 'rag-saved';

    if (question.isSaved && question.commentRequired === true) {
      if (question.comment === '')
      {
        ragColour = 'rag-partial';
        this._recommendation = false;
      }
      else
      {
        ragColour = 'rag-saved';       
      }
    }
    // else if (!question.isSaved)
    //   ragColour = 'rag-not-saved';

    return ragColour;
  }

  public displayField(question: IQuestionResponseViewModel) {
    let canDisplayField: boolean;
    switch (question.responseTypeId) {
      case ResponseTypeEnum.CloseEnded:
        canDisplayField = true;
        break;
      case ResponseTypeEnum.Score:
        canDisplayField = true; //question.weighting !== 0 ? true : false;
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

  public getAverageScoreTotal(questionnaire: IQuestionResponseViewModel[]) 
  {
    questionnaire.forEach(item => {
      if(Number(item.responseOption.name) >= 0)
      {
        this.totalAverageScore += Number(item.responseOption.name);
      }
      else{
        this.totalAverageScore = 0;
      }
    });

    //if (questionnaire[0].questionCategoryId === QuestionCategoryEnum.Evaluation)
    //this.updateEvaluationStatus(this.totalAverageScore);

    return this.totalAverageScore;
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
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }

      );

    }
  }

  public getQuestionCategory()
  {    
    this._dropdownService.getEntities(DropdownTypeEnum.QuestionCategory, true).subscribe(
      (results) => {
        this.QuestionCategoryentities  = results;       
      },
    );
  }

  private getResponseType() {
    this._dropdownService.getEntities(DropdownTypeEnum.ResponseType, true).subscribe(
      (results) => {
        this.ResponseTypeentities = results;
        this._spinner.hide();
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

  private getAuditHistory() {
    this._applicationRepo.getApplicationAudits(this.application.id).subscribe(
      (results) => {
        this.applicationAudits = results;
     //   this.mainReview = results.filter(x => x.statusId === StatusEnum.PendingApproval)[0];
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  viewAuditHistory() {
    this.displayHistory = true;
  }

  private loadApplications() {
    this._spinner.show();
    this._applicationRepo.getApplicationsByNpoId(Number(this.id)).subscribe(
      (results) => {
        this.financialYears = [];
        this.applications = results.filter(x => x.applicationPeriod.applicationTypeId === ApplicationTypeEnum.SP && x.statusId === StatusEnum.AcceptedSLA);

        this.applications.forEach(item => {
          var isPresent = this.financialYears.some(function (financialYear) { return financialYear === item.applicationPeriod.financialYear });
          if (!isPresent)
            this.financialYears.push(item.applicationPeriod.financialYear);
        });

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadActivities() {
    this._spinner.show();
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

  private loadTargets(activity: IActivity) {
    this._indicatorRepo.getTargetsByActivityId(activity.id).subscribe(
      (results) => {
        // Add WorkplanTargets to WorkplanIndicators at index of activity
        var index = this.workplanIndicators.findIndex(x => x.activity.id == activity.id);
        this.workplanIndicators[index].workplanTargets = results;

        if (this.activities[this.activities.length - 1] === activity) {
          this.lastWorkplanTarget = true;
          this.filterWorkplanIndicators();
        }
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

        if (this.activities[this.activities.length - 1] === activity) {
          this.lastWorkplanActual = true;
          this.filterWorkplanIndicators();
        }
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  

  private filterWorkplanIndicators() {
    if (this.lastWorkplanTarget && this.lastWorkplanActual) {
      this.filteredWorkplanIndicators = [];

      this.workplanIndicators.forEach(indicator => {

        // Filter WorkplanTargets on activity, financial year and monthly frequency
        let workplanTargets = indicator.workplanTargets.filter(x => x.activityId == indicator.activity.id && x.financialYearId == this.selectedFinancialYear.id && x.frequencyId == FrequencyEnum.Monthly);

        // Calculate total targets
        let targetTotal = workplanTargets[0] ? (workplanTargets[0].apr + workplanTargets[0].may + workplanTargets[0].jun + workplanTargets[0].jul + workplanTargets[0].aug + workplanTargets[0].sep + workplanTargets[0].oct + workplanTargets[0].nov + workplanTargets[0].dec + workplanTargets[0].jan + workplanTargets[0].feb + workplanTargets[0].mar) : 0;

        // Filter WorkplanActuals on activity and financial year, then filter on WorkplanTargets.
        // This will retrieve the WorkplanActuals for all activities for the selected financial year and monthly WorkplanTargets
        let workplanActuals = indicator.workplanActuals.filter(x => x.activityId == indicator.activity.id && x.financialYearId == this.selectedFinancialYear.id);
        let filteredWorkplanActuals = workplanActuals.filter((el) => {
          return workplanTargets.some((f) => {
            return f.id === el.workplanTargetId;
          });
        });

        // Calculate total actuals
        let actualTotal = filteredWorkplanActuals.reduce((sum, object) => {
          let actual = object.actual == null ? 0 : object.actual;
          return sum + actual;
        }, 0);

        this.filteredWorkplanIndicators.push({
          activity: indicator.activity,
          workplanTargets: workplanTargets,
          workplanActuals: filteredWorkplanActuals,
          totalTargets: targetTotal,
          totalActuals: actualTotal
        } as IWorkplanIndicator);
      });

      this.makeRowsSameHeight();
    }
  }

  private makeRowsSameHeight() {
    setTimeout(() => {
      if (document.getElementsByClassName('p-datatable-scrollable-wrapper').length) {
        let wrapper = document.getElementsByClassName('p-datatable-scrollable-wrapper');

        for (var i = 0; i < wrapper.length; i++) {

          let w = wrapper.item(i) as HTMLElement;
          let frozen_rows: any = w.querySelectorAll('.p-datatable-frozen-view tr');
          let unfrozen_rows: any = w.querySelectorAll('.p-datatable-unfrozen-view tr');

          for (let i = 0; i < frozen_rows.length; i++) {

            if (frozen_rows[i].clientHeight > unfrozen_rows[i].clientHeight) {
              unfrozen_rows[i].style.height = frozen_rows[i].clientHeight + "px";
            }
            else if (frozen_rows[i].clientHeight < unfrozen_rows[i].clientHeight) {
              frozen_rows[i].style.height = unfrozen_rows[i].clientHeight + "px";
            }
          }
        }

        this._spinner.hide();
      }
    });
  }

}
