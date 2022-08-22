import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IWorkplanTarget, } from 'src/app/models/interfaces';
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
    const url = `${this._envUrl.urlAddress}/api/indicators/activityId/${activityId}`;
    return this._http.get<IWorkplanTarget[]>(url, httpOptions);
  }

  public manageTarget(target: IWorkplanTarget) {
    const url = `${this._envUrl.urlAddress}/api/indicators/workplan`;
    return this._http.post<IWorkplanTarget>(url, target, httpOptions);
  }
}
