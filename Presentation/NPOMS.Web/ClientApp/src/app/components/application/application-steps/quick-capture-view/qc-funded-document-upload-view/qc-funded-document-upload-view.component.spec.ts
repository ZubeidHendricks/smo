import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcFundedDocumentUploadViewComponent } from './qc-funded-document-upload-view.component';

describe('QcFundedDocumentUploadViewComponent', () => {
  let component: QcFundedDocumentUploadViewComponent;
  let fixture: ComponentFixture<QcFundedDocumentUploadViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcFundedDocumentUploadViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcFundedDocumentUploadViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
