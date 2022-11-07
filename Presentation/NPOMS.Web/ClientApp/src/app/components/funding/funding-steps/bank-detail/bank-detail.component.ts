import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { DropdownTypeEnum } from 'src/app/models/enums';
import { IAccountType, IBank, IBankDetail, IBranch, INpoProfile } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-bank-detail',
  templateUrl: './bank-detail.component.html',
  styleUrls: ['./bank-detail.component.css']
})
export class BankDetailComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() npoProfile: INpoProfile;

  bankDetails: IBankDetail[];
  banks: IBank[];
  selectedBank: IBank;
  branches: IBranch[];
  selectedBranch: IBranch;
  accountTypes: IAccountType[];
  selectedAccountType: IAccountType;
  accountNumbers: any[];
  selectedAccountNumber: any;

  constructor(
    private _npoProfileRepo: NpoProfileService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _dropdownRepo: DropdownService
  ) { }

  ngOnInit(): void {
    this.loadBankDetails();
  }

  private loadBankDetails() {
    if (this.npoProfile) {
      this._spinner.show();
      this._npoProfileRepo.getBankDetailByNpoProfileId(this.npoProfile.id).subscribe(
        (results) => {
          this.bankDetails = results;
          this.loadBanks();
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadBanks() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Banks, false).subscribe(
      (results) => {
        // Filter banks based on the bank details captured in npo profile
        this.banks = results.filter(bank => {
          return this.bankDetails.find(detail => {
            return bank.id === detail.bankId;
          });
        });
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  bankChange() {
    if (this.selectedBank) {
      this.branches = [];
      this.selectedBranch = null;
      this.accountTypes = [];
      this.selectedAccountType = null;
      this.accountNumbers = [];
      this.selectedAccountNumber = null;

      this.loadBranches();
    }
  }

  private loadBranches() {
    // Filter bank details on selected bank
    let bankDetails = this.bankDetails.filter(x => x.bankId === this.selectedBank.id);

    if (bankDetails && bankDetails.length > 0) {
      // Get distinct branch ids from the filtered bank details
      let branchIds = bankDetails.map(x => x.branchId).filter((value, index, self) => self.indexOf(value) === index);

      if (branchIds && branchIds.length > 0) {
        branchIds.forEach(branchId => {
          this._dropdownRepo.getBranchById(branchId).subscribe(
            (results) => {
              this.branches.push(results);
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        });
      }
    }
  }

  branchChange() {
    if (this.selectedBank && this.selectedBranch) {
      this.accountTypes = [];
      this.selectedAccountType = null;
      this.accountNumbers = [];
      this.selectedAccountNumber = null;

      this.loadAccountTypes();
    }
  }

  private loadAccountTypes() {
    // Filter bank details on selected bank and selected branch
    let bankDetails = this.bankDetails.filter(x => x.bankId === this.selectedBank.id && x.branchId === this.selectedBranch.id);

    if (bankDetails && bankDetails.length > 0) {
      // Get distinct account type ids from the filtered bank details
      let accountTypeIds = bankDetails.map(x => x.accountTypeId).filter((value, index, self) => self.indexOf(value) === index);

      if (accountTypeIds && accountTypeIds.length > 0) {
        accountTypeIds.forEach(accountTypeId => {
          this._dropdownRepo.getAccountTypeById(accountTypeId).subscribe(
            (results) => {
              this.accountTypes.push(results);
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        });
      }
    }
  }

  accountTypeChange() {
    if (this.selectedBank && this.selectedBranch && this.selectedAccountType) {
      this.accountNumbers = [];
      this.selectedAccountNumber = null;

      this.loadAccountNumbers();
    }
  }

  private loadAccountNumbers() {
    // Filter bank details on selected bank, selected branch and selected account type
    let bankDetails = this.bankDetails.filter(x => x.bankId === this.selectedBank.id && x.branchId === this.selectedBranch.id && x.accountTypeId === this.selectedAccountType.id);

    if (bankDetails && bankDetails.length > 0) {
      bankDetails.forEach(item => {
        this.accountNumbers.push({ name: item.accountNumber, value: item.accountNumber });
      });
    }
  }

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }
}
