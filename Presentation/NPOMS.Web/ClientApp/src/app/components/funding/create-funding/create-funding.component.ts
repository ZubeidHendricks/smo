import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem, Message } from 'primeng/api';
import { FundingStepsEnum, PermissionsEnum } from 'src/app/models/enums';
import { INpoProfile, IUser } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-create-funding',
  templateUrl: './create-funding.component.html',
  styleUrls: ['./create-funding.component.css']
})
export class CreateFundingComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get FundingStepsEnum(): typeof FundingStepsEnum {
    return FundingStepsEnum;
  }

  profile: IUser;

  menuActions: MenuItem[];
  validationErrors: Message[];

  items: MenuItem[];
  activeStep: number = 0;

  npoProfile: INpoProfile;

  constructor(
    private _router: Router,
    private _authService: AuthService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.AddApplication))
          this._router.navigate(['401']);

        this.buildMenu();
        this.buildSteps();
      }
    });
  }

  private buildMenu() {
    if (this.profile) {
      this.menuActions = [
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
            this._router.navigateByUrl('npo-funding');
          }
        }
      ];
    }
  }

  private buildSteps() {
    this.items = [
      { label: 'Funding Details' },
      { label: 'Service Delivery Area' },
      { label: 'Payment Schedule' },
      { label: 'Bank Details' }
    ];
  }

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[0].visible = false;
  }

  private saveItems() {
    if (this.canContinue()) {
      console.log('save information');
      this._router.navigateByUrl('npo-funding');
    }
  }

  private canContinue() {
    this.validationErrors = [];

    this.formValidate();

    if (this.validationErrors.length == 0)
      return true;

    return false;
  }

  private formValidate() {
    this.validationErrors = [];

    if (this.validationErrors.length == 0)
      this.menuActions[0].visible = false;
    else
      this.menuActions[0].visible = true;
  }

  updateNpoProfile(data) {
    this.npoProfile = data;
  }
}
