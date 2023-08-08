import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IDepartment, IDirectorate, IProgramme, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-programme',
  templateUrl: './programme.component.html',
  styleUrls: ['./programme.component.css']
})
export class ProgrammeComponent implements OnInit {

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

  entities: IProgramme[];
  entity: IProgramme = {} as IProgramme;
  isEdit: boolean;
  isNew: boolean;
  selectedEntity: IProgramme;
  showDialog: boolean;
  inActive: boolean;

  isSystemAdmin: boolean;
  departments: IDepartment[];
  selectedDepartment: IDepartment;

  directorates: IDirectorate[];
  selectedDirectorate: IDirectorate;

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

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.loadDepartments();
        this.loadDirectorates();
        this.loadEntities();
      }
    });

    this.cols = [
      { field: 'name', header: 'Programme Name', width: '15%' },
      { field: 'description', header: 'Programme Description', width: '25%' }
    ];
  }

  private loadDepartments() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Departments, true).subscribe(
      (results) => {
        this.departments = results;
        this.updateObjects();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadDirectorates() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Directorates, true).subscribe(
      (results) => {
        this.directorates = results;
        this.updateObjects();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadEntities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, true).subscribe(
      (results) => {
        if (this.isSystemAdmin) {
          this.entities = results;
          this.updateObjects();
        }
        else
          this.entities = results.filter(x => this.profile.departments[0].id === x.departmentId);

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  // Update the department and directorate for each programme
  private updateObjects() {
    if (this.departments && this.entities && this.directorates) {
      this.entities.forEach(item => {
        item.department = this.departments.find(x => x.id === item.departmentId);
        item.directorate = this.directorates.find(x => x.id === item.directorateId);
      });
    }
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
    this.entity = {} as IProgramme;
    this.inActive = null;
    this.selectedDepartment = null;
    this.selectedDirectorate = null;
    this.showDialog = true;
  }

  edit(data: IProgramme) {
    this.selectedEntity = data;
    this.isEdit = true;
    this.isNew = false;
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: IProgramme): IProgramme {
    let entity = {} as IProgramme;

    for (let prop in data)
      entity[prop] = data[prop];

    this.inActive = !entity.isActive;
    this.selectedDepartment = this.departments.find(x => x.id === entity.departmentId);
    this.selectedDirectorate = this.directorates.find(x => x.id === entity.directorateId);

    return entity;
  }

  disableSave() {
    if (!this.selectedDirectorate || !this.entity.name || !this.entity.description)
      return true;

    if (this.isSystemAdmin && !this.selectedDepartment)
      return true;

    return false;
  }

  save() {
    this.entity.isActive = !this.inActive;

    if (this.isSystemAdmin) {
      this.entity.departmentId = this.selectedDepartment.id;
      this.entity.department = null;
    }
    else
      this.entity.departmentId = this.profile.departments[0].id;

    this.entity.directorateId = this.selectedDirectorate.id;
    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownRepo.createEntity(this.entity, DropdownTypeEnum.Programmes).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Programme successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownRepo.updateEntity(this.entity, DropdownTypeEnum.Programmes).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Programme successfully updated.' });
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
