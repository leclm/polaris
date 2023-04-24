import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-categorias',
  templateUrl: './visualizar-categorias.component.html',
  styleUrls: ['./visualizar-categorias.component.scss']
})
export class VisualizarCategoriasComponent implements OnInit {
  public categoriaData: any;

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.gerenteService.getAllCategorias().subscribe( (res: any) => {
        this.categoriaData = res;
      }
    )
  }
}
