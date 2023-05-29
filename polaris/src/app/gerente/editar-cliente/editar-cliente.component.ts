import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ClienteEdicao } from 'src/app/models/clienteEdicao.model';
import { Endereco } from 'src/app/models/endereco.model';
import { GerenteService } from '../services';
import { Cliente } from 'src/app/models/cliente.model';

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
  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.clienteUuid = this.activatedRoute.snapshot.params['id']; 
    this.getAllClientes();
    this.getClienteById();
  }

  editar() {
    console.log(this.cliente);
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
        this.cliente.nome = this.clienteById.nome;
        this.cliente.sobrenome = this.clienteById.sobrenome;
        this.cliente.dataNascimento = this.clienteById.dataNascimento;
        this.cliente.email = this.clienteById.email;
        this.cliente.telefone = this.clienteById.telefone;
        this.cliente.endereco = this.clienteById.endereco;  
      }
    )
  }
}