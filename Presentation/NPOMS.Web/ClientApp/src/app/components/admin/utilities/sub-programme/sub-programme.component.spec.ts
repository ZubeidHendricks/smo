import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubProgrammeComponent } from './sub-programme.component';

describe('SubProgrammeComponent', () => {
  let component: SubProgrammeComponent;
  let fixture: ComponentFixture<SubProgrammeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubProgrammeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubProgrammeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
