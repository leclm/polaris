import { Component, OnInit } from '@angular/core';
import { Categoria } from 'src/app/models/categoria.model';
import { Conteiner } from 'src/app/models/conteiner.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Tipo } from 'src/app/models/tipo.model';
import { GerenteService } from '../services';
import { HttpResponse } from '@angular/common/http';

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
  selector: 'app-manter-conteiner',
  templateUrl: './manter-conteiner.component.html',
  styleUrls: ['./manter-conteiner.component.scss']
})
export class ManterConteinerComponent implements OnInit {
  public statusMsg!: string;
  public terceirizadosCadastrados: Terceirizado[] = [];
  public categoriasCadastradas: Categoria[] = [];  
  public tiposCadastrados: Tipo[] = [];

  public conteiner: Conteiner = {
    conteinerUuid: '',
    codigo: 0,
    fabricacao: '',
    fabricante: '',
    material: '',
    cor: '',
    categoria: '',
    tipo: ''
  }

  public tipo: Tipo = {
    tipoConteinerUuid: '',
    nome: '',
    largura: 0,
    comprimento: 0,
    volume: 0,
    pesoMaximo: 0,
    altura: 0,
    valorDiaria: 0,
    valorMensal: 0,
    status: true
  }

  public categoria: Categoria = {
    categoriaConteinerUuid: '',
    nome: '',
    status: true
  }

  status = ['Em manutenção', 'Limpeza', 'Disponível', 'Locado', 'Atrasado', 'Reservado', 'Indisponível', 'Em vistoria']

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.getAllCategoriasAtivas(); 
    this.getAllTiposAtivos(); 
    this.getAllTerceirizadosAtivos();
  }

  cadastrar() {
    this.conteiner.codigo += 1;
    this.gerenteService.addConteiner(this.conteiner).subscribe(
      (response: HttpResponse<Conteiner>) => {   
        if (response.status === 200 || response.status === 201) {
          this.statusMsg = 'success';
          console.log('Post request successful');
        } else {
          console.log('Post request failed');
        }
      },
      (error) => {
        console.error('Error:', error);
        this.statusMsg = 'fail';
      }
    );
  }

  getAllCategoriasAtivas() {
    this.gerenteService.getAllCategoriasAtivas()
    .subscribe( response => {
      this.categoriasCadastradas = response;
    })
  }

  getAllTiposAtivos() {
    this.gerenteService.getAllTiposAtivos()
    .subscribe( response => {
      this.tiposCadastrados = response;
    })
  }

  getAllTerceirizadosAtivos() {
    this.gerenteService.getAllTerceirizadosAtivos()
    .subscribe( response => {
      this.terceirizadosCadastrados = response;
    })
  }
}
