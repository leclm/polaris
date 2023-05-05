import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GerenteService } from '../services';

enum EstadoPrestacaoServico {
  Cancelado = 0,
  Finalizado = 1,
  "Em Andamento" = 2
};

@Component({
  selector: 'app-visualizar-historico-prestacao-servico',
  templateUrl: './visualizar-historico-prestacao-servico.component.html',
  styleUrls: ['./visualizar-historico-prestacao-servico.component.scss']
})

export class VisualizarHistoricoPrestacaoServicoComponent implements OnInit {
  public conteinerUuid: any;
  public conteineresData: any;
  public prestacaoServicosData: any;
  public estadoPrestacaoServico = EstadoPrestacaoServico;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.conteinerUuid = this.activatedRoute.snapshot.params['id'];
    
    this.gerenteService.getAllConteineresAtivos().subscribe( (res: any) => {
        this.conteineresData = res;
      }
    );

    this.gerenteService.getPrestacaoServicoById(this.conteinerUuid).subscribe( (res: any) => {
        this.prestacaoServicosData = res;
        this.getEstadoText(this.prestacaoServicosData);
      }
    );
  }

  getEstadoText(data: any) {
    for (const element of data) {
      let estado = element.estadoPrestacaoServico;
      let estadoText = EstadoPrestacaoServico[estado]
      element.estadoPrestacaoServico = estadoText;
    }
  };
}
