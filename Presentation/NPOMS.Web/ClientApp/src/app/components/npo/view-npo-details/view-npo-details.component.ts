import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subscription } from 'rxjs';
import { PermissionsEnum } from 'src/app/models/enums';
import { IContactInformation, INpo, IUser } from 'src/app/models/interfaces';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { UserService } from 'src/app/services/api-services/user/user.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-view-npo-details',
  templateUrl: './view-npo-details.component.html',
  styleUrls: ['./view-npo-details.component.css']
})
export class ViewNpoDetailsComponent implements OnInit {

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
  npo: INpo;

  npoId: string;
  paramSubcriptions: Subscription;

  contactCols: any[];
  stateOptions: any[];
  stakeholderCols: any[];

  isDataAvailable: boolean;

  contactInformation: IContactInformation = {} as IContactInformation;
  stakeholderDetails: IContactInformation[];
  displayContactDialog: boolean;

  selectedTitle: string;
  selectedPosition: string;
  selectedRace: string;
  selectedGender: string;
  selectedLanguage: string;
  seletedDateofEmployment: string;

  minDate: Date;
  maxDate: Date;

  // Highlight required fields on validate click
  validated: boolean = true;

  constructor(
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _authService: AuthService,
    private _router: Router,
    private _npoRepo: NpoService,
    private _loggerService: LoggerService,
    private _userRepo: UserService
  ) { }

  ngOnInit(): void {
    this._spinner.show();
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.npoId = params.get('id');
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewNpo))
          this._router.navigate(['401']);

        this.loadNpo();
      }
    });

    this.contactCols = [
      { header: 'Name', width: '30%' },
      { header: 'Position', width: '20%' },
      { header: 'Email', width: '30%' },
      { header: 'Cellphone', width: '15%' },
      { header: 'Actions', width: '5%' }
    ];

    this.stakeholderCols = [
      { header: 'Name', width: '15%' },
      { header: 'Primary Contact', width: '15%' },
      { header: 'Board Member', width: '15%' },
      { header: 'Bank Signatory', width: '15%' },
      { header: 'Written Agreement Signatory', width: '15%' },
      { header: 'Disabled', width: '15%' }
    ];

    this.stateOptions = [
      { label: 'Yes', value: true },
      { label: 'No', value: false }
    ];
  }

  private loadNpo() {
    if (this.npoId != null) {
      this._npoRepo.getNpoById(Number(this.npoId)).subscribe(
        (results) => {
          this.npo = results;
          this.stakeholderDetails = this.npo.contactInformation.filter(x => x.isBoardMember || x.isSignatory || x.isWrittenAgreementSignatory || x.isDisabled);

          this.isDataAvailable = true;
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
    this._userRepo.getUserById(this.npo.createdUserId).subscribe(
      (results) => {
        this.npo.createdUser = results;
        this.loadUpdatedUser();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadUpdatedUser() {
    if (this.npo.updatedUserId) {
      this._userRepo.getUserById(this.npo.updatedUserId).subscribe(
        (results) => {
          this.npo.updatedUser = results;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
    else {
      this.npo.updatedUser = {} as IUser;
      this._spinner.hide();
    }
  }

  viewContactInformation(data: IContactInformation) {
    this.contactInformation = this.cloneContactInformation(data);
    this.displayContactDialog = true;
  }

  private cloneContactInformation(data: IContactInformation): IContactInformation {
    let contactInfo = {} as IContactInformation;

    for (let prop in data)
      contactInfo[prop] = data[prop];

    this.selectedTitle = data.title.name;
    this.selectedPosition = data.position.name;

    this.selectedGender = data.gender ? data.gender.name : null;
    this.selectedRace = data.race ? data.race.name : null;
    this.selectedLanguage = data.language ? data.language.name : null;
    this.seletedDateofEmployment = data.dateOfEmployment ? data.dateOfEmployment.toString() : null;

    return contactInfo;
  }
}
