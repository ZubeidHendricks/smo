import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcApplicationDetailViewComponent } from './qc-application-detail-view.component';

describe('QcApplicationDetailComponent', () => {
  let component: QcApplicationDetailViewComponent;
  let fixture: ComponentFixture<QcApplicationDetailViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcApplicationDetailViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcApplicationDetailViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
