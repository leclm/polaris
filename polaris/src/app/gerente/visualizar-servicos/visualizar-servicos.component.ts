import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-servicos',
  templateUrl: './visualizar-servicos.component.html',
  styleUrls: ['./visualizar-servicos.component.scss']
})
export class VisualizarServicosComponent implements OnInit {
  public servicoData: any;
  
  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.gerenteService.getAllServicosAtivos().subscribe( (res: any) => { this.servicoData = res; });
  };

  didTapOnDelete(uuid: string) {
    this.gerenteService.deleteServico(uuid).subscribe(
      response => this.loadData(),
      error => console.error(error)
    )
  };

}
