import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ClienteEdicao } from 'src/app/models/clienteEdicao.model';
import { Endereco } from 'src/app/models/endereco.model';
import { GerenteService } from '../services';
import { Cliente } from 'src/app/models/cliente.model';
import { CustomvalidationService } from 'src/app/shared';

@Component({
  selector: 'app-editar-cliente',
  templateUrl: './editar-cliente.component.html',
  styleUrls: ['./editar-cliente.component.scss']
})
export class EditarClienteComponent implements OnInit {
  public statusMsg!: string;
  public clienteUuid: any;
  public clienteData: any;
  public clienteById!: Cliente;

  public endereco: Endereco = {
    cep: '',
    cidade: '',
    estado: '',
    logradouro: '',
    complemento: '',
    numero: NaN
  }

  public cliente: ClienteEdicao = {
    clienteUuid: '',
    nome: '',
    sobrenome: '',
    dataNascimento: '',
    email: '',
    telefone: '',
    endereco: this.endereco
  }
  
  @ViewChild("formCliente") formCliente!: NgForm;
  constructor( private CustomvalidationService: CustomvalidationService, private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.clienteUuid = this.activatedRoute.snapshot.params['id']; 
    this.getAllClientes();
    this.getClienteById();
  }

  public dataVar = this.cliente.dataNascimento;
  valuechange(date: any) {
    let day: any;
    let month: any;
    let year = JSON.stringify(date.year)
    if((JSON.stringify(date.day).length)==1){
      day = "0"+JSON.stringify(date.day)
    } else {day = date.day}
    if((JSON.stringify(date.month).length)==1){
      month = "0"+JSON.stringify(date.month)
    } else {month = date.month}
    
    this.cliente.dataNascimento = `${year}-${month}-${day}T00:00:00`;
    console.log(this.cliente.dataNascimento)
    this.dataVar = `${date.day}-${date.month}-${date.year}`;
  }
  editar() {
    this.gerenteService.editarCliente(this.cliente).subscribe(
      (response: HttpResponse<ClienteEdicao>) => {   
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

  getAllClientes() {
    this.gerenteService.getAllClientes().subscribe( (res: any) => {
        this.clienteData = res;
      }
    )
  }

  getClienteById() {
    this.gerenteService.getClienteById(this.clienteUuid).subscribe( (res: any) => {
        this.clienteById = res;
        this.cliente.clienteUuid = this.clienteUuid;
        this.cliente.nome = this.CustomvalidationService.camelize(this.clienteById.nome);
        this.cliente.sobrenome = this.CustomvalidationService.camelize(this.clienteById.sobrenome);
        this.cliente.email = this.CustomvalidationService.camelize(this.clienteById.email);
        this.cliente.telefone = this.clienteById.telefone;
        this.cliente.endereco = this.clienteById.endereco;
        this.cliente.endereco.cidade = this.CustomvalidationService.camelize(this.cliente.endereco.cidade)
        this.cliente.endereco.logradouro = this.CustomvalidationService.camelize(this.cliente.endereco.logradouro)
        this.cliente.endereco.complemento = this.CustomvalidationService.camelize(this.cliente.endereco.complemento)

        let dataNasc = this.clienteById.dataNascimento;
        let dataArr = dataNasc.split("T");
        dataArr = dataArr[0].split("-")
  
        this.dataVar = `${dataArr[2]}-${dataArr[1]}-${dataArr[0]}`;
        this.cliente.dataNascimento = `${dataArr[0]}-${dataArr[1]}-${dataArr[2]}T00:00:00`;

      }
    )
  }
}