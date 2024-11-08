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

  showComplianceDialog: boolean = false;
  showComplianceDetail: boolean = false;
  blockEditCompliance: boolean = false;

  yesNoOptions: any[] = [
    {name: 'YES', value: 'YES'},
    {name: 'NO', value: 'NO'},
  ];


  yesNoValue: any;

  selectedTpaOption: any = 'NO';

  selectedProgressOption: any = 'NO';

  selectedNonFinancialOption: any = 'NO';

  selectedOverrideOption: any = 'NO';

  selectedComplianceOption: any = 'NO';


  cols: any[];
  compliances: any[];
  selectedCompliance: any;

  selectedCycleNo: number = 5;
  selectedTpa:boolean = false;

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
      { header: 'Paid Amount', width: '15%' },
      { header: 'Compliance', width: '15%' }
    ];

    this.compliances = [
      { finyear: '2024 - 2025', complianceCycle: 1, signedTpa: true, progressReport: true, nonFinData: true, isOverridden: true, isCompliant: true},
      { finyear: '2024 - 2025', complianceCycle: 2, signedTpa: true, progressReport: false, nonFinData: true, isOverridden: false, isCompliant: false},
      { finyear: '2024 - 2025', complianceCycle: 3, signedTpa: false, progressReport: false, nonFinData: false, isOverridden: false, isCompliant: false},
      { finyear: '2024 - 2025', complianceCycle: 4, signedTpa: false, progressReport: false, nonFinData: false, isOverridden: false, isCompliant: false}

    ];

    console.log('paymentSchedule',this.paymentSchedule);
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

  onComplianceChange(rowdata: any){

    this.selectedCycleNo = rowdata.cycleNumber;
    this.selectedComplianceOption = rowdata.isCompliant;

    if (rowdata.isCompliant) {

      this.compliances = [
        {finyear: rowdata.paymentDate,
         complianceCycle: rowdata.cycleNumber,
         signedTpa: !rowdata.isCompliant, 
         progressReport: !rowdata.isCompliant, 
         nonFinData: !rowdata.isCompliant, 
         isOverridden: !rowdata.isCompliant, 
         isCompliant: !rowdata.isCompliant}
      ];

    }

    this.showComplianceDialog = true;
  }

  hideComplianceDialog(){
    this.showComplianceDialog = false;
  }

  onEditCompliance(selectedCompliance){

    console.log('onEditCompliance', selectedCompliance);
    this.showComplianceDialog = false;
    this.showComplianceDetail = true;

  }

  onSaveCompliance(){
    let id = this.paymentSchedule.paymentScheduleItemViewModels.filter(x => x.cycleNumber === this.selectedCycleNo)[0]?.id;
    let compliant = this.paymentSchedule.paymentScheduleItemViewModels.filter(x => x.cycleNumber === this.selectedCycleNo)[0]?.isCompliant;
    console.log('id',id);
    console.log('compliant',compliant);

    if (this.selectedComplianceOption === 'YES'){
    this._fundingManagementRepo.updatePaymentSchedules(this.paymentSchedule).subscribe(
      (results) => {
        //this.paymentSchedule = results;
        this.paymentScheduleChanged.emit(this.paymentSchedule);
        this._spinner.hide();
        this.blockEditCompliance = true;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }


    this.showComplianceDetail = false;


    console.log('----',  this.paymentSchedule.paymentScheduleItemViewModels.filter(x => x.cycleNumber === this.selectedCycleNo)[0]?.isCompliant);

    //this.paymentSchedule.paymentScheduleItemViewModels.filter(x => x.cycleNumber === this.selectedCycleNo)[0]?.isCompliant.value = this.selectedComplianceOption
    //this.selectedCompliance
  }

  blockEditComplianceCheck(){

    return this.blockEditCompliance;
  }

  onOptionChange(){


    if (this.selectedTpaOption==='YES' && this.selectedProgressOption==='YES' && this.selectedNonFinancialOption === 'YES'){
      this.selectedComplianceOption = 'YES'
    } else {
            this.selectedComplianceOption = 'NO'
    }
  }
}
