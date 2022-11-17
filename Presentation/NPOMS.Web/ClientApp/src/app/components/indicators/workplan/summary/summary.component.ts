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
import { LoggerService } from 'src/app/services/logger/logger.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Workbook } from 'exceljs';
import * as fileSaver from 'file-saver';

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

        if (!this.IsAuthorized(PermissionsEnum.ViewSummaryOption))
          this._router.navigate(['401']);

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
    let workbook = new Workbook();
    let worksheet = workbook.addWorksheet('Summary');

    worksheet.autoFilter = {
      from: 'A1',
      to: 'I1'
    };

    worksheet.columns = [
      { header: 'Financial Year', key: 'FinancialYear', width: 30, style: { font: { 'name': 'Calibri', size: 9 } }, alignment: { 'vertical': 'middle', 'horizontal': 'left' } },
      { header: 'Month', key: 'Month', width: 30, style: { font: { 'name': 'Calibri', size: 9 } }, alignment: { 'vertical': 'middle', 'horizontal': 'left' } },
      { header: 'Activity', key: 'Activity', width: 30, style: { font: { 'name': 'Calibri', size: 9 } }, alignment: { 'vertical': 'middle', 'horizontal': 'left' } },
      { header: 'Indicator', key: 'Indicator', width: 30, style: { font: { 'name': 'Calibri', size: 9 } }, alignment: { 'vertical': 'middle', 'horizontal': 'left' } },
      { header: 'Target', key: 'Target', width: 30, style: { font: { 'name': 'Calibri', size: 9 } }, alignment: { 'vertical': 'middle', 'horizontal': 'left' } },
      { header: 'Actual', key: 'Actual', width: 30, style: { font: { 'name': 'Calibri', size: 9 } }, alignment: { 'vertical': 'middle', 'horizontal': 'left' } },
      { header: 'Statement', key: 'Statement', width: 30, style: { font: { 'name': 'Calibri', size: 9 } }, alignment: { 'vertical': 'middle', 'horizontal': 'left' } },
      { header: 'Deviation Reason', key: 'DeviationReason', width: 30, style: { font: { 'name': 'Calibri', size: 9 } }, alignment: { 'vertical': 'middle', 'horizontal': 'left' } },
      { header: 'Action', key: 'Action', width: 30, style: { font: { 'name': 'Calibri', size: 9 } }, alignment: { 'vertical': 'middle', 'horizontal': 'left' } }
    ];

    const targetColumn = worksheet.getColumn('Target');
    targetColumn.alignment = { vertical: 'middle', horizontal: 'left' };
    const actualColumn = worksheet.getColumn('Actual');
    actualColumn.alignment = { vertical: 'middle', horizontal: 'left' };

    this.filteredWorkplanIndicators.forEach(indicator => {

      /* Targets*/
      let aprilTarget = indicator.workplanTargets[0].apr;
      let mayTarget = indicator.workplanTargets[0].may;
      let juneTarget = indicator.workplanTargets[0].jun;
      let julyTarget = indicator.workplanTargets[0].jul;
      let augustTarget = indicator.workplanTargets[0].aug;
      let septemberTarget = indicator.workplanTargets[0].sep;
      let octoberTarget = indicator.workplanTargets[0].oct;
      let novemberTarget = indicator.workplanTargets[0].nov;
      let decemberTarget = indicator.workplanTargets[0].dec;
      let januaryTarget = indicator.workplanTargets[0].jan;
      let februaryTarget = indicator.workplanTargets[0].feb;
      let marchTarget = indicator.workplanTargets[0].mar;

      /* Actuals */
      let aprilActual = indicator.workplanActuals[0].actual;
      let mayActual = indicator.workplanActuals[1].actual;
      let juneActual = indicator.workplanActuals[2].actual;
      let julyActual = indicator.workplanActuals[3].actual;
      let augustActual = indicator.workplanActuals[4].actual;
      let septemberActual = indicator.workplanActuals[5].actual;
      let octoberActual = indicator.workplanActuals[6].actual;
      let novemberActual = indicator.workplanActuals[7].actual;
      let decemberActual = indicator.workplanActuals[8].actual;
      let januaryActual = indicator.workplanActuals[9].actual;
      let februaryActual = indicator.workplanActuals[10].actual;
      let marchActual = indicator.workplanActuals[11].actual;

      /* Statements */
      let aprilStatement = indicator.workplanActuals[0].statement;
      let mayStatement = indicator.workplanActuals[1].statement;
      let juneStatement = indicator.workplanActuals[2].statement;
      let julyStatement = indicator.workplanActuals[3].statement;
      let augustStatement = indicator.workplanActuals[4].statement;
      let septemberStatement = indicator.workplanActuals[5].statement;
      let octoberStatement = indicator.workplanActuals[6].statement;
      let novemberStatement = indicator.workplanActuals[7].statement;
      let decemberStatement = indicator.workplanActuals[8].statement;
      let januaryStatement = indicator.workplanActuals[9].statement;
      let februaryStatement = indicator.workplanActuals[10].statement;
      let marchStatement = indicator.workplanActuals[11].statement;

      /* Deviation Reasons */
      let aprilDeviationReason = indicator.workplanActuals[0].deviationReason;
      let mayDeviationReason = indicator.workplanActuals[1].deviationReason;
      let juneDeviationReason = indicator.workplanActuals[2].deviationReason;
      let julyDeviationReason = indicator.workplanActuals[3].deviationReason;
      let augustDeviationReason = indicator.workplanActuals[4].deviationReason;
      let septemberDeviationReason = indicator.workplanActuals[5].deviationReason;
      let octoberDeviationReason = indicator.workplanActuals[6].deviationReason;
      let novemberDeviationReason = indicator.workplanActuals[7].deviationReason;
      let decemberDeviationReason = indicator.workplanActuals[8].deviationReason;
      let januaryDeviationReason = indicator.workplanActuals[9].deviationReason;
      let februaryDeviationReason = indicator.workplanActuals[10].deviationReason;
      let marchDeviationReason = indicator.workplanActuals[11].deviationReason;

      /* Actions */
      let aprilAction = indicator.workplanActuals[0].action;
      let mayAction = indicator.workplanActuals[1].action;
      let juneAction = indicator.workplanActuals[2].action;
      let julyAction = indicator.workplanActuals[3].action;
      let augustAction = indicator.workplanActuals[4].action;
      let septemberAction = indicator.workplanActuals[5].action;
      let octoberAction = indicator.workplanActuals[6].action;
      let novemberAction = indicator.workplanActuals[7].action;
      let decemberAction = indicator.workplanActuals[8].action;
      let januaryAction = indicator.workplanActuals[9].action;
      let februaryAction = indicator.workplanActuals[10].action;
      let marchAction = indicator.workplanActuals[11].action;

      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'April', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': aprilTarget, 'Actual': aprilActual, 'Statement': aprilStatement, 'DeviationReason': aprilDeviationReason, 'Action': aprilAction });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'May', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': mayTarget, 'Actual': mayActual, 'Statement': mayStatement, 'DeviationReason': mayDeviationReason, 'Action': mayAction });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'June', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': juneTarget, 'Actual': juneActual, 'Statement': juneStatement, 'DeviationReason': juneDeviationReason, 'Action': juneAction });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'July', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': julyTarget, 'Actual': julyActual, 'Statement': julyStatement, 'DeviationReason': julyDeviationReason, 'Action': julyAction });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'August', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': augustTarget, 'Actual': augustActual, 'Statement': augustStatement, 'DeviationReason': augustDeviationReason, 'Action': augustAction });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'September', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': septemberTarget, 'Actual': septemberActual, 'Statement': septemberStatement, 'DeviationReason': septemberDeviationReason, 'Action': septemberAction });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'October', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': octoberTarget, 'Actual': octoberActual, 'Statement': octoberStatement, 'DeviationReason': octoberDeviationReason, 'Action': octoberAction });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'November', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': novemberTarget, 'Actual': novemberActual, 'Statement': novemberStatement, 'DeviationReason': novemberDeviationReason, 'Action': novemberAction });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'December', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': decemberTarget, 'Actual': decemberActual, 'Statement': decemberStatement, 'DeviationReason': decemberDeviationReason, 'Action': decemberAction });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'January', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': januaryTarget, 'Actual': januaryActual, 'Statement': januaryStatement, 'DeviationReason': januaryDeviationReason, 'Action': januaryAction });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'February', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': februaryTarget, 'Actual': februaryActual, 'Statement': februaryStatement, 'DeviationReason': februaryDeviationReason, 'Action': februaryAction });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Month': 'March', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': marchTarget, 'Actual': marchActual, 'Statement': marchStatement, 'DeviationReason': marchDeviationReason, 'Action': marchAction });

      worksheet.getRow(1).fill = {
        type: 'pattern',
        pattern: 'solid',
        fgColor: { argb: 'D3D3D3' }
      };
    });

    workbook.xlsx.writeBuffer().then((data) => {
      var today = this._datePipe.transform(new Date(), 'yyyy-MM-ddTHH:mm:ss');
      this._spinner.hide();
      let blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      fileSaver.saveAs(blob, this.application.refNo + '_SummaryExport_' + today + '.xlsx');
    });
  }

  financialYearChange() {
    if (this.selectedFinancialYear) {
      this.filteredWorkplanIndicators = [];

      this.workplanIndicators.forEach(indicator => {

        // Filter WorkplanTargets on activity, financial year and monthly frequency
        let workplanTargets = indicator.workplanTargets.filter(x => x.activityId == indicator.activity.id && x.financialYearId == this.selectedFinancialYear.id && x.frequencyId == FrequencyEnum.Monthly);

        // Calculate total targets
        let targetTotal = workplanTargets[0] ? (workplanTargets[0].apr + workplanTargets[0].may + workplanTargets[0].jun + workplanTargets[0].jul + workplanTargets[0].aug + workplanTargets[0].sep + workplanTargets[0].oct + workplanTargets[0].nov + workplanTargets[0].dec + workplanTargets[0].jan + workplanTargets[0].feb + workplanTargets[0].mar) : 0;

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
