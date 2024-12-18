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
  selector: 'app-manage',
  templateUrl: './manage.component.html',
  styleUrls: ['./manage.component.css']
})
export class ManageComponent implements OnInit {

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
        this.applications = results.filter(x => x.applicationPeriod.applicationTypeId === ApplicationTypeEnum.SP && x.statusId === StatusEnum.AcceptedSLA);

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
        this.frequencyPeriods = results;
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
    this._router.navigateByUrl('workplan-indicator/actuals/' + activity.id);
  }

  captureTargets(activity) {
    this._router.navigateByUrl('workplan-indicator/targets/' + activity.id + '/financial-year/' + this.selectedFinancialYear.id);
  }

  public financialYearChange() {
    this._spinner.show();
    const application = this.applications.find(x => x.applicationPeriod.financialYearId === this.selectedFinancialYear.id);
    this._applicationRepo.getApplicationById(Number(application.id)).subscribe(
        (results) => {
            this.application = results;
            if (this.application) {
                this.loadActivities();
            }
        },
        (err) => {
            console.error('Error fetching application:', err);
            this._loggerService.logException(err);
            this._spinner.hide();
        },
        () => {
            this._spinner.hide();
        }
    );
}

private loadActivities() {
    this._applicationRepo.getAllActivities(this.application).subscribe(
        (results) => {
            this.activities = results.filter(x => x.isActive === true);
            this.workplanIndicators = this.activities.map(item => ({
                activity: item,
                workplanTargets: [],
                workplanActuals: []
            } as IWorkplanIndicator));
            this._spinner.hide();
        },
        (err) => {
            console.error('Failed to load activities:', err);
            this._loggerService.logException(err);
            this._spinner.hide();
        }
    );
}
}
