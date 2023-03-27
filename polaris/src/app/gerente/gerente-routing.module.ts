import { Routes } from '@angular/router';
import { ManterClienteComponent } from './manter-cliente';
import { ManterTerceirizadoComponent } from './manter-terceirizado';
import { VisualizarClientesComponent } from './visualizar-clientes';
import { VisualizarDetalhesClienteComponent } from './visualizar-detalhes-cliente';
import { VisualizarTerceirizadosComponent } from './visualizar-terceirizados';

export const GerenteRoutes: Routes = [
  {
    path: 'gerente/manter-cliente',
    component: ManterClienteComponent
  },
  {
    path: 'gerente/visualizar-detalhes-cliente/:id',
    component: VisualizarDetalhesClienteComponent
  },
  {
    path: 'gerente/visualizar-clientes',
    component: VisualizarClientesComponent
  },
  {
    path: 'gerente/manter-terceirizado',
    component: ManterTerceirizadoComponent
  },
  {
    path: 'gerente/visualizar-terceirizados',
    component: VisualizarTerceirizadosComponent
  }
];
