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
import { VisualizarHistoricoTerceirizadoComponent } from './visualizar-historico-terceirizado';
import { VisualizarTerceirizadosComponent } from './visualizar-terceirizados';
import { VisualizarTiposComponent } from './visualizar-tipos';
import { VisualizarEstoqueConteineresComponent } from './visualizar-estoque-conteineres';
import { VisualizarConteinerComponent } from './visualizar-conteiner';
import { ManterConteinerComponent } from './manter-conteiner';
import { EditarConteinerComponent } from './editar-conteiner';
import { ManterServicoComponent } from './manter-servico';
import { VisualizarServicosComponent } from './visualizar-servicos';
import { EditarServicoComponent } from './editar-servico';
import { VisualizarHistoricoPrestacaoServicoComponent } from './visualizar-historico-prestacao-servico';
import { VisualizarHistoricoAluguelConteinerComponent } from './visualizar-historico-aluguel-conteiner';
import { ManterPrestacaoServicoComponent } from './manter-prestacao-servico/manter-prestacao-servico.component';
import { EditarPrestacaoServicoComponent } from './editar-prestacao-servico';
import { EditarDisponibilidadeConteinerComponent } from './editar-disponibilidade-conteiner';
import { DashboardComponent } from './dashboard';
import { ManterAluguelComponent } from './manter-aluguel';

export const GerenteRoutes: Routes = [
  // Dashboard
  {
    path: 'gerente/dashboard',
    component: DashboardComponent
  },
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
  // Serviços Prestados pelos Terceirizados
  {
    path: 'gerente/manter-servico',
    component: ManterServicoComponent
  },
  {
    path: 'gerente/editar-servico/:id',
    component: EditarServicoComponent
  },
  {
    path: 'gerente/visualizar-servicos',
    component: VisualizarServicosComponent
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
  },
  // Contêiner
  {
    path: 'gerente/visualizar-estoque-conteineres',
    component: VisualizarEstoqueConteineresComponent
  },
  {
    path: 'gerente/visualizar-conteiner/:id',
    component: VisualizarConteinerComponent
  },
  {
    path: 'gerente/manter-conteiner',
    component: ManterConteinerComponent
  },
  {
    path: 'gerente/editar-conteiner/:id',
    component: EditarConteinerComponent
  },
  {
    path: 'gerente/editar-disponibilidade-conteiner/:id',
    component: EditarDisponibilidadeConteinerComponent
  },
  {
    path: 'gerente/visualizar-historico-prestacao-servico/:id',
    component: VisualizarHistoricoPrestacaoServicoComponent
  },
  {
    path: 'gerente/visualizar-historico-aluguel-conteiner/:id',
    component: VisualizarHistoricoAluguelConteinerComponent
  },
  {
    path: 'gerente/manter-prestacao-servico/:id',
    component: ManterPrestacaoServicoComponent
  },
  {
    path: 'gerente/editar-prestacao-servico/:id',
    component: EditarPrestacaoServicoComponent
  },
  // Aluguel
  {
    path: 'gerente/manter-aluguel',
    component: ManterAluguelComponent
  }
];
