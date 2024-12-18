import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, Message, ConfirmationService, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs/internal/Subscription';
import { PermissionsEnum, DropdownTypeEnum, AccessStatusEnum } from 'src/app/models/enums';
import { INpo, IContactInformation, IUser, IOrganisationType, IRegistrationStatus, ITitle, IPosition, IRace, IGender, ILanguage } from 'src/app/models/interfaces';
import { AddressLookupService } from 'src/app/services/api-services/address-lookup/address-lookup.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-edit-quick-capture',
  templateUrl: './edit-quick-capture.component.html',
  styleUrls: ['./edit-quick-capture.component.css']
})
export class EditQuickCaptureComponent implements OnInit {



  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  npo: INpo;

  menuActions: MenuItem[];
  profile: IUser;

  validationErrors: Message[];
  stateOptions: any[];

  organisationTypes: IOrganisationType[];
  selectedOrganisationType: IOrganisationType;

  registrationStatuses: IRegistrationStatus[];
  selectedRegistrationStatus: IRegistrationStatus;

  titles: ITitle[];
  selectedTitle: ITitle;
  positions: IPosition[];
  selectedPosition: IPosition;

  races: IRace[];
  selectedRace: IRace;

  gender: IGender[];
  selectedGender: IGender;

  languages: ILanguage[];
  selectedLanguage: ILanguage;

  contactCols: any[];
  isContactInformationEdit: boolean;
  newContactInformation: boolean;
  contactInformation: IContactInformation = {} as IContactInformation;
  selectedContactInformation: IContactInformation;
  primaryContactInformation: IContactInformation;
  displayContactDialog: boolean;

  selectedNPO: INpo;
  NPOs: INpo[];

  npoId: string;
  applicationId: string;
  paramSubcriptions: Subscription;
  isDataAvailable: boolean = false;

  // Highlight required fields on validate click
  validated: boolean = false;
  minDate: Date;
  maxDate: Date;
  disableDate: boolean = true;

  isPrimaryContact: boolean;
  isBoardMember: boolean;
  isSignatory: boolean;
  isWrittenAgreementSignatory: boolean;
  isDisabled: boolean;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _confirmationService: ConfirmationService,
    private _npoRepo: NpoService,
    private _activeRouter: ActivatedRoute,
    private _loggerService: LoggerService,
    private _applicationRepo: ApplicationService,
    private _addressLookupService: AddressLookupService
  ) { }

  ngOnInit(): void {
    this._spinner.show();
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      //this.npoId = params.get('id');
      this.applicationId = params.get('id');
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.EditNpo))
          this._router.navigate(['401']);


        this.loadOrganisationTypes();
        this.loadRegistrationStatuses();
        this.loadTitles();
        this.loadPositions();
        this.loadRaces();
        this.loadGender();
        this.loadLanguages();
        this.loadNpo();
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

    this.contactCols = [
      { header: 'Name', width: '25%' },
      { header: 'Position', width: '20%' },
      { header: 'Email', width: '33%' },
      { header: 'Cellphone', width: '15%' }
    ];
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
        }
        // ,
        // {
        //   label: 'Go Back',
        //   icon: 'fa fa-step-backward',
        //   command: () => {
        //     this._router.navigateByUrl('npos');
        //   }
        // }
      ];
    }
  }

  private loadOrganisationTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.OrganisationTypes, false).subscribe(
      (results) => {
        this.organisationTypes = results;
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
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadTitles() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Titles, false).subscribe(
      (results) => {
        this.titles = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadPositions() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Positions, false).subscribe(
      (results) => {
        this.positions = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }


  private loadRaces() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Race, false).subscribe(
      (results) => {
        this.races = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadLanguages() {
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
  private loadNpo() {
    this._applicationRepo.getApplicationById(Number(this.applicationId)).subscribe(
      (results) => {
        if (results != null) {
          this.npoId = results.npoId.toString();
          this._npoRepo.getNpoById(Number(this.npoId)).subscribe(
            (resultsNpo) => {
              this.selectedOrganisationType = resultsNpo.organisationType;
              this.selectedRegistrationStatus = resultsNpo.registrationStatus;
              this.npo = resultsNpo;
              this.isDataAvailable = true;
              this._spinner.hide();
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        }
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );

    // this._npoRepo.getNpoById(Number(this.npoId)).subscribe(
    //   (resultsNpo) => {
    //     this.selectedOrganisationType = resultsNpo.organisationType;
    //     this.selectedRegistrationStatus = resultsNpo.registrationStatus;
    //     this.npo = resultsNpo;
    //     this.isDataAvailable = true;
    //     this._spinner.hide();
    //   },
    //   (err) => {
    //     this._loggerService.logException(err);
    //     this._spinner.hide();
    //   }
    // ); 
  }

  private formValidate() {
    this.validated = true;
    this.validationErrors = [];

    let data = this.npo;

    if (!data.name || !this.selectedOrganisationType || !this.selectedRegistrationStatus)
      this.validationErrors.push({ severity: 'error', summary: "General Information:", detail: "Missing detail required." });

    if (data.contactInformation.length === 0)
      this.validationErrors.push({ severity: 'error', summary: "Contact / Stakeholder Details:", detail: "The Organisation Contact List cannot be empty." });

    if (data.contactInformation.length > 0 && data.contactInformation.filter(x => x.isPrimaryContact === true).length === 0)
      this.validationErrors.push({ severity: 'error', summary: "Contact / Stakeholder Details:", detail: "Please specify the primary contact." });

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
      let data = this.npo;

      // TK: Set default approval status to Approved after chat with RG on 2023-06-19
      data.approvalStatusId = AccessStatusEnum.Approved;
      data.organisationTypeId = this.selectedOrganisationType.id;
      data.registrationStatusId = this.selectedRegistrationStatus.id;

      data.contactInformation.forEach(item => {
        item.titleId = item.title.id;
        item.positionId = item.position.id;
        // item.genderId = item.gender.id;
        // item.raceId = item.race.id;
      });

      this._npoRepo.updateNpo(data).subscribe(
        (resp) => {
          this._spinner.hide();
          this._router.navigateByUrl('npos');
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
    this.selectedGender = null;
    this.selectedRace = null;
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
    else {
      this.contactInformation.updatedUserId = this.profile.id;
      this.contactInformation.updatedDateTime = new Date();
      this.npo.contactInformation[this.npo.contactInformation.indexOf(this.selectedContactInformation)] = this.contactInformation;
    }

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

  updateNpoName() {
    this.npo.name = this.selectedNPO.name;
  }
}
