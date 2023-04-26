import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';

enum EstadoConteiner {
  Cancelado = 0,
  Disponível = 1,
  Manutenção = 2,
  Limpeza = 3,
  Locado = 4,
  Atrasado = 5,
  Reservado = 6,
  Indisponível = 7,
  Vistoria = 8
};

@Component({
  selector: 'app-visualizar-estoque-conteineres',
  templateUrl: './visualizar-estoque-conteineres.component.html',
  styleUrls: ['./visualizar-estoque-conteineres.component.scss']
})
export class VisualizarEstoqueConteineresComponent implements OnInit {
  public conteinerData: any;
  
  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.gerenteService.getAllConteineresAtivos().subscribe( (res: any) => {
      this.conteinerData = res;
      this.getEstadoText(this.conteinerData);
    });
  };
  
  getEstadoText(data: any) {
    for (let i = 0; i < data.length; i++) {
      let estado = data[i].estado;
      let estadoText = EstadoConteiner[estado]
      data[i].estado = estadoText;
    }
  };

  didTapOnDelete(uuid: string) {
    this.gerenteService.deleteConteiner(uuid).subscribe(
      response => this.loadData(),
      error => console.error(error)
    )
  };
}
