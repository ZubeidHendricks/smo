import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReviewAdjudicatedNpoComponent } from './review-adjudicated-npo.component';

describe('ReviewAdjudicatedNpoComponent', () => {
  let component: ReviewAdjudicatedNpoComponent;
  let fixture: ComponentFixture<ReviewAdjudicatedNpoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReviewAdjudicatedNpoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReviewAdjudicatedNpoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
