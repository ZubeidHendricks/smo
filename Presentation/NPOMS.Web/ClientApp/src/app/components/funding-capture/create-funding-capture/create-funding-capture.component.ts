import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, Message } from 'primeng/api';
import { PermissionsEnum, StatusEnum } from 'src/app/models/enums';
import { IBankDetailViewModel, IDocumentViewModel, IFundingCaptureViewModel, IFundingDetailViewModel, INpoViewModel, ISDAViewModel, IUser } from 'src/app/models/interfaces';
import { FundingManagementService } from 'src/app/services/api-services/funding-management/funding-management.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

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

  menuActions: MenuItem[];
  validationErrors: Message[];

  fundingCapture = {} as IFundingCaptureViewModel;
  fundingDetail = {
    allowVariableFunding: false,
    allowClaims: false
  } as IFundingDetailViewModel;
  sda = {} as ISDAViewModel;
  bnkDetail = {} as IBankDetailViewModel;
  document = {} as IDocumentViewModel;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _fundingManagementRepo: FundingManagementService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _activeRouter: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.AddFundingCapture))
          this._router.navigate(['401']);

        this.buildMenu();
        this.loadFundingCapture();
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
            console.log('entity', this.entity);
            console.log('fundingDetail', this.fundingDetail);
            this.saveItems(StatusEnum.Saved);
          }
        },
        {
          label: 'Submit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {

          }
        },
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

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[0].visible = false;
  }

  private saveItems(status: StatusEnum) {
    if (this.canContinue(status)) {

    }
  }

  private canContinue(status: StatusEnum) {
    this.validationErrors = [];

    if (status === StatusEnum.Saved)
      this.validateRequiredFields();

    // if (status === StatusEnum.PendingReview)
    //   this.formValidate();

    this.menuActions[0].visible = this.validationErrors.length == 0 ? false : true;
    return this.validationErrors.length == 0 ? true : false;
  }

  private validateRequiredFields() {
    var fundingDetail = this.fundingDetail;
    if (!fundingDetail.financialYearId || !fundingDetail.programmeId || !fundingDetail.subProgrammeId || !fundingDetail.subProgrammeTypeId)
      this.validationErrors.push({ severity: 'error', summary: "Funding Details:", detail: "Please capture required fields." });
  }

  private loadFundingCapture() {
    this._spinner.show();
    this._activeRouter.paramMap.subscribe(
      params => {
        let npoId = params.get('npoId');

        this._fundingManagementRepo.getFundingCaptureByNpoId(Number(npoId)).subscribe(
          (results) => {
            this.entity = results;
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
