import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GerenteService } from '../services';

enum EstadoAluguel {
  Solicitado = 0,
  "Em Andamento" = 1,
  "Pagamento Atrasado" = 2,
  "Devolução Atrasada" = 3,
  Cancelado = 4,
  "Aguardando Retirada do Contêiner" = 5,
  Finalizado = 6
}
@Component({
  selector: 'app-visualizar-historico-aluguel-conteiner',
  templateUrl: './visualizar-historico-aluguel-conteiner.component.html',
  styleUrls: ['./visualizar-historico-aluguel-conteiner.component.scss']
})
export class VisualizarHistoricoAluguelConteinerComponent implements OnInit {
  public codigoConteiner: any;
  public conteinerAluguelData: any;
  public estadoAluguel = EstadoAluguel;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.codigoConteiner = this.activatedRoute.snapshot.params['id'];
    this.getAlugueisByConteiner();
  }

  getAlugueisByConteiner() {
    this.gerenteService.getAlugueisByConteiner(this.codigoConteiner).subscribe( (res: any) => {
        this.conteinerAluguelData = res;
        this.getEstadoText(this.conteinerAluguelData);
      }
    );
  }

  getEstadoText(data: any) {
    for (const element of data) {
      let estado = element.estadoAluguel;
      let estadoText = EstadoAluguel[estado]
      element.estadoAluguel = estadoText;
    }
  };
}
