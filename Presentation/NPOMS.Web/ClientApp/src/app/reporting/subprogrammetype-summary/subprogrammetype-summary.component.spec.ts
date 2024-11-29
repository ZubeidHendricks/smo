import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubprogrammetypeSummaryComponent } from './subprogrammetype-summary.component';

describe('SubprogrammetypeSummaryComponent', () => {
  let component: SubprogrammetypeSummaryComponent;
  let fixture: ComponentFixture<SubprogrammetypeSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubprogrammetypeSummaryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubprogrammetypeSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
