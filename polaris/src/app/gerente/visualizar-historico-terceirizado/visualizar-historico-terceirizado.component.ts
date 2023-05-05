import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-visualizar-historico-terceirizado',
  templateUrl: './visualizar-historico-terceirizado.component.html',
  styleUrls: ['./visualizar-historico-terceirizado.component.scss']
})
export class VisualizarHistoricoTerceirizadoComponent implements OnInit {
  public terceirizadoUuid: any;
  public prestacaoServicoData: any;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.terceirizadoUuid = this.activatedRoute.snapshot.params['id'];
    this.getAllPrestacaoServicos();
    
  }

  getAllPrestacaoServicos() {
    this.gerenteService.getAllPrestacaoServicos().subscribe( (res: any) => {
        this.prestacaoServicoData = res;
        console.log(this.prestacaoServicoData)
      }
    )
  }
}
