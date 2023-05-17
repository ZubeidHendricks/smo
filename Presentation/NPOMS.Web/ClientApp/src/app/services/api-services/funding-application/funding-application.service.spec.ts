import { TestBed } from '@angular/core/testing';

import { FundingApplicationService } from './funding-application.service';

describe('FundingApplicationService', () => {
  let service: FundingApplicationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FundingApplicationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
