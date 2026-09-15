import { HttpClient } from '@angular/common/http';
import { Injectable, Service } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class Projektiservice {
    constructor(private http: HttpClient) {}
    getProjekti() {   return this.http.get('http://localhost:5184/Projekti'); }
    dodajProjekat(projekat:any) { return this.http.post('http://localhost:5184/Projekti', projekat);}
    obrisiProjekat(id:number){return this.http.delete(`http://localhost:5184/Projekti/${id}`);}
    getAktivniProjekti(){return this.http.get('http://localhost:5184/Projekti/GetAktivniProjekti');}
}
