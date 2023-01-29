import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VisualizarAluguelComponent } from './cliente/visualizar-aluguel/visualizar-aluguel.component';
import { DetalhesAluguelComponent } from './cliente/detalhes-aluguel/detalhes-aluguel.component';

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
    component: VisualizarAluguelComponent 
  },
  { 
    path: 'cliente/detalhes-aluguel',
    component: DetalhesAluguelComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
