import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { DropdownTypeEnum, PermissionsEnum, QuestionCategoryEnum, ResponseTypeEnum } from 'src/app/models/enums';
import { IQuestion, IQuestionProperty, IQuestionSection, IResponseType, IUser } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

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

  public get ResponseTypeEnum(): typeof ResponseTypeEnum {
    return ResponseTypeEnum;
  }

  public get QuestionCategoryEnum(): typeof QuestionCategoryEnum {
    return QuestionCategoryEnum;
  }

  profile: IUser;
  cols: any[];

  questionSections: IQuestionSection[];
  filteredQuestionSections: IQuestionSection[];
  selectedQuestionSection: IQuestionSection;

  responseTypes: IResponseType[];
  filteredResponseTypes: IResponseType[];
  selectedResponseType: IResponseType;

  entities: IQuestion[];
  entity: IQuestion = {} as IQuestion;

  isNew: boolean;
  showDialog: boolean;
  inActive: boolean;

  stateOptions: any[];

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

        this.loadQuestionSections();
      }
    });

    this.cols = [
      { field: 'questionSection.name', header: 'Question Section', width: '12%' },
      { field: 'responseType.name', header: 'Response Type', width: '12%' },
      { field: 'name', header: 'Name', width: '40%' },
      { field: 'questionProperty.weighting', header: 'Weighting', width: '8%' },
      { field: 'sortOrder', header: 'Sort Order', width: '8%' }
    ];

    this.stateOptions = [
      { label: 'Yes', value: true },
      { label: 'No', value: false }
    ];
  }

  private loadQuestionSections() {
    this._dropdownService.getEntities(DropdownTypeEnum.QuestionSection, true).subscribe(
      (results) => {
        this.questionSections = results;
        this.filteredQuestionSections = this.questionSections.filter(x => x.isActive);
        this.loadResponseTypes();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide()
      }
    );
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
    this._dropdownService.getEntities(DropdownTypeEnum.Question, true).subscribe(
      (results) => {
        this.entities = results;

        this.entities.forEach(item => {
          item.questionSection = this.questionSections.find(x => x.id === item.questionSectionId);
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

    if (row.responseTypeId !== ResponseTypeEnum.Score && col.field === "questionProperty.weighting") {
      return null;
    }

    return value;
  }

  public add() {
    this.entity = {
      questionProperty: {
        hasComment: false,
        commentRequired: false,
        hasDocument: false,
        documentRequired: false,
        weighting: 0
      } as IQuestionProperty
    } as IQuestion;
    this.inActive = null;
    this.selectedQuestionSection = null;
    this.selectedResponseType = null;
    this.showDialog = true;
  }

  public edit(data: IQuestion) {
    this.entity = this.cloneEntity(data);
    this.showDialog = true;
  }

  private cloneEntity(data: IQuestion): IQuestion {
    let object = {} as IQuestion;

    for (let prop in data)
      object[prop] = data[prop];

    this.inActive = !object.isActive;
    this.selectedQuestionSection = this.questionSections.find(x => x.id === object.questionSectionId);
    this.selectedResponseType = this.responseTypes.find(x => x.id === object.responseTypeId);

    return object;
  }

  public disableSave() {
    if (!this.entity.name || !this.selectedQuestionSection || !this.selectedResponseType || !this.entity.sortOrder)
      return true;

    return false;
  }

  public save() {
    this.entity.isActive = !this.inActive;
    this.entity.questionSectionId = this.selectedQuestionSection.id;
    this.entity.responseTypeId = this.selectedResponseType.id;

    this.entity.questionProperty.commentRequired = this.entity.questionProperty.hasComment ? this.entity.questionProperty.commentRequired : false;
    this.entity.questionProperty.documentRequired = this.entity.questionProperty.hasDocument ? this.entity.questionProperty.documentRequired : false;

    this.isNew ? this.createEntity() : this.updateEntity();
    this.showDialog = false;
  }

  private createEntity() {
    this._dropdownService.createEntity(this.entity, DropdownTypeEnum.Question).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Question successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownService.updateEntity(this.entity, DropdownTypeEnum.Question).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Question successfully updated.' });
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

  public hasWeighting(questionCategoryId: QuestionCategoryEnum) {
    let questions = this.entities.filter(x => x.questionSection.questionCategoryId === questionCategoryId);
    return questions.some(function (item) { return item.responseTypeId === ResponseTypeEnum.Score });
  }

  public getQuestions(questionCategoryId: QuestionCategoryEnum) {
    return this.entities.filter(x => x.questionSection.questionCategoryId === questionCategoryId);
  }

  public getWeightingTotal(questionCategoryId: QuestionCategoryEnum) {
    let totalWeighting = 0;

    let questions = this.entities.filter(x => x.questionSection.questionCategoryId === questionCategoryId);
    questions.forEach(item => {
      totalWeighting += item.questionProperty.weighting;
    });

    return totalWeighting;
  }
}
