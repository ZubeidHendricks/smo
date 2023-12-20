import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QcObjectivesComponent } from './qc-objectives.component';

describe('QcObjectivesComponent', () => {
  let component: QcObjectivesComponent;
  let fixture: ComponentFixture<QcObjectivesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QcObjectivesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QcObjectivesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
