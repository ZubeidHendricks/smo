import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewFundingCaptureComponent } from './view-funding-capture.component';

describe('ViewFundingCaptureComponent', () => {
  let component: ViewFundingCaptureComponent;
  let fixture: ComponentFixture<ViewFundingCaptureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewFundingCaptureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewFundingCaptureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
