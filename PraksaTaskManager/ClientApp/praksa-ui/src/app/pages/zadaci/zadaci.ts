import { Component } from '@angular/core';
import { Zadaciservice } from '../../services/zadaciservice';
import { MatTableModule } from '@angular/material/table';
import { ZadaciDialog } from '../../dialog/zadaci-dialog/zadaci-dialog';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

@Component({
  imports: [MatTableModule, MatIconModule],
  standalone: true,
  selector: 'app-zadaci',
  styleUrl: './zadaci.scss',
  templateUrl: './zadaci.html',
})

export class Zadaci {
  constructor(private zadaciservice: Zadaciservice, private dialog: MatDialog,) { }
  kolone: string[] = ['id', 'naziv', 'opis', 'rok', 'akcije'];
  zadacis: any[] = [];

  ngOnInit() {
    this.zadaciservice.getZadaci().subscribe((data: any) => {
      console.log(data);
      this.zadacis = data as any[];
    });
  }
  otvoriDijalog() {
    const ref = this.dialog.open(ZadaciDialog);
    ref.afterClosed().subscribe(result => {
      if (result) {
        this.zadaciservice.getZadaci().subscribe(data => {
          this.zadacis = data as any[];
        });
      }
    });
  }

  obrisi(id: number) {
    if (confirm('Da li ste sigurni da zelite da obrisete ovaj zadatak')) {
      this.zadaciservice.obrisiZadatak(id).subscribe(() => {
        this.zadacis = this.zadacis.filter(z => z.id !== z);
      });
    }
  }

  prikaziRokNijeProsao() {
    this.zadaciservice.getZadaciRokNijeProsao().subscribe((data) => {
      this.zadacis = data as any[];
    });
  }

  prikaziSveZadatke(){
      this.zadaciservice.getZadaci().subscribe((data)=>{
        this.zadacis=data as any[];
      });
    }
}








