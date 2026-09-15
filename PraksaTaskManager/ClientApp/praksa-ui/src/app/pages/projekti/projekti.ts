import { Component } from '@angular/core';
import { Projektiservice } from '../../services/projektiservice';
import { MatTableModule } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { ProjektiDialog } from '../../dialog/projekti-dialog/projekti-dialog';
import { MatIconModule } from '@angular/material/icon';

@Component({
  imports: [MatTableModule, MatIconModule ],
  standalone:true,
  selector: 'app-projekti',
  styleUrl: './projekti.scss',
  templateUrl: './projekti.html',
})
export class Projekti {
   kolone: string[] = ['id', 'naziv', 'opis','aktivan','akcije'];
   projektis: any[] = [];
      constructor(private projektiservice:Projektiservice, private dialog: MatDialog) {}
      ngOnInit() {
      this.projektiservice.getProjekti().subscribe((data:any) => {
        console.log(data);
        this.projektis = data as any[];
      });}
         otvoriDijalog() {
            const ref = this.dialog.open(ProjektiDialog);
            ref.afterClosed().subscribe(result => {
              if (result) {
                this.projektiservice.getProjekti().subscribe(data =>{
                  this.projektis = data as any[];
                });
          }
        });
          }

          obrisi(id:number){
      if(confirm('Da li ste sigurni da zelite da obrisete ovaj projekat')){
        this.projektiservice.obrisiProjekat(id).subscribe(()=>{
          this.projektis=this.projektis.filter(p=>p.id!==p);
        });
      }
    }
     prikaziAktivneProjekte(){
      this.projektiservice.getAktivniProjekti().subscribe((data)=>{
        this.projektis=data as any[];
      });
    }
    prikaziSveProjekte(){
      this.projektiservice.getProjekti().subscribe((data)=>{
        this.projektis=data as any[];
      });
    }
        }

