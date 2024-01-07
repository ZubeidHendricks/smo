import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcNpoDetailsViewComponent } from './qc-npo-details-view.component';

describe('QcNpoDetailsViewComponent', () => {
  let component: QcNpoDetailsViewComponent;
  let fixture: ComponentFixture<QcNpoDetailsViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcNpoDetailsViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcNpoDetailsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
