import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-visualizar-detalhes-terceirizado',
  templateUrl: './visualizar-detalhes-terceirizado.component.html',
  styleUrls: ['./visualizar-detalhes-terceirizado.component.scss']
})
export class VisualizarDetalhesTerceirizadoComponent implements OnInit {
  public terceirizadoUuid: any;
  public terceirizadoData: any;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.terceirizadoUuid = this.activatedRoute.snapshot.params['id'];
    
    this.gerenteService.getAllTerceirizados().subscribe( (res: any) => {
        this.terceirizadoData = res;
      }
    )
  }
}
