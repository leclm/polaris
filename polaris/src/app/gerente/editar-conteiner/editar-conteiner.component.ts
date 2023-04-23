import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GerenteService } from '../services';
import { ActivatedRoute, Router } from '@angular/router';
import { Tipo } from 'src/app/models/tipo.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Categoria } from 'src/app/models/categoria.model';
import { Conteiner } from 'src/app/models/conteiner.model';
import { HttpResponse } from '@angular/common/http';
import { Servico } from 'src/app/models/servico.model';
import { Endereco } from 'src/app/models/endereco.model';

@Component({
  selector: 'app-editar-conteiner',
  templateUrl: './editar-conteiner.component.html',
  styleUrls: ['./editar-conteiner.component.scss']
})
export class EditarConteinerComponent implements OnInit {
  public conteinerUuid: any;
  public conteinerById!: Conteiner;
  public conteinerData: any;
  public statusMsg!: string;
  public tiposCadastrados: Tipo[] = []; 
  public categoriasCadastradas: Categoria[] = []; 
  public terceirizadosCadastrados: Terceirizado[] = [];  

  @ViewChild("formConteiner") formConteiner!: NgForm;
  
  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute, private router: Router ) { }

  status = ['Em manutenção', 'Limpeza', 'Disponível', 'Locado', 'Atrasado', 'Reservado', 'Indisponível', 'Em vistoria']

  public categoria: Categoria = {
    categoriaConteinerUuid: '',
    nome: '',
    status: true
  }

  public servico: Servico = {
    servicoUuid: '',
    nome: '',
    checked: false
  }
  
  public endereco: Endereco = {
    cep: '',
    cidade: '',
    estado: '',
    logradouro: '',
    complemento: '',
    numero: NaN
  }
  
  public terceirizado: Terceirizado = {
    empresa: '',
    cnpj: '',
    email: '',
    telefone: '',
    endereco: this.endereco,
    listaServicos: []
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

  ngOnInit(): void {
    this.conteinerUuid = this.activatedRoute.snapshot.params['id']; 
    this.gerenteService.getAllConteineres().subscribe( (res: any) => { this.conteinerData = res; });
    this.gerenteService.getConteinerById(this.conteinerUuid).subscribe( (res: any) => { this.conteinerById = res; console.log(this.conteinerById); });
    this.gerenteService.getAllTipos().subscribe( (res: any) => { this.tiposCadastrados = res; });
    this.gerenteService.getAllCategorias().subscribe( (res: any) => { this.categoriasCadastradas = res; });
    this.gerenteService.getAllTerceirizados().subscribe( (res: any) => { this.terceirizadosCadastrados = res;});  }

  editar() {
    console.log(this.conteinerById);
    this.gerenteService.putConteiner(this.conteinerById).subscribe(
      (response: HttpResponse<Conteiner>) => {   
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
}
