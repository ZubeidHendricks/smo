import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportActualsComponent } from './report-actuals.component';

describe('ReportActualsComponent', () => {
  let component: ReportActualsComponent;
  let fixture: ComponentFixture<ReportActualsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportActualsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportActualsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
