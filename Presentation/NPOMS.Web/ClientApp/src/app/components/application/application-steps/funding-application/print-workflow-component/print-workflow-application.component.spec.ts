import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintWorkflowApplicationComponent } from './print-workflow-application.component';

describe('WorkflowApplicationComponent', () => {
  let component: PrintWorkflowApplicationComponent;
  let fixture: ComponentFixture<PrintWorkflowApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintWorkflowApplicationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintWorkflowApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
