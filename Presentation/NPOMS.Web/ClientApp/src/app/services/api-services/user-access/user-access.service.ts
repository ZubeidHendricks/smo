import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUserNpo } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class UserAccessService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getAllUserNpos() {
    const url = `${this._envUrl.urlAddress}/api/user-access`;
    return this._http.get<IUserNpo[]>(url, httpOptions);
  }

  public createUserNpo(mapping: IUserNpo) {
    const url = `${this._envUrl.urlAddress}/api/user-access`;
    return this._http.post<IUserNpo>(url, mapping, httpOptions);
  }

  public updateUserNpo(mapping: IUserNpo) {
    const url = `${this._envUrl.urlAddress}/api/user-access`;
    return this._http.put<IUserNpo>(url, mapping, httpOptions);
  }
}
