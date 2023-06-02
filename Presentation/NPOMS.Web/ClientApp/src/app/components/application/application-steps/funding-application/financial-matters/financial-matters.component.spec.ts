import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FinancialMattersComponent } from './financial-matters.component';

describe('FinancialMattersComponent', () => {
  let component: FinancialMattersComponent;
  let fixture: ComponentFixture<FinancialMattersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FinancialMattersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FinancialMattersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
