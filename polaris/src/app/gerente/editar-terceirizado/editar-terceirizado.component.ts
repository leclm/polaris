import { Component, OnInit, ViewChild } from '@angular/core';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';
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

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.terceirizadoUuid = this.activatedRoute.snapshot.params['id']; 
    this.gerenteService.getAllTerceirizados().subscribe( (res: any) => {
        this.terceirizadoData = res;
      }
    )

    this.gerenteService.getTerceirizadoById(this.terceirizadoUuid).subscribe( (res: any) => {
        this.terceirizadoById = res;
        this.terceirizado.terceirizadoUuid = this.terceirizadoUuid;
        this.terceirizado.empresa = this.terceirizadoById.empresa;
        this.terceirizado.cnpj = this.terceirizadoById.cnpj;
        this.terceirizado.email = this.terceirizadoById.email;
        this.terceirizado.telefone = this.terceirizadoById.telefone;
        this.terceirizado.endereco = this.terceirizadoById.endereco;
        
        this.servicosAtuaisTerceirizado = res.servicos;
        for (let i = 0; i < this.servicosAtuaisTerceirizado.length; i++) {
          this.servicosAtuaisTerceirizado[i].checked = true;
        }

        this.terceirizado.listaServicos = res.servicos.map((i: any) => i.servicoUuid);
      }
    )

    this.gerenteService.getAllServicos().subscribe( (res: any) => {
        this.servicosCadastrados = res;
      }
    )
  }

  onCheckboxChange(item: any) {
    this.selectedOptions = this.servicosCadastrados.filter((i: any) => i.checked).map((i: any) => i.servicoUuid);
    this.terceirizado.listaServicos = this.selectedOptions;
  }

  getCheckedItems() {
    return this.servicosAtuaisTerceirizado.filter(item => item.checked);
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
