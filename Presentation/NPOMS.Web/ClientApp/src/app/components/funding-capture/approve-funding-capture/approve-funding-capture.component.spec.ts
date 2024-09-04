import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproveFundingCaptureComponent } from './approve-funding-capture.component';

describe('ApproveFundingCaptureComponent', () => {
  let component: ApproveFundingCaptureComponent;
  let fixture: ComponentFixture<ApproveFundingCaptureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApproveFundingCaptureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApproveFundingCaptureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
