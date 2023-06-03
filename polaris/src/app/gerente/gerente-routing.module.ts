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
import { VisualizarHistoricoAlugueisComponent } from './visualizar-historico-alugueis';
import { EditarEstadoAluguelComponent } from './editar-estado-aluguel';
import { VisualizarDetalhesAluguelComponent } from './visualizar-detalhes-aluguel';
import { VisualizarHistoricoClienteComponent } from './visualizar-historico-cliente/visualizar-historico-cliente.component';
import { AuthGuard } from '../auth/auth.guard';

export const GerenteRoutes: Routes = [
  // Dashboard
  {
    path: 'gerente/dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  // Cliente
  {
    path: 'gerente/manter-cliente',
    component: ManterClienteComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/editar-cliente/:id',
    component: EditarClienteComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-clientes',
    component: VisualizarClientesComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-detalhes-cliente/:id',
    component: VisualizarDetalhesClienteComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-historico-cliente/:id',
    component: VisualizarHistoricoClienteComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  // Terceirizado
  {
    path: 'gerente/manter-terceirizado',
    component: ManterTerceirizadoComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/editar-terceirizado/:id',
    component: EditarTerceirizadoComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-terceirizados',
    component: VisualizarTerceirizadosComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-detalhes-terceirizado/:id',
    component: VisualizarDetalhesTerceirizadoComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-historico-terceirizado/:id',
    component: VisualizarHistoricoTerceirizadoComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  // Serviços Prestados pelos Terceirizados
  {
    path: 'gerente/manter-servico',
    component: ManterServicoComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/editar-servico/:id',
    component: EditarServicoComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-servicos',
    component: VisualizarServicosComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  // Categoria de Contêiner
  {
    path: 'gerente/manter-categoria',
    component: ManterCategoriaComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-categorias',
    component: VisualizarCategoriasComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/editar-categoria/:id',
    component: EditarCategoriaComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  // Tipo de Contêiner
  {
    path: 'gerente/manter-tipo',
    component: ManterTipoComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/editar-tipo/:id',
    component: EditarTipoComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-tipos',
    component: VisualizarTiposComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  // Contêiner
  {
    path: 'gerente/visualizar-estoque-conteineres',
    component: VisualizarEstoqueConteineresComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-conteiner/:id',
    component: VisualizarConteinerComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/manter-conteiner',
    component: ManterConteinerComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/editar-conteiner/:id',
    component: EditarConteinerComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/editar-disponibilidade-conteiner/:id',
    component: EditarDisponibilidadeConteinerComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-historico-prestacao-servico/:id',
    component: VisualizarHistoricoPrestacaoServicoComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-historico-aluguel-conteiner/:id',
    component: VisualizarHistoricoAluguelConteinerComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/manter-prestacao-servico/:id',
    component: ManterPrestacaoServicoComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/editar-prestacao-servico/:id',
    component: EditarPrestacaoServicoComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  // Aluguel
  {
    path: 'gerente/manter-aluguel',
    component: ManterAluguelComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-historico-alugueis',
    component: VisualizarHistoricoAlugueisComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/editar-estado-aluguel/:id',
    component: EditarEstadoAluguelComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  },
  {
    path: 'gerente/visualizar-detalhes-aluguel/:id',
    component: VisualizarDetalhesAluguelComponent,
    canActivate: [AuthGuard],
      data: {
        role: 'gerente'
      }
  }
];
