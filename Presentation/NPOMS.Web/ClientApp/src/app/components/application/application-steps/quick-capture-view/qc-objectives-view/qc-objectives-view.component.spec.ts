import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcObjectivesViewComponent } from './qc-objectives-view.component';

describe('QcObjectivesViewComponent', () => {
  let component: QcObjectivesViewComponent;
  let fixture: ComponentFixture<QcObjectivesViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcObjectivesViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcObjectivesViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
