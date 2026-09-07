import { Component } from '@angular/core';
import { Korisniciservice } from '../../services/korisniciservice';
import { MatTableModule } from '@angular/material/table';

@Component({
  imports: [MatTableModule ],
  selector: 'app-korisnici',
  styleUrl: './korisnici.scss',
  templateUrl: './korisnici.html',
})
export class Korisnici {
  kolone: string[] = ['id', 'ime', 'prezime','email','aktivan'];
  korisnicis: any[] = [];
    constructor(private korisniciservice:Korisniciservice) {}
    ngOnInit() {
    this.korisniciservice.getKorisnici().subscribe((data:any) => {
      console.log(data);
      this.korisnicis = data as any[];
    });
  }
}
