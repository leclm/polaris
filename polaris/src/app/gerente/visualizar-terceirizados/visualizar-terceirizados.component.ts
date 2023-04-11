import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-terceirizados',
  templateUrl: './visualizar-terceirizados.component.html',
  styleUrls: ['./visualizar-terceirizados.component.scss']
})
export class VisualizarTerceirizadosComponent implements OnInit {
  clienteData = {
    content: [
      {
        'id': '1',
        'tipo': 'Limpeza',
        'empresa': 'Lava Contêiner S.A.',
        'telefone': '(41) 9 9999-9999',
        'cnpj': '00.394.460/0001-87',
        'endereco': 'Rua Bruno Filgueira'
      },
      {
        'id': '2',
        'tipo': 'Frete',
        'empresa': 'Frete Total',
        'telefone': '(41) 9 8888-8888',
        'cnpj': '00.394.460/0001-87',
        'endereco': 'Rua Saldanha Marinho'
      }   
    ]
  }

  public servicoData: any;
  public terceirizadoData: any;

  constructor( private _gerenteServiceAPI: GerenteService ) { }

  ngOnInit(): void {
    this._gerenteServiceAPI.getServicoData().subscribe( (res: any) => {
        this.servicoData = res;
      }
    )

    this._gerenteServiceAPI.getTerceirizadoData().subscribe( (res: any) => {
      this.terceirizadoData = res;
    }
  )
  }

}
