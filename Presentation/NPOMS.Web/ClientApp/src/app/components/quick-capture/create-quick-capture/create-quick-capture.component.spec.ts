import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateQuickCaptureComponent } from './create-quick-capture.component';

describe('CreateQuickCaptureComponent', () => {
  let component: CreateQuickCaptureComponent;
  let fixture: ComponentFixture<CreateQuickCaptureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateQuickCaptureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateQuickCaptureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
