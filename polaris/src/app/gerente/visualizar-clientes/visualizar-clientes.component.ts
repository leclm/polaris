import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-clientes',
  templateUrl: './visualizar-clientes.component.html',
  styleUrls: ['./visualizar-clientes.component.scss']
})
export class VisualizarClientesComponent implements OnInit {
  public clienteData: any;
  public terceirizadoUuid!: string;

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.getAllClientes();
    this.loadData();
  }

  getAllClientes() {
    this.gerenteService.getAllClientes().subscribe( (res: any) => {
        this.clienteData = res;
      }
    );
  }

  loadData() {
    this.gerenteService.getAllClientesAtivos().subscribe( (res: any) => {
      this.clienteData = res;
    })
  };

  didTapOnDelete(uuid: string) {
    this.gerenteService.deleteCliente(uuid).subscribe(
      response => this.loadData(),
      error => console.error(error)
    )
  };
}
