import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateNpoComponent } from './create-npo.component';

describe('CreateNpoComponent', () => {
  let component: CreateNpoComponent;
  let fixture: ComponentFixture<CreateNpoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateNpoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateNpoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
