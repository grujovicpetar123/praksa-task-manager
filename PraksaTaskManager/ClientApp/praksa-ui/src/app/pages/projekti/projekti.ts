import { Component } from '@angular/core';
import { Projektiservice } from '../../services/projektiservice';
import { MatTableModule } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { ProjektiDialog } from '../../dialog/projekti-dialog/projekti-dialog';

@Component({
  imports: [MatTableModule ],
  standalone:true,
  selector: 'app-projekti',
  styleUrl: './projekti.scss',
  templateUrl: './projekti.html',
})
export class Projekti {
   kolone: string[] = ['id', 'naziv', 'opis','aktivan'];
   projektis: any[] = [];
      constructor(private projektiservice:Projektiservice, private dialog: MatDialog) {}
      ngOnInit() {
      this.projektiservice.getProjekti().subscribe((data:any) => {
        console.log(data);
        this.projektis = data as any[];
      });}
      otvoriDijalog(){
        this.dialog.open(ProjektiDialog);
      };
    }

