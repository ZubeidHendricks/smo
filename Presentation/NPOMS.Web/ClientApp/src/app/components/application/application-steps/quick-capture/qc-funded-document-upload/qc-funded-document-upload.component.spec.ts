import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcFundedDocumentUploadComponent } from './qc-funded-document-upload.component';

describe('QcFundedDocumentUploadComponent', () => {
  let component: QcFundedDocumentUploadComponent;
  let fixture: ComponentFixture<QcFundedDocumentUploadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcFundedDocumentUploadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcFundedDocumentUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
