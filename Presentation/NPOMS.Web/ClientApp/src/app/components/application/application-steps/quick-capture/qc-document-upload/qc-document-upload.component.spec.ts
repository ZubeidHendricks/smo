import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcDocumentUploadComponent } from './qc-document-upload.component';

describe('QcDocumentUploadComponent', () => {
  let component: QcDocumentUploadComponent;
  let fixture: ComponentFixture<QcDocumentUploadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcDocumentUploadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcDocumentUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
