import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvisionTypeComponent } from './provision-type.component';

describe('ProvisionTypeComponent', () => {
  let component: ProvisionTypeComponent;
  let fixture: ComponentFixture<ProvisionTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProvisionTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvisionTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
