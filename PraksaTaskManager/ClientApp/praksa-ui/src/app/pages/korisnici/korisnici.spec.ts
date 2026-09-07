import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Korisnici } from './korisnici';

describe('Korisnici', () => {
  let component: Korisnici;
  let fixture: ComponentFixture<Korisnici>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Korisnici],
    }).compileComponents();

    fixture = TestBed.createComponent(Korisnici);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
