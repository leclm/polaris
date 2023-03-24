import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManterClienteComponent } from './manter-cliente/manter-cliente.component';
import { VisualizarDetalhesClienteComponent } from './visualizar-detalhes-cliente/visualizar-detalhes-cliente.component';



@NgModule({
  declarations: [
    ManterClienteComponent,
    VisualizarDetalhesClienteComponent
  ],
  imports: [
    CommonModule
  ]
})
export class GerenteModule { }
