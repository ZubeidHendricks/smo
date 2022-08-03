import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }

  constructor(
    private _http: HttpClient,
    private _envUrl: EnvironmentUrlService
  ) { }

  getLoggedInProfile(): Observable<IUser> {
    //todo: need to change the profile service 
    let userName = 'current';
    return this._http.get<IUser>(`${this._envUrl.urlAddress}/api/users/${userName}`);
  }
}
