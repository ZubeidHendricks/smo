import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EnvironmentUrlService {

  public urlAddress: string = environment.b2cConfig.resources.uri;

  constructor() { }
}
