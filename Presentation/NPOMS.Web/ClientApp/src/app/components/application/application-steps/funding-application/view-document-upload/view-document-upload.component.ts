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
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { EnvironmentUrlService } from 'src/app/services/environment-url/environment-url.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-view-document-upload',
  templateUrl: './view-document-upload.component.html',
  styleUrls: ['./view-document-upload.component.css']
})
export class ViewDocumentUploadComponent implements OnInit {

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

  // Document upload element
  @ViewChild('addDoc') element: ElementRef;

  displayUploadedFilesDialog: boolean;

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  @Input() activeStep: number;
  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;

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
  headerTitle: string;

  validationErrors: Message[];
  menuActions: MenuItem[];
  getFiles: any;
  indicatorDetailsId: number;
  selectedDocTypeId: number;
  selectedDocumentType: IDocumentType;
  userId: number;
  _profile: IUser;
  list: any[];
  selectedFile: any;
  selectedFilename: string;
  setDisabled: boolean = true;

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
    private _activeRouter: ActivatedRoute
  ) { }

  ngOnInit(): void {

    this._spinner.show();

    this._activeRouter.paramMap.subscribe(params => {
      this.selectedApplicationId = params.get('id');
    });
    this._authService.profile$.subscribe(x => {

      if (x) {
        this._profile = x;
        this.userId = x.id;
      }
    });

    var splitUrl = window.location.href.split('/');
    this.headerTitle = splitUrl[5];

    if(this.headerTitle != 'view')
    {
      this.setDisabled = false;
    }

    this._spinner.hide();
    this.documentCols = [
      { header: 'Id', width: '5%' },
      { field: 'name', header: 'Document Type', width: '35%' },
      { header: 'Document Name', width: '45%' },
      { header: 'Actions', width: '10%' }
    ];
    this.uploadedFileCols = [
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
  }

  private loadDocumentTypes() {
    this._dropdownRepo.GetEntitiesForDoc(DropdownTypeEnum.DocumentTypes, Number(this.selectedApplicationId), false).subscribe(
      (results) => {
        this.compulsoryDocuments = results.filter(x => x.isCompulsory === true && x.location === DocumentUploadLocationsEnum.NpoProfile);
        this.nonCompulsoryDocuments = results.filter(x => x.isCompulsory === false && x.location === DocumentUploadLocationsEnum.NpoProfile);
        this.documentTypes = results.filter(x => x.location === DocumentUploadLocationsEnum.FundApp);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  onDownloadDocument(doc: any) {

    let text = "Are you sure that you want to download document?";
    if (confirm(text) == true)
    {
      this._documentStore.download(doc).subscribe();
      this.displayUploadedFilesDialog = false;
    }
    else{

      this.displayUploadedFilesDialog = false;
    }
  }
 
  public uploadedFiles(doc: any) {
    this._spinner.show();
    this.selectedDocTypeId = doc.id;
    this.getFundAppDocuments(doc.id);
    this.displayUploadedFilesDialog = true;
  }

  onFileSelected(event) {
    this.selectedFile = <File>event.target.files[0];
    this.selectedFilename = this.selectedFile.name;
  }

  private getDocuments() {
    if (this.fundingApplicationDetails?.id != undefined) {
      this._documentStore.get(Number(this.fundingApplicationDetails?.id), EntityTypeEnum.SupportingDocuments).subscribe(
        res => {
          this.documents = res.filter(x => x.entity === EntityEnum.FundingApplicationDetails);
          this._spinner.hide();
        },
        () => this._spinner.hide()
      );
    }
  }

  private getFundAppDocuments(docTypeId: number) {
    if (this.fundingApplicationDetails?.id != undefined) {
      this._documentStore.getFundApp(Number(this.fundingApplicationDetails?.id), docTypeId, EntityTypeEnum.SupportingDocuments).subscribe(
        res => {
          this.fundAppdocuments = res;
          this._spinner.hide();
        },
        () => this._spinner.hide()
      );
    }
  }
}
