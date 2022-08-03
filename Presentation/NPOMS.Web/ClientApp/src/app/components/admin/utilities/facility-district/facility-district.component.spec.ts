import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FacilityDistrictComponent } from './facility-district.component';

describe('FacilityDistrictComponent', () => {
  let component: FacilityDistrictComponent;
  let fixture: ComponentFixture<FacilityDistrictComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FacilityDistrictComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FacilityDistrictComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
