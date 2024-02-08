import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MessageService } from 'primeng/api';
import { AccessStatusEnum, DropdownTypeEnum, PermissionsEnum, RoleEnum, StaffCategoryEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IApplicationPeriod, IContactInformation, IGender, ILanguage, INpo, INpoProfile, IOrganisationType, IPosition, IRace, IRegistrationStatus, IStaffCategory, IStaffMemberProfile, ITitle, IUser } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';

@Component({
  selector: 'app-create-quick-capture',
  templateUrl: './create-quick-capture.component.html',
  styleUrls: ['./create-quick-capture.component.css']
})
export class CreateQuickCaptureComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() npo: INpo;
  @Output() npoChange: EventEmitter<INpo> = new EventEmitter<INpo>();

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get StaffCategoryEnum(): typeof StaffCategoryEnum {
    return StaffCategoryEnum;
  }

  profile: IUser;
  stateOptions: any[];

  organisationTypes: IOrganisationType[];
  selectedOrganisationType: IOrganisationType;

  registrationStatuses: IRegistrationStatus[];
  selectedRegistrationStatus: IRegistrationStatus;

  titles: ITitle[];
  selectedTitle: ITitle;

  positions: IPosition[];
  selectedPosition: IPosition;

  isSystemAdmin: boolean = true;
  isAdmin: boolean = false;
  races: IRace[];
  selectedRace: IRace;

  allNpos: INpo[];
  selectedNPO: INpo;
  isDisabled: boolean = true;
  gender: IGender[];
  selectedGender: IGender;
  hasAdminRole: boolean = false;
  languages: ILanguage[];
  selectedLanguage: ILanguage;
  displayDialog: boolean;
  minDate: Date;
  maxDate: Date;
  contactCols: any[];
  isContactInformationEdit: boolean;
  newContactInformation: boolean;
  contactInformation: IContactInformation = {} as IContactInformation;
  selectedContactInformation: IContactInformation;
  displayContactDialog: boolean;

  application: IApplication = {} as IApplication;
  allApplicationPeriods: IApplicationPeriod[];
  applicationPeriodId: number;

  // Highlight required fields on validate click
  validated: boolean = false;

  staffMemberProfiles: IStaffMemberProfile[];
  staffCategories: IStaffCategory[];

  npoProfile: INpoProfile;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _confirmationService: ConfirmationService,
    private _npoRepo: NpoService,
     private _npoProfileRepo: NpoProfileService,
    private _loggerService: LoggerService,
    private _messageService: MessageService
    // private _addressLookupService: AddressLookupService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.AddNpo))
        {
          this._router.navigate(['401']);
        }
        
          this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
          this.isAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.Admin });

        if (this.isSystemAdmin || this.isAdmin)
        this.hasAdminRole = true;

        this.loadNpos();
        this.loadOrganisationTypes();
        this.loadRegistrationStatuses();
        this.loadTitles();
        this.loadPositions();
        this.loadGender();
        this.loadRaces();
        this.loadLanguages();
        //     this.buildMenu();
      }
    });

    this.stateOptions = [
      { label: 'Yes', value: true },
      { label: 'No', value: false }
    ];

    this.contactCols = [
      { header: 'Name', width: '25%' },
      { header: 'Position', width: '20%' },
      { header: 'Email', width: '33%' },
      { header: 'Cellphone', width: '15%' }
    ];
  }

  // private buildMenu() {
  //   if (this.profile) {
  //     this.menuActions = [
  //       {
  //         label: 'Validate',
  //         icon: 'fa fa-check',
  //         command: () => {
  //           this.formValidate();
  //         },
  //         visible: false
  //       },
  //       {
  //         label: 'Clear Messages',
  //         icon: 'fa fa-undo',
  //         command: () => {
  //           this.clearMessages();
  //         },
  //         visible: false
  //       },
  //       {
  //         label: 'Save',
  //         icon: 'fa fa-floppy-o',
  //         command: () => {
  //           this.saveItems();
  //         }
  //       }
  //     ];
  //   }
  // }

  private loadOrganisationTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.OrganisationTypes, false).subscribe(
      (results) => {
        this.organisationTypes = results;
        this.selectedOrganisationType = this.npo.organisationTypeId ? this.organisationTypes.find(x => x.id === this.npo.organisationTypeId) : null;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadRegistrationStatuses() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.RegistrationStatus, false).subscribe(
      (results) => {
        this.registrationStatuses = results;
        this.selectedRegistrationStatus = this.npo.registrationStatusId ? this.registrationStatuses.find(x => x.id === this.npo.registrationStatusId) : null;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadTitles() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Titles, false).subscribe(
      (results) => {
        this.titles = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadPositions() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Positions, false).subscribe(
      (results) => {
        this.positions = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadRaces() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Race, false).subscribe(
      (results) => {
        this.races = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadLanguages() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Languages, false).subscribe(
      (results) => {
        this.languages = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadGender() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Gender, false).subscribe(
      (results) => {
        this.gender = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }



  // private clearMessages() {
  //   this.validated = false;
  //   this.validationErrors = [];
  //   this.menuActions[1].visible = false;
  // }

  // private saveItems() {
  //   if (this.canContinue()) {
  //     this._spinner.show();
  //     let data = this.npo;

  //     // TK: Set default approval status to Approved after chat with RG on 2023-06-19
  //     data.approvalStatusId = AccessStatusEnum.Approved; //AccessStatusEnum.New;
  //     data.organisationTypeId = this.selectedOrganisationType.id;
  //     data.registrationStatusId = this.selectedRegistrationStatus.id;

  //     data.contactInformation.forEach(item => {
  //       item.titleId = item.title.id;
  //       item.positionId = item.position.id;
  //       item.genderId = item.gender.id;
  //       item.raceId = item.race.id;
  //       item.languageId = item.language.id;
  //     });

  //     this._npoRepo.createNpo(data).subscribe(
  //       (resp) => {
  //         this._npoProfileRepo.getNpoProfileByNpoId(Number(resp.id)).subscribe(
  //           (results) => {
  //             this._spinner.hide();
  //             if (results != null) this.newlySavedNpoId = results.id;
  //             this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
  //           },
  //           (err) => {
  //             this._loggerService.logException(err);
  //             this._spinner.hide();
  //           }
  //         );
  //       },
  //       (err) => {
  //         this._loggerService.logException(err);
  //         this._spinner.hide();
  //       }
  //     );
  //   }
  // }

  nextPage() {
    if (this.canContinue()) {
      // save npo
      this._spinner.show();
      let data = this.npo;

      // TK: Set default approval status to Approved after chat with RG on 2023-06-19
      data.approvalStatusId = AccessStatusEnum.Approved; //AccessStatusEnum.New;

      data.contactInformation.forEach(item => {
        item.titleId = item.title.id;
        item.positionId = item.position.id;
        item.genderId = item.gender ? item.gender.id : null;
        item.raceId = item.race ? item.race.id : null;
        item.languageId = item.language ? item.language.id : null;
      });

      this._npoRepo.createNpo(data).subscribe(
        (resp) => {//
          this._spinner.hide();
          this.npo.id = resp.id;
          this.updateNpo();

          this.activeStep = this.activeStep + 1;
          this.activeStepChange.emit(this.activeStep);
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  public setValidated(value: boolean) {
    this.validated = value;
  }

  private canContinue() {
    this.validated = true;
    let data = this.npo;
    let orgDetailsError: string[] = [];

    if (!data.name || !this.selectedOrganisationType || !this.selectedRegistrationStatus)
      orgDetailsError.push("Missing detail required under General Information");

    if (data.contactInformation.length === 0)
      orgDetailsError.push("The Organisation Contact List cannot be empty under Contact / Stakeholder Details");

    if (data.contactInformation.length > 0 && data.contactInformation.filter(x => x.isPrimaryContact === true).length === 0)
      orgDetailsError.push("Please specify the primary contact under Contact / Stakeholder Details");

    if (orgDetailsError.length > 0)
      this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });

    return orgDetailsError.length > 0 ? false : true;

    // if (!data.name || !this.selectedOrganisationType || !this.selectedRegistrationStatus) {
    //   this._messageService.add({ severity: 'error', summary: "General Information:", detail: "Missing detail required." });
    //   hasErrors.push(true);
    // }

    // if (data.contactInformation.length === 0) {
    //   this._messageService.add({ severity: 'error', summary: "Contact / Stakeholder Details:", detail: "The Organisation Contact List cannot be empty." });
    //   hasErrors.push(true);
    // }

    // if (data.contactInformation.length > 0 && data.contactInformation.filter(x => x.isPrimaryContact === true).length === 0) {
    //   this._messageService.add({ severity: 'error', summary: "Contact / Stakeholder Details:", detail: "Please specify the primary contact." });
    //   hasErrors.push(true);
    // }

    // return hasErrors.includes(true) ? false : true;
  }

  // private canContinue() {
  //   this.formValidate();

  //   if (this.validationErrors.length == 0)
  //     return true;

  //   return false;
  // }

  clearIdPassportNumber(event) {
    if (event.value === true)
      this.npo.contactInformation[0].passportNumber = "";

    if (event.value === false)
      this.npo.contactInformation[0].idNumber = "";
  }

  addContactInformation() {
    this.isContactInformationEdit = false;
    this.newContactInformation = true;

    this.contactInformation = {
      rsaIdNumber: true,
      isPrimaryContact: false,
      isActive: true,
      createdUserId: this.profile.id,
      createdDateTime: new Date()
    } as IContactInformation;

    this.selectedTitle = null;
    this.selectedPosition = null;
    this.selectedRace = null;
    this.selectedGender = null;
    this.selectedLanguage = null;
    this.displayContactDialog = true;
  }

  saveContactInformation() {
    this.contactInformation.title = this.selectedTitle;
    this.contactInformation.position = this.selectedPosition;
    this.contactInformation.race = this.selectedRace;
    this.contactInformation.gender = this.selectedGender;
    this.contactInformation.language = this.selectedLanguage;

    if (this.newContactInformation)
      this.npo.contactInformation.push(this.contactInformation);
    else
      this.npo.contactInformation[this.npo.contactInformation.indexOf(this.selectedContactInformation)] = this.contactInformation;

    this.updateNpo();
    this.displayContactDialog = false;
  }

  disableSaveContactInfo() {
    const regularExpression = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

    if (!this.selectedTitle || !this.contactInformation.firstName || !this.contactInformation.lastName || !this.contactInformation.emailAddress || !regularExpression.test(String(this.contactInformation.emailAddress)) || !this.contactInformation.cellphone || this.contactInformation.cellphone.length != 10 || !this.selectedPosition)
      return true;

    return false;
  }

  editContactInformation(data: IContactInformation) {
    this.selectedContactInformation = data;
    this.isContactInformationEdit = true;
    this.newContactInformation = false;
    this.contactInformation = this.cloneContactInformation(data);
    this.displayContactDialog = true;
  }

  private cloneContactInformation(data: IContactInformation): IContactInformation {
    let contactInfo = {} as IContactInformation;

    for (let prop in data)
      contactInfo[prop] = data[prop];

    this.selectedTitle = data.title;
    this.selectedPosition = data.position;
    this.selectedRace = data.race;
    this.selectedGender = data.gender;
    this.selectedLanguage = data.language;

    return contactInfo;
  }

  deleteContactInformation(data: IContactInformation) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.npo.contactInformation.forEach(function (item, index, object) {
          if (data === item)
            object.splice(index, 1);
        });
      },
      reject: () => {
      }
    });
  }

  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }

  public updateNpo() {
    this.npoChange.emit(this.npo);
  }

  public updateOrgType(orgType: IOrganisationType) {
    this.npo.organisationTypeId = orgType.id;
    this.updateNpo();
  }

  public updateRegistrationStatus(registrationStatus: IRegistrationStatus) {
    this.npo.registrationStatusId = registrationStatus.id;
    this.updateNpo();
  }

  private loadNpos() {
    this._spinner.show();
    this._npoRepo.getAllNpos(AccessStatusEnum.Approved).subscribe(
      (results) => {
        this.allNpos = results;
      //  this.loadStaffMemberProfiles();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      } 
    );
  }

  search(event) {
    let query = event.query;
    this._npoRepo.getNpoByName(query).subscribe((results) => {
      this.allNpos = results;
      if(this.allNpos.length === 0)
      {
        this.isDisabled = false;
      }
    });
  }

  
  onRowSelect() {
    this.displayDialog = true;
  }

  selectNPO() {
    this.displayDialog = false;
    this.addOrganisation();
  }

  private addOrganisation() {
    this.application.npoId = this.selectedNPO.id;
    this.application.applicationPeriodId = this.applicationPeriodId;
    this.application.statusId = StatusEnum.New;

    if (this.selectedNPO.id != null) {
      this._npoRepo.getNpoById(Number(this.selectedNPO.id)).subscribe(
        (results) => {         
          this.selectedOrganisationType = results.organisationType;
          this.selectedRegistrationStatus = results.registrationStatus;
          this.npo = results;        
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
   }

   disableSelect() {
    if (!this.selectedNPO)
      return true;

    // if (this.selectedApplicationPeriod.applicationType.id === ApplicationTypeEnum.SP && !this.selectedOption) {
    //   if (!this.selectedFinancialYear)
    //     return true
    // }
    return false;
  }

  private loadStaffMemberProfiles() {
    this._npoProfileRepo.getStaffMemberProfilesByNpoProfileId(72).subscribe(
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

  selectedNPOChange() {
    //this.getExistingWorkplanFinancialYear();
  }

}
