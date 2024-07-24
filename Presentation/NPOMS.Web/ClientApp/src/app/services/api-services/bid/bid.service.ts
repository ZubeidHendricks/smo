import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FinYear, IFundAppDeclaration, IFundingApplicationDetails, IPlace, ISDA, ISubPlace } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';
import { DeclarationTypeEnum, FundingApplicationStepsEnum } from 'src/app/models/enums';
import { FinancialMatters } from 'src/app/models/FinancialMatters';

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

  editIncome(id: number, financialMatter: FinancialMatters): Observable<FinancialMatters> {
    const url = `${this.bidUrl}/${id}/income`;
    return this.http.put<FinancialMatters>(url, financialMatter, httpOptions);
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

  getSdaPlaces(sdas: ISDA[], applicationId: number, programId: number): Observable<IPlace[]> {
    const url = `${this.bidUrl}/places/applicationId/${applicationId}/programId/${programId}`;
    return this.http.post<IPlace[]>(url, JSON.stringify(sdas), httpOptions);
  }

  getSubPlaces(places: IPlace[]): Observable<ISubPlace[]> {
    const url = `${this.bidUrl}/subplaces`;
    return this.http.post<ISubPlace[]>(url, JSON.stringify(places), httpOptions);
  }

  public getSignOff(procurementSection: FundingApplicationStepsEnum, implementationId: number, declarationType: string) {
   // const url = `${this.bidUrl}/api/proposal/procurementSectionEnum/${procurementSection}/implementationId/${implementationId}/declarationType/${declarationType}`;
    var data;

    // switch (procurementSection) {
    //   case FundingApplicationStepsEnum.Declaration:
    //     data = this.http.get<IFundAppDeclaration>(url, httpOptions);
    //     break;
    //   // case FundingApplicationStepsEnum.Bidders2:
    //   //   data = this.http.get<IFundAppDeclaration>(url, httpOptions);
    //   //   break;
    // }

    return data;
  }

  public updateSignOff(data: any, procurementSection: FundingApplicationStepsEnum, declarationType: string) {
    //const url = `${this.bidUrl}/api/proposal/procurementSectionEnum/${procurementSection}/declarationType/${declarationType}`;
    var entity;

    // switch (procurementSection) {
    //   case FundingApplicationStepsEnum.Declaration:
    //     entity = this.http.put<IFundAppDeclaration>(url, data, httpOptions);
    //     break;
    //   // case DeclarationTypeEnum.Bidders2:
    //   //   entity = this.http.put<IFundAppDeclaration>(url, data, httpOptions);
    //   //   break;
    // }

    return entity;
  }

}
