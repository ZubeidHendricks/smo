import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IQuestionCategory, IQuestionSection, IUser } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-question-section',
  templateUrl: './question-section.component.html',
  styleUrls: ['./question-section.component.css']
})
export class QuestionSectionComponent implements OnInit {

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

  questionCategories: IQuestionCategory[];
  filteredQuestionCategories: IQuestionCategory[];
  selectedQuestionCategory: IQuestionCategory;

  entities: IQuestionSection[];
  entity: IQuestionSection = {} as IQuestionSection;

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

        this.loadQuestionCategories();
      }
    });

    this.cols = [
      { field: 'questionCategory.name', header: 'Question Category', width: '30%' },
      { field: 'name', header: 'Name', width: '40%' },
      { field: 'sortOrder', header: 'Sort Order', width: '10%' }
    ];
  }

  private loadQuestionCategories() {
    this._dropdownService.getEntities(DropdownTypeEnum.QuestionCategory, true).subscribe(
      (results) => {
        this.questionCategories = results;
        this.filteredQuestionCategories = this.questionCategories.filter(x => x.isActive);
        this.loadEntities();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide()
      }
    );
  }

  private loadEntities() {
    this._dropdownService.getEntities(DropdownTypeEnum.QuestionSection, true).subscribe(
      (results) => {
        this.entities = results;

        this.entities.forEach(item => {
          item.questionCategory = this.questionCategories.find(x => x.id === item.questionCategoryId);
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
    this.entity = {} as IQuestionSection;
    this.inActive = null;
    this.selectedQuestionCategory = null;
    this.showDialog = true;
  }

  public edit(data: IQuestionSection) {
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: IQuestionSection): IQuestionSection {
    let object = {} as IQuestionSection;

    for (let prop in data)
      object[prop] = data[prop];

    this.inActive = !object.isActive;
    this.selectedQuestionCategory = this.questionCategories.find(x => x.id === object.questionCategoryId);

    return object;
  }

  public disableSave() {
    if (!this.entity.name || !this.selectedQuestionCategory || !this.entity.sortOrder)
      return true;

    return false;
  }

  public save() {
    this.entity.isActive = !this.inActive;
    this.entity.questionCategoryId = this.selectedQuestionCategory.id;

    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownService.createEntity(this.entity, DropdownTypeEnum.QuestionSection).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Question Section successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownService.updateEntity(this.entity, DropdownTypeEnum.QuestionSection).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Question Section successfully updated.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  delete(data: IQuestionSection) {
    let text = "Are you sure that you want to delete this?";

    if (confirm(text) == true) 
    {      
      this._dropdownService.delete(data, DropdownTypeEnum.QuestionSection).subscribe();
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
