import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Table } from 'primeng/table';
import { PermissionsEnum } from 'src/app/models/enums';
import { INpoViewModel, IUser } from 'src/app/models/interfaces';
import { FundingManagementService } from 'src/app/services/api-services/funding-management/funding-management.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-funding-capture-list',
  templateUrl: './funding-capture-list.component.html',
  styleUrls: ['./funding-capture-list.component.css']
})
export class FundingCaptureListComponent implements OnInit {

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
  cols: any[];
  entities: INpoViewModel[];

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _fundingManagementRepo: FundingManagementService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewFundingCapture))
          this._router.navigate(['401']);

        this.loadFundingCaptures();
      }
    });

    this.cols = [
      { field: 'refNo', header: 'Ref. No.', width: '10%' },
      { field: 'refNo', header: 'Financial Year', width: '10%' },
      { field: 'refNo', header: 'Programme', width: '10%' },
      { field: 'refNo', header: 'Sub-Programme Type', width: '10%' },
      { field: 'refNo', header: 'Service Delivery Area', width: '10%' },
      { field: 'refNo', header: 'Payment Frequency', width: '10%' },
      { field: 'refNo', header: 'Programme Budget', width: '10%' },
      { field: 'refNo', header: 'Amount Awarded', width: '10%' },
      { field: 'refNo', header: 'Amount Paid', width: '10%' }
    ];
  }

  private loadFundingCaptures() {
    this._spinner.show();
    this._fundingManagementRepo.getAllFundingCaptures().subscribe(
      (results) => {
        this.entities = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];
    }

    return value;
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  add(id: number) {
    this._router.navigateByUrl(`funding-capture/create/${id}`);
  }

  // edit(npo: INpo) {
  //   // this._router.navigateByUrl('npo/edit/' + npo.id);
  // }

  // view(npo: INpo) {
  //   // this._router.navigateByUrl('npo/view/' + npo.id);
  // }
}
