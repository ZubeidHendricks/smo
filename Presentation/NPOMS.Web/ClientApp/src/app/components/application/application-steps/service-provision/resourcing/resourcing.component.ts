import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DropdownTypeEnum, RoleEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IAllocationType, IApplication, IApplicationComment, IApplicationReviewerSatisfaction, IProvisionType, IResource, IResourceList, IResourceType, IServiceType } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-resourcing',
  templateUrl: './resourcing.component.html',
  styleUrls: ['./resourcing.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ResourcingComponent implements OnInit {

  public get RoleEnum(): typeof RoleEnum {
    return RoleEnum;
  }

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Output() resourceChange: EventEmitter<IResource> = new EventEmitter<IResource>();
  @Input() reviewApplication: boolean;
  @Input() canReviewOrApprove: boolean;
  @Input() canAddComments: boolean;
  @Input() isReview: boolean;

  allResources: IResource[];
  activeResources: IResource[];
  deletedResources: IResource[];

  resource: IResource = {} as IResource;
  resourceCols: any[];
  displayResourceDialog: boolean;
  newResource: boolean;

  activities: IActivity[];
  selectedActivity: IActivity;
  rowGroupMetadata: any[];

  resourceTypes: IResourceType[];
  selectedResourceType: IResourceType;
  serviceTypes: IServiceType[];
  selectedServiceType: IServiceType;
  allocationTypes: IAllocationType[];
  selectedAllocationType: IAllocationType;

  canEdit: boolean;

  displayAllCommentDialog: boolean;
  displayCommentDialog: boolean;
  comment: string;
  commentCols: any;
  applicationComments: IApplicationComment[] = [];

  tooltip: string;

  resourceList: IResourceList[];
  filteredResourceList: IResourceList[];
  selectedResource: IResourceList;

  provisionTypes: IProvisionType[];
  selectedProvisionType: IProvisionType;

  maxChars = 50;

  showReviewerSatisfaction: boolean;
  applicationReviewerSatisfaction: IApplicationReviewerSatisfaction[] = [];
  displayReviewerSatisfactionDialog: boolean;
  reviewerSatisfactionCols: any;

  displayDeletedResourceDialog: boolean;

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _confirmationService: ConfirmationService,
    private _dropdownRepo: DropdownService,
    private _messageService: MessageService,
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

    this.loadResourceTypes();
    this.loadServiceTypes();
    this.loadAllocationTypes();
    this.loadActivities();
    this.loadResources();
    this.loadResourceList();
    this.loadProvisionTypes();

    this.resourceCols = [
      { field: 'resourceType.name', header: 'Resource Type', width: '10%' },
      { field: 'serviceType.name', header: 'Service Type', width: '15%' },
      { field: 'allocationType.name', header: 'Allocation Type', width: '10%' },
      { field: 'provisionType.name', header: 'Provided vs Required', width: '12%' },
      { field: 'resourceList.name', header: 'Resource', width: '28%' },
      { field: 'numberOfResources', header: 'Number of Resources', width: '11%' }
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

  private loadResourceTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.ResourceTypes, false).subscribe(
      (results) => {
        this.resourceTypes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadServiceTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.ServiceTypes, false).subscribe(
      (results) => {
        this.serviceTypes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadAllocationTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.AllocationTypes, false).subscribe(
      (results) => {
        this.allocationTypes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadActivities() {
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.activities = results.filter(x => x.isActive === true);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadResources() {
    this._spinner.show();
    this._applicationRepo.getAllResources(this.application).subscribe(
      (results) => {
        this.allResources = results;
        this.activeResources = this.allResources.filter(x => x.isActive === true);
        this.updateRowGroupMetaData();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadResourceList() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.ResourceList, false).subscribe(
      (results) => {
        this.resourceList = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProvisionTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.ProvisionTypes, false).subscribe(
      (results) => {
        this.provisionTypes = results;
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

  nextPage() {
    this.activeStep = this.activeStep + 1;
    this.activeStepChange.emit(this.activeStep);
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  addResource() {
    this.newResource = true;
    this.resource = {} as IResource;
    this.selectedActivity = null;
    this.selectedResourceType = null;
    this.selectedServiceType = null;
    this.selectedAllocationType = null;
    this.selectedProvisionType = null;
    this.selectedResource = null;
    this.filteredResourceList = [];
    this.displayResourceDialog = true;

    if (this.application.isCloned)
      this.resource.isNew = this.resource.isNew == undefined ? true : this.resource.isNew;
  }

  editResource(data: IResource) {
    this.newResource = false;
    this.resource = this.cloneResource(data);

    if (this.application.isCloned)
      this.resource.isNew = this.resource.isNew == undefined ? false : this.resource.isNew;

    this.displayResourceDialog = true;
  }

  private cloneResource(data: IResource): IResource {
    data.name = data.resourceList.name;
    data.description = data.resourceList.description;

    let resource = {} as IResource;

    for (let prop in data)
      resource[prop] = data[prop];

    this.selectedActivity = this.activities.find(x => x.id === data.activityId);
    this.selectedResourceType = this.resourceTypes.find(x => x.id === data.resourceTypeId);
    this.selectedServiceType = this.serviceTypes.find(x => x.id === data.serviceTypeId);
    this.selectedAllocationType = this.allocationTypes.find(x => x.id === data.allocationTypeId);
    this.selectedProvisionType = this.provisionTypes.find(x => x.id === data.provisionTypeId);
    this.resourceTypeChange(this.selectedResourceType);

    return resource;
  }

  deleteResource(data: IResource) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.resource = this.cloneResource(data);
        this.resource.isActive = false;
        this.updateResource();
      },
      reject: () => {
      }
    });
  }

  disableSaveResource() {
    let data = this.resource;

    if (!this.selectedActivity || !this.selectedResourceType || !this.selectedServiceType || !this.selectedAllocationType)
      return true;

    return false;
  }

  saveResource() {
    this.resource.activity = null;
    this.resource.activityId = this.selectedActivity.id;
    this.resource.isActive = true;
    this.resource.changesRequired = this.resource.changesRequired == null ? null : false;

    this.resource.resourceTypeId = this.selectedResourceType.id;
    this.resource.serviceTypeId = this.selectedServiceType.id;
    this.resource.allocationTypeId = this.selectedAllocationType.id;
    this.resource.provisionTypeId = this.selectedProvisionType.id;

    this._dropdownRepo.createResourceList({ name: this.resource.name, description: this.resource.description, resourceTypeId: this.selectedResourceType.id, isActive: true } as IResourceList).subscribe(
      (resp) => {
        this.resource.resourceListId = resp.id;
        this.newResource ? this.createResource() : this.updateResource();
        this.loadResourceList();
        this.displayResourceDialog = false;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private createResource() {
    this._applicationRepo.createResource(this.resource, this.application).subscribe(
      (resp) => {
        this.loadResources();
        this.resourceChange.emit(this.resource);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateResource() {
    this._applicationRepo.updateResource(this.resource).subscribe(
      (resp) => {
        this.loadResources();
        this.resourceChange.emit(this.resource);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateRowGroupMetaData() {
    this.rowGroupMetadata = [];

    this.activeResources = this.activeResources.sort((a, b) => a.activityId - b.activityId);

    if (this.activeResources) {

      this.activeResources.forEach(element => {

        var itemExists = this.rowGroupMetadata.some(function (data) { return data.itemName === element.activity.activityList.description });

        this.rowGroupMetadata.push({
          itemName: element.activity.activityList.description,
          itemExists: itemExists
        });
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

  addComment() {
    this.comment = null;
    this.displayCommentDialog = true;
  }

  viewComments(data: IResource, origin: string) {
    this.resource = data;

    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Resourcing,
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
      serviceProvisionStepId: ServiceProvisionStepsEnum.Resourcing,
      entityId: this.resource.id,
      comment: this.comment
    } as IApplicationComment;

    this._applicationRepo.createApplicationComment(model, changesRequired).subscribe(
      (resp) => {
        this.loadResources();

        let entity = {
          id: model.entityId
        } as IResource;
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

  resourceTypeChange(value: IResourceType) {
    this.filteredResourceList = [];
    this.filteredResourceList = this.resourceList.filter(x => x.resourceTypeId === value.id);

    this.resource.name = null;
    this.resource.description = null;
  }

  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }

  resourceListChange(entity: IResourceList) {
    this.resource.name = entity.name;
    this.resource.description = entity.description;
  }

  viewReviewerSatisfaction(data: IResource) {
    this.resource = data;

    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.Resourcing,
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
          serviceProvisionStepId: ServiceProvisionStepsEnum.Resourcing,
          entityId: this.resource.id,
          isSatisfied: isSatisfied
        } as IApplicationReviewerSatisfaction;

        this._applicationRepo.createApplicationReviewerSatisfaction(model).subscribe(
          (resp) => {
            this.loadResources();

            let entity = {
              id: model.entityId
            } as IResource;
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

  public getColspan() {
    return this.application.isCloned && this.isReview ? 8 : 7;
  }

  public viewDeletedResources() {
    this.deletedResources = this.allResources.filter(x => x.isActive === false);
    this.displayDeletedResourceDialog = true;
  }
}
