import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { CalculatedFinMatters } from 'src/app/models/CalculatedFinMatters';
import { FinancialMatters } from 'src/app/models/FinancialMatters';
import { PropertySubType } from 'src/app/models/PropertySubType';
import { PropertyType } from 'src/app/models/PropertyType';
import { DropdownTypeEnum, StatusEnum } from 'src/app/models/enums';
import { IApplication, FinYear, IFundingApplicationDetails } from 'src/app/models/interfaces';

import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';

@Component({
  selector: 'app-financial-matters',
  templateUrl: './financial-matters.component.html',
  styleUrls: ['./financial-matters.component.css']
})
export class FinancialMattersComponent implements OnInit {

  @Input() isReadOnly: boolean;
  @Input() fundingApplicationDetails: IFundingApplicationDetails; @Input() application: IApplication;
  @Input() financialMatters: FinancialMatters[];
  @Input() isEdit: boolean;
  @Output() financialMattersChange = new EventEmitter();
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

  newFinancialMatter: boolean;
  menuItem: any[];
  propertyObj: PropertyType = {} as PropertyType;
  financialMattersIncome: FinancialMatters[];
  financialMattersExpenditure: FinancialMatters[];
  displayExpenditureTotal: boolean = false;
  displayIncomeTotal: boolean = false;
  calculatedFinMattersIncome: CalculatedFinMatters = {} as CalculatedFinMatters;
  calculatedExpenditureFinMatters: CalculatedFinMatters = {} as CalculatedFinMatters;
  finYears: FinYear[];
  selectedPropertyTypes: PropertyType;
  selectedPropertySubtypes: PropertySubType;
  financialmatter: FinancialMatters = {} as FinancialMatters;
  selectedFinancialMatter: FinancialMatters;
  cols: any[];
  displayDialogAddFin: boolean = false;
  propertyTypes: PropertyType[] = [];
  propertySubtypes: PropertySubType[] = [];
  propertySubtypesAll: PropertySubType[] = [];

  private subscriptions: Subscription[] = [];

  totalAmountOne: number;
  totalAmountTwo: number;
  totalAmountThree: number;
  fundingTotal: number;

  totalAmountOneE: number;
  totalAmountTwoE: number;
  totalAmountThreeE: number;
  fundingTotalE: number;

  isBudgetEdit: boolean = false;
  displayDialog: boolean;

  constructor(private dropDownService: DropdownService,
    private _confirmationService: ConfirmationService,
    private messageService: MessageService) { }


  ngOnInit(): void {
    this.menuItem = [
      {
        label: 'Financial Matter Details for Funding Application',        
        command: () => {
          this.addBudget();
        }
      }
    ];

    if (this.fundingApplicationDetails.financialMatters) {
      this.financialMattersIncome = this.fundingApplicationDetails.financialMatters?.filter(x => x.type == "income");
      this.financialMattersExpenditure = this.fundingApplicationDetails.financialMatters?.filter(x => x.type == "expenditure");
    }
    else {
      this.fundingApplicationDetails.financialMatters = [];
      this.financialMattersIncome = [];
      this.financialMattersExpenditure = [];
    }

    var subscription = this.dropDownService.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(res => {
      this.finYears = res;

      this.cols = [
        { field: 'property', header: 'Item Description' },
        // { field: 'subproperty', header: 'Sub Property' },
        { field: 'year1', header: 'Budget for financial year ' + this.finYears[0].name },
        { field: 'year2', header: 'Budget for financial year ' + this.finYears[1].name },
        { field: 'year3', header: 'Budget for financial year ' + this.finYears[2].name },
        { field: 'total', header: 'Total Funding ', width: '5%'}
      ];
    });
    this.subscriptions.push(subscription);
    if (this.isEdit) {
      this.calculateTotals();
    }
  }


  readonly(): boolean {

    if (this.application.statusId == StatusEnum.PendingReview ||
      this.application.statusId == StatusEnum.Approved )
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

  calculateTotals() {
    var totalAmountOne: number = 0;
    var totalAmountTwo: number = 0;
    var totalAmountThree: number = 0;
    var totalFundingAmount: number = 0;

    this.financialMattersIncome.forEach(item => {
      var amountOne = item.amountOne != null ? Number(item.amountOne) : 0;
      var amountTwo = item.amountTwo != null ? Number(item.amountTwo) : 0;
      var amountThree = item.amountThree != null ? Number(item.amountThree) : 0;

      var projectFundingAmount = amountOne + amountTwo + amountThree;
      item.totalFundingAmount = projectFundingAmount;

      totalAmountOne = totalAmountOne + amountOne;
      totalAmountTwo = totalAmountTwo + amountTwo;
      totalAmountThree = totalAmountThree + amountThree;
      totalFundingAmount = totalFundingAmount + projectFundingAmount;
    });

    this.totalAmountOne = totalAmountOne;
    this.totalAmountTwo = totalAmountTwo;
    this.totalAmountThree = totalAmountThree;
    this.fundingTotal = totalFundingAmount;
  }

  calculateExpenditureTotals() {
    var totalAmountOne: number = 0;
    var totalAmountTwo: number = 0;
    var totalAmountThree: number = 0;
    var totalFundingAmount: number = 0;

    this.financialMattersExpenditure.forEach(item => {
      var amountOne = item.amountOne != null ? Number(item.amountOne) : 0;
      var amountTwo = item.amountTwo != null ? Number(item.amountTwo) : 0;
      var amountThree = item.amountThree != null ? Number(item.amountThree) : 0;

      var projectFundingAmount = amountOne + amountTwo + amountThree;
      item.totalFundingAmount = projectFundingAmount;

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

  addBudgetIncomeItem() {
    this.newFinancialMatter = true;
    var today = this.getCurrentDateTime();

    this.financialMattersIncome.push({
      createdDateTime: today
    } as FinancialMatters);

   }

   addBudgetExpenditureItem() {
    this.newFinancialMatter = true;
    var today = this.getCurrentDateTime();

    this.financialMattersExpenditure.push({
      createdDateTime: today
    } as FinancialMatters);

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
    this.financialmatter = {
      createdDateTime: today
    } as FinancialMatters;

    this.displayDialog = true;
  }


  save() {
  debugger;
    let financialmatter = [...this.financialMatters];
    if (this.newFinancialMatter) {
    this.financialmatter.totalFundingAmount = Number(this.financialmatter.amountOne) + Number(this.financialmatter.amountTwo) + Number(this.financialmatter.amountThree);

      financialmatter.push(this.financialmatter);
    }
    else {
    this.financialmatter.totalFundingAmount = Number(this.financialmatter.amountOne) + Number(this.financialmatter.amountTwo) + Number(this.financialmatter.amountThree);
    
      financialmatter[this.financialMatters.indexOf(this.selectedFinancialMatter)] = this.financialmatter;
    }

    this.financialMatters = financialmatter;
    this.financialMattersChange.emit(this.financialMatters);
    this.financialmatter = null;
  }

  deleteBudgetItem(budget: FinancialMatters) {
    debugger;
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

  deleteBudgetExpenditureItem(budget: FinancialMatters) {
    debugger;
    this._confirmationService.confirm({
      message: 'Are you sure that you want to delete this item?',
      header: 'Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.financialMattersExpenditure.forEach(function (item, index, object) {
          if (budget === item)
            object.splice(index, 1);
        });

          this.calculateTotals();      
      },
      reject: () => {
      }
    });
  }

  onRowSelect1(event) {

    this.selectedFinancialMatter = event.data;
    this.newFinancialMatter = false;
    this.financialmatter = this.cloneImplementation(event.data);
  }
  onRowSelect(data) {
    this.selectedFinancialMatter = data;
    this.isBudgetEdit = true;
    this.newFinancialMatter = false;
    this.financialmatter = this.cloneImplementation(data);
    this.displayDialog = true;
  }


  cloneImplementation(c: FinancialMatters): FinancialMatters {

    let addFun = {} as FinancialMatters;
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

}
