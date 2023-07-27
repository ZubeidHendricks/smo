import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewMonitoringEvaluationComponent } from './view-monitoring-evaluation.component';

describe('ViewMonitoringEvaluationComponent', () => {
  let component: ViewMonitoringEvaluationComponent;
  let fixture: ComponentFixture<ViewMonitoringEvaluationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewMonitoringEvaluationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewMonitoringEvaluationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
