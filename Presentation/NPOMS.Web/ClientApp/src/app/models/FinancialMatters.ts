

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