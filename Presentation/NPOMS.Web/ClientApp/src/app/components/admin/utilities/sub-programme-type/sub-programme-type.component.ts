import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IProgramme, ISubProgramme, ISubProgrammeType, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-sub-programme-type',
  templateUrl: './sub-programme-type.component.html',
  styleUrls: ['./sub-programme-type.component.css']
})
export class SubProgrammeTypeComponent implements OnInit {

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

  entities: ISubProgrammeType[];
  entity: ISubProgrammeType = {} as ISubProgrammeType;
  isEdit: boolean;
  isNew: boolean;
  selectedEntity: ISubProgrammeType;
  showDialog: boolean;
  inActive: boolean;

  programmes: IProgramme[];
  selectedProgramme: IProgramme;

  subProgrammes: ISubProgramme[];
  selectedSubProgramme: ISubProgramme;
  isSystemAdmin: boolean;

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
        this.loadProgrammes();
        this.loadSubProgrammes();
        this.loadEntities();
      }
    });

    this.cols = [
      { field: 'name', header: 'Sub-Programme Type Name', width: '20%' },
      { field: 'description', header: 'Description', width: '20%' }
    ];
  }

  private loadProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, true).subscribe(
      (results) => {
        if (this.isSystemAdmin)
          this.programmes = results;
        else
          this.programmes = results.filter(x => x.departmentId === this.profile.departments[0].id);

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSubProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, true).subscribe(
      (results) => {
        if (this.isSystemAdmin)
          this.subProgrammes = results;
        else
          this.subProgrammes = results.filter(x => x.programme.departmentId === this.profile.departments[0].id);

        this.updateSubProgramme();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadEntities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgrammeTypes, true).subscribe(
      (results) => {
        this.entities = results;

        this.updateSubProgramme();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateSubProgramme() {
    if (this.subProgrammes && this.entities) {

      this.entities.forEach(item => {
        item.subProgramme = this.subProgrammes.find(x => x.id === item.subProgrammeId);
      });

      if (!this.isSystemAdmin) {
        this.entities = this.entities.filter(x => this.subProgrammes.includes(x.subProgramme));
      }

      this.updateProgramme();
    }
  }

  private updateProgramme() {
    if (this.programmes && this.entities) {

      this.entities.forEach(item => {
        item.subProgramme.programme = this.programmes.find(x => x.id === item.subProgramme.programmeId);
      });

      if (!this.isSystemAdmin) {
        this.entities = this.entities.filter(x => this.programmes.includes(x.subProgramme.programme));
      }
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
    this.entity = {} as ISubProgrammeType;
    this.inActive = null;
    this.selectedSubProgramme = null;
    this.showDialog = true;
  }

  edit(data: ISubProgrammeType) {
    this.selectedEntity = data;
    this.isEdit = true;
    this.isNew = false;
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: ISubProgrammeType): ISubProgrammeType {
    let entity = {} as ISubProgrammeType;

    for (let prop in data)
      entity[prop] = data[prop];

    this.inActive = !entity.isActive;
    this.selectedProgramme = this.programmes.find(x => x.id === entity.subProgramme.programmeId);
    this.selectedSubProgramme = this.subProgrammes.find(x => x.id === entity.subProgrammeId);

    return entity;
  }

  disableSave() {
    if (!this.entity.name || !this.entity.description || !this.selectedSubProgramme)
      return true;

    return false;
  }

  save() {
    this.entity.isActive = !this.inActive;
    this.entity.subProgrammeId = this.selectedSubProgramme.id;
    this.entity.subProgramme = null;

    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownRepo.createEntity(this.entity, DropdownTypeEnum.SubProgrammeTypes).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Sub-Programme Type successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownRepo.updateEntity(this.entity, DropdownTypeEnum.SubProgrammeTypes).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Sub-Programme Type successfully updated.' });
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
