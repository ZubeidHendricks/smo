import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadSLAComponent } from './upload-sla.component';

describe('UploadSLAComponent', () => {
  let component: UploadSLAComponent;
  let fixture: ComponentFixture<UploadSLAComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UploadSLAComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UploadSLAComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
