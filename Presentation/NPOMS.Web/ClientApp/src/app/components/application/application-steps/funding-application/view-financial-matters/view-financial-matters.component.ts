import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { CalculatedFinMatters } from 'src/app/models/CalculatedFinMatters';
import { IFinancialMattersIncome, IPreviousFinancialYear, IFinancialMattersExpenditure, IFinancialMattersOthers, FinancialMatters } from 'src/app/models/FinancialMatters';
import { PropertySubType } from 'src/app/models/PropertySubType';
import { PropertyType } from 'src/app/models/PropertyType';
import { DropdownTypeEnum, StatusEnum } from 'src/app/models/enums';
import { IFundingApplicationDetails, IApplication, FinYear, IBankDetail, IBank, IBranch, IAccountType } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';

@Component({
  selector: 'app-view-financial-matters',
  templateUrl: './view-financial-matters.component.html',
  styleUrls: ['./view-financial-matters.component.css']
})
export class ViewFinancialMattersComponent implements OnInit {

  @Input() isReadOnly: boolean;
  @Input() fundingApplicationDetails: IFundingApplicationDetails; @Input() application: IApplication;
  @Input() financialMatters: IFinancialMattersIncome[] = [];
  @Input() isEdit: boolean;
  @Output() financialMattersChange = new EventEmitter<any>();
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();
  @Input() currentUserId: number;

  previousFinancialYear: IPreviousFinancialYear[];
  totalIncome: number;
  totalExpenditure: number;
  totalDeficitSurplus: number;
  stateOptions: any[];
  newFinancialMatter: boolean;
  menuItem: any[];
  propertyObj: PropertyType = {} as PropertyType;
  financialMattersIncome: IFinancialMattersIncome[];
  financialMattersExpenditure: IFinancialMattersExpenditure[];
  financialMattersOthers: IFinancialMattersOthers[];


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

  banks: IBank[];
  selectedBank: IBank;
  branches: IBranch[];
  selectedBranch: IBranch;
  accountTypes: IAccountType[];
  selectedAccountType: IAccountType;
  bankDetails: IBankDetail[];
  constructor(private dropDownService: DropdownService,
    private _confirmationService: ConfirmationService,
    private _bidServie: BidService,
    private _activeRouter: ActivatedRoute,
    private _dropdownRepo: DropdownService,
    private _applicationRepo: ApplicationService,
    private _npoProfile: NpoProfileService,
    private messageService: MessageService) { }


  ngOnInit(): void {

    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.selectedApplicationId = params.get('id');

    });
    
    this.GetPreviousYearFinanceData();
       this.GetBankDetail();

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
      this.financialMattersOthers =[];
      this.financicalMattersOthrSourceFunding =[];
    // }

    var subscription = this.dropDownService.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(res => {
      this.finYears = res;
      console.log('this.finYears', this.finYears);
      console.log('res', res);

      this.cols = [
        { field: 'property', header: 'Item Description', width: '40%' },
        // { field: 'subproperty', header: 'Sub Property' },
        { field: 'year1', header: this.finYears[2].name, width: '15%' },
        { field: 'year2', header: this.finYears[3].name + '[estimated]', width: '15%' },
        { field: 'year3', header: this.finYears[4].name + '[estimated]', width: '15%' },
        { field: 'total', header: 'Total Funding ', width: '10%' },
        { field: 'action', header: 'Action ', width: '5%' }

      ];
      this.colsOther = [
        { field: 'property', header: 'Name of Organisation from whom funding has been received', width: '40%' },
        // { field: 'subproperty', header: 'Sub Property' },
        { field: 'year1', header: this.finYears[2].name, width: '15%' },
        { field: 'year2', header: this.finYears[3].name + '[estimated]', width: '15%' },
        { field: 'year3', header: this.finYears[4].name + '[estimated]', width: '15%' },
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
    var today = this.getCurrentDateTime();

    this.previousFinancialYear.push({
      createdUserId: this.currentUserId,
      createdDateTime: today
    } as IPreviousFinancialYear);
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
    if ( this.banks && this.accountTypes && this.bankDetails) {
      this.bankDetails.forEach(item => {
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

  addBankDetail() {
    this.isBankDetailEdit = false;
    this.newBankDetail = true;
    this.bankDetail = {} as IBankDetail;
    this.selectedBank = null;
    this.branches = [];
    this.selectedBranch = null;
    this.selectedAccountType = null;
    this.displayBankDetailDialog = true;
  }


  editBankDetail(data: IBankDetail) {
    console.log('data from EditBankDetail',data);
    this.selectedBankDetail = data;
    this.isBankDetailEdit = true;
    this.newBankDetail = false;
    this.bankDetail = this.cloneBankDetail(data);
    this.branchChange();
    this.displayBankDetailDialog = true;
  }

  private cloneBankDetail(data: IBankDetail): IBankDetail {
    console.log('data from clone',data);
    let bankDetail = {} as IBankDetail;

    for (let prop in data)
      bankDetail[prop] = data[prop];

    this.selectedBank = data.bank;
    this.bankChange();
    this.selectedBranch = data.branch;
    this.selectedAccountType = data.accountType;

    return bankDetail;
  }


  deleteBankDetail(bankDetail) {
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this._npoProfile.deleteBankDetail(bankDetail).subscribe(
          (resp) => {
            this.GetBankDetail();
          },
          (err) => {
            //
          }
        );        
      },
      reject: () => {
        //
      }
    });
  }

  saveBankDetail() {
    // this.bankDetail.npoProfileId = Number(this.selectedApplicationId);
    // this.bankDetail.bankId = this.selectedBank.id;
    // this.bankDetail.branchId = this.selectedBranch.id;
    // this.bankDetail.accountTypeId = this.selectedAccountType.id;
    // this.bankDetail.isActive = true;
    // this.newBankDetail ? this.createBankDetail(this.bankDetail): this.updateBankDetail(this.bankDetail);
    // this.displayBankDetailDialog = false;


    this.bankDetail.npoProfileId = Number(this.selectedApplicationId);
    this.bankDetail.bankId = this.selectedBank.id;
    this.bankDetail.branchId = this.selectedBranch.id;
    this.bankDetail.accountTypeId = this.selectedAccountType.id;
    this.bankDetail.isActive = true;

    this.newBankDetail ? this.createBankDetail(this.bankDetail) : this.updateBankDetail(this.bankDetail);
    this.displayBankDetailDialog = false;
  }
  private createBankDetail(bankDetail: IBankDetail) {
    this._npoProfile.createBankDetail(bankDetail).subscribe(
      (resp) => {
        this.GetBankDetail();
      },
      (err) => {//
      }
    );
  }
  private updateBankDetail(bankDetail: IBankDetail) {
    this._npoProfile.updateBankDetail(bankDetail).subscribe(
      (resp) => {
        this.loadBankDetails(Number(this.npoProfileId));
      },
      (err) => {
        // this._loggerService.logException(err);
        // this._spinner.hide();
      }
    );
  }

  private loadBankDetails(npoProfileId: number) {
    this._npoProfile.getBankDetailByNpoProfileId(npoProfileId).subscribe(
      (results) => {
        this.bankDetails = results;
        this.updateBankDetailObjects();
      },
      (err) => {
        // this._loggerService.logException(err);
        // this._spinner.hide();
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
  showTable(obj:any)
  {
    if(obj.value === "Yes")
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
    this.newFinancialMatter = true;
    var today = this.getCurrentDateTime();

    this.financialMattersIncome.push({
      createdDateTime: today
    } as IFinancialMattersIncome);

    if (this.newFinancialMatter) {
      this.financialmatterIncome.totalFundingAmountI = Number(this.financialmatterIncome.amountOneI) + Number(this.financialmatterIncome.amountTwoI) + Number(this.financialmatterIncome.amountThreeI);

      this.financialMatters.push(this.financialmatterIncome);
    }
    else {
      //this.financialmatter.property = this.selectedFoundationalEnergyStudy.description;
      this.financialmatterIncome.totalFundingAmountI = Number(this.financialmatterIncome.amountOneI) + Number(this.financialmatterIncome.amountTwoI) + Number(this.financialmatterIncome.amountThreeI);
      this.financialMatters[this.financialMatters.indexOf(this.selectedFinancialMatterIncome)] = this.financialmatterIncome;
    }
  }

  addBudgetExpenditureItem() {
    this.newFinancialMatter = true;
    var today = this.getCurrentDateTime();

    this.financialMattersExpenditure.push({
      createdDateTime: today
    } as IFinancialMattersExpenditure);

  }

  addBudgetOthrSourceFunding() {
    this.newFinancialMatter = true;
    var today = this.getCurrentDateTime();

    this.financialMattersOthers.push({
      createdDateTime: today
    } as IFinancialMattersOthers);

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
        this.financialMattersIncome.forEach(function (item, index, object) {
          if (budget === item)
            object.splice(index, 1);
        });

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
        this.financialMattersExpenditure.forEach(function (item, index, object) {
          if (budget === item)
            object.splice(index, 1);
        });

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
        this.financialMattersOthers.forEach(function (item, index, object) {
          if (budget === item)
            object.splice(index, 1);
        });

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

    this.activeStep = this.activeStep + 1;
    this.activeStepChange.emit(this.activeStep);
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
    if (this.isEdit) {
      var today = this.getCurrentDateTime();

      this.financialMattersIncome[0].updatedUserId = this.currentUserId;
      this.financialMattersIncome[0].updatedDateTime = today;
    }
    this._npoProfile.updateFinancialMattersIncome(this.financialMattersIncome, this.selectedApplicationId).subscribe(
      (resp) => {
        this.GetFinancialMattersIncome();
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
        // if(results.length > 0)
        // {
        //   document.getElementById('previousFinancialYear').hidden = false; 
        // }
        this.calculateTotals(); 
      },
      (err) => {
        //
      }
    );
  }

  updateExpenditureDetail(rowData: IFinancialMattersExpenditure) {
    if (this.isEdit) {
      var today = this.getCurrentDateTime();

      this.financialMattersExpenditure[0].updatedUserId = this.currentUserId;
      this.financialMattersExpenditure[0].updatedDateTime = today;
    }
    this._npoProfile.updateFinancialMattersExpenditure(this.financialMattersExpenditure, this.selectedApplicationId).subscribe(
      (resp) => {
        this.GetFinancialMattersExpenditure();
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
        // if(results.length > 0)
        // {
        //   document.getElementById('previousFinancialYear').hidden = false; 
        // }
        this.calculateExpenditureTotals(); 
      },
      (err) => {
        //
      }
    );
  }  

  updateOthersDetail(rowData: IFinancialMattersOthers) {
    if (this.isEdit) {
      var today = this.getCurrentDateTime();

      this.financialMattersOthers[0].updatedUserId = this.currentUserId;
      this.financialMattersOthers[0].updatedDateTime = today;
    }
    this._npoProfile.updateFinancialMattersOthers(this.financialMattersOthers, this.selectedApplicationId).subscribe(
      (resp) => {
        this.GetFinancialMattersOther();
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
        // if(results.length > 0)
        // {
        //   document.getElementById('previousFinancialYear').hidden = false; 
        // }
        this.calculateOthrSourceFundingTotal(); 
      },
      (err) => {
        //
      }
    );
  }    
  
  updateDetail(rowData: IPreviousFinancialYear) {
    if (this.isEdit) {
      var today = this.getCurrentDateTime();

      this.previousFinancialYear[0].updatedUserId = this.currentUserId;
      this.previousFinancialYear[0].updatedDateTime = today;
    }
    this._npoProfile.UpdatePreviousYearData(this.previousFinancialYear, this.selectedApplicationId).subscribe(
      (resp) => {
        this.GetPreviousYearFinanceData();
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
        if(results.length > 0)
        {
          document.getElementById('previousFinancialYear').hidden = false; 
        }
        this.calculatePreviousYearTotals(); 
      },
      (err) => {
        //
      }
    );
  }

  private GetBankDetail() {
    this._npoProfile.getBankDetailByNpoProfileId(Number(this.selectedApplicationId)).subscribe(
      (results) => {
        this.bankDetails = results;
        this.updateBankDetailObjects();
      },
      (err) => {
        //
      }
    );
  }

}
