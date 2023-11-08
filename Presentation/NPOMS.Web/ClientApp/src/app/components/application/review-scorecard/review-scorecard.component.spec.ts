import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReviewScorecardComponent } from './review-scorecard.component';

describe('ReviewScorecardComponent', () => {
  let component: ReviewScorecardComponent;
  let fixture: ComponentFixture<ReviewScorecardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReviewScorecardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReviewScorecardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
