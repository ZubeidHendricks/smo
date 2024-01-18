import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActualsBusinessPlanComponent } from './actuals-businessplan.component';

describe('ActualsBusinessPlanComponent', () => {
  let component: ActualsBusinessPlanComponent;
  let fixture: ComponentFixture<ActualsBusinessPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActualsBusinessPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActualsBusinessPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
