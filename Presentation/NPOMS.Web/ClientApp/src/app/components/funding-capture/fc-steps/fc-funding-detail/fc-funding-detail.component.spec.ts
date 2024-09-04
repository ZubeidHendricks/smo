import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FCFundingDetailComponent } from './fc-funding-detail.component';

describe('FCFundingDetailComponent', () => {
  let component: FCFundingDetailComponent;
  let fixture: ComponentFixture<FCFundingDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FCFundingDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FCFundingDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
