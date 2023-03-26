import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-clientes',
  templateUrl: './visualizar-clientes.component.html',
  styleUrls: ['./visualizar-clientes.component.scss']
})
export class VisualizarClientesComponent implements OnInit {
  //public clienteData: any;
  public aluguelData: any;

  clienteData = {
    content: [
      {
        'id': '1',
        'nome': 'Letícia das Chagas Lima ',
        'telefone': '(41) 9 9891-7792',
        'cpf': '07804144970',
        'dataDevolucao': '30/04/2023',
        'endereco': 'Rua Bruno Filgueira',
        'numero': '54',
        'cidade': 'Curitiba'
      },
      {
        'id': '2',
        'nome': 'Lucas das Chagas Lima ',
        'telefone': '(41) 9 8855-7465',
        'cpf': '15425478585',
        'dataDevolucao': '31/03/2023',
        'endereco': 'Rua Adir Dalabona',
        'numero': '111',
        'cidade': 'Curitiba'
      },
      {
        'id': '2',
        'nome': 'Lucas das Chagas Lima ',
        'telefone': '(41) 9 8855-7465',
        'cpf': '15425478585',
        'dataDevolucao': '31/03/2023',
        'endereco': 'Rua Adir Dalabona',
        'numero': '111',
        'cidade': 'Curitiba'
      },
      {
        'id': '2',
        'nome': 'Lucas das Chagas Lima ',
        'telefone': '(41) 9 8855-7465',
        'cpf': '15425478585',
        'dataDevolucao': '31/03/2023',
        'endereco': 'Rua Adir Dalabona',
        'numero': '111',
        'cidade': 'Curitiba'
      },
      {
        'id': '2',
        'nome': 'Lucas das Chagas Lima ',
        'telefone': '(41) 9 8855-7465',
        'cpf': '15425478585',
        'dataDevolucao': '31/03/2023',
        'endereco': 'Rua Adir Dalabona',
        'numero': '111',
        'cidade': 'Curitiba'
      },
      {
        'id': '2',
        'nome': 'Lucas das Chagas Lima ',
        'telefone': '(41) 9 8855-7465',
        'cpf': '15425478585',
        'dataDevolucao': '31/03/2023',
        'endereco': 'Rua Adir Dalabona',
        'numero': '111',
        'cidade': 'Curitiba'
      }      
    ]
  }

  constructor( private _gerenteServiceAPI: GerenteService ) { }

  ngOnInit(): void {
    this._gerenteServiceAPI.getClienteData().subscribe( (res: any) => {
        this.clienteData = res;
      }
    )

    this._gerenteServiceAPI.getAluguelData().subscribe( (res: any) => {
        this.aluguelData = res;
      }
    )
  }

}
