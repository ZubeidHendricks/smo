import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { CalculationTypeEnum, DropdownTypeEnum, FundingTypeEnum, PermissionsEnum, StatusEnum } from 'src/app/models/enums';
import { IFinancialYear, IFrequency, IFundingCaptureViewModel, IFundingDetailViewModel, INpoViewModel, IProgramme, IServicesRendered, IStatus, ISubProgramme, ISubProgrammeType, IUser } from 'src/app/models/interfaces';
import { FundingManagementService } from 'src/app/services/api-services/funding-management/funding-management.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { DownloadFundingCaptureComponent } from '../download-funding-capture/download-funding-capture.component';

@Component({
  selector: 'app-funding-capture-list',
  templateUrl: './funding-capture-list.component.html',
  styleUrls: ['./funding-capture-list.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class FundingCaptureListComponent implements OnInit {

  @ViewChild(DownloadFundingCaptureComponent) downloadFundingCaptureComponent: DownloadFundingCaptureComponent;

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
  npoCols: any[];
  cols: any[];

  npos: INpoViewModel[];
  selectedNpo = {} as INpoViewModel;

  displayDialog: boolean;
  servicesRendered: IServicesRendered[];

  allFinancialYears: IFinancialYear[];
  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  programmes: IProgramme[];
  filteredProgrammes: IProgramme[];
  selectedProgramme: IProgramme;

  subProgrammes: ISubProgramme[];
  filteredSubProgrammes: ISubProgramme[];
  selectedSubProgramme: ISubProgramme;

  subProgrammeTypes: ISubProgrammeType[];
  filteredSubProgrammeTypes: ISubProgrammeType[];
  selectedSubProgrammeType: ISubProgrammeType;

  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  // This is the selected funding when clicking on option buttons...
  selectedFundingCapture: IFundingCaptureViewModel;
  buttonItems: MenuItem[];

  paymentFrequencies: IFrequency[];
  statuses: IStatus[];

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _fundingManagementRepo: FundingManagementService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _dropdownRepo: DropdownService,
    private _npoProfileRepo: NpoProfileService,
    private _messageService: MessageService,
    private _confirmationService: ConfirmationService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewFundingCapture))
          this._router.navigate(['401']);

        this.loadFinancialYears();
        this.loadFrequencies();
        this.loadStatuses();
        this.buildButtonItems();
      }
    });

    this.npoCols = [
      { field: 'refNo', header: 'Ref. No.', width: '15%' },
      { field: 'name', header: 'Organisation Name', width: '60%' },
      { field: 'organisationTypeName', header: 'Organisation Type', width: '15%' }
    ];

    this.cols = [
      { field: 'financialYearName', header: 'Fin. Year', width: '8%' },
      { field: 'fundingDetailViewModel.programmeName', header: 'Programme', width: '17%' },
      { field: 'fundingDetailViewModel.subProgrammeTypeName', header: 'Sub-Programme Type', width: '15%' },
      { field: 'sdaViewModel.serviceDeliveryAreaName', header: 'Service Delivery Area', width: '10%' },
      { field: 'fundingDetailViewModel.frequencyName', header: 'Payment Frequency', width: '10%' },
      { header: 'Amount Awarded', width: '10%' },
      { header: 'Amount Paid', width: '10%' },
      { field: 'statusName', header: 'Status', width: '10%' }
    ];
  }

  private loadNpos() {
    this._fundingManagementRepo.getNposForFunding().subscribe(
      (results) => {
        this.npos = results;
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
      this.buttonItems = [
        {
          label: 'Actions',
          items: []
        }
      ];

      if (this.IsAuthorized(PermissionsEnum.EditFundingCapture)) {
        this.buttonItems[0].items.push({
          label: 'Edit Funding',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl(`funding-capture/edit/${this.selectedFundingCapture.id}`);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ApproveFundingCapture)) {
        this.buttonItems[0].items.push({
          label: 'Approve Funding',
          icon: 'fa fa-pencil-square-o',
          command: () => {
            this._router.navigateByUrl(`funding-capture/approve/${this.selectedFundingCapture.id}`);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.ViewFundingCapture)) {
        this.buttonItems[0].items.push({
          label: 'View Funding',
          icon: 'fa fa-file-text-o',
          command: () => {
            this._router.navigateByUrl(`funding-capture/view/${this.selectedFundingCapture.id}`);
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DeleteFundingCapture)) {
        this.buttonItems[0].items.push({
          label: 'Delete Funding',
          icon: 'fa fa-trash',
          command: () => {
            this.deleteFunding();
          }
        });
      }

      if (this.IsAuthorized(PermissionsEnum.DownloadFundingCapture)) {
        this.buttonItems[0].items.push({
          label: 'Download Funding',
          icon: 'fa fa-download',
          command: () => {
            this.downloadFunding();
          }
        });
      }
    }
  }

  private deleteFunding() {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._spinner.show();
        this.selectedFundingCapture.isActive = false;
        this._fundingManagementRepo.updateFundingCapture(this.selectedFundingCapture).subscribe(
          (resp) => {
            this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Funding Capture successfully deleted.' });
            this.loadNpos();
          },
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
          }
        );
      },
      reject: () => {
      }
    });
  }

  private downloadFunding() {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to download this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._spinner.show();

        this._fundingManagementRepo.getFundingById(this.selectedFundingCapture.id).subscribe(
          (results) => {
            this._spinner.hide();
            this.downloadFundingCaptureComponent.generatePDF(results);
          },
          (err) => {
            this._loggerService.logException(err);
            this._spinner.hide();
          }
        );
      },
      reject: () => {
      }
    });
  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  add(npo: INpoViewModel) {
    this._confirmationService.confirm({
      message: `Are you sure that you want to add funding for ${npo.name} (${npo.refNo})?`,
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.selectedNpo = npo;

        this.selectedFinancialYear = null;
        this.selectedProgramme = null;
        this.selectedSubProgramme = null;
        this.selectedSubProgrammeType = null;

        this.loadServicesRendered();
      },
      reject: () => {
      }
    });
  }

  private loadFrequencies() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Frequencies, false).subscribe(
      (results) => {
        this.paymentFrequencies = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadStatuses() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Statuses, false).subscribe(
      (results) => {
        this.statuses = results;
        this.statuses = this.statuses.filter(x => x.id === StatusEnum.Saved || x.id === StatusEnum.PendingApproval || x.id === StatusEnum.Approved || x.id === StatusEnum.Declined);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getFromCurrentFinYear().subscribe(
      (results) => {
        this.financialYears = results;
        this.loadProgrammes();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );

    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        this.allFinancialYears = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadProgrammes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Programmes, false).subscribe(
      (results) => {
        this.programmes = results;
        this.loadSubProgrammes();
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
        this.loadSubProgrammeTypes();
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
        this.loadNpos();
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

      this._npoProfileRepo.getServicesRenderedByNpoProfileId(this.selectedNpo.npoProfileId, "fundingCapture").subscribe(
        (results) => {
          this.servicesRendered = results;

          this.filteredProgrammes = this.programmes.filter(x => {
            return this.servicesRendered.some(y => {
              return x.id === y.programmeId;
            });
          });

          this.displayDialog = true;
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

  disableSave() {
    if (!this.selectedFinancialYear || !this.selectedProgramme || !this.selectedSubProgramme || !this.selectedSubProgrammeType)
      return true;

    return false;
  }

  save() {
    this._spinner.show();
    var fundingCapture = {
      npoId: this.selectedNpo.id,
      financialYearId: this.selectedFinancialYear.id,
      statusId: StatusEnum.Saved,
      isActive: true,
      fundingDetailViewModel: {
        financialYearId: this.selectedFinancialYear.id,
        fundingTypeId: FundingTypeEnum.Annual,
        programmeId: this.selectedProgramme.id,
        subProgrammeId: this.selectedSubProgramme.id,
        subProgrammeTypeId: this.selectedSubProgrammeType.id,
        calculationTypeId: CalculationTypeEnum.Summary,
        allowClaims: false,
        allowVariableFunding: false,
        isActive: true
      } as IFundingDetailViewModel
    } as IFundingCaptureViewModel;

    this._fundingManagementRepo.canCaptureFunding(fundingCapture.fundingDetailViewModel).subscribe(
      (results) => {
        if (results)
          this.createFundingCapture(fundingCapture)
        else {
          this._messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Funding already captured...' });
          this._spinner.hide();
        }
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private createFundingCapture(fundingCapture: IFundingCaptureViewModel) {
    this._fundingManagementRepo.createFundingCapture(fundingCapture).subscribe(
      (results) => {
        this._router.navigateByUrl(`funding-capture/edit/${results.id}`);
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public updateButtonItems() {
    // Show all buttons
    this.buttonItems[0].items.forEach(option => {
      option.visible = true;
    });

    // Hide buttons based on status
    switch (this.selectedFundingCapture.statusId) {
      case StatusEnum.Saved:
        this.buttonItemExists('Approve Funding');
        this.buttonItemExists('Download Funding');
        break;
      case StatusEnum.PendingApproval:
        this.buttonItemExists('Edit Funding');
        break;
      case StatusEnum.Approved:
      case StatusEnum.Declined:
        this.buttonItemExists('Edit Funding');
        this.buttonItemExists('Approve Funding');
        break;
    }
  }

  private buttonItemExists(label: string) {
    let buttonItem = this.buttonItems[0].items.find(x => x.label === label);

    if (buttonItem)
      buttonItem.visible = false;
  }
}
