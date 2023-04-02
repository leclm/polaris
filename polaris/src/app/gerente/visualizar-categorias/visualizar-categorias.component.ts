import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-visualizar-categorias',
  templateUrl: './visualizar-categorias.component.html',
  styleUrls: ['./visualizar-categorias.component.scss']
})
export class VisualizarCategoriasComponent implements OnInit {
  categorias = {
    content: [
      {
        'id': '1',
        'nome': 'Construção Civil'
      },
      {
        'id': '2',
        'nome': 'Moradia'
      },
      {
        'id': '3',
        'nome': 'Comércio'
      },
      {
        'id': '4',
        'nome': 'Banheiro'
      }
    ]
  }

  constructor() { }

  ngOnInit(): void {
  }

}
