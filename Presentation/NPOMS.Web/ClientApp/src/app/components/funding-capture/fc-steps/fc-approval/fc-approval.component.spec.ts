import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FCApprovalComponent } from './fc-approval.component';

describe('FCApprovalComponent', () => {
  let component: FCApprovalComponent;
  let fixture: ComponentFixture<FCApprovalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FCApprovalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FCApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
