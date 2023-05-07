import { Routes } from '@angular/router';
import { PaginaInicialComponent } from './pagina-inicial';
import { SolicitarContatoComponent } from './solicitar-contato';

export const SistemaRoutes: Routes = [
  {
    path: 'sistema',
    component: PaginaInicialComponent
  },
  {
    path: 'sistema/pagina-inicial',
    component: PaginaInicialComponent
  },
  {
    path: 'sistema/solicitar-contato',
    component: SolicitarContatoComponent
  }
];
