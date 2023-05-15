import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PropertySubType } from 'src/app/models/PropertySubType';
import { PropertyType } from 'src/app/models/PropertyType';
import { Bid, FinYear, DistrictCouncil, LocalMunicipality, Region, SDA, Place, SubPlace } from 'src/app/models/interfaces';
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

  getBid(id: number): Observable<Bid> {
    const url = `${this.bidUrl}/${id}`;
    return this.http.get<Bid>(url);
  }

  addBid(bid: Bid): Observable<Bid> {
    const url = `${this.bidUrl}`;
    return this.http.post<Bid>(url, bid, httpOptions);
  }

  editBid(id: number, bid: Bid): Observable<Bid> {
    const url = `${this.bidUrl}/${id}`;
    return this.http.put<Bid>(url, bid, httpOptions);
  }

  getFinYears(): Observable<FinYear[]> {
    let url: string;
      url = `${this.bidUrl}/finyears`;
    return this.http.get<FinYear[]>(url);
  }

  public getApplicationBiId(applicationId: number) {
    const url = `${this.bidUrl}/applicationId/${applicationId}`;
    return this.http.get<Bid>(url, httpOptions);    
  }

  getpropertyTypes(): Observable<PropertyType[]> {

    let url: string;
    url = `${this.bidUrl}/propertyTypes`;
    return this.http.get<PropertyType[]>(url);
  }

  getsubPropertyTypes(): Observable<PropertySubType[]> {
    const url = `${this.bidUrl}/subPropertyTypes`;
    return this.http.get<PropertySubType[]>(url);
  }

  
  getDistrictCouncils(): Observable<DistrictCouncil[]> {
    const url = `${this.bidUrl}/DistrictCouncils`;
    return this.http.get<DistrictCouncil[]>(url);
  }

  getLocalMunicipalities(): Observable<LocalMunicipality[]> {
    const url = `${this.bidUrl}/LocalMunicipalities`;
    return this.http.get<LocalMunicipality[]>(url);
  }

  getRegions(): Observable<Region[]> {
    const url = `${this.bidUrl}/Regions`;
    return this.http.get<Region[]>(url);
  }

  getSdas(): Observable<SDA[]> {
    const url = `${this.bidUrl}/sdas`;
    return this.http.get<SDA[]>(url);
  }

  getPlaces(sdas: SDA[]): Observable<Place[]> {
    const url = `${this.bidUrl}/places`;
    return this.http.post<Place[]>(url, JSON.stringify(sdas), httpOptions);
  }

  getSubPlaces(places: Place[]): Observable<SubPlace[]> {
    const url = `${this.bidUrl}/subplaces`;
    return this.http.post<SubPlace[]>(url, JSON.stringify(places), httpOptions);
  }
}
