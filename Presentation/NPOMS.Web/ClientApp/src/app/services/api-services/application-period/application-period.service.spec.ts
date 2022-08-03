import { TestBed } from '@angular/core/testing';

import { ApplicationPeriodService } from './application-period.service';

describe('ApplicationPeriodService', () => {
  let service: ApplicationPeriodService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApplicationPeriodService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
