import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { Message, MenuItem, ConfirmationService, MessageService } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { DocumentUploadLocationsEnum, DropdownTypeEnum, EntityEnum, EntityTypeEnum, PermissionsEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IUser, IDocumentStore, IDocumentType, IFundingApplicationDetails } from 'src/app/models/interfaces';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { EnvironmentUrlService } from 'src/app/services/environment-url/environment-url.service';
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
  @ViewChild('fileAdDoc') el:ElementRef;
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
  uploadedFileCols:any[];
  documentTypeCols: any[];
  documentTypes: IDocumentType[] = [];
  compulsoryDocuments: IDocumentType[] = [];
  nonCompulsoryDocuments: IDocumentType[] = [];
  docTypeNames : any[];
  documentTypeName : string;

  validationErrors: Message[];
  menuActions: MenuItem[];
  getFiles: any;
  //uploadedFiles: boolean = false;
  indicatorDetailsId: number;
  selectedDocTypeId: number;
  selectedDocumentType: IDocumentType;
  userId: number;
  _profile:IUser;
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
  ) { }

  ngOnInit(): void {

    this._spinner.show();
    this._authService.profile$.subscribe(x=>{

      if(x)
      {
          this._profile = x;
          this.userId = x.id;
      }});
    //this.getDocuments();
    //this.getFundAppDocuments(this.selectedDocTypeId);
       this._spinner.hide();
    this.documentCols = [
      { header: 'Id', width: '5%' },
      { header: 'Document Type', width: '35%' },
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

    this.docTypeNames =[
      {name:'Type1'},
      {name:'Type2'},
      {name:'Type3'},
      {name:'Type4'},
      {name:'Type5'}  
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

  onRowSelect(event) {
    debugger;
    if (event.files[0]) {
this.selectedDocTypeId =      
        event.files[0].documentType.id;
        console.log('this.selectedDocTypeId from onRowSelect',this.selectedDocTypeId);
        console.log('event.files[0].documentType.id from onRowSelect',event.files[0].documentType.id);

    }
    else {
      this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Please specify the document type.' });
    }    
  }

  private loadDocumentTypes() {
    debugger;
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
    debugger;
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
  selectCarWithButton(plan: any) {
    //this.indicatorDetailsId = plan.id; 
    this.indicatorDetailsId =  Number(this.fundingApplicationDetails.id); 
    
    this.el.nativeElement.click();
    //  console.log(plan);
  }

  public uploadDocument(doc: any) {
    debugger;
    console.log('doc while click Upload icon',doc);
    this.selectedDocTypeId = doc.id;
    console.log('this.selectedDocTypeId while click Upload icon',this.selectedDocTypeId);
    this.element.nativeElement.click();
  }
  public uploadedFiles(doc: any) {
    debugger;
    this._spinner.show();
    //this.getDocuments();
    console.log('doc from Uploaded Files',doc);
    console.log('doc from Uploaded Files',doc.id);

    this.getFundAppDocuments(doc.id);
    this.displayUploadedFilesDialog = true;
  }

  public onUploadChange = (files) => {
    debugger;
    console.log('this.selectedDocTypeId on Upload Change',this.selectedDocTypeId);

    files[0].documentType = this.documentTypes.find(x => x.location === DocumentUploadLocationsEnum.FundApp);
    this._documentStore.upload(files, EntityTypeEnum.SupportingDocuments, Number(this.fundingApplicationDetails.id), 
    EntityEnum.FundingApplicationDetails, this.application.refNo, files[0].documentType.id).subscribe(
      event => {
        if (event.type === HttpEventType.UploadProgress)
          this._spinner.show();
        else if (event.type === HttpEventType.Response) {
          this._spinner.hide();
          //this.getDocuments();
          console.log('Document Type Id', files[0].documentType.id);
          this.getFundAppDocuments(files[0].documentType.id);
          this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'File successfully uploaded.' });
        }
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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
     console.log("kurac",files);
    if (files.length === 0) {      
      return;   
    }
    this._spinner.show();
    let filesToUpload : File[] = files;
    const formData = new FormData();   
  
    Array.from(filesToUpload).map((fileAdDoc, index) => {
      // console.log(files);
      return formData.append('file'+index, fileAdDoc, fileAdDoc.name);
    });
  
    this.http.post(this.envUrl.urlAddress + `/api/documentstore/UploadDocuments?id=`+ this.indicatorDetailsId +"&userId=" + this.userId, formData, {reportProgress: true, observe: 'events'})
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
        this._spinner.show();
        else if (event.type === HttpEventType.Response) {
          // this.message = 'Uploaded!';
          
           this.downloadButtonColor = 'p-button-success';
      this.downloadButtonColor = 'ui-button-info';
          this._spinner.hide();
          // console.log(event.body);
          let filesToUpload : File[] = files;
          this._messageService.add({severity: 'success', summary: 'Success', detail: 'File Uploaded'});
        }
      },
  
  (error) => {console.log(error.error)
  // this.errMessage= error.error;
   this._spinner.hide();
  // this.display1 = true;     
  });
}

  private getDocuments() {
    debugger;
    if (this.fundingApplicationDetails?.id != undefined) {
      this._documentStore.get(Number(this.fundingApplicationDetails?.id), EntityTypeEnum.SupportingDocuments).subscribe(
        res => {
        
          // if(res.find(x => x.documentTypeId == 18))
          // {
          //   this.documentTypeName ="Application Declaration";          
          // }
          // if(res.find(x => x.documentTypeId == 8))
          // {
          //   this.documentTypeName ="NPO Reg Cert";          
          // }
          // if(res.find(x => x.documentTypeId == 9))
          // {
          //   this.documentTypeName ="Org Registration Certificate";          
          // }
          // if(res.find(x => x.documentTypeId == 10))
          // {
          //   this.documentTypeName ="Constitution";          
          // }
          // if(res.find(x => x.documentTypeId == 11))
          // {
          //   this.documentTypeName ="Supporting";          
          // }
          // if(res.find(x => x.documentTypeId == 12))
          // {
          //   this.documentTypeName ="Bank Letter";          
          // }
          // if(res.find(x => x.documentTypeId == 13))
          // {
          //   this.documentTypeName ="Audited Annual Financial Statement";          
          // }
          // if(res.find(x => x.documentTypeId == 14))
          // {
          //   this.documentTypeName ="Certified Financial Statement";          
          // }
          // if(res.find(x => x.documentTypeId == 15))
          // {
          //   this.documentTypeName ="PFMA";          
          // }
          // if(res.find(x => x.documentTypeId == 16))
          // {
          //   this.documentTypeName ="Bank Statements";          
          // }
          // if(res.find(x => x.documentTypeId == 17))
          // {
          //   this.documentTypeName ="BAS Entity Form";          
          // }          
          // if(res.find(x => x.documentTypeId == 19))
          // {
          //   this.documentTypeName ="Enrolment Form";          
          // }
          
          // if(res.find(x => x.documentTypeId == 7))
          // {
          //   this.documentTypeName ="Signed Declaration of Interest";          
          // } 
          
          this.documents = res;
      
        this._spinner.hide();
        },
        () => this._spinner.hide()
      );
    }
  }

  private getFundAppDocuments(docTypeId :number) {
    debugger;
    console.log('From GetFundApp document',docTypeId);
    //this.fundAppdocuments =[];
    if (this.fundingApplicationDetails?.id != undefined) {
      this._documentStore.getFundApp(Number(this.fundingApplicationDetails?.id), docTypeId, EntityTypeEnum.SupportingDocuments).subscribe(
        res => {
          // if(res.find(x => x.documentTypeId == 7))
          // {
          //   this.documentTypeName ="Signed Declaration of Interest";          
          // } 
          // if(res.find(x => x.documentTypeId == 8))
          // {
          //   this.documentTypeName ="NPO Reg Cert";          
          // }
          // if(res.find(x => x.documentTypeId == 9))
          // {
          //   this.documentTypeName ="Org Registration Certificate";          
          // }
          // if(res.find(x => x.documentTypeId == 10))
          // {
          //   this.documentTypeName ="Constitution";          
          // }
          // if(res.find(x => x.documentTypeId == 11))
          // {
          //   this.documentTypeName ="Supporting";          
          // }
          // if(res.find(x => x.documentTypeId == 12))
          // {
          //   this.documentTypeName ="Bank Letter";          
          // }
          // if(res.find(x => x.documentTypeId == 13))
          // {
          //   this.documentTypeName ="Audited Annual Financial Statement";          
          // }
          // if(res.find(x => x.documentTypeId == 14))
          // {
          //   this.documentTypeName ="Certified Financial Statement";          
          // }
          // if(res.find(x => x.documentTypeId == 15))
          // {
          //   this.documentTypeName ="PFMA";          
          // }
          // if(res.find(x => x.documentTypeId == 16))
          // {
          //   this.documentTypeName ="Bank Statements";          
          // }
          // if(res.find(x => x.documentTypeId == 17))
          // {
          //   this.documentTypeName ="BAS Entity Form";          
          // }
          // if(res.find(x => x.documentTypeId == 18))
          // {
          //   this.documentTypeName ="Application Declaration";          
          // }          
          // if(res.find(x => x.documentTypeId == 19))
          // {
          //   this.documentTypeName ="Enrolment Form";          
          // }          
    

          this.fundAppdocuments = res;
          console.log('Get FundApp',this.fundAppdocuments);
        this._spinner.hide();
        },
        () => this._spinner.hide()
      );
    }
  }

  onDeleteDocument(doc: any) {
    debugger;
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this document?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._spinner.show();

        this._documentStore.delete(doc.resourceId).subscribe(
          event => {
            this.getDocuments();
            //this.getFundAppDocuments(doc.id);
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
