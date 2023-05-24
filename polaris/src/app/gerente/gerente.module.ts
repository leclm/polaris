import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManterClienteComponent } from './manter-cliente/manter-cliente.component';
import { VisualizarDetalhesClienteComponent } from './visualizar-detalhes-cliente/visualizar-detalhes-cliente.component';
import { VisualizarClientesComponent } from './visualizar-clientes/visualizar-clientes.component';
import { ManterTerceirizadoComponent } from './manter-terceirizado/manter-terceirizado.component';
import { VisualizarTerceirizadosComponent } from './visualizar-terceirizados/visualizar-terceirizados.component';
import { VisualizarDetalhesTerceirizadoComponent } from './visualizar-detalhes-terceirizado/visualizar-detalhes-terceirizado.component';
import { SortDirective } from '../shared/directives/sort.directive';
import { EditarTerceirizadoComponent } from './editar-terceirizado/editar-terceirizado.component';
import { EditarClienteComponent } from './editar-cliente/editar-cliente.component';
import { VisualizarHistoricoTerceirizadoComponent } from './visualizar-historico-terceirizado/visualizar-historico-terceirizado.component';
import { FormsModule } from '@angular/forms';
import { ManterCategoriaComponent } from './manter-categoria/manter-categoria.component';
import { VisualizarCategoriasComponent } from './visualizar-categorias/visualizar-categorias.component';
import { EditarCategoriaComponent } from './editar-categoria/editar-categoria.component';
import { ManterTipoComponent } from './manter-tipo/manter-tipo.component';
import { EditarTipoComponent } from './editar-tipo/editar-tipo.component';
import { VisualizarTiposComponent } from './visualizar-tipos/visualizar-tipos.component';
import { RouterModule } from '@angular/router';
import { GerenteService } from './services';
import { VisualizarEstoqueConteineresComponent } from './visualizar-estoque-conteineres/visualizar-estoque-conteineres.component';
import { VisualizarConteinerComponent } from './visualizar-conteiner/visualizar-conteiner.component';
import { ManterConteinerComponent } from './manter-conteiner/manter-conteiner.component';
import { EditarConteinerComponent } from './editar-conteiner/editar-conteiner.component';
import { ManterServicoComponent } from './manter-servico/manter-servico.component';
import { VisualizarServicosComponent } from './visualizar-servicos/visualizar-servicos.component';
import { EditarServicoComponent } from './editar-servico/editar-servico.component';
import { VisualizarHistoricoPrestacaoServicoComponent } from './visualizar-historico-prestacao-servico/visualizar-historico-prestacao-servico.component';
import { VisualizarHistoricoAluguelConteinerComponent } from './visualizar-historico-aluguel-conteiner/visualizar-historico-aluguel-conteiner.component';
import { ManterPrestacaoServicoComponent } from './manter-prestacao-servico/manter-prestacao-servico.component';
import { EditarPrestacaoServicoComponent } from './editar-prestacao-servico/editar-prestacao-servico.component';
import { EditarDisponibilidadeConteinerComponent } from './editar-disponibilidade-conteiner/editar-disponibilidade-conteiner.component';
import { NgbCarouselModule } from '@ng-bootstrap/ng-bootstrap';
import { CapitalizacaoGerentePipe, CpfGerentePipe, DateGerentePipe, PhoneGerentePipe } from '../shared';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NgbPaginationModule, NgbAlertModule, NgbDate, NgbModule, NgbDatepickerModule, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { VisualizarHistoricoAlugueisComponent } from './visualizar-historico-alugueis/visualizar-historico-alugueis.component';
import { EditarEstadoAluguelComponent } from './editar-estado-aluguel/editar-estado-aluguel.component';
import { VisualizarDetalhesAluguelComponent } from './visualizar-detalhes-aluguel/visualizar-detalhes-aluguel.component';
import { ManterAluguelComponent } from './manter-aluguel/manter-aluguel.component';
import { CurrencyMaskModule } from "ng2-currency-mask";
import { NgxMaskModule, IConfig } from 'ngx-mask';

@NgModule({
  declarations: [
    ManterClienteComponent,
    VisualizarDetalhesClienteComponent,
    VisualizarClientesComponent,
    ManterTerceirizadoComponent,
    VisualizarTerceirizadosComponent,
    VisualizarDetalhesTerceirizadoComponent,
    SortDirective,
    EditarTerceirizadoComponent,
    EditarClienteComponent,
    VisualizarHistoricoTerceirizadoComponent,
    ManterCategoriaComponent,
    VisualizarCategoriasComponent,
    EditarCategoriaComponent,
    ManterTipoComponent,
    EditarTipoComponent,
    VisualizarTiposComponent,
    VisualizarEstoqueConteineresComponent,
    VisualizarConteinerComponent,
    ManterConteinerComponent,
    EditarConteinerComponent,
    ManterServicoComponent,
    VisualizarServicosComponent,
    EditarServicoComponent,
    VisualizarHistoricoPrestacaoServicoComponent,
    VisualizarHistoricoAluguelConteinerComponent,
    ManterPrestacaoServicoComponent,
    EditarPrestacaoServicoComponent,
    EditarDisponibilidadeConteinerComponent,
    CapitalizacaoGerentePipe,
    PhoneGerentePipe,
    CpfGerentePipe,
    DateGerentePipe,
    DashboardComponent,
    ManterAluguelComponent,
    VisualizarHistoricoAlugueisComponent,
    EditarEstadoAluguelComponent,
    VisualizarDetalhesAluguelComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    NgbCarouselModule,
    NgbCarouselModule,
    NgxMaskModule.forRoot(),
    CurrencyMaskModule,
    NgbPaginationModule, 
    NgbAlertModule,
    NgbModule,
    NgbDatepickerModule, 
  ],
  providers: [
    GerenteService
  ]
})
export class GerenteModule { }
