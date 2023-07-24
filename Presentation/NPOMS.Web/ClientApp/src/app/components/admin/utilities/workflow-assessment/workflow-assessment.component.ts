import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IQuestionCategory, IQuestionSection, IUser, IWorkflowAssessment } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-workflow-assessment',
  templateUrl: './workflow-assessment.component.html',
  styleUrls: ['./workflow-assessment.component.css']
})
export class WorkflowAssessmentComponent implements OnInit {

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

  entities: IWorkflowAssessment[];
  entity: IWorkflowAssessment = {} as IWorkflowAssessment;

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
      { field: 'numberOfAssessments', header: 'Number of assessments', width: '50%' }
    ];
  }

  private loadQuestionCategories() {
    this._dropdownService.getEntities(DropdownTypeEnum.QuestionCategory, true).subscribe(
      (results) => {
        this.questionCategories = results;
        this.loadEntities();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide()
      }
    );
  }

  private loadEntities() {
    this._dropdownService.getEntities(DropdownTypeEnum.WorkflowAssessment, true).subscribe(
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
    this.entity = {} as IWorkflowAssessment;
    this.inActive = null;
    this.selectedQuestionCategory = null;

    // Only retrieve question categories where no workflow assessment is created
    // Found at https://stackoverflow.com/questions/32965688/comparing-two-arrays-of-objects-and-exclude-the-elements-who-match-values-into
    this.filteredQuestionCategories = this.questionCategories;//.filter(x => !this.entities.some(y => x.id === y.questionCategoryId) && x.isActive);

    this.showDialog = true;
  }

  public edit(data: IWorkflowAssessment) {
    this.entity = this.cloneEntity(data);
    this.filteredQuestionCategories = this.questionCategories;
    this.showDialog = true;
  }

  private cloneEntity(data: IWorkflowAssessment): IWorkflowAssessment {
    let object = {} as IWorkflowAssessment;

    for (let prop in data)
      object[prop] = data[prop];

    this.inActive = !object.isActive;
    this.selectedQuestionCategory = this.questionCategories.find(x => x.id === object.questionCategoryId);

    return object;
  }

  public disableSave() {
    if (!this.entity.numberOfAssessments || !this.selectedQuestionCategory)
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
    this._dropdownService.createEntity(this.entity, DropdownTypeEnum.WorkflowAssessment).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Workflow Assessment successfully added.' });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateEntity() {
    this._dropdownService.updateEntity(this.entity, DropdownTypeEnum.WorkflowAssessment).subscribe(
      (resp) => {
        this.loadEntities();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Workflow Assessment successfully updated.' });
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
