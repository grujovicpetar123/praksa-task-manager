import { Component } from '@angular/core';
import { Korisniciservice } from '../../services/korisniciservice';
import { MatTableModule } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { KorisniciDialog } from '../../dialog/korisnici-dialog/korisnici-dialog';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';


@Component({
  imports: [MatTableModule,MatIconModule,CommonModule],
  selector: 'app-korisnici',
  styleUrl: './korisnici.scss',
  templateUrl: './korisnici.html',
})
export class Korisnici {
  kolone: string[] = ['id', 'ime', 'prezime','email','aktivan','akcije'];
  koloneIzvestajZadataka:string[]=['ime', 'prezime','brojZadataka'];
  koloneIzvestajBrojKomentara:string[]=['ime','prezime','brojKomentara'];
  korisnicis: any[] = [];
  izvestajBrojZadataka:any[]=[];
  izvestajBrojKomentara:any[]=[];
  prikazujemIzvestajZadataka=false;
  prikazujemIzvestajKomentara=false;
  
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
          this.prikazujemIzvestajZadataka=false;
          this.prikazujemIzvestajKomentara=false;
        });
      }
    }

    prikaziAktivneKorisnike(){
      this.korisniciservice.getAktivniKorisnici().subscribe((data)=>{
        this.korisnicis=data as any[];
        this.prikazujemIzvestajZadataka=false;
        this.prikazujemIzvestajKomentara=false;
      });
    }
    prikaziSveKorisnike(){
      this.korisniciservice.getKorisnici().subscribe((data)=>{
        this.korisnicis=data as any[];
        this.prikazujemIzvestajZadataka=false;
        this.prikazujemIzvestajKomentara=false;
      });
    }
    prikaziPoPrezimenu()
    {
      this.korisniciservice.getKorisniciPoPrezimenu().subscribe((data)=>{
        this.korisnicis=data as any[];
        this.prikazujemIzvestajZadataka=false;
        this.prikazujemIzvestajKomentara=false;
      });
    }

    prikaziBrojZadataka()
    {
      this.korisniciservice.getBrojZadatakaPoKorisniku().subscribe((data)=>{
        this.izvestajBrojZadataka=data as any[];
        this.prikazujemIzvestajZadataka=true;
        this.prikazujemIzvestajKomentara=false;
      });
    }
    prikaziBrojKomentara()
    {
      this.korisniciservice.getBrojKomentaraPoKorisniku().subscribe((data)=>{
        this.izvestajBrojKomentara=data as any[];
        this.prikazujemIzvestajKomentara=true;
        this.prikazujemIzvestajZadataka=false;
    });
  }
  }
