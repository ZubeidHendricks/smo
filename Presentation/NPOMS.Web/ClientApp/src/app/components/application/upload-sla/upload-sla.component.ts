import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { Subscription } from 'rxjs';
import { ApplicationTypeEnum, DocumentTypeEnum, DocumentUploadLocationsEnum, DropdownTypeEnum, EntityEnum, EntityTypeEnum, PermissionsEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IApplicationAudit, IApplicationComment, IApplicationPeriod, IDocumentStore, IDocumentType, IObjective, IResource, ISustainabilityPlan, IUser } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-upload-sla',
  templateUrl: './upload-sla.component.html',
  styleUrls: ['./upload-sla.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class UploadSLAComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get ApplicationTypeEnum(): typeof ApplicationTypeEnum {
    return ApplicationTypeEnum;
  }

  public get ServiceProvisionStepsEnum(): typeof ServiceProvisionStepsEnum {
    return ServiceProvisionStepsEnum;
  }

  paramSubcriptions: Subscription;
  id: string;

  menuActions: MenuItem[] = [];
  profile: IUser;
  validationErrors: Message[];

  items: MenuItem[] = [];

  activeStep: number = 0;
  application: IApplication;
  isApplicationAvailable: boolean;
  isStepsAvailable: boolean;

  objectives: IObjective[] = [];
  activities: IActivity[] = [];
  sustainabilityPlans: ISustainabilityPlan[] = [];
  resources: IResource[] = [];

  documents: IDocumentStore[] = [];
  documentCols: any[];
  documentTypes: IDocumentType[];

  auditCols: any[];
  applicationAudits: IApplicationAudit[];
  displayHistory: boolean;

  applicationComments: IApplicationComment[] = [];
  commentCols: any[];
  displayAllCommentDialog: boolean;
  displayCommentDialog: boolean;
  comment: string;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _documentStore: DocumentStoreService,
    private _confirmationService: ConfirmationService,
    private _dropdownRepo: DropdownService,
    private _messageService: MessageService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
      this.loadApplication();
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.UploadSLA))
          this._router.navigate(['401']);

        this.loadDocumentTypes();
        this.buildMenu();
      }
    });

    this.documentCols = [
      { header: '', width: '5%' },
      { header: 'Document Name', width: '43%' },
      { header: 'Document Type', width: '25%' },
      { header: 'Size', width: '10%' },
      { header: 'Uploaded Date', width: '10%' },
      { header: 'Actions', width: '7%' }
    ];

    this.auditCols = [
      { header: '', width: '5%' },
      { header: 'Status', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];

    this.commentCols = [
      { header: '', width: '5%' },
      { header: 'Comment', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];
  }

  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
          this.buildSteps(results.applicationPeriod);
          this.loadObjectives();
          this.loadActivities();
          this.loadSustainabilityPlans();
          this.loadResources();
          this.isApplicationAvailable = true;
          this.getDocuments();
          this.showSave(this.application, this.menuActions);
        }

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private showSave(application: IApplication, menuActions: MenuItem[]) {
    if (application && menuActions.length > 0) {
      if (application.statusId === StatusEnum.PendingSLA)
        this.menuActions[2].visible = false;
      else
        this.menuActions[2].visible = true;
    }
  }

  private loadDocumentTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DocumentTypes, false).subscribe(
      (results) => {
        this.documentTypes = results.filter(x => x.location === DocumentUploadLocationsEnum.Workplan);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private buildSteps(applicationPeriod: IApplicationPeriod) {
    if (applicationPeriod != null) {
      if (applicationPeriod.applicationTypeId === ApplicationTypeEnum.SP) {
        this.items = [
          { label: 'Organisation Details' },
          { label: 'Objectives' },
          { label: 'Activities' },
          { label: 'Sustainability' },
          { label: 'Resourcing' },
          { label: 'Upload SLA' }
        ];
      }

      if (applicationPeriod.applicationTypeId === ApplicationTypeEnum.FA) {
        this.items = [
          { label: 'Organisation Details' }
        ];
      }

      this.isStepsAvailable = true;
    }
  }

  private loadObjectives() {
    this._applicationRepo.getAllObjectives(this.application).subscribe(
      (results) => {
        this.objectives = results.filter(x => x.isActive === true);
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

  private loadSustainabilityPlans() {
    this._applicationRepo.getAllSustainabilityPlans(this.application).subscribe(
      (results) => {
        this.sustainabilityPlans = results.filter(x => x.isActive === true);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadResources() {
    this._applicationRepo.getAllResources(this.application).subscribe(
      (results) => {
        this.resources = results.filter(x => x.isActive === true);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private buildMenu() {
    if (this.profile) {
      this.menuActions = [
        {
          label: 'Validate',
          icon: 'fa fa-check',
          command: () => {
            this.formValidate();
          },
          visible: false
        },
        {
          label: 'Clear Messages',
          icon: 'fa fa-undo',
          command: () => {
            this.clearMessages();
          },
          visible: false
        },
        {
          label: 'Save',
          icon: 'fa fa-floppy-o',
          command: () => {
            if (this.application.statusId === StatusEnum.PendingSignedSLA || this.application.statusId === StatusEnum.DeptComments) {
              this.saveItems(StatusEnum.OrgComments);
            }
            else if (this.application.statusId === StatusEnum.OrgComments) {
              this.saveItems(StatusEnum.DeptComments);
            }
          },
          title: 'Update application and send comments'
        },
        {
          label: 'Submit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            if (this.application.statusId === StatusEnum.PendingSLA || this.application.statusId === StatusEnum.OrgComments) {
              this.saveItems(StatusEnum.PendingSignedSLA);
            }
            else if (this.application.statusId === StatusEnum.PendingSignedSLA || this.application.statusId === StatusEnum.DeptComments) {
              this.saveItems(StatusEnum.AcceptedSLA);
            }
          }
        },
        {
          label: 'Go Back',
          icon: 'fa fa-step-backward',
          command: () => {
            this._router.navigateByUrl('applications');
          }
        }
      ];

      this.showSave(this.application, this.menuActions);
    }
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
  }

  public onUploadChange = (event, form) => {
    if (event.files[0].documentType) {
      this._documentStore.upload(event.files, EntityTypeEnum.SLA, Number(this.application.id), EntityEnum.Application, this.application.refNo, event.files[0].documentType.id).subscribe(
        event => {
          if (event.type === HttpEventType.UploadProgress)
            this._spinner.show();
          else if (event.type === HttpEventType.Response) {
            this._spinner.hide();
            this.getDocuments();
          }
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
      form.clear();
    }
    else {
      this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Please specify the document type.' });
    }
  }

  remove(event, file: File, uploader: FileUpload) {
    const index = uploader.files.indexOf(file);
    uploader.remove(event, index);
  }

  private getDocuments() {
    this._documentStore.get(Number(this.application.id), EntityTypeEnum.SLA).subscribe(
      res => {
        this.documents = res;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  onDownloadDocument(doc: any) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to download document?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._documentStore.download(doc).subscribe();
      },
      reject: () => {
      }
    });
  }

  onDeleteDocument(doc: any) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this document?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._spinner.show();

        this._documentStore.delete(doc.resourceId).subscribe(
          event => {
            this.getDocuments();
            this._spinner.hide();
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

  /*documentTypeChange(document: IDocumentStore, documentType: IDocumentType) {
    document.documentType = null;
    document.documentTypeId = documentType.id;

    this._documentStore.update(document).subscribe(resp => {
      this.getDocuments();
    });
  }*/

  viewAuditHistory() {
    this._applicationRepo.getApplicationAudits(this.application.id).subscribe(
      (results) => {
        this.applicationAudits = results;
        this.displayHistory = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private formValidate() {
    this.validationErrors = [];

    if (this.documents.length > 0) {
      var documentTypeNotSelected = this.documents.some(function (document) { return document.documentType === null });

      if (documentTypeNotSelected) {
        this.validationErrors.push({ severity: 'warn', summary: "Upload SLA:", detail: "Please ensure the relevant document type is selected for all documents." });
      }
      else {
        if (this.application.statusId === StatusEnum.PendingSLA || this.application.statusId === StatusEnum.OrgComments) {
          var sla = this.documents.some(function (el) { return el.documentType.id === DocumentTypeEnum.SLA });

          if (!sla)
            this.validationErrors.push({ severity: 'warn', summary: "Upload SLA:", detail: "Please upload the SLA document." });
        }

        if (this.application.statusId === StatusEnum.PendingSignedSLA || this.application.statusId === StatusEnum.DeptComments) {
          var signedSLA = this.documents.some(function (el) { return el.documentType.id === DocumentTypeEnum.SignedSLA });

          if (!signedSLA)
            this.validationErrors.push({ severity: 'warn', summary: "Upload SLA:", detail: "Please upload the signed SLA document." });
        }
      }
    }
    else
      this.validationErrors.push({ severity: 'error', summary: "Upload SLA:", detail: "Please upload the necessary documentation." });

    if (this.validationErrors.length == 0)
      this.menuActions[1].visible = false;
    else
      this.menuActions[1].visible = true;
  }

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[1].visible = false;
  }

  private saveItems(status: StatusEnum) {
    if (this.canContinue(status)) {
      this._spinner.show();
      this.application.statusId = status;

      this._applicationRepo.updateApplication(this.application).subscribe(
        (resp) => {
          this._spinner.hide();
          this._router.navigateByUrl('applications');
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private canContinue(status: StatusEnum) {
    this.validationErrors = [];

    if (status === StatusEnum.PendingSLA || status === StatusEnum.PendingSignedSLA)
      this.formValidate();

    if (this.validationErrors.length == 0)
      return true;

    return false;
  }

  viewComments() {
    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.ApplicationConfirmation,
      entityId: this.application.id
    } as IApplicationComment;

    this._applicationRepo.getApplicationComments(model).subscribe(
      (results) => {
        this.applicationComments = results;
        this.displayAllCommentDialog = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  addComment() {
    this.comment = null;
    this.displayCommentDialog = true;
  }

  disableSaveComment() {
    if (!this.comment)
      return true;

    return false;
  }

  saveComment() {
    let model = {
      applicationId: this.application.id,
      serviceProvisionStepId: ServiceProvisionStepsEnum.ApplicationConfirmation,
      entityId: this.application.id,
      comment: this.comment
    } as IApplicationComment;

    this._applicationRepo.createApplicationComment(model, false).subscribe(
      (resp) => {
        this.viewComments();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Comment successfully added.' });
        this.displayCommentDialog = false;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
}
