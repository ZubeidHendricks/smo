import { HttpEventType } from '@angular/common/http';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DocumentUploadLocationsEnum, DropdownTypeEnum, EntityEnum, EntityTypeEnum, FrequencyPeriodEnum, PermissionsEnum, StatusEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IDocumentType, IFinancialYear, IFrequencyPeriod, IStatus, IUser, IWorkplanActual, IWorkplanActualAudit, IWorkplanComment, IWorkplanIndicator } from 'src/app/models/interfaces';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-actuals',
  templateUrl: './actuals.component.html',
  styleUrls: ['./actuals.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ActualsComponent implements OnInit {

  @Input() application: IApplication;

  private _workplanIndicators: IWorkplanIndicator[];
  @Input()
  get workplanIndicators(): IWorkplanIndicator[] { return this._workplanIndicators; }
  set workplanIndicators(workplanIndicators: IWorkplanIndicator[]) { this._workplanIndicators = workplanIndicators; this.getTargetsAndActuals(); }

  private _financialYears: IFinancialYear[];
  @Input()
  get financialYears(): IFinancialYear[] { return this._financialYears; }
  set financialYears(financialYears: IFinancialYear[]) { this._financialYears = financialYears; }

  private _frequencyPeriods: IFrequencyPeriod[];
  @Input()
  get frequencyPeriods(): IFrequencyPeriod[] { return this._frequencyPeriods; }
  set frequencyPeriods(frequencyPeriods: IFrequencyPeriod[]) { this._frequencyPeriods = frequencyPeriods; }

  private _selectedFinancialYear: IFinancialYear;
  @Input()
  get selectedFinancialYear(): IFinancialYear { return this._selectedFinancialYear; }
  set selectedFinancialYear(selectedFinancialYear: IFinancialYear) { this._selectedFinancialYear = selectedFinancialYear; this.financialYearChange(); }

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get FrequencyPeriodEnum(): typeof FrequencyPeriodEnum {
    return FrequencyPeriodEnum;
  }

  public get StatusEnum(): typeof StatusEnum {
    return StatusEnum;
  }

  profile: IUser;

  cols: any[];
  documentCols: any[];
  buttonItems: MenuItem[];

  selectedFrequencyPeriod: IFrequencyPeriod;

  filteredWorkplanIndicators: IWorkplanIndicator[];

  workplanActual = {} as IWorkplanActual;

  documentTypes: IDocumentType[] = [];

  // If a previous/past financial year is selected, disable all inputs
  isPreviousFinancialYear: boolean;

  // Document upload element
  @ViewChild('addDoc') element: ElementRef;

  displayUploadedFilesDialog: boolean;
  displayAllCommentDialog: boolean;
  displayCommentDialog: boolean;

  // This is the selected indicator when clicking on option buttons...
  selectedIndicator: IWorkplanIndicator;

  workplanComments: IWorkplanComment[];
  commentCols: any[];
  comment: string;

  statuses: IStatus[];
  auditCols: any[];

  workplanActualAudits: IWorkplanActualAudit[];
  displayHistory: boolean;

  allFinancialYears: IFinancialYear[];

  constructor(
    private _spinner: NgxSpinnerService,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _indicatorRepo: IndicatorService,
    private _messageService: MessageService,
    private _documentStore: DocumentStoreService,
    private _confirmationService: ConfirmationService,
    private _loggerService: LoggerService,
    private _router: Router
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewManageIndicatorsOption))
          this._router.navigate(['401']);

        this.loadAllFinancialYears();
        this.loadDocumentTypes();
        this.loadStatuses();
        this.buildButtonItems();
      }
    });

    this.cols = [
      { header: '', width: '5%' },
      { header: 'Activity', width: '16%' },
      { header: 'Indicator', width: '10%' },
      { header: 'Target', width: '5%' },
      { header: 'Actual', width: '5%' },
      { header: 'Statement', width: '14%' },
      { header: 'Deviation Reason', width: '14%' },
      { header: 'Action', width: '14%' },
      { header: 'Evidence', width: '6%' },
      { header: 'Status', width: '6%' },
      { header: 'Actions', width: '5%' }
    ];

    this.documentCols = [
      { header: '', width: '5%' },
      { header: 'Document Name', width: '60%' },
      { header: 'Size', width: '10%' },
      { header: 'Uploaded Date', width: '15%' },
      { header: 'Actions', width: '10%' }
    ];

    this.commentCols = [
      { header: '', width: '5%' },
      { header: 'Comment', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];

    this.auditCols = [
      { header: '', width: '5%' },
      { header: 'Status', width: '55%' },
      { header: 'Created User', width: '20%' },
      { header: 'Created Date', width: '20%' }
    ];
  }

  private getTargetsAndActuals() {
    if (this._workplanIndicators) {
      this._workplanIndicators.forEach(indicator => {
        this.loadTargets(indicator.activity);
        this.loadActuals(indicator.activity);
      });
    }
  }

  private loadTargets(activity: IActivity) {
    this._indicatorRepo.getTargetsByActivityId(activity.id).subscribe(
      (results) => {
        var index = this.workplanIndicators.findIndex(x => x.activity.id == activity.id);
        this.workplanIndicators[index].workplanTargets = results;
      },
      (err) => {
        this._loggerService.logException(err);
      }
    );
  }

  private loadActuals(activity: IActivity) {
    this._indicatorRepo.getActualsByActivityId(activity.id).subscribe(
      (results) => {
        var index = this.workplanIndicators.findIndex(x => x.activity.id == activity.id);
        this.workplanIndicators[index].workplanActuals = results;
      },
      (err) => {
        this._loggerService.logException(err);
      }
    );
  }

  private loadAllFinancialYears() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, true).subscribe(
      (results) => {
        this.allFinancialYears = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadDocumentTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DocumentTypes, false).subscribe(
      (results) => {
        this.documentTypes = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadStatuses() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Statuses, false).subscribe(
      (results) => {
        this.statuses = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private buildButtonItems() {
    this.buttonItems = [];

    if (this.profile) {

      this.buttonItems = [{
        label: 'Options',
        items: []
      }];

      if (this.IsAuthorized(PermissionsEnum.CaptureWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Save Actual',
          icon: 'fa fa-floppy-o',
          command: () => {
            this.updateIndicator(this.selectedIndicator, StatusEnum.Saved);
          }
        });

        this.buttonItems[0].items.push({
          label: 'Submit Actual',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.updateIndicator(this.selectedIndicator, StatusEnum.PendingReview);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ReviewWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Verify Actual',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.updateIndicator(this.selectedIndicator, StatusEnum.PendingApproval);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Approve Actual',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.updateIndicator(this.selectedIndicator, StatusEnum.Approved);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ReviewWorkplanActual) || this.IsAuthorized(PermissionsEnum.ApproveWorkplanActual)) {
        this.buttonItems[0].items.push({
          label: 'Amendments Required',
          icon: 'fa fa-hand-o-left',
          command: () => {
            this.updateIndicator(this.selectedIndicator, StatusEnum.AmendmentsRequired);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewManageIndicatorsOption)) {
        this.buttonItems[0].items.push({
          label: 'Comments',
          icon: 'fa fa-comments-o',
          command: () => {
            this.viewComments(this.selectedIndicator);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewManageIndicatorsOption)) {
        this.buttonItems[0].items.push({
          label: 'View History',
          icon: 'fa fa-history',
          command: () => {
            this.viewAuditHistory(this.selectedIndicator);
          }
        });
      }
    }
  }

  private updateIndicator(workplanIndicator: IWorkplanIndicator, status: number) {
    // Only 1 WorkplanActual will be updated at a time
    this.updateWorkplanActual(workplanIndicator.workplanActuals[0], status);
  }

  private updateWorkplanActual(workplanActual: IWorkplanActual, status: number) {
    this._spinner.show();

    if (workplanActual && status) {
      if (this.canContinue(workplanActual)) {

        workplanActual.statusId = status;

        this._indicatorRepo.updateActual(workplanActual).subscribe(
          (resp) => {
            this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully updated.' });
            this.getFilteredWorkplanIndicators();
          },
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
          }
        );
      }
    }
    else {
      this._spinner.hide();
      this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Target not captured.' });
    }
  }

  private canContinue(workplanActual: IWorkplanActual) {

    if (workplanActual.actual) {
      return true;
    }

    this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Actual not captured.' });
    return false;
  }

  private viewComments(workplanIndicator: IWorkplanIndicator) {
    this._spinner.show();
    this._indicatorRepo.getWorkplanComments(workplanIndicator.workplanActuals[0].id).subscribe(
      (results) => {
        this.workplanComments = results;
        this._spinner.hide();
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
      workplanActualId: this.selectedIndicator.workplanActuals[0].id,
      comment: this.comment
    } as IWorkplanComment;

    this._indicatorRepo.createWorkplanComment(model).subscribe(
      (resp) => {
        this.viewComments(this.selectedIndicator);

        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Comment successfully added.' });
        this.displayCommentDialog = false;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private viewAuditHistory(workplanIndicator: IWorkplanIndicator) {
    this._spinner.show();
    this._indicatorRepo.getWorkplanActualAudits(workplanIndicator.workplanActuals[0].id).subscribe(
      (results) => {
        this.workplanActualAudits = results;
        this._spinner.hide();
        this.displayHistory = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private getDocuments(workplanActual: IWorkplanActual) {
    this._documentStore.get(Number(workplanActual.id), EntityTypeEnum.WorkplanActuals).subscribe(
      (resp) => {
        workplanActual.documents = resp;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private financialYearChange() {
    this.selectedFrequencyPeriod = null;
    
    if (this.selectedFinancialYear) {
      this.getFilteredWorkplanIndicators();

      /*let currentDate = new Date();

      let currentFinancialYear = this.allFinancialYears.find(x => new Date(x.startDate) <= currentDate && new Date(x.endDate) >= currentDate);
      this.isPreviousFinancialYear = this.selectedFinancialYear.id >= currentFinancialYear.id ? false : true;

      // If previous financial year, disable all buttons besides comments and view history
      for (let i = 0; i < this.buttonItems[0].items.length - 2; i++) {
        this.buttonItems[0].items[i].disabled = this.isPreviousFinancialYear;
      }*/
    }
  }

  frequencyPeriodChange() {
    this.getFilteredWorkplanIndicators();
  }

  private getFilteredWorkplanIndicators() {
    if (this.selectedFinancialYear && this.selectedFrequencyPeriod) {
      this.filteredWorkplanIndicators = [];

      this._workplanIndicators.forEach(indicator => {
        let workplanTargets = indicator.workplanTargets.filter(x => x.activityId == indicator.activity.id && x.financialYearId == this.selectedFinancialYear.id && x.frequencyId == this.selectedFrequencyPeriod.frequencyId);
        let workplanActuals = indicator.workplanActuals.filter(x => x.activityId == indicator.activity.id && x.financialYearId == this.selectedFinancialYear.id && x.frequencyPeriodId == this.selectedFrequencyPeriod.id);

        workplanActuals.forEach(item => {
          item.status = this.statuses.find(x => x.id === item.statusId);

          // Disable fields if WorkplanActual is not in a New, Saved or AmendmentsRequired state
          item.isSubmitted = item.statusId == StatusEnum.New || item.statusId == StatusEnum.Saved || item.statusId == StatusEnum.AmendmentsRequired ? false : true;
        });

        let capturedTarget = 0;
        let targetMet = null;
        let attentionRequired = null;

        if (workplanActuals.length > 0) {

          switch (workplanActuals[0].frequencyPeriodId) {
            case FrequencyPeriodEnum.Apr:
              capturedTarget = workplanTargets[0].apr;
              break;
            case FrequencyPeriodEnum.May:
              capturedTarget = workplanTargets[0].may;
              break;
            case FrequencyPeriodEnum.Jun:
              capturedTarget = workplanTargets[0].jun;
              break;
            case FrequencyPeriodEnum.Jul:
              capturedTarget = workplanTargets[0].jul;
              break;
            case FrequencyPeriodEnum.Aug:
              capturedTarget = workplanTargets[0].aug;
              break;
            case FrequencyPeriodEnum.Sep:
              capturedTarget = workplanTargets[0].sep;
              break;
            case FrequencyPeriodEnum.Oct:
              capturedTarget = workplanTargets[0].oct;
              break;
            case FrequencyPeriodEnum.Nov:
              capturedTarget = workplanTargets[0].nov;
              break;
            case FrequencyPeriodEnum.Dec:
              capturedTarget = workplanTargets[0].dec;
              break;
            case FrequencyPeriodEnum.Jan:
              capturedTarget = workplanTargets[0].jan;
              break;
            case FrequencyPeriodEnum.Feb:
              capturedTarget = workplanTargets[0].feb;
              break;
            case FrequencyPeriodEnum.Mar:
              capturedTarget = workplanTargets[0].mar;
              break;
          }

          targetMet = !workplanActuals[0].actual ? null : workplanActuals[0].actual >= capturedTarget;
          attentionRequired = workplanActuals[0].statement || workplanActuals[0].deviationReason || workplanActuals[0].action ? true : false;
        }

        this.filteredWorkplanIndicators.push({
          activity: indicator.activity,
          workplanTargets: workplanTargets,
          workplanActuals: workplanActuals,
          targetMet: targetMet,
          attentionRequired: attentionRequired
        } as IWorkplanIndicator);
      });

      this._spinner.hide();
    }

    this._spinner.hide();
  }

  public uploadDocument(workplanIndicator: IWorkplanIndicator) {
    this.selectedIndicator = workplanIndicator;
    this.element.nativeElement.click();
  }

  public onUploadChange = (files) => {
    files[0].documentType = this.documentTypes.find(x => x.location === DocumentUploadLocationsEnum.WorkplanActuals);

    this._documentStore.upload(files, EntityTypeEnum.WorkplanActuals, Number(this.selectedIndicator.workplanActuals[0].id), EntityEnum.WorkplanIndicators, this.application.refNo, files[0].documentType.id).subscribe(
      event => {
        if (event.type === HttpEventType.UploadProgress)
          this._spinner.show();
        else if (event.type === HttpEventType.Response) {
          this._spinner.hide();
          this.getDocuments(this.selectedIndicator.workplanActuals[0]);
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'File successfully uploaded.' });
        }
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public uploadedFiles(workplanIndicator: IWorkplanIndicator) {
    this._spinner.show();
    this.workplanActual = workplanIndicator.workplanActuals[0];
    this.getDocuments(workplanIndicator.workplanActuals[0]);
    this.displayUploadedFilesDialog = true;
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

  onDeleteDocument(doc: any, workplanActuals: IWorkplanActual) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this document?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._spinner.show();

        this._documentStore.delete(doc.resourceId).subscribe(
          (event) => {
            this.getDocuments(workplanActuals);
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

  updateButtonItems() {
    // Show all buttons
    this.buttonItems[0].items.forEach(option => {
      option.visible = true;
    });

    // Hide buttons based on status
    switch (this.selectedIndicator.workplanActuals[0].statusId) {
      case StatusEnum.New:
      case StatusEnum.Saved:
      case StatusEnum.AmendmentsRequired: {
        this.buttonItems[0].items[2].visible = false;
        this.buttonItems[0].items[3].visible = false;
        this.buttonItems[0].items[4].visible = false;
        break;
      }
      case StatusEnum.PendingReview: {
        this.buttonItems[0].items[0].visible = false;
        this.buttonItems[0].items[1].visible = false;
        this.buttonItems[0].items[3].visible = false;
        break;
      }
      case StatusEnum.PendingApproval: {
        this.buttonItems[0].items[0].visible = false;
        this.buttonItems[0].items[1].visible = false;
        this.buttonItems[0].items[2].visible = false;
        break;
      }
      case StatusEnum.Approved: {
        this.buttonItems[0].items[0].visible = false;
        this.buttonItems[0].items[1].visible = false;
        this.buttonItems[0].items[2].visible = false;
        this.buttonItems[0].items[3].visible = false;
        this.buttonItems[0].items[4].visible = false;
        break;
      }
    }
  }

  getRowColour(data: IWorkplanIndicator) {
    if (data.workplanActuals[0] && data.workplanActuals[0].statusId !== StatusEnum.Approved) {
      if ((data.targetMet != null && !data.targetMet) || (data.attentionRequired != null && data.attentionRequired === true))
        return 'red';
    }

    if (data.workplanActuals[0] && data.workplanActuals[0].statusId === StatusEnum.Approved)
      return 'green';

    return 'default';
  }
}
