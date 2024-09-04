import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem } from 'primeng/api';
import { PermissionsEnum } from 'src/app/models/enums';
import { IBankDetailViewModel, IDocumentViewModel, IFundingCaptureViewModel, IFundingDetailViewModel, INpoViewModel, IPaymentScheduleViewModel, ISDAViewModel, IUser } from 'src/app/models/interfaces';
import { FundingManagementService } from 'src/app/services/api-services/funding-management/funding-management.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-view-funding-capture',
  templateUrl: './view-funding-capture.component.html',
  styleUrls: ['./view-funding-capture.component.css']
})
export class ViewFundingCaptureComponent implements OnInit {

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
  menuActions: MenuItem[];

  npo: INpoViewModel;
  fundingCapture: IFundingCaptureViewModel;
  fundingDetail: IFundingDetailViewModel;
  sda: ISDAViewModel;
  paymentSchedule: IPaymentScheduleViewModel;
  bankDetail: IBankDetailViewModel;
  document: IDocumentViewModel;

  paymentFrequencyId: number;
  startDate: string;
  amountAwarded: number;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _fundingManagementRepo: FundingManagementService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewFundingCapture))
          this._router.navigate(['401']);

        this.buildMenu();
        this.loadFunding();
      }
    });
  }

  private buildMenu() {
    if (this.profile) {
      this.menuActions = [
        {
          label: 'Go Back',
          icon: 'fa fa-step-backward',
          command: () => {
            this._router.navigateByUrl('funding-capture');
          }
        }
      ];
    }
  }

  private loadFunding() {
    this._spinner.show();
    this._activeRouter.paramMap.subscribe(
      params => {
        let id = params.get('id');

        this._fundingManagementRepo.getFundingById(Number(id)).subscribe(
          (results) => {
            this.npo = results;
            this.fundingCapture = results.fundingCaptureViewModels[0];
            this.fundingDetail = this.fundingCapture.fundingDetailViewModel;
            this.sda = this.fundingCapture.sdaViewModel;
            this.paymentSchedule = this.fundingCapture.paymentScheduleViewModel;
            this.bankDetail = this.fundingCapture.bankDetailViewModel;
            this.document = this.fundingCapture.documentViewModel;

            this.paymentFrequencyId = this.fundingDetail.frequencyId;
            this.startDate = this.fundingDetail.startDate;
            this.amountAwarded = this.fundingDetail.amountAwarded;

            this._spinner.hide();
          },
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
          }
        );
      }
    );
  }
}
