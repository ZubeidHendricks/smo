import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDocumentUploadComponent } from './view-document-upload.component';

describe('ViewDocumentUploadComponent', () => {
  let component: ViewDocumentUploadComponent;
  let fixture: ComponentFixture<ViewDocumentUploadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewDocumentUploadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewDocumentUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
