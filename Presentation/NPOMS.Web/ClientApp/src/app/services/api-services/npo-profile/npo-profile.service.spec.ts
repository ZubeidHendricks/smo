import { TestBed } from '@angular/core/testing';

import { NpoProfileService } from './npo-profile.service';

describe('NpoProfileService', () => {
  let service: NpoProfileService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NpoProfileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
