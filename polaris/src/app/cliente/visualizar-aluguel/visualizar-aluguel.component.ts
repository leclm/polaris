import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services';
@Component({
  selector: 'app-visualizar-aluguel',
  templateUrl: './visualizar-aluguel.component.html',
  styleUrls: ['./visualizar-aluguel.component.scss']
})
export class VisualizarAluguelComponent implements OnInit {
  public authData: any;
  public aluguelData: any;

  constructor( private _clienteServiceAPI: ClienteService ) { }

  ngOnInit(): void {
    this._clienteServiceAPI.getAuthData().subscribe( (res: any) => {
        this.authData = res;
      }
    )

    this._clienteServiceAPI.getAluguelData().subscribe( (res: any) => {
        this.aluguelData = res;
      }
    )
  }
}
