import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NpoListComponent } from './npo-list.component';

describe('NpoListComponent', () => {
  let component: NpoListComponent;
  let fixture: ComponentFixture<NpoListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NpoListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NpoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
