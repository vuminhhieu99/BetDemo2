import { TestBed } from '@angular/core/testing';

import { ControlLibService } from './control-lib.service';

describe('ControlLibService', () => {
  let service: ControlLibService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ControlLibService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
