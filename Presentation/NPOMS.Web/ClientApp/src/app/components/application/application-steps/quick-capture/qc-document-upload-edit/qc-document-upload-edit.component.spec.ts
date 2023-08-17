import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcDocumentUploadEditComponent } from './qc-document-upload-edit.component';

describe('QcDocumentUploadEditComponent', () => {
  let component: QcDocumentUploadEditComponent;
  let fixture: ComponentFixture<QcDocumentUploadEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcDocumentUploadEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcDocumentUploadEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
