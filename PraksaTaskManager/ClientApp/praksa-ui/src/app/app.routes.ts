import { Routes } from '@angular/router';
import { Zadaci } from './pages/zadaci/zadaci';
import { Home } from './pages/home/home';
import { Dashboard } from './pages/dashboard/dashboard';
import { Projekti } from './pages/projekti/projekti';
import { Korisnici } from './pages/korisnici/korisnici';

export const routes: Routes = [  
    {     path: '', redirectTo:'dashboard', pathMatch:'full'  },
    {     path: 'zadaci',     component: Zadaci  },
    {path:'home', component:Home},
{path:'dashboard', component:Dashboard},
{path:'projekti', component:Projekti},
{path:'korisnici', component:Korisnici}
 ];

