import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-visualizar-historico-terceirizado',
  templateUrl: './visualizar-historico-terceirizado.component.html',
  styleUrls: ['./visualizar-historico-terceirizado.component.scss']
})
export class VisualizarHistoricoTerceirizadoComponent implements OnInit {
  historicoServicos = {
    content: [
      {
        'id': '1',
        'empresa': 'Lava Contêiner S.A.',
        'cnpj': '00.394.460/0001-87',
        'conteiner': 'Construção Civil - Grande - #324',
        'procedimento': 'Limpeza',
        'dataProcedimento': '05/02/2023'    
      },
      {
        'id': '2',
        'empresa': 'Lava Contêiner S.A.',
        'cnpj': '10.394.460/0001-87',
        'conteiner': 'Construção Civil - Pequeno - #178',
        'procedimento': 'Manutenção',
        'dataProcedimento': '07/02/2023'    
      },
      {
        'id': '3',
        'empresa': 'Lava Contêiner S.A.',
        'cnpj': '30.394.460/0001-87',
        'conteiner': 'Construção Civil - Médio - #34',
        'procedimento': 'Frete',
        'dataProcedimento': '10/02/2023'    
      },
      {
        'id': '4',
        'empresa': 'Lava Contêiner S.A.',
        'cnpj': '50.394.460/0001-87',
        'conteiner': 'Construção Civil - Grande - #24',
        'procedimento': 'Limpeza',
        'dataProcedimento': '15/02/2023'    
      }
    ]
  }
  constructor() { }

  ngOnInit(): void {
  }

}
