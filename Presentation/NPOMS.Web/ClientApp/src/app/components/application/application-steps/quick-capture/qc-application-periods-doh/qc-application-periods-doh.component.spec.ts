import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcApplicationPeriodsDohComponent } from './qc-application-periods-doh.component';

describe('QcApplicationPeriodsDohComponent', () => {
  let component: QcApplicationPeriodsDohComponent;
  let fixture: ComponentFixture<QcApplicationPeriodsDohComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcApplicationPeriodsDohComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcApplicationPeriodsDohComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
