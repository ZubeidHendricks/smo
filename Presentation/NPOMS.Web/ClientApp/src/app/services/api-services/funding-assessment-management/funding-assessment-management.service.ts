import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';
import {  } from 'src/app/models/interfaces';
import { dtoFundingAssessmentApplicationFormGet, dtoFundingAssessmentApplicationFormSDAUpsert, dtoFundingAssessmentApplicationGet, dtoFundingAssessmentFormQuestionResponseUpsert } from './dtoFundingAssessmentManagement';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};
@Injectable({
  providedIn: 'root'
})
export class FundingAssessmentManagementService {
  private fundingManagementUrl: string;


  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) {
    this.fundingManagementUrl = `${this._envUrl.urlAddress}/api/funding-assessments`;

  }

  public getFundingAssessmentApplications() {
    const url = `${this.fundingManagementUrl}`;
    return this._http.get<dtoFundingAssessmentApplicationGet[]>(url, httpOptions);
  }

  public getFundingAssessmentApplicationForm(applicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/funding-assessments/0/application/${applicationId}`;
    return this._http.get<dtoFundingAssessmentApplicationFormGet>(url, httpOptions);
  }

  public updateDOICapturer(applicationId: number) {
    const url = `${this._envUrl.urlAddress}/api/funding-assessments/0/application/${applicationId}/doi-confirm-capturer`;
    return this._http.put<any>(url, null, httpOptions);
  }

  public upsertQuestionResponse(dto: dtoFundingAssessmentFormQuestionResponseUpsert) {
    const url = `${this._envUrl.urlAddress}/api/funding-assessments/${dto.assessmentApplicationFormId}/question/${dto.id}/responses`;
    return this._http.put<any>(url, dto, httpOptions);
  }

  public upsertSDA(formId: number, applicationId: number, dto: dtoFundingAssessmentApplicationFormSDAUpsert) {
    const url = `${this._envUrl.urlAddress}/api/funding-assessments/${formId}/application/${applicationId}/programeServiceDeliveryArea`;
    return this._http.put<any>(url, dto, httpOptions);
  }
//   public createFundingCapture(fundingCapture: IFundingCaptureViewModel) {
//     const url = `${this.fundingManagementUrl}`;
//     return this._http.post<IFundingCaptureViewModel>(url, fundingCapture, httpOptions);
//   }

//   public getFundingById(id: number) {
//     const url = `${this.fundingManagementUrl}/id/${id}`;
//     return this._http.get<INpoViewModel>(url, httpOptions);
//   }

//   public updateFundingCapture(fundingCapture: IFundingCaptureViewModel) {
//     const url = `${this.fundingManagementUrl}/funding-capture`;
//     return this._http.put<IFundingCaptureViewModel>(url, fundingCapture, httpOptions);
//   }

//   public updateFundingDetail(fundingDetail: IFundingDetailViewModel) {
//     const url = `${this.fundingManagementUrl}/funding-detail`;
//     return this._http.put<IFundingDetailViewModel>(url, fundingDetail, httpOptions);
//   }

//   public updateSDA(sda: ISDAViewModel) {
//     const url = `${this.fundingManagementUrl}/service-delivery-area`;
//     return this._http.put<ISDAViewModel>(url, sda, httpOptions);
//   }

//   public generatePaymentSchedule(fundingCaptureId: number, frequencyId: number, startDate: string, amountAwarded: number) {
//     const url = `${this.fundingManagementUrl}/fundingCaptureId/${fundingCaptureId}/frequencyId/${frequencyId}/startDate/${startDate}/amountAwarded/${amountAwarded}`;
//     return this._http.get<IPaymentScheduleViewModel>(url, httpOptions);
//   }

//   public updatePaymentSchedules(paymentSchedule: IPaymentScheduleViewModel) {
//     const url = `${this.fundingManagementUrl}/payment-schedule`;
//     return this._http.put<IPaymentScheduleViewModel>(url, paymentSchedule, httpOptions);
//   }

//   public updateBankDetails(bankDetail: IBankDetailViewModel) {
//     const url = `${this.fundingManagementUrl}/bank-detail`;
//     return this._http.put<IBankDetailViewModel>(url, bankDetail, httpOptions);
//   }

//   public updateDocument(document: IDocumentViewModel) {
//     const url = `${this.fundingManagementUrl}/document`;
//     return this._http.put<IDocumentViewModel>(url, document, httpOptions);
//   }

//   public updateApproverDetail(fundingCapture: IFundingCaptureViewModel) {
//     const url = `${this.fundingManagementUrl}/approver-detail`;
//     return this._http.put<IFundingCaptureViewModel>(url, fundingCapture, httpOptions);
//   }
}
