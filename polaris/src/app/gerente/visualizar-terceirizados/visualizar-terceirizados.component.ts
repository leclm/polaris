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

  constructor( private gerenteServiceAPI: GerenteService ) { }

  ngOnInit(): void {
    this.gerenteServiceAPI.getAllServicos().subscribe( (res: any) => {
        this.servicoData = res;
      }
    )

    this.gerenteServiceAPI.getAllTerceirizadosAtivos().subscribe( (res: any) => {
        this.terceirizadoData = res;
      }
    )
  }
}
