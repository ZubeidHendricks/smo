import { HttpEventType } from '@angular/common/http';
import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DocumentUploadLocationsEnum, DropdownTypeEnum, EntityEnum, EntityTypeEnum, FrequencyPeriodEnum, PermissionsEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IDocumentType, IFinancialYear, IFrequencyPeriod, IUser, IWorkplanActual, IWorkplanComment, IWorkplanIndicator } from 'src/app/models/interfaces';
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

  profile: IUser;

  cols: any[];
  documentCols: any[];
  buttonItems: MenuItem[];

  filtererdFinancialYears: IFinancialYear[] = [];
  selectedFinancialYear: IFinancialYear;

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

  constructor(
    private _spinner: NgxSpinnerService,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _indicatorRepo: IndicatorService,
    private _messageService: MessageService,
    private _documentStore: DocumentStoreService,
    private _confirmationService: ConfirmationService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        /*if (!this.IsAuthorized(PermissionsEnum.AddApplicationPeriod))
          this._router.navigate(['401']);*/

        this.loadDocumentTypes();
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

        this.populateFilteredFinancialYears();
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

  private populateFilteredFinancialYears() {
    if (this._financialYears && this._financialYears.length > 0) {
      let financialYears = [];

      this._workplanIndicators.forEach(indicator => {
        indicator.workplanTargets.forEach(target => {
          financialYears.push(this._financialYears.find(x => x.id === target.financialYearId));
        });
      });

      this.filtererdFinancialYears = financialYears.filter((element, index) => index === financialYears.indexOf(element));
    }
  }

  private loadDocumentTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DocumentTypes, false).subscribe(
      (results) => {
        this.documentTypes = results.find(x => x.location === DocumentUploadLocationsEnum.WorkplanActuals);
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

      if (this.IsAuthorized(PermissionsEnum.ViewAcceptedApplication)) {
        this.buttonItems[0].items.push({
          label: 'Save Actual',
          icon: 'fa fa-floppy-o',
          command: () => {
            this.saveActual(this.selectedIndicator);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewAcceptedApplication)) {
        this.buttonItems[0].items.push({
          label: 'Submit Actual',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.submitActual(this.selectedIndicator);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewAcceptedApplication)) {
        this.buttonItems[0].items.push({
          label: 'Comments',
          icon: 'fa fa-comments-o',
          command: () => {
            this.viewComments(this.selectedIndicator);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewAcceptedApplication)) {
        this.buttonItems[0].items.push({
          label: 'View History',
          icon: 'fa fa-history',
          command: () => {
            this.viewAuditHistory(this.selectedIndicator);
            this._messageService.add({ severity: 'info', summary: 'Information', detail: 'View History under construction.' });
          }
        });
      }
    }
  }

  private saveActual(workplanIndicator: IWorkplanIndicator) {
    // Only 1 WorkplanActual will be saved/submitted at a time
    this.updateWorkplanActual(workplanIndicator.workplanActuals[0], 1);
  }

  private submitActual(workplanIndicator: IWorkplanIndicator) {
    // Only 1 WorkplanActual will be saved/submitted at a time
    this.updateWorkplanActual(workplanIndicator.workplanActuals[0], 2);
  }

  private updateWorkplanActual(workplanActual: IWorkplanActual, status: number) {
    if (workplanActual && status) {
      this._indicatorRepo.updateActual(workplanActual).subscribe(
        (resp) => {
          if (status == 1)
            this._messageService.add({ severity: 'info', summary: 'Successful', detail: 'Information successfully saved.' });

          if (status == 2)
            this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully submitted.' });
        },
        (err) => {
          this._loggerService.logException(err);
        }
      );
    }
    else {
      this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Target not captured.' });
    }
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

  financialYearChange() {
    this.getFilteredWorkplanIndicators();    
    
    let currentDate = new Date();
    let startDate = new Date(this.selectedFinancialYear.startDate);
    let endDate = new Date(this.selectedFinancialYear.endDate);

    this.isPreviousFinancialYear = (startDate <= currentDate && endDate >= currentDate) ? false : true;

    // Disable Save and Submit buttons if previous financial year
    this.buttonItems.forEach(option => {
      option.items[0].disabled = this.isPreviousFinancialYear;
      option.items[1].disabled = this.isPreviousFinancialYear;
    });
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

        this.filteredWorkplanIndicators.push({
          activity: indicator.activity,
          workplanTargets: workplanTargets,
          workplanActuals: workplanActuals
        } as IWorkplanIndicator);
      });
    }
  }

  public uploadDocument(rowData) {
    this.element.nativeElement.click();
  }

  public onUploadChange = (files, workplanIndicator) => {
    files[0].documentType = this.documentTypes.find(x => x.location === DocumentUploadLocationsEnum.WorkplanActuals);

    this._documentStore.upload(files, EntityTypeEnum.WorkplanActuals, Number(workplanIndicator.workplanActuals[0].id), EntityEnum.WorkplanIndicators, this.application.refNo, files[0].documentType.id).subscribe(
      event => {
        if (event.type === HttpEventType.UploadProgress)
          this._spinner.show();
        else if (event.type === HttpEventType.Response) {
          this._spinner.hide();
          this.getDocuments(workplanIndicator.workplanActuals[0]);
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
}
