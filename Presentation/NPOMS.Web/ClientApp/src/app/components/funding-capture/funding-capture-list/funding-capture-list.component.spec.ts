import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FundingCaptureListComponent } from './funding-capture-list.component';

describe('FundingCaptureListComponent', () => {
  let component: FundingCaptureListComponent;
  let fixture: ComponentFixture<FundingCaptureListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FundingCaptureListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FundingCaptureListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
