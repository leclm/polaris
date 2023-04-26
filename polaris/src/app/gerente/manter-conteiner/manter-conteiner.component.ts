import { Component, OnInit } from '@angular/core';
import { Categoria } from 'src/app/models/categoria.model';
import { Conteiner } from 'src/app/models/conteiner.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Tipo } from 'src/app/models/tipo.model';
import { GerenteService } from '../services';
import { HttpResponse } from '@angular/common/http';

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

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.getAllCategoriasAtivas(); 
    this.getAllTiposAtivos(); 
    this.getAllTerceirizadosAtivos();
  }

  cadastrar() {
    this.generateRandomCod();
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

  generateRandomCod() {
    let arr: number[] = [1, 2, 3, 99999, 99998, 99997, 99996, 99995];
    let num: number;

    do {
      num = Math.floor(Math.random() * 999999) + 1; // generates a random number between 1 and 999999
    } while (arr.includes(num) && arr.length < 100); // repeat until a unique number is found or the array is full

    if (!arr.includes(num)) {
      arr.push(num);
      this.conteiner.codigo += num;
    }
    return this.conteiner.codigo;
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
