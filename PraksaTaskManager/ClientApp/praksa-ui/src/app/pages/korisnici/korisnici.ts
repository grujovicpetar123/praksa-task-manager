import { Component } from '@angular/core';
import { Korisniciservice } from '../../services/korisniciservice';
import { MatTableModule } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { KorisniciDialog } from '../../dialog/korisnici-dialog/korisnici-dialog';

@Component({
  imports: [MatTableModule ],
  selector: 'app-korisnici',
  styleUrl: './korisnici.scss',
  templateUrl: './korisnici.html',
})
export class Korisnici {
  kolone: string[] = ['id', 'ime', 'prezime','email','aktivan'];
  korisnicis: any[] = [];
  
    constructor(private korisniciservice:Korisniciservice, private dialog: MatDialog) {}
    ngOnInit() {
    this.korisniciservice.getKorisnici().subscribe((data:any) => {
      console.log(data);
      this.korisnicis = data as any[];
    });
  }
   otvoriDijalog() {
      const ref = this.dialog.open(KorisniciDialog);
      ref.afterClosed().subscribe(result => {
        if (result) {
          this.korisniciservice.getKorisnici().subscribe(data =>{
            this.korisnicis = data as any[];
          });
    }
  });
    }
  }
