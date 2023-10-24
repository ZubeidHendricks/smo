import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewNpoDetailsComponent } from './view-npo-details.component';

describe('ViewNpoDetailsComponent', () => {
  let component: ViewNpoDetailsComponent;
  let fixture: ComponentFixture<ViewNpoDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewNpoDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewNpoDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
