import { ComponentFixture, TestBed } from '@angular/core/testing';
import { KorisniciDialog } from './korisnici-dialog';

describe('KorisniciDialog', () => {
  let component: KorisniciDialog;
  let fixture: ComponentFixture<KorisniciDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KorisniciDialog],
    }).compileComponents();

    fixture = TestBed.createComponent(KorisniciDialog);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
