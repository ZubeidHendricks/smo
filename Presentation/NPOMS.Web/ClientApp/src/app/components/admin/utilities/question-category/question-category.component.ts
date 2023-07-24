import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IFundingTemplateType, IQuestionCategory, IUser } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-question-category',
  templateUrl: './question-category.component.html',
  styleUrls: ['./question-category.component.css']
})
export class QuestionCategoryComponent implements OnInit {

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

  fundingTemplateTypes: IFundingTemplateType[];
  filteredFundingTemplateTypes: IFundingTemplateType[];
  selectedFundingTemplateType: IFundingTemplateType;

  entities: IQuestionCategory[];
  entity: IQuestionCategory = {} as IQuestionCategory;

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

        this.loadFundingTemplateTypes();
      }
    });

    this.cols = [
      { field: 'fundingTemplateType.name', header: 'Funding Template Type', width: '30%' },
      { field: 'name', header: 'Name', width: '50%' }
    ];
  }

  private loadFundingTemplateTypes() {
    this._dropdownService.getEntities(DropdownTypeEnum.FundingTemplateType, true).subscribe(
      (results) => {
        this.fundingTemplateTypes = results;
        this.filteredFundingTemplateTypes = this.fundingTemplateTypes.filter(x => x.isActive);
        this.loadEntities();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide()
      }
    );
  }

  private loadEntities() {
    this._dropdownService.getEntities(DropdownTypeEnum.QuestionCategory, true).subscribe(
      (results) => {
        this.entities = results;

        this.entities.forEach(item => {
          item.fundingTemplateType = this.fundingTemplateTypes.find(x => x.id === item.fundingTemplateTypeId);
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
    this.entity = {} as IQuestionCategory;
    this.inActive = null;
    this.selectedFundingTemplateType = null;
    this.showDialog = true;
  }

  public edit(data: IQuestionCategory) {
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: IQuestionCategory): IQuestionCategory {
    let object = {} as IQuestionCategory;

    for (let prop in data)
      object[prop] = data[prop];

    this.inActive = !object.isActive;
    this.selectedFundingTemplateType = this.fundingTemplateTypes.find(x => x.id === object.fundingTemplateTypeId);

    return object;
  }

  public disableSave() {
    if (!this.entity.name || !this.selectedFundingTemplateType)
      return true;

    return false;
  }

  public save() {
    this.entity.isActive = !this.inActive;
    this.entity.fundingTemplateTypeId = this.selectedFundingTemplateType.id;

    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownService.createEntity(this.entity, DropdownTypeEnum.QuestionCategory).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Question Category successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownService.updateEntity(this.entity, DropdownTypeEnum.QuestionCategory).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Question Category successfully updated.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public goBack() {
    this._router.navigateByUrl('admin/utilities');
  }

  get isSystemAdmin() {
    return this.profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
  }
}
