import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-tipos',
  templateUrl: './visualizar-tipos.component.html',
  styleUrls: ['./visualizar-tipos.component.scss']
})
export class VisualizarTiposComponent implements OnInit {
  public tipoData: any;

  constructor( private gerenteServiceAPI: GerenteService ) { }

  ngOnInit(): void {
    this.gerenteServiceAPI.getAllTipos().subscribe( (res: any) => {
        this.tipoData = res;
      }
    )
  }
}
