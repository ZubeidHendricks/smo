import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcApplicationDetailEditComponent } from './qc-application-detail-edit.component';

describe('QcApplicationDetailEditComponent', () => {
  let component: QcApplicationDetailEditComponent;
  let fixture: ComponentFixture<QcApplicationDetailEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcApplicationDetailEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcApplicationDetailEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
