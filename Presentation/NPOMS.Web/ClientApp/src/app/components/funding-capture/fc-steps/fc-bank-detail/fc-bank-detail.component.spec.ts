import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FCBankDetailComponent } from './fc-bank-detail.component';

describe('FcBankDetailComponent', () => {
  let component: FCBankDetailComponent;
  let fixture: ComponentFixture<FCBankDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FCBankDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FCBankDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
