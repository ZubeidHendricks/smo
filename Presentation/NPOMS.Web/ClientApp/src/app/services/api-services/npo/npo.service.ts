import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccessStatusEnum } from 'src/app/models/enums';
import { INpo, IQuickCaptureDetails } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class NpoService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getAllNpos(accessStatus: AccessStatusEnum) {
    const url = `${this._envUrl.urlAddress}/api/npos/access-status/${accessStatus}`;
    return this._http.get<INpo[]>(url, httpOptions);
  }

  public getAllQuickCaptures(accessStatus: AccessStatusEnum) {
    const url = `${this._envUrl.urlAddress}/api/npos/quick-captures/access-status/${accessStatus}`;
    return this._http.get<INpo[]>(url, httpOptions);
  }    

  // public getAllQuickCaptures(accessStatus: AccessStatusEnum) {
  //   const url = `${this._envUrl.urlAddress}/api/npos/quick-captures/access-status/${accessStatus}`;
  //   return this._http.get<IQuickCaptureDetails[]>(url, httpOptions);
  // }  

  public getNpoById(npoId: number) {
    const url = `${this._envUrl.urlAddress}/api/npos/npoId/${npoId}`;
    return this._http.get<INpo>(url, httpOptions);
  }

  public getNpoByName(name: string) {
    const url = `${this._envUrl.urlAddress}/api/npos/name/${name}`;
    return this._http.get<INpo[]>(url, httpOptions);
  }

  public getApprovedNpoByName(name: string) {
    const url = `${this._envUrl.urlAddress}/api/npos/approved-npo/name/${name}`;
    return this._http.get<INpo[]>(url, httpOptions);
  }

  public createNpo(npo: INpo) {
    const url = `${this._envUrl.urlAddress}/api/npos`;
    return this._http.post<INpo>(url, npo, httpOptions);
  }


  public createQCNpo(npo: INpo, isQuickCapture: boolean) {
    const url = `${this._envUrl.urlAddress}/api/npos/isQuickCapture/${isQuickCapture}`;

    return this._http.post<INpo>(url, npo, httpOptions);
  }

  public updateNpo(npo: INpo) {
    const url = `${this._envUrl.urlAddress}/api/npos`;
    return this._http.put<INpo>(url, npo, httpOptions);
  }

  public updateNpoApprovalStatus(npo: INpo) {
    const url = `${this._envUrl.urlAddress}/api/npos/approval-status`;
    return this._http.put<INpo>(url, npo, httpOptions);
  }
}
