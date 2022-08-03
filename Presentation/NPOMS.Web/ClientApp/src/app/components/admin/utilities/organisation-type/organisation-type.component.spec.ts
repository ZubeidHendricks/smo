import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganisationTypeComponent } from './organisation-type.component';

describe('OrganisationTypeComponent', () => {
  let component: OrganisationTypeComponent;
  let fixture: ComponentFixture<OrganisationTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrganisationTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrganisationTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
