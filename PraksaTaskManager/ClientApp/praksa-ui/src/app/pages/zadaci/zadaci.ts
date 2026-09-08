import { Component } from '@angular/core';
import { Zadaciservice } from '../../services/zadaciservice';
import { MatTableModule } from '@angular/material/table';
import { ZadaciDialog } from '../../dialog/zadaci-dialog/zadaci-dialog';
import { MatDialog } from '@angular/material/dialog';

@Component({
  imports: [MatTableModule ],
  standalone: true,   
  selector: 'app-zadaci',
  styleUrl: './zadaci.scss',
  templateUrl: './zadaci.html',
})
export class Zadaci {
  kolone: string[] = ['id', 'naziv', 'opis','rok'];
  zadacis: any[] = [];
  constructor(private zadaciservice:Zadaciservice, private dialog: MatDialog) {}
  ngOnInit() {
  this.zadaciservice.getZadaci().subscribe((data:any) => {
    console.log(data);
    this.zadacis = data as any[];
  });
}
otvoriDijalog(){
        this.dialog.open(ZadaciDialog);
      };
}

