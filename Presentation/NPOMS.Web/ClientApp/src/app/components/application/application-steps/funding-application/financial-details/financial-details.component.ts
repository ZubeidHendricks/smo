import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { CalculatedFinMatters } from 'src/app/models/CalculatedFinMatters';
import { FinancialMatters } from 'src/app/models/FinancialMatters';
import { PropertySubType } from 'src/app/models/PropertySubType';
import { PropertyType } from 'src/app/models/PropertyType';
import { DropdownTypeEnum, StatusEnum } from 'src/app/models/enums';
import { Bid, FinYear, IApplication } from 'src/app/models/interfaces';
import { BidService } from 'src/app/services/api-services/bid/bid.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';

@Component({
  selector: 'app-financial-details',
  templateUrl: './financial-details.component.html',
  styleUrls: ['./financial-details.component.css']
})
export class FinancialDetailsComponent implements OnInit, OnChanges {

  @Input() isReadOnly: boolean;
  @Input() bid: Bid; @Input() application: IApplication;
  @Input() financialMatters: FinancialMatters[];
  @Output() financialMattersChange = new EventEmitter();
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

  newFinancialMatter: boolean;
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

  constructor(private dropDownService: DropdownService, private messageService: MessageService) { }


  ngOnInit(): void {

     //console.log('bid', this.bid);

    // console.log('bid', this.bid);

    // if (this.bid.financialMatters) {
    //   this.financialMattersIncome = this.bid.financialMatters?.filter(x => x.type == "income");
    //   this.financialMattersExpenditure = this.bid.financialMatters?.filter(x => x.type == "expenditure");
    // }
    // else {
    //   this.bid.financialMatters = [];
    //   this.financialMattersIncome = [];
    //   this.financialMattersExpenditure = [];
    // }
    this.loadPropertyTypes();


    var subscription = this.dropDownService.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(res => {
      this.finYears = res;

      this.cols = [
        { field: 'property', header: 'Property' },
        { field: 'subproperty', header: 'Sub Property' },
        { field: 'year1', header: 'Budget for financial year ' + this.finYears[0].name },
        { field: 'year2', header: 'Budget for financial year ' + this.finYears[1].name },
        { field: 'year3', header: 'Budget for financial year ' + this.finYears[2].name },
      ];
    });
    this.subscriptions.push(subscription);
  }


  readonly(): boolean {
    
        if (this.application.statusId ==StatusEnum.PendingReview ||  
          this.application.statusId == StatusEnum.Approved ||
          this.application.statusId ==  StatusEnum.Evaluated ||
          this.application.statusId ==  StatusEnum.EvaluationApproved)
          return true;
        else return false;
      }

 
  private loadPropertyTypes() {

    var subscription = this.dropDownService.getEntities(DropdownTypeEnum.PropertyType, false).subscribe((propertyTypes) => {
      console.log('propertyTypes',propertyTypes);
      this.propertyTypes = propertyTypes;
      //this.propertyTypes.unshift({ name: 'Select Property Type', id: null });
    }, error => {
      var errorMessage = error ? error.error ? error.error : null : null;
      this.messageService.add({ severity: 'error', summary: 'Error Message', detail: errorMessage });
      console.log(error);
    });
    this.subscriptions.push(subscription);

  }


  private loadPropertySubTypes(id: number) {

    var subscription = this.dropDownService.getEntities(DropdownTypeEnum.PropertySubType, false).subscribe((subpropertyTypes) => {
      this.propertySubtypes = subpropertyTypes.filter(x => x.propertyTypeID == id);
      //this.propertySubtypes.unshift({ name: 'Select Sub Property Type', id: null, propertyTypeID: null });
    }, error => {
      var errorMessage = error ? error.error ? error.error : null : null;
      this.messageService.add({ severity: 'error', summary: 'Error Message', detail: errorMessage });
      console.log(error);
    });
    this.subscriptions.push(subscription);

  }


  public propertyTypeChange(propertyType: PropertyType) {

    this.propertySubtypes = [];
    if (propertyType.id != null) {
      this.loadPropertyTypes();
      this.loadPropertySubTypes(propertyType.id);
    }
  }


  ngOnChanges(changes: SimpleChanges) {

    console.log('Financial Matters',this.financialMatters);
    if (this.financialMatters) {
      this.financialMattersIncome = this.financialMatters?.filter(x => x.type == "income");
      this.financialMattersExpenditure = this.financialMatters?.filter(x => x.type == "expenditure");
      var sumOne = 0;
      var sumTwo = 0;
      var sumThree = 0;
      var sumEOne = 0;
      var sumETwo = 0;
      var sumEThree = 0;

      if (this.financialMattersIncome.length > 0) {

        this.financialMattersIncome.forEach(x => {
          sumOne += Number(x.amountOne);
          sumTwo += Number(x.amountTwo);
          sumThree += Number(x.amountThree);
        });

        this.calculatedFinMattersIncome.totalOne = Number(sumOne);
        this.calculatedFinMattersIncome.totalTwo = Number(sumTwo);
        this.calculatedFinMattersIncome.totalThree = Number(sumThree);
        this.displayIncomeTotal = true;
      }

      if (this.financialMattersExpenditure.length > 0) {
        this.financialMattersExpenditure.forEach(x => {
          sumEOne += Number(x.amountOne);
          sumETwo += Number(x.amountTwo);
          sumEThree += Number(x.amountThree);
        });

        this.calculatedExpenditureFinMatters.totalOne = Number(sumEOne);
        this.calculatedExpenditureFinMatters.totalTwo = Number(sumETwo);
        this.calculatedExpenditureFinMatters.totalThree = Number(sumEThree);
        this.displayExpenditureTotal = true;
      }


    }
    else {
      //if (this.bid == null) {
        this.financialMatters = [];
      //}
    }


  }

  showDialogAddFin(type: string) {

    this.newFinancialMatter = true;
    this.selectedPropertyTypes = null;
    this.selectedPropertySubtypes = null;
    this.financialmatter = {} as FinancialMatters;
    this.financialmatter.type = type;
    this.loadPropertyTypes();
    this.displayDialogAddFin = true;
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

  saveAddFun() {

    this.financialmatter.property = this.selectedPropertyTypes.name;
    this.financialmatter.propertyId = Number(this.selectedPropertyTypes.id);
    this.financialmatter.subProperty = this.selectedPropertySubtypes.name;
    this.financialmatter.subPropertyId = Number(this.selectedPropertySubtypes.id);
    if (this.financialmatter.type == "income") {
      if (this.newFinancialMatter) {
        this.financialMattersIncome.push(this.financialmatter);
      }
      else {
        this.financialMattersIncome[this.financialMattersIncome.indexOf(this.selectedFinancialMatter)] = this.financialmatter;
      }

      this.financialMatters = this.financialMattersIncome.concat(this.financialMattersExpenditure);
      let totalOne: number = this.financialMattersIncome.map(a => a.amountOne).reduce(function (a, b) {
        return Number(a) + Number(b);
      });

      let totalTwo: number = this.financialMattersIncome.map(a => a.amountTwo).reduce(function (a, b) {
        return Number(a) + Number(b);
      });

      let totalThree: number = this.financialMattersIncome.map(a => a.amountThree).reduce(function (a, b) {
        return Number(a) + Number(b);
      });

      this.calculatedFinMattersIncome.totalOne = totalOne;
      this.calculatedFinMattersIncome.totalTwo = totalTwo;
      this.calculatedFinMattersIncome.totalThree = totalThree;
    }

    if (this.financialmatter.type == "expenditure") {

      if (this.newFinancialMatter) {
        this.financialMattersExpenditure.push(this.financialmatter);
      }
      else {
        this.financialMattersExpenditure[this.financialMattersExpenditure.indexOf(this.selectedFinancialMatter)] = this.financialmatter;
      }

      this.financialMatters = this.financialMattersExpenditure.concat(this.financialMattersIncome);

      let totalOneExpenditure: number = this.financialMattersExpenditure.map(a => a.amountOne).reduce(function (a, b) {
        return Number(a) + Number(b);
      });

      let totalTwoExpenditure: number = this.financialMattersExpenditure.map(a => a.amountTwo).reduce(function (a, b) {
        return Number(a) + Number(b);
      });

      let totalThreeExpenditure: number = this.financialMattersExpenditure.map(a => a.amountThree).reduce(function (a, b) {
        return Number(a) + Number(b);
      });

      this.calculatedExpenditureFinMatters.totalOne = totalOneExpenditure;
      this.calculatedExpenditureFinMatters.totalTwo = totalTwoExpenditure;
      this.calculatedExpenditureFinMatters.totalThree = totalThreeExpenditure;

    }

    if (this.financialmatter.type == "income") {
      if (this.financialMattersIncome.length > 0) {
        this.displayIncomeTotal = true;
      }
    }

    if (this.financialmatter.type == "expenditure") {
      if (this.financialMattersExpenditure.length > 0) {
        this.displayExpenditureTotal = true;
      }
    }

    this.propertyTypes = null;
    this.propertySubtypes = null;
    this.displayDialogAddFin = false;
    this.selectedPropertyTypes = null;
    this.selectedPropertySubtypes = null;

    this.financialMattersChange.emit(this.financialmatter);
  }


  save() {

    this.financialmatter.property = this.selectedPropertyTypes.name;
    this.financialmatter.propertyId = Number(this.selectedPropertyTypes.id);
    this.financialmatter.subProperty = this.selectedPropertySubtypes.name;
    this.financialmatter.subPropertyId = Number(this.selectedPropertySubtypes.id);

    let financialmatter = [...this.financialMatters];
    if (this.newFinancialMatter) {
      financialmatter.push(this.financialmatter);
    }
    else {
      financialmatter[this.financialMatters.indexOf(this.selectedFinancialMatter)] = this.financialmatter;
    }

    this.financialMatters = financialmatter;
    this.financialMattersChange.emit(this.financialMatters);
    this.financialmatter = null;
  }

  onRowSelect(event) {

    this.selectedFinancialMatter = event.data;
    this.newFinancialMatter = false;
    this.financialmatter = this.cloneImplementation(event.data);

    // loadProperty Types
    this.dropDownService.getEntities(DropdownTypeEnum.PropertyType, false).subscribe((typs) => {
      this.propertyTypes = typs;
      let properties = this.propertyTypes?.filter(x => x.id == this.financialmatter.propertyId);

      if (properties.length > 0) {

        this.selectedPropertyTypes = properties[0];
        this.selectedPropertyTypes.name = properties[0].name;
      }
    });

    this.dropDownService.getEntities(DropdownTypeEnum.PropertySubType, false).subscribe((subpropertyTypes) => {
      this.propertySubtypes = subpropertyTypes;
      if (this.propertySubtypes.length > 0) {
        let subProperty = this.propertySubtypes.filter(x => x.id == this.financialmatter.subPropertyId);
        this.selectedPropertySubtypes = subProperty[0];
        this.selectedPropertySubtypes.id = subProperty[0].id;
        this.selectedPropertySubtypes.name = subProperty[0].name;
        this.displayDialogAddFin = true;
      }
    });
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
