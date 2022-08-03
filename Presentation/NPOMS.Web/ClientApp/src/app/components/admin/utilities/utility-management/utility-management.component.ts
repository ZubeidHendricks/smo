import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IUser, IUtility } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-utility-management',
  templateUrl: './utility-management.component.html',
  styleUrls: ['./utility-management.component.css']
})
export class UtilityManagementComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  menuActions: MenuItem[];
  profile: IUser;
  cols: any[];

  entities: IUtility[];
  entity: IUtility = {} as IUtility;
  isEdit: boolean;
  isNew: boolean;
  selectedEntity: IUtility;
  showDialog: boolean;
  inActive: boolean;
  systemAdminUtility: boolean;

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _messageService: MessageService
  ) { }

  ngOnInit(): void {
    this._spinner.show();

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewUtilities))
          this._router.navigate(['401']);

        this.loadEntities();
      }
    });

    this.cols = [
      { field: 'name', header: 'Name', width: '20%' },
      { field: 'description', header: 'Description', width: '30%' },
      { field: 'angularRedirectUrl', header: 'Redirect Url', width: '20%' }
    ];
  }

  private loadEntities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Utilities, true).subscribe(
      (results) => {
        this.entities = results;
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

  add() {
    this.isEdit = false;
    this.isNew = true;
    this.entity = {} as IUtility;
    this.inActive = null;
    this.systemAdminUtility = null;
    this.showDialog = true;
  }

  edit(data: IUtility) {
    this.selectedEntity = data;
    this.isEdit = true;
    this.isNew = false;
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: IUtility): IUtility {
    let entity = {} as IUtility;

    for (let prop in data)
      entity[prop] = data[prop];

    this.inActive = !entity.isActive;
    this.systemAdminUtility = entity.systemAdminUtility;

    return entity;
  }

  disableSave() {
    if (!this.entity.name || !this.entity.description || !this.entity.angularRedirectUrl)
      return true;

    return false;
  }

  save() {
    this.entity.isActive = !this.inActive;
    this.entity.systemAdminUtility = this.systemAdminUtility ? true : false;
    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownRepo.createEntity(this.entity, DropdownTypeEnum.Utilities).subscribe(resp => {
      this.loadEntities();
      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Utility successfully added.' });
    });
  }

  private updateEntity() {
    this._dropdownRepo.updateEntity(this.entity, DropdownTypeEnum.Utilities).subscribe(resp => {
      this.loadEntities();
      this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Utility successfully updated.' });
    });
  }

  goBack() {
    this._router.navigateByUrl('admin/utilities');
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }
}
