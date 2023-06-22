

export class FinancialMatters {
  constructor(
    public id: number,
    public fundingApplicationDetailId: number,
 
    public property: string,
    //public subProperty: string,
    public amountOne: number,
    public amountTwo: number,
    public amountThree: number,
    public totalFundingAmount: number,
    public createdDateTime: Date,
    public type: string) { }
}

export interface IPreviousFinancialYear {
  id: number;
  fundingApplicationDetailId: number;
  incomeDescription: string;
  incomeAmount: number;
  expenditureDescription: string;
  expenditureAmount: number;
  createdUserId: number;
  createdDateTime: Date;
  updatedUserId: number;
  updatedDateTime: Date;
}

export class IFinancialMattersIncome {

    id: number;
    fundingApplicationDetailId: number;
    incomeDescription: string;
    amountOneI: number;
    amountTwoI: number;
    amountThreeI: number;
    totalFundingAmountI: number;
    typeI:string;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;
}

export class IFinancialMattersExpenditure {
  id: number;
  fundingApplicationDetailId: number;
  expenditureDescription: string;
  amountOneE: number;
  amountTwoE: number;
  amountThreeE: number;
  totalFundingAmountE: number;
  typeE:string;
  createdUserId: number;
  createdDateTime: Date;
  updatedUserId: number;
  updatedDateTime: Date;
}
export class IFinancialMattersOthers {
  id: number;
  fundingApplicationDetailId: number;
  otherDescription: string;
  amountOneO: number;
  amountTwoO: number;
  amountThreeO: number;
  totalFundingAmountO: number;
  typeO:string;
  createdUserId: number;
  createdDateTime: Date;
  updatedUserId: number;
  updatedDateTime: Date;
}


export interface ISourceOfInformation {
  id: number;
  npoProfileId: number;
  selectedSourceValue: number;
  additionalSourceInformation: string;
  createdUserId: number;
  createdDateTime: Date;
  updatedUserId: number;
  updatedDateTime: Date;
}

export interface IAffiliatedOrganisation {
  id: number;
  fundingApplicationDetailId: number;
  nameOfOrganisation: string;
  contactPerson: string;
  emailAddress: string;
  telephoneNumber: string;
  website: string;
  createdUserId: number;
  createdDateTime: Date;
  updatedUserId: number;
  updatedDateTime: Date;
}