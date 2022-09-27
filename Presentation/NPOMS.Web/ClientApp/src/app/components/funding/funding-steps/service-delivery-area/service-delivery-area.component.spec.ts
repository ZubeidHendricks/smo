import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceDeliveryAreaComponent } from './service-delivery-area.component';

describe('ServiceDeliveryAreaComponent', () => {
  let component: ServiceDeliveryAreaComponent;
  let fixture: ComponentFixture<ServiceDeliveryAreaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServiceDeliveryAreaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceDeliveryAreaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
