import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-detalhes-cliente',
  templateUrl: './visualizar-detalhes-cliente.component.html',
  styleUrls: ['./visualizar-detalhes-cliente.component.scss']
})
export class VisualizarDetalhesClienteComponent implements OnInit {
  public clienteUuid: any;
  public clienteData: any;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.clienteUuid = this.activatedRoute.snapshot.params['id'];
    this.getAllClientesAtivos();
  }

  getAllClientesAtivos() {
      this.gerenteService.getAllClientesAtivos().subscribe( (res: any) => {
        this.clienteData = res;
      }
    )
  }
}
