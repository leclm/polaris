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
  selector: 'app-visualizar-historico-cliente',
  templateUrl: './visualizar-historico-cliente.component.html',
  styleUrls: ['./visualizar-historico-cliente.component.scss']
})
export class VisualizarHistoricoClienteComponent implements OnInit {
  public clienteCPF: any;
  public clienteAluguelData: any;
  public estadoAluguel = EstadoAluguel;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.clienteCPF = this.activatedRoute.snapshot.params['id'];
    this.getAlugueisByCPFClient();
  }

  getAlugueisByCPFClient() {
    this.gerenteService.getAlugueisByCPFClient(this.clienteCPF).subscribe( (res: any) => {
        this.clienteAluguelData = res;
        this.getEstadoText(this.clienteAluguelData);
        console.log(this.clienteAluguelData);
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
