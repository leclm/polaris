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
    this.loadData();
  }

  loadData() {
    this.gerenteService.getAllCategoriasAtivas().subscribe( (res: any) => { this.categoriaData = res; });
  };

  didTapOnDelete(uuid: string) {
    this.gerenteService.deleteCategoria(uuid).subscribe(
      response => this.loadData(),
      error => console.error(error)
    )
  };
}
