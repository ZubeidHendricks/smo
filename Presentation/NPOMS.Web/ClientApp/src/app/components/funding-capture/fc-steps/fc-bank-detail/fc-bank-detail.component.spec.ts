import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FcBankDetailComponent } from './fc-bank-detail.component';

describe('FcBankDetailComponent', () => {
  let component: FcBankDetailComponent;
  let fixture: ComponentFixture<FcBankDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FcBankDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FcBankDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
