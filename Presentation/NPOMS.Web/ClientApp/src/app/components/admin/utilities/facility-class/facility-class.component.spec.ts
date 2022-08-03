import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FacilityClassComponent } from './facility-class.component';

describe('FacilityClassComponent', () => {
  let component: FacilityClassComponent;
  let fixture: ComponentFixture<FacilityClassComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FacilityClassComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FacilityClassComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
