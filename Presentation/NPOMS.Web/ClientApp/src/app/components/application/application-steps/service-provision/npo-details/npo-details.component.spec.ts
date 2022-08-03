import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NpoDetailsComponent } from './npo-details.component';

describe('NpoDetailsComponent', () => {
  let component: NpoDetailsComponent;
  let fixture: ComponentFixture<NpoDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NpoDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NpoDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
