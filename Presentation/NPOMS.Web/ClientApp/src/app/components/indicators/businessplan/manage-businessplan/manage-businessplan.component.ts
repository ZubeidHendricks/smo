import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MegaMenuItem } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ApplicationTypeEnum, DropdownTypeEnum, PermissionsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IFinancialYear, IFrequencyPeriod, IUser, IWorkplanIndicator } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-manage-businessplan',
  templateUrl: './manage-businessplan.component.html',
  styleUrls: ['./manage-businessplan.component.css']
})
export class ManageBusinessPlanComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  paramSubcriptions: Subscription;
  npoId: string;

  profile: IUser;

  applications: IApplication[];
  application: IApplication;
  activities: IActivity[];

  cols: any[];
  menuActions: MegaMenuItem[];

  workplanIndicators: IWorkplanIndicator[];
  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;
  frequencyPeriods: IFrequencyPeriod[];

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _activeRouter: ActivatedRoute,
    private _router: Router,
    private _dropdownRepo: DropdownService,
    private _loggerService: LoggerService,
    private _authService: AuthService
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.npoId = params.get('npoId');
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this._spinner.show();
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewManageIndicatorsOption))
          this._router.navigate(['401']);

        this.loadApplications();
        this.buildMenu();
        this.loadFrequencyPeriods();
      }
    });

    this.cols = [
      { field: 'activityList.name', header: 'Activity', width: '50%' },
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

  private loadApplications() {
    this._applicationRepo.getApplicationsByNpoId(Number(this.npoId)).subscribe(
      (results) => {
        this.financialYears = [];
        this.applications = results.filter(x => x.applicationPeriod.applicationTypeId === ApplicationTypeEnum.BP && x.statusId === StatusEnum.Approved);

        this.applications.forEach(item => {
          var isPresent = this.financialYears.some(function (financialYear) { return financialYear === item.applicationPeriod.financialYear });
          if (!isPresent)
            this.financialYears.push(item.applicationPeriod.financialYear);
        });

        this.isDataAvailable();
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
        this.activities = results.filter(x => x.isActive === true);
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

  private loadFrequencyPeriods() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FrequencyPeriods, false).subscribe(
      (results) => {
        results = results.sort((a, b) => a.id - b.id);
        this.frequencyPeriods = results.filter(x => x.name === 'Quarter1' || x.name === 'Quarter2' || x.name === 'Quarter3' || x.name === 'Quarter4');
        this.isDataAvailable();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private isDataAvailable() {
    if (this.applications && this.frequencyPeriods)
      this._spinner.hide();
  }

  captureActuals(activity) {
    this._router.navigateByUrl('businessplan-indicator/actuals/' + activity.id);
  }

  captureTargets(activity) {
    this._router.navigateByUrl('businessplan-indicator/targets/' + activity.id + '/financial-year/' + this.selectedFinancialYear.id);
  }

  public financialYearChange() {
    this._spinner.show();
    let application = this.applications.find(x => x.applicationPeriod.financialYearId === this.selectedFinancialYear.id);

    this._applicationRepo.getApplicationById(Number(application.id)).subscribe(
      (results) => {
        this.application = results;
        this.loadActivities();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
}
