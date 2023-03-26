import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-detalhes-cliente',
  templateUrl: './visualizar-detalhes-cliente.component.html',
  styleUrls: ['./visualizar-detalhes-cliente.component.scss']
})
export class VisualizarDetalhesClienteComponent implements OnInit {
  //public clienteData: any;
  public clienteId: any;

  constructor( private _gerenteServiceAPI: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.clienteId = this.activatedRoute.snapshot.params['id'];
    
    /*this._gerenteServiceAPI.getClienteData().subscribe( (res: any) => {
        this.clienteData = res;
      }
    )*/
  }
}
