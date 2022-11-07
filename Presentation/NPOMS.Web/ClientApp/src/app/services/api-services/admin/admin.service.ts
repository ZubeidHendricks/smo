import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ICompliantCycle, IPaymentSchedule } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getCompliantCyclesByIds(departmentId: number, financialYearId: number) {
    const url = `${this._envUrl.urlAddress}/api/admin/compliant-cycle/departmentId/${departmentId}/financialYearId/${financialYearId}`;
    return this._http.get<ICompliantCycle[]>(url, httpOptions);
  }

  public createCompliantCycle(compliantCycle: ICompliantCycle) {
    const url = `${this._envUrl.urlAddress}/api/admin/compliant-cycle`;
    return this._http.post<ICompliantCycle>(url, compliantCycle, httpOptions);
  }

  public updateCompliantCycle(compliantCycle: ICompliantCycle) {
    const url = `${this._envUrl.urlAddress}/api/admin/compliant-cycle`;
    return this._http.put<ICompliantCycle>(url, compliantCycle, httpOptions);
  }

  public getPaymentSchedulesByIds(departmentId: number, financialYearId: number) {
    const url = `${this._envUrl.urlAddress}/api/admin/payment-schedule/departmentId/${departmentId}/financialYearId/${financialYearId}`;
    return this._http.get<IPaymentSchedule[]>(url, httpOptions);
  }

  public createPaymentSchedule(paymentSchedule: IPaymentSchedule) {
    const url = `${this._envUrl.urlAddress}/api/admin/payment-schedule`;
    return this._http.post<IPaymentSchedule>(url, paymentSchedule, httpOptions);
  }

  public updatePaymentSchedule(paymentSchedule: IPaymentSchedule) {
    const url = `${this._envUrl.urlAddress}/api/admin/payment-schedule`;
    return this._http.put<IPaymentSchedule>(url, paymentSchedule, httpOptions);
  }
}
