import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResourcingComponent } from './resourcing.component';

describe('ResourcingComponent', () => {
  let component: ResourcingComponent;
  let fixture: ComponentFixture<ResourcingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResourcingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResourcingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
