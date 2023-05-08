import { HttpResponse } from '@angular/common/http';
import { ViaCepService } from 'src/app/shared';
import { Component, OnInit } from '@angular/core';
import { GerenteService } from 'src/app/gerente/services';
import { Cliente } from 'src/app/models/cliente.model';
import { Endereco } from 'src/app/models/endereco.model';

@Component({
  selector: 'app-solicitar-contato',
  templateUrl: './solicitar-contato.component.html',
  styleUrls: ['./solicitar-contato.component.scss']
})
export class SolicitarContatoComponent implements OnInit {
  public statusMsg!: string;

  constructor( private viaCepService: ViaCepService, private gerenteService: GerenteService ) { }

  public endereco: Endereco = {
    cep: '',
    cidade: '',
    estado: '',
    logradouro: '',
    complemento: '',
    numero: NaN
  }
  
  public cliente: Cliente = {
    clienteUuid: '',
    nome: '',
    sobrenome: '',
    cpf: '',
    dataNascimento: '',
    email: '',
    telefone: '',
    endereco: this.endereco
  }

  ngOnInit(): void {
  }

  cadastrar() {
    console.log('cadastrar');
  }

  searchAddress(event: any) {
    this.viaCepService.getAddressByCep(this.endereco.cep).subscribe(data => {
      this.endereco.cidade = data.localidade;
      this.endereco.estado = data.uf;
      this.endereco.logradouro = data.logradouro;
    });
  }

/*  cadastrar() {
    this.gerenteService.addTerceirizado(this.novoCliente).subscribe(
      (response: HttpResponse<NovoCliente>) => {   
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
  }*/
}