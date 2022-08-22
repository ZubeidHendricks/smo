import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MegaMenuItem } from 'primeng/api';
import { Subscription } from 'rxjs';
import { IActivity, IApplication } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';

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

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _activeRouter: ActivatedRoute,
    private _router: Router
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
      this.loadApplication();
    });

    this.buildMenu();

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
      (err) => this._spinner.hide()
    );
  }

  private loadActivities() {
    this._spinner.show();
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.activities = results;
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private buildMenu() {
    this.menuActions = [
      /*{
        label: 'Export',
        icon: 'fa fa-file-o',
        items: [
          [
            {
              label: 'Quarter 1',
              items: [
                { label: 'April', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(4) } },
                { label: 'May', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(5) } },
                { label: 'June', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(6) } }]
            },
            {
              label: 'Quarter 3',
              items: [
                { label: 'October', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(10) } },
                { label: 'November', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(11) } },
                { label: 'December', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(12) } }]
            }
          ],
          [
            {
              label: 'Quarter 2',
              items: [
                { label: 'July', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(7) } },
                { label: 'August', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(8) } },
                { label: 'September', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(9) } }]
            },
            {
              label: 'Quarter 4',
              items: [
                { label: 'January', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(1) } },
                { label: 'February', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(2) } },
                { label: 'March', icon: 'fa fa-file-excel-o', command: () => { this.exportExcelDetails(3) } }]
            }
          ]
        ]
      },*/
      {
        label: 'Go Back',
        icon: 'fa fa-step-backward',
        command: () => {
          this._router.navigateByUrl('applications');
        }
      }
    ];
  }

  private exportExcelDetails(month: number) {

  }

  captureActuals(activity) {
    this._router.navigateByUrl('workplan-indicator/actuals/' + activity.id);
  }

  captureTargets(activity) {
    this._router.navigateByUrl('workplan-indicator/targets/' + activity.id);
  }
}
