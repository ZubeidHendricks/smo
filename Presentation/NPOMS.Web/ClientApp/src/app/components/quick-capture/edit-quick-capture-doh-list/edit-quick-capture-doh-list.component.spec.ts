import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditQuickCaptureDohListComponent } from './edit-quick-capture-doh-list.component';

describe('EditQuickCaptureDohListComponent', () => {
  let component: EditQuickCaptureDohListComponent;
  let fixture: ComponentFixture<EditQuickCaptureDohListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditQuickCaptureDohListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditQuickCaptureDohListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
