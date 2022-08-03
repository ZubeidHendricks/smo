import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUser } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getAllUsers() {
    const url = `${this._envUrl.urlAddress}/api/users`;
    return this._http.get<IUser[]>(url, httpOptions);
  }

  public createUser(user) {
    const url = `${this._envUrl.urlAddress}/api/users`;
    return this._http.post<IUser>(url, user, httpOptions);
  }

  public updateUser(user) {
    const url = `${this._envUrl.urlAddress}/api/users`;
    return this._http.put<IUser>(url, user, httpOptions);
  }

  /*Search for user*/
  public searchForUser(searchTerm) {
    const url = `${this._envUrl.urlAddress}/api/users/global?searchTerm=${searchTerm}`;
    return this._http.get<any[]>(url, httpOptions);
  }
}
