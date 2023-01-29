import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteService } from './services/cliente.service';
import { VisualizarAluguelComponent } from './visualizar-aluguel/visualizar-aluguel.component';
import { DetalhesAluguelComponent } from './detalhes-aluguel/detalhes-aluguel.component';

@NgModule({
  declarations: [
    VisualizarAluguelComponent,
    DetalhesAluguelComponent
  ],
  imports: [
    CommonModule
  ],
  providers: [
    ClienteService
  ]
})

export class ClienteModule { }
