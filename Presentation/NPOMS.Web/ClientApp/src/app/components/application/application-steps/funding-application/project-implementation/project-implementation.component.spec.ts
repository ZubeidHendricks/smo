import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectImplementationComponent } from './project-implementation.component';

describe('ProjectImplementationComponent', () => {
  let component: ProjectImplementationComponent;
  let fixture: ComponentFixture<ProjectImplementationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjectImplementationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectImplementationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
