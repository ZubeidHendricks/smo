import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResponseOptionComponent } from './response-option.component';

describe('ResponseOptionComponent', () => {
  let component: ResponseOptionComponent;
  let fixture: ComponentFixture<ResponseOptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResponseOptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResponseOptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
