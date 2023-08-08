import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickCaptureEditListComponent } from './quick-capture-edit-list.component';

describe('QuickCaptureEditListComponent', () => {
  let component: QuickCaptureEditListComponent;
  let fixture: ComponentFixture<QuickCaptureEditListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuickCaptureEditListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickCaptureEditListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
