import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScorecardQuestionComponent } from './scorecard-question.component';

describe('ScorecardQuestionComponent', () => {
  let component: ScorecardQuestionComponent;
  let fixture: ComponentFixture<ScorecardQuestionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScorecardQuestionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ScorecardQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
