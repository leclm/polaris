import { RouterModule, Routes } from '@angular/router';
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
  }
];
