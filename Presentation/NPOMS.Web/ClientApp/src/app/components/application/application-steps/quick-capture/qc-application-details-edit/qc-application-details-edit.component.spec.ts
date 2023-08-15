import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcApplicationDetailsEditComponent } from './qc-application-details-edit.component';

describe('QcApplicationDetailsEditComponent', () => {
  let component: QcApplicationDetailsEditComponent;
  let fixture: ComponentFixture<QcApplicationDetailsEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcApplicationDetailsEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcApplicationDetailsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
