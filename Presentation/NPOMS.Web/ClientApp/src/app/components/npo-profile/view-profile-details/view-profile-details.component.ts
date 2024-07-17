import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService } from 'primeng/api';
import { Subscription, forkJoin } from 'rxjs';
import { AccessStatusEnum, AuditorOrAffiliationEntityTypeEnum, DocumentUploadLocationsEnum, DropdownTypeEnum, EntityEnum, EntityTypeEnum, FacilityTypeEnum, PermissionsEnum, StaffCategoryEnum } from 'src/app/models/enums';
import { IAccountType, IAddressInformation, IAuditorOrAffiliation, IBank, IBankDetail, IBranch, IDocumentStore, IDocumentType, INpo, INpoProfile, INpoProfileFacilityList, IProgramBankDetails, IProgramContactInformation, IProgramme, IProgrammeServiceDelivery, IServicesRendered, IStaffCategory, IStaffMemberProfile, ISubProgramme, ISubProgrammeType, IUser } from 'src/app/models/interfaces';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { UserService } from 'src/app/services/api-services/user/user.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-view-profile-details',
  templateUrl: './view-profile-details.component.html',
  styleUrls: ['./view-profile-details.component.css']
})
export class ViewProfileDetailsComponent implements OnInit {
  selectedRowIndex: number | null = null;
  selectedProgram: any;
  displayBankingDetailsPanel: boolean = false;

  contactInformation: IProgramContactInformation = {} as IProgramContactInformation;
  selectedContactInformation: IProgramContactInformation;
  primaryContactInformation: IProgramContactInformation;

  programBankDetails : IProgramBankDetails [];
  programContactInformation: IProgramContactInformation[];
  programBankDetail: IProgramBankDetails = {} as IProgramBankDetails;
  programDeliveryDetails : IProgrammeServiceDelivery [];

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  profile: IUser;

  npoProfileId: string;
  paramSubcriptions: Subscription;

  npo: INpo;
  npoProfile: INpoProfile;
  isDataAvailable: boolean;

  stateOptions: any[];
  facilityInfoCols: any[];
  documentCols: any[];
  documentTypeCols: any[];
  serviceRenderedCols: any[];
  bankDetailCols: any[];
  auditorCols: any[];

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
  auditorOrAffiliation: IAuditorOrAffiliation = {} as IAuditorOrAffiliation;
  displayAuditorDialog: boolean;

  staffCategories: IStaffCategory[];
  staffMemberProfiles: IStaffMemberProfile[];
  source: string = 'NpoProfile';

  constructor(
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _authService: AuthService,
    private _router: Router,
    private _npoProfileRepo: NpoProfileService,
    private _documentStore: DocumentStoreService,
    private _dropdownRepo: DropdownService,
    private _confirmationService: ConfirmationService,
    private _loggerService: LoggerService,
    private _userRepo: UserService
  ) { }

  ngOnInit(): void {
    this._spinner.show();
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.npoProfileId = params.get('id');
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewNpoProfiles))
          this._router.navigate(['401']);

        this.loadDocumentTypes();
        this.loadProgrammes();
        this.loadSubProgrammes();
        this.loadSubProgrammeTypes();
        this.loadBanks();
        this.loadAccountTypes();
        this.loadStaffCategories();
        this.loadNpoProfile();
      }
    });

    this.stateOptions = [
      { label: 'Yes', value: true },
      { label: 'No', value: false }
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

  onFirstTdClick(rowIndex: number) {
    this.selectedRowIndex = rowIndex;
  }
  toggleBankingDetailsPanel(program: any) {
    this.selectedProgram = program;
    this.loadProgrammeDetails(program.id);
    this.displayBankingDetailsPanel = true;
  }

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

  private loadNpoProfile() {
    if (this.npoProfileId != null) {
      this._npoProfileRepo.getNpoProfileById(Number(this.npoProfileId)).subscribe(
        (results) => {
          results.addressInformation = results.addressInformation != null ? results.addressInformation : {} as IAddressInformation;

          this.npoProfile = results;
          this.getDocuments();

          this.loadFacilities(this.npoProfile.id);
          this.loadServicesRendered(this.npoProfile.id);
          this.loadBankDetails(this.npoProfile.id);
          this.loadStaffMemberProfiles();

          this.loadAuditorOrAffiliations();
          this.loadCreatedUser();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadCreatedUser() {
    this._userRepo.getUserById(this.npoProfile.createdUserId).subscribe(
      (results) => {
        this.npoProfile.createdUser = results;
        this.loadUpdatedUser();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadUpdatedUser() {
    if (this.npoProfile.updatedUserId) {
      this._userRepo.getUserById(this.npoProfile.updatedUserId).subscribe(
        (results) => {
          this.npoProfile.updatedUser = results;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
    else {
      this.npoProfile.updatedUser = {} as IUser;
      this._spinner.hide();
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
    this._npoProfileRepo.getServicesRenderedByNpoProfileId(npoProfileId,this.source).subscribe(
      (results) => {
        this.servicesRendered = results;
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

  updateNpo(event) {
    this.npo = event
  }
}
