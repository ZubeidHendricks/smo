import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentSchedulesComponent } from './payment-schedules.component';

describe('PaymentSchedulesComponent', () => {
  let component: PaymentSchedulesComponent;
  let fixture: ComponentFixture<PaymentSchedulesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaymentSchedulesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentSchedulesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
