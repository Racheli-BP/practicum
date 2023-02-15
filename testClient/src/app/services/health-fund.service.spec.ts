import { TestBed } from '@angular/core/testing';

import { HealthFundService } from './health-fund.service';

describe('HealthFundService', () => {
  let service: HealthFundService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HealthFundService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
