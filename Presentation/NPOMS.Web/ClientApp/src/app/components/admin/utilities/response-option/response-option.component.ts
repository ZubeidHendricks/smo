import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IResponseOption, IResponseType, IUser } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-response-option',
  templateUrl: './response-option.component.html',
  styleUrls: ['./response-option.component.css']
})
export class ResponseOptionComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }

    return false;
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  profile: IUser;
  cols: any[];

  responseTypes: IResponseType[];
  filteredResponseTypes: IResponseType[];
  selectedResponseType: IResponseType;

  entities: IResponseOption[];
  entity: IResponseOption = {} as IResponseOption;

  isNew: boolean;
  showDialog: boolean;
  inActive: boolean;

  constructor(
    private _router: Router,
    private _dropdownService: DropdownService,
    private _spinner: NgxSpinnerService,
    private _authService: AuthService,
    private _messageService: MessageService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this._spinner.show();
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewUtilities))
          this._router.navigate(['401']);

        this.loadResponseTypes();
      }
    });

    this.cols = [
      { field: 'responseType.name', header: 'Response Type', width: '15%' },
      { field: 'name', header: 'Response Option', width: '50%' },
      { field: 'systemName', header: 'System Name', width: '15%' }
    ];
  }

  private loadResponseTypes() {
    this._dropdownService.getEntities(DropdownTypeEnum.ResponseType, true).subscribe(
      (results) => {
        this.responseTypes = results;
        this.filteredResponseTypes = this.responseTypes.filter(x => x.isActive);
        this.loadEntities();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide()
      }
    );
  }

  private loadEntities() {
    this._dropdownService.getEntities(DropdownTypeEnum.ResponseOption, true).subscribe(
      (results) => {
        this.entities = results;

        this.entities.forEach(item => {
          item.responseType = this.responseTypes.find(x => x.id === item.responseTypeId);
        });

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide()
      }
    );
  }

  public getCellData(row: any, col: any): any {
    const nestedProperties: string[] = col.field.split('.');
    let value: any = row;

    for (const prop of nestedProperties) {
      value = value[prop];
    }

    return value;
  }

  public add() {
    this.entity = {} as IResponseOption;
    this.inActive = null;
    this.selectedResponseType = null;
    this.showDialog = true;
  }

  public edit(data: IResponseOption) {
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: IResponseOption): IResponseOption {
    let object = {} as IResponseOption;

    for (let prop in data)
      object[prop] = data[prop];

    this.inActive = !object.isActive;
    this.selectedResponseType = this.responseTypes.find(x => x.id === object.responseTypeId);

    return object;
  }

  public disableSave() {
    if (!this.entity.name || !this.selectedResponseType)
      return true;

    return false;
  }

  public save() {
    this.entity.isActive = !this.inActive;
    this.entity.responseTypeId = this.selectedResponseType.id;

    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownService.createEntity(this.entity, DropdownTypeEnum.ResponseOption).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Response Option successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownService.updateEntity(this.entity, DropdownTypeEnum.ResponseOption).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Response Option successfully updated.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  delete(data: IResponseOption) {
    let text = "Are you sure that you want to delete this?";

    if (confirm(text) == true) 
    {      
      this._dropdownService.delete(data, DropdownTypeEnum.ResponseOption).subscribe();
      this.loadEntities();
    } 
    else 
    {
      return false;
    }
  }

  public goBack() {
    this._router.navigateByUrl('admin/utilities');
  }
}
