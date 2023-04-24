import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-terceirizados',
  templateUrl: './visualizar-terceirizados.component.html',
  styleUrls: ['./visualizar-terceirizados.component.scss']
})
export class VisualizarTerceirizadosComponent implements OnInit {
  public servicoData: any;
  public terceirizadoData: any;
  public terceirizadoUuid!: string;

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.gerenteService.getAllServicos().subscribe( (res: any) => {
        this.servicoData = res;
      }
    );
    this.loadData();
  }

  loadData() {
    this.gerenteService.getAllTerceirizadosAtivos().subscribe( (res: any) => {
      this.terceirizadoData = res;
    })
  };

  didTapOnDelete(uuid: string) {
    this.gerenteService.deleteTerceirizado(uuid).subscribe(
      response => this.loadData(),
      error => console.error(error)
    )
  };
}
