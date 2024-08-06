import { FinancialMatters, IFinancialMattersExpenditure, IFinancialMattersIncome, IFinancialMattersOthers } from './../../../../../models/FinancialMatters';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { Subscription, forkJoin } from 'rxjs';
import { CalculatedFinMatters } from 'src/app/models/CalculatedFinMatters';
import { IPreviousFinancialYear } from 'src/app/models/FinancialMatters';
import { PropertySubType } from 'src/app/models/PropertySubType';
import { PropertyType } from 'src/app/models/PropertyType';
import { DropdownTypeEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, FinYear, IFundingApplicationDetails, IBankDetail, IBank, IBranch, IAccountType, IFinancialYear, IProgramBankDetails } from 'src/app/models/interfaces';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { style } from '@angular/animations';
import { NgxSpinnerService } from 'ngx-spinner';
import * as internal from 'stream';

@Component({
  selector: 'app-financial-matters',
  templateUrl: './financial-matters.component.html',
  styleUrls: ['./financial-matters.component.css']
})
export class FinancialMattersComponent implements OnInit {

  @Input() isReadOnly: boolean;
  @Input() fundingApplicationDetails: IFundingApplicationDetails; 
  isSDASelected: boolean;
  @Input() application: IApplication;
  @Input() financialMatters: IFinancialMattersIncome[] = [];
  @Input() isEdit: boolean;
  @Output() financialMattersChange = new EventEmitter<any>();
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() currentUserId: number;
  @Input() programId: number; 
  @Input() subProgramId: number;
  @Input() subProgramTypeId: number;

  previousFinancialYear: IPreviousFinancialYear[];
  totalIncome: number;
  totalExpenditure: number;
  totalDeficitSurplus: number;
  stateOptions: any[];
  newFinancialMatter: boolean;
  menuItem: any[];
  propertyObj: PropertyType = {} as PropertyType;
  @Input() financialMattersIncome: IFinancialMattersIncome[];
  financialMattersExpenditure: IFinancialMattersExpenditure[];
  financialMattersOthers: IFinancialMattersOthers[];
  menuActions: MenuItem[];

  npoProfileId: string;
  displayOthrSourceFundingTotal: boolean = false;
  displayExpenditureTotal: boolean = false;
  displayIncomeTotal: boolean = false;
  calculatedFinMattersIncome: CalculatedFinMatters = {} as CalculatedFinMatters;
  calculatedExpenditureFinMatters: CalculatedFinMatters = {} as CalculatedFinMatters;
  calculatedOthrSourceFunding: CalculatedFinMatters = {} as CalculatedFinMatters;
  finYears: FinYear[];
  selectedPropertyTypes: PropertyType;
  selectedPropertySubtypes: PropertySubType;
  financialmatterIncome: IFinancialMattersIncome = {} as IFinancialMattersIncome;
  financialmatterExpenditure: IFinancialMattersExpenditure = {} as IFinancialMattersExpenditure;
  financialmatterOther: IFinancialMattersOthers = {} as IFinancialMattersOthers;
  programBankDetail: IProgramBankDetails = {} as IProgramBankDetails;
  financicalMattersOthrSourceFunding: IFinancialMattersOthers[];

  selectedFinancialMatterIncome: IFinancialMattersIncome;
  selectedFinancialMatterExpenditure: IFinancialMattersExpenditure;
  selectedFinancialMatterOthers: IFinancialMattersOthers;
  cols: any[];
  colsOther: any[];
  displayDialogAddFin: boolean = false;
  propertyTypes: PropertyType[] = [];
  propertySubtypes: PropertySubType[] = [];
  propertySubtypesAll: PropertySubType[] = [];

  private subscriptions: Subscription[] = [];

  paramSubcriptions: Subscription;

  totalAmountOne: number;
  totalAmountTwo: number;
  totalAmountThree: number;
  fundingTotal: number;

  totalAmountOneE: number;
  totalAmountTwoE: number;
  totalAmountThreeE: number;
  fundingTotalE: number;

  totalAmountOneO: number;
  totalAmountTwoO: number;
  totalAmountThreeO: number;
  fundingTotalO: number;

  isBudgetEdit: boolean = false;
  displayDialog: boolean;
  selectedApplicationId: string;
  fundAppDetailId: number;
  id: string;


  bankDetailCols: any[];
  displayBankDetailDialog: boolean;
  isBankDetailEdit: boolean;
  newBankDetail: boolean;
  bankDetail: IBankDetail = {} as IBankDetail;
  selectedBankDetail: IBankDetail;
  //isSDASelected: boolean;
  banks: IBank[];
  selectedBank: IBank;
  branches: IBranch[];
  selectedBranch: IBranch;
  accountTypes: IAccountType[];
  selectedAccountType: IAccountType;
  bankDetails: IBankDetail[];
  programBankDetails : IProgramBankDetails [];
  previous_year: any;
  private _loggerService: any;
  isDisabledButton: boolean;
  constructor(private dropDownService: DropdownService,
    private _confirmationService: ConfirmationService,
    private _bidServie: BidService,
    private _activeRouter: ActivatedRoute,
    private _dropdownRepo: DropdownService,
    private _applicationRepo: ApplicationService,
    private _npoProfile: NpoProfileService,
    private _bidService: BidService,
    private _router: Router,
    private _spinner: NgxSpinnerService,
    private messageService: MessageService) { }


  ngOnInit(): void {

    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.selectedApplicationId = params.get('id');

      this.loadProgrammeDetails();
     // this.current_year = new Date("YYYY").toString();

    }); 

    this.GetPreviousYearFinanceData();

    if (this.previousFinancialYear != null && this.previousFinancialYear.length > 0)
      this.calculatePreviousYearTotals();

    this.GetFinancialMattersIncome();
    if (this.financialMattersIncome != null && this.financialMattersIncome.length > 0)
      this.calculateTotals();

    this.GetFinancialMattersExpenditure();
    if (this.financialMattersExpenditure != null && this.financialMattersExpenditure.length > 0)
      this.calculateExpenditureTotals();

    this.GetFinancialMattersOther();
    if (this.financialMattersOthers != null && this.financialMattersOthers.length > 0)
      this.calculateOthrSourceFundingTotal();

    this.menuItem = [
      {
        label: 'Financial Matter Details for Funding Application',
        command: () => {
          this.addBudget();
        }
      }
    ];
    this.stateOptions = [
      {
        label: 'Yes',
        value: 'Yes'
      },
      {
        label: 'No',
        value: 'No'
      }
    ];
    // if (this.fundingApplicationDetails.financialMatters) {
    //   this.financialMattersIncome = this.fundingApplicationDetails.financialMatters?.filter(x => x.type == "income");
    //   this.financialMattersExpenditure = this.fundingApplicationDetails.financialMatters?.filter(x => x.type == "expenditure");
    //   this.financicalMattersOthrSourceFunding = this.fundingApplicationDetails.financialMatters?.filter(x => x.type == "othersource");      
    // }
    // else {
    this.fundingApplicationDetails.financialMatters = [];
    this.financialMattersIncome = [];
    this.financialMattersExpenditure = [];
    this.financialMattersOthers = [];
    this.financicalMattersOthrSourceFunding = [];
    // }
    
    var subscription = this.dropDownService.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(res => {
      this.finYears = res;
      this.previous_year = this.finYears[this.application.applicationPeriod.financialYearId - 2].name;
      
      this.cols = [
        { field: 'property', header: 'Item Description', width: '40%' },
        // { field: 'subproperty', header: 'Sub Property' },
        { field: 'year1', header: this.finYears[this.application.applicationPeriod.financialYearId - 1].name, width: '15%' },
        { field: 'year2', header: this.finYears[this.application.applicationPeriod.financialYearId].name + '[estimated]', width: '15%' },
        { field: 'year3', header: this.finYears[this.application.applicationPeriod.financialYearId + 1].name + '[estimated]', width: '15%' },
        { field: 'total', header: 'Total Funding ', width: '10%' },
        { field: 'action', header: 'Action ', width: '5%' }

      ];
      this.colsOther = [
        { field: 'property', header: 'Name of Organisation from whom funding has been received', width: '40%' },
        // { field: 'subproperty', header: 'Sub Property' },
        { field: 'year1', header: this.finYears[this.application.applicationPeriod.financialYearId -1].name, width: '15%' },
        { field: 'year2', header: this.finYears[this.application.applicationPeriod.financialYearId].name + '[estimated]', width: '15%' },
        { field: 'year3', header: this.finYears[this.application.applicationPeriod.financialYearId + 1].name + '[estimated]', width: '15%' },
        { field: 'total', header: 'Total Funding ', width: '10%' },
        { field: 'action', header: 'Action ', width: '5%' }

      ];
      this.bankDetailCols = [
        { header: 'Bank', width: '15%' },
        { header: 'Branch', width: '25%' },
        { header: 'Code', width: '15%' },
        { header: 'Account Type', width: '15%' },
        { header: 'Account Number', width: '23%' },
        { header: 'Actions', width: '7%' },
      ];
    });
    this.subscriptions.push(subscription);
    if (this.isEdit) {
      this.calculateTotals();
    }

    this.loadBanks();
    this.loadAccountTypes();
  }

  private loadProgrammeDetails() {
   
    this._npoProfile.getProgrammeBankDetails(this.application.id).subscribe(
      (results) => {
        this.programBankDetails = results.filter(x=> x.programId === this.programId && x.subProgrammeId === this.subProgramId && x.subProgrammeTypeId === this.subProgramTypeId); // x.approvalStatus.id === 2 && 
        this.updateBankDetailObjects();
      }, 
      (err) => {
      }
    );
  }  
  
  setValue(event, value) {  

      if(event.target.checked)//
      {
        this.isSDASelected = true;      
      }
      else{
        this.isSDASelected = false; 
      }

      this._npoProfile.updateProgrammeBankSelection(value, this.isSDASelected, this.application.npoId).subscribe(resp => {
        this.loadProgrammeDetails();
      },
      (err) => {
        this._loggerService.logException(err);
      });
  }

  disableSaveProgramBankDetail() {
    if (!this.selectedBank || !this.selectedBranch || !this.selectedAccountType || !this.programBankDetail.accountNumber)
      return true;

    return false;
  }
  private loadBanks() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Banks, false).subscribe(
      (results) => {
        this.banks = results;
        this.updateBankDetailObjects();
      },
      (err) => {
        //this._loggerService.logException(err);
        //this._spinner.hide();
      }
    );
  }

  addIncomeExpenditure() {
    this._npoProfile.createPreviousYearData(this.application.id).subscribe(
      (resp) => {
        this.GetPreviousYearFinanceData();
      },
      (err) => {
        //
      }
    );
  }

  private loadAccountTypes() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.AccountTypes, false).subscribe(
      (results) => {
        this.accountTypes = results;
        this.updateBankDetailObjects();
      },
      (err) => {
        //
      }
    );
  }

  private updateBankDetailObjects() {
    if (this.banks && this.accountTypes && this.programBankDetails) {
      var selectedBanks = this.programBankDetails.filter(x => x.isSelected);
      this.isSDASelected = selectedBanks.length == 1 ? true : false;
      this.programBankDetails.forEach(item => {
        item.bank = this.banks.find(x => x.id === item.bankId);
        this.loadBranch(item);
        item.accountType = this.accountTypes.find(x => x.id === item.accountTypeId);
      });
    }
  }

  private loadBranch(bankDetail: IBankDetail) {
    this._dropdownRepo.getBranchById(bankDetail.branchId).subscribe(
      (results) => {
        bankDetail.branch = results;
        bankDetail.branchCode = bankDetail.branch.branchCode != null ? bankDetail.branch.branchCode : bankDetail.bank.code;
      },
      (err) => {
        //this._loggerService.logException(err);
        //this._spinner.hide();
      }
    );
  }

  readonly(): boolean {

    if (this.application.statusId == StatusEnum.PendingReview ||
      this.application.statusId == StatusEnum.Approved)
      return true;
    else return false;
  }

  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;
  }

  addProgrammeBankDetail() {
    this.isBankDetailEdit = false;
    this.newBankDetail = true;
    this.programBankDetail = {} as IProgramBankDetails;
    this.selectedBank = null;
    this.branches = [];
    this.selectedBranch = null;
    this.selectedAccountType = null;
    this.displayBankDetailDialog = true;
  }

  editBankDetail(data: IBankDetail) {
    this.selectedBankDetail = data;
    this.isBankDetailEdit = true;
    this.newBankDetail = false;
    this.bankDetail = this.cloneBankDetail(data);
    this.branchChange();
    this.displayBankDetailDialog = true;
  }

  private cloneBankDetail(data: IBankDetail): IBankDetail {
    let bankDetail = {} as IBankDetail;

    for (let prop in data)
      bankDetail[prop] = data[prop];

    this.selectedBank = data.bank;
    this.bankChange();
    this.selectedBranch = data.branch;
    this.selectedAccountType = data.accountType;

    return bankDetail;
  }

 
  branchProgrammeChange() {
    if (this.selectedBranch) {
      this.programBankDetail.branchCode = this.selectedBranch.branchCode != null ? this.selectedBranch.branchCode : this.selectedBank.code;
    }
  }
  saveProgrammeBankDetail() {
    this.programBankDetail.programId = Number(this.application.applicationPeriod.programmeId);
    this.programBankDetail.bankId = this.selectedBank.id;
    this.programBankDetail.branchId = this.selectedBranch.id;
    this.programBankDetail.accountTypeId = this.selectedAccountType.id;
    this.programBankDetail.isActive = true;
    
    this.createProgrameBankDetail(this.programBankDetail)
    //this.newBankDetail ? this.createProgrameBankDetail(this.programBankDetail) : this.updateProgrameBankDetail(this.programBankDetail);
    this.displayBankDetailDialog = false;
  }

  private createProgrameBankDetail(bankDetail: IProgramBankDetails) {
    this._npoProfile.createProgrammeBankDetails(Number(this.application.id),bankDetail).subscribe(
      (resp) => {
        this.loadProgrammeDetails();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }


  disableSaveBankDetail() {
    if (!this.selectedBank || !this.selectedBranch || !this.selectedAccountType || !this.bankDetail.accountNumber)
      return true;

    return false;
  }

  bankChange() {
    if (this.selectedBank) {
      this.branches = [];
      this.selectedBranch = null;
      this._dropdownRepo.getEntitiesByEntityId(DropdownTypeEnum.Branches, this.selectedBank.id).subscribe(
        (results) => {
          this.branches = results;
        },
        (err) => {
          //
        }
      );
    }
  }

  branchChange() {
    if (this.selectedBranch) {
      this.bankDetail.branchCode = this.selectedBranch.branchCode != null ? this.selectedBranch.branchCode : this.selectedBank.code;
    }
  }

  calculatePreviousYearTotals() {
    var calculatedTotalIncome: number = 0;
    var calculatedTotalExpenditure: number = 0;

    this.previousFinancialYear.forEach(element => {
      var incomeAmount = element.incomeAmount != null ? Number(element.incomeAmount) : 0;
      var expenditureAmount = element.expenditureAmount != null ? Number(element.expenditureAmount) : 0;

      calculatedTotalIncome = calculatedTotalIncome + incomeAmount;
      calculatedTotalExpenditure = calculatedTotalExpenditure + expenditureAmount;
    });

    this.totalIncome = calculatedTotalIncome;
    this.totalExpenditure = calculatedTotalExpenditure;
    this.totalDeficitSurplus = this.totalIncome - this.totalExpenditure;
  }
  showTable(obj: any) {
    if (obj.value === "Yes")
      document.getElementById('previousFinancialYear').hidden = false;
    else
      document.getElementById('previousFinancialYear').hidden = true;
  }
  calculatePreviousYearTotal() {
    var calculatedTotalIncome: number = 0;
    var calculatedTotalExpenditure: number = 0;

    this.previousFinancialYear.forEach(element => {
      var incomeAmount = element.incomeAmount != null ? Number(element.incomeAmount) : 0;
      var expenditureAmount = element.expenditureAmount != null ? Number(element.expenditureAmount) : 0;

      calculatedTotalIncome = calculatedTotalIncome + incomeAmount;
      calculatedTotalExpenditure = calculatedTotalExpenditure + expenditureAmount;
    });

    this.totalIncome = calculatedTotalIncome;
    this.totalExpenditure = calculatedTotalExpenditure;
    this.totalDeficitSurplus = this.totalIncome - this.totalExpenditure;
  }

  calculateTotals() {
    var totalAmountOne: number = 0;
    var totalAmountTwo: number = 0;
    var totalAmountThree: number = 0;
    var totalFundingAmount: number = 0;

    this.financialMattersIncome.forEach(item => {
      var amountOne = item.amountOneI != null ? Number(item.amountOneI) : 0;
      var amountTwo = item.amountTwoI != null ? Number(item.amountTwoI) : 0;
      var amountThree = item.amountThreeI != null ? Number(item.amountThreeI) : 0;

      var projectFundingAmount = amountOne + amountTwo + amountThree;
      item.totalFundingAmountI = projectFundingAmount;

      totalAmountOne = totalAmountOne + amountOne;
      totalAmountTwo = totalAmountTwo + amountTwo;
      totalAmountThree = totalAmountThree + amountThree;
      totalFundingAmount = totalFundingAmount + projectFundingAmount;
    });

    this.totalAmountOne = totalAmountOne;
    this.totalAmountTwo = totalAmountTwo;
    this.totalAmountThree = totalAmountThree;
    this.fundingTotal = totalFundingAmount;
    this.financialMattersChange.emit(this.financialMattersIncome);
  }

  calculateExpenditureTotals() {
    var totalAmountOne: number = 0;
    var totalAmountTwo: number = 0;
    var totalAmountThree: number = 0;
    var totalFundingAmount: number = 0;

    this.financialMattersExpenditure.forEach(item => {
      var amountOne = item.amountOneE != null ? Number(item.amountOneE) : 0;
      var amountTwo = item.amountTwoE != null ? Number(item.amountTwoE) : 0;
      var amountThree = item.amountThreeE != null ? Number(item.amountThreeE) : 0;

      var projectFundingAmount = amountOne + amountTwo + amountThree;
      item.totalFundingAmountE = projectFundingAmount;

      totalAmountOne = totalAmountOne + amountOne;
      totalAmountTwo = totalAmountTwo + amountTwo;
      totalAmountThree = totalAmountThree + amountThree;
      totalFundingAmount = totalFundingAmount + projectFundingAmount;
    });

    this.totalAmountOneE = totalAmountOne;
    this.totalAmountTwoE = totalAmountTwo;
    this.totalAmountThreeE = totalAmountThree;
    this.fundingTotalE = totalFundingAmount;
  }

  calculateOthrSourceFundingTotal() {
    var totalAmountOne: number = 0;
    var totalAmountTwo: number = 0;
    var totalAmountThree: number = 0;
    var totalFundingAmount: number = 0;

    this.financialMattersOthers.forEach(item => {
      var amountOne = item.amountOneO != null ? Number(item.amountOneO) : 0;
      var amountTwo = item.amountTwoO != null ? Number(item.amountTwoO) : 0;
      var amountThree = item.amountThreeO != null ? Number(item.amountThreeO) : 0;

      var projectFundingAmount = amountOne + amountTwo + amountThree;
      item.totalFundingAmountO = projectFundingAmount;

      totalAmountOne = totalAmountOne + amountOne;
      totalAmountTwo = totalAmountTwo + amountTwo;
      totalAmountThree = totalAmountThree + amountThree;
      totalFundingAmount = totalFundingAmount + projectFundingAmount;
    });

    this.totalAmountOneO = totalAmountOne;
    this.totalAmountTwoO = totalAmountTwo;
    this.totalAmountThreeO = totalAmountThree;
    this.fundingTotalO = totalFundingAmount;
  }

  addBudgetIncomeItem() {
    this._npoProfile.createFinancialMattersIncome(this.application.id).subscribe(
      (resp) => {
        this.GetFinancialMattersIncome();
      },
      (err) => {
        //
      }
    );
  }

  addBudgetExpenditureItem() {
    this._npoProfile.createFinancialMattersExpenditure(this.application.id).subscribe(
      (resp) => {
        this.GetFinancialMattersExpenditure();
      },
      (err) => {
        //
      }
    );
  }

  addBudgetOthrSourceFunding() {
    this._npoProfile.createFinancialMattersOther(this.application.id).subscribe(
      (resp) => {
        this.GetFinancialMattersOther();
      },
      (err) => {
        //
      }
    );
  }

  private getCurrentDateTime() {
    let today = new Date();
    let nextTwoHours = today.getHours() + 2;
    today.setHours(nextTwoHours);

    return today;
  }

  isReadOnlyBudget(): boolean {
    if (this.isReadOnly) {
      return true;
    }
    return false;
  }

  closeDialogAddFin() {
    this.displayDialogAddFin = false;
  }
  private addBudget() {
    var today = this.getCurrentDateTime();
    this.isBudgetEdit = false;
    this.newFinancialMatter = true;
    this.financialmatterIncome = {
      createdDateTime: today
    } as IFinancialMattersIncome;

    this.displayDialog = true;
  }
  saveBudget() {
    if (this.newFinancialMatter) {
      this.financialmatterIncome.totalFundingAmountI = Number(this.financialmatterIncome.amountOneI) + Number(this.financialmatterIncome.amountTwoI) + Number(this.financialmatterIncome.amountThreeI);

      this.financialMatters.push(this.financialmatterIncome);
    }
    else {
      //this.financialmatter.property = this.selectedFoundationalEnergyStudy.description;
      this.financialmatterIncome.totalFundingAmountI = Number(this.financialmatterIncome.amountOneI) + Number(this.financialmatterIncome.amountTwoI) + Number(this.financialmatterIncome.amountThreeI);
      this.financialMatters[this.financialMatters.indexOf(this.selectedFinancialMatterIncome)] = this.financialmatterIncome;
    }
    this.financialMattersChange.emit(this.financialMatters);
    this.financialmatterIncome = null;

  }

  save() {
    let financialmatter = [...this.financialMatters];
    if (this.newFinancialMatter) {
      this.financialmatterIncome.totalFundingAmountI = Number(this.financialmatterIncome.amountOneI) + Number(this.financialmatterIncome.amountTwoI) + Number(this.financialmatterIncome.amountThreeI);

      this.financialMatters.push(this.financialmatterIncome);
    }
    else {
      this.financialmatterIncome.totalFundingAmountI = Number(this.financialmatterIncome.amountOneI) + Number(this.financialmatterIncome.amountTwoI) + Number(this.financialmatterIncome.amountThreeI);

      financialmatter[this.financialMatters.indexOf(this.selectedFinancialMatterIncome)] = this.financialmatterIncome;
    }

    this.financialMatters = financialmatter;
    this.financialMattersChange.emit(this.financialMatters);
    this.financialmatterIncome = null;
  }

  deletePreviousYearItem(previousYear) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._npoProfile.deletePreviousYearDataById(previousYear).subscribe(
          (resp) => {
            this.GetPreviousYearFinanceData();
          },
          (err) => {
            //
          }
        );
        this.calculateTotals();
      },
      reject: () => {
      }
    });
  }

  deleteBudgetItem(budget: IFinancialMattersIncome) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._npoProfile.deleteFinancialMattersIncomeById(budget.id).subscribe(
          (resp) => {
            this.GetFinancialMattersIncome();
          },
          (err) => {
            //
          }
        );

        this.calculateTotals();
      },
      reject: () => {
      }
    });
  }

  deleteBudgetExpenditureItem(budget: IFinancialMattersExpenditure) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._npoProfile.deleteFinancialMattersExpenditureById(budget.id).subscribe(
          (resp) => {
            this.GetFinancialMattersExpenditure();
          },
          (err) => {
            //
          }
        );

        this.calculateExpenditureTotals();
      },
      reject: () => {
      }
    });
  }

  deleteBudgetOthrSourceFunding(budget: IFinancialMattersOthers) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._npoProfile.deleteFinancialMattersOthersById(budget.id).subscribe(
          (resp) => {
            this.GetFinancialMattersOther();
          },
          (err) => {
            //
          }
        );

        this.calculateOthrSourceFundingTotal();
      },
      reject: () => {
      }
    });
  }

  onRowSelect1(event) {

    this.selectedFinancialMatterIncome = event.data;
    this.newFinancialMatter = false;
    this.financialmatterIncome = this.cloneImplementation(event.data);
  }
  onRowSelect(data) {
    this.selectedFinancialMatterIncome = data;
    this.isBudgetEdit = true;
    this.newFinancialMatter = false;
    this.financialmatterIncome = this.cloneImplementation(data);
    this.displayDialog = true;
  }



  cloneImplementation(c: IFinancialMattersIncome): IFinancialMattersIncome {

    let addFun = {} as IFinancialMattersIncome;
    for (let prop in c) {
      addFun[prop] = c[prop];
    }
    return addFun;
  }


  nextPage() {
    if(this.isSDASelected === true)
      {
        this.activeStep = this.activeStep + 1;
        this.bidForm(StatusEnum.Saved);
        this.activeStepChange.emit(this.activeStep);
      }
      else{
        alert('Please select bank account or add bank account in profile section');
        return false;
      }   
  }


  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }

  ngOnDestroy() {
    this.subscriptions.forEach(function (sub) {
      sub.unsubscribe();
    });
  }

  updateDetails(rowData: FinancialMatters) {
    if (this.isEdit) {

      var today = this.getCurrentDateTime();
      this.financialMatters[0].createdDateTime = today;
    }
    this._bidServie.editIncome(rowData.fundingApplicationDetailId, rowData).subscribe(

      (resp) => {
        //
      },
      (err) => {
        //
      }
    );
  }
  updateIncomeDetail(rowData: IFinancialMattersIncome) {
    this._npoProfile.updateFinancialMattersIncome(rowData, this.selectedApplicationId).subscribe(
      (resp) => {
        // this.GetFinancialMattersIncome();
      },
      (err) => {
        //
      }
    );
  }
  private GetFinancialMattersIncome() {
    this._npoProfile.getFinancialMattersIncomeByNpoProfileId(this.selectedApplicationId).subscribe(
      (results) => {
        this.financialMattersIncome = results;
        this.calculateTotals();
      },
      (err) => {
        //
      }
    );
  }

  updateExpenditureDetail(rowData: IFinancialMattersExpenditure) {
    this._npoProfile.updateFinancialMattersExpenditure(rowData, this.selectedApplicationId).subscribe(
      (resp) => {
        // this.GetFinancialMattersExpenditure();
      },
      (err) => {
        //
      }
    );
  }
  private GetFinancialMattersExpenditure() {
    this._npoProfile.getFinancialMattersExpenditureByNpoProfileId(this.selectedApplicationId).subscribe(
      (results) => {
        this.financialMattersExpenditure = results;
        this.calculateExpenditureTotals();
      },
      (err) => {
        //
      }
    );
  }

  updateOthersDetail(rowData: IFinancialMattersOthers) {
    this._npoProfile.updateFinancialMattersOthers(rowData, this.selectedApplicationId).subscribe(
      (resp) => {
        // this.GetFinancialMattersOther();
      },
      (err) => {
        //
      }
    );
  }
  private GetFinancialMattersOther() {
    this._npoProfile.getFinancialMattersOthersByNpoProfileId(this.selectedApplicationId).subscribe(
      (results) => {
        this.financialMattersOthers = results;
        this.calculateOthrSourceFundingTotal();
      },
      (err) => {
        //
      }
    );
  }

  updateDetail(rowData: IPreviousFinancialYear) {
    this._npoProfile.UpdatePreviousYearData(rowData, this.selectedApplicationId).subscribe(
      (resp) => {
        // this.GetPreviousYearFinanceData();
      },
      (err) => {
        //
      }
    );
  }

  private GetPreviousYearFinanceData() {
    this._npoProfile.getPreviousYearDataById(this.selectedApplicationId).subscribe(
      (results) => {
        this.previousFinancialYear = results;
        if (results.length > 0) {
          document.getElementById('previousFinancialYear').hidden = false;
        }
        this.calculatePreviousYearTotals();
      },
      (err) => {
        //
      }
    );
  }

  private bidForm(status: StatusEnum) {
    this.application.status = null;
    this.application.statusId = status;
  //  this.fundingApplicationDetails.implementations = null;
    const applicationIdOnBid = this.fundingApplicationDetails;

    if (applicationIdOnBid.id == null) {
      this._bidService.addBid(this.fundingApplicationDetails).subscribe(resp => {
        this.menuActions[1].visible = false;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
        resp;
      });
    }

    else {
      this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => {
        if (resp) {
          this._router.navigateByUrl(`application/edit/${this.application.id}/${this.activeStep}`);
          this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
        }
      });
    }

    if (status == StatusEnum.PendingReview) {

      this.application.statusId = status;
      this._applicationRepo.updateApplication(this.application).subscribe();
      this._bidService.editBid(this.fundingApplicationDetails.id, this.fundingApplicationDetails).subscribe(resp => { });
      this._router.navigateByUrl('applications');
    };
    // }
  }

}
