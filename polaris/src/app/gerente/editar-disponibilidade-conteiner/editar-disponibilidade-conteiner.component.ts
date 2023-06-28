import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConteinerEstado } from 'src/app/models/conteinerEstado.model';
import { GerenteService } from '../services';

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
  selector: 'app-editar-disponibilidade-conteiner',
  templateUrl: './editar-disponibilidade-conteiner.component.html',
  styleUrls: ['./editar-disponibilidade-conteiner.component.scss']
})
export class EditarDisponibilidadeConteinerComponent implements OnInit {
  public conteinerUuid: any;
  public conteinerData: any;
  public statusMsg!: string;
  public estadoConteiner = EstadoConteiner;
  public estadoConteinerSelecionado = 0;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.conteinerUuid = this.activatedRoute.snapshot.params['id']; 
    this.getAllConteineres();  
    this.getConteinerById();
  }

  getConteinerById() {
    this.gerenteService.getConteinerById(this.conteinerUuid).subscribe( (res: any) => { 
      this.estadoConteinerSelecionado = res.estado;
    });   
  }
  
  getAllConteineres() {
    this.gerenteService.getAllConteineres().subscribe( (res: any) => { this.conteinerData = res; }); 
  }

  editar() {
    this.gerenteService.alteraDisponibilidadeConteiner(this.conteinerUuid, this.estadoConteinerSelecionado).subscribe(
      (response: HttpResponse<ConteinerEstado>) => {   
        if (response.status === 200 || response.status === 201) {
          this.statusMsg = 'success';
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

  // Popula EstadoConteiner dropdown
  public enumConteinerLength = Object.keys(this.estadoConteiner).length / 2;
  fakeArrayConteiner = new Array(this.enumConteinerLength);
}
