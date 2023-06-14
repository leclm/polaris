import { Component, OnInit, ViewChild } from '@angular/core';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';
import { ViaCepService, CustomvalidationService } from 'src/app/shared';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { NgForm } from '@angular/forms';
import { Servico } from 'src/app/models/servico.model';
import { HttpResponse } from '@angular/common/http';
import { Endereco } from 'src/app/models/endereco.model';

@Component({
  selector: 'app-editar-terceirizado',
  templateUrl: './editar-terceirizado.component.html',
  styleUrls: ['./editar-terceirizado.component.scss']
})
export class EditarTerceirizadoComponent implements OnInit {
  public terceirizadoUuid: any;
  public terceirizadoById!: Terceirizado;
  public servicosCadastrados: Servico[] = []; 
  public servicosAtuaisTerceirizado: Servico[] = [];  
  public terceirizadoData: any;
  public statusMsg!: string;
  public selectedOptions: string[] = [];
  public cnpjNotValid = false;
  public cepNotValid = false;
  
  public endereco: Endereco = {
    cep: '',
    cidade: '',
    estado: '',
    logradouro: '',
    complemento: '',
    numero: NaN
  }

  public terceirizado: Terceirizado = {
    terceirizadoUuid: '',
    empresa: '',
    cnpj: '',
    email: '',
    telefone: '',
    endereco: this.endereco,
    listaServicos: []
  }

  public servico: Servico = {
    servicoUuid: '',
    nome: '',
    checked: true
  }

  @ViewChild("formTerceirizado") formTerceirizado!: NgForm;

  constructor(  private CustomvalidationService: CustomvalidationService, private viaCepService: ViaCepService, private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.terceirizadoUuid = this.activatedRoute.snapshot.params['id']; 
    this.gerenteService.getAllTerceirizados().subscribe( (res: any) => {
        this.terceirizadoData = res;
      }
    )

    this.gerenteService.getTerceirizadoById(this.terceirizadoUuid).subscribe( (res: any) => {
        this.terceirizadoById = res;
        this.terceirizado.terceirizadoUuid = this.terceirizadoUuid;
        this.terceirizado.empresa = this.CustomvalidationService.camelize(this.terceirizadoById.empresa);
        this.terceirizado.cnpj = this.terceirizadoById.cnpj;
        this.terceirizado.email = this.terceirizadoById.email;
        this.terceirizado.telefone = this.terceirizadoById.telefone;
        this.terceirizado.endereco = this.terceirizadoById.endereco;
        this.terceirizado.endereco.cidade = this.CustomvalidationService.camelize(this.terceirizado.endereco.cidade)
        this.terceirizado.endereco.logradouro = this.CustomvalidationService.camelize(this.terceirizado.endereco.logradouro)
        this.terceirizado.endereco.complemento = this.CustomvalidationService.camelize(this.terceirizado.endereco.complemento)
        
        this.servicosAtuaisTerceirizado = res.servicos;
        for (let i = 0; i < this.servicosAtuaisTerceirizado.length; i++) {
          this.servicosAtuaisTerceirizado[i].checked = true;
        }

        this.terceirizado.listaServicos = res.servicos.map((i: any) => i.servicoUuid);
      }
    )
    this.gerenteService.getAllServicosAtivos()
    .subscribe( response => {
      this.servicosCadastrados = response;
      for (let data of this.servicosCadastrados) {
        data.nome = this.CustomvalidationService.camelize(data.nome)   
      }
    })

  }

  onCheckboxChange(item: any) {
    this.selectedOptions = this.servicosCadastrados.filter((i: any) => i.checked).map((i: any) => i.servicoUuid);
    this.terceirizado.listaServicos = this.selectedOptions;
  }

  getCheckedItems() {
    return this.servicosAtuaisTerceirizado.filter(item => item.checked);
  }

  validateCnpj(event: any) {
      let valid = this.CustomvalidationService.validaCnpj(this.terceirizado.cnpj)
      this.cnpjNotValid = valid;
  }

  searchAddress(event: any) {
    console.log(this.terceirizado.endereco.cep)
    this.viaCepService.getAddressByCep(this.terceirizado.endereco.cep).subscribe(data => {
      this.terceirizado.endereco.cidade = data.localidade;
      this.terceirizado.endereco.estado = data.uf;
      this.terceirizado.endereco.logradouro = data.logradouro;
      if(data.uf==undefined){
        this.cepNotValid = true;
      } else{
        this.cepNotValid = false;
      }
    });
  }

  editar() {
    this.gerenteService.editarTerceirizado(this.terceirizado).subscribe(
      (response: HttpResponse<Terceirizado>) => {   
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
