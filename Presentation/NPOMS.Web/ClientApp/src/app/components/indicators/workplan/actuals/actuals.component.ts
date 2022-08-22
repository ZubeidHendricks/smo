import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { Subscription } from 'rxjs';
import { DropdownTypeEnum, FrequencyEnum, PermissionsEnum } from 'src/app/models/enums';
import { IActivity, IDocumentStore, IFinancialYear, IFrequency, IUser, IWorkplanTarget } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
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

  public get FrequencyEnum(): typeof FrequencyEnum {
    return FrequencyEnum;
  }

  profile: IUser;
  validationErrors: Message[];

  menuActions: MenuItem[];
  paramSubcriptions: Subscription;
  id: string;

  activity: IActivity;
  isDataAvailable: boolean;

  documents: IDocumentStore[] = [];
  documentCols: any[];

  financialYears: IFinancialYear[];
  filtererdFinancialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  target: IWorkplanTarget;

  workplanTargets: IWorkplanTarget[];

  value1: string;

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _activeRouter: ActivatedRoute,
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _indicatorRepo: IndicatorService,
    private _messageService: MessageService
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
        this.loadTargets();
      },
      (err) => this._spinner.hide()
    );
  }

  private loadTargets() {
    this._indicatorRepo.getTargetsByActivityId(this.activity.id).subscribe(
      (results) => {
        this.workplanTargets = results;
        this.populateFilteredFinancialYears();
        this._spinner.hide();
        this.isDataAvailable = true;
      },
      (error) => this._spinner.hide()
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

  populateFilteredFinancialYears() {
    if (this.financialYears && this.workplanTargets) {
      let financialYears = [];
      this.filtererdFinancialYears = [];

      this.workplanTargets.forEach(item => {
        financialYears.push(this.financialYears.find(x => x.id === item.financialYearId));
      });

      this.filtererdFinancialYears = financialYears.filter((element, index) => index === financialYears.indexOf(element));
    }
  }

  private buildMenu() {
    this.menuActions = [
      {
        label: 'Clear Messages',
        icon: 'fa fa-undo',
        command: () => {
          // this.clearMessages();
        },
        visible: false
      },
      {
        label: 'Save',
        icon: 'fa fa-floppy-o',
        command: () => {

        }
      },
      {
        label: 'Submit',
        icon: 'fa fa-thumbs-o-up',
        command: () => {
          // this.saveItems(StatusEnum.PendingReview);
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

  financialYearChange() {
    this.target = this.workplanTargets.find(x => x.activityId == this.activity.id && x.financialYearId == this.selectedFinancialYear.id);
  }

  public onUploadChange = (event, form) => {
    // if (event.files[0].documentType) {
    //   this._documentStore.upload(event.files, EntityTypeEnum.SupportingDocuments, Number(this.npoProfile.id), EntityEnum.NpoProfile, this.npoProfile.refNo, event.files[0].documentType.id).subscribe(
    //     event => {
    //       if (event.type === HttpEventType.UploadProgress)
    //         this._spinner.show();
    //       else if (event.type === HttpEventType.Response) {
    //         this._spinner.hide();
    //         this.getDocuments();
    //       }
    //     },
    //     (error) => this._spinner.hide()
    //   );
    //   form.clear();
    // }
    // else {
    //   this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Please specify the document type.' });
    // }
  }

  remove(event, file: File, uploader: FileUpload) {
    const index = uploader.files.indexOf(file);
    uploader.remove(event, index);
  }

  onDownloadDocument(doc: any) {
    // this._confirmationService.confirm({
    //   message: 'Are you sure that you want to download document?',
    //   header: 'Confirmation',
    //   icon: 'pi pi-info-circle',
    //   accept: () => {
    //     this._documentStore.download(doc).subscribe();
    //   },
    //   reject: () => {
    //   }
    // });
  }

  onDeleteDocument(doc: any) {
    // this._confirmationService.confirm({
    //   message: 'Are you sure that you want to delete this document?',
    //   header: 'Confirmation',
    //   icon: 'pi pi-info-circle',
    //   accept: () => {
    //     this._spinner.show();

    //     this._documentStore.delete(doc.resourceId).subscribe(
    //       event => {
    //         this.getDocuments();
    //         this._spinner.hide();
    //       },
    //       (error) => this._spinner.hide()
    //     );
    //   },
    //   reject: () => {
    //   }
    // });
  }
}
