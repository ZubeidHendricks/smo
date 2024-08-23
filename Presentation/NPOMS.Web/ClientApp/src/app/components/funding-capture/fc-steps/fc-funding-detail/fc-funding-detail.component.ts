import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { CalculationTypeEnum, DropdownTypeEnum, FundingTypeEnum } from 'src/app/models/enums';
import { IFinancialYear, IFrequency, IFundingDetailViewModel, INpoViewModel, IProgramme, IServicesRendered, ISubProgramme, ISubProgrammeType } from 'src/app/models/interfaces';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-fc-funding-detail',
  templateUrl: './fc-funding-detail.component.html',
  styleUrls: ['./fc-funding-detail.component.css']
})
export class FCFundingDetailComponent implements OnInit {

  @Input() entity: INpoViewModel;
  @Input() fundingDetail = {} as IFundingDetailViewModel;
  @Output() fundingDetailChange: EventEmitter<IFundingDetailViewModel> = new EventEmitter<IFundingDetailViewModel>();
  @Input() toggleable: boolean;

  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;
  disableStartDate: boolean = true;
  minDate: Date;
  maxDate: Date;

  stateOptions: any[];

  paymentFrequencies: IFrequency[];
  selectedPaymentFrequency: IFrequency;

  programmes: IProgramme[];
  filteredProgrammes: IProgramme[];
  selectedProgramme: IProgramme;

  subProgrammes: ISubProgramme[];
  filteredSubProgrammes: ISubProgramme[];
  selectedSubProgramme: ISubProgramme;

  subProgrammeTypes: ISubProgrammeType[];
  filteredSubProgrammeTypes: ISubProgrammeType[];
  selectedSubProgrammeType: ISubProgrammeType;

  servicesRendered: IServicesRendered[];

  amount: string = "0.00";

  constructor(
    private _dropdownRepo: DropdownService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _npoProfileRepo: NpoProfileService
  ) { }

  ngOnInit(): void {
    this.loadFinancialYears();
    this.loadFrequencies();
    this.loadProgrammes();
    this.loadSubProgrammes();
    this.loadSubProgrammeTypes();

    this.stateOptions = [
      { label: 'Yes', value: true },
      { label: 'No', value: false }
    ];
  }

  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        this.financialYears = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadFrequencies() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Frequencies, false).subscribe(
      (results) => {
        this.paymentFrequencies = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  financialYearChange(finYear: IFinancialYear) {
    this.disableStartDate = false;
    this.updateDateField(finYear.startDate, finYear.endDate);
  }

  private updateDateField(startDate: Date, endDate: Date) {
    let newStartDate = new Date(startDate);
    let newEndDate = new Date(endDate);
    let today = new Date();

    if (today > newStartDate)
      this.minDate = new Date();
    else
      this.minDate = newStartDate;

    this.maxDate = newEndDate;
  }

  private loadProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
      (results) => {
        this.programmes = results;
        this.loadServicesRendered();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSubProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgramme, false).subscribe(
      (results) => {
        this.subProgrammes = results;
        this.loadServicesRendered();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadSubProgrammeTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.SubProgrammeTypes, false).subscribe(
      (results) => {
        this.subProgrammeTypes = results;
        this.loadServicesRendered();
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadServicesRendered() {
    if (this.programmes && this.subProgrammes && this.subProgrammeTypes) {
      this._spinner.show();
      this.filteredProgrammes = [];

      this._npoProfileRepo.getServicesRenderedByNpoProfileId(355, "fundingCapture").subscribe(
        (results) => {
          this.servicesRendered = results;

          this.filteredProgrammes = this.programmes.filter(x => {
            return this.servicesRendered.some(y => {
              return x.id === y.programmeId;
            });
          });

          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  programmeChange(programme: IProgramme) {
    this.selectedSubProgramme = null;
    this.selectedSubProgrammeType = null;

    this.filteredSubProgrammes = [];
    this.filteredSubProgrammeTypes = [];

    if (programme.id != null) {
      this.filteredSubProgrammes = this.subProgrammes.filter(x => {
        return this.servicesRendered.some(y => {
          return x.id === y.subProgrammeId && x.programmeId === programme.id;
        });
      });
    }
  }

  subProgrammeChange(subProgramme: ISubProgramme) {
    this.selectedSubProgrammeType = null;
    this.filteredSubProgrammeTypes = [];

    if (subProgramme.id != null) {
      this.filteredSubProgrammeTypes = this.subProgrammeTypes.filter(x => x.subProgrammeId === subProgramme.id);
      this.filteredSubProgrammeTypes = this.subProgrammeTypes.filter(x => {
        return this.servicesRendered.some(y => {
          return x.id === y.subProgrammeTypeId && x.subProgrammeId === subProgramme.id;
        });
      });
    }
  }

  valueChanged() {
    this.fundingDetail.financialYearId = this.selectedFinancialYear ? this.selectedFinancialYear.id : null;
    this.fundingDetail.fundingTypeId = FundingTypeEnum.Annual;
    this.fundingDetail.frequencyId = this.selectedPaymentFrequency ? this.selectedPaymentFrequency.id : null;
    this.fundingDetail.programmeId = this.selectedProgramme ? this.selectedProgramme.id : null;
    this.fundingDetail.subProgrammeId = this.selectedSubProgramme ? this.selectedSubProgramme.id : null;;
    this.fundingDetail.subProgrammeTypeId = this.selectedSubProgrammeType ? this.selectedSubProgrammeType.id : null;
    //this.fundingDetail.amountAwarded: number;
    this.fundingDetail.calculationTypeId = CalculationTypeEnum.Summary;
    this.fundingDetailChange.emit(this.fundingDetail);
  }
}
