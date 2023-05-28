import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FinYear, IFundingApplicationDetails, IPlace, ISDA, ISubPlace } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};
@Injectable({
  providedIn: 'root'
})
export class BidService {

  private bidUrl: string;

  constructor(private http: HttpClient,
    private envUrl: EnvironmentUrlService) {
    this.bidUrl = this.envUrl.urlAddress + '/api/bid';
  } 

  getBid(id: number): Observable<IFundingApplicationDetails> {
    const url = `${this.bidUrl}/${id}`;
    return this.http.get<IFundingApplicationDetails>(url);
  }

  addBid(bid: IFundingApplicationDetails): Observable<IFundingApplicationDetails> {
    const url = `${this.bidUrl}`;
    return this.http.post<IFundingApplicationDetails>(url, bid, httpOptions);
  }

  editBid(id: number, bid: IFundingApplicationDetails): Observable<IFundingApplicationDetails> {
    const url = `${this.bidUrl}/${id}`;
    return this.http.put<IFundingApplicationDetails>(url, bid, httpOptions);
  } 


  getFinYears(): Observable<FinYear[]> {
    let url: string;
      url = `${this.bidUrl}/finyears`;
    return this.http.get<FinYear[]>(url);
  }

  public getApplicationBiId(applicationId: number) {
    const url = `${this.bidUrl}/applicationId/${applicationId}`;
    return this.http.get<IFundingApplicationDetails>(url, httpOptions);    
  }

  getPlaces(sdas: ISDA[]): Observable<IPlace[]> {
    const url = `${this.bidUrl}/places`;
    return this.http.post<IPlace[]>(url, JSON.stringify(sdas), httpOptions);
  }

  getSubPlaces(places: IPlace[]): Observable<ISubPlace[]> {
    const url = `${this.bidUrl}/subplaces`;
    return this.http.post<ISubPlace[]>(url, JSON.stringify(places), httpOptions);
  }
}
