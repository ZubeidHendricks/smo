import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NpoApprovalComponent } from './npo-approval.component';

describe('NpoApprovalComponent', () => {
  let component: NpoApprovalComponent;
  let fixture: ComponentFixture<NpoApprovalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NpoApprovalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NpoApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
