import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateFundingCaptureComponent } from './create-funding-capture.component';

describe('CreateFundingCaptureComponent', () => {
  let component: CreateFundingCaptureComponent;
  let fixture: ComponentFixture<CreateFundingCaptureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateFundingCaptureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateFundingCaptureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
