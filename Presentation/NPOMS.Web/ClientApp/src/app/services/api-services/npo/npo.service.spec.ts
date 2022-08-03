import { TestBed } from '@angular/core/testing';

import { NpoService } from './npo.service';

describe('NpoService', () => {
  let service: NpoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NpoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
