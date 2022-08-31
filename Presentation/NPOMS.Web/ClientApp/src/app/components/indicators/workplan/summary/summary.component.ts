import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MegaMenuItem, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { DropdownTypeEnum, FrequencyEnum, FrequencyPeriodEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IFinancialYear, IWorkplanActual, IWorkplanIndicator, IWorkplanTarget } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import * as xlsx from 'xlsx';
import * as fileSaver from 'file-saver';

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
    private _dropdownRepo: DropdownService,
    private _datePipe: DatePipe,
    private _messageService: MessageService
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

    this.workplanIndicators.forEach(indicator => {

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
      switch (indicator.workplanTarget.frequencyId) {
        case FrequencyEnum.Annually:
          marchTarget = indicator.workplanTarget.annual;
          break;
        case FrequencyEnum.Monthly:
          aprilTarget = indicator.workplanTarget.apr;
          mayTarget = indicator.workplanTarget.may;
          juneTarget = indicator.workplanTarget.jun;
          julyTarget = indicator.workplanTarget.jul;
          augustTarget = indicator.workplanTarget.aug;
          septemberTarget = indicator.workplanTarget.sep;
          octoberTarget = indicator.workplanTarget.oct;
          novemberTarget = indicator.workplanTarget.nov;
          decemberTarget = indicator.workplanTarget.dec;
          januaryTarget = indicator.workplanTarget.jan;
          februarytarget = indicator.workplanTarget.feb;
          marchTarget = indicator.workplanTarget.mar;
          break;
        case FrequencyEnum.Quarterly:
          juneTarget = indicator.workplanTarget.quarter1;
          septemberTarget = indicator.workplanTarget.quarter2;
          decemberTarget = indicator.workplanTarget.quarter3;
          marchTarget = indicator.workplanTarget.quarter4;
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
        Frequency: indicator.workplanTarget.frequency.name,
        Activity: indicator.activity.activityList.description,
        Indicator: indicator.activity.successIndicator,
        Apr_Target: aprilTarget,
        Apr_Actual: aprilActual,
        May_Target: mayTarget,
        May_Actual: mayActual,
        Jun_Target: juneTarget,
        Jun_Actual: juneActual,
        Jul_Target: julyTarget,
        Jul_Actual: julyActual,
        Aug_Target: augustTarget,
        Aug_Actual: augustActual,
        Sep_Target: septemberTarget,
        Sep_Actual: septemberActual,
        Oct_Target: octoberTarget,
        Oct_Actual: octoberActual,
        Nov_Target: novemberTarget,
        Nov_Actual: novemberActual,
        Dec_Target: decemberTarget,
        Dec_Actual: decemberActual,
        Jan_Target: januaryTarget,
        Jan_Actual: januaryActual,
        Feb_Target: februarytarget,
        Feb_Actual: februaryActual,
        Mar_Target: marchTarget,
        Mar_Actual: marchActual
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
    this.makeRowsSameHeight();
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
