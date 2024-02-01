import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageBusinessPlanComponent } from './manage-businessplan.component';

describe('ManageBusinessPlanComponent', () => {
  let component: ManageBusinessPlanComponent;
  let fixture: ComponentFixture<ManageBusinessPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageBusinessPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageBusinessPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
