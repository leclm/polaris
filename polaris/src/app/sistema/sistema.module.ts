import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginaInicialComponent } from './pagina-inicial/pagina-inicial.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    PaginaInicialComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class SistemaModule { }
