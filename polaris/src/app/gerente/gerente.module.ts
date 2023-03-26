import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManterClienteComponent } from './manter-cliente/manter-cliente.component';
import { VisualizarDetalhesClienteComponent } from './visualizar-detalhes-cliente/visualizar-detalhes-cliente.component';
import { VisualizarClientesComponent } from './visualizar-clientes/visualizar-clientes.component';
import { ManterTerceirizadoComponent } from './manter-terceirizado/manter-terceirizado.component';

@NgModule({
  declarations: [
    ManterClienteComponent,
    VisualizarDetalhesClienteComponent,
    VisualizarClientesComponent,
    ManterTerceirizadoComponent
  ],
  imports: [
    CommonModule
  ]
})
export class GerenteModule { }
