import { TestBed } from '@angular/core/testing';
import { Projektiservice } from './projektiservice';

describe('Projektiservice', () => {
  let service: Projektiservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Projektiservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
