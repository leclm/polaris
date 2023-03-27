import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManterClienteComponent } from './manter-cliente/manter-cliente.component';
import { VisualizarDetalhesClienteComponent } from './visualizar-detalhes-cliente/visualizar-detalhes-cliente.component';
import { VisualizarClientesComponent } from './visualizar-clientes/visualizar-clientes.component';
import { ManterTerceirizadoComponent } from './manter-terceirizado/manter-terceirizado.component';
import { VisualizarTerceirizadosComponent } from './visualizar-terceirizados/visualizar-terceirizados.component';
import { VisualizarDetalhesTerceirizadoComponent } from './visualizar-detalhes-terceirizado/visualizar-detalhes-terceirizado.component';
import { SortDirective } from '../shared/directives/sort.directive';

@NgModule({
  declarations: [
    ManterClienteComponent,
    VisualizarDetalhesClienteComponent,
    VisualizarClientesComponent,
    ManterTerceirizadoComponent,
    VisualizarTerceirizadosComponent,
    VisualizarDetalhesTerceirizadoComponent,
    SortDirective
  ],
  imports: [
    CommonModule
  ]
})
export class GerenteModule { }
