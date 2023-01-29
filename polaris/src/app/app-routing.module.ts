import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthRoutes } from './auth/auth-routing.module';
import { ClienteRoutes } from './cliente/cliente-routing.module';

const routes: Routes = [
  { 
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  ...ClienteRoutes,
  ...AuthRoutes
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
