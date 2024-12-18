import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateFundingComponent } from './create-funding.component';

describe('CreateFundingComponent', () => {
  let component: CreateFundingComponent;
  let fixture: ComponentFixture<CreateFundingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateFundingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateFundingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
