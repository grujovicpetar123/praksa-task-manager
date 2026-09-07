import { TestBed } from '@angular/core/testing';
import { Korisniciservice } from './korisniciservice';

describe('Korisniciservice', () => {
  let service: Korisniciservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Korisniciservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
