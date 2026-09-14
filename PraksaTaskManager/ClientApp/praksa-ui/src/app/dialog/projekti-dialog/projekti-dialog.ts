import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Projektiservice } from '../../services/projektiservice';


@Component({
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatButtonModule, MatDialogModule, MatCheckboxModule],
  selector: 'app-projekti-dialog',
  styleUrl: './projekti-dialog.scss',
  templateUrl: './projekti-dialog.html',
})
export class ProjektiDialog {
  forma = new FormGroup({ 
    naziv: new FormControl(''), 
    opis: new FormControl(''), 
    aktivan: new FormControl(true), 
  });

  constructor(
    private projektiService: Projektiservice,
    private dialogRef: MatDialogRef<ProjektiDialog>
  ){

  }

ngOnInit() {     
      
    }
    sacuvaj() {     
      console.log(this.forma.value);     
      this.projektiService.dodajProjekat(this.forma.value)
      .subscribe({         
        next: data => {           
          console.log('Projekat dodat', data);           
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