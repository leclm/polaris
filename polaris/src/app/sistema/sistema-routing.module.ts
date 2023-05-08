import { Routes } from '@angular/router';
import { PaginaInicialComponent } from './pagina-inicial';

export const SistemaRoutes: Routes = [
  {
    path: 'sistema',
    component: PaginaInicialComponent
  },
  {
    path: 'sistema/pagina-inicial',
    component: PaginaInicialComponent
  }
];
