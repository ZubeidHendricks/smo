import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PermissionsEnum } from 'src/app/models/enums';
import { INpoViewModel, IUser } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-create-funding-capture',
  templateUrl: './create-funding-capture.component.html',
  styleUrls: ['./create-funding-capture.component.css']
})
export class CreateFundingCaptureComponent implements OnInit {

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
  entity: INpoViewModel;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    // private _fundingManagementRepo: FundingManagementService,
    // private _spinner: NgxSpinnerService,
    // private _loggerService: LoggerService,
    // private _activeRouter: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.AddFundingCapture))
          this._router.navigate(['401']);

        // this.loadFundingCapture();
      }
    });
  }

  // private loadFundingCapture() {
  //   this._spinner.show();
  //   this._activeRouter.paramMap.subscribe(
  //     params => {
  //       let npoId = params.get('npoId');

  //       this._fundingManagementRepo.getFundingCaptureByNpoId(Number(npoId)).subscribe(
  //         (results) => {
  //           console.log('entity', results);
  //           this.entity = results;
  //           this._spinner.hide();
  //         },
  //         (err) => {
  //           this._loggerService.logException(err);
  //           this._spinner.hide();
  //         }
  //       );
  //     }
  //   );    
  // }
}
