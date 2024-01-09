import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScorecardActionComponent } from './scorecard-action.component';

describe('ScorecardActionComponent', () => {
  let component: ScorecardActionComponent;
  let fixture: ComponentFixture<ScorecardActionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ScorecardActionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ScorecardActionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
