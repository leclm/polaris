import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-historico-aluguel-conteiner',
  templateUrl: './visualizar-historico-aluguel-conteiner.component.html',
  styleUrls: ['./visualizar-historico-aluguel-conteiner.component.scss']
})
export class VisualizarHistoricoAluguelConteinerComponent implements OnInit {
  public conteinerUuid: any;
  public conteineresData: any;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.conteinerUuid = this.activatedRoute.snapshot.params['id'];
    
    this.gerenteService.getAllConteineresAtivos().subscribe( (res: any) => {
        this.conteineresData = res;
      }
    );
  }

}
