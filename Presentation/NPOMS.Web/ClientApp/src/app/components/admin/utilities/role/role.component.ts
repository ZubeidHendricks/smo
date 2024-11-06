import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DepartmentEnum, DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IRole, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']
})
export class RoleComponent implements OnInit {

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

  entities: IRole[];
  entity: IRole = {} as IRole;
  isEdit: boolean;
  isNew: boolean;
  selectedEntity: IRole;
  showDialog: boolean;
  inActive: boolean;

  departmentCodes: any[];
  selectedDepartmentCode: any;

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _messageService: MessageService,
    private _loggerService: LoggerService
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
      { field: 'name', header: 'Name', width: '30%' },
      { field: 'systemName', header: 'System Name', width: '25%' },
      { field: 'departmentCode', header: 'Department Code', width: '25%' }
    ];

    // Get the name of the enum
    // Found at https://stackoverflow.com/questions/18111657/how-to-get-names-of-enum-entries
    this.departmentCodes = [
      { name: DepartmentEnum[DepartmentEnum.ALL], value: DepartmentEnum[DepartmentEnum.ALL] },
      { name: DepartmentEnum[DepartmentEnum.DOH], value: DepartmentEnum[DepartmentEnum.DOH] },
      { name: DepartmentEnum[DepartmentEnum.DSD], value: DepartmentEnum[DepartmentEnum.DSD] }
    ]
  }

  private loadEntities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Roles, true).subscribe(
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

  add() {
    this.isEdit = false;
    this.isNew = true;
    this.entity = {} as IRole;
    this.inActive = null;
    this.selectedDepartmentCode = null;
    this.showDialog = true;
  }

  edit(data: IRole) {
    this.selectedEntity = data;
    this.isEdit = true;
    this.isNew = false;
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: IRole): IRole {
    let entity = {} as IRole;

    for (let prop in data)
      entity[prop] = data[prop];

    this.inActive = !entity.isActive;
    this.selectedDepartmentCode = this.departmentCodes.find(x => x.value === entity.departmentCode);

    return entity;
  }

  disableSave() {
    if (!this.entity.name || !this.entity.systemName || !this.selectedDepartmentCode)
      return true;

    return false;
  }

  save() {
    this.entity.isActive = !this.inActive;
    this.entity.departmentCode = this.selectedDepartmentCode.value;
    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownRepo.createEntity(this.entity, DropdownTypeEnum.Roles).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Role successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownRepo.updateEntity(this.entity, DropdownTypeEnum.Roles).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Role successfully updated.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  goBack() {
    this._router.navigateByUrl('admin/utilities');
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }
}
