import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Korisniciservice } from '../../services/korisniciservice';
import { MatCheckboxModule } from '@angular/material/checkbox';

@Component({
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule, MatDialogModule, MatCheckboxModule],
  selector: 'app-korisnici-dialog',
  styleUrl: './korisnici-dialog.scss',
  templateUrl: './korisnici-dialog.html',
})
export class KorisniciDialog implements OnInit{
forma = new FormGroup({ 
    ime: new FormControl(''), 
    email: new FormControl(''), 
    aktivan: new FormControl(true), 
    prezime: new FormControl(''), 
  });

  constructor(
    private korisniciService: Korisniciservice,
    private dialogRef: MatDialogRef<KorisniciDialog>
  ){

  }

ngOnInit() {     
      
    }
    sacuvaj() {     
      console.log(this.forma.value);     
      this.korisniciService.dodajKorisnika(this.forma.value)
      .subscribe({         
        next: data => {           
          console.log('Korisnik dodat', data);           
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