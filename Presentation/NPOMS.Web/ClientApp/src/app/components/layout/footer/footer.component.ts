import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  get primefacesUrl() {
    return environment.primefacesUrl;
  }

  get environmentName() {
    return environment.environmentName;
  }

  currentYear(): string {
    return moment().format('YYYY');
  }

  currentVersion(): string {
    return '2.8.8';
  }

  deploymentDate(): string {
    return '17 January 2024';
  }
}
