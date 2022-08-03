import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationPeriodListComponent } from './application-period-list.component';

describe('ApplicationPeriodListComponent', () => {
  let component: ApplicationPeriodListComponent;
  let fixture: ComponentFixture<ApplicationPeriodListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationPeriodListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationPeriodListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
