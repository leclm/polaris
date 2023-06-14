import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-clientes',
  templateUrl: './visualizar-clientes.component.html',
  styleUrls: ['./visualizar-clientes.component.scss']
})
export class VisualizarClientesComponent implements OnInit {
  public clienteData: any;
  public loginUuid!: string;
  public loginStatusUuid!: string;

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.getAllClientesAtivos();
    this.loadData();
  }

  getAllClientesAtivos() {
    this.gerenteService.getAllClientesAtivos().subscribe( (res: any) => {
        this.clienteData = res;
      }
    );
  }
  
  loadData() {
    this.gerenteService.getAllClientesAtivos().subscribe( (res: any) => {
      this.clienteData = res;
    })
  };

  alterarStatusLoginCliente(uuid: string) {
    this.gerenteService.alterarStatusLoginCliente(uuid).subscribe(
      response => console.log("Status do login alterado com sucesso!"),
      error => console.error(error)
    );       
  }

  didTapOnDelete(clienteUuid: string) {
    this.gerenteService.deleteCliente(clienteUuid).subscribe(
      response => this.loadData(),
      error => console.error(error)
    );    
  };
}
