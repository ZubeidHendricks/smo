import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcObjectivesEditComponent } from './qc-objectives-edit.component';

describe('QcObjectivesEditComponent', () => {
  let component: QcObjectivesEditComponent;
  let fixture: ComponentFixture<QcObjectivesEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcObjectivesEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcObjectivesEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
