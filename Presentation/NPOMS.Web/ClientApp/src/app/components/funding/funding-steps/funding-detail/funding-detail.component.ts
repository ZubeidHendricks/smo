import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Message, MessageService } from 'primeng/api';
import { AccessStatusEnum, DropdownTypeEnum } from 'src/app/models/enums';
import { IFinancialYear, IFrequency, INpo, INpoProfile, IProgramme, IProgrammeBudget, ISubProgramme, ISubProgrammeType } from 'src/app/models/interfaces';
import { BudgetService } from 'src/app/services/api-services/budget/budget.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-funding-detail',
  templateUrl: './funding-detail.component.html',
  styleUrls: ['./funding-detail.component.css']
})
export class FundingDetailComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() newFunding: boolean;
  @Output() retrievedNpoProfile = new EventEmitter<INpoProfile>();

  validationErrors: Message[] = [];

  npos: INpo[];
  selectedNpo: INpo;

  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  programmes: IProgramme[];
  filteredProgrammes: IProgramme[];
  selectedProgramme: IProgramme;

  subProgrammes: ISubProgramme[];
  selectedSubProgramme: ISubProgramme;

  subProgrammeTypes: ISubProgrammeType[];
  selectedSubProgrammeType: ISubProgrammeType;

  frequencies: IFrequency[];
  selectedFrequency: IFrequency;

  programmeBudget: IProgrammeBudget;

  // Highlight required fields on next click
  validated: boolean = false;

  //to be deleted...
  date1: Date;
  variableFunding: boolean;
  claims: boolean;
  amountAwarded: number;

  constructor(
    private _npoRepo: NpoService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _dropdownRepo: DropdownService,
    private _npoProfileRepo: NpoProfileService,
    private _messageService: MessageService,
    private _budgetRepo: BudgetService
  ) { }

  ngOnInit(): void {
    this.loadFinancialYears();
    this.loadProgrammes();
    this.loadFrequencies();
  }

  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        //Get until current financial year
        let currentDate = new Date();
        let currentFinancialYear = results.find(x => new Date(x.startDate) <= currentDate && new Date(x.endDate) >= currentDate);
        this.financialYears = results.filter(x => x.id <= currentFinancialYear.id);
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProgrammes() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
      (results) => {
        this.programmes = results;
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
        this.frequencies = results;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  search(event) {
    let query = event.query;
    this._npoRepo.getApprovedNpoByName(query).subscribe((results) => {
      this.npos = results;
    });
  }

  npoChange() {
    this.loadNpoProfile();
  }

  financialYearChange() {
    this.loadProgrammeBudget();
  }

  programmeChange() {
    this.subProgrammes = [];
    this.subProgrammeTypes = [];
    this.selectedSubProgramme = null;
    this.selectedSubProgrammeType = null;

    this.loadProgrammeBudget();
    this.loadSubProgrammes();
  }

  private loadProgrammeBudget() {
    if (this.selectedProgramme && this.selectedFinancialYear) {
      this._budgetRepo.getProgrammeBudgetByProgrammeId(this.selectedProgramme.id, this.selectedFinancialYear.id).subscribe(
        (results) => {
          this.programmeBudget = results;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadSubProgrammes() {
    if (this.selectedProgramme) {
      this._spinner.show();
      this._dropdownRepo.getEntitiesByEntityId(DropdownTypeEnum.SubProgramme, this.selectedProgramme.id).subscribe(
        (results) => {
          this.subProgrammes = results;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadNpoProfile() {
    if (this.selectedNpo) {
      this._npoProfileRepo.getNpoProfileByNpoId(this.selectedNpo.id).subscribe(
        (profile) => {
          this.retrievedNpoProfile.emit(profile);

          this._npoProfileRepo.getServicesRenderedByNpoProfileId(profile.id).subscribe(
            (services) => {
              // Populate filtered programmes based on npo profile services rendered programmes
              this.filteredProgrammes = this.programmes.filter(programme => {
                return services.find(service => {
                  return programme.id === service.programmeId;
                });
              });

              this._spinner.hide();
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  subProgrammeChange() {
    this.subProgrammeTypes = [];
    this.selectedSubProgrammeType = null;

    this.loadSubProgrammeTypes();
  }

  private loadSubProgrammeTypes() {
    if (this.selectedSubProgramme) {
      this._spinner.show();
      this._dropdownRepo.getEntitiesByEntityId(DropdownTypeEnum.SubProgrammeTypes, this.selectedSubProgramme.id).subscribe(
        (results) => {
          this.subProgrammeTypes = results;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  subProgrammeTypeChange() {

  }

  nextPage() {
    this.activeStep = this.activeStep + 1;
    this.activeStepChange.emit(this.activeStep);

    /*if (!this.selectedNpo || !this.selectedFinancialYear || !this.date1 || !this.selectedProgramme || !this.selectedSubProgramme || !this.selectedSubProgrammeType || !this.selectedFrequency || !this.amountAwarded) {
      this.validated = true;
      this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Missing detail required.' });
    }
    else {
      this.validated = false;
      // Create funding item in db...

      // Then move to next screen...
      this.activeStep = this.activeStep + 1;
      this.activeStepChange.emit(this.activeStep);
    }*/
  }
}
