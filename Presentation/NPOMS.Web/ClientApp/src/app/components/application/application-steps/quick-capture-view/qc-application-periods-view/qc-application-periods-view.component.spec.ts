import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcApplicationPeriodsViewComponent } from './qc-application-periods-view.component';

describe('QcApplicationPeriodsComponent', () => {
  let component: QcApplicationPeriodsViewComponent;
  let fixture: ComponentFixture<QcApplicationPeriodsViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcApplicationPeriodsViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcApplicationPeriodsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
