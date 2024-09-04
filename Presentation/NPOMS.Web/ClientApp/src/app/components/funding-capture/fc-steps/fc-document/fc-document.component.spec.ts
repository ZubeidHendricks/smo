import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FcDocumentComponent } from './fc-document.component';

describe('FcDocumentComponent', () => {
  let component: FcDocumentComponent;
  let fixture: ComponentFixture<FcDocumentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FcDocumentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FcDocumentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
