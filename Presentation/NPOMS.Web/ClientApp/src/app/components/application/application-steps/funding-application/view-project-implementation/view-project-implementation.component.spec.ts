import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewProjectImplementationComponent } from './view-project-implementation.component';

describe('ViewProjectImplementationComponent', () => {
  let component: ViewProjectImplementationComponent;
  let fixture: ComponentFixture<ViewProjectImplementationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewProjectImplementationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewProjectImplementationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
