import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { PermissionsEnum } from 'src/app/models/enums';
import { INpo, IUser, IUserNpo } from 'src/app/models/interfaces';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { UserAccessService } from 'src/app/services/api-services/user-access/user-access.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-access-request',
  templateUrl: './access-request.component.html',
  styleUrls: ['./access-request.component.css']
})
export class AccessRequestComponent implements OnInit {

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

  accessRequests: any[];
  cols: any[];

  showDialog: boolean = false;
  npos: INpo[];
  selectedNPO: INpo;

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _userAccessRepo: UserAccessService,
    private _npoRepo: NpoService,
    private _messageService: MessageService,
    private _datepipe: DatePipe,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewUserRequests))
          this._router.navigate(['401']);

        this.loadUserRequests();
      }
    });

    this.cols = [
      { field: 'npo.name', header: 'Organisation', width: '50%', type: 'object' },
      { field: 'accessStatus.name', header: 'Status', width: '15%', type: 'object' },
      { field: 'createdDateTime', header: 'Requested Date', width: '15%', type: 'string' },
      { field: 'updatedUser.fullName', header: 'Reviewed By', width: '15%', type: 'user-object' },
      { field: 'updatedDateTime', header: 'Reviewed Date', width: '15%', type: 'string' }
    ];
  }

  getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];

      if (col.field == 'updatedUser.fullName')
        value = value == null ? '' : value;

      if (col.field == 'createdDateTime' || col.field == 'updatedDateTime')
        value = this._datepipe.transform(value, 'yyyy-MM-dd');
    }

    return value;
  }

  private loadUserRequests() {
    this._spinner.show();
    this._userAccessRepo.getAllUserNpos().subscribe(
      (results) => {
        this.accessRequests = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  addUserRequest() {
    this.selectedNPO = null;
    this.showDialog = true;
  }

  disableSave() {
    if (!this.selectedNPO)
      return true;

    return false;
  }

  saveRequest() {
    this.showDialog = false;

    var mapping: IUserNpo = {
      id: 0,
      userId: this.profile.id,
      npoId: this.selectedNPO.id,
      accessStatusId: 1
    } as IUserNpo;

    this._userAccessRepo.createUserNpo(mapping).subscribe(
      (resp) => {
        this.loadUserRequests();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Access Request submitted.' });
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

  search(event) {
    let query = event.query;
    this._npoRepo.getNpoByName(query).subscribe(
      (results) => {
        this.npos = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
}
