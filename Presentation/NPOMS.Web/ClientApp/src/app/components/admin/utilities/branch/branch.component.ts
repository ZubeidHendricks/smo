import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IBank, IBranch, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-branch',
  templateUrl: './branch.component.html',
  styleUrls: ['./branch.component.css']
})
export class BranchComponent implements OnInit {

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

  entities: IBranch[];
  entity: IBranch = {} as IBranch;
  isEdit: boolean;
  isNew: boolean;
  selectedEntity: IBranch;
  showDialog: boolean;
  inActive: boolean;

  banks: IBank[];
  selectedBank: IBank;

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

        this.loadBanks();
      }
    });

    this.cols = [
      { field: 'name', header: 'Name', width: '40%' },
      { field: 'branchCode', header: 'Branch Code', width: '10%' },
      { field: 'bank.name', header: 'Bank', width: '30%' }
    ];
  }

  private loadBanks() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Banks, true).subscribe(
      (results) => {
        this.banks = results;
        this.loadEntities();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadEntities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Branches, true).subscribe(
      (results) => {
        this.entities = results;
        this.updateBankObject();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateBankObject() {
    this.entities.forEach(item => {
      item.bank = this.banks.find(x => x.id === item.bankId);
    });
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
    this.entity = {} as IBranch;
    this.selectedBank = null;
    this.inActive = null;
    this.showDialog = true;
  }

  edit(data: IBranch) {
    this.selectedEntity = data;
    this.isEdit = true;
    this.isNew = false;
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: IBranch): IBranch {
    let entity = {} as IBranch;

    for (let prop in data)
      entity[prop] = data[prop];

    this.selectedBank = entity.bank;
    this.inActive = !entity.isActive;

    return entity;
  }

  disableSave() {
    if (!this.entity.name || !this.selectedBank)
      return true;

    return false;
  }

  save() {
    this.entity.bankId = this.selectedBank.id;
    this.entity.isActive = !this.inActive;
    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownRepo.createEntity(this.entity, DropdownTypeEnum.Branches).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Branch successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownRepo.updateEntity(this.entity, DropdownTypeEnum.Branches).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Branch successfully updated.' });
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
