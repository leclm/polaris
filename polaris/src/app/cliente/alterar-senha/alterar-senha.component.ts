import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GerenteService } from 'src/app/gerente/services';
import { Login } from 'src/app/models/login.model';

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
  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    // ajustar para pegar o usuario logado
    this.getClienteById('aa392264-ec06-4ab4-af59-f97f1c37bca7');
  }

  getClienteById(id: string) {
    this.gerenteService.getClienteByIdLogin(id).subscribe( res => {
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
    this.gerenteService.alterarSenha(this.login).subscribe(
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
