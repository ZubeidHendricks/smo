import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcApplicationPeriodsDohViewComponent } from './qc-application-periods-doh-view.component';

describe('QcApplicationPeriodsDohViewComponent', () => {
  let component: QcApplicationPeriodsDohViewComponent;
  let fixture: ComponentFixture<QcApplicationPeriodsDohViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcApplicationPeriodsDohViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcApplicationPeriodsDohViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
