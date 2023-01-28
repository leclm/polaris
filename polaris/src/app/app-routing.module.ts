import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VisualizarAluguelComponent } from './cliente/visualizar-aluguel/visualizar-aluguel.component';

const routes: Routes = [
  { 
    path: '',
    redirectTo: 'cliente/visualizar-aluguel',
    pathMatch: 'full' 
  },
  { 
    path: 'cliente',
    redirectTo: 'cliente/visualizar-aluguel' 
  },
  { 
    path: 'cliente/visualizar-aluguel',
    component: VisualizarAluguelComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
