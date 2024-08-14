import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApplicationWithUsers, IActivity, IApplication, IApplicationApproval, IApplicationAudit, IApplicationComment, IApplicationReviewerSatisfaction, IBankDetail, IFacilityList, IFinancialYear, IFundingApplicationDetails, IMyContentLink, IObjective, IPlace, IProjectImplementation, IResource, ISDA, ISubPlace, ISustainabilityPlan, IUser } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getAllApplications() {
    const url = `${this._envUrl.urlAddress}/api/applications`;
    return this._http.get<IApplication[]>(url, httpOptions);
  }

  public getApplicationById(applicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/applicationId/${applicationId}`;
    return this._http.get<IApplication>(url, httpOptions);
  }

  public getApplicationByNpoIdAndPeriodId(application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications/npoId/${application.npoId}/applicationPeriodId/${application.applicationPeriodId}`;
    return this._http.get<IApplication>(url, httpOptions);
  }

  public getApplicationsByNpoId(npoId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/npoId/${npoId}`;
    return this._http.get<IApplication[]>(url, httpOptions);
  }

  public createApplication(application: IApplication, createNew: boolean, financialYear: IFinancialYear) {
    // Set default value for financial year id as it would be null when createNew is true
    let financialYearId = financialYear != null ? financialYear.id : 0;

    const url = `${this._envUrl.urlAddress}/api/applications/createNew/${createNew}/financialYearId/${financialYearId}`;
    return this._http.post<IApplication>(url, application, httpOptions);
  }

  public updateApplication(application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications`;
    return this._http.put<IApplication>(url, application, httpOptions);
  }

  public addProjectImplementation(projectImplementation: IProjectImplementation) {
    const url = `${this._envUrl.urlAddress}/api/applications/addProjectImplementation`;
    return this._http.post<IProjectImplementation>(url, projectImplementation, httpOptions);
  }

  public updateProjectImplementation(projectImplementation: IProjectImplementation) {
    const url = `${this._envUrl.urlAddress}/api/applications/updateProjectImplementation`;
    return this._http.put<IProjectImplementation>(url, projectImplementation, httpOptions);
  }

  public deleteApplicationById(applicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/applicationId/${applicationId}`;
    return this._http.put<IApplication>(url, httpOptions);
  }

  public getAllObjectives(application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications/objectives/npoId/${application.npoId}/applicationPeriodId/${application.applicationPeriodId}`;
    return this._http.get<IObjective[]>(url, httpOptions);
  }

  public createObjective(objective: IObjective, application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications/objectives/npoId/${application.npoId}/applicationPeriodId/${application.applicationPeriodId}`;
    return this._http.post<IObjective>(url, objective, httpOptions);
  }

  public updateObjective(objective: IObjective) {
    const url = `${this._envUrl.urlAddress}/api/applications/objectives`;
    return this._http.put<IObjective>(url, objective, httpOptions);
  }


  public createFundingApplicationDetails(fundingApplicationDetails: IFundingApplicationDetails, application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications/fundingApplicationDetails/npoId/${application.npoId}/applicationPeriodId/${application.applicationPeriodId}`;
    return this._http.post<IFundingApplicationDetails>(url, fundingApplicationDetails, httpOptions);
  }

  public updateFundingApplicationDetails(fundingApplicationDetails: IFundingApplicationDetails) {
    const url = `${this._envUrl.urlAddress}/api/applications/fundingApplicationDetails`;
    return this._http.put<IFundingApplicationDetails>(url, fundingApplicationDetails, httpOptions);
  }

  public createBankDetail(bankDetail: IBankDetail) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/bank-detail`;
    return this._http.post<IBankDetail>(url, bankDetail, httpOptions);
  }


  public getAllActivities(application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications/activities/npoId/${application.npoId}/applicationPeriodId/${application.applicationPeriodId}`;
    return this._http.get<IActivity[]>(url, httpOptions);
  }

  public getActivityById(activityId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/activityId/${activityId}`;
    return this._http.get<IActivity>(url, httpOptions);
  }

  public createActivity(activity: IActivity, application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications/activities/npoId/${application.npoId}/applicationPeriodId/${application.applicationPeriodId}`;
    return this._http.post<IActivity>(url, activity, httpOptions);
  }

  public updateActivity(activity: IActivity) {
    const url = `${this._envUrl.urlAddress}/api/applications/activities`;
    return this._http.put<IActivity>(url, activity, httpOptions);
  }

  public getAllResources(application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications/resources/npoId/${application.npoId}/applicationPeriodId/${application.applicationPeriodId}`;
    return this._http.get<IResource[]>(url, httpOptions);
  }

  public createResource(resource: IResource, application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications/resources/npoId/${application.npoId}/applicationPeriodId/${application.applicationPeriodId}`;
    return this._http.post<IResource>(url, resource, httpOptions);
  }

  public updateResource(resource: IResource) {
    const url = `${this._envUrl.urlAddress}/api/applications/resources`;
    return this._http.put<IResource>(url, resource, httpOptions);
  }

  public getAllSustainabilityPlans(application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications/sustainability-plans/npoId/${application.npoId}/applicationPeriodId/${application.applicationPeriodId}`;
    return this._http.get<ISustainabilityPlan[]>(url, httpOptions);
  }

  public createSustainabilityPlan(sustainabilityPlan: ISustainabilityPlan, application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications/sustainability-plans/npoId/${application.npoId}/applicationPeriodId/${application.applicationPeriodId}`;
    return this._http.post<ISustainabilityPlan>(url, sustainabilityPlan, httpOptions);
  }

  public updateSustainabilityPlan(sustainabilityPlan: ISustainabilityPlan) {
    const url = `${this._envUrl.urlAddress}/api/applications/sustainability-plans`;
    return this._http.put<ISustainabilityPlan>(url, sustainabilityPlan, httpOptions);
  }

  public getAssignedFacilities(application: IApplication) {
    const url = `${this._envUrl.urlAddress}/api/applications/facilities/npoId/${application.npoId}`;
    return this._http.get<IFacilityList[]>(url, httpOptions);
  }

  public getAllApplicationComments(applicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/application-comments/applicationId/${applicationId}`;
    return this._http.get<IApplicationComment[]>(url, httpOptions);
  }

  public getApplicationComments(model: IApplicationComment) {
    const url = `${this._envUrl.urlAddress}/api/applications/application-comments/applicationId/${model.applicationId}/serviceProvisionStepId/${model.serviceProvisionStepId}/entityId/${model.entityId}`;
    return this._http.get<IApplicationComment[]>(url, httpOptions);
  }

  public createApplicationComment(model: IApplicationComment, changesRequired: boolean) {
    const url = `${this._envUrl.urlAddress}/api/applications/application-comments/changesRequired/${changesRequired}`;
    return this._http.post<IApplicationComment>(url, model, httpOptions);
  }

  public getApplicationAudits(applicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/application-audits/applicationId/${applicationId}`;
    return this._http.get<IApplicationAudit[]>(url, httpOptions);
  }

  public getApplicationApprovals(applicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/approval/applicationId/${applicationId}`;
    return this._http.get<IApplicationApproval[]>(url, httpOptions);
  }

  public createApplicationApproval(applicationApproval: IApplicationApproval) {
    const url = `${this._envUrl.urlAddress}/api/applications/approval`;
    return this._http.post<IApplicationApproval[]>(url, applicationApproval, httpOptions);
  }

  public updateApplicationApproval(applicationApproval: IApplicationApproval) {
    const url = `${this._envUrl.urlAddress}/api/applications/approval`;
    return this._http.put<IApplicationApproval>(url, applicationApproval, httpOptions);
  }

  public getApplicationReviewerSatisfactions(model: IApplicationReviewerSatisfaction) {
    const url = `${this._envUrl.urlAddress}/api/applications/application-reviewer-satisfaction/applicationId/${model.applicationId}/serviceProvisionStepId/${model.serviceProvisionStepId}/entityId/${model.entityId}`;
    return this._http.get<IApplicationReviewerSatisfaction[]>(url, httpOptions);
  }

  public getReviewerSatisfactionByApplicationId(applicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/application-reviewer-satisfaction/applicationId/${applicationId}`;
    return this._http.get<IApplicationReviewerSatisfaction[]>(url, httpOptions);
  }

  public createApplicationReviewerSatisfaction(model: IApplicationReviewerSatisfaction) {
    const url = `${this._envUrl.urlAddress}/api/applications/application-reviewer-satisfaction`;
    return this._http.post<IApplicationReviewerSatisfaction>(url, model, httpOptions);
  }

  getPlaces(sdas: ISDA[]): Observable<IPlace[]> {
    const url = `${this._envUrl.urlAddress}/api/applications/places`;
    return this._http.post<IPlace[]>(url, JSON.stringify(sdas), httpOptions);
  }

  getSubPlaces(places: IPlace[]): Observable<ISubPlace[]> {
    const url = `${this._envUrl.urlAddress}/api/applications/subplaces`;
    return this._http.post<ISubPlace[]>(url, JSON.stringify(places), httpOptions);
  }

  public getMyContentLinks(applicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/my-content-link/applicationId/${applicationId}`;
    return this._http.get<IMyContentLink[]>(url, httpOptions);
  }

  public createMyContentLink(model: IMyContentLink) {
    const url = `${this._envUrl.urlAddress}/api/applications/my-content-link`;
    return this._http.post<IMyContentLink>(url, model, httpOptions);
  }

  public updateMyContentLink(model: IMyContentLink) {
    const url = `${this._envUrl.urlAddress}/api/applications/my-content-link`;
    return this._http.put<IMyContentLink>(url, model, httpOptions);
  }

  public UpdateInitiateScorecardValue(applicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/UpdateInitiateScorecardValue/applicationId/${applicationId}`;
    return this._http.put<IApplication>(url, httpOptions);
  }

  public UpdateCloseScorecardValue(applicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/UpdateCloseScorecardValue/applicationId/${applicationId}`;
    return this._http.put<IApplication>(url, httpOptions);
  }  

  public reviewers() {
    const url = `${this._envUrl.urlAddress}/api/applications/reviewers`;
    return this._http.get<IUser[]>(url, httpOptions);
  }

  public depReviewers(departmentId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/depReviewers/${departmentId}`;
    return this._http.get<IUser[]>(url, httpOptions);
  }

  public workplanMainReviewers(departmentId: number) {
    const url = `${this._envUrl.urlAddress}/api/applications/workplanapprovers/${departmentId}`;
    return this._http.get<IUser[]>(url, httpOptions);
  }

  public UpdateInitiateScorecardValueAndEmail(applicationId: number, users: { fullName: string, email: string, id: number }[]) {
    const url = `${this._envUrl.urlAddress}/api/applications/UpdateInitiateScorecardValueAndEmail/applicationId/${applicationId}`;
    return this._http.put<IApplication>(url, users, httpOptions);
}
public UpdatesatisfactionReviewers(applicationId: number, users: { fullName: string, email: string, id: number }[]) {
  const url = `${this._envUrl.urlAddress}/api/applications/UpdatesatisfactionReviewers/applicationId/${applicationId}`;
  return this._http.put<IApplication>(url, users, httpOptions);
}

public UpdateReviewers(applicationId: number, users: { fullName: string, email: string, id: number }[]) {
  const url = `${this._envUrl.urlAddress}/api/applications/UpdateReviewers/applicationId/${applicationId}`;
  return this._http.put<IApplication>(url, users, httpOptions);
}

public updateApplicationWithApprovers(model: ApplicationWithUsers) {
  const url = `${this._envUrl.urlAddress}/api/applications/Addworkplanapprovers`;
  return this._http.put<IApplication>(url, model, httpOptions);
}
}
