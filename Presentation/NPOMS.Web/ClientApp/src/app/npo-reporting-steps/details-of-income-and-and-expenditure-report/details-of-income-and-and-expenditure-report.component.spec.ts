import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsOfIncomeAndAndExpenditureReportComponent } from './details-of-income-and-and-expenditure-report.component';

describe('DetailsOfIncomeAndAndExpenditureReportComponent', () => {
  let component: DetailsOfIncomeAndAndExpenditureReportComponent;
  let fixture: ComponentFixture<DetailsOfIncomeAndAndExpenditureReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsOfIncomeAndAndExpenditureReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsOfIncomeAndAndExpenditureReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
