import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditApplicationPeriodComponent } from './edit-application-period.component';

describe('EditApplicationPeriodComponent', () => {
  let component: EditApplicationPeriodComponent;
  let fixture: ComponentFixture<EditApplicationPeriodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditApplicationPeriodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditApplicationPeriodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
