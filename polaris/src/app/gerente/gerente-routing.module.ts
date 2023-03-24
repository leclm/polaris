import { Routes } from '@angular/router';
import { ManterClienteComponent } from './manter-cliente';

export const GerenteRoutes: Routes = [
  {
    path: 'gerente/manter-cliente',
    component: ManterClienteComponent
  }
  
  /*{
    path: 'gerente/editar-cliente/:id',
    component: EditarClienteComponent
  }*/
];
