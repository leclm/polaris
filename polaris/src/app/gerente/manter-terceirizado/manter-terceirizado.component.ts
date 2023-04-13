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
  public statusMsg!: string;
  public terceirizadosCadastrados: Terceirizado[] = [];
  public servicosCadastrados: Servico[] = [];

  public servico: Servico = {
    servicoUuid: '' // exemplo uuid nao cadastrado no db: 7db3f5dc-b90c-4d7d-b179-1d2341a96722
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
    servicos: [this.servico]
  }

  constructor( private viaCepService: ViaCepService, private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.getAllTerceirizados(); // usado só pra mostrar no console os terceirizados cadastrados e ver se ta dando certo ou não
    this.getAllServicos(); // pega os serviços cadastrados e popula o select do html
  }

  cadastrar() {
    this.gerenteService.addTerceirizado(this.terceirizado)
    .subscribe( response => {
      console.log(response);
    });
    
    this.getAllTerceirizados();
    console.log(this.terceirizado);
  }
  
  searchAddress(event: any) {
    this.viaCepService.getAddressByCep(this.endereco.cep).subscribe(data => {
      this.endereco = data;
      console.log(data);
      console.log(this.terceirizado);
    });
  }
  
  getAllTerceirizados() {
    this.gerenteService.getAllTerceirizados()
    .subscribe( response => {
      this.terceirizadosCadastrados = response;
      console.log(this.terceirizadosCadastrados);
    })
  }

  getAllServicos() {
    this.gerenteService.getAllServicos()
    .subscribe( response => {
      this.servicosCadastrados = response;
      console.log(this.servicosCadastrados);
    })
  }

  
  // mock para mensagem de sucesso e erro ao cadastrar (nao implementado)
  cadastrarError(): any {
    var code = "200";
    if ( code == "200") {
      this.statusMsg = 'success';
    } else {
      this.statusMsg = 'fail';
    }
  } 
}
