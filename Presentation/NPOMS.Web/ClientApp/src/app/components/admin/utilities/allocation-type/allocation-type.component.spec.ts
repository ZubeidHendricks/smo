import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllocationTypeComponent } from './allocation-type.component';

describe('AllocationTypeComponent', () => {
  let component: AllocationTypeComponent;
  let fixture: ComponentFixture<AllocationTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllocationTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllocationTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
