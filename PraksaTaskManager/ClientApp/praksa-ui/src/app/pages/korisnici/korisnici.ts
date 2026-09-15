import { Component } from '@angular/core';
import { Korisniciservice } from '../../services/korisniciservice';
import { MatTableModule } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { KorisniciDialog } from '../../dialog/korisnici-dialog/korisnici-dialog';
import { MatIconModule } from '@angular/material/icon';

@Component({
  imports: [MatTableModule,MatIconModule],
  selector: 'app-korisnici',
  styleUrl: './korisnici.scss',
  templateUrl: './korisnici.html',
})
export class Korisnici {
  kolone: string[] = ['id', 'ime', 'prezime','email','aktivan','akcije', 'brojZadataka'];
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

    obrisi(id:number){
      if(confirm('Da li ste sigurni da zelite da obrisete korisnika')){
        this.korisniciservice.obrisiKorisnika(id).subscribe(()=>{
          this.korisnicis=this.korisnicis.filter(k=>k.id!==id);
        });
      }
    }

    prikaziAktivneKorisnike(){
      this.korisniciservice.getAktivniKorisnici().subscribe((data)=>{
        this.korisnicis=data as any[];
      });
    }
    prikaziSveKorisnike(){
      this.korisniciservice.getKorisnici().subscribe((data)=>{
        this.korisnicis=data as any[];
      });
    }
    prikaziPoPrezimenu()
    {
      this.korisniciservice.getKorisniciPoPrezimenu().subscribe((data)=>{
        this.korisnicis=data as any[];
      });
    }

    prikaziBrojZadataka()
    {
      this.korisniciservice.getBrojZadatakaPoKorisniku().subscribe((data)=>{
        this.korisnicis=data as any[];
      });
    }
    
  }
