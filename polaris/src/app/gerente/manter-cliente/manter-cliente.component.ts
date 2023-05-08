import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Cliente } from 'src/app/models/cliente.model';
import { Endereco } from 'src/app/models/endereco.model';
import { ViaCepService } from 'src/app/shared';
import { GerenteService } from '../services';

@Component({
  selector: 'app-manter-cliente',
  templateUrl: './manter-cliente.component.html',
  styleUrls: ['./manter-cliente.component.scss']
})
export class ManterClienteComponent implements OnInit {
  public statusMsg!: string;

  public endereco: Endereco = {
    cep: '',
    cidade: '',
    estado: '',
    logradouro: '',
    complemento: '',
    numero: NaN
  }

  public cliente: Cliente = {
    nome: '',
    sobrenome: '',
    cpf: '',
    dataNascimento: '',
    email: '',
    telefone: '',
    endereco: this.endereco
  }
  
  constructor( private viaCepService: ViaCepService, private gerenteService: GerenteService ) { }

  ngOnInit(): void {
  }
  
  cadastrar() {
    this.gerenteService.addCliente(this.cliente).subscribe(
      (response: HttpResponse<Cliente>) => {   
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
