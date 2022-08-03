import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessReviewComponent } from './access-review.component';

describe('AccessReviewComponent', () => {
  let component: AccessReviewComponent;
  let fixture: ComponentFixture<AccessReviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccessReviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AccessReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
