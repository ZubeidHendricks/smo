import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewQuickCaptureDohComponent } from './view-quick-capture-doh.component';

describe('ViewQuickCaptureDohComponent', () => {
  let component: ViewQuickCaptureDohComponent;
  let fixture: ComponentFixture<ViewQuickCaptureDohComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewQuickCaptureDohComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewQuickCaptureDohComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
