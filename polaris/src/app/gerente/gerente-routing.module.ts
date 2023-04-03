import { Routes } from '@angular/router';
import { EditarCategoriaComponent } from './editar-categoria';
import { EditarClienteComponent } from './editar-cliente';
import { EditarTerceirizadoComponent } from './editar-terceirizado';
import { EditarTipoComponent } from './editar-tipo';
import { ManterCategoriaComponent } from './manter-categoria';
import { ManterClienteComponent } from './manter-cliente';
import { ManterTerceirizadoComponent } from './manter-terceirizado';
import { ManterTipoComponent } from './manter-tipo';
import { VisualizarCategoriasComponent } from './visualizar-categorias';
import { VisualizarClientesComponent } from './visualizar-clientes';
import { VisualizarDetalhesClienteComponent } from './visualizar-detalhes-cliente';
import { VisualizarDetalhesTerceirizadoComponent } from './visualizar-detalhes-terceirizado';
import { VisualizarHistoricoTerceirizadoComponent } from './visualizar-historico-terceirizado/visualizar-historico-terceirizado.component';
import { VisualizarTerceirizadosComponent } from './visualizar-terceirizados';
import { VisualizarTiposComponent } from './visualizar-tipos';

export const GerenteRoutes: Routes = [
  // Cliente
  {
    path: 'gerente/manter-cliente',
    component: ManterClienteComponent
  },
  {
    path: 'gerente/editar-cliente/:id',
    component: EditarClienteComponent
  },
  {
    path: 'gerente/visualizar-clientes',
    component: VisualizarClientesComponent
  },
  {
    path: 'gerente/visualizar-detalhes-cliente/:id',
    component: VisualizarDetalhesClienteComponent
  },
  // Terceirizado
  {
    path: 'gerente/manter-terceirizado',
    component: ManterTerceirizadoComponent
  },
  {
    path: 'gerente/editar-terceirizado/:id',
    component: EditarTerceirizadoComponent
  },
  {
    path: 'gerente/visualizar-terceirizados',
    component: VisualizarTerceirizadosComponent
  },
  {
    path: 'gerente/visualizar-detalhes-terceirizado/:id',
    component: VisualizarDetalhesTerceirizadoComponent
  },
  {
    path: 'gerente/visualizar-historico-terceirizado/:id',
    component: VisualizarHistoricoTerceirizadoComponent
  },
  // Categoria de Contêiner
  {
    path: 'gerente/manter-categoria',
    component: ManterCategoriaComponent
  },
  {
    path: 'gerente/visualizar-categorias',
    component: VisualizarCategoriasComponent
  },
  {
    path: 'gerente/editar-categoria/:id',
    component: EditarCategoriaComponent
  },
  // Tipo de Contêiner
  {
    path: 'gerente/manter-tipo',
    component: ManterTipoComponent
  },
  {
    path: 'gerente/editar-tipo/:id',
    component: EditarTipoComponent
  },
  {
    path: 'gerente/visualizar-tipos',
    component: VisualizarTiposComponent
  }
];
