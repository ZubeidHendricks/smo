import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewNpoComponent } from './view-npo.component';

describe('ViewNpoComponent', () => {
  let component: ViewNpoComponent;
  let fixture: ComponentFixture<ViewNpoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewNpoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewNpoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
