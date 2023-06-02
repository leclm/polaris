import { Routes } from '@angular/router';
import { AlterarSenhaComponent } from './alterar-senha';
import { DetalhesAluguelComponent } from './detalhes-aluguel';
import { VisualizarAluguelComponent } from './visualizar-aluguel';
import { AuthGuard } from '../auth/auth.guard';

export const ClienteRoutes: Routes = [
  {
    path: 'cliente',
    component: VisualizarAluguelComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'CLIENTE'
      }
  },
  {
    path: 'cliente/visualizar-aluguel',
    component: VisualizarAluguelComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'CLIENTE'
      }
  },
  {
    path: 'cliente/detalhes-aluguel/:id',
    component: DetalhesAluguelComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'CLIENTE'
      }
  },
  {
    path: 'cliente/alterar-senha',
    component: AlterarSenhaComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'CLIENTE'
      }
  }
];
