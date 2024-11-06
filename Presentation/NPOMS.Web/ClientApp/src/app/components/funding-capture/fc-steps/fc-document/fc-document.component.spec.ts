import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FCDocumentComponent } from './fc-document.component';

describe('FcDocumentComponent', () => {
  let component: FCDocumentComponent;
  let fixture: ComponentFixture<FCDocumentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FCDocumentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FCDocumentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
