import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewFundingApplicationComponent } from './view-funding-application.component';

describe('ViewFundingApplicationComponent', () => {
  let component: ViewFundingApplicationComponent;
  let fixture: ComponentFixture<ViewFundingApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewFundingApplicationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewFundingApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
