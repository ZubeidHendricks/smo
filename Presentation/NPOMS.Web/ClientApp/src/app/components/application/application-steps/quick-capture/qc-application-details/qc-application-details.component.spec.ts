import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcApplicationDetailsComponent } from './qc-application-details.component';

describe('QcApplicationDetailsComponent', () => {
  let component: QcApplicationDetailsComponent;
  let fixture: ComponentFixture<QcApplicationDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcApplicationDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcApplicationDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
