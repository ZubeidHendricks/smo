import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { MsalBroadcastService, MsalService } from '@azure/msal-angular';
import { AccountInfo, AuthError, EventMessage, InteractionStatus, RedirectRequest } from '@azure/msal-browser';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter } from 'rxjs/operators';
import { IUser } from 'src/app/models/interfaces';
import { environment } from 'src/environments/environment';
import { UserProfileService } from '../user-profile/user-profile.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  //get notified when login is complete
  private loggedInSubject$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public loggedIn$: Observable<boolean> = this.loggedInSubject$.asObservable();

  //get project details
  private profileSubject$: BehaviorSubject<IUser> = new BehaviorSubject(undefined);
  public profile$: Observable<IUser> = this.profileSubject$.asObservable();

  //mainly used when wanting to auto login
  private canLogInSubject$: BehaviorSubject<boolean> = new BehaviorSubject(false);
  public canLogIn$: Observable<boolean> = this.canLogInSubject$.asObservable();

  private profile: IUser;

  // purpose of flag is to prevent attempts to login more than once or,
  // when another login attempt is in progress
  private canLogin: boolean = false;

  private _pendingPasswordReset: boolean = false;

  constructor(
    private _msalService: MsalService,
    private _msalBroadcastService: MsalBroadcastService,
    private _profileService: UserProfileService,
    private _router: Router,
  ) {

    this._msalBroadcastService.msalSubject$.subscribe((result: EventMessage) => {
      if (result.error instanceof AuthError) {

        let passwordResetErrorCode = 'AADB2C90118';
        if (result.error.errorMessage.indexOf(passwordResetErrorCode) > -1) {
          this._pendingPasswordReset = true;
          this.passwordReset();
        }
      }
    });

    //check and set logged in status
    this._msalBroadcastService.inProgress$
      .pipe(
        filter((status: InteractionStatus) => status === InteractionStatus.None),
      )
      .subscribe((x) => {

        if (this.checkAndSetActiveAccount() !== null)
          this.loggedInSubject$.next(true);

        if (!this.canLogin && !this.isLoggedIn() && !this._pendingPasswordReset) {
          //if (!this.canLogin && !this.isLoggedIn()) {
          this.canLogin = true;
          this.canLogInSubject$.next(true);
        }
      });

    //get profile when logged in
    this.loggedIn$.subscribe(status => {
      if (status) {
        if (this.profile) {
          this.profileSubject$.next(this.profile);
          this.checkAuthorization(this.profile);
        }
        else {
          this._profileService.getLoggedInProfile().subscribe(profile => {
            this.profile = profile;
            this.profileSubject$.next(profile);
            this.checkAuthorization(this.profile);
          });
        }
      }
    });
  }

  private checkAuthorization(profile: IUser) {
    // manage redirects
    if (!profile) {
      //no profile setup for this user
      this._router.navigate(['401']);
    }

    if (profile && !profile.isActive) {
      //profile is disabled.
      this._router.navigate(['403']);
    }
  }

  //only required for internal use
  private checkAndSetActiveAccount() {

    let activeAccount = this._msalService.instance.getActiveAccount();

    if (!activeAccount && this._msalService.instance.getAllAccounts().length > 0) {
      this._msalService.instance.setActiveAccount(this._msalService.instance.getAllAccounts()[0]);
      this.loggedInSubject$.next(true);
    }

    return activeAccount;
  }

  loggedInAccount(): AccountInfo {
    return this.checkAndSetActiveAccount();
  }

  //only required for internal use.
  //use the observable instance for public accesss
  private isLoggedIn(): boolean {
    return this.checkAndSetActiveAccount() !== null;
  }

  login() {
    if (this.canLogin) {
      this.canLogin = false;
      this._msalService.loginRedirect();
    }
  }

  logout() {
    this.canLogin = false;
    this._msalService.logout();
  }

  editProfile() {
    let editProfileFlowRequest: RedirectRequest = {
      scopes: ["openid", "profile"],
      authority: environment.b2cConfig.authorities.editProfile.authority,
    }

    this._msalService.loginRedirect(editProfileFlowRequest);
  }

  passwordReset() {
    let resetPasswordFlowRequest: RedirectRequest = {
      scopes: ["openid", "profile"],
      authority: environment.b2cConfig.authorities.forgotPassword.authority,
    }

    this._msalService.loginRedirect(resetPasswordFlowRequest);
  }

  signup() {
    let resetPasswordFlowRequest: RedirectRequest = {
      scopes: ["openid", "profile"],
      authority: environment.b2cConfig.authorities.signUp.authority,
    }

    this._msalService.loginRedirect(resetPasswordFlowRequest);
  }
}
