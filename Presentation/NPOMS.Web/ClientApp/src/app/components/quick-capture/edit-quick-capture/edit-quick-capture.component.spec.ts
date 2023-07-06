import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditQuickCaptureComponent } from './edit-quick-capture.component';

describe('EditQuickCaptureComponent', () => {
  let component: EditQuickCaptureComponent;
  let fixture: ComponentFixture<EditQuickCaptureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditQuickCaptureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditQuickCaptureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
