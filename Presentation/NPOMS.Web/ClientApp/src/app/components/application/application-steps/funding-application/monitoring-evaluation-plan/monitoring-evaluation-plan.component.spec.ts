import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonitoringEvaluationPlanComponent } from './monitoring-evaluation-plan.component';

describe('MonitoringEvaluationPlanComponent', () => {
  let component: MonitoringEvaluationPlanComponent;
  let fixture: ComponentFixture<MonitoringEvaluationPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MonitoringEvaluationPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MonitoringEvaluationPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
