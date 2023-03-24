import { Routes } from '@angular/router';
import { ManterClienteComponent } from './manter-cliente';
import { VisualizarDetalhesClienteComponent } from './visualizar-detalhes-cliente';

export const GerenteRoutes: Routes = [
  {
    path: 'gerente/manter-cliente',
    component: ManterClienteComponent
  },
  {
    path: 'gerente/visualizar-detalhes-cliente',
    component: VisualizarDetalhesClienteComponent
  }
  
  /*{
    path: 'gerente/editar-cliente/:id',
    component: EditarClienteComponent
  }*/
];
