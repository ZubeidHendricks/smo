import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { MenuItem, Message, MessageService } from 'primeng/api';
import { PermissionsEnum, StatusEnum } from 'src/app/models/enums';
import { IBankDetailViewModel, IDocumentViewModel, IFundingCaptureViewModel, IFundingDetailViewModel, INpoViewModel, ISDAViewModel, IUser } from 'src/app/models/interfaces';
import { FundingManagementService } from 'src/app/services/api-services/funding-management/funding-management.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-edit-funding-capture',
  templateUrl: './edit-funding-capture.component.html',
  styleUrls: ['./edit-funding-capture.component.css'],
  providers: [MessageService]
})
export class EditFundingCaptureComponent implements OnInit {

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
  validationErrors: Message[];

  npo: INpoViewModel;
  fundingCapture: IFundingCaptureViewModel;
  fundingDetail: IFundingDetailViewModel;
  sda: ISDAViewModel;
  bankDetail: IBankDetailViewModel;
  document: IDocumentViewModel;

  // Highlight required fields on validate click
  validated: boolean = false;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _fundingManagementRepo: FundingManagementService,
    private _loggerService: LoggerService,
    private _messageService: MessageService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.EditFundingCapture))
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
            this.saveItems(StatusEnum.Saved);
          }
        },
        {
          label: 'Submit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            this.saveItems(StatusEnum.PendingApproval);
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
    this.validated = false;
    this.validationErrors = [];
    this.menuActions[0].visible = false;
  }

  private saveItems(status: StatusEnum) {
    if (this.canContinue(status)) {
      this._spinner.show();
      this.fundingCapture.statusId = status;

      this._fundingManagementRepo.updateFundingCapture(this.fundingCapture).subscribe(
        (resp) => {
          this._spinner.hide();
          status === StatusEnum.Saved ? this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Funding Capture successfully saved.' }) : this._router.navigateByUrl('funding-capture');
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private canContinue(status: StatusEnum) {
    this.validationErrors = [];

    if (status === StatusEnum.PendingApproval)
      this.formValidate();

    return this.validationErrors.length == 0 ? true : false;
  }

  private formValidate() {
    this.validated = true;
    this.loadFunding();

    if (!this.fundingDetail.financialYearId || !this.fundingDetail.startDate || !this.fundingDetail.fundingTypeId || !this.fundingDetail.frequencyId || !this.fundingDetail.programmeId || !this.fundingDetail.subProgrammeId || !this.fundingDetail.subProgrammeTypeId || this.fundingDetail.amountAwarded < 1 || !this.fundingDetail.calculationTypeId)
      this.validationErrors.push({ severity: 'error', summary: "Funding:", detail: "Please capture all required fields." });

    if (this.fundingDetail.amountAwarded < 1)
      this.validationErrors.push({ severity: 'warn', summary: "Amounts:", detail: "Please capture Amount Awarded." });

    if (!this.sda.serviceDeliveryAreaId || !this.sda.placeId)
      this.validationErrors.push({ severity: 'error', summary: "Service Delivery Area:", detail: "Please capture all required fields." });

    if (!this.bankDetail.programBankDetailsId)
      this.validationErrors.push({ severity: 'error', summary: "Bank Details:", detail: "Please capture all required fields." });
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
            this.bankDetail = this.fundingCapture.bankDetailViewModel;
            this.document = this.fundingCapture.documentViewModel;
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
