import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { Subscription } from 'rxjs';
import { AccessStatusEnum, AuditorOrAffiliationEntityNameEnum, AuditorOrAffiliationEntityTypeEnum, DocumentUploadLocationsEnum, DropdownTypeEnum, EntityEnum, EntityTypeEnum, FacilityTypeEnum, PermissionsEnum, StaffCategoryEnum } from 'src/app/models/enums';
import { IAccountType, IAddressInformation, IAddressLookup, IAuditorOrAffiliation, IBank, IBankDetail, IBranch, IDenodoFacility, IDepartment, IDocumentStore, IDocumentType, IFacilityClass, IFacilityDistrict, IFacilityList, IFacilitySubDistrict, IFacilityType, INpo, INpoProfile, INpoProfileFacilityList, IProgramme, IServicesRendered, IStaffCategory, IStaffMemberProfile, ISubProgramme, ISubProgrammeType, IUser } from 'src/app/models/interfaces';
import { AddressLookupService } from 'src/app/services/api-services/address-lookup/address-lookup.service';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

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

  public get StaffCategoryEnum(): typeof StaffCategoryEnum {
    return StaffCategoryEnum;
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
  facilityList: IFacilityList;

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

  serviceRenderedCols: any[];
  displayServiceRenderedDialog: boolean;
  isServiceRenderedEdit: boolean;
  newServiceRendered: boolean;
  serviceRendered: IServicesRendered = {} as IServicesRendered;
  selectedServiceRendered: IServicesRendered;

  programmes: IProgramme[];
  filteredProgrammes: IProgramme[] = [];
  selectedProgramme: IProgramme;
  subProgrammes: ISubProgramme[];
  filteredSubProgrammes: ISubProgramme[] = [];
  selectedSubProgramme: ISubProgramme;
  subProgrammeTypes: ISubProgrammeType[];
  filteredSubProgrammeTypes: ISubProgrammeType[] = [];
  selectedSubProgrammeType: ISubProgrammeType;

  departments: IDepartment[];

  bankDetailCols: any[];
  displayBankDetailDialog: boolean;
  isBankDetailEdit: boolean;
  newBankDetail: boolean;
  bankDetail: IBankDetail = {} as IBankDetail;
  selectedBankDetail: IBankDetail;

  banks: IBank[];
  selectedBank: IBank;
  branches: IBranch[];
  selectedBranch: IBranch;
  accountTypes: IAccountType[];
  selectedAccountType: IAccountType;

  npoProfileFacilityLists: INpoProfileFacilityList[];
  servicesRendered: IServicesRendered[];
  bankDetails: IBankDetail[];

  auditorOrAffiliations: IAuditorOrAffiliation[];
  auditorCols: any[];
  newAuditorOrAffiliation: boolean;
  auditorOrAffiliation: IAuditorOrAffiliation = {} as IAuditorOrAffiliation;
  selectedAuditorOrAffiliation: IAuditorOrAffiliation;
  displayAuditorDialog: boolean;

  staffCategories: IStaffCategory[];
  staffMemberProfiles: IStaffMemberProfile[];

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
    private _messageService: MessageService,
    private _loggerService: LoggerService
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
        this.loadProgrammes();
        this.loadSubProgrammes();
        this.loadSubProgrammeTypes();
        this.loadDepartments();
        this.loadBanks();
        this.loadAccountTypes();
        this.loadStaffCategories();
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

    this.serviceRenderedCols = [
      { header: 'Programme', width: '31%' },
      { header: 'Sub-Programme', width: '31%' },
      { header: 'Sub-Programme Type', width: '31%' }
    ];

    this.bankDetailCols = [
      { header: 'Bank', width: '15%' },
      { header: 'Branch', width: '25%' },
      { header: 'Code', width: '10%' },
      { header: 'Account Type', width: '15%' },
      { header: 'Account Number', width: '28%' }
    ];

    this.auditorCols = [
      { header: 'Company', width: '20%' },
      { header: 'Registration Number', width: '15%' },
      { header: 'Address', width: '23%' },
      { header: 'Telephone Number', width: '10%' },
      { header: 'Email Address', width: '25%' }
    ];
  }

  private loadFacilityDistricts() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilityDistricts, false).subscribe(
      (results) => {
        this.facilityDistricts = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadFacilitySubDistricts() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilitySubDistricts, false).subscribe(
      (results) => {
        this.allFacilitySubDistricts = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadFacilityClasses() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilityClasses, false).subscribe(
      (results) => {
        this.facilityClasses = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadFacilityTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.FacilityTypes, false).subscribe(
      (results) => {
        this.facilityTypes = results;
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
        this.documentTypes = results.filter(x => x.location === DocumentUploadLocationsEnum.NpoProfile);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadDepartments() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Departments, true).subscribe(
      (results) => {
        this.departments = results;
        this.updateDepartments();
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
        this.updateDepartments();
        this.updateServicesRenderedObjects();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateDepartments() {
    if (this.departments && this.programmes) {
      this.programmes.forEach(item => {
        item.department = this.departments.find(x => x.id === item.departmentId);
      });

      this.filteredProgrammes = this.programmes.filter(x => x.department.isActive == true);
    }
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
    if (this.npoProfileId != null) {
      this._npoProfileRepo.getNpoProfileById(Number(this.npoProfileId)).subscribe(
        (results) => {
          results.addressInformation = results.addressInformation != null ? results.addressInformation : {} as IAddressInformation;

          this.npoProfile = results;
          this.getDocuments();

          this.loadFacilities(Number(this.npoProfileId));
          this.loadServicesRendered(Number(this.npoProfileId));
          this.loadBankDetails(Number(this.npoProfileId));
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

  public addOther() {
    this.staffMemberProfiles.push({
      staffCategoryId: this.staffCategories.find(x => x.id === StaffCategoryEnum.Other).id,
      staffCategory: this.staffCategories.find(x => x.id === StaffCategoryEnum.Other),
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
  }

  public updateStaffMemberProfile(staffMemberProfile: IStaffMemberProfile) {
    this._spinner.show();
    staffMemberProfile.npoProfileId = this.npoProfile.id;
    this._npoProfileRepo.updateStaffMemberProfile(staffMemberProfile).subscribe(
      (resp) => {
        staffMemberProfile.id = resp.id;
        staffMemberProfile.createdUserId = resp.createdUserId;
        staffMemberProfile.createdDateTime = resp.createdDateTime;
        staffMemberProfile.updatedUserId = resp.updatedUserId;
        staffMemberProfile.updatedDateTime = resp.updatedDateTime;
        this._spinner.hide();
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
    this._npoProfileRepo.getServicesRenderedByNpoProfileId(npoProfileId).subscribe(
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
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private formValidate() {
    this.validated = true;
    this.validationErrors = [];

    let data = this.npoProfile;

    if (!this.npo.name || !this.npo.organisationTypeId)
      this.validationErrors.push({ severity: 'error', summary: "General Information:", detail: "Missing detail required. This can be updated on the Organisations tab." });

    if (this.npo.contactInformation.length === 0)
      this.validationErrors.push({ severity: 'error', summary: "Contact / Stakeholder Details:", detail: "The Organisation Contact List cannot be empty. This can be updated on the Organisations tab." });

    if (!data.addressInformation.physicalAddress || data.addressInformation.postalSameAsPhysical == null || data.addressInformation.postalSameAsPhysical == undefined || !data.addressInformation.postalAddress)
      this.validationErrors.push({ severity: 'error', summary: "Address Information:", detail: "Missing detail required." });

    if (this.npoProfileFacilityLists.length === 0)
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

      // TK: Set default approval status to Approved after chat with RG on 2023-06-19
      this.npo.approvalStatusId = AccessStatusEnum.Approved; //AccessStatusEnum.Pending;
      this.npo.approvalUserId = null;
      this.npo.approvalDateTime = null;

      this._npoRepo.updateNpo(this.npo).subscribe(
        (resp) => {
          data.addressInformation.npoProfileId = data.id;

          this._npoProfileRepo.updateNpoProfile(data).subscribe(
            (resp) => {
              this._spinner.hide();
              this._router.navigateByUrl('npo-profiles');
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
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

    this._addressLookupService.getAddress(query).subscribe(
      (d) => {
        this.newAddress = d['suggestions'];
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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
    this.mapping.facilityList.facilitySubDistrict = this.selectedSubDistrict;
    this.mapping.facilityList.facilitySubDistrict.facilityDistrict = this.selectedDistrict;
    this.mapping.facilityList.facilityClass = this.selectedClass;

    let facilityList = {
      facilityTypeId: this.mapping.facilityList.facilityType.id,
      facilitySubDistrictId: this.mapping.facilityList.facilitySubDistrict.id,
      name: this.mapping.facilityList.name,
      facilityClassId: this.mapping.facilityList.facilityClass.id,
      latitude: this.mapping.facilityList.facilityFound ? this.facilityList.latitude : this.mapping.facilityList.latitude,
      longitude: this.mapping.facilityList.facilityFound ? this.facilityList.longitude : this.mapping.facilityList.longitude,
      address: this.mapping.facilityList.facilityFound ? this.facilityList.address : this.mapping.facilityList.address,
      isNew: this.mapping.facilityList.facilityFound ? false : true,
      isActive: true
    } as IFacilityList;

    this._dropdownRepo.getFacilityList(facilityList).subscribe(
      (facility) => {

        if (this.isFacilityInformationEdit) {
          /*this.selectedMapping.facilityList.facilityType = null;
          this.selectedMapping.facilityList.facilitySubDistrict = null;
          this.selectedMapping.facilityList.facilityClass = null;*/

          this.updateFacilityList(this.selectedMapping.facilityList);
        }

        if (facility == null) {
          if (this.newFacilityInformation) {
            this.createFacilityList(facilityList);
          }
        }
        else {
          let mapping = {
            id: this.newFacilityInformation ? 0 : this.selectedMapping.id,
            npoProfileId: Number(this.npoProfileId),
            facilityListId: facility.id,
            isActive: true
          } as INpoProfileFacilityList;

          this.newFacilityInformation ? this.createFacility(mapping) : this.updateFacility(mapping);
        }
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );

    this.displayFacilityInformationDialog = false;
  }

  private createFacilityList(facilityList: IFacilityList) {
    this._dropdownRepo.createFacilityList(facilityList).subscribe(
      (newFacility) => {
        let mapping = {
          npoProfileId: Number(this.npoProfileId),
          facilityListId: newFacility.id,
          isActive: true
        } as INpoProfileFacilityList;

        this.createFacility(mapping);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateFacilityList(facilityList: IFacilityList) {
    this._dropdownRepo.updateFacilityList(facilityList).subscribe(
      (editFacility) => {
        this.loadFacilities(Number(this.npoProfileId));
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private createFacility(mapping: INpoProfileFacilityList) {
    this._npoProfileRepo.createFacilityMapping(mapping).subscribe(
      (resp) => {
        this.loadFacilities(Number(this.npoProfileId));
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateFacility(mapping: INpoProfileFacilityList) {
    this._npoProfileRepo.updateFacilityMapping(mapping).subscribe(
      (resp) => {
        this.loadFacilities(Number(this.npoProfileId));
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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
        data.isActive = false;
        this.updateFacility(data);
      },
      reject: () => {
      }
    });
  }

  search(event) {
    let query = event.query;
    this._dropdownRepo.getFacilityByName(query).subscribe(
      (results) => {
        this.denodoFacilities = results.elements;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
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
      this.facilityList = {
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
      } as IFacilityList;
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
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
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
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
          }
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

  populateAddressField(event, field) {
    switch (field) {
      case 'physicalAddress':
        this.npoProfile.addressInformation.physicalAddress = event.text;
        break;
      case 'postalAddress':
        this.npoProfile.addressInformation.postalAddress = event.text;
        break;
      case 'facilityAddress':
        this.mapping.facilityList.address = event.text;
        break;
      case 'auditorAddress':
        this.auditorOrAffiliation.address = event.text;
        break;
    }
  }

  addServicesRendered() {
    this.isServiceRenderedEdit = false;
    this.newServiceRendered = true;
    this.serviceRendered = {} as IServicesRendered;

    this.selectedProgramme = null;
    this.selectedSubProgramme = null;
    this.selectedSubProgrammeType = null;

    this.filteredSubProgrammes = [];
    this.filteredSubProgrammeTypes = [];

    this.displayServiceRenderedDialog = true;
  }

  saveServicesRendered() {
    this.serviceRendered.npoProfileId = Number(this.npoProfileId);
    this.serviceRendered.programmeId = this.selectedProgramme.id;
    this.serviceRendered.subProgrammeId = this.selectedSubProgramme.id;
    this.serviceRendered.subProgrammeTypeId = this.selectedSubProgrammeType.id;
    this.serviceRendered.isActive = true;

    this.newServiceRendered ? this.createServiceRendered(this.serviceRendered) : this.updateServiceRendered(this.serviceRendered);
    this.displayServiceRenderedDialog = false;
  }

  private createServiceRendered(service: IServicesRendered) {
    this._npoProfileRepo.createServicesRendered(service).subscribe(
      (resp) => {
        this.loadServicesRendered(Number(this.npoProfileId));
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateServiceRendered(service: IServicesRendered) {
    this._npoProfileRepo.updateServicesRendered(service).subscribe(
      (resp) => {
        this.loadServicesRendered(Number(this.npoProfileId));
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  disableSaveServicesRendered() {
    if (!this.selectedProgramme || !this.selectedSubProgramme || !this.selectedSubProgrammeType)
      return true;

    return false;
  }

  editServicesRendered(data: IServicesRendered) {
    this.selectedServiceRendered = data;
    this.isServiceRenderedEdit = true;
    this.newServiceRendered = false;
    this.serviceRendered = this.cloneServicesRendered(data);
    this.displayServiceRenderedDialog = true;
  }

  private cloneServicesRendered(data: IServicesRendered): IServicesRendered {
    let serviceRendered = {} as IServicesRendered;

    for (let prop in data)
      serviceRendered[prop] = data[prop];

    this.selectedProgramme = data.programme;
    this.programmeChange(this.selectedProgramme);

    this.selectedSubProgramme = data.subProgramme;
    this.subProgrammeChange(this.selectedSubProgramme);

    this.selectedSubProgrammeType = data.subProgrammeType;

    return serviceRendered;
  }

  deleteServicesRendered(data: IServicesRendered) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        data.isActive = false;
        this.updateServiceRendered(data);
      },
      reject: () => {
      }
    });
  }

  programmeChange(programme: IProgramme) {
    this.selectedSubProgramme = null;
    this.selectedSubProgrammeType = null;

    this.filteredSubProgrammes = [];
    this.filteredSubProgrammeTypes = [];

    if (programme.id != null) {
      this.filteredSubProgrammes = this.subProgrammes.filter(x => x.programmeId === programme.id);
    }
  }

  subProgrammeChange(subProgramme: ISubProgramme) {
    this.selectedSubProgrammeType = null;
    this.filteredSubProgrammeTypes = [];

    if (subProgramme.id != null) {
      this.filteredSubProgrammeTypes = this.subProgrammeTypes.filter(x => x.subProgrammeId === subProgramme.id);
    }
  }

  disableSubProgramme(): boolean {
    if (this.filteredSubProgrammes.length > 0)
      return false;

    return true;
  }

  disableSubProgrammeType(): boolean {
    if (this.filteredSubProgrammeTypes.length > 0)
      return false;

    return true;
  }

  addBankDetail() {
    this.isBankDetailEdit = false;
    this.newBankDetail = true;
    this.bankDetail = {} as IBankDetail;
    this.selectedBank = null;
    this.branches = [];
    this.selectedBranch = null;
    this.selectedAccountType = null;
    this.displayBankDetailDialog = true;
  }

  editBankDetail(data: IBankDetail) {
    this.selectedBankDetail = data;
    this.isBankDetailEdit = true;
    this.newBankDetail = false;
    this.bankDetail = this.cloneBankDetail(data);
    this.branchChange();
    this.displayBankDetailDialog = true;
  }

  private cloneBankDetail(data: IBankDetail): IBankDetail {
    let bankDetail = {} as IBankDetail;

    for (let prop in data)
      bankDetail[prop] = data[prop];

    this.selectedBank = data.bank;
    this.bankChange();
    this.selectedBranch = data.branch;
    this.selectedAccountType = data.accountType;

    return bankDetail;
  }

  deleteBankDetail(data: IBankDetail) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        data.isActive = false;
        this.updateBankDetail(data);
      },
      reject: () => {
      }
    });
  }

  saveBankDetail() {
    this.bankDetail.npoProfileId = Number(this.npoProfileId);
    this.bankDetail.bankId = this.selectedBank.id;
    this.bankDetail.branchId = this.selectedBranch.id;
    this.bankDetail.accountTypeId = this.selectedAccountType.id;
    this.bankDetail.isActive = true;

    this.newBankDetail ? this.createBankDetail(this.bankDetail) : this.updateBankDetail(this.bankDetail);
    this.displayBankDetailDialog = false;
  }

  private createBankDetail(bankDetail: IBankDetail) {
    this._npoProfileRepo.createBankDetail(bankDetail).subscribe(
      (resp) => {
        this.loadBankDetails(Number(this.npoProfileId));
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateBankDetail(bankDetail: IBankDetail) {
    this._npoProfileRepo.updateBankDetail(bankDetail).subscribe(
      (resp) => {
        this.loadBankDetails(Number(this.npoProfileId));
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  disableSaveBankDetail() {
    if (!this.selectedBank || !this.selectedBranch || !this.selectedAccountType || !this.bankDetail.accountNumber)
      return true;

    return false;
  }

  bankChange() {
    if (this.selectedBank) {
      this.branches = [];
      this.selectedBranch = null;

      this._spinner.show();
      this._dropdownRepo.getEntitiesByEntityId(DropdownTypeEnum.Branches, this.selectedBank.id).subscribe(
        (results) => {
          this.branches = results;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  branchChange() {
    if (this.selectedBranch) {
      this.bankDetail.branchCode = this.selectedBranch.branchCode != null ? this.selectedBranch.branchCode : this.selectedBank.code;
    }
  }

  public addAuditorInformation() {
    this.newAuditorOrAffiliation = true;

    this.auditorOrAffiliation = {
      entityId: this.npoProfile.id,
      entityName: AuditorOrAffiliationEntityNameEnum.NpoProfile,
      entityType: AuditorOrAffiliationEntityTypeEnum.Auditor,
      isActive: true
    } as IAuditorOrAffiliation;

    this.addressLookup = null;
    this.displayAuditorDialog = true;
  }

  public editAuditorInformation(data: IAuditorOrAffiliation) {
    this.newAuditorOrAffiliation = false;
    this.auditorOrAffiliation = this.cloneAuditorOrAffiliation(data);
    this.addressLookup = null;
    this.displayAuditorDialog = true;
  }

  private cloneAuditorOrAffiliation(data: IAuditorOrAffiliation): IAuditorOrAffiliation {
    let object = {} as IAuditorOrAffiliation;

    for (let prop in data)
      object[prop] = data[prop];

    return object;
  }

  public deleteAuditorInformation(data: IAuditorOrAffiliation) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.auditorOrAffiliation = this.cloneAuditorOrAffiliation(data);
        this.auditorOrAffiliation.isActive = false;
        this.updateAuditorOrAffiliation();
      },
      reject: () => {
      }
    });
  }

  public disableSaveAuditorInfo() {
    const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (!this.auditorOrAffiliation.organisationName || !this.auditorOrAffiliation.registrationNumber || !this.auditorOrAffiliation.address || !this.auditorOrAffiliation.contactPerson || !this.auditorOrAffiliation.telephoneNumber || this.auditorOrAffiliation.telephoneNumber.length != 10 || !this.auditorOrAffiliation.emailAddress || !regularExpression.test(String(this.auditorOrAffiliation.emailAddress)))
      return true;

    return false;
  }

  public saveAuditorInformation() {
    this.newAuditorOrAffiliation ? this.createAuditorOrAffiliation() : this.updateAuditorOrAffiliation();
    this.displayAuditorDialog = false;
  }

  private createAuditorOrAffiliation() {
    this._npoProfileRepo.createAuditorOrAffiliation(this.auditorOrAffiliation).subscribe(
      (resp) => {
        this.loadAuditorOrAffiliations();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateAuditorOrAffiliation() {
    this._npoProfileRepo.updateAuditorOrAffiliation(this.auditorOrAffiliation).subscribe(
      (resp) => {
        this.loadAuditorOrAffiliations();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
}
