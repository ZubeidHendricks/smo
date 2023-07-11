import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkflowAssessmentComponent } from './workflow-assessment.component';

describe('WorkflowAssessmentComponent', () => {
  let component: WorkflowAssessmentComponent;
  let fixture: ComponentFixture<WorkflowAssessmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WorkflowAssessmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkflowAssessmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
