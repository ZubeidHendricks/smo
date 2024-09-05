import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DownloadFundingCaptureComponent } from './download-funding-capture.component';

describe('DownloadFundingCaptureComponent', () => {
  let component: DownloadFundingCaptureComponent;
  let fixture: ComponentFixture<DownloadFundingCaptureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DownloadFundingCaptureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DownloadFundingCaptureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
