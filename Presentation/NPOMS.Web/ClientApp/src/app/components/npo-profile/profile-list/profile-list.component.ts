import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Table } from 'primeng/table';
import { AccessStatusEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { INpo, INpoProfile, IUser } from 'src/app/models/interfaces';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-profile-list',
  templateUrl: './profile-list.component.html',
  styleUrls: ['./profile-list.component.css']
})
export class ProfileListComponent implements OnInit {

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
  allProfiles: INpoProfile[];
  allNpos: INpo[];
  selectedNPO: INpo;

  displayDialog: boolean;
  isSystemAdmin: boolean = true;
  isAdmin: boolean = false;
  hasAdminRole: boolean = false;

  hideAddButton: boolean = true;

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _npoProfileRepo: NpoProfileService,
    private _spinner: NgxSpinnerService,
    private _npoRepo: NpoService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewNpoProfiles))
          this._router.navigate(['401']);

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.isAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.Admin });

        if (this.isSystemAdmin || this.isAdmin)
          this.hasAdminRole = true;

        this.loadNpos();
        this.loadNpoProfiles();
      }
    });

    this.cols = [
      { field: 'refNo', header: 'Ref. No.', width: '15%' },
      { field: 'npo.name', header: 'Organisation', width: '40%' },
      { field: 'npo.organisationType.name', header: 'Organisation Type', width: '12%' },
      { field: 'npo.approvalStatus.name', header: 'Organisation Status', width: '13%' },
      { field: 'npo.yearRegistered', header: 'Year Registered', width: '10%' }
    ];
  }

  private loadNpos() {
    this._spinner.show();
    this._npoRepo.getAllNpos(AccessStatusEnum.AllStatuses).subscribe(
      (results) => {
        this.allNpos = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadNpoProfiles() {
    this._spinner.show();
    this._npoProfileRepo.getAllNpoProfiles().subscribe(
      (results) => {
        this.allProfiles = results;
        if (!this.hasAdminRole) {
          if (this.profile.userNpos.length != this.allProfiles.length)
            this.hideAddButton = false;
        }
        else {
          this.hideAddButton = false;
        }

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

  add() {
    this.selectedNPO = null;
    this.displayDialog = true;
  }

  disableSelect() {
    if (!this.selectedNPO)
      return true;

    return false;
  }

  selectNPO() {
    this.displayDialog = false;
    this._router.navigateByUrl('npo-profile/create/' + this.selectedNPO.id);
  }

  edit(profile: INpoProfile) {
    this._router.navigateByUrl('npo-profile/edit/' + profile.id);
  }

  view(profile: INpoProfile) {
    this._router.navigateByUrl('npo-profile/view/' + profile.id);
  }
}
