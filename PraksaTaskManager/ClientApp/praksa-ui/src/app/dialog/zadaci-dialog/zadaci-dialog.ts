import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Zadaciservice } from '../../services/zadaciservice';

@Component({
  standalone: true,
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule, MatDialogModule],
  selector: 'app-zadaci-dialog',
  styleUrl: './zadaci-dialog.scss',
  templateUrl: './zadaci-dialog.html',
})
export class ZadaciDialog implements OnInit {
  korisnici: any[] = []; 
  projekti: any[] = []; 
  statusi: any[] = [];
  prioriteti: any[] = []; 
  forma = new FormGroup({ naziv: new FormControl(''), 
    opis: new FormControl(''), 
   
    prioritetId: new FormControl(null), 
    rok: new FormControl(''), 
    datumKreiranja: new FormControl(''), 
    korisnikId: new FormControl(null), 
    projekatId: new FormControl(null),
     statusId: new FormControl(null), 
  });

  constructor(
    private zadaciService: Zadaciservice,
    private dialogRef: MatDialogRef<ZadaciDialog>
  ){

  }

    ngOnInit() {     
      this.zadaciService.getKorisnici().subscribe(data => {       this.korisnici = data as any;     });     
      this.zadaciService.getProjekti().subscribe(data => {       this.projekti = data as any;     });     
      this.zadaciService.getStatusi().subscribe(data => {       this.statusi = data as any; console.log(data)    });
      this.zadaciService.getPrioriteti().subscribe(data => {       this.prioriteti = data as any;     });   
    }
    sacuvaj() {     
      console.log(this.forma.value);     
      this.zadaciService.dodajZadatak(this.forma.value)
      .subscribe({         
        next: data => {           
          console.log('Zadatak dodat', data);           
          this.dialogRef.close(true);
                 },         
                 error: error => { 
                  console.log('Greška:', error);
                         }       
                        });   
                     
    }
     zatvori(){
                        this.dialogRef.close();
                      }
  }


