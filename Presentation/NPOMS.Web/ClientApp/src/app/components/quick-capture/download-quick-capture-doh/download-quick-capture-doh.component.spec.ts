import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DownloadQuickCaptureDohComponent } from './download-quick-capture-doh.component';

describe('DownloadQuickCaptureDohComponent', () => {
  let component: DownloadQuickCaptureDohComponent;
  let fixture: ComponentFixture<DownloadQuickCaptureDohComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DownloadQuickCaptureDohComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DownloadQuickCaptureDohComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
