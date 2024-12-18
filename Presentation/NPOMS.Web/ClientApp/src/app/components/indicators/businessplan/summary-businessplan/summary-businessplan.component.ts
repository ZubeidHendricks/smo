import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MegaMenuItem, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ApplicationTypeEnum, FrequencyEnum, FrequencyPeriodEnum, PermissionsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IFinancialYear, IUser, IWorkplanIndicator } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Workbook } from 'exceljs';
import * as fileSaver from 'file-saver';

@Component({
  selector: 'app-summary-businessplan',
  templateUrl: './summary-businessplan.component.html',
  styleUrls: ['./summary-businessplan.component.css']
})
export class SummaryBusinessPlanComponent implements OnInit {

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
  npoId: string;

  profile: IUser;

  applications: IApplication[];
  application: IApplication;
  activities: IActivity[];

  menuActions: MegaMenuItem[];

  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  workplanIndicators: IWorkplanIndicator[];
  filteredWorkplanIndicators: IWorkplanIndicator[];

  scrollableCols: any[];
  frozenCols: any[];

  lastWorkplanTarget: boolean;
  lastWorkplanActual: boolean;

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _activeRouter: ActivatedRoute,
    private _router: Router,
    private _indicatorRepo: IndicatorService,
    private _datePipe: DatePipe,
    private _messageService: MessageService,
    private _loggerService: LoggerService,
    private _authService: AuthService
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.npoId = params.get('npoId');
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewSummaryOption))
          this._router.navigate(['401']);

        this.loadApplications();
        this.buildMenu();
      }
    });
  }

  private loadApplications() {
    this._spinner.show();
    this._applicationRepo.getApplicationsByNpoId(Number(this.npoId)).subscribe(
      (results) => {
        this.financialYears = [];
        this.applications = results.filter(x => x.applicationPeriod.applicationTypeId === ApplicationTypeEnum.QC && x.statusId === StatusEnum.Approved);

        this.applications.forEach(item => {
          var isPresent = this.financialYears.some(function (financialYear) { return financialYear === item.applicationPeriod.financialYear });
          if (!isPresent)
            this.financialYears.push(item.applicationPeriod.financialYear);
        });

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
        this.activities = results.filter(x => x.isActive === true);
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

        if (this.activities[this.activities.length - 1] === activity) {
          this.lastWorkplanTarget = true;
          this.filterWorkplanIndicators();
        }
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

        if (this.activities[this.activities.length - 1] === activity) {
          this.lastWorkplanActual = true;
          this.filterWorkplanIndicators();
        }
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

      let defaultTargetValue = 0;
      let defaultActualValue = 0;
      let defaultStatementValue = '';
      let defaultDeviationReasonValue = '';
      let defaultActionvalue = '';

      /* Targets*/
      let quarter1Target = indicator.workplanTargets.length > 0 ? indicator.workplanTargets[0].quarter1 : defaultTargetValue;
      let quarter2Target = indicator.workplanTargets.length > 0 ? indicator.workplanTargets[0].quarter2 : defaultTargetValue;
      let quarter3Target = indicator.workplanTargets.length > 0 ? indicator.workplanTargets[0].quarter3 : defaultTargetValue;
      let quarter4Target = indicator.workplanTargets.length > 0 ? indicator.workplanTargets[0].quarter4 : defaultTargetValue;
     
      /* Actuals */
      let quarter1Actual = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[0].actual : defaultActualValue;
      let quarter2Actual = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[1].actual : defaultActualValue;
      let quarter3Actual = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[2].actual : defaultActualValue;
      let quarter4Actual = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[3].actual : defaultActualValue;

      /* Statements */
      let quarter1Statement = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[0].statement : defaultStatementValue;
      let quarter2Statement = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[1].statement : defaultStatementValue;
      let quarter3Statement = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[2].statement : defaultStatementValue;
      let quarter4Statement = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[3].statement : defaultStatementValue;
      
      /* Deviation Reasons */
      let quarter1DeviationReason = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[0].deviationReason : defaultDeviationReasonValue;
      let quarter2DeviationReason = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[1].deviationReason : defaultDeviationReasonValue;
      let quarter3DeviationReason = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[2].deviationReason : defaultDeviationReasonValue;
      let quarter4DeviationReason = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[3].deviationReason : defaultDeviationReasonValue;
      
      /* Actions */
      let quarter1Action = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[0].action : defaultActionvalue;
      let quarter2Action = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[1].action : defaultActionvalue;
      let quarter3Action = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[2].action : defaultActionvalue;
      let quarter4Action = indicator.workplanActuals.length > 0 ? indicator.workplanActuals[3].action : defaultActionvalue;
     
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Quarter': 'Quarter1', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': quarter1Target, 'Actual': quarter1Actual, 'Statement': quarter1Statement, 'DeviationReason': quarter1DeviationReason, 'Action': quarter1Action });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Quarter': 'Quarter2', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': quarter2Target, 'Actual': quarter2Actual, 'Statement': quarter2Statement, 'DeviationReason': quarter2DeviationReason, 'Action': quarter2Action });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Quarter': 'Quarter3', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': quarter3Target, 'Actual': quarter3Actual, 'Statement': quarter3Statement, 'DeviationReason': quarter3DeviationReason, 'Action': quarter3Action });
      worksheet.addRow({ 'FinancialYear': this.selectedFinancialYear.name, 'Quarter': 'Quarter4', 'Activity': indicator.activity.activityList.description, 'Indicator': indicator.activity.successIndicator, 'Target': quarter4Target, 'Actual': quarter4Actual, 'Statement': quarter4Statement, 'DeviationReason': quarter4DeviationReason, 'Action': quarter4Action });
     
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
      this.application = this.applications.find(x => x.applicationPeriod.financialYearId === this.selectedFinancialYear.id);
      this.loadActivities();
    }
  }

  private filterWorkplanIndicators() {
    if (this.lastWorkplanTarget && this.lastWorkplanActual) {
      this.filteredWorkplanIndicators = [];

      this.workplanIndicators.forEach(indicator => {

        // Filter WorkplanTargets on activity, financial year and monthly frequency
        let workplanTargets = indicator.workplanTargets.filter(x => x.activityId == indicator.activity.id && x.financialYearId == this.selectedFinancialYear.id && x.frequencyId == FrequencyEnum.Quarterly);
     
        // Calculate total targets
       // let targetTotal = workplanTargets[0] ? (workplanTargets[0].apr + workplanTargets[0].may + workplanTargets[0].quarter1 + workplanTargets[0].jul + workplanTargets[0].aug + workplanTargets[0].quarter2 + workplanTargets[0].oct + workplanTargets[0].nov + workplanTargets[0].quarter3 + workplanTargets[0].jan + workplanTargets[0].feb + workplanTargets[0].quarter4) : 0;
       let targetTotal = workplanTargets[0] ? (workplanTargets[0].quarter1 + workplanTargets[0].quarter2 + workplanTargets[0].quarter3 + workplanTargets[0].quarter4) : 0;
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

        this._spinner.hide();
      }
    });
  }
}
