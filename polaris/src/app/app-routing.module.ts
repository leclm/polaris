import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteRoutes } from './cliente/cliente-routing.module';

const routes: Routes = [
  { 
    path: '',
    redirectTo: 'cliente',
    pathMatch: 'full' 
  },
  ...ClienteRoutes
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
