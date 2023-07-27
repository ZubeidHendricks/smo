import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewFinancialMattersComponent } from './view-financial-matters.component';

describe('ViewFinancialMattersComponent', () => {
  let component: ViewFinancialMattersComponent;
  let fixture: ComponentFixture<ViewFinancialMattersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewFinancialMattersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewFinancialMattersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
