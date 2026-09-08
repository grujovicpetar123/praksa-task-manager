import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ProjektiDialog } from './projekti-dialog';

describe('ProjektiDialog', () => {
  let component: ProjektiDialog;
  let fixture: ComponentFixture<ProjektiDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProjektiDialog],
    }).compileComponents();

    fixture = TestBed.createComponent(ProjektiDialog);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
