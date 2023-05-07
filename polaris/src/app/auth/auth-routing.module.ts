import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';

export const AuthRoutes: Routes = [
  {
    path: 'auth/login',
    component: LoginComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  { 
    path: '', redirectTo: '/login', pathMatch: 'full' 
  }
];