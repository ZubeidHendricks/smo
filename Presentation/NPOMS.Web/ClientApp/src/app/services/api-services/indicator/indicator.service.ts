import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IWorkplanActual, IWorkplanTarget, } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class IndicatorService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getTargetsByActivityId(activityId: number) {
    const url = `${this._envUrl.urlAddress}/api/indicators/workplan-target/activityId/${activityId}`;
    return this._http.get<IWorkplanTarget[]>(url, httpOptions);
  }

  public manageTarget(target: IWorkplanTarget) {
    const url = `${this._envUrl.urlAddress}/api/indicators/workplan-target`;
    return this._http.post<IWorkplanTarget>(url, target, httpOptions);
  }

  public getActualsByActivityId(activityId: number) {
    const url = `${this._envUrl.urlAddress}/api/indicators/workplan-actual/activityId/${activityId}`;
    return this._http.get<IWorkplanActual[]>(url, httpOptions);
  }

  public updateActual(actual: IWorkplanActual) {
    const url = `${this._envUrl.urlAddress}/api/indicators/workplan-actual`;
    return this._http.put<IWorkplanActual>(url, actual, httpOptions);
  }
}
