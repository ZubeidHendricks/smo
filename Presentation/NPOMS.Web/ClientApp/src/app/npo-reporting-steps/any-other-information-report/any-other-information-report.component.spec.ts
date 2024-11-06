import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnyOtherInformationReportComponent } from './any-other-information-report.component';

describe('AnyOtherInformationReportComponent', () => {
  let component: AnyOtherInformationReportComponent;
  let fixture: ComponentFixture<AnyOtherInformationReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AnyOtherInformationReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AnyOtherInformationReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
