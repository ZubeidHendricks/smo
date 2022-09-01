import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IFacilityDistrict, IFacilitySubDistrict, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-facility-sub-district',
  templateUrl: './facility-sub-district.component.html',
  styleUrls: ['./facility-sub-district.component.css']
})
export class FacilitySubDistrictComponent implements OnInit {

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

  entities: IFacilitySubDistrict[];
  entity: IFacilitySubDistrict = {} as IFacilitySubDistrict;
  isEdit: boolean;
  isNew: boolean;
  selectedEntity: IFacilitySubDistrict;
  showDialog: boolean;
  inActive: boolean;

  facilityDistricts: IFacilityDistrict[];
  selectedFacilityDistrict: IFacilityDistrict;

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

        this.loadFacilityDistricts();
        this.loadEntities();
      }
    });

    this.cols = [
      { field: 'name', header: 'Name', width: '50%' }
    ];
  }

  private loadFacilityDistricts() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilityDistricts, false).subscribe(
      (results) => {
        this.facilityDistricts = results;
        this.updateFacilityDistrict();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadEntities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilitySubDistricts, true).subscribe(
      (results) => {
        this.entities = results;
        this.updateFacilityDistrict();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateFacilityDistrict() {
    if (this.facilityDistricts && this.entities) {
      this.entities.forEach(item => {
        item.facilityDistrict = this.facilityDistricts.find(x => x.id === item.facilityDistrictId);
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
    this.entity = {} as IFacilitySubDistrict;
    this.inActive = null;
    this.selectedFacilityDistrict = null;
    this.showDialog = true;
  }

  edit(data: IFacilitySubDistrict) {
    this.selectedEntity = data;
    this.isEdit = true;
    this.isNew = false;
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: IFacilitySubDistrict): IFacilitySubDistrict {
    let entity = {} as IFacilitySubDistrict;

    for (let prop in data)
      entity[prop] = data[prop];

    this.inActive = !entity.isActive;
    this.selectedFacilityDistrict = this.facilityDistricts.find(x => x.id === entity.facilityDistrictId);

    return entity;
  }

  disableSave() {
    if (!this.selectedFacilityDistrict || !this.entity.name)
      return true;

    return false;
  }

  save() {
    this.entity.isActive = !this.inActive;
    this.entity.facilityDistrictId = this.selectedFacilityDistrict.id;
    this.entity.facilityDistrict = null;

    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownRepo.createEntity(this.entity, DropdownTypeEnum.FacilitySubDistricts).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Facility Sub-District successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownRepo.updateEntity(this.entity, DropdownTypeEnum.FacilitySubDistricts).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Facility Sub-District successfully updated.' });
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
