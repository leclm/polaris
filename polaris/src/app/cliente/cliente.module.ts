import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteService } from './services/cliente.service';
import { VisualizarAluguelComponent } from './visualizar-aluguel/visualizar-aluguel.component';
import { DetalhesAluguelComponent } from './detalhes-aluguel/detalhes-aluguel.component';
import { RouterModule } from '@angular/router';
import { NgxPayPalModule } from 'ngx-paypal';

@NgModule({
  declarations: [
    VisualizarAluguelComponent,
    DetalhesAluguelComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    NgxPayPalModule
  ],
  providers: [
    ClienteService
  ]
})

export class ClienteModule { }
