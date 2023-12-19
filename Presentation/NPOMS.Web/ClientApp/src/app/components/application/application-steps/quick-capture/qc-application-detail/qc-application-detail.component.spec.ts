import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcApplicationDetailComponent } from './qc-application-detail.component';

describe('QcApplicationDetailComponent', () => {
  let component: QcApplicationDetailComponent;
  let fixture: ComponentFixture<QcApplicationDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcApplicationDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcApplicationDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
