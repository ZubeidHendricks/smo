import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { INpoProfile } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class NpoProfileService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getAllNpoProfiles() {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles`;
    return this._http.get<INpoProfile[]>(url, httpOptions);
  }

  public getNpoProfileById(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/npoProfileId/${npoProfileId}`;
    return this._http.get<INpoProfile>(url, httpOptions);
  }

  public getNpoProfileByNpoId(npoId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/npoId/${npoId}`;
    return this._http.get<INpoProfile>(url, httpOptions);
  }

  public createNpoProfile(npoProfile: INpoProfile) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles`;
    return this._http.post<INpoProfile>(url, npoProfile, httpOptions);
  }

  public updateNpoProfile(npoProfile: INpoProfile) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles`;
    return this._http.put<INpoProfile>(url, npoProfile, httpOptions);
  }
}
