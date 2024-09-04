import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FCSDAComponent } from './fc-sda.component';

describe('FCSDAComponent', () => {
  let component: FCSDAComponent;
  let fixture: ComponentFixture<FCSDAComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FCSDAComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FCSDAComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
