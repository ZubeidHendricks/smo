import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MegaMenuItem } from 'primeng/api';
import { Subscription } from 'rxjs';
import { DropdownTypeEnum, FrequencyEnum, FrequencyPeriodEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IFinancialYear, IWorkplanActual, IWorkplanIndicator, IWorkplanTarget } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {

  public get FrequencyEnum(): typeof FrequencyEnum {
    return FrequencyEnum;
  }

  public get FrequencyPeriodEnum(): typeof FrequencyPeriodEnum {
    return FrequencyPeriodEnum;
  }

  paramSubcriptions: Subscription;
  id: string;

  application: IApplication;
  activities: IActivity[];

  menuActions: MegaMenuItem[];

  workplanTargets: IWorkplanTarget[];
  filteredWorkplanTarget: IWorkplanTarget;

  workplanActuals: IWorkplanActual[];
  filteredWorkplanActuals: IWorkplanActual[];

  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  workplanIndicators: IWorkplanIndicator[];

  scrollableCols: any[];
  frozenCols: any[];

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _activeRouter: ActivatedRoute,
    private _router: Router,
    private _indicatorRepo: IndicatorService,
    private _dropdownRepo: DropdownService
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
      this.loadApplication();
      this.loadFinancialYears();
    });

    this.buildMenu();
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
      (err) => this._spinner.hide()
    );
  }

  private loadActivities() {
    this._spinner.show();
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.activities = results;

        this.workplanTargets = [];
        this.workplanActuals = [];

        this.activities.forEach(activity => {
          this.loadTargets(activity.id);
          this.loadActuals(activity.id);
        });

        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private loadTargets(activityId: number) {
    this._indicatorRepo.getTargetsByActivityId(activityId).subscribe(
      (results) => {
        // Add or merge retrieved targets with already retrieved targets...
        this.workplanTargets = this.workplanTargets.concat(results);
      },
      (error) => this._spinner.hide()
    );
  }

  private loadActuals(activityId: number) {
    this._indicatorRepo.getActualsByActivityId(activityId).subscribe(
      (results) => {
        // Add or merge retrieved actuals with already retrieved actuals...
        this.workplanActuals = this.workplanActuals.concat(results);
      },
      (error) => this._spinner.hide()
    );
  }

  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        this.financialYears = results;
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private buildMenu() {
    this.menuActions = [
      {
        label: 'Export',
        icon: 'fa fa-download',
        command: () => {

        }
      },
      {
        label: 'Go Back',
        icon: 'fa fa-step-backward',
        command: () => {
          this._router.navigateByUrl('applications');
        }
      }
    ];
  }

  financialYearChange() {
    this.workplanIndicators = [];

    this.filteredWorkplanTarget = this.workplanTargets.find(x => x.financialYearId == this.selectedFinancialYear.id);
    this.filteredWorkplanActuals = this.workplanActuals.filter(x => x.financialYearId == this.selectedFinancialYear.id);

    let activity = this.activities.find(x => x.id == this.filteredWorkplanActuals[0].activityId);

    let workplanIndicator = {
      activity: activity,
      workplanTarget: this.filteredWorkplanTarget,
      workplanActuals: this.filteredWorkplanActuals
    } as IWorkplanIndicator;

    this.workplanIndicators.push(workplanIndicator);
  }
}
