import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { SelectItem } from 'primeng/api';
import { StatusEnum } from 'src/app/models/enums';
import { IFundingCaptureViewModel } from 'src/app/models/interfaces';
import { FundingManagementService } from 'src/app/services/api-services/funding-management/funding-management.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-fc-approval',
  templateUrl: './fc-approval.component.html',
  styleUrls: ['./fc-approval.component.css']
})
export class FCApprovalComponent implements OnInit {

  @Input() fundingCapture: IFundingCaptureViewModel;
  @Input() isApproval: boolean;

  acceptDeclineDropdown: SelectItem[];
  selectedOption: SelectItem;

  constructor(
    private _router: Router,
    private _fundingManagementRepo: FundingManagementService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this.acceptDeclineDropdown = [
      { label: 'Approve', value: StatusEnum.Approved },
      { label: 'Decline', value: StatusEnum.Declined }
    ];
  }

  public getClassName(section: string) {
    let isMandatory: boolean = false;

    switch (section) {
      case 'approver':
        isMandatory = this.selectedOption && this.selectedOption.value === StatusEnum.Declined ? true : false;
        break;
    }

    return isMandatory ? 'mandatory-content' : 'non-mandatory-content';
  }

  public cancel() {
    this._router.navigateByUrl('funding-capture');
  }

  public disableSubmit() {
    let hasErrors: boolean[] = [];

    if (!this.selectedOption)
      hasErrors.push(true);

    if (this.selectedOption && this.selectedOption.value === StatusEnum.Declined && !this.fundingCapture.approverComment)
      hasErrors.push(true);

    return hasErrors.includes(true) ? true : false;
  }

  public updateApproverDetails() {
    this._spinner.show();
    this.fundingCapture.statusId = this.selectedOption.value;

    this._fundingManagementRepo.updateApproverDetail(this.fundingCapture).subscribe(
      (resp) => {
        this._spinner.hide();
        this._router.navigateByUrl('funding-capture');
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
}
