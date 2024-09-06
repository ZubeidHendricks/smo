import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NpoReportCaptureComponent } from './npo-report-capture.component';

describe('NpoReportCaptureComponent', () => {
  let component: NpoReportCaptureComponent;
  let fixture: ComponentFixture<NpoReportCaptureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NpoReportCaptureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NpoReportCaptureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
