import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IApplicationPeriod } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApplicationPeriodService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getAllApplicationPeriods() {
    const url = `${this._envUrl.urlAddress}/api/application-periods`;
    return this._http.get<IApplicationPeriod[]>(url, httpOptions);
  }

  public getApplicationPeriodById(applicationPeriodId: number) {
    const url = `${this._envUrl.urlAddress}/api/application-periods/applicationPeriodId/${applicationPeriodId}`;
    return this._http.get<IApplicationPeriod>(url, httpOptions);
  }

  public createApplicationPeriod(applicationPeriod: IApplicationPeriod) {
    const url = `${this._envUrl.urlAddress}/api/application-periods`;
    return this._http.post<IApplicationPeriod>(url, applicationPeriod, httpOptions);
  }

  public updateApplicationPeriod(applicationPeriod: IApplicationPeriod) {
    const url = `${this._envUrl.urlAddress}/api/application-periods`;
    return this._http.put<IApplicationPeriod>(url, applicationPeriod, httpOptions);
  }
}
