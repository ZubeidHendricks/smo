import { Component, Input, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { DropdownTypeEnum } from 'src/app/models/enums';
import { IAccountType, IBank, IBankDetailViewModel, IBranch, IFundingDetailViewModel, INpoViewModel, IProgramBankDetails } from 'src/app/models/interfaces';
import { FundingManagementService } from 'src/app/services/api-services/funding-management/funding-management.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-fc-bank-detail',
  templateUrl: './fc-bank-detail.component.html',
  styleUrls: ['./fc-bank-detail.component.css']
})
export class FCBankDetailComponent implements OnInit {

  @Input() toggleable: boolean;
  @Input() bankDetail: IBankDetailViewModel;
  @Input() npo: INpoViewModel;
  @Input() fundingDetail: IFundingDetailViewModel;
  @Input() isEdit: boolean;

  private _validated: boolean;
  @Input()
  get validated(): boolean { return this._validated; }
  set validated(validated: boolean) { this._validated = validated; }

  banks: IBank[];
  filteredBanks: IBank[];
  selectedBank: IBank;

  branches: IBranch[];
  filteredBranches: IBranch[];
  selectedBranch: IBranch;

  accountTypes: IAccountType[];
  filteredAccountTypes: IAccountType[];
  selectedAccountType: IAccountType;

  bankDetails: IProgramBankDetails[];
  filteredBankDetails: IProgramBankDetails[];
  selectedBankDetail: IProgramBankDetails;

  constructor(
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _npoProfileRepo: NpoProfileService,
    private _fundingManagementRepo: FundingManagementService
  ) { }

  ngOnInit(): void {
    this.loadBanks();
  }

  private loadBanks() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Banks, false).subscribe(
      (results) => {
        this.banks = results;
        this.loadProgrammeBankDetails();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProgrammeBankDetails() {
    this._npoProfileRepo.getProgrammeBankDetailsById(this.fundingDetail.programmeId, this.npo.npoProfileId).subscribe(
      (results) => {
        this.bankDetails = results.filter(x => x.subProgrammeId === this.fundingDetail.subProgrammeId && x.subProgrammeTypeId === this.fundingDetail.subProgrammeTypeId);

        let bankIds = this.bankDetails.map(x => { return x.bankId; });
        this.filteredBanks = this.banks.filter(x => bankIds.includes(x.id));

        this.loadBranches();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadBranches() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Branches, false).subscribe(
      (results) => {
        this.branches = results;
        this.loadAccountTypes();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadAccountTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.AccountTypes, false).subscribe(
      (results) => {
        this.accountTypes = results;
        this.updateSelectedValues();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateSelectedValues() {
    if (this.bankDetail.programBankDetailsId != null) {
      let bankDetail = this.bankDetails.find(x => x.id === this.bankDetail.programBankDetailsId);

      this.selectedBank = this.filteredBanks.find(x => x.id === bankDetail.bankId);
      this.bankChange(this.selectedBank);

      this.selectedBranch = this.filteredBranches.find(x => x.id === bankDetail.branchId);
      this.branchChange(this.selectedBranch);

      this.selectedAccountType = this.filteredAccountTypes.find(x => x.id === bankDetail.accountTypeId);
      this.accountTypeChange(this.selectedAccountType);

      this.selectedBankDetail = this.filteredBankDetails.find(x => x.id === bankDetail.id);
    }
  }

  public bankChange(bank: IBank) {
    this.filteredBranches = [];
    this.selectedBranch = null;

    this.filteredAccountTypes = [];
    this.selectedAccountType = null;

    this.filteredBankDetails = [];
    this.selectedBankDetail = null;

    if (bank.id != null) {
      this.filteredBranches = this.branches.filter(x => {
        return this.bankDetails.some(y => {
          return x.id === y.branchId && x.bankId === bank.id;
        });
      });
    }
  }

  public branchChange(branch: IBranch) {
    this.filteredAccountTypes = [];
    this.selectedAccountType = null;

    this.filteredBankDetails = [];
    this.selectedBankDetail = null;

    let bankDetail = this.bankDetails.find(x => x.bankId === this.selectedBank.id && x.branchId === branch.id);
    this.filteredAccountTypes = this.accountTypes.filter(x => x.id === bankDetail.accountTypeId);
  }

  public accountTypeChange(accountType: IAccountType) {
    this.filteredBankDetails = [];
    this.selectedBankDetail = null;

    this.filteredBankDetails = this.bankDetails.filter(x => x.bankId === this.selectedBank.id && x.branchId === this.selectedBranch.id && x.accountTypeId === accountType.id);
  }

  public valueChanged() {
    this.bankDetail.programBankDetailsId = this.selectedBankDetail ? this.selectedBankDetail.id : null;
    this._fundingManagementRepo.updateBankDetails(this.bankDetail).subscribe();
  }
}
