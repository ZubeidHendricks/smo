import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReviewQuickCaptureDohComponent } from './review-quick-capture-doh.component';

describe('ReviewQuickCaptureDohComponent', () => {
  let component: ReviewQuickCaptureDohComponent;
  let fixture: ComponentFixture<ReviewQuickCaptureDohComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReviewQuickCaptureDohComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReviewQuickCaptureDohComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
