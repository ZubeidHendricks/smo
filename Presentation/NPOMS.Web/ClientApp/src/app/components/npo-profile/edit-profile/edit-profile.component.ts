import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { Subscription } from 'rxjs';
import { AccessStatusEnum, DropdownTypeEnum, EntityEnum, EntityTypeEnum, FacilityTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IAddressInformation, IAddressLookup, IDenodoFacility, IDocumentStore, IDocumentType, IFacilityClass, IFacilityDistrict, IFacilityList, IFacilitySubDistrict, IFacilityType, INpo, INpoProfile, INpoProfileFacilityList, IUser } from 'src/app/models/interfaces';
import { AddressLookupService } from 'src/app/services/api-services/address-lookup/address-lookup.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class EditProfileComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get FacilityTypeEnum(): typeof FacilityTypeEnum {
    return FacilityTypeEnum;
  }

  npo: INpo;
  npoProfile: INpoProfile;

  menuActions: MenuItem[];
  profile: IUser;

  validationErrors: Message[];
  stateOptions: any[];

  npoProfileId: string;
  paramSubcriptions: Subscription;

  isDataAvailable: boolean = false;

  newAddress: IAddressLookup[];
  physicalAddressLookup: IAddressLookup;
  postalAddressLookup: IAddressLookup;
  addressLookup: IAddressLookup;

  facilityInfoCols: any[];
  displayFacilityInformationDialog: boolean;
  isFacilityInformationEdit: boolean;
  newFacilityInformation: boolean;
  mapping: INpoProfileFacilityList = {} as INpoProfileFacilityList;
  selectedMapping: INpoProfileFacilityList;

  facilityDistricts: IFacilityDistrict[];
  selectedDistrict: IFacilityDistrict;
  allFacilitySubDistricts: IFacilitySubDistrict[];
  facilitySubDistricts: IFacilitySubDistrict[];
  selectedSubDistrict: IFacilitySubDistrict;
  facilityClasses: IFacilityClass[];
  selectedClass: IFacilityClass;
  facilityTypes: IFacilityType[];
  selectedFacilityType: IFacilityType;

  denodoFacilities: IDenodoFacility[];
  selectedDenodoFacility: IDenodoFacility;
  facilityList: IFacilityList[] = [];

  disableField: boolean = true;

  documents: IDocumentStore[] = [];
  documentCols: any[];
  documentTypeCols: any[];
  documentTypes: IDocumentType[] = [];
  compulsoryDocuments: IDocumentType[] = [];
  nonCompulsoryDocuments: IDocumentType[] = [];

  rowGroupMetadata: any[];

  // Highlight required fields on validate click
  validated: boolean = false;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _addressLookupService: AddressLookupService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _confirmationService: ConfirmationService,
    private _npoProfileRepo: NpoProfileService,
    private _activeRouter: ActivatedRoute,
    private _documentStore: DocumentStoreService,
    private _npoRepo: NpoService,
    private _messageService: MessageService
  ) { }

  ngOnInit(): void {
    this._spinner.show();
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.npoProfileId = params.get('id');
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.EditNpoProfile))
          this._router.navigate(['401']);

        this.loadFacilityDistricts();
        this.loadFacilitySubDistricts();
        this.loadFacilityClasses();
        this.loadFacilityTypes();
        this.loadDocumentTypes();
        this.loadNpoProfile();
        this.buildMenu();
      }
    });

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
      { header: 'Sub-District', width: '18%' },
      { header: 'Facility or Community Place Name', width: '30%' },
      { header: 'Class', width: '15%' },
      { header: 'Address', width: '30%' }
    ];

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
  }

  private loadFacilityDistricts() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilityDistricts, false).subscribe(
      (results) => {
        this.facilityDistricts = results;
      },
      (err) => this._spinner.hide()
    );
  }

  private loadFacilitySubDistricts() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilitySubDistricts, false).subscribe(
      (results) => {
        this.allFacilitySubDistricts = results;
      },
      (err) => this._spinner.hide()
    );
  }

  private loadFacilityClasses() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilityClasses, false).subscribe(
      (results) => {
        this.facilityClasses = results;
      },
      (err) => this._spinner.hide()
    );
  }

  private loadFacilityTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilityTypes, false).subscribe(
      (results) => {
        this.facilityTypes = results;
      },
      (err) => this._spinner.hide()
    );
  }

  private loadDocumentTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.DocumentTypes, false).subscribe(
      (results) => {
        this.compulsoryDocuments = results.filter(x => x.isCompulsory === true && x.name.indexOf('SLA') === -1);
        this.nonCompulsoryDocuments = results.filter(x => x.isCompulsory === false);
        this.documentTypes = results.filter(x => x.name.indexOf('SLA') === -1);
      },
      (err) => this._spinner.hide()
    );
  }

  private loadNpoProfile() {
    if (this.npoProfileId != null) {
      this._npoProfileRepo.getNpoProfileById(Number(this.npoProfileId)).subscribe(
        (results) => {
          results.addressInformation = results.addressInformation != null ? results.addressInformation : {} as IAddressInformation;
          /*this.physicalAddressLookup = { text: results.addressInformation.physicalAddress, magicKey: null };
          this.postalAddressLookup = { text: results.addressInformation.postalAddress, magicKey: null };*/

          this.npoProfile = results;
          this.isDataAvailable = true;
          this.updateRowGroupMetaData();
          this.getDocuments();
          this._spinner.hide();
        },
        (err) => this._spinner.hide()
      );
    }
  }

  private buildMenu() {
    if (this.profile) {
      this.menuActions = [
        {
          label: 'Validate',
          icon: 'fa fa-check',
          command: () => {
            this.formValidate();
          },
          visible: false
        },
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
            this.saveItems();
          }
        },
        {
          label: 'Go Back',
          icon: 'fa fa-step-backward',
          command: () => {
            this._router.navigateByUrl('npo-profiles');
          }
        }
      ];
    }
  }

  private getDocuments() {
    this._documentStore.get(Number(this.npoProfileId), EntityTypeEnum.SupportingDocuments).subscribe(
      res => {
        this.documents = res;
      },
      (err) => this._spinner.hide()
    );
  }

  private formValidate() {
    this.validated = true;
    this.validationErrors = [];

    let data = this.npoProfile;

    if (!this.npo.name || !this.npo.organisationTypeId)
      this.validationErrors.push({ severity: 'error', summary: "General Information:", detail: "Missing detail required. This can be updated on the Organisations tab." });

    if (this.npo.contactInformation.length === 0)
      this.validationErrors.push({ severity: 'error', summary: "Contact Information:", detail: "The Organisation Contact List cannot be empty. This can be updated on the Organisations tab." });

    if (!data.addressInformation.physicalAddress || !data.addressInformation.postalSameAsPhysical || !data.addressInformation.postalAddress)
      this.validationErrors.push({ severity: 'error', summary: "Address Information:", detail: "Missing detail required." });

    // if (data.geographicalDetails.length === 0)
    //   this.validationErrors.push({ severity: 'error', summary: "Service Delivery Area:", detail: "The Service Devivery Area table cannot be empty." });

    if (data.npoProfileFacilityLists.length === 0)
      this.validationErrors.push({ severity: 'error', summary: "Facility Information:", detail: "The Facility Information table cannot be empty." });

    if (this.compulsoryDocuments.length > 0) {
      if (this.documents.length > 0) {
        var documentTypeNotSelected = this.documents.some(function (document) { return document.documentType === null });

        if (documentTypeNotSelected)
          this.validationErrors.push({ severity: 'warn', summary: "Supporting Documents:", detail: "Please ensure the relevant document type is selected for all supporting documents." });
        else {
          let canContinue: boolean[] = [];

          this.compulsoryDocuments.forEach(item => {
            var isPresent = this.documents.some(function (document) { return document.documentType.id === item.id });
            canContinue.push(isPresent);
          });

          if (canContinue.includes(false))
            this.validationErrors.push({ severity: 'warn', summary: "Supporting Documents:", detail: "Please upload all compulsory supporting documents." });
        }
      }
      else
        this.validationErrors.push({ severity: 'error', summary: "Supporting Documents:", detail: "Please upload the necessary supporting documentation." });
    }

    if (this.validationErrors.length == 0)
      this.menuActions[1].visible = false;
    else
      this.menuActions[1].visible = true;
  }

  private clearMessages() {
    this.validated = false;
    this.validationErrors = [];
    this.menuActions[1].visible = false;
  }

  private saveItems() {
    if (this.canContinue()) {
      this._spinner.show();
      let data = this.npoProfile;
      let currentDate = new Date();

      /*data.addressInformation.physicalAddress = this.physicalAddressLookup ? this.physicalAddressLookup.text : "";
      data.addressInformation.postalAddress = this.postalAddressLookup ? this.postalAddressLookup.text : "";*/
      data.addressInformation.createdUserId = this.profile.id;
      data.addressInformation.createdDateTime = currentDate;

      data.npoProfileFacilityLists.forEach(item => {
        item.facilityList.facilitySubDistrictId = item.facilityList.facilitySubDistrict.id;
        item.facilityList.facilityClassId = item.facilityList.facilityClass.id;
      });

      this._dropdownRepo.createFacilityList(this.facilityList).subscribe(resp => {

        this.npo.approvalStatusId = AccessStatusEnum.Pending;
        this.npo.approvalUserId = null;
        this.npo.approvalDateTime = null;

        this._npoRepo.updateNpo(this.npo).subscribe(resp => {
          this._npoProfileRepo.updateNpoProfile(data).subscribe(resp => {
            this._spinner.hide();
            this._router.navigateByUrl('npo-profiles');
          });
        });
      });
    }
  }

  private canContinue() {
    this.formValidate();

    if (this.validationErrors.length == 0)
      return true;

    return false;
  }

  filterCountrySingle(event) {
    let query = event.query;

    this._addressLookupService.getAddress(query).subscribe((d) => {
      this.newAddress = d['suggestions'];
    });
  }

  updatePostalAddress(event) {
    if (event.value === true) {
      this.postalAddressLookup = this.physicalAddressLookup;
      this.npoProfile.addressInformation.postalAddress = this.npoProfile.addressInformation.physicalAddress;
    }

    if (event.value === false) {
      this.postalAddressLookup = null;
      this.npoProfile.addressInformation.postalAddress = null;
    }
  }

  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }

  updateNpo(event) {
    this.npo = event
  }

  addFacilityInformation() {
    this.isFacilityInformationEdit = false;
    this.newFacilityInformation = true;

    this.mapping = {
      facilityList: {
        facilityFound: true,
      } as IFacilityList
    } as INpoProfileFacilityList;

    this.selectedFacilityType = null;
    this.selectedDenodoFacility = null;
    this.selectedDistrict = null;
    this.selectedSubDistrict = null;
    this.selectedClass = null;
    this.addressLookup = null;

    this.displayFacilityInformationDialog = true;
  }

  disableSaveFacilityInformation() {
    if (!this.mapping.facilityList.name || !this.selectedDistrict || !this.selectedSubDistrict)
      return true;

    if (this.selectedFacilityType.id === FacilityTypeEnum.Facility && this.mapping.facilityList.facilityFound === false) {
      if (!this.selectedClass || !this.mapping.facilityList.address)
        return true;
    }

    return false;
  }

  saveFacilityInformation() {
    this.mapping.facilityList.facilityType = this.selectedFacilityType;

    if (!this.mapping.facilityList.facilityFound) {
      this.mapping.facilityList.facilitySubDistrict = this.selectedSubDistrict;
      this.mapping.facilityList.facilitySubDistrict.facilityDistrict = this.selectedDistrict;
      this.mapping.facilityList.facilityClass = this.selectedClass;
      //this.mapping.facilityList.address = this.addressLookup ? this.addressLookup.text : null;

      this.facilityList.push({
        facilityType: this.mapping.facilityList.facilityType,
        facilityTypeId: this.mapping.facilityList.facilityType.id,
        facilitySubDistrict: this.mapping.facilityList.facilitySubDistrict,
        facilitySubDistrictId: this.mapping.facilityList.facilitySubDistrict.id,
        name: this.mapping.facilityList.name,
        facilityClass: this.mapping.facilityList.facilityClass,
        facilityClassId: this.mapping.facilityList.facilityClass.id,
        latitude: this.mapping.facilityList.latitude,
        longitude: this.mapping.facilityList.longitude,
        address: this.mapping.facilityList.address,
        isNew: true,
        isActive: true
      } as IFacilityList);
    }

    if (this.newFacilityInformation)
      this.npoProfile.npoProfileFacilityLists.push({
        npoProfileId: this.npoProfile.id,
        facilityList: this.mapping.facilityList
      } as INpoProfileFacilityList);
    else
      this.npoProfile.npoProfileFacilityLists[this.npoProfile.npoProfileFacilityLists.indexOf(this.selectedMapping)] = this.mapping;

    this.updateRowGroupMetaData();
    this.displayFacilityInformationDialog = false;
  }

  editFacilityInformation(data: INpoProfileFacilityList) {
    this.selectedMapping = data;
    this.isFacilityInformationEdit = true;
    this.newFacilityInformation = false;
    this.mapping = this.cloneFacilityInformation(data);
    this.displayFacilityInformationDialog = true;
  }

  private cloneFacilityInformation(data: INpoProfileFacilityList) {
    let mapping = {} as INpoProfileFacilityList;
    data.facilityList.facilityFound = !data.facilityList.isNew;

    this.disableField = data.facilityList.facilityFound ? true : false;

    for (let prop in data)
      mapping[prop] = data[prop];

    this.selectedFacilityType = data.facilityList.facilityType;
    this.selectedDistrict = data.facilityList.facilitySubDistrict.facilityDistrict;
    this.districtChange(this.selectedDistrict);
    this.selectedSubDistrict = this.facilitySubDistricts.find(x => x.id === data.facilityList.facilitySubDistrictId);
    this.selectedClass = data.facilityList.facilityClass;
    //this.addressLookup = { text: data.facilityList.address, magicKey: null };

    return mapping;
  }

  deleteFacilityInformation(data: INpoProfileFacilityList) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.npoProfile.npoProfileFacilityLists.forEach(function (item, index, object) {
          if (data === item)
            object.splice(index, 1);
        });
      },
      reject: () => {
      }
    });
  }

  search(event) {
    let query = event.query;
    this._dropdownRepo.getFacilityByName(query).subscribe((results) => {
      this.denodoFacilities = results.elements;
    });
  }

  selectDenodoFacility(denodoFacility: IDenodoFacility, initialSelect: boolean) {
    this.selectedDistrict = this.facilityDistricts.find(x => x.name === denodoFacility.district);
    this.districtChange(this.selectedDistrict);
    this.selectedSubDistrict = this.facilitySubDistricts.find(x => x.name === denodoFacility.sub_district);
    this.selectedClass = this.facilityClasses.find(x => x.name === denodoFacility.classification);
    //this.addressLookup = { text: "", magicKey: "" } as IAddressLookup;

    this.mapping.facilityList.name = denodoFacility.name;
    this.mapping.facilityList.facilitySubDistrict = this.selectedSubDistrict;
    this.mapping.facilityList.facilityClass = this.selectedClass;
    //this.mapping.facilityList.address = this.addressLookup ? this.addressLookup.text : "";

    if (initialSelect) {
      this.facilityList.push({
        facilityType: this.selectedFacilityType,
        facilityTypeId: this.selectedFacilityType.id,
        facilitySubDistrict: this.selectedSubDistrict,
        facilitySubDistrictId: this.selectedSubDistrict.id,
        name: denodoFacility.name,
        facilityClass: this.selectedClass,
        facilityClassId: this.selectedClass.id,
        latitude: denodoFacility.latitude,
        longitude: denodoFacility.longitude,
        address: null,
        isNew: false,
        isActive: true
      } as IFacilityList);
    }
  }

  districtChange(district: IFacilityDistrict) {
    this.selectedSubDistrict = null;
    this.facilitySubDistricts = [];

    if (district.id != null) {
      for (var i = 0; i < this.allFacilitySubDistricts.length; i++) {
        if (this.allFacilitySubDistricts[i].facilityDistrictId == district.id) {
          this.facilitySubDistricts.push(this.allFacilitySubDistricts[i]);
        }
      }
    }
  }

  facilityFoundChange(value) {
    this.disableField = value;

    if (value === true && this.selectedDenodoFacility != null) {
      this.mapping.facilityList.isNew = !value;
      this.selectDenodoFacility(this.selectedDenodoFacility, false);
    }
    else {
      this.mapping.facilityList.isNew = !value;
      this.mapping.facilityList.name = null;
      this.mapping.facilityList.address = null;

      this.selectedDistrict = null;
      this.selectedSubDistrict = null;
      this.selectedClass = null;
      this.addressLookup = null;
    }
  }

  public onUploadChange = (event, form) => {
    if (event.files[0].documentType) {
      this._documentStore.upload(event.files, EntityTypeEnum.SupportingDocuments, Number(this.npoProfile.id), EntityEnum.NpoProfile, this.npoProfile.refNo, event.files[0].documentType.id).subscribe(
        event => {
          if (event.type === HttpEventType.UploadProgress)
            this._spinner.show();
          else if (event.type === HttpEventType.Response) {
            this._spinner.hide();
            this.getDocuments();
          }
        },
        (error) => this._spinner.hide()
      );
      form.clear();
    }
    else {
      this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Please specify the document type.' });
    }
  }

  remove(event, file: File, uploader: FileUpload) {
    const index = uploader.files.indexOf(file);
    uploader.remove(event, index);
  }

  /*documentTypeChange(document: IDocumentStore, documentType: IDocumentType) {
    document.documentType = null;
    document.documentTypeId = documentType.id;

    this._documentStore.update(document).subscribe(resp => {
      this.getDocuments();
    });
  }*/

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

  facilityTypeChange(facilityType: IFacilityType) {
    if (facilityType.id === FacilityTypeEnum.Community)
      this.mapping.facilityList.facilityFound = false;
    else
      this.mapping.facilityList.facilityFound = true;

    this.selectedDenodoFacility = null;
    this.selectedDistrict = null;
    this.selectedSubDistrict = null;
    this.selectedClass = null;
    this.addressLookup = null;

    this.facilityFoundChange(true);

    if (facilityType.id === FacilityTypeEnum.Community)
      this.selectedClass = this.facilityClasses.find(x => x.id === 4);
  }

  private updateRowGroupMetaData() {
    this.rowGroupMetadata = [];

    this.npoProfile.npoProfileFacilityLists = this.npoProfile.npoProfileFacilityLists.sort((a, b) => a.facilityList.facilityType.id - b.facilityList.facilityType.id);

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

  populateAddressField(event, field) {
    if (field === 'physicalAddress')
      this.npoProfile.addressInformation.physicalAddress = event.text;

    if (field === 'postalAddress')
      this.npoProfile.addressInformation.postalAddress = event.text;

    if (field === 'facilityAddress')
      this.mapping.facilityList.address = event.text;
  }
}
