import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GerenteService } from 'src/app/gerente/services';
import { Login } from 'src/app/models/login.model';
import { ClienteService } from '../services';

@Component({
  selector: 'app-alterar-senha',
  templateUrl: './alterar-senha.component.html',
  styleUrls: ['./alterar-senha.component.scss']
})
export class AlterarSenhaComponent implements OnInit {
  public statusMsg!: string;
  newPassword: string = '';
  confirmPassword: string = '';
  passwordsMatch: boolean = true;

  public login: Login = {
    loginUuid: '',
    usuario: '',
    senha: ''
  }  

  @ViewChild("formAlterarSenha") formAlterarSenha!: NgForm;
  constructor( private clienteService: ClienteService, private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.login.loginUuid = localStorage.getItem("loginUuid") as string;
    this.getClienteById();
  }

  getClienteById() {
    this.gerenteService.getClienteByIdLogin(this.login.loginUuid).subscribe( res => {
        this.login.loginUuid = res.login.loginUuid;
        this.login.usuario = res.login.usuario;
      }      
    );
  }
 
  changePassword(): void {
    if (this.newPassword === this.confirmPassword) {
      this.login.senha = this.newPassword;
      this.editar();
    } else {
      this.passwordsMatch = false;
      this.statusMsg = 'fail';
    }
  }

  editar() {
    console.log(this.login);
    this.clienteService.alterarSenha(this.login).subscribe(
      (response: HttpResponse<Login>) => {   
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
  };
}
