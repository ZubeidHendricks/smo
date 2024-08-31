import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QCActivitiesEditComponent } from './qc-activities-edit.component';

describe('QCActivitiesEditComponent', () => {
  let component: QCActivitiesEditComponent;
  let fixture: ComponentFixture<QCActivitiesEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QCActivitiesEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QCActivitiesEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
