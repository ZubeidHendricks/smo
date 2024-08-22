import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';
import { INpoViewModel } from 'src/app/models/interfaces';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};
@Injectable({
  providedIn: 'root'
})
export class FundingManagementService {
  private fundingManagementUrl: string;

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) {
    this.fundingManagementUrl = `${this._envUrl.urlAddress}/api/funding-management`;
  }

  public getAllFundingCaptures() {
    const url = `${this.fundingManagementUrl}`;
    return this._http.get<INpoViewModel[]>(url, httpOptions);
  }

  public getFundingCaptureById(id: number) {
    const url = `${this.fundingManagementUrl}/id/${id}`;
    return this._http.get<INpoViewModel>(url, httpOptions);
  }

  public getFundingCaptureByNpoId(npoId: number) {
    const url = `${this.fundingManagementUrl}/npoId/${npoId}`;
    return this._http.get<INpoViewModel>(url, httpOptions);
  }
}
