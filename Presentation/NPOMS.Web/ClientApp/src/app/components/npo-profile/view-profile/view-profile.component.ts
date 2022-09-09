import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DropdownTypeEnum, EntityTypeEnum, FacilityTypeEnum } from 'src/app/models/enums';
import { IAddressInformation, IDocumentStore, IDocumentType, INpoProfile, INpoProfileFacilityList, IProgramme, ISubProgramme, ISubProgrammeType } from 'src/app/models/interfaces';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ViewProfileComponent implements OnInit {

  @Input() npoId: number;
  @Output() retrievedNpoProfile = new EventEmitter<INpoProfile>();

  npoProfile: INpoProfile;
  isDataAvailable: boolean = false;

  stateOptions: any[];
  geographicalDetailCols: any[];
  facilityInfoCols: any[];
  documentCols: any[];
  documentTypeCols: any[];
  serviceRenderedCols: any[];

  mapping: INpoProfileFacilityList = {} as INpoProfileFacilityList;
  displayFacilityInformationDialog: boolean;

  documents: IDocumentStore[];
  compulsoryDocuments: IDocumentType[] = [];
  nonCompulsoryDocuments: IDocumentType[] = [];

  rowGroupMetadata: any[];

  public get FacilityTypeEnum(): typeof FacilityTypeEnum {
    return FacilityTypeEnum;
  }

  // Highlight required fields on validate click
  validated: boolean = true;

  programmes: IProgramme[];
  subProgrammes: ISubProgramme[];
  subProgrammeTypes: ISubProgrammeType[];

  constructor(
    private _spinner: NgxSpinnerService,
    private _npoProfileRepo: NpoProfileService,
    private _documentStore: DocumentStoreService,
    private _dropdownRepo: DropdownService,
    private _confirmationService: ConfirmationService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this.loadDocumentTypes();
    this.loadProgrammes();
    this.loadSubProgrammes();
    this.loadSubProgrammeTypes();
    this.loadNpoProfile();

    this.stateOptions = [
      {
        label: 'Yes',
        value: true
      },
      {
        label: 'No',
        value: false
      }
    ];

    this.facilityInfoCols = [
      { header: 'Sub-District', width: '20%' },
      { header: 'Facility or Community Place Name', width: '30%' },
      { header: 'Class', width: '15%' },
      { header: 'Address', width: '30%' },
      { header: 'Actions', width: '5%' }
    ];

    this.documentCols = [
      { header: '', width: '5%' },
      { header: 'Document Name', width: '45%' },
      { header: 'Document Type', width: '25%' },
      { header: 'Size', width: '10%' },
      { header: 'Uploaded Date', width: '10%' },
      { header: 'Actions', width: '5%' }
    ];

    this.documentTypeCols = [
      { header: '', width: '5%' },
      { header: 'Document Type', width: '20%' },
      { header: 'Document Type Description', width: '75%' }
    ];

    this.serviceRenderedCols = [
      { header: 'Programme', width: '34%' },
      { header: 'Sub-Programme', width: '33%' },
      { header: 'Sub-Programme Type', width: '33%' }
    ];
  }

  private loadNpoProfile() {
    if (this.npoId != null) {
      this._npoProfileRepo.getNpoProfileByNpoId(Number(this.npoId)).subscribe(
        (results) => {
          results.addressInformation = results.addressInformation != null ? results.addressInformation : {} as IAddressInformation;

          this.npoProfile = results;
          this.updateNpoProfile();

          this.retrievedNpoProfile.emit(this.npoProfile);

          this.isDataAvailable = true;
          this.updateRowGroupMetaData();
          this.getDocuments();
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private getDocuments() {
    this._documentStore.get(Number(this.npoProfile.id), EntityTypeEnum.SupportingDocuments).subscribe(
      res => {
        this.documents = res;
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
        this.compulsoryDocuments = results.filter(x => x.isCompulsory === true && x.name.indexOf('SLA') === -1 && x.name.indexOf('Evidence') === -1);
        this.nonCompulsoryDocuments = results.filter(x => x.isCompulsory === false && x.name.indexOf('SLA') === -1 && x.name.indexOf('Evidence') === -1);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
      (results) => {
        this.programmes = results;
        this.updateNpoProfile();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSubProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
      (results) => {
        this.subProgrammes = results;
        this.updateNpoProfile();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSubProgrammeTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgrammeTypes, false).subscribe(
      (results) => {
        this.subProgrammeTypes = results;
        this.updateNpoProfile();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateNpoProfile() {
    if (this.npoProfile && this.programmes && this.subProgrammes && this.subProgrammeTypes) {
      this.npoProfile.servicesRendered.forEach(item => {
        item.programme = this.programmes.find(x => x.id === item.programmeId);
        item.subProgramme = this.subProgrammes.find(x => x.id === item.subProgrammeId);
        item.subProgrammeType = this.subProgrammeTypes.find(x => x.id === item.subProgrammeTypeId);
      });

      this.npoProfile.servicesRendered.sort((a, b) => a.programme.name.localeCompare(b.programme.name));
    }
  }

  viewFacilityInformation(data: INpoProfileFacilityList) {
    this.mapping = data;
    this.mapping.facilityList.facilityFound = !data.facilityList.isNew;
    this.displayFacilityInformationDialog = true;
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

  private updateRowGroupMetaData() {
    this.rowGroupMetadata = [];

    this.npoProfile.npoProfileFacilityLists = this.npoProfile.npoProfileFacilityLists.sort((a, b) => a.facilityList.facilityTypeId - b.facilityList.facilityTypeId);

    if (this.npoProfile.npoProfileFacilityLists) {

      this.npoProfile.npoProfileFacilityLists.forEach(element => {

        var itemExists = this.rowGroupMetadata.some(function (data) { return data.itemName === element.facilityList.facilityType.name });

        this.rowGroupMetadata.push({
          itemName: element.facilityList.facilityType.name,
          itemExists: itemExists
        });
      });
    }
  }
}
