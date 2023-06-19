import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBankDetail, INpoProfile, INpoProfileFacilityList, IServicesRendered } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';
import { IPreviousFinancialYear } from 'src/app/models/FinancialMatters';

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

  public getFacilitiesByNpoProfileId(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/facilities/npoProfileId/${npoProfileId}`;
    return this._http.get<INpoProfileFacilityList[]>(url, httpOptions);
  }

  public createFacilityMapping(mapping: INpoProfileFacilityList) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/facilities`;
    return this._http.post<INpoProfileFacilityList>(url, mapping, httpOptions);
  }

  public updateFacilityMapping(mapping: INpoProfileFacilityList) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/facilities`;
    return this._http.put<INpoProfileFacilityList>(url, mapping, httpOptions);
  }

  public deleteFacilityMapping(mapping: INpoProfileFacilityList) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/facilities`;
    return this._http.put<INpoProfileFacilityList>(url, mapping, httpOptions);
  }

  public getServicesRenderedByNpoProfileId(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/services-rendered/npoProfileId/${npoProfileId}`;
    return this._http.get<IServicesRendered[]>(url, httpOptions);
  }

  public createServicesRendered(servicesRendered: IServicesRendered) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/services-rendered`;
    return this._http.post<IServicesRendered>(url, servicesRendered, httpOptions);
  }

  public updateServicesRendered(servicesRendered: IServicesRendered) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/services-rendered`;
    return this._http.put<IServicesRendered>(url, servicesRendered, httpOptions);
  }

  public deleteServicesRendered(servicesRendered: IServicesRendered) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/services-rendered`;
    return this._http.put<IServicesRendered>(url, servicesRendered, httpOptions);
  }

  public getBankDetailByNpoProfileId(npoProfileId: number) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/bank-detail/npoProfileId/${npoProfileId}`;
    return this._http.get<IBankDetail[]>(url, httpOptions);
  }

  public createBankDetail(bankDetail: IBankDetail) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/CreateBankDetail`;
    return this._http.post<IBankDetail>(url, bankDetail, httpOptions);
  }

  public updateBankDetail(bankDetail: IBankDetail) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/bank-detail`;
    return this._http.put<IBankDetail>(url, bankDetail, httpOptions);
  }

  public deleteBankDetail(bankDetail: IBankDetail) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/bank-detail`;
    return this._http.put<IBankDetail>(url, bankDetail, httpOptions);
  }

  public UpdatePreviousYearData(previousYearData: any[], npoProfileId: string) {
    const url = `${this._envUrl.urlAddress}/api/npo-profiles/bank-detail`;
    return this._http.put<IPreviousFinancialYear[]>(url, previousYearData, httpOptions);
  }
}
