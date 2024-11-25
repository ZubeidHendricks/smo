import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageService } from 'primeng/api';
import { DropdownTypeEnum } from 'src/app/models/enums';
import { IFrequency, IFundingDetailViewModel, INpoViewModel } from 'src/app/models/interfaces';
import { FundingManagementService } from 'src/app/services/api-services/funding-management/funding-management.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-fc-funding-detail',
  templateUrl: './fc-funding-detail.component.html',
  styleUrls: ['./fc-funding-detail.component.css'],
  providers: [MessageService]
})
export class FCFundingDetailComponent implements OnInit {

  @Input() toggleable: boolean;
  @Input() npo: INpoViewModel;
  @Input() fundingDetail: IFundingDetailViewModel;
  @Output() paymentFrequencyChanged: EventEmitter<number> = new EventEmitter<number>();
  @Output() startDateChanged: EventEmitter<string> = new EventEmitter<string>();
  @Output() amountAwardedChanged: EventEmitter<number> = new EventEmitter<number>();
  @Input() isEdit: boolean;

  canEditAward: boolean;

  private _validated: boolean;
  @Input()
  get validated(): boolean { return this._validated; }
  set validated(validated: boolean) { this._validated = validated; }

  minDate: Date;
  maxDate: Date;
  finYearStartDate: Date;

  action: string = 'create';

  stateOptions: any[];

  paymentFrequencies: IFrequency[];
  selectedPaymentFrequency: IFrequency;

  addendumText: string = 'Funding Capture';

  amount: string = "0.00";

  constructor(
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _datepipe: DatePipe,
    private _fundingManagementRepo: FundingManagementService,
    private _activeRouter: ActivatedRoute,
    private _router: Router,
  ) { }

  ngOnInit(): void {
    this.loadFrequencies();
    this.updateDateField(this.fundingDetail.financialYearStartDate, this.fundingDetail.financialYearEndDate);
    console.log('this.fundingDetail', this.fundingDetail);
    this.addendumText = this.fundingDetail.isAddendum ? 'Addendum Funding Capture' : 'Funding Capture';

    this.stateOptions = [
      { label: 'Yes', value: true },
      { label: 'No', value: false }
    ];
  }


  editAwardAmount(){
    if (!this.isEdit)
      return false;

    if (this.fundingDetail.programmeBudget === 0){
      return true;
    }

    if (this.action === 'addendum'){
      this.npo.cCode = this.npo.cCode + 'ADDENDUM';
    }
  }

  private loadFrequencies() {

    this._activeRouter.paramMap.subscribe(
      params => {
        let sku = params.get('id');
        this.action = this._router.url.includes('addendum') ? 'addendum' : 'create';
      });

    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Frequencies, false).subscribe(
      (results) => {
        this.paymentFrequencies = results;
        this.selectedPaymentFrequency = this.fundingDetail.frequencyId ? this.paymentFrequencies.find(x => x.id === this.fundingDetail.frequencyId) : null;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private updateDateField(startDate: Date, endDate: Date) {
    let newStartDate = new Date(startDate);
    let newEndDate = new Date(endDate);
    let today = new Date();
    let finDateMin = new Date(this.fundingDetail.financialYearStartDate);

    if (finDateMin > newStartDate)
      this.minDate = new Date(finDateMin);
    else
      this.minDate = newStartDate;

    this.maxDate = newEndDate;
  }

  public valueChanged() {
    this.fundingDetail.startDate = this.fundingDetail.startDate ? this._datepipe.transform(this.fundingDetail.startDate, 'yyyy-MM-dd') : null;
    this.fundingDetail.frequencyId = this.selectedPaymentFrequency ? this.selectedPaymentFrequency.id : null;
    this.fundingDetail.amountAwarded = this.fundingDetail.amountAwarded ? this.fundingDetail.amountAwarded : 0;
    this._fundingManagementRepo.updateFundingDetail(this.fundingDetail).subscribe();

    this.paymentFrequencyChanged.emit(this.fundingDetail.frequencyId);
    this.startDateChanged.emit(this.fundingDetail.startDate);
    this.amountAwardedChanged.emit(this.fundingDetail.amountAwarded);
  }
}
