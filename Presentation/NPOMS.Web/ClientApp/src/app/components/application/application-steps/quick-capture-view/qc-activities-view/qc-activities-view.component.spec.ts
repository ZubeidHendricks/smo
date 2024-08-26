import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QCActivitiesViewComponent } from './qc-activities-view.component';

describe('QCActivitiesViewComponent', () => {
  let component: QCActivitiesViewComponent;
  let fixture: ComponentFixture<QCActivitiesViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QCActivitiesViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QCActivitiesViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
