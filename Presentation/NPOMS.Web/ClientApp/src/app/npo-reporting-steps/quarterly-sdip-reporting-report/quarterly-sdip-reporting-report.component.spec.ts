import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuarterlySDIPReportingReportComponent } from './quarterly-sdip-reporting-report.component';

describe('QuarterlySDIPReportingReportComponent', () => {
  let component: QuarterlySDIPReportingReportComponent;
  let fixture: ComponentFixture<QuarterlySDIPReportingReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuarterlySDIPReportingReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuarterlySDIPReportingReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
