import { Routes } from '@angular/router';
import { PaginaInicialComponent } from './pagina-inicial';

export const SistemaRoutes: Routes = [
  // Sistema
  {
    path: 'sistema',
    component: PaginaInicialComponent
  },
  {
    path: 'sistema/pagina-inicial',
    component: PaginaInicialComponent
  }
];
