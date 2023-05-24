import { Routes } from '@angular/router';
import { AlterarSenhaComponent } from './alterar-senha';
import { DetalhesAluguelComponent } from './detalhes-aluguel';
import { VisualizarAluguelComponent } from './visualizar-aluguel';

export const ClienteRoutes: Routes = [
  {
    path: 'cliente',
    component: VisualizarAluguelComponent
  },
  {
    path: 'cliente/visualizar-aluguel',
    component: VisualizarAluguelComponent
  },
  {
    path: 'cliente/detalhes-aluguel/:id',
    component: DetalhesAluguelComponent
  },
  {
    path: 'cliente/alterar-senha',
    component: AlterarSenhaComponent
  }
];
