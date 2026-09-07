import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Projekti } from './projekti';

describe('Projekti', () => {
  let component: Projekti;
  let fixture: ComponentFixture<Projekti>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Projekti],
    }).compileComponents();

    fixture = TestBed.createComponent(Projekti);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
