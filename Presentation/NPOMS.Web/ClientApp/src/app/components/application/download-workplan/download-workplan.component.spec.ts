import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DownloadWorkplanComponent } from './download-workplan.component';

describe('DownloadWorkplanComponent', () => {
  let component: DownloadWorkplanComponent;
  let fixture: ComponentFixture<DownloadWorkplanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DownloadWorkplanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DownloadWorkplanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
