import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompliantCyclesComponent } from './compliant-cycles.component';

describe('CompliantCyclesComponent', () => {
  let component: CompliantCyclesComponent;
  let fixture: ComponentFixture<CompliantCyclesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompliantCyclesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CompliantCyclesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
