import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditFundingCaptureComponent } from './edit-funding-capture.component';

describe('EditFundingCaptureComponent', () => {
  let component: EditFundingCaptureComponent;
  let fixture: ComponentFixture<EditFundingCaptureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditFundingCaptureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditFundingCaptureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
