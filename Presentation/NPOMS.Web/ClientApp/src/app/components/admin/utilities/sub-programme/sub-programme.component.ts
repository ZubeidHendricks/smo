import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IProgramme, ISubProgramme, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-sub-programme',
  templateUrl: './sub-programme.component.html',
  styleUrls: ['./sub-programme.component.css']
})
export class SubProgrammeComponent implements OnInit {

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

  entities: ISubProgramme[];
  entity: ISubProgramme = {} as ISubProgramme;
  isEdit: boolean;
  isNew: boolean;
  selectedEntity: ISubProgramme;
  showDialog: boolean;
  inActive: boolean;

  programmes: IProgramme[];
  selectedProgramme: IProgramme;
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
        this.loadEntities();
      }
    });

    this.cols = [
      { field: 'name', header: 'Sub-Programme Name', width: '27%' },
      { field: 'description', header: 'Description', width: '27%' }
    ];
  }

  private loadProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, true).subscribe(
      (results) => {
        if (this.isSystemAdmin)
          this.programmes = results;
        else
          this.programmes = results.filter(x => x.departmentId === this.profile.departments[0].id);

        this.updateProgramme();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadEntities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, true).subscribe(
      (results) => {
        this.entities = results;

        this.updateProgramme();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateProgramme() {
    if (this.programmes && this.entities) {

      this.entities.forEach(item => {
        item.programme = this.programmes.find(x => x.id === item.programmeId);
      });

      if (!this.isSystemAdmin) {
        this.entities = this.entities.filter(x => this.programmes.includes(x.programme));
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
    this.entity = {} as ISubProgramme;
    this.inActive = null;
    this.selectedProgramme = null;
    this.showDialog = true;
  }

  edit(data: ISubProgramme) {
    this.selectedEntity = data;
    this.isEdit = true;
    this.isNew = false;
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: ISubProgramme): ISubProgramme {
    let entity = {} as ISubProgramme;

    for (let prop in data)
      entity[prop] = data[prop];

    this.inActive = !entity.isActive;
    this.selectedProgramme = this.programmes.find(x => x.id === entity.programmeId);

    return entity;
  }

  disableSave() {
    if (!this.entity.name || !this.entity.description || !this.selectedProgramme)
      return true;

    return false;
  }

  save() {
    this.entity.isActive = !this.inActive;
    this.entity.programmeId = this.selectedProgramme.id;
    this.entity.programme = null;

    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownRepo.createEntity(this.entity, DropdownTypeEnum.SubProgramme).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Sub-Programme successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownRepo.updateEntity(this.entity, DropdownTypeEnum.SubProgramme).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Sub-Programme successfully updated.' });
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
