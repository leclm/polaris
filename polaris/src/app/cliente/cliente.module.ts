import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteService } from './services/cliente.service';
import { VisualizarAluguelComponent } from './visualizar-aluguel/visualizar-aluguel.component';
import { DetalhesAluguelComponent } from './detalhes-aluguel/detalhes-aluguel.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgxPayPalModule } from 'ngx-paypal';
import { CepPipe, CpfPipe, PhonePipe } from '../shared/pipes';

import { NgxMaskModule, IConfig } from 'ngx-mask'
export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};
import { CurrencyMaskModule } from "ng2-currency-mask";


@NgModule({
  declarations: [
    VisualizarAluguelComponent,
    DetalhesAluguelComponent,
    CpfPipe,
    CepPipe,
    PhonePipe
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    NgxPayPalModule,
    NgxMaskModule.forRoot(), 
    CurrencyMaskModule
  ],
  providers: [
    ClienteService
  ]
})

export class ClienteModule { }
