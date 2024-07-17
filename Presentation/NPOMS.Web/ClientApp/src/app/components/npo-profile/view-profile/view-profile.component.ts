import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { AccessStatusEnum, AuditorOrAffiliationEntityTypeEnum, DocumentUploadLocationsEnum, DropdownTypeEnum, EntityEnum, EntityTypeEnum, FacilityTypeEnum, StaffCategoryEnum } from 'src/app/models/enums';
import { IAccountType, IAddressInformation, IAuditorOrAffiliation, IBank, IBankDetail, IBranch, IDocumentStore, IDocumentType, INpoProfile, INpoProfileFacilityList, IProgramBankDetails, IProgramContactInformation, IProgramme, IProgrammeServiceDelivery, IServicesRendered, IStaffCategory, IStaffMemberProfile, ISubProgramme, ISubProgrammeType } from 'src/app/models/interfaces';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-view-profile',
  templateUrl: './view-profile.component.html',
  styleUrls: ['./view-profile.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ViewProfileComponent implements OnInit {

  @Input() npoId: number;
  @Input() source: string;
  @Input() programId: number;
  @Output() retrievedNpoProfile = new EventEmitter<INpoProfile>();

  npoProfile: INpoProfile;
  isDataAvailable: boolean = false;

  stateOptions: any[];
  geographicalDetailCols: any[];
  facilityInfoCols: any[];
  documentCols: any[];
  documentTypeCols: any[];
  serviceRenderedCols: any[];
  bankDetailCols: any[];

  mapping: INpoProfileFacilityList = {} as INpoProfileFacilityList;
  displayFacilityInformationDialog: boolean;

  documents: IDocumentStore[];
  compulsoryDocuments: IDocumentType[] = [];
  nonCompulsoryDocuments: IDocumentType[] = [];

  rowGroupMetadata: any[];

  public get FacilityTypeEnum(): typeof FacilityTypeEnum {
    return FacilityTypeEnum;
  }

  public get StaffCategoryEnum(): typeof StaffCategoryEnum {
    return StaffCategoryEnum;
  }

  // Highlight required fields on validate click
  validated: boolean = true;

  programmes: IProgramme[];
  subProgrammes: ISubProgramme[];
  subProgrammeTypes: ISubProgrammeType[];

  npoProfileFacilityLists: INpoProfileFacilityList[];
  servicesRendered: IServicesRendered[];
  bankDetails: IBankDetail[];

  banks: IBank[];
  branches: IBranch[];
  accountTypes: IAccountType[];

  auditorOrAffiliations: IAuditorOrAffiliation[];
  auditorCols: any[];
  auditorOrAffiliation: IAuditorOrAffiliation = {} as IAuditorOrAffiliation;
  displayAuditorDialog: boolean;

  staffCategories: IStaffCategory[];
  staffMemberProfiles: IStaffMemberProfile[];

  selectedProgram: any;
  displayBankingDetailsPanel: boolean = false;

  contactInformation: IProgramContactInformation = {} as IProgramContactInformation;
  selectedContactInformation: IProgramContactInformation;
  primaryContactInformation: IProgramContactInformation;

  programBankDetails : IProgramBankDetails [];
  programContactInformation: IProgramContactInformation[];
  programBankDetail: IProgramBankDetails = {} as IProgramBankDetails;
  programDeliveryDetails : IProgrammeServiceDelivery [];
  selectedRowIndex: number | null = null;
  headerTitle: string;
  viewHeader:boolean;

  constructor(
    private _spinner: NgxSpinnerService,
    private _npoProfileRepo: NpoProfileService,
    private _documentStore: DocumentStoreService,
    private _dropdownRepo: DropdownService,
    private _confirmationService: ConfirmationService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {

    var splitUrl = window.location.href.split('/');
    this.headerTitle = splitUrl[5];
    if(this.headerTitle === "view")
    {
      this.viewHeader = true;
    }
    

    this.loadDocumentTypes();
    this.loadProgrammes();
    this.loadSubProgrammes();
    this.loadSubProgrammeTypes();
    this.loadBanks();
    this.loadAccountTypes();
    this.loadStaffCategories();
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
      { header: 'Programme', width: '30%' },
      { header: 'Sub-Programme', width: '30%' },
      { header: 'Sub-Programme Type', width: '30%' },
    ];

    this.bankDetailCols = [
      { header: 'Bank', width: '20%' },
      { header: 'Branch', width: '20%' },
      { header: 'Code', width: '20%' },
      { header: 'Account Type', width: '20%' },
      { header: 'Account Number', width: '20%' }
    ];

    this.auditorCols = [
      { header: 'Company', width: '20%' },
      { header: 'Registration Number', width: '15%' },
      { header: 'Address', width: '25%' },
      { header: 'Telephone Number', width: '10%' },
      { header: 'Email Address', width: '25%' },
      { header: 'Actions', width: '5%' }
    ];
  }
  onFirstTdClick(rowIndex: number) {
    if(this.headerTitle !== 'view')
      this.selectedRowIndex = rowIndex;
  }
  toggleBankingDetailsPanel(program: any) {
    // if (this.selectedProgram && this.selectedProgram.id === program.id) {
    //   this.displayBankingDetailsPanel = true;
    // } else {
    //   this.selectedProgram = program;
    //   this.loadProgrammeDetails(program.id);
    //   this.displayBankingDetailsPanel = true;
    // }
    if(this.headerTitle !== 'view')
    {
      this.selectedProgram = program;
      this.loadProgrammeDetails(program.id);
      this.displayBankingDetailsPanel = true;
    }   
  }
  // toggleBankingDetailsPanel(program: any) {
  //   if (this.selectedProgram && this.selectedProgram.id === program.id) {
  //     this.displayBankingDetailsPanel = !this.displayBankingDetailsPanel;
  //   } else {
  //     this.selectedProgram = program;
  //     this.loadProgrammeDetails(program.id);
  //     this.displayBankingDetailsPanel = true;
  //   }
  // }

  getNames(array: any[]): string {
    const names = array.map(item => item.name) // Access 'name' directly
                       .filter(name => name !== undefined && name.trim() !== '') // Filter out undefined or empty strings
                       .join(', '); // Join the names with a comma
  
    return names; // Return the joined names as a string
  }

  loadProgrammeDetails(progId: number): void {
    forkJoin({
      contacts: this._npoProfileRepo.getProgrammeContactsById(progId,Number(this.npoProfile.id)),
      bankDetails: this._npoProfileRepo.getProgrammeBankDetailsById(progId,Number(this.npoProfile.id)),
      deliveryDetails: this._npoProfileRepo.getProgrammeDeliveryDetailsById(progId,Number(this.npoProfile.id))
    }).subscribe({
      next: (result) => {
        this.programContactInformation = result.contacts.filter(contact => contact.approvalStatus.id === AccessStatusEnum.Approved);
        this.programBankDetails = result.bankDetails.filter(bankDetail => bankDetail.approvalStatus.id === AccessStatusEnum.Approved);
        this.programDeliveryDetails = result.deliveryDetails.filter(deliveryDetail => deliveryDetail.approvalStatus.id === AccessStatusEnum.Approved);
        this.updateProgramBankDetailObjects();
      },
      error: (err) => {
        console.error(err);
      }
    });
  }
  

  // loadProgrammeDetails(progId: number): void {
  //   forkJoin({
  //     contacts: this._npoProfileRepo.getProgrammeContactsById(progId),
  //     bankDetails: this._npoProfileRepo.getProgrammeBankDetailsById(progId),
  //     deliveryDetails : this._npoProfileRepo.getProgrammeDeliveryDetailsById(progId)
  //   }).subscribe({
  //     next: (result) => {
  //       this.programContactInformation = result.contacts;
  //       this.programBankDetails = result.bankDetails;
  //       this.programDeliveryDetails = result.deliveryDetails;
  //       this.updateProgramBankDetailObjects();
  //     },
  //     error: (err) => {
  //       console.error(err);
  //     }
  //   });
  // }

  private updateProgramBankDetailObjects() {
    if (this.banks && this.accountTypes && this.programBankDetails) {
      this.programBankDetails.forEach(item => {
        item.bank = this.banks.find(x => x.id === item.bankId);
        this.loadProgrammeBranch(item);
        item.accountType = this.accountTypes.find(x => x.id === item.accountTypeId);
      });
    }
  }

  private loadProgrammeBranch(bankDetail: IProgramBankDetails) {
    this._dropdownRepo.getBranchById(bankDetail.branchId).subscribe(
      (results) => {
        bankDetail.branch = results;
        bankDetail.branchCode = bankDetail.branch.branchCode != null ? bankDetail.branch.branchCode : bankDetail.bank.code;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadStaffCategories() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.StaffCategory, false).subscribe(
      (results) => {
        this.staffCategories = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadNpoProfile() {
    if (this.npoId != null) {
      this._npoProfileRepo.getNpoProfileByNpoId(Number(this.npoId)).subscribe(
        (results) => {
          results.addressInformation = results.addressInformation != null ? results.addressInformation : {} as IAddressInformation;

          this.npoProfile = results;
          this.retrievedNpoProfile.emit(this.npoProfile);
          this.getDocuments();

          this.loadFacilities(this.npoProfile.id);
          this.loadServicesRendered(this.npoProfile.id);
          this.loadBankDetails(this.npoProfile.id);
          this.loadStaffMemberProfiles();

          this.loadAuditorOrAffiliations();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadStaffMemberProfiles() {
    this._npoProfileRepo.getStaffMemberProfilesByNpoProfileId(this.npoProfile.id).subscribe(
      (results) => {
        this.staffMemberProfiles = results ? results : [] as IStaffMemberProfile[];

        this.staffMemberProfiles.forEach(item => {
          item.staffCategory = this.staffCategories.find(x => x.id === item.staffCategoryId);
        });

        let filteredCategories = this.staffCategories.filter(x => x.id !== StaffCategoryEnum.Other);
        let memberProfiles = this.staffMemberProfiles;

        if (this.staffMemberProfiles.length > 0) {
          filteredCategories = filteredCategories.filter(function (category) {
            return !memberProfiles.find(function (profile) {
              return category.id === profile.staffCategoryId;
            });
          });
        }

        filteredCategories.forEach(item => {
          this.staffMemberProfiles.push({
            staffCategoryId: item.id,
            staffCategory: item,
            vacantPosts: 0,
            filledPosts: 0,
            consultantsAppointed: 0,
            staffWithDisabilities: 0,
            africanMale: 0,
            africanFemale: 0,
            indianMale: 0,
            indianFemale: 0,
            colouredMale: 0,
            colouredFemale: 0,
            whiteMale: 0,
            whiteFemale: 0,
            otherSpecify: null
          } as IStaffMemberProfile);
        });

        //Sort Staff Member Profiles by Staff Category Id
        this.staffMemberProfiles.sort((a, b) => a.staffCategoryId - b.staffCategoryId);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  get totalStaffMemberProfile() {
    let totals = {
      vacantPosts: 0,
      filledPosts: 0,
      consultantsAppointed: 0,
      staffWithDisabilities: 0,
      africanMale: 0,
      africanFemale: 0,
      indianMale: 0,
      indianFemale: 0,
      colouredMale: 0,
      colouredFemale: 0,
      whiteMale: 0,
      whiteFemale: 0
    } as IStaffMemberProfile;

    this.staffMemberProfiles.forEach(item => {
      totals.vacantPosts += item.vacantPosts;
      totals.filledPosts += item.filledPosts;
      totals.consultantsAppointed += item.consultantsAppointed;
      totals.staffWithDisabilities += item.staffWithDisabilities;
      totals.africanMale += item.africanMale;
      totals.africanFemale += item.africanFemale;
      totals.indianMale += item.indianMale;
      totals.indianFemale += item.indianFemale;
      totals.colouredMale += item.colouredMale;
      totals.colouredFemale += item.colouredFemale;
      totals.whiteMale += item.whiteMale;
      totals.whiteFemale += item.whiteFemale;
    });

    return totals;
  }

  private loadAuditorOrAffiliations() {
    this._npoProfileRepo.getAuditorOrAffiliations(this.npoProfile.id).subscribe(
      (results) => {
        this.auditorOrAffiliations = results.filter(x => x.entityType === AuditorOrAffiliationEntityTypeEnum.Auditor);
        this.isDataAvailable = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadFacilities(npoProfileId: number) {
    this._npoProfileRepo.getFacilitiesByNpoProfileId(npoProfileId).subscribe(
      (results) => {
        this.npoProfileFacilityLists = results;
        this.updateRowGroupMetaData();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadServicesRendered(npoProfileId: number) {
    this._npoProfileRepo.getServicesRenderedByNpoProfileId(npoProfileId, this.source).subscribe(
      (results) => {
        this.servicesRendered = results;
        if(this.programId != null && this.programId > 0)
        {
            this.servicesRendered = results.filter(service => service.programmeId === this.programId);
        }
        this.updateServicesRenderedObjects();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadBankDetails(npoProfileId: number) {
    this._npoProfileRepo.getBankDetailByNpoProfileId(npoProfileId).subscribe(
      (results) => {
        this.bankDetails = results;
        this.updateBankDetailObjects();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateServicesRenderedObjects() {
    if (this.npoProfile && this.programmes && this.subProgrammes && this.subProgrammeTypes && this.servicesRendered) {
      this.servicesRendered.forEach(item => {
        item.programme = this.programmes.find(x => x.id === item.programmeId);
        item.subProgramme = this.subProgrammes.find(x => x.id === item.subProgrammeId);
        item.subProgrammeType = this.subProgrammeTypes.find(x => x.id === item.subProgrammeTypeId);
      });

      this.servicesRendered.sort((a, b) => a.programme.name.localeCompare(b.programme.name));
    }
  }

  private updateBankDetailObjects() {
    if (this.npoProfile && this.banks && this.accountTypes && this.bankDetails) {
      this.bankDetails.forEach(item => {
        item.bank = this.banks.find(x => x.id === item.bankId);
        this.loadBranch(item);
        item.accountType = this.accountTypes.find(x => x.id === item.accountTypeId);
      });
    }
  }

  private loadBranch(bankDetail: IBankDetail) {
    this._dropdownRepo.getBranchById(bankDetail.branchId).subscribe(
      (results) => {
        bankDetail.branch = results;
        bankDetail.branchCode = bankDetail.branch.branchCode != null ? bankDetail.branch.branchCode : bankDetail.bank.code;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private getDocuments() {
    this._documentStore.get(Number(this.npoProfile.id), EntityTypeEnum.SupportingDocuments).subscribe(
      res => {
        this.documents = res.filter(x => x.entity === EntityEnum.NpoProfile);
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
        this.compulsoryDocuments = results.filter(x => x.isCompulsory === true && x.location === DocumentUploadLocationsEnum.NpoProfile);
        this.nonCompulsoryDocuments = results.filter(x => x.isCompulsory === false && x.location === DocumentUploadLocationsEnum.NpoProfile);
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
        this.updateServicesRenderedObjects();
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
        this.updateServicesRenderedObjects();
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
        this.updateServicesRenderedObjects();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadBanks() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Banks, false).subscribe(
      (results) => {
        this.banks = results;
        this.updateBankDetailObjects();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadAccountTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.AccountTypes, false).subscribe(
      (results) => {
        this.accountTypes = results;
        this.updateBankDetailObjects();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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

    this.npoProfileFacilityLists = this.npoProfileFacilityLists.sort((a, b) => a.facilityList.facilityType.id - b.facilityList.facilityType.id);

    if (this.npoProfileFacilityLists) {

      this.npoProfileFacilityLists.forEach(element => {

        var itemExists = this.rowGroupMetadata.some(function (data) { return data.itemName === element.facilityList.facilityType.name });

        this.rowGroupMetadata.push({
          itemName: element.facilityList.facilityType.name,
          itemExists: itemExists
        });
      });
    }
  }

  public viewAuditorInformation(data: IAuditorOrAffiliation) {
    this.auditorOrAffiliation = this.cloneAuditorOrAffiliation(data);
    this.displayAuditorDialog = true;
  }

  private cloneAuditorOrAffiliation(data: IAuditorOrAffiliation): IAuditorOrAffiliation {
    let object = {} as IAuditorOrAffiliation;

    for (let prop in data)
      object[prop] = data[prop];

    return object;
  }
}
