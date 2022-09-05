import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PermissionsEnum, ReportTypeEnum } from 'src/app/models/enums';
import { IUser } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';
import * as pbi from 'powerbi-client';
import { PowerbiService } from 'src/app/services/api-services/powerbi/powerbi.service';
import { NgxPowerBiService } from 'ngx-powerbi';
import { NgxSpinnerService } from 'ngx-spinner';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-powerbi-dashboard',
  templateUrl: './powerbi-dashboard.component.html',
  styleUrls: ['./powerbi-dashboard.component.css']
})
export class PowerbiDashboardComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  profile: IUser;
  errMessage: string;

  private powerBiService: NgxPowerBiService;
  private pbiContainerElement: HTMLElement;

  config: any;
  screenHeight: number;
  powerBI: {
    type: string,
    EmbedReport: {
      ReportId: string,
      ReportName: string,
      EmbedUrl: string
    }[],
    EmbedToken: {
      Token: string,
      TokenId: string,
      Expiration: string
    }
  };

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _reportService: PowerbiService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService
  ) {
    this.powerBiService = new NgxPowerBiService();
  }

  ngOnInit(): void {
    this._spinner.show();

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewDashboard))
          this._router.navigate(['401']);
      }
    });

    this.pbiContainerElement = <HTMLElement>(document.getElementById('pbi-container'));

    this._reportService.getReport(ReportTypeEnum.PowerBIDashboard).subscribe(
      (resp) => {
        this.powerBI = resp;

        const basicFilter = {
          $schema: "http://powerbi.com/product/schema#basic",
          target: {
            table: "Store",
            column: "Count"
          },
          operator: "In",
          values: [1, 2, 3, 4],
          filterType: 1
        }

        const config = {
          type: 'report',
          tokenType: pbi.models.TokenType.Embed,
          id: this.powerBI.EmbedReport[0].ReportId,
          embedUrl: this.powerBI.EmbedReport[0].EmbedUrl,
          accessToken: this.powerBI.EmbedToken.Token,
          tokenExpiry: null,
          // permissions: 7,
          settings: {
            filterPaneEnabled: true,
            navContentPaneEnabled: true
          },
          // filters: [basicFilter]  
        };
        // this.powerBiService.embed(this.pbiContainerElement, config)

        this.screenHeight = (window.screen.height - 100);
        var report = this.powerBiService.embed(this.pbiContainerElement, config);
        // Report.off removes a given event handler if it exists.
        report.off('loaded');
        report.on("loaded", function () {
          console.log("Report load successful");
        });

        // Clear any other rendered handler events
        report.off("rendered");

        // Triggers when a report is successfully embedded in UI
        report.on("rendered", function () {
          console.log("Report render successful");
        });

        // Clear any other error handler events
        report.off("error");
        report.on('error', function (event) {
          console.log(event.detail);
          report.off('error');
        });

        report.off('saved');
        report.on('saved', function (event) {
          console.log(event.detail);
        });

        this._spinner.hide();
      },
      (error) => {
        this._loggerService.logException(error.error)
        this.errMessage = error.error;
        this._spinner.hide();
      }
    );
  }
}