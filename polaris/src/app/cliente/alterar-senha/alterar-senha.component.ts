import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GerenteService } from 'src/app/gerente/services';
import { Cliente } from 'src/app/models/cliente.model';
import { Endereco } from 'src/app/models/endereco.model';
import { Login } from 'src/app/models/login.model';

@Component({
  selector: 'app-alterar-senha',
  templateUrl: './alterar-senha.component.html',
  styleUrls: ['./alterar-senha.component.scss']
})
export class AlterarSenhaComponent implements OnInit {
  public statusMsg!: string;

  public endereco: Endereco = {
    cep: '',
    cidade: '',
    estado: '',
    logradouro: '',
    complemento: '',
    numero: NaN
  }

  public login: Login = {
    usuario: '',
    senha: ''
  }

  public cliente: Cliente = {
    nome: '',
    sobrenome: '',
    cpf: '',
    dataNascimento: '',
    email: '',
    telefone: '',
    endereco: this.endereco,
    login: this.login
  }

  @ViewChild("formAlterarSenha") formCategoria!: NgForm;
  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
  }

  editar() {
    console.log('saasd');
    /*this.gerenteService.editarCategoria(this.categoria).subscribe(
      (response: HttpResponse<Categoria>) => {   
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
    );*/
  };

}
