import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickCaptureListComponent } from './quick-capture-list.component';

describe('QuickCaptureListComponent', () => {
  let component: QuickCaptureListComponent;
  let fixture: ComponentFixture<QuickCaptureListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuickCaptureListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickCaptureListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
