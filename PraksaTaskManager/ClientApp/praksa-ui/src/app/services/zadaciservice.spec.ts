import { TestBed } from '@angular/core/testing';
import { Zadaciservice } from './zadaciservice';

describe('Zadaciservice', () => {
  let service: Zadaciservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Zadaciservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
