import { TestBed } from '@angular/core/testing';

import { CurrencyHelper } from './currency-helper.service';

describe('CurrencyHelper', () => {
  let service: CurrencyHelper;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CurrencyHelper);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
