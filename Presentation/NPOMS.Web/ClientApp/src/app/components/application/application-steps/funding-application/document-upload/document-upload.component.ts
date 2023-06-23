import { HttpEventType } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Message, MenuItem, ConfirmationService, MessageService } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { DocumentUploadLocationsEnum, DropdownTypeEnum, EntityEnum, EntityTypeEnum, PermissionsEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IUser, IDocumentStore, IDocumentType, IFundingApplicationDetails } from 'src/app/models/interfaces';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-document-upload',
  templateUrl: './document-upload.component.html',
  styleUrls: ['./document-upload.component.css']
})
export class DocumentUploadComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  @Input() activeStep: number;
  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;

  profile: IUser;
  documents: IDocumentStore[] = [];
  documentCols: any[];
  documentTypeCols: any[];
  documentTypes: IDocumentType[] = [];
  compulsoryDocuments: IDocumentType[] = [];
  nonCompulsoryDocuments: IDocumentType[] = [];

  validationErrors: Message[];
  menuActions: MenuItem[];

  constructor(
    private _spinner: NgxSpinnerService,
    private _documentStore: DocumentStoreService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private _dropdownRepo: DropdownService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this.getDocuments();
    this.documentCols = [
      { header: '', width: '5%' },
      { header: 'Document Name', width: '43%' },
      { header: 'Document Type', width: '25%' },
      { header: 'Size', width: '10%' },
      { header: 'Uploaded Date', width: '10%' },
      { header: 'Actions', width: '7%' }
    ];
    this.documentTypeCols = [
      { header: '', width: '5%' },
      { header: 'Document Type', width: '20%' },
      { header: 'Document Type Description', width: '75%' }
    ];
    this.loadDocumentTypes();
  }

  readonly(): boolean {

    if (this.application.statusId == StatusEnum.PendingReview ||
      this.application.statusId == StatusEnum.Approved)
      return true;
    else return false;
  }

  remove(event, file: File, uploader: FileUpload) {
    const index = uploader.files.indexOf(file);
    uploader.remove(event, index);
  }

  private loadDocumentTypes() {

    this._dropdownRepo.getEntities(DropdownTypeEnum.DocumentTypes, false).subscribe(
      (results) => {
        this.compulsoryDocuments = results.filter(x => x.isCompulsory === true && x.location === DocumentUploadLocationsEnum.NpoProfile);
        this.nonCompulsoryDocuments = results.filter(x => x.isCompulsory === false && x.location === DocumentUploadLocationsEnum.NpoProfile);
        this.documentTypes = results.filter(x => x.location === DocumentUploadLocationsEnum.FundApp);
        console.log('this.documentTypes', this.documentTypes);
        console.log('results', results);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  onDownloadDocument(doc: any) {
    console.log('download', doc);
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

  public onUploadChange = (event, form) => {
    if (event.files[0]) {
      this._documentStore.upload(event.files, EntityTypeEnum.SupportingDocuments,
        Number(this.fundingApplicationDetails.id), EntityEnum.FundingApplicationDetails,
        this.application.refNo, event.files[0].documentType.id).subscribe(
          event => {
            if (event.type === HttpEventType.UploadProgress)
              this._spinner.show();
            else if (event.type === HttpEventType.Response) {
              this._spinner.hide();
              this.getDocuments();
            }
          },
          () => this._spinner.hide()
        );
      form.clear();
    }
    else {
      this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Please specify the document type.' });
    }
  }



  private getDocuments() {
    if (this.fundingApplicationDetails?.id != undefined) {
      this._documentStore.get(Number(this.fundingApplicationDetails?.id), EntityTypeEnum.SupportingDocuments).subscribe(
        res => {
          this.documents = res;
        },
        () => this._spinner.hide()
      );
    }
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
          (error) => this._spinner.hide()
        );
      },
      reject: () => {
      }
    });
  }


  prevPage() {

    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }
}
