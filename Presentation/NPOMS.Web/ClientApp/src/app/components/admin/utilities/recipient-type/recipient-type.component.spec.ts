import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipientTypeComponent } from './recipient-type.component';

describe('RecipientTypeComponent', () => {
  let component: RecipientTypeComponent;
  let fixture: ComponentFixture<RecipientTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecipientTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipientTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
