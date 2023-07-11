import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { DeclarationTypeEnum, DropdownTypeEnum, FundingApplicationStepsEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, IFundAppDeclaration, IFundingApplicationDetails, IUser } from 'src/app/models/interfaces';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-declaration',
  templateUrl: './declaration.component.html',
  styleUrls: ['./declaration.component.css']
})
export class DeclarationComponent implements OnInit {

  @Input() fundingApplicationDetails: IFundingApplicationDetails;
  @Input() isDisabled: boolean;
  @Input() readonlyView: boolean;

  profile: IUser;
  isDataAvailable: boolean;
  review: IFundAppDeclaration;

  constructor(
    private _authService: AuthService,
    private bidRepo: BidService,
    private _loggerService: LoggerService,
    private _spinner: NgxSpinnerService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this._spinner.show();
        this.profile = profile;
        this.loadSignOff();
      }
    });
  }

  private loadSignOff() {
    this.bidRepo.getSignOff(FundingApplicationStepsEnum.Declaration, this.fundingApplicationDetails.id, DeclarationTypeEnum.Bidders1).subscribe(
      (results) => {
        this.review = results != null ? results : {} as IFundAppDeclaration;
        this.isDataAvailable = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public update() {
    this.review.declarationType = DeclarationTypeEnum.Bidders1;

    this.review.isActive = true;
    this.review.createdUser = null;

    this.bidRepo.updateSignOff(this.review, FundingApplicationStepsEnum.Declaration, DeclarationTypeEnum.Bidders1).subscribe(
      (resp) => {
        this.loadSignOff();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
}
