import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcConfirmationComponent } from './qc-confirmation.component';

describe('QcConfirmationComponent', () => {
  let component: QcConfirmationComponent;
  let fixture: ComponentFixture<QcConfirmationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcConfirmationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
