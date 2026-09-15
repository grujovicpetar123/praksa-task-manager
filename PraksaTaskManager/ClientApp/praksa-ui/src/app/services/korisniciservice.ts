import { HttpClient } from '@angular/common/http';
import { Injectable, Service } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class Korisniciservice {
     constructor(private http: HttpClient) {}
    getKorisnici() {   return this.http.get('http://localhost:5184/Korisnici'); }
    dodajKorisnika(korisnik:any) { return this.http.post('http://localhost:5184/Korisnici', korisnik);}
    obrisiKorisnika(id:number){return this.http.delete(`http://localhost:5184/Korisnici/${id}`);}
    getAktivniKorisnici(){return this.http.get('http://localhost:5184/Korisnici/GetAktivniKorisnici');}
    getKorisniciPoPrezimenu(){return this.http.get('http://localhost:5184/Korisnici/KorisniciPoPrezimenu'); }
    getBrojZadatakaPoKorisniku(){return this.http.post('http://localhost:5184/Korisnici/BrojZadatakPoKorisniku',{});}
    getBrojKomentaraPoKorisniku(){return this.http.post('http://localhost:5184/Korisnici/BrojKomentaraPoKorisniku',{});}
}
