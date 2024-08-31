import { HttpClient, HttpEventType } from '@angular/common/http';
import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Table } from 'exceljs';
import { NgxSpinnerService } from 'ngx-spinner';
import { Message, MenuItem, ConfirmationService, MessageService } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { PermissionsEnum, StatusEnum, DropdownTypeEnum, DocumentUploadLocationsEnum, EntityTypeEnum, EntityEnum } from 'src/app/models/enums';
import { IFundingApplicationDetails, IApplication, IUser, IDocumentStore, IDocumentType, IProjectInformation, IMonitoringAndEvaluation, IMyContentLink, INpo } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { EnvironmentUrlService } from 'src/app/services/environment-url/environment-url.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-qc-document-upload',
  templateUrl: './qc-document-upload.component.html',
  styleUrls: ['./qc-document-upload.component.css']
})
export class QcDocumentUploadComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() application: IApplication;
  @Input() isView: boolean;
  @Input() npo: INpo;

  // @Input() newlySavedApplicationId: number;
  // @Output() newlySavedApplicationIdChange: EventEmitter<number> = new EventEmitter<number>();

  // @Input() applnPeriodId: number;
  // @Output() applnPeriodIdChange: EventEmitter<number> = new EventEmitter<number>();

  /* Permission logic */
  // public IsAuthorized(permission: PermissionsEnum): boolean {
  //   if (this.profile != null && this.profile.permissions.length > 0) {
  //     return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
  //   }
  // }
  // @ViewChild('fileAdDoc') el: ElementRef;


  // Used for table filtering
  // @ViewChild('dt') dt: Table | undefined;
  // acutalGrid: string;
  // downloadButtonColor: string;
  // uploadButtonDisabled: boolean = false;

  // Document upload element
  // @ViewChild('addDoc') element: ElementRef;

  // displayUploadedFilesDialog: boolean;

  // public get PermissionsEnum(): typeof PermissionsEnum {
  //   return PermissionsEnum;
  // }

  // @Input() activeStep: number;
  // @Input() fundingApplicationDetails: IFundingApplicationDetails;
  // @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  // application: IApplication;

  profile: IUser;
  // documents: IDocumentStore[] = [];
  // fundAppdocuments: IDocumentStore[] = [];
  documentCols: any[];
  // uploadedFileCols: any[];
  // documentTypeCols: any[];
  documentTypes: IDocumentType[];
  // compulsoryDocuments: IDocumentType[] = [];
  // nonCompulsoryDocuments: IDocumentType[] = [];
  // docTypeNames: any[];
  // documentTypeName: string;

  // validationErrors: Message[];
  // menuActions: MenuItem[];
  // getFiles: any;
  // //uploadedFiles: boolean = false;
  // indicatorDetailsId: number;
  // selectedDocTypeId: number;
  // selectedDocumentType: IDocumentType;
  // userId: number;
  // _profile: IUser;
  // list: any[];
  // selectedFile: any;
  // selectedFilename: string;

  // selectedApplicationId: string;

  documents: IMyContentLink[];
  filteredDocuments: IMyContentLink[];
  document: IMyContentLink = {} as IMyContentLink;

  displayAddDialog: boolean;
  displayViewDialog: boolean;

  constructor(
    private _spinner: NgxSpinnerService,
    // private _documentStore: DocumentStoreService,
    private _confirmationService: ConfirmationService,
    // private _messageService: MessageService,
    private _dropdownRepo: DropdownService,
    private _loggerService: LoggerService,
    // private http: HttpClient,
    // private fb: FormBuilder,
    // private envUrl: EnvironmentUrlService,
    private _authService: AuthService,
    // private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService
    // private _bidService: BidService,
    // private _router: Router
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this._spinner.show();
        this.profile = profile;

        this.loadDocumentTypes();
      }
    });
    // this.loadfundingDropdowns();
    // this._spinner.show();

    // this._activeRouter.paramMap.subscribe(params => {
    //   this.selectedApplicationId = params.get('id');
    // });
    // this._authService.profile$.subscribe(x => {
    //   if (profile != null && profile.isActive) {

    //   }
    //   if (x) {
    //     this._profile = x;
    //     this.userId = x.id;
    //   }
    // });

    // this._spinner.hide();
    this.documentCols = [
      { field: 'name', header: 'Document Type', width: '70%' },
      { header: 'No. of Linked Document(s)', width: '15%' }
    ];
    // this.uploadedFileCols = [
    //   // { header: '', width: '5%' },
    //   { header: 'Document Type', width: '25%' },
    //   { header: 'Document Name', width: '40%' },
    //   { header: 'Size', width: '10%' },
    //   { header: 'Uploaded Date', width: '10%' },
    //   { header: 'Actions', width: '15%' }
    // ];
    // this.documentTypeCols = [
    //   { header: '', width: '5%' },
    //   { header: 'Document Type', width: '20%' },
    //   { header: 'Document Type Description', width: '75%' }
    // ];

    // this.docTypeNames = [
    //   { name: 'Type1' },
    //   { name: 'Type2' },
    //   { name: 'Type3' },
    //   { name: 'Type4' },
    //   { name: 'Type5' }
    // ];
    // this.loadDocumentTypes();
    // this.loadApplication();
  }

  private loadDocumentTypes() {
    // this._dropdownRepo.GetEntitiesForDoc(DropdownTypeEnum.DocumentTypes, this.application.id, false).subscribe(
    //   (results) => {
    //     this.documentTypes = results.filter(x => x.location === DocumentUploadLocationsEnum.FundApp);
    //   },
    //   (err) => {
    //     this._loggerService.logException(err);
    //     this._spinner.hide();
    //   }
    // );
    this._dropdownRepo.getEntities(DropdownTypeEnum.DocumentTypes, false).subscribe(
      (results) => {
        this.documentTypes = results.filter(x => x.location === DocumentUploadLocationsEnum.QuickCapture);
        this.getMyContentLinks();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private getMyContentLinks() {
    if (this.application) {
      this._applicationRepo.getMyContentLinks(this.application.id).subscribe(
        (results) => {
          this.documents = results;

          this.documents.forEach(item => {
            item.documentType = this.documentTypes.find(x => x.id === item.documentTypeId);
          });

          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
    else {
      this.documents = [];
      this.filteredDocuments = [];
      this._spinner.hide();
    }
  }

  public numberOfLinkedDocuments(documentType: IDocumentType) {
    return this.documents.filter(x => x.documentTypeId === documentType.id).length;
  }

  public view(documentType: IDocumentType) {
    this.filteredDocuments = this.documents.filter(x => x.documentTypeId === documentType.id);
    this.displayViewDialog = true;
  }

  public add(documentType: IDocumentType) {
    this.document = {
      applicationId: this.application.id,
      documentTypeId: documentType.id,
      url: null,
      isActive: true
    } as IMyContentLink;

    this.displayAddDialog = true;
  }

  public disableSave() {
    if (!this.document.url)
      return true;

    return false;
  }

  public save() {
    this._spinner.show();
    this._applicationRepo.createMyContentLink(this.document).subscribe(
      (results) => {
        this.getMyContentLinks();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );

    this.displayAddDialog = false;
  }

  public openDocument(document: IMyContentLink) {
    window.open(document.url, '_blank');
  }

  public deleteDocument(document: IMyContentLink) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        document.isActive = false;
        this.updateDocument(document);
      },
      reject: () => {
      }
    });
  }

  private updateDocument(document: IMyContentLink) {
    this._applicationRepo.updateMyContentLink(document).subscribe(
      (results) => {
        this.getMyContentLinks();
        this.filteredDocuments = this.documents.filter(x => x.documentTypeId === document.documentTypeId && x.isActive);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  // private loadApplication() {
  //   this._spinner.show();
  //   this._applicationRepo.getApplicationById(Number(this.selectedApplicationId)).subscribe(
  //     (results) => {
  //       if (results != null) {
  //         this.application = results;
  //         this._bidService.getApplicationBiId(results.id).subscribe(response => {
  //           if (response.id != null) {
  //             this.getFundingApplicationDetails(response);
  //           }
  //         });
  //       }
  //       this._spinner.hide();
  //     },
  //     (err) => this._spinner.hide()
  //   );
  // }
  // private getFundingApplicationDetails(data) {
  //   this._bidService.getBid(data.id).subscribe(response => {

  //     this.getBidFullObject(response)
  //   });

  // }

  // private getBidFullObject(data) {
  //   this.fundingApplicationDetails = data;
  //   this.fundingApplicationDetails.id = data.id;
  //   this.fundingApplicationDetails.applicationDetails.amountApplyingFor = data.applicationDetails.amountApplyingFor;
  //   this.fundingApplicationDetails.implementations = data.implementations;
  //   if (this.fundingApplicationDetails.projectInformation != null) {
  //     this.fundingApplicationDetails.projectInformation.purposeQuestion = data.projectInformation.purposeQuestion;
  //   }
  //   else {
  //     this.fundingApplicationDetails.projectInformation = {} as IProjectInformation;
  //   }

  //   if (this.fundingApplicationDetails.monitoringEvaluation != null) {
  //     this.fundingApplicationDetails.monitoringEvaluation.monEvalDescription = data.monitoringEvaluation.monEvalDescription;

  //   }
  //   else {
  //     this.fundingApplicationDetails.monitoringEvaluation = {} as IMonitoringAndEvaluation;
  //   }
  //   this.fundingApplicationDetails.financialMatters = data.financialMatters;
  //   this.fundingApplicationDetails.applicationDetails.fundAppSDADetail = data.applicationDetails.fundAppSDADetail;

  //   this.fundingApplicationDetails.implementations?.forEach(c => {

  //     let a = new Date(c.timeframeFrom);
  //     c.timeframe?.push(new Date(c.timeframeTo));
  //     c.timeframe?.push(new Date(c.timeframeFrom))
  //   });

  // }

  // private bidForm(status: StatusEnum) {
  //   this.application.status = null;
  //   if (status === StatusEnum.Saved) {
  //     this.application.statusId = status;
  //   }
  //   if (status === StatusEnum.PendingReview) {
  //     this.application.statusId = status;
  //   }
  //   if (this.bidCanContinue(status)) {
  //     this.application.statusId = status;
  //     if (this.validationErrors.length == 0) {
  //       this._applicationRepo.updateApplication(this.application).subscribe();
  //     }
  //   }
  //   this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
  //   this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });

  //   if (status == StatusEnum.PendingReview) {
  //     this.application.status.name = "PendingReview";
  //     this._router.navigateByUrl('applications');
  //   }

  // }


  // private bidCanContinue(status: StatusEnum) {
  //   this.validationErrors = [];
  //   if (status === StatusEnum.PendingReview)
  //     this.formValidate();
  //   if (this.validationErrors.length == 0)
  //     return true;

  //   return false;
  // }


  // private formValidate() {
  //   this.validationErrors = [];
  // }

  // private clearMessages() {
  //   this.validationErrors = [];
  //   this.menuActions[1].visible = false;
  // }
  // private loadfundingDropdowns() {
  //   this._spinner.show();

  //   this._applicationRepo.getApplicationById(this.newlySavedApplicationId).subscribe(
  //     (results) => {
  //       if (results != null) {
  //         this.application = results;
  //         //this.fundingApplicationDetails.applicationPeriodId = this.application?.applicationPeriodId;
  //       }
  //       this._spinner.hide();
  //     },
  //     (err) => this._spinner.hide()
  //   );
  // }


  // onFilesUpload(event) {

  //   // Iterate over selected files
  //   for (let file of event.target.files) {

  //     // Append to a list
  //     this.list.push({
  //       name: file.name,
  //       type: file.type
  //       // Other specs
  //     });
  //   }
  // }
  // readonly(): boolean {

  //   if (this.application.statusId == StatusEnum.PendingReview ||
  //     this.application.statusId == StatusEnum.Approved)
  //     return true;
  //   else return false;
  // }

  // remove(event, file: File, uploader: FileUpload) {
  //   const index = uploader.files.indexOf(file);
  //   uploader.remove(event, index);
  // }

  // onRowSelect(event) {
  //   if (event.files[0]) {
  //     this.selectedDocTypeId =
  //       event.files[0].documentType.id;
  //   }
  //   else {
  //     this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Please specify the document type.' });
  //   }
  // }
  // onDownloadDocument(doc: any) {
  //   this._confirmationService.confirm({
  //     message: 'Are you sure that you want to download document?',
  //     header: 'Confirmation',
  //     icon: 'pi pi-info-circle',
  //     accept: () => {
  //       this._documentStore.download(doc).subscribe();
  //     },
  //     reject: () => {
  //     }
  //   });
  // }
  // selectCarWithButton(plan: any) {
  //   this.indicatorDetailsId = Number(this.fundingApplicationDetails.id);
  //   this.el.nativeElement.click();
  // }

  // public uploadDocument(doc: any) {
  //   this.selectedDocTypeId = doc.id;
  //   this.element.nativeElement.click();
  // }
  // public uploadedFiles(doc: any) {
  //   this._spinner.show();
  //   this.selectedDocTypeId = doc.id;
  //   this.getFundAppDocuments(doc.id);
  //   this.displayUploadedFilesDialog = true;
  // }

  // public onUploadChange = (files) => {
  //   files[0].documentType = this.documentTypes.find(x => x.location === DocumentUploadLocationsEnum.FundApp);
  //   this._documentStore.upload(files, EntityTypeEnum.SupportingDocuments, Number(this.selectedApplicationId),
  //     EntityEnum.FundingApplicationDetails, this.application.refNo, this.selectedDocTypeId).subscribe(
  //       event => {
  //         if (event.type === HttpEventType.UploadProgress)
  //           this._spinner.show();
  //         else if (event.type === HttpEventType.Response) {
  //           this._spinner.hide();
  //           this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'File successfully uploaded.' });
  //           this.loadDocumentTypes();
  //         }
  //       },
  //       (err) => {
  //         this._loggerService.logException(err);
  //         this._spinner.hide();
  //       }
  //     );
  // }

  // onFileSelected(event) {
  //   this.selectedFile = <File>event.target.files[0];
  //   this.selectedFilename = this.selectedFile.name;
  // }

  // public onUploadChange1 = (event, form) => {
  //   if (event.files[0]) {
  //     this._documentStore.upload(event.files, EntityTypeEnum.SupportingDocuments,
  //       Number(this.fundingApplicationDetails.id), EntityEnum.FundingApplicationDetails,
  //       this.application.refNo, event.files[0].documentType.id).subscribe(
  //         event => {
  //           if (event.type === HttpEventType.UploadProgress)
  //             this._spinner.show();
  //           else if (event.type === HttpEventType.Response) {
  //             this._spinner.hide();
  //             this.getDocuments();
  //           }
  //         },
  //         () => this._spinner.hide()
  //       );
  //     form.clear();
  //   }
  //   else {
  //     this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Please specify the document type.' });
  //   }
  // }

  // public uploadADDocument = (files) => {
  //   if (files.length === 0) {
  //     return;
  //   }
  //   this._spinner.show();
  //   let filesToUpload: File[] = files;
  //   const formData = new FormData();

  //   Array.from(filesToUpload).map((fileAdDoc, index) => {
  //     return formData.append('file' + index, fileAdDoc, fileAdDoc.name);
  //   });

  //   this.http.post(this.envUrl.urlAddress + `/api/documentstore/UploadDocuments?id=` + this.indicatorDetailsId + "&userId=" + this.userId, formData, { reportProgress: true, observe: 'events' })
  //     .subscribe(event => {
  //       if (event.type === HttpEventType.UploadProgress)
  //         this._spinner.show();
  //       else if (event.type === HttpEventType.Response) {
  //         // this.message = 'Uploaded!';

  //         this.downloadButtonColor = 'p-button-success';
  //         this.downloadButtonColor = 'ui-button-info';
  //         this._spinner.hide();
  //         let filesToUpload: File[] = files;
  //         this._messageService.add({ severity: 'success', summary: 'Success', detail: 'File Uploaded' });
  //       }
  //     },

  //       (error) => {
  //         this._loggerService.logException(error);
  //         this._loggerService.logException(error.error);
  //         this._spinner.hide();
  //       });
  // }

  // private getDocuments() {
  //   if (this.fundingApplicationDetails?.id != undefined) {
  //     this._documentStore.get(Number(this.fundingApplicationDetails?.id), EntityTypeEnum.SupportingDocuments).subscribe(
  //       res => {
  //         this.documents = res;
  //         this._spinner.hide();
  //       },
  //       () => this._spinner.hide()
  //     );
  //   }
  // }

  // private getFundAppDocuments(docTypeId: number) {
  //   if (this.selectedApplicationId != undefined) {
  //     this._documentStore.getFundApp(Number(this.selectedApplicationId), docTypeId, EntityTypeEnum.SupportingDocuments).subscribe(
  //       res => {
  //         this.fundAppdocuments = res;
  //         this._spinner.hide();
  //       },
  //       () => this._spinner.hide()
  //     );
  //   }
  // }

  // onDeleteDocument(doc: any) {
  //   this._confirmationService.confirm({
  //     message: 'Are you sure that you want to delete this document?',
  //     header: 'Confirmation',
  //     icon: 'pi pi-info-circle',
  //     accept: () => {
  //       this._spinner.show();

  //       this._documentStore.delete(doc.resourceId).subscribe(
  //         event => {
  //           //this.getDocuments();
  //           this.getFundAppDocuments(this.selectedDocTypeId);
  //           this._spinner.hide();
  //         },
  //         (error) => this._spinner.hide()
  //       );
  //     },
  //     reject: () => {
  //     }
  //   });
  // }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }
  // nextPage() {
  //   this.bidForm(StatusEnum.Saved);
  //   this._messageService.add({ severity: 'success', summary: 'Success', detail: 'File(s) Saved Successfully' });
  //   this._router.navigateByUrl('applications');
  // }
}
