import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from '../environment-url/environment-url.service';
import { ICapturedResponse, IQuestionResponseViewModel, IResponse, IResponseHistory, IResponseOptions, IWorkflowAssessment, IGetResponseOptions, IGetResponseOption } from 'src/app/models/interfaces';
import { IResponses } from 'src/app/models/enums';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class EvaluationService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getQuestionnaire(fundingApplicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/fundingApplicationId/${fundingApplicationId}`;
    return this._http.get<IQuestionResponseViewModel[]>(url, httpOptions);
  }

  public getQuestionnaireReport(fundingApplicationId: number, qtrId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/fundingApplicationId/${fundingApplicationId}/qtrId/${qtrId}`;
    return this._http.get<IQuestionResponseViewModel[]>(url, httpOptions);
  }


  public getAddScoreQuestionnaire(funId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/funId/${funId}`;
    return this._http.get<IQuestionResponseViewModel[]>(url, httpOptions);
  }

  public getScorecardQuestionnaire(fId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/fId/${fId}`;
    return this._http.get<IQuestionResponseViewModel[]>(url, httpOptions);
  }

  public getCompletedQuestionnaires(fundingApplicationId: number, questionCategoryId: number, createdUserId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/completed-questionnaires/fundingApplicationId/${fundingApplicationId}/questionCategoryId/${questionCategoryId}/createdUserId/${createdUserId}`;
    return this._http.get<IQuestionResponseViewModel[]>(url, httpOptions);
  }

  public getResponses(fundingAppId: number, questionId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/fundingAppId/${fundingAppId}/questionId/${questionId}`;
    return this._http.get<IGetResponseOptions[]>(url, httpOptions);
  }

  public getReviewerResponse(fundingAppId: number, questionId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/fundingAppId/${fundingAppId}/questionId/${questionId}`;
    return this._http.get<IGetResponseOption[]>(url, httpOptions);
  }

  public getResponseHistory(fundingApplicationId: number, questionId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/fundingApplicationId/${fundingApplicationId}/questionId/${questionId}`;
    return this._http.get<IResponseHistory[]>(url, httpOptions);
  }

  public getSingleResponseHistory(fundAppId: number, questionId: number, userId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/fundAppId/${fundAppId}/questionId/${questionId}/userId/${userId}`;
    return this._http.get<IResponseHistory>(url, httpOptions);
  }
  
  public getResponse(id: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/Id/${id}`;
    return this._http.get<IResponseOptions[]>(url, httpOptions);
  } 

  public getAllResponses() {
    const url = `${this._envUrl.urlAddress}/api/evaluation/getAll`;
    return this._http.get<IResponseOptions[]>(url, httpOptions);
  } 
  
  public workflowAssessmentCount(qcId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/QCId/${qcId}`;
    return this._http.get<number>(url, httpOptions);
  }  

  public getCapturedResponseHistory(fundingApplicationId: number, questionId: number, createdUserId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/fundingApplicationId/${fundingApplicationId}/questionId/${questionId}/createdUserId/${createdUserId}`;
    return this._http.get<IResponseHistory[]>(url, httpOptions);
  }

  public updateResponse(response: IResponse) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/response`;
    return this._http.put<IQuestionResponseViewModel>(url, response, httpOptions);
  }

  public updateScorecardResponse(response: IResponse) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/scorecardResponse`;
    return this._http.put<IQuestionResponseViewModel>(url, response, httpOptions);
  }

  public updateRejectionComment(response: IResponse, param: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/scorecardRejectResponse/param/${param}`;
    return this._http.put<IQuestionResponseViewModel>(url, response, httpOptions);
  }

  public getCapturedResponses(fundingApplicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/captured-response/fundingApplicationId/${fundingApplicationId}`;
    return this._http.get<ICapturedResponse[]>(url, httpOptions);
  }

  public getAllCapturedResponses() {
    const url = `${this._envUrl.urlAddress}/api/evaluation/captured-responses`;
    return this._http.get<ICapturedResponse[]>(url, httpOptions);
  }

  public createCapturedResponse(caputerdResponse: ICapturedResponse) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/captured-response`;
    return this._http.post<ICapturedResponse>(url, caputerdResponse, httpOptions);
  }

  public createScorecardResponse(caputerdResponse: ICapturedResponse) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/captured-scorecardResponse`;
    return this._http.post<ICapturedResponse>(url, caputerdResponse, httpOptions);
  }

  public addReviewerComment(caputerdResponse: ICapturedResponse) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/captured-reviewerComment`;
    return this._http.post<ICapturedResponse>(url, caputerdResponse, httpOptions);
  }

  public sendAmendmentNotification(fundingApplicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/evaluation/amendment-notification/fundingApplicationId/${fundingApplicationId}`;
    return this._http.post(url, httpOptions);
  }

}
