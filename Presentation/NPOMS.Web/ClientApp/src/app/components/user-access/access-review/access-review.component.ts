import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IAccessStatus, IUser, IUserNpo } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { UserAccessService } from 'src/app/services/api-services/user-access/user-access.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-access-review',
  templateUrl: './access-review.component.html',
  styleUrls: ['./access-review.component.css']
})
export class AccessReviewComponent implements OnInit {

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
  accessStatuses: IAccessStatus[];
  cols: any[];

  showDialog: boolean = false;

  requestedBy: string;
  userName: string;
  npo: string;
  selectedMapping: IUserNpo;

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _dropdownRepo: DropdownService,
    private _userAccessRepo: UserAccessService,
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

        this.loadAccessStatuses();
        this.loadUserRequests();
      }
    });

    this.cols = [
      { field: 'user.fullName', header: 'Requested By', width: '10%' },
      { field: 'user.email', header: 'User Name', width: '25%' },
      { field: 'npo.name', header: 'Organisation', width: '15%' },
      { field: 'accessStatus.name', header: 'Status', width: '10%' },
      { field: 'createdDateTime', header: 'Requested Date', width: '10%' },
      { field: 'updatedUser.fullName', header: 'Reviewed By', width: '10%' },
      { field: 'updatedDateTime', header: 'Reviewed Date', width: '10%' }
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

  edit(data: any) {
    this.selectedMapping = data;
    this.requestedBy = data.createdUser.fullName;
    this.userName = data.createdUser.userName;
    this.npo = data.npo.name;
    this.showDialog = true;
  }

  approveRequest() {
    var selectedStatus = this.accessStatuses.filter(x => x.name === 'Approved');
    this.updateUserNpo(selectedStatus);
  }

  rejectRequest() {
    var selectedStatus = this.accessStatuses.filter(x => x.name === 'Rejected');
    this.updateUserNpo(selectedStatus);
  }

  private updateUserNpo(selectedStatus: any[]) {
    this.showDialog = false;

    var mapping: IUserNpo = {
      id: this.selectedMapping.id,
      userId: this.selectedMapping.userId,
      npoId: this.selectedMapping.npoId,
      accessStatusId: selectedStatus[0].id,
      createdUserId: this.selectedMapping.createdUserId,
      createdDateTime: this.selectedMapping.createdDateTime
    } as IUserNpo;

    this._userAccessRepo.updateUserNpo(mapping).subscribe(
      (resp) => {
        this.loadUserRequests();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Access Request reviewed.' });
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
}
