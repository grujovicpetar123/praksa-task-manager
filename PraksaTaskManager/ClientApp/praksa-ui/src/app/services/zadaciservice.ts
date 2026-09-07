import { HttpClient } from '@angular/common/http';
import { Injectable, Service } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class Zadaciservice {
    constructor(private http: HttpClient) {}
    getZadaci() {   return this.http.get('http://localhost:5184/Zadaci'); }
}
