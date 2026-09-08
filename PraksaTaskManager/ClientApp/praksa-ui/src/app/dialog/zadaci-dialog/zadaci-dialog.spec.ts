import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ZadaciDialog } from './zadaci-dialog';

describe('ZadaciDialog', () => {
  let component: ZadaciDialog;
  let fixture: ComponentFixture<ZadaciDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ZadaciDialog],
    }).compileComponents();

    fixture = TestBed.createComponent(ZadaciDialog);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
