import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SummaryBusinessPlanComponent } from './summary-businessplan.component';

describe('SummaryBusinessPlanComponent', () => {
  let component: SummaryBusinessPlanComponent;
  let fixture: ComponentFixture<SummaryBusinessPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SummaryBusinessPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SummaryBusinessPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
