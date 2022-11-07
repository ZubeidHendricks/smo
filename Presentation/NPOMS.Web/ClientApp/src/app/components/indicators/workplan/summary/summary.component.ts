import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MegaMenuItem, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { DropdownTypeEnum, FrequencyEnum, FrequencyPeriodEnum, PermissionsEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IFinancialYear, IUser, IWorkplanIndicator } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import * as xlsx from 'xlsx';
import * as fileSaver from 'file-saver';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get FrequencyEnum(): typeof FrequencyEnum {
    return FrequencyEnum;
  }

  public get FrequencyPeriodEnum(): typeof FrequencyPeriodEnum {
    return FrequencyPeriodEnum;
  }

  paramSubcriptions: Subscription;
  id: string;

  profile: IUser;

  application: IApplication;
  activities: IActivity[];

  menuActions: MegaMenuItem[];

  financialYears: IFinancialYear[];
  filtererdFinancialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  workplanIndicators: IWorkplanIndicator[];
  filteredWorkplanIndicators: IWorkplanIndicator[];

  scrollableCols: any[];
  frozenCols: any[];

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _activeRouter: ActivatedRoute,
    private _router: Router,
    private _indicatorRepo: IndicatorService,
    private _dropdownRepo: DropdownService,
    private _datePipe: DatePipe,
    private _messageService: MessageService,
    private _loggerService: LoggerService,
    private _authService: AuthService
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        // if (!this.IsAuthorized(PermissionsEnum.ViewSummaryOption))
        //   this._router.navigate(['401']);

        this.loadApplication();
        this.loadFinancialYears();
        this.buildMenu();
      }
    });
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

        this.activities.forEach(activity => {
          this.workplanIndicators.push({
            activity: activity,
            workplanTargets: [],
            workplanActuals: []
          } as IWorkplanIndicator);

          this.loadTargets(activity);
          this.loadActuals(activity);
        });

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadTargets(activity: IActivity) {
    this._indicatorRepo.getTargetsByActivityId(activity.id).subscribe(
      (results) => {
        // Add WorkplanTargets to WorkplanIndicators at index of activity
        var index = this.workplanIndicators.findIndex(x => x.activity.id == activity.id);
        this.workplanIndicators[index].workplanTargets = results;

        this.populateFilteredFinancialYears();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadActuals(activity: IActivity) {
    this._indicatorRepo.getActualsByActivityId(activity.id).subscribe(
      (results) => {
        // Add WorkplanActuals to WorkplanIndicators at index of activity
        var index = this.workplanIndicators.findIndex(x => x.activity.id == activity.id);
        this.workplanIndicators[index].workplanActuals = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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

  private populateFilteredFinancialYears() {
    if (this.financialYears && this.financialYears.length > 0) {
      let financialYears = [];

      this.workplanIndicators.forEach(indicator => {
        indicator.workplanTargets.forEach(target => {
          financialYears.push(this.financialYears.find(x => x.id === target.financialYearId));
        });
      });

      this.filtererdFinancialYears = financialYears.filter((element, index) => index === financialYears.indexOf(element));
    }
  }

  private buildMenu() {

    this.menuActions = [
      {
        label: 'Export',
        icon: 'fa fa-download',
        disabled: !this.IsAuthorized(PermissionsEnum.ExportSummary),
        command: () => {
          if (this.selectedFinancialYear) {
            this._spinner.show();
            this.exportExcel();
          }
          else
            this._messageService.add({ severity: 'info', summary: 'Information', detail: 'Please select a Financial Year.' });
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

  private exportExcel() {
    const worksheet = xlsx.utils.json_to_sheet(this.exportSummary());
    const workbook = { Sheets: { 'summary': worksheet }, SheetNames: ['summary'] };
    const excelBuffer: any = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
    this.saveAsExcelFile(excelBuffer, "NPOMS_" + this.application.refNo + "_Summary");
  }

  private exportSummary() {
    let exportedWorkplanIndicators = [];

    this.filteredWorkplanIndicators.forEach(indicator => {

      let aprilTarget = null;
      let mayTarget = null;
      let juneTarget = null;
      let julyTarget = null;
      let augustTarget = null;
      let septemberTarget = null;
      let octoberTarget = null;
      let novemberTarget = null;
      let decemberTarget = null;
      let januaryTarget = null;
      let februarytarget = null;
      let marchTarget = null;

      let aprilActual = null;
      let mayActual = null;
      let juneActual = null;
      let julyActual = null;
      let augustActual = null;
      let septemberActual = null;
      let octoberActual = null;
      let novemberActual = null;
      let decemberActual = null;
      let januaryActual = null;
      let februaryActual = null;
      let marchActual = null;

      /* Get target values */
      switch (indicator.workplanTargets[0].frequencyId) {
        case FrequencyEnum.Annually:
          marchTarget = indicator.workplanTargets[0].annual;
          break;
        case FrequencyEnum.Monthly:
          aprilTarget = indicator.workplanTargets[0].apr;
          mayTarget = indicator.workplanTargets[0].may;
          juneTarget = indicator.workplanTargets[0].jun;
          julyTarget = indicator.workplanTargets[0].jul;
          augustTarget = indicator.workplanTargets[0].aug;
          septemberTarget = indicator.workplanTargets[0].sep;
          octoberTarget = indicator.workplanTargets[0].oct;
          novemberTarget = indicator.workplanTargets[0].nov;
          decemberTarget = indicator.workplanTargets[0].dec;
          januaryTarget = indicator.workplanTargets[0].jan;
          februarytarget = indicator.workplanTargets[0].feb;
          marchTarget = indicator.workplanTargets[0].mar;
          break;
        case FrequencyEnum.Quarterly:
          juneTarget = indicator.workplanTargets[0].quarter1;
          septemberTarget = indicator.workplanTargets[0].quarter2;
          decemberTarget = indicator.workplanTargets[0].quarter3;
          marchTarget = indicator.workplanTargets[0].quarter4;
          break;
      }

      /* Get actual values */
      switch (indicator.workplanActuals[0].frequencyPeriodId) {
        case FrequencyPeriodEnum.Annual:
          marchActual = indicator.workplanActuals[0].actual;
          break;
        case FrequencyPeriodEnum.Apr:
          aprilActual = indicator.workplanActuals[0].actual;
          break;
        case FrequencyPeriodEnum.May:
          mayActual = indicator.workplanActuals[1].actual;
          break;
        case FrequencyPeriodEnum.Jun:
          juneActual = indicator.workplanActuals[2].actual;
          break;
        case FrequencyPeriodEnum.Jul:
          julyActual = indicator.workplanActuals[3].actual;
          break;
        case FrequencyPeriodEnum.Aug:
          augustActual = indicator.workplanActuals[4].actual;
          break;
        case FrequencyPeriodEnum.Sep:
          septemberActual = indicator.workplanActuals[5].actual;
          break;
        case FrequencyPeriodEnum.Oct:
          octoberActual = indicator.workplanActuals[6].actual;
          break;
        case FrequencyPeriodEnum.Nov:
          novemberActual = indicator.workplanActuals[7].actual;
          break;
        case FrequencyPeriodEnum.Dec:
          decemberActual = indicator.workplanActuals[8].actual;
          break;
        case FrequencyPeriodEnum.Jan:
          januaryActual = indicator.workplanActuals[9].actual;
          break;
        case FrequencyPeriodEnum.Feb:
          februaryActual = indicator.workplanActuals[10].actual;
          break;
        case FrequencyPeriodEnum.Mar:
          marchActual = indicator.workplanActuals[11].actual;
          break;
        case FrequencyPeriodEnum.Q1:
          juneActual = indicator.workplanActuals[0].actual;
          break;
        case FrequencyPeriodEnum.Q2:
          septemberActual = indicator.workplanActuals[1].actual;
          break;
        case FrequencyPeriodEnum.Q3:
          decemberActual = indicator.workplanActuals[2].actual;
          break;
        case FrequencyPeriodEnum.Q4:
          marchActual = indicator.workplanActuals[3].actual;
          break;
      }

      exportedWorkplanIndicators.push({
        Financial_Year: this.selectedFinancialYear.name,
        Activity: indicator.activity.activityList.description,
        Indicator: indicator.activity.successIndicator,
        April_Target: aprilTarget,
        April_Actual: aprilActual,
        May_Target: mayTarget,
        May_Actual: mayActual,
        June_Target: juneTarget,
        June_Actual: juneActual,
        July_Target: julyTarget,
        July_Actual: julyActual,
        August_Target: augustTarget,
        August_Actual: augustActual,
        September_Target: septemberTarget,
        September_Actual: septemberActual,
        October_Target: octoberTarget,
        October_Actual: octoberActual,
        November_Target: novemberTarget,
        November_Actual: novemberActual,
        December_Target: decemberTarget,
        December_Actual: decemberActual,
        January_Target: januaryTarget,
        Janaury_Actual: januaryActual,
        February_Target: februarytarget,
        February_Actual: februaryActual,
        March_Target: marchTarget,
        March_Actual: marchActual,
        Total_Target: indicator.totalTargets,
        Total_Actual_YTD: indicator.totalActuals
      });
    });

    return exportedWorkplanIndicators;
  }

  private saveAsExcelFile(buffer: any, fileName: string): void {
    var today = this._datePipe.transform(new Date(), 'yyyy-MM-ddTHH:mm:ss');

    let EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    let EXCEL_EXTENSION = '.xlsx';

    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE
    });

    this._spinner.hide();
    fileSaver.saveAs(data, fileName + '_export_' + today + EXCEL_EXTENSION);
  }

  financialYearChange() {
    if (this.selectedFinancialYear) {
      this.filteredWorkplanIndicators = [];

      this.workplanIndicators.forEach(indicator => {

        // Filter WorkplanTargets on activity, financial year and monthly frequency
        let workplanTargets = indicator.workplanTargets.filter(x => x.activityId == indicator.activity.id && x.financialYearId == this.selectedFinancialYear.id && x.frequencyId == FrequencyEnum.Monthly);

        // Calculate total targets
        let targetTotal = (workplanTargets[0].apr + workplanTargets[0].may + workplanTargets[0].jun + workplanTargets[0].jul + workplanTargets[0].aug + workplanTargets[0].sep + workplanTargets[0].oct + workplanTargets[0].nov + workplanTargets[0].dec + workplanTargets[0].jan + workplanTargets[0].feb + workplanTargets[0].mar);

        // Filter WorkplanActuals on activity and financial year, then filter on WorkplanTargets.
        // This will retrieve the WorkplanActuals for all activities for the selected financial year and monthly WorkplanTargets
        let workplanActuals = indicator.workplanActuals.filter(x => x.activityId == indicator.activity.id && x.financialYearId == this.selectedFinancialYear.id);
        let filteredWorkplanActuals = workplanActuals.filter((el) => {
          return workplanTargets.some((f) => {
            return f.id === el.workplanTargetId;
          });
        });

        // Calculate total actuals
        let actualTotal = filteredWorkplanActuals.reduce((sum, object) => {
          let actual = object.actual == null ? 0 : object.actual;
          return sum + actual;
        }, 0);

        this.filteredWorkplanIndicators.push({
          activity: indicator.activity,
          workplanTargets: workplanTargets,
          workplanActuals: filteredWorkplanActuals,
          totalTargets: targetTotal,
          totalActuals: actualTotal
        } as IWorkplanIndicator);
      });

      this.makeRowsSameHeight();
    }
  }

  // Found at https://stackoverflow.com/questions/54057545/properly-use-primeng-table-with-scrollable-width-and-height-and-frozen-columns/54060117#54060117
  private makeRowsSameHeight() {
    setTimeout(() => {
      if (document.getElementsByClassName('p-datatable-scrollable-wrapper').length) {
        let wrapper = document.getElementsByClassName('p-datatable-scrollable-wrapper');

        for (var i = 0; i < wrapper.length; i++) {

          let w = wrapper.item(i) as HTMLElement;
          let frozen_rows: any = w.querySelectorAll('.p-datatable-frozen-view tr');
          let unfrozen_rows: any = w.querySelectorAll('.p-datatable-unfrozen-view tr');

          for (let i = 0; i < frozen_rows.length; i++) {

            if (frozen_rows[i].clientHeight > unfrozen_rows[i].clientHeight) {
              unfrozen_rows[i].style.height = frozen_rows[i].clientHeight + "px";
            }
            else if (frozen_rows[i].clientHeight < unfrozen_rows[i].clientHeight) {
              frozen_rows[i].style.height = unfrozen_rows[i].clientHeight + "px";
            }
          }
        }
      }
    });
  }
}
