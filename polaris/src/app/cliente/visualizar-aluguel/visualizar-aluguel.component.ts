import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services';
import { LoginService } from 'src/app/auth';
import { GerenteService } from 'src/app/gerente/services';

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
  selector: 'app-visualizar-aluguel',
  templateUrl: './visualizar-aluguel.component.html',
  styleUrls: ['./visualizar-aluguel.component.scss']
})
export class VisualizarAluguelComponent implements OnInit {
  public aluguelData: any;
  public estadoAluguel = EstadoAluguel;
  public cpf!: string;
  public loginUuid!: string;

  constructor( private clienteService: ClienteService, private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.loginUuid = localStorage.getItem("loginUuid") as string;
    this.getClienteById();
  }

  getClienteById() {
    this.gerenteService.getClienteByIdLogin(this.loginUuid).subscribe( res => {
        this.cpf = res.cpf;
      }      
    );
    this.getAllAlugueis();
  }
  
  getAllAlugueis() {
    this.clienteService.getAlugueisByCPFClient(this.cpf).subscribe( (res: any) => {
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
