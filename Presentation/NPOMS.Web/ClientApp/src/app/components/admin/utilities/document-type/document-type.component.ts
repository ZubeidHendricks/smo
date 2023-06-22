import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DocumentUploadLocationsEnum, DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IDocumentType, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-document-type',
  templateUrl: './document-type.component.html',
  styleUrls: ['./document-type.component.css']
})
export class DocumentTypeComponent implements OnInit {

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

  entities: IDocumentType[];
  entity: IDocumentType = {} as IDocumentType;
  isEdit: boolean;
  isNew: boolean;
  selectedEntity: IDocumentType;
  showDialog: boolean;
  inActive: boolean;
  isCompulsory: boolean;

  locations: any[];
  selectedLocation: any;

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
      { field: 'name', header: 'Name', width: '20%' },
      { field: 'description', header: 'Description', width: '40%' },
      { field: 'location', header: 'Location', width: '10%' }
    ];

    this.locations = [
      {
        name: DocumentUploadLocationsEnum.NpoProfile,
        value: DocumentUploadLocationsEnum.NpoProfile
      },
      {
        name: DocumentUploadLocationsEnum.Workplan,
        value: DocumentUploadLocationsEnum.Workplan
      },
      {
        name: DocumentUploadLocationsEnum.WorkplanActuals,
        value: DocumentUploadLocationsEnum.WorkplanActuals
      }
    ]
  }

  private loadEntities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DocumentTypes, true).subscribe(
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
    this.entity = {} as IDocumentType;
    this.inActive = null;
    this.isCompulsory = null;
    this.showDialog = true;
  }

  edit(data: IDocumentType) {
    this.selectedEntity = data;
    this.isEdit = true;
    this.isNew = false;
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: IDocumentType): IDocumentType {
    let entity = {} as IDocumentType;

    for (let prop in data)
      entity[prop] = data[prop];

    this.inActive = !entity.isActive;
    this.isCompulsory = entity.isCompulsory;
    this.selectedLocation = this.locations.find(x => x.value === entity.location);

    return entity;
  }

  disableSave() {
    if (!this.entity.name || !this.entity.description || !this.selectedLocation)
      return true;

    return false;
  }

  save() {
    this.entity.isActive = !this.inActive;
    this.entity.isCompulsory = this.isCompulsory ? true : false;
    this.entity.location = this.selectedLocation.value;
    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownRepo.createEntity(this.entity, DropdownTypeEnum.DocumentTypes).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Document Type successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownRepo.updateEntity(this.entity, DropdownTypeEnum.DocumentTypes).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Document Type successfully updated.' });
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
