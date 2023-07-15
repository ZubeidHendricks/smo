import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcApplicationPeriodsComponent } from './qc-application-periods.component';

describe('QcApplicationPeriodsComponent', () => {
  let component: QcApplicationPeriodsComponent;
  let fixture: ComponentFixture<QcApplicationPeriodsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcApplicationPeriodsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcApplicationPeriodsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
