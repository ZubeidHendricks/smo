import { Component, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})

export class AppComponent implements OnInit {

  isIframe = false;

  constructor(
    private _primengConfig: PrimeNGConfig,
    private _msalService: MsalService,
  ) { }

  ngOnInit(): void {
    this.isIframe = window !== window.parent && !window.opener;

    this._primengConfig.ripple = true;
    document.documentElement.style.fontSize = 13 + 'px';

    this._msalService.instance.handleRedirectPromise().then(x => {
      if (x !== null && x.account !== null) {
        this._msalService.instance.setActiveAccount(x.account);
      }
    });
  }
}
