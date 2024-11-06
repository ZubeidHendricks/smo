import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FCPaymentScheduleComponent } from './fc-payment-schedule.component';

describe('FcPaymentScheduleComponent', () => {
  let component: FCPaymentScheduleComponent;
  let fixture: ComponentFixture<FCPaymentScheduleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FCPaymentScheduleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FCPaymentScheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
