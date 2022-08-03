import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IAddressLookup } from 'src/app/models/interfaces';

@Injectable({
  providedIn: 'root'
})
export class AddressLookupService {

  constructor(
    private _http: HttpClient
  ) { }

  public getAddress(address: string): Observable<IAddressLookup[]> {
    return this._http.get<IAddressLookup[]>(`https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/suggest?text=` + address + `&f=pjson&sourceCountry=ZAF&maxLocations=10`)
  }
}
