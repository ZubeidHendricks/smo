import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubProgrammeTypeComponent } from './sub-programme-type.component';

describe('SubProgrammeTypeComponent', () => {
  let component: SubProgrammeTypeComponent;
  let fixture: ComponentFixture<SubProgrammeTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubProgrammeTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubProgrammeTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
