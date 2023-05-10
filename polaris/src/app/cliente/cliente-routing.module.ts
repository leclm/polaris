import { Routes } from '@angular/router';
import { AlterarSenhaComponent } from './alterar-senha';
import { DetalhesAluguelComponent } from './detalhes-aluguel';
import { VisualizarAluguelComponent } from './visualizar-aluguel';
import { VisualizarHistoricoClienteComponent } from './visualizar-historico-cliente';

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
  },
  {
    path: 'cliente/visualizar-historico-cliente/:id',
    component: VisualizarHistoricoClienteComponent
  }
];
