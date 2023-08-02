import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkflowApplicationComponent } from './workflow-application.component';

describe('WorkflowApplicationComponent', () => {
  let component: WorkflowApplicationComponent;
  let fixture: ComponentFixture<WorkflowApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WorkflowApplicationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkflowApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
