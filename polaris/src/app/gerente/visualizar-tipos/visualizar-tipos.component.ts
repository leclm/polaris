import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-tipos',
  templateUrl: './visualizar-tipos.component.html',
  styleUrls: ['./visualizar-tipos.component.scss']
})
export class VisualizarTiposComponent implements OnInit {
  public tipoData: any;

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.gerenteService.getAllTiposAtivos().subscribe( (res: any) => { this.tipoData = res; })
  };

  didTapOnDelete(uuid: string) {
    this.gerenteService.deleteTipo(uuid).subscribe(
      response => this.loadData(),
      error => console.error(error)
    )
  };
}
