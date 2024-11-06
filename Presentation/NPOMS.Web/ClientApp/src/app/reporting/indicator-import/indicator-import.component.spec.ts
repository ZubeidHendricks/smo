import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndicatorImportComponent } from './indicator-import.component';

describe('IndicatorImportComponent', () => {
  let component: IndicatorImportComponent;
  let fixture: ComponentFixture<IndicatorImportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IndicatorImportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IndicatorImportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
