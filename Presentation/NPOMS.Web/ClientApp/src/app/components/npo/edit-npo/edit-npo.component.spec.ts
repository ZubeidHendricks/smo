import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditNpoComponent } from './edit-npo.component';

describe('EditNpoComponent', () => {
  let component: EditNpoComponent;
  let fixture: ComponentFixture<EditNpoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditNpoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditNpoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
