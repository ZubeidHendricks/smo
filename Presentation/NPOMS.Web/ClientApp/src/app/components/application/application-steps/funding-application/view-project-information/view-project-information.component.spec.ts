import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewProjectInformationComponent } from './view-project-information.component';

describe('ViewProjectInformationComponent', () => {
  let component: ViewProjectInformationComponent;
  let fixture: ComponentFixture<ViewProjectInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewProjectInformationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewProjectInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
