import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FundingApplicationViewComponent } from './funding-application-view.component';

describe('FundingApplicationViewComponent', () => {
  let component: FundingApplicationViewComponent;
  let fixture: ComponentFixture<FundingApplicationViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FundingApplicationViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FundingApplicationViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
