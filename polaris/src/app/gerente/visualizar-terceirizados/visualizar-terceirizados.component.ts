import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-terceirizados',
  templateUrl: './visualizar-terceirizados.component.html',
  styleUrls: ['./visualizar-terceirizados.component.scss']
})
export class VisualizarTerceirizadosComponent implements OnInit {
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
