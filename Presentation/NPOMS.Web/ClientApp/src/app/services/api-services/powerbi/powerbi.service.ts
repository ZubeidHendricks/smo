import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IEmbeddedReport } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class PowerbiService {

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getAll() {
    return this._http.get<IEmbeddedReport[]>(`${this._envUrl.urlAddress}/api/powerbi`, httpOptions)
  }

  public getReport(id: number) {
    return this._http.get<any>(`${this._envUrl.urlAddress}/api/powerbi/${id}`, httpOptions)
  }
}
