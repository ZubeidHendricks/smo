

export class FinancialMatters {
  constructor(
    public id: number,
    public propertyId: number,
    public property: string,
    public subProperty: string,
    public subPropertyId: number,
    public amountOne: number,
    public amountTwo: number,
    public amountThree: number,
    public bidId: number,
    public type: string) { }
}