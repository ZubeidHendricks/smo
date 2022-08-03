import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FacilitySubDistrictComponent } from './facility-sub-district.component';

describe('FacilitySubDistrictComponent', () => {
  let component: FacilitySubDistrictComponent;
  let fixture: ComponentFixture<FacilitySubDistrictComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FacilitySubDistrictComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FacilitySubDistrictComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
