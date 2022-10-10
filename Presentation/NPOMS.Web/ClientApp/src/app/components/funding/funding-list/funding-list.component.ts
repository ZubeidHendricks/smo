import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { AccessStatusEnum, DropdownTypeEnum, PermissionsEnum } from 'src/app/models/enums';
import { IFinancialYear, INpo, INpoProfile, IProgramme, IUser } from 'src/app/models/interfaces';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { Table } from 'primeng/table';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';

@Component({
  selector: 'app-funding-list',
  templateUrl: './funding-list.component.html',
  styleUrls: ['./funding-list.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class FundingListComponent implements OnInit {

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

  npos: INpo[];
  selectedNpo: INpo;

  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  programmes: IProgramme[];
  filteredProgrammes: IProgramme[];
  selectedProgramme: IProgramme;

  funding: any[];
  filteredFunding: any[];
  selectedFunding: any; // This is the selected funding when clicking on option buttons...

  cols: any[];
  buttonItems: MenuItem[];

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _npoRepo: NpoService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _dropdownRepo: DropdownService,
    private _npoProfileRepo: NpoProfileService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewNpoFunding))
          this._router.navigate(['401']);

        this.loadFinancialYears();
        this.loadProgrammes();
        this.buildButtonItems();
      }
    });

    this.cols = [
      { header: 'Financial Year', width: '10%' },
      { header: 'Programme', width: '20%' },
      { header: 'Sub-Programme Type', width: '20%' },
      { header: 'Payment Frequency', width: '15%' },
      { header: 'Programme Budget', width: '15%' },
      { header: 'Amount Awarded', width: '15%' },
      { header: 'Actions', width: '5%' }
    ];
  }

  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        //Get until current financial year
        let currentDate = new Date();
        let currentFinancialYear = results.find(x => new Date(x.startDate) <= currentDate && new Date(x.endDate) >= currentDate);
        this.financialYears = results.filter(x => x.id <= currentFinancialYear.id);

        // Select last financial year in list
        this.selectedFinancialYear = this.financialYears[this.financialYears.length - 1];

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

  private buildButtonItems() {
    this.buttonItems = [];

    if (this.profile) {

      this.buttonItems = [{
        label: 'Options',
        items: []
      }];

      if (this.IsAuthorized(PermissionsEnum.EditNpoFunding)) {
        this.buttonItems[0].items.push({
          label: 'Edit Funding',
          icon: 'fa fa-pencil-square-o wcg-icon',
          command: () => {
            this._router.navigateByUrl('npo-funding/edit/' + this.selectedFunding.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DeleteNpoFunding)) {
        this.buttonItems[0].items.push({
          label: 'Delete Funding',
          icon: 'fa fa-trash wcg-icon',
          command: () => {
            this.delete();
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ComplianceCheck)) {
        this.buttonItems[0].items.push({
          label: 'View Payment Schedule',
          icon: 'fa fa-calendar wcg-icon',
          command: () => {
            // this._router.navigateByUrl('workplan-indicator/manage/' + this.selectedApplication.id);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewAcceptedApplication)) {
        this.buttonItems[0].items.push({
          label: 'Compliance Check',
          icon: 'fa fa-check-circle wcg-icon',
          command: () => {
            // this._router.navigateByUrl('workplan-indicator/manage/' + this.selectedApplication.id);
          }
        });
      }
    }
  }

  search(event) {
    let query = event.query;
    this._npoRepo.getApprovedNpoByName(query).subscribe((results) => {
      this.npos = results;
    });
  }

  npoChange() {
    this.loadNpoProfile();
    this.filterFunding();
  }

  financialYearChange() {
    this.filterFunding();
  }

  programmeChange() {
    this.filterFunding();
  }

  private loadNpoProfile() {
    if (this.selectedNpo) {
      this._npoProfileRepo.getNpoProfileByNpoId(this.selectedNpo.id).subscribe(
        (profile) => {
          this.getServicesRendered(profile);
          this.getFunding(profile.npoId);
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private getServicesRendered(npoProfile: INpoProfile) {
    this._spinner.show();
    this._npoProfileRepo.getServicesRenderedByNpoProfileId(npoProfile.id).subscribe(
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
  }

  private getFunding(npoId: number) {
    console.log('npoId', npoId);
  }

  private filterFunding() {
    this.filteredFunding = this.funding;

    if (this.selectedNpo) {
      console.log('filter by organisation');
    }

    if (this.selectedFinancialYear) {
      console.log('filter by financial year');
    }

    if (this.selectedProgramme) {
      console.log('filter by programme');
    }
  }

  add() {
    this._router.navigateByUrl('npo-funding/create');
  }

  private delete() {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        console.log('delete funding');
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Funding successfully deleted.' });
      },
      reject: () => {
      }
    });
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }
}
