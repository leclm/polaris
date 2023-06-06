import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';
import { HttpResponse } from '@angular/common/http';
import { AluguelEstado } from 'src/app/models/aluguelEstado.model';
import { Conteiner } from 'src/app/models/conteiner.model';
import { Aluguel } from 'src/app/models/aluguel.model';

enum EstadoConteiner {
  Cancelado = 0,
  Disponível = 1,
  "Em Manutenção" = 2,
  Limpeza = 3,
  Locado = 4,
  Atrasado = 5,
  Reservado = 6,
  Indisponível = 7,
  "Em Vistoria" = 8
};

@Component({
  selector: 'app-visualizar-estoque-conteineres',
  templateUrl: './visualizar-estoque-conteineres.component.html',
  styleUrls: ['./visualizar-estoque-conteineres.component.scss']
})
export class VisualizarEstoqueConteineresComponent implements OnInit {
  public conteinerData: any;
  public estadoConteiner: any;
  public statusMsg!: string;
  
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

  didTapOnDelete(uuid: string, codigo: string) {
    this.gerenteService.getAlugueisByConteiner(codigo).subscribe(      
      (res: any) => {
        const estadoAluguelValues = res.map((item: any) => item.estadoAluguel);
        
        if (estadoAluguelValues.includes(0) || estadoAluguelValues.includes(1) || estadoAluguelValues.includes(2) || estadoAluguelValues.includes(3) || estadoAluguelValues.includes(5)) {
          this.statusMsg = 'fail';
        } else {
          this.gerenteService.deleteConteiner(uuid).subscribe(
            (response: HttpResponse<Conteiner>) => {   
              if (response.status === 200 || response.status === 201) {
                this.statusMsg = 'success';
                this.loadData();
                console.log('Put request successful');
              } else {
                console.log('Put request failed');
              }
            },
            (error) => {
              console.error('Error:', error);
              this.statusMsg = 'fail';
            }
          );
        }
      }
    );
  }
}
