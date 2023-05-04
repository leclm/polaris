import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginaInicialComponent } from './pagina-inicial/pagina-inicial.component';
import { RouterModule } from '@angular/router';
import { SolicitarContatoComponent } from './solicitar-contato/solicitar-contato.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    PaginaInicialComponent,
    SolicitarContatoComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ]
})
export class SistemaModule { }