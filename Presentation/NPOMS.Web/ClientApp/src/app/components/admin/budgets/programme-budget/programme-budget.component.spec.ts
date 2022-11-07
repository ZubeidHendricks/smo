import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgrammeBudgetComponent } from './programme-budget.component';

describe('ProgrammeBudgetComponent', () => {
  let component: ProgrammeBudgetComponent;
  let fixture: ComponentFixture<ProgrammeBudgetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProgrammeBudgetComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProgrammeBudgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
