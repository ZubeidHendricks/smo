import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TargetsBusinessPlanComponent } from './targets-businessplan.component';

describe('TargetsBusinessPlanComponent', () => {
  let component: TargetsBusinessPlanComponent;
  let fixture: ComponentFixture<TargetsBusinessPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TargetsBusinessPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TargetsBusinessPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
