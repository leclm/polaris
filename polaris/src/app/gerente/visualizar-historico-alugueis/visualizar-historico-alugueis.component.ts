import { Component, OnInit } from '@angular/core';
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
  selector: 'app-visualizar-historico-alugueis',
  templateUrl: './visualizar-historico-alugueis.component.html',
  styleUrls: ['./visualizar-historico-alugueis.component.scss']
})
export class VisualizarHistoricoAlugueisComponent implements OnInit {
  public aluguelData: any;
  public estadoAluguel = EstadoAluguel;

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.getAllAlugueis();
  }

  getAllAlugueis() {
    this.gerenteService.getAllAlugueis().subscribe( (res: any) => {
      this.aluguelData = res;
      this.getEstadoText(this.aluguelData);
    })
  };

  getEstadoText(data: any) {
    for (const element of data) {
      let estado = element.estadoAluguel;
      let estadoText = EstadoAluguel[estado]
      element.estadoAluguel = estadoText;
    }
  };
}
