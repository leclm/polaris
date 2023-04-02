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
    VisualizarHistoricoTerceirizadoComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class GerenteModule { }
