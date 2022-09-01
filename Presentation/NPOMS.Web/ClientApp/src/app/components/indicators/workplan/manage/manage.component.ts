import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MegaMenuItem } from 'primeng/api';
import { Subscription } from 'rxjs';
import { DropdownTypeEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IFinancialYear, IFrequencyPeriod, IWorkplanIndicator } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-manage',
  templateUrl: './manage.component.html',
  styleUrls: ['./manage.component.css']
})
export class ManageComponent implements OnInit {

  paramSubcriptions: Subscription;
  id: string;

  application: IApplication;
  activities: IActivity[];

  cols: any[];
  menuActions: MegaMenuItem[];

  workplanIndicators: IWorkplanIndicator[];
  financialYears: IFinancialYear[];
  frequencyPeriods: IFrequencyPeriod[];

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _activeRouter: ActivatedRoute,
    private _router: Router,
    private _dropdownRepo: DropdownService,
    private _indicatorRepo: IndicatorService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
      this.loadApplication();
    });

    this.buildMenu();
    this.loadFinancialYears();
    this.loadFrequencyPeriods();

    this.cols = [
      { field: 'activityList.description', header: 'Activity', width: '50%' },
      { field: 'successIndicator', header: 'Indicator', width: '30%' },
      { field: 'target', header: 'Target', width: '9%' },
    ];
  }

  getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];
    }

    return value;
  }

  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
          this.loadActivities();
        }

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadActivities() {
    this._spinner.show();
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.activities = results;
        this.workplanIndicators = [];

        this.activities.forEach(item => {
          this.workplanIndicators.push({
            activity: item,
            workplanTargets: [],
            workplanActuals: []
          } as IWorkplanIndicator);
        });

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }



  private buildMenu() {
    this.menuActions = [
      {
        label: 'Go Back',
        icon: 'fa fa-step-backward',
        command: () => {
          this._router.navigateByUrl('applications');
        }
      }
    ];
  }

  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        this.financialYears = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadFrequencyPeriods() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FrequencyPeriods, false).subscribe(
      (results) => {
        results = results.sort((a, b) => a.id - b.id);
        this.frequencyPeriods = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  captureActuals(activity) {
    this._router.navigateByUrl('workplan-indicator/actuals/' + activity.id);
  }

  captureTargets(activity) {
    this._router.navigateByUrl('workplan-indicator/targets/' + activity.id);
  }
}
