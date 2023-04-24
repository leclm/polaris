import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-estoque-conteineres',
  templateUrl: './visualizar-estoque-conteineres.component.html',
  styleUrls: ['./visualizar-estoque-conteineres.component.scss']
})
export class VisualizarEstoqueConteineresComponent implements OnInit {
  public conteinerData: any;

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.gerenteService.getAllConteineres().subscribe( (res: any) => {
        this.conteinerData = res;
      }
    )
  }
}
