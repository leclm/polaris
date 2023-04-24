import { Component, OnInit } from '@angular/core';
import { ViaCepService } from 'src/app/shared';
import { GerenteService } from '../services';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Endereco } from 'src/app/models/endereco.model';
import { Servico } from 'src/app/models/servico.model';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-manter-terceirizado',
  templateUrl: './manter-terceirizado.component.html',
  styleUrls: ['./manter-terceirizado.component.scss']
})

export class ManterTerceirizadoComponent implements OnInit {
  public statusMsg!: string;
  public servicosCadastrados: Servico[] = [];
  public selectedOptions: string[] = [];
  
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
    this.getAllServicos();
  }

  onCheckboxChange(item: any) {
    this.selectedOptions = this.servicosCadastrados.filter((i: any) => i.checked).map((i: any) => i.servicoUuid);
  }

  getAllServicos() {
    this.gerenteService.getAllServicos()
    .subscribe( response => {
      this.servicosCadastrados = response;
    })
  }

  cadastrar() {
    this.terceirizado.listaServicos = this.selectedOptions;
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
      this.endereco.cidade = data.localidade;
      this.endereco.estado = data.uf;
      this.endereco.logradouro = data.logradouro;
    });
  }
}
