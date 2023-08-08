import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrintFundingApplicatonComponent } from './print-funding-applicaton.component';

describe('PrintFundingApplicatonComponent', () => {
  let component: PrintFundingApplicatonComponent;
  let fixture: ComponentFixture<PrintFundingApplicatonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrintFundingApplicatonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrintFundingApplicatonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
