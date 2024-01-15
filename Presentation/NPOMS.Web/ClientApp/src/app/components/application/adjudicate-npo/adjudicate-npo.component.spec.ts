import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdjudicateNpoComponent } from './adjudicate-npo.component';

describe('AdjudicateNpoComponent', () => {
  let component: AdjudicateNpoComponent;
  let fixture: ComponentFixture<AdjudicateNpoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdjudicateNpoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdjudicateNpoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
