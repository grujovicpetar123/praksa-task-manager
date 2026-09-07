import { HttpClient } from '@angular/common/http';
import { Injectable, Service } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class Korisniciservice {
     constructor(private http: HttpClient) {}
    getKorisnici() {   return this.http.get('http://localhost:5184/Korisnici'); }
}
