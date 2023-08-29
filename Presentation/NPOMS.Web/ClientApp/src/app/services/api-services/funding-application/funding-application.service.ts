import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';
import { IFundingApplicationDetails, IPlace, IRegion, ISDA, ISubPlace } from 'src/app/models/interfaces';
import { Observable } from 'rxjs';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};
@Injectable({
  providedIn: 'root'
})
export class FundingApplicationService {

  private fundAppUrl: string;
  constructor(private http: HttpClient,
    private envUrl: EnvironmentUrlService) {
    this.fundAppUrl = this.envUrl.urlAddress + '/api/applications';
}
getFundingApplicationDetails(id: number): Observable<IFundingApplicationDetails> {
  const url = `${this.fundAppUrl}/funding-application-details/${id}`;
  return this.http.get<IFundingApplicationDetails>(url);
}

addFundingApplicationDetails(fundAppDetail: IFundingApplicationDetails): Observable<IFundingApplicationDetails> {
  const url = `${this.fundAppUrl}/funding-application-details`;

  return this.http.post<IFundingApplicationDetails>(url, fundAppDetail, httpOptions);
}

editFundingApplicationDetails(fundAppDetail: IFundingApplicationDetails): Observable<IFundingApplicationDetails> {
  const url = `${this.fundAppUrl}/funding-application-details`;
  return this.http.put<IFundingApplicationDetails>(url, fundAppDetail, httpOptions);
}

getRegions(id: number): Observable<IRegion[]> {
  const url = `${this.fundAppUrl}/region/${id}`;
  return this.http.get<IRegion[]>(url);
}

getSdas(id: number): Observable<ISDA[]> {
  const url = `${this.fundAppUrl}/sdas/${id}`;
  return this.http.get<ISDA[]>(url);
}

getPlaces(sdas: ISDA[]): Observable<IPlace[]> {
  const url = `${this.fundAppUrl}/places`;
  return this.http.post<IPlace[]>(url, JSON.stringify(sdas), httpOptions);
}

getSubPlaces(places: IPlace[]): Observable<ISubPlace[]> {
  const url = `${this.fundAppUrl}/subplaces`;
  return this.http.post<ISubPlace[]>(url, JSON.stringify(places), httpOptions);
}

public getApplicationBiId(applicationId: number) {
  const url = `${this.fundAppUrl}/applicationId/${applicationId}`;
  return this.http.get<IFundingApplicationDetails>(url, httpOptions);
  
}

}
