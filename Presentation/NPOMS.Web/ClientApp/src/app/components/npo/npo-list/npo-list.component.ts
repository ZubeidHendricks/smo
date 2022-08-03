import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Table } from 'primeng/table';
import { AccessStatusEnum, PermissionsEnum } from 'src/app/models/enums';
import { INpo, IUser } from 'src/app/models/interfaces';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-npo-list',
  templateUrl: './npo-list.component.html',
  styleUrls: ['./npo-list.component.css']
})
export class NpoListComponent implements OnInit {

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
  allNPOs: INpo[];

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _npoRepo: NpoService,
    private _spinner: NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewNpo))
          this._router.navigate(['401']);

        this.loadNPOs();
      }
    });

    this.cols = [
      { field: 'refNo', header: 'Ref. No.', width: '15%' },
      { field: 'name', header: 'Name', width: '50%' },
      { field: 'organisationType.name', header: 'Organisation Type', width: '15%' },
      { field: 'approvalStatus.name', header: 'Organisation Status', width: '10%' }
    ];
  }

  private loadNPOs() {
    this._spinner.show();
    this._npoRepo.getAllNpos(AccessStatusEnum.AllStatuses).subscribe(
      (results) => {
        this.allNPOs = results;
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
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
    this._router.navigateByUrl('npo/create');
  }

  edit(npo: INpo) {
    this._router.navigateByUrl('npo/edit/' + npo.id);
  }
}
