import { Component, HostListener, OnInit } from '@angular/core';
import { ViaCepService } from 'src/app/shared';
import { GerenteService } from '../services';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Endereco } from 'src/app/models/endereco.model';
import { Servico } from 'src/app/models/servico.model';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

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
    servicoUuid: '',
    nome: ''
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

  constructor( private viaCepService: ViaCepService, private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.getAllTerceirizados();
    this.getAllServicos();
  }

  cadastrar() {
    this.terceirizado.listaServicos = [this.servico.servicoUuid];
    this.gerenteService.addTerceirizado(this.terceirizado).subscribe(
      (response: HttpResponse<Terceirizado>) => {   
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
    })
  }

  getAllServicos() {
    this.gerenteService.getAllServicos()
    .subscribe( response => {
      this.servicosCadastrados = response;
    })
  }
}
