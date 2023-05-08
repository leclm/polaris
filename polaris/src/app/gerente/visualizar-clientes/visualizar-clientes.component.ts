import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-clientes',
  templateUrl: './visualizar-clientes.component.html',
  styleUrls: ['./visualizar-clientes.component.scss']
})
export class VisualizarClientesComponent implements OnInit {
  public clienteData: any;

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.getAllClientes();
  }

  getAllClientes() {
    this.gerenteService.getAllClientes().subscribe( (res: any) => {
        this.clienteData = res;
      }
    );
  }
}
