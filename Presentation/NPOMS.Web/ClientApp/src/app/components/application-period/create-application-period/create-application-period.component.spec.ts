import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateApplicationPeriodComponent } from './create-application-period.component';

describe('CreateApplicationPeriodComponent', () => {
  let component: CreateApplicationPeriodComponent;
  let fixture: ComponentFixture<CreateApplicationPeriodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateApplicationPeriodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateApplicationPeriodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
