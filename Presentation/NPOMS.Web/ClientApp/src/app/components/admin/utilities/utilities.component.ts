import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { DropdownTypeEnum, PermissionsEnum, RoleEnum } from 'src/app/models/enums';
import { IUser, IUtility } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-utilities',
  templateUrl: './utilities.component.html',
  styleUrls: ['./utilities.component.css']
})
export class UtilitiesComponent implements OnInit {

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

  systemAdminUtilities: IUtility[];
  utilities: IUtility[];
  evaluationUtilities: IUtility[];
  performanceUtilities: IUtility[];
  isSystemAdmin: boolean = false;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._spinner.show();

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;
        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });

        if (!this.IsAuthorized(PermissionsEnum.ViewUtilitiesSubMenu))
          this._router.navigate(['401']);

        this.loadUtilities();
      }
    });
  }

  private loadUtilities() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Utilities, false).subscribe(
      (results) => {
        this.systemAdminUtilities = results.filter(x => x.systemAdminUtility === true);
        this.utilities = results.filter(x => x.systemAdminUtility === false && x.isActive && !x.name.includes('Question') && !x.name.includes('Response') && !x.name.includes('Assessments'));
        this.evaluationUtilities = results.filter(x => x.systemAdminUtility === false && x.isActive && (x.name.includes('Question') || x.name.includes('Response') || x.name.includes('Assessments')));
        this.performanceUtilities = results.filter(x => x.systemAdminUtility === false && x.isActive && (x.name.includes('Performance')));
     
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  redirectToUtility(item: IUtility) {
    this._router.navigateByUrl(item.angularRedirectUrl);
  }
}
