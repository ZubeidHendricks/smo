import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FcPaymentScheduleComponent } from './fc-payment-schedule.component';

describe('FcPaymentScheduleComponent', () => {
  let component: FcPaymentScheduleComponent;
  let fixture: ComponentFixture<FcPaymentScheduleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FcPaymentScheduleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FcPaymentScheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
