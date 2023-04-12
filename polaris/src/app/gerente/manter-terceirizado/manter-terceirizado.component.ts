import { Component, HostListener, OnInit } from '@angular/core';
import { ViaCepService } from 'src/app/shared';
import { GerenteService } from '../services';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Endereco } from 'src/app/models/endereco.model';
import { Servico } from 'src/app/models/servico.model';

@Component({
  selector: 'app-manter-terceirizado',
  templateUrl: './manter-terceirizado.component.html',
  styleUrls: ['./manter-terceirizado.component.scss']
})

export class ManterTerceirizadoComponent implements OnInit {
  public cep!: string;
  public address: any;
  public status!: string;

  public terceirizados: Terceirizado[] = [];
  public servicos: Servico[] = [];

  public endereco: Endereco = {
    id: '',
    cep: '',
    cidade: '',
    estado: '',
    logradouro: '',
    complemento: '',
    numero: 0
  }

  public servico: Servico = {
    id: '',
    nome: ''
  }

  public terceirizado: Terceirizado = {
    id: '',
    empresa: '',
    cnpj: '',
    email: '',
    telefone: '',
    endereco: this.endereco,
    servicos: [this.servico]
  }

  constructor( 
    private viaCepService: ViaCepService,
    private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.getAllTerceirizados();
    this.getAllServicos();
  }

  getAllTerceirizados() {
    this.gerenteService.getAllTerceirizados()
    .subscribe( response => {
      this.terceirizados = response;
      console.log(response);
    })
  }

  getAllServicos() {
    this.gerenteService.getAllServicos()
    .subscribe( response => {
      this.servicos = response;
      console.log(response);
    })
  }

  cadastrar() {
    this.gerenteService.addTerceirizado(this.terceirizado)
    .subscribe( response => {
      console.log(response);
    })
  }

  // mock para mensagem
  cadastrarError(): any {
    var code = "200";
    if ( code == "200") {
      this.status = 'success';
    } else {
      this.status = 'fail';
    }
  }  

  searchAddress(event: any) {
    this.viaCepService.getAddressByCep(this.cep).subscribe(data => {
      this.address = data;
    });
  }
}
