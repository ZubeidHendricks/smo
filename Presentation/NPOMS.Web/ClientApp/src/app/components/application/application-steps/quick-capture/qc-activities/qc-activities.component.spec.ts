import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QCActivitiesComponent } from './qc-activities.component';

describe('ActivitiesComponent', () => {
  let component: QCActivitiesComponent;
  let fixture: ComponentFixture<QCActivitiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QCActivitiesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QCActivitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
