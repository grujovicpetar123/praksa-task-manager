import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Zadaci } from './zadaci';

describe('Zadaci', () => {
  let component: Zadaci;
  let fixture: ComponentFixture<Zadaci>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Zadaci],
    }).compileComponents();

    fixture = TestBed.createComponent(Zadaci);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
