import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { Subscription } from 'rxjs';
import { DropdownTypeEnum, EntityEnum, EntityTypeEnum, FrequencyEnum, FrequencyPeriodEnum, PermissionsEnum } from 'src/app/models/enums';
import { IActivity, IApplication, IDocumentStore, IDocumentType, IFinancialYear, IFrequency, IFrequencyPeriod, IUser, IWorkplanActual, IWorkplanTarget } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-actuals',
  templateUrl: './actuals.component.html',
  styleUrls: ['./actuals.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ActualsComponent implements OnInit {

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
  validationErrors: Message[];

  menuActions: MenuItem[];
  paramSubcriptions: Subscription;
  id: string;

  application: IApplication;
  activity: IActivity;
  isDataAvailable: boolean;

  documentCols: any[];

  financialYears: IFinancialYear[];
  filtererdFinancialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  frequencies: IFrequency[];
  selectedFrequency: IFrequency;

  workplanTargets: IWorkplanTarget[];
  target: IWorkplanTarget;

  workplanActuals: IWorkplanActual[];
  filteredWorkplanActuals: IWorkplanActual[];

  documentTypes: IDocumentType[] = [];

  // If a previous/past financial year is selected, disable all inputs
  isPreviousFinancialYear: boolean;

  // Highlight required fields on save/submit click
  validated: boolean = false;

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _activeRouter: ActivatedRoute,
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _indicatorRepo: IndicatorService,
    private _messageService: MessageService,
    private _documentStore: DocumentStoreService,
    private _confirmationService: ConfirmationService
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
      this.loadActivity();
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        /*if (!this.IsAuthorized(PermissionsEnum.AddApplicationPeriod))
          this._router.navigate(['401']);*/

        this.loadFinancialYears();
        this.loadFrequencies();
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
  }

  private loadActivity() {
    this._spinner.show();
    this._applicationRepo.getActivityById(Number(this.id)).subscribe(
      (results) => {
        this.activity = results;
        this.loadApplication();
        this.loadTargets();
        this.loadActuals();
      },
      (err) => this._spinner.hide()
    );
  }

  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.activity.applicationId)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
        }

        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private loadTargets() {
    this._indicatorRepo.getTargetsByActivityId(this.activity.id).subscribe(
      (results) => {
        this.workplanTargets = results;
        this.populateFilteredFinancialYears();
        this.isDataAvailable = true;
      },
      (error) => this._spinner.hide()
    );
  }

  private loadActuals() {
    this._indicatorRepo.getActualsByActivityId(this.activity.id).subscribe(
      (results) => {
        this.workplanActuals = results;

        this.workplanActuals.forEach(item => {
          this.getDocuments(item);
        });

        this._spinner.hide();
      },
      (error) => this._spinner.hide()
    );
  }

  private getDocuments(workplanActual: IWorkplanActual) {
    this._documentStore.get(Number(workplanActual.id), EntityTypeEnum.WorkplanActuals).subscribe(
      res => {
        workplanActual.documents = res;
      },
      (err) => this._spinner.hide()
    );
  }

  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        this.financialYears = results;
        this.populateFilteredFinancialYears();
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private populateFilteredFinancialYears() {
    if (this.financialYears && this.workplanTargets) {
      let financialYears = [];
      this.filtererdFinancialYears = [];

      this.workplanTargets.forEach(item => {
        financialYears.push(this.financialYears.find(x => x.id === item.financialYearId));
      });

      this.filtererdFinancialYears = financialYears.filter((element, index) => index === financialYears.indexOf(element));
    }
  }

  private loadFrequencies() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Frequencies, false).subscribe(
      (results) => {
        this.frequencies = results;
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private loadDocumentTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DocumentTypes, false).subscribe(
      (results) => {
        this.documentTypes = results;
      },
      (err) => this._spinner.hide()
    );
  }

  private buildMenu() {
    this.menuActions = [
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
          this.saveItems('save');
        }
      },
      {
        label: 'Submit',
        icon: 'fa fa-thumbs-o-up',
        command: () => {
          this.saveItems('submit');
        }
      },
      {
        label: 'Go Back',
        icon: 'fa fa-step-backward',
        command: () => {
          this._router.navigateByUrl('workplan-indicator/manage/' + this.activity.applicationId);
        }
      }
    ];
  }

  private clearMessages() {
    this.validated = false;
    this.validationErrors = [];
    this.menuActions[0].visible = false;
  }

  private saveItems(buttonClicked: string) {
    if (this.canContinue(buttonClicked)) {
      let updatedWorkplanActuals = this.filteredWorkplanActuals.filter(x => x.isUpdated == true);

      if (updatedWorkplanActuals.length > 0) {
        this._spinner.show();

        updatedWorkplanActuals.forEach(item => {
          this._indicatorRepo.updateActual(item).subscribe(resp => {
            this.loadActuals();
          });
        });
      }

      if (buttonClicked == 'save')
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });

      if (buttonClicked == 'submit')
        this._router.navigateByUrl('workplan-indicator/manage/' + this.activity.applicationId);
    }
  }

  private canContinue(buttonClicked: string) {
    this.validationErrors = [];

    if (buttonClicked == 'save')
      this.saveFormValidate();

    if (buttonClicked == 'submit')
      this.formValidate();

    if (this.validationErrors.length == 0) {
      this.validated = false;
      return true;
    }

    return false;
  }

  private saveFormValidate() {
    this.validated = true;
    this.validationErrors = [];

    if (!this.selectedFinancialYear || !this.selectedFrequency)
      this.validationErrors.push({ severity: 'error', summary: "Actuals:", detail: "Missing detail required." });

    if (this.validationErrors.length == 0)
      this.menuActions[0].visible = false;
    else
      this.menuActions[0].visible = true;
  }

  private formValidate() {
    this.validated = true;
    this.validationErrors = [];

    let hasActualsErrors: boolean[] = [];
    let locationOfErrors: string[] = [];

    if (!this.selectedFinancialYear || !this.selectedFrequency)
      hasActualsErrors.push(true);

    if (this.selectedFinancialYear && this.selectedFrequency) {
      this.filteredWorkplanActuals.forEach(item => {
        if (item.actual == null || !item.statement || !item.deviationReason || !item.action) {
          hasActualsErrors.push(true);
          locationOfErrors.push(item.frequencyPeriod.name + ' Actuals');
        }
      });
    }

    if (hasActualsErrors.includes(true)) {
      if (locationOfErrors.length > 0)
        this.validationErrors.push({ severity: 'error', summary: "Actuals:", detail: "Missing detail required on " + locationOfErrors.join(', ') });
      else
        this.validationErrors.push({ severity: 'error', summary: "Actuals:", detail: "Missing detail required." });
    }

    if (this.validationErrors.length == 0)
      this.menuActions[0].visible = false;
    else
      this.menuActions[0].visible = true;
  }

  financialYearChange() {
    this.target = this.workplanTargets.find(x => x.activityId == this.activity.id && x.financialYearId == this.selectedFinancialYear.id);
    this.selectedFrequency = this.frequencies.find(x => x.id == this.target.frequencyId);
    this.filteredWorkplanActuals = this.workplanActuals.filter(x => x.financialYearId == this.target.financialYearId && x.frequencyPeriod.frequencyId == this.target.frequencyId);

    let currentYear = new Date().getFullYear();
    this.isPreviousFinancialYear = this.selectedFinancialYear.year >= currentYear ? false : true;
  }

  valueChanged(workplanActual: IWorkplanActual) {
    workplanActual.isUpdated = true;
  }

  public onUploadChange = (event, form, workplanActual) => {
    event.files[0].documentType = this.documentTypes.find(x => x.name == 'Evidence');

    this._documentStore.upload(event.files, EntityTypeEnum.WorkplanActuals, Number(workplanActual.id), EntityEnum.WorkplanIndicators, this.application.refNo, event.files[0].documentType.id).subscribe(
      event => {
        if (event.type === HttpEventType.UploadProgress)
          this._spinner.show();
        else if (event.type === HttpEventType.Response) {
          this._spinner.hide();
          this.getDocuments(workplanActual);
        }
      },
      (error) => this._spinner.hide()
    );

    form.clear();
  }

  remove(event, file: File, uploader: FileUpload) {
    const index = uploader.files.indexOf(file);
    uploader.remove(event, index);
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

  onDeleteDocument(doc: any, workplanActual: IWorkplanActual) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this document?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._spinner.show();

        this._documentStore.delete(doc.resourceId).subscribe(
          event => {
            this.getDocuments(workplanActual);
            this._spinner.hide();
          },
          (error) => this._spinner.hide()
        );
      },
      reject: () => {
      }
    });
  }
}
