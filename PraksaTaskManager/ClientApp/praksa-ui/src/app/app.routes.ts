import { Routes } from '@angular/router';
import { Zadaci } from './pages/zadaci/zadaci';
import { Home } from './pages/home/home';

export const routes: Routes = [   {     path: 'zadaci',     component: Zadaci  },
    {path:'home', component:Home}
 ];

