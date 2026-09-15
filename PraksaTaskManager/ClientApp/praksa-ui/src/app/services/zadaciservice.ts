import { HttpClient } from '@angular/common/http';
import { Injectable, Service } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class Zadaciservice {
    constructor(private http: HttpClient) {}
    getZadaci() {   return this.http.get('http://localhost:5184/Zadaci'); }
    getKorisnici() {   return this.http.get('http://localhost:5184/Korisnici'); }
    getProjekti() {   return this.http.get('http://localhost:5184/Projekti'); }
    getStatusi() {   return this.http.get('http://localhost:5184/Status'); }
    getPrioriteti() {   return this.http.get('http://localhost:5184/Prioriteti'); }
    dodajZadatak(zadatak:any) { return this.http.post('http://localhost:5184/Zadaci', zadatak);}
    obrisiZadatak(id:number){return this.http.delete(`http://localhost:5184/Zadaci/${id}`);}
    getZadaciRokNijeProsao(){return this.http.post(`http://localhost:5184/Zadaci/ZadaciKojimaRokNijeProsao`,{});}
    
}
