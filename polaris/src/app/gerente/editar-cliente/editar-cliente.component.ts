import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Cliente } from 'src/app/models/cliente.model';
import { ClienteLogin } from 'src/app/models/clienteLogin.model';
import { Endereco } from 'src/app/models/endereco.model';
import { Login } from 'src/app/models/login.model';
import { LoginEdicaoCadastro } from "src/app/models/loginEdicaoCadastro.model";
import { GerenteService } from '../services';

@Component({
  selector: 'app-editar-cliente',
  templateUrl: './editar-cliente.component.html',
  styleUrls: ['./editar-cliente.component.scss']
})
export class EditarClienteComponent implements OnInit {
  public statusMsg!: string;
  public clienteUuid: any;
  public clienteData: any;
  public clienteById!: ClienteLogin;

  public login: Login = {
    loginUuid: '',
    usuario: '',
    senha: 'senha1234'
  }

  public endereco: Endereco = {
    cep: '',
    cidade: '',
    estado: '',
    logradouro: '',
    complemento: '',
    numero: NaN
  }

  public cliente: ClienteLogin = {
    clienteUuid: '',
    nome: '',
    sobrenome: '',
    cpf: '',
    dataNascimento: '',
    email: '',
    telefone: '',
    endereco: this.endereco,
    login: this.login
  }
  
  @ViewChild("formCliente") formCliente!: NgForm;
  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.clienteUuid = this.activatedRoute.snapshot.params['id']; 
    this.getAllClientes();
    this.getClienteByIdLogin();
  }

  editar() {
    console.log(this.cliente);
    this.gerenteService.editarCliente(this.cliente).subscribe(
      (response: HttpResponse<Cliente>) => {   
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

  getClienteByIdLogin() {
    this.gerenteService.getClienteByIdLogin(this.clienteUuid).subscribe( (res: any) => {
        this.clienteById = res;
        this.cliente.clienteUuid = this.clienteUuid;
        this.cliente.nome = this.clienteById.nome;
        this.cliente.sobrenome = this.clienteById.sobrenome;
        this.cliente.cpf = this.clienteById.cpf;
        this.cliente.dataNascimento = this.clienteById.dataNascimento;
        this.cliente.email = this.clienteById.email;
        this.cliente.telefone = this.clienteById.telefone;
        this.cliente.endereco = this.clienteById.endereco;
        this.cliente.login.loginUuid = this.clienteById.login.loginUuid;  
        this.cliente.login.usuario = this.clienteById.login.usuario;       
      }
    )
  }
}