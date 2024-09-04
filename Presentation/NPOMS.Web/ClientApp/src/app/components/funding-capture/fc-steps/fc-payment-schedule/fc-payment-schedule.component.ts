import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { FrequencyEnum } from 'src/app/models/enums';
import { IFundingCaptureViewModel, IPaymentScheduleViewModel } from 'src/app/models/interfaces';
import { FundingManagementService } from 'src/app/services/api-services/funding-management/funding-management.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-fc-payment-schedule',
  templateUrl: './fc-payment-schedule.component.html',
  styleUrls: ['./fc-payment-schedule.component.css']
})
export class FCPaymentScheduleComponent implements OnInit {

  @Input() toggleable: boolean;
  @Input() paymentSchedule: IPaymentScheduleViewModel;
  @Output() paymentScheduleChanged: EventEmitter<IPaymentScheduleViewModel> = new EventEmitter<IPaymentScheduleViewModel>();
  @Input() fundingCapture: IFundingCaptureViewModel;
  @Input() isEdit: boolean;

  private _validated: boolean;
  @Input()
  get validated(): boolean { return this._validated; }
  set validated(validated: boolean) { this._validated = validated; }

  private _paymentFrequencyId: number;
  @Input()
  get paymentFrequencyId(): number { return this._paymentFrequencyId; }
  set paymentFrequencyId(paymentFrequencyId: number) { this._paymentFrequencyId = paymentFrequencyId; this.generateFundingPaymentSchedules(); }

  private _startDate: string;
  @Input()
  get startDate(): string { return this._startDate; }
  set startDate(startDate: string) { this._startDate = startDate; this.generateFundingPaymentSchedules(); }

  private _amountAwarded: number;
  @Input()
  get amountAwarded(): number { return this._amountAwarded; }
  set amountAwarded(amountAwarded: number) { this._amountAwarded = amountAwarded; this.generateFundingPaymentSchedules(); }

  public get FrequencyEnum(): typeof FrequencyEnum {
    return FrequencyEnum;
  }

  cols: any[];

  constructor(
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _fundingManagementRepo: FundingManagementService
  ) { }

  ngOnInit(): void {
    this.cols = [
      { header: 'Compliant Cycle', width: '15%' },
      { header: 'Payment Date', width: '15%' },
      { header: 'Payment Status', width: '15%' },
      { header: 'Allocated Amount', width: '15%' },
      { header: 'Approved Amount', width: '15%' },
      { header: 'Paid Amount', width: '15%' }
    ];
  }

  private generateFundingPaymentSchedules() {
    if (this.paymentFrequencyId && this.startDate && this.amountAwarded && this.isEdit) {
      this._spinner.show();
      this._fundingManagementRepo.generatePaymentSchedule(this.fundingCapture.id, this.paymentFrequencyId, this.startDate, this.amountAwarded).subscribe(
        (results) => {
          this.paymentSchedule = results;
          this.paymentScheduleChanged.emit(this.paymentSchedule);
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }
}
