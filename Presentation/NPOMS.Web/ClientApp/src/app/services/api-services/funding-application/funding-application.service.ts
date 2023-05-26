import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';
import { IFundingApplicationDetails, IPlace, ISDA, ISubPlace } from 'src/app/models/interfaces';
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
  const url = `${this.fundAppUrl}/${id}`;
  return this.http.get<IFundingApplicationDetails>(url);
}

addFundingApplicationDetails(fundAppDetail: IFundingApplicationDetails): Observable<IFundingApplicationDetails> {
  const url = `${this.fundAppUrl}`;

  return this.http.post<IFundingApplicationDetails>(url, fundAppDetail, httpOptions);
}

editFundingApplicationDetails(id: number, fundAppDetail: IFundingApplicationDetails): Observable<IFundingApplicationDetails> {
  const url = `${this.fundAppUrl}/${id}`;
  return this.http.put<IFundingApplicationDetails>(url, fundAppDetail, httpOptions);
}

getSdas(): Observable<ISDA[]> {
  const url = `${this.fundAppUrl}/sdas`;
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
