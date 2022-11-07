import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DirectorateBudgetComponent } from './directorate-budget.component';

describe('DirectorateBudgetComponent', () => {
  let component: DirectorateBudgetComponent;
  let fixture: ComponentFixture<DirectorateBudgetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DirectorateBudgetComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DirectorateBudgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
