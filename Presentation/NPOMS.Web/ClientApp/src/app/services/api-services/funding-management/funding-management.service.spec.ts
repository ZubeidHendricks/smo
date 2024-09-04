import { TestBed } from '@angular/core/testing';

import { FundingManagementService } from './funding-management.service';

describe('FundingManagementService', () => {
  let service: FundingManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FundingManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
