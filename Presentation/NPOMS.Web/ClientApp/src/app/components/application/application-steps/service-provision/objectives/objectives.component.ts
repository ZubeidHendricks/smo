import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DropdownTypeEnum, RecipientTypeEnum, RoleEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IApplicationComment, IApplicationReviewerSatisfaction, IDepartment, IObjective, IObjectiveProgramme, IProgramme, IRecipientType, ISubProgramme, ISubRecipient, ISubSubRecipient } from 'src/app/models/interfaces';
import { ApplicationPeriodService } from 'src/app/services/api-services/application-period/application-period.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-objectives',
  templateUrl: './objectives.component.html',
  styleUrls: ['./objectives.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ObjectivesComponent implements OnInit {

  public get RoleEnum(): typeof RoleEnum {
    return RoleEnum;
  }

  public get RecipientTypeEnum(): typeof RecipientTypeEnum {
    return RecipientTypeEnum;
  }

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Output() objectiveChange: EventEmitter<IObjective> = new EventEmitter<IObjective>();
  @Input() canAddComments: boolean;
  @Input() isReview: boolean;
  @Input() currentUserId: number;

  allObjectives: IObjective[];
  activeObjectives: IObjective[];
  deletedObjectives: IObjective[];

  objectiveCols: any[];
  displayObjectiveDialog: boolean;
  newObjective: boolean;
  objective: IObjective = {} as IObjective;

  recipientTypes: IRecipientType[];
  selectedRecipientType: IRecipientType;

  yearRange: string;

  allProgrammes: IProgramme[];
  programmes: IProgramme[] = [];
  selectedProgrammes: IProgramme[];
  allSubProgrammes: ISubProgramme[];
  subProgrammes: ISubProgramme[] = [];
  selectedSubProgrammes: ISubProgramme[];

  canEdit: boolean;
  selectedProgrammesText: string;
  selectedSubProgrammesText: string;

  displayAllCommentDialog: boolean;
  displayCommentDialog: boolean;
  comment: string;
  commentCols: any;
  applicationComments: IApplicationComment[] = [];

  tooltip: string;
  maxChars = 50;

  showReviewerSatisfaction: boolean;
  applicationReviewerSatisfaction: IApplicationReviewerSatisfaction[] = [];
  displayReviewerSatisfactionDialog: boolean;
  reviewerSatisfactionCols: any;

  displayDeletedObjectiveDialog: boolean;

  displayRecipientDialog: boolean;
  newRecipient: boolean;
  subRecipient: ISubRecipient = {} as ISubRecipient;
  subSubRecipient: ISubSubRecipient = {} as ISubSubRecipient;
  selectedSubRecipientType: IRecipientType;
  selectedSubRecipient: ISubRecipient;

  subRecipientToEdit: ISubRecipient;
  subSubRecipientToEdit: ISubSubRecipient;

  rowGroupMetadata: any[];

  constructor(
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private _applicationRepo: ApplicationService,
    private _datepipe: DatePipe,
    private _applicationPeriodRepo: ApplicationPeriodService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._spinner.show();

    this.canEdit = (this.application.statusId === StatusEnum.PendingReview ||
      this.application.statusId === StatusEnum.PendingApproval ||
      this.application.statusId === StatusEnum.ApprovalInProgress ||
      this.application.statusId === StatusEnum.PendingSLA ||
      this.application.statusId === StatusEnum.PendingSignedSLA ||
      this.application.statusId === StatusEnum.DeptComments ||
      this.application.statusId === StatusEnum.OrgComments)
      ? false : true;

    this.showReviewerSatisfaction = this.application.statusId === StatusEnum.PendingReview ? true : false;
    this.tooltip = this.canEdit ? 'Edit' : 'View';

    this.loadAllProgrammes();
    this.loadAllSubProgrammes();
    this.loadRecipientTypes();
    this.loadObjectives();
    this.setYearRange();

    this.objectiveCols = [
      { header: 'Objective Name', width: '20%' },
      { header: 'Funding Source', width: '15%' },
      { header: 'Funding Period', width: '18%' },
      { header: 'Recipient Type', width: '15%' },
      { header: 'Budget', width: '15%' }
    ];

    this.commentCols = [
      { header: '', width: '5%' },
      { header: 'Comment', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];

    this.reviewerSatisfactionCols = [
      { header: '', width: '5%' },
      { header: 'Is Satisfied', width: '25%' },
      { header: 'Created User', width: '35%' },
      { header: 'Created Date', width: '35%' }
    ];
  }

  private loadApplicationPeriod() {
    this._applicationPeriodRepo.getApplicationPeriodById(Number(this.application.applicationPeriodId)).subscribe(
      (results) => {
        this.loadProgrammesForDepartment(results.department);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadAllProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
      (results) => {
        this.allProgrammes = results;
        this.loadApplicationPeriod();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProgrammesForDepartment(department: IDepartment) {
    this.programmes = [];
    this.subProgrammes = [];

    if (department.id != null) {
      for (var i = 0; i < this.allProgrammes.length; i++) {
        if (this.allProgrammes[i].departmentId == department.id) {
          this.programmes.push(this.allProgrammes[i]);
        }
      }
    }
  }

  private loadAllSubProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
      (results) => {
        this.allSubProgrammes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadRecipientTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.RecipientTypes, false).subscribe(
      (results) => {
        this.recipientTypes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadObjectives() {
    this._spinner.show();
    this._applicationRepo.getAllObjectives(this.application).subscribe(
      (results) => {
        this.allObjectives = results;
        this.activeObjectives = this.allObjectives.filter(x => x.isActive === true);
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public GetDifference(isNew: boolean) {
    switch (isNew) {
      case undefined:
        return '';
      case true:
        return 'New';
      case false:
        return 'Changed';
    }
  }

  private setYearRange() {
    let currentDate = new Date;
    let startYear = currentDate.getFullYear() - 5;
    let endYear = currentDate.getFullYear() + 5;

    this.yearRange = `${startYear}:${endYear}`;
  }

  nextPage() {
    if (this.activeObjectives.length > 0) {
      this.activeStep = this.activeStep + 1;
      this.activeStepChange.emit(this.activeStep);
    }
    else
      this._messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Objective table cannot be empty.' });
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  addObjective() {
    this.newObjective = true;
    this.objective = {
      objectiveProgrammes: [] as IObjectiveProgramme[],
      subRecipients: [] as ISubRecipient[]
    } as IObjective;

    this.updateRowGroupMetaData(this.objective);

    this.selectedProgrammes = [];
    this.subProgrammes = [];
    this.selectedSubProgrammes = [];
    this.selectedRecipientType = null;
    this.displayObjectiveDialog = true;

    if (this.application.isCloned)
      this.objective.isNew = this.objective.isNew == undefined ? true : this.objective.isNew;
  }

  editObjective(data: IObjective) {
    this.newObjective = false;
    this.objective = this.cloneObjective(data);

    this.updateRowGroupMetaData(this.objective);

    if (this.application.isCloned)
      this.objective.isNew = this.objective.isNew == undefined ? false : this.objective.isNew;

    this.displayObjectiveDialog = true;
  }

  private updateRowGroupMetaData(objective: IObjective) {
    this.rowGroupMetadata = [];

    if (objective.subRecipients) {

      objective.subRecipients.forEach(element => {

        var itemExists = this.rowGroupMetadata.some(function (data) { return data.itemName === element.organisationName });

        this.rowGroupMetadata.push({
          itemName: element.organisationName,
          itemExists: itemExists
        });
      });
    }
  }

  private cloneObjective(data: IObjective): IObjective {
    let obj = {} as IObjective;

    for (let prop in data)
      obj[prop] = data[prop];

    this.selectedRecipientType = data.recipientType;

    const programmeIds = data.objectiveProgrammes.map(({ programmeId }) => programmeId);
    this.selectedProgrammes = this.programmes.filter(item => programmeIds.includes(item.id));
    this.programmeChange(this.selectedProgrammes);

    const subProgrammeIds = data.objectiveProgrammes.map(({ subProgrammeId }) => subProgrammeId);
    this.selectedSubProgrammes = this.subProgrammes.filter(item => subProgrammeIds.includes(item.id));

    this.getTextValues();

    data.subRecipients.forEach(sr => {
      sr.recipientType = this.recipientTypes.find(x => x.id === sr.recipientTypeId);

      sr.subSubRecipients.forEach(ssr => {
        ssr.recipientType = this.recipientTypes.find(x => x.id === ssr.recipientTypeId);
      });
    });

    return obj;
  }

  getTextValues() {
    let allProgrammes: string = "";
    let allSubProgrammes: string = "";

    this.selectedProgrammes.forEach(item => {
      allProgrammes += item.name + ", ";
    });

    this.selectedSubProgrammes.forEach(item => {
      allSubProgrammes += item.name + ", ";
    });

    this.selectedProgrammesText = allProgrammes.slice(0, -2);
    this.selectedSubProgrammesText = allSubProgrammes.slice(0, -2);
  }

  deleteObjective(data: IObjective) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.objective = this.cloneObjective(data);
        this.objective.isActive = false;
        this.updateObjective();
      },
      reject: () => {
      }
    });
  }

  disableSaveObjective() {
    let data = this.objective;

    if (!data.name || !data.description || !data.fundingSource || this.selectedProgrammes.length === 0 || this.selectedSubProgrammes.length === 0 || !this.selectedRecipientType || !data.fundingPeriodStartDate || !data.fundingPeriodEndDate || !data.budget)
      return true;

    return false;
  }

  saveObjective() {
    this.objective.recipientType = null;
    this.objective.recipientTypeId = this.selectedRecipientType.id;
    this.objective.isActive = true;
    this.objective.changesRequired = this.objective.changesRequired == null ? null : false;

    this.objective.fundingPeriodStartDate = this._datepipe.transform(this.objective.fundingPeriodStartDate, 'yyyy-MM-dd');
    this.objective.fundingPeriodEndDate = this._datepipe.transform(this.objective.fundingPeriodEndDate, 'yyyy-MM-dd');

    this.objective.objectiveProgrammes = [];
    this.selectedSubProgrammes.forEach(item => {
      let objectiveProgramme = {
        objectiveId: this.objective.id,
        programmeId: item.programmeId,
        subProgrammeId: item.id,
        isActive: true
      } as IObjectiveProgramme;

      this.objective.objectiveProgrammes.push(objectiveProgramme);
    });

    this.objective.subRecipients.forEach(sr => {
      sr.recipientType = null;
      sr.subSubRecipients.forEach(ssr => {
        ssr.recipientType = null;
      });
    });

    this.newObjective ? this.createObjective() : this.updateObjective();
    this.displayObjectiveDialog = false;
  }

  private createObjective() {
    this._applicationRepo.createObjective(this.objective, this.application).subscribe(
      (resp) => {
        this.loadObjectives();
        this.objectiveChange.emit(this.objective);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateObjective() {
    this._applicationRepo.updateObjective(this.objective).subscribe(
      (resp) => {
        this.loadObjectives();
        this.objectiveChange.emit(this.objective);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  programmeChange(programmes: IProgramme[]) {
    this.subProgrammes = [];

    programmes.forEach(item => {
      if (item.id != null) {
        for (var i = 0; i < this.allSubProgrammes.length; i++) {
          if (this.allSubProgrammes[i].programmeId == item.id) {
            this.subProgrammes.push(this.allSubProgrammes[i]);
          }
        }
      }
    });
  }

  disableSubProgramme(): boolean {
    if (this.subProgrammes.length > 0)
      return false;

    return true;
  }

  addComment() {
    this.comment = null;
    this.displayCommentDialog = true;
  }

  viewComments(data: IObjective, origin: string) {
    this.objective = data;

    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Objectives,
      entityId: data.id
    } as IApplicationComment;

    this._applicationRepo.getApplicationComments(model).subscribe(
      (results) => {
        this.applicationComments = results;

        if (origin === 'allComments')
          this.displayAllCommentDialog = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  disableSaveComment() {
    if (!this.comment)
      return true;

    return false;
  }

  saveComment(changesRequired: boolean, origin: string) {
    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Objectives,
      entityId: this.objective.id,
      comment: this.comment
    } as IApplicationComment;

    this._applicationRepo.createApplicationComment(model, changesRequired).subscribe(
      (resp) => {
        this.loadObjectives();

        let entity = {
          id: model.entityId
        } as IObjective;
        this.viewComments(entity, origin);

        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Comment successfully added.' });
        this.displayCommentDialog = false;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  viewReviewerSatisfaction(data: IObjective) {
    this.objective = data;

    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Objectives,
      entityId: data.id
    } as IApplicationReviewerSatisfaction;

    this._applicationRepo.getApplicationReviewerSatisfactions(model).subscribe(
      (results) => {
        this.applicationReviewerSatisfaction = results;
        this.displayReviewerSatisfactionDialog = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  createReviewerSatisfaction(isSatisfied: boolean) {
    this._confirmationService.confirm({
      message: 'Are you sure that you selected the correct option?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {

        let model = {
          applicationId: this.application.id,
          serviceProvisionStepId: ServiceProvisionStepsEnum.Objectives,
          entityId: this.objective.id,
          isSatisfied: isSatisfied
        } as IApplicationReviewerSatisfaction;

        this._applicationRepo.createApplicationReviewerSatisfaction(model).subscribe(
          (resp) => {
            this.loadObjectives();

            let entity = {
              id: model.entityId
            } as IObjective;
            this.viewReviewerSatisfaction(entity);

            this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Item successfully added.' });
            this.displayReviewerSatisfactionDialog = false;
          },
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
          }
        );
      },
      reject: () => {
      }
    });
  }

  public viewDeletedObjectives() {
    this.deletedObjectives = this.allObjectives.filter(x => x.isActive === false);
    this.displayDeletedObjectiveDialog = true;
  }

  public getFilteredRecipientTypes(recipientType: RecipientTypeEnum) {
    if (this.recipientTypes)
      return recipientType === RecipientTypeEnum.Primary ? this.recipientTypes.filter(x => x.id === recipientType) : this.recipientTypes.filter(x => x.id !== RecipientTypeEnum.Primary);
  }

  public addRecipient() {
    this.newRecipient = true;
    this.selectedSubRecipientType = null;
    this.displayRecipientDialog = true;
  }

  public disableSaveRecipient(recipientType: IRecipientType) {
    if (recipientType.id === RecipientTypeEnum.SubRecipient) {
      let data = this.subRecipient;

      if (!data.organisationName || !data.fundingPeriodStartDate || !data.fundingPeriodEndDate || !data.budget)
        return true;
    }

    if (recipientType.id === RecipientTypeEnum.SubSubRecipient) {
      let data = this.subSubRecipient;

      if (!data.organisationName || !data.fundingPeriodStartDate || !data.fundingPeriodEndDate || !data.budget || !this.selectedSubRecipient)
        return true;
    }

    return false;
  }

  public saveRecipient(recipientType: IRecipientType) {
    if (recipientType.id === RecipientTypeEnum.SubRecipient) {
      this.subRecipient.recipientType = this.selectedSubRecipientType;
      this.subRecipient.recipientTypeId = this.selectedSubRecipientType.id;
      this.subRecipient.isActive = true;

      this.subRecipient.fundingPeriodStartDate = this._datepipe.transform(this.subRecipient.fundingPeriodStartDate, 'yyyy-MM-dd');
      this.subRecipient.fundingPeriodEndDate = this._datepipe.transform(this.subRecipient.fundingPeriodEndDate, 'yyyy-MM-dd');

      this.newRecipient ? this.createSR() : this.updateSR();
      this.updateRowGroupMetaData(this.objective);
    }

    if (recipientType.id === RecipientTypeEnum.SubSubRecipient) {
      this.subSubRecipient.recipientType = this.selectedSubRecipientType;
      this.subSubRecipient.recipientTypeId = this.selectedSubRecipientType.id;
      this.subSubRecipient.isActive = true;

      this.subSubRecipient.fundingPeriodStartDate = this._datepipe.transform(this.subSubRecipient.fundingPeriodStartDate, 'yyyy-MM-dd');
      this.subSubRecipient.fundingPeriodEndDate = this._datepipe.transform(this.subSubRecipient.fundingPeriodEndDate, 'yyyy-MM-dd');

      this.newRecipient ? this.createSSR() : this.updateSSR();
      this.updateRowGroupMetaData(this.objective);
    }

    this.displayRecipientDialog = false;
  }

  private createSR() {
    this.subRecipient.subSubRecipients = [];
    this.subRecipient.createdUserId = this.currentUserId;
    this.subRecipient.createdDateTime = this.getCurrentDateTime();
    this.objective.subRecipients.push(this.subRecipient);
  }

  private updateSR() {
    this.subRecipient.updatedUserId = this.currentUserId;
    this.subRecipient.updatedDateTime = this.getCurrentDateTime();
    this.objective.subRecipients[this.objective.subRecipients.indexOf(this.subRecipientToEdit)] = this.subRecipient;
  }

  private createSSR() {
    this.subSubRecipient.createdUserId = this.currentUserId;
    this.subSubRecipient.createdDateTime = this.getCurrentDateTime();

    let subRecipientDetail = this.objective.subRecipients.find(x => x.organisationName === this.selectedSubRecipient.organisationName);
    subRecipientDetail.subSubRecipients.push(this.subSubRecipient);
  }

  private updateSSR() {
    this.subSubRecipient.updatedUserId = this.currentUserId;
    this.subSubRecipient.updatedDateTime = this.getCurrentDateTime();

    let subRecipient = this.objective.subRecipients[this.objective.subRecipients.indexOf(this.subRecipientToEdit)];
    subRecipient.subSubRecipients[subRecipient.subSubRecipients.indexOf(this.subSubRecipientToEdit)] = this.subSubRecipient;
  }

  public editSR(subRecipient: ISubRecipient) {
    this.newRecipient = false;
    this.subRecipientToEdit = subRecipient;
    this.subRecipient = this.cloneSubRecipient(subRecipient);
    this.displayRecipientDialog = true;
  }

  private cloneSubRecipient(data: ISubRecipient): ISubRecipient {
    let obj = {} as ISubRecipient;

    for (let prop in data)
      obj[prop] = data[prop];

    this.selectedSubRecipientType = this.recipientTypes.find(x => x.id === data.recipientTypeId);

    return obj;
  }

  public deleteSR(subRecipient: ISubRecipient) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        subRecipient.isActive = false;
        subRecipient.updatedUserId = this.currentUserId;
        subRecipient.updatedDateTime = this.getCurrentDateTime();
      },
      reject: () => {
      }
    });
  }

  public editSSR(ssr: ISubSubRecipient, subRecipient: ISubRecipient) {
    this.newRecipient = false;
    this.subRecipientToEdit = subRecipient;
    this.subSubRecipientToEdit = ssr;
    this.subSubRecipient = this.cloneSubSubRecipient(ssr, subRecipient);
    this.displayRecipientDialog = true;
  }

  private cloneSubSubRecipient(data: ISubSubRecipient, subRecipient: ISubRecipient): ISubSubRecipient {
    let obj = {} as ISubSubRecipient;

    for (let prop in data)
      obj[prop] = data[prop];

    this.selectedSubRecipientType = this.recipientTypes.find(x => x.id === data.recipientTypeId);
    this.selectedSubRecipient = this.objective.subRecipients.find(x => x.organisationName === subRecipient.organisationName);

    return obj;
  }

  public deleteSSR(ssr: ISubSubRecipient) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        ssr.isActive = false;
        ssr.updatedUserId = this.currentUserId;
        ssr.updatedDateTime = this.getCurrentDateTime();
      },
      reject: () => {
      }
    });
  }

  private getCurrentDateTime() {
    let today = new Date();
    let nextTwoHours = today.getHours() + 2;
    today.setHours(nextTwoHours);
    return today;
  }

  public recipientTypeChange() {
    if (this.selectedSubRecipientType.id === RecipientTypeEnum.SubRecipient)
      this.subRecipient = {} as ISubRecipient;

    if (this.selectedSubRecipientType.id === RecipientTypeEnum.SubSubRecipient) {
      this.subSubRecipient = {} as ISubSubRecipient;
      this.selectedSubRecipient = null;
    }
  }

  public getActiveSRs(objective: IObjective) {
    return objective && objective.subRecipients && objective.subRecipients.length > 0 ? this.objective.subRecipients.filter(x => x.isActive) : [];
  }

  public getActiveSSRs(subSubRecipients: ISubSubRecipient[]) {
    return subSubRecipients.filter(x => x.isActive);
  }

  public subRecipientChange(subRecipient: ISubRecipient) {
    this.subSubRecipient.subRecipientId = this.objective.subRecipients.find(x => x.organisationName === subRecipient.organisationName).id;
  }

  public reviewAllItems() {

    this._confirmationService.confirm({
      message: 'Are you sure you are satisfied with the details contained in all the Objectives?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {

        this.activeObjectives.forEach(item => {
          let model = {
            applicationId: this.application.id,
            serviceProvisionStepId: ServiceProvisionStepsEnum.Objectives,
            entityId: item.id,
            isSatisfied: true
          } as IApplicationReviewerSatisfaction;

          let lastObjectInArray = this.activeObjectives[this.activeObjectives.length - 1];

          this._applicationRepo.createApplicationReviewerSatisfaction(model).subscribe(
            (resp) => {

              if (item === lastObjectInArray) {
                this.loadObjectives();
                this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Reviewer Satisfaction completed for all objectives.' });
              }
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        });
      },
      reject: () => {
      }
    });
  }
}
