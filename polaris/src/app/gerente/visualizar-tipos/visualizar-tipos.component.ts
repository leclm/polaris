import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-visualizar-tipos',
  templateUrl: './visualizar-tipos.component.html',
  styleUrls: ['./visualizar-tipos.component.scss']
})
export class VisualizarTiposComponent implements OnInit {
  tipos = {
    content: [
      {
        'id': '1',
        'categoria': 'Construção Civil',
        'tipo': 'Pequeno',
        'largura': '2',
        'comprimento': '6',
        'altura':'3',
        'volume': '12',
        'pesoMaximo': '2000',
        'valorDiaria': '70',
        'valorMes': '400'
      },
      {
        'id': '2',
        'categoria': 'Construção Civil',
        'tipo': 'Pequeno',
        'largura': '2',
        'comprimento': '6',
        'altura':'3',
        'volume': '12',
        'pesoMaximo': '2000',
        'valorDiaria': '70',
        'valorMes': '400'
      },
      {
        'id': '3',
        'categoria': 'Construção Civil',
        'tipo': 'Pequeno',
        'largura': '2',
        'comprimento': '6',
        'altura':'3',
        'volume': '12',
        'pesoMaximo': '2000',
        'valorDiaria': '70',
        'valorMes': '400'
      },
      {
        'id': '4',
        'categoria': 'Construção Civil',
        'tipo': 'Pequeno',
        'largura': '2',
        'comprimento': '6',
        'altura':'3',
        'volume': '12',
        'pesoMaximo': '2000',
        'valorDiaria': '70',
        'valorMes': '400'
      }
    ]
  }
  constructor() { }

  ngOnInit(): void {
  }

}
