import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Table } from 'exceljs';
import { NgxSpinnerService } from 'ngx-spinner';
import { Message, MenuItem, ConfirmationService, MessageService } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { PermissionsEnum, StatusEnum, DropdownTypeEnum, DocumentUploadLocationsEnum, EntityTypeEnum, EntityEnum } from 'src/app/models/enums';
import { IFundingApplicationDetails, IApplication, IUser, IDocumentStore, IDocumentType } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { EnvironmentUrlService } from 'src/app/services/environment-url/environment-url.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-qc-document-upload-edit',
  templateUrl: './qc-document-upload-edit.component.html',
  styleUrls: ['./qc-document-upload-edit.component.css']
})
export class QcDocumentUploadEditComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }
  @ViewChild('fileAdDoc') el: ElementRef;


  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;
  acutalGrid: string;
  downloadButtonColor: string;
  uploadButtonDisabled: boolean = false;
  selectClass: string = "non-mandatory-content";
  // Document upload element
  @ViewChild('addDoc') element: ElementRef;

  displayUploadedFilesDialog: boolean;

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  @Input() activeStep: number;
  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  application: IApplication;

  profile: IUser;
  documents: IDocumentStore[] = [];
  fundAppdocuments: IDocumentStore[] = [];
  documentCols: any[];
  uploadedFileCols: any[];
  documentTypeCols: any[];
  documentTypes: IDocumentType[] = [];
  compulsoryDocuments: IDocumentType[] = [];
  nonCompulsoryDocuments: IDocumentType[] = [];
  docTypeNames: any[];
  documentTypeName: string;

  validationErrors: Message[];
  menuActions: MenuItem[];
  getFiles: any;
  //uploadedFiles: boolean = false;
  indicatorDetailsId: number;
  selectedDocTypeId: number;
  selectedDocumentType: IDocumentType;
  userId: number;
  _profile: IUser;
  list: any[];
  selectedFile: any;
  selectedFilename: string;

  selectedApplicationId: string;
  constructor(
    private _spinner: NgxSpinnerService,
    private _documentStore: DocumentStoreService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private _dropdownRepo: DropdownService,
    private _loggerService: LoggerService,
    private http: HttpClient,
    private fb: FormBuilder,
    private envUrl: EnvironmentUrlService,
    private _authService: AuthService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _bidService: BidService,
  ) { }

  ngOnInit(): void {

    this._spinner.show();

    this._activeRouter.paramMap.subscribe(params => {
      this.selectedApplicationId = params.get('id');
    });

    console.log('Selected Application Id from document page',this.selectedApplicationId );
    console.log('Selected fundingApplicationDetails id  from document page',this.fundingApplicationDetails.id );

    
    this._authService.profile$.subscribe(x => {

      if (x) {
        this._profile = x;
        this.userId = x.id;
      }
    });

    this._spinner.hide();
    this.documentCols = [
      { header: 'Id', width: '5%' },
      { field: 'name', header: 'Document Type', width: '35%' },
      { header: 'Document Name', width: '45%' },
      // { header: 'Size', width: '10%' },
      // { header: 'Uploaded Date', width: '10%' },
      { header: 'Actions', width: '10%' }
    ];
    this.uploadedFileCols = [
      // { header: '', width: '5%' },
      { header: 'Document Type', width: '25%' },
      { header: 'Document Name', width: '40%' },
      { header: 'Size', width: '10%' },
      { header: 'Uploaded Date', width: '10%' },
      { header: 'Actions', width: '15%' }
    ];
    this.documentTypeCols = [
      { header: '', width: '5%' },
      { header: 'Document Type', width: '20%' },
      { header: 'Document Type Description', width: '75%' }
    ];

    this.docTypeNames = [
      { name: 'Type1' },
      { name: 'Type2' },
      { name: 'Type3' },
      { name: 'Type4' },
      { name: 'Type5' }
    ];
    this.loadDocumentTypes();
    this.loadApplication();
  }

  private loadApplication() {
    debugger;
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.selectedApplicationId)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
                 this._bidService.getApplicationBiId(results.id).subscribe(response => {          
              this.getFundingApplicationDetails(response); 
           
          });
        }
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }
  
  
  private getFundingApplicationDetails(data) {
    if(data != null){

    this._bidService.getBid(data.id).subscribe(response => {

      this.getBidFullObject(response)
    });
  }

  }

  private getBidFullObject(data) {
    this.fundingApplicationDetails = data;
    this.fundingApplicationDetails.id = data.id;
    this.fundingApplicationDetails.applicationDetails.amountApplyingFor = data.applicationDetails.amountApplyingFor;
    this.fundingApplicationDetails.applicationDetails.fundAppSDADetail = data.applicationDetails.fundAppSDADetail;
  }  
  onFilesUpload(event) {

    // Iterate over selected files
    for (let file of event.target.files) {

      // Append to a list
      this.list.push({
        name: file.name,
        type: file.type
        // Other specs
      });
    }
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

  onRowSelect(event) {
    if (event.files[0]) {
      this.selectedDocTypeId =
        event.files[0].documentType.id;
    }
    else {
      this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Please specify the document type.' });
    }
  }

  private loadDocumentTypes() {

    this._dropdownRepo.GetEntitiesForDoc(DropdownTypeEnum.DocumentTypes, Number(this.selectedApplicationId), false).subscribe(
      (results) => {
        this.compulsoryDocuments = results.filter(x => x.isCompulsory === true && x.location === DocumentUploadLocationsEnum.NpoProfile);
        this.nonCompulsoryDocuments = results.filter(x => x.isCompulsory === false && x.location === DocumentUploadLocationsEnum.NpoProfile);
        this.documentTypes = results.filter(x => x.location === DocumentUploadLocationsEnum.FundApp);

        this.documentTypes.forEach(element => {
          if (element.isCompulsory) {
            if (element.isCompulsory === true)
              this.selectClass = "mandatory-content";
            else
              this.selectClass = "non-mandatory-content";
          }
        });
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
  selectCarWithButton(plan: any) {
    this.indicatorDetailsId = Number(this.fundingApplicationDetails.id);
    this.el.nativeElement.click();

  }

  public uploadDocument(doc: any) {
    this.selectedDocTypeId = doc.id;
    this.element.nativeElement.click();
  }
  public uploadedFiles(doc: any) {
    this._spinner.show();
    this.selectedDocTypeId = doc.id;
    this.getFundAppDocuments(doc.id);
    this.displayUploadedFilesDialog = true;
  }

  public onUploadChange = (files) => {
    debugger;
    files[0].documentType = this.documentTypes.find(x => x.location === DocumentUploadLocationsEnum.FundApp);
    this._documentStore.upload(files, EntityTypeEnum.SupportingDocuments, Number(this.selectedApplicationId),
      EntityEnum.FundingApplicationDetails, this.application.refNo, this.selectedDocTypeId).subscribe(
        event => {
          if (event.type === HttpEventType.UploadProgress)
            this._spinner.show();
          else if (event.type === HttpEventType.Response) {
            this._spinner.hide();
            this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'File successfully uploaded.' });
            this.loadDocumentTypes();
          }
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
  }

  onFileSelected(event) {
    this.selectedFile = <File>event.target.files[0];
    this.selectedFilename = this.selectedFile.name;
  }

  public onUploadChange1 = (event, form) => {
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

  public uploadADDocument = (files) => {
    if (files.length === 0) {
      return;
    }
    this._spinner.show();
    let filesToUpload: File[] = files;
    const formData = new FormData();

    Array.from(filesToUpload).map((fileAdDoc, index) => {
      return formData.append('file' + index, fileAdDoc, fileAdDoc.name);
    });

    this.http.post(this.envUrl.urlAddress + `/api/documentstore/UploadDocuments?id=` + this.indicatorDetailsId + "&userId=" + this.userId, formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this._spinner.show();
        else if (event.type === HttpEventType.Response) {
          // this.message = 'Uploaded!';

          this.downloadButtonColor = 'p-button-success';
          this.downloadButtonColor = 'ui-button-info';
          this._spinner.hide();
          let filesToUpload: File[] = files;
          this._messageService.add({ severity: 'success', summary: 'Success', detail: 'File Uploaded' });
        }
      },

        (error) => {
          console.log(error.error)
          // this.errMessage= error.error;
          this._spinner.hide();
          // this.display1 = true;     
        });
  }

  private getDocuments() {
    if (this.fundingApplicationDetails?.id != undefined) {
      this._documentStore.get(Number(this.fundingApplicationDetails?.id), EntityTypeEnum.SupportingDocuments).subscribe(
        res => {
          this.documents = res;
          this._spinner.hide();
        },
        () => this._spinner.hide()
      );
    }
  }

  private getFundAppDocuments(docTypeId: number) {
    //this.fundAppdocuments =[];
    if (this.selectedApplicationId != undefined) {
      this._documentStore.getFundApp(Number(this.selectedApplicationId), docTypeId, EntityTypeEnum.SupportingDocuments).subscribe(
        res => {
          this.fundAppdocuments = res;
          this._spinner.hide();
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
            //this.getDocuments();

            this.getFundAppDocuments(this.selectedDocTypeId);
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