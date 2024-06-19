import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { AccessStatusEnum, DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IAccessStatus, INpo, INpoProfile, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-npo-approval',
  templateUrl: './npo-approval.component.html',
  styleUrls: ['./npo-approval.component.css']
})
export class NpoApprovalComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get AccessStatusEnum(): typeof AccessStatusEnum {
    return AccessStatusEnum;
  }

  profile: IUser;

  npos: any[];
  accessStatuses: IAccessStatus[];
  cols: any[];

  showDialog: boolean = false;
  showOrganisationDialog: boolean = false;

  requestedBy: string;
  userName: string;
  npoName: string;
  npo: INpo;
  npoProfile: INpoProfile;
  source: string = 'workflow';

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _authService: AuthService,
    private _router: Router,
    private _spinner: NgxSpinnerService,
    private _dropdownRepo: DropdownService,
    private _npoRepo: NpoService,
    private _datepipe: DatePipe,
    private _messageService: MessageService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewNpoRequests))
          this._router.navigate(['401']);

        this.loadAccessStatuses();
        this.loadNPOs();
      }
    });

    this.cols = [
      { field: 'createdUser.fullName', header: 'Requested By', width: '10%' },
      { field: 'createdUser.email', header: 'User Name', width: '25%' },
      { field: 'name', header: 'Organisation', width: '15%' },
      { field: 'approvalStatus.name', header: 'Status', width: '10%' },
      { field: 'createdDateTime', header: 'Requested Date', width: '10%' },
      { field: 'approvalUser.fullName', header: 'Reviewed By', width: '10%' },
      { field: 'approvalDateTime', header: 'Reviewed Date', width: '10%' }
    ];
  }

  getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];

      if (col.field == 'approvalUser.fullName')
        value = value == null ? '' : value;

      if (col.field == 'createdDateTime' || col.field == 'approvalDateTime')
        value = this._datepipe.transform(value, 'yyyy-MM-dd');
    }

    return value;
  }

  private loadAccessStatuses() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.AccessStatuses, false).subscribe(
      (results) => {
        this.accessStatuses = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadNPOs() {
    this._spinner.show();
    this._npoRepo.getAllNpos(AccessStatusEnum.AllStatuses).subscribe(
      (results) => {
        this.npos = results.filter(x => x.approvalStatusId !== AccessStatusEnum.New);
        this.npos = this.npos.sort((a, b) => a.approvalStatusId - b.approvalStatusId);
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  edit(data: any) {
    this.npo = data;
    this.requestedBy = data.createdUser.fullName;
    this.userName = data.createdUser.userName;
    this.npoName = data.name;
    this.showDialog = true;
  }

  updateRequest(approvalStatusId: AccessStatusEnum) {
    this.showDialog = false;
    this.npo.approvalStatusId = approvalStatusId;

    this._npoRepo.updateNpoApprovalStatus(this.npo).subscribe(
      (resp) => {
        this.loadNPOs();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Organisation reviewed.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  viewOrganisatonDetails() {
    this.showOrganisationDialog = true;
  }
}
