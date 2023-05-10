import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { GerenteService } from 'src/app/gerente/services';
import { Login } from 'src/app/models/login.model';
import { LoginAcesso } from 'src/app/models/loginAcesso.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
  public statusMsg!: string;
  inputLogin: string = '';
  password: string = '';

  public login: LoginAcesso = {
    usuario: '',
    senha: ''
  } 

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
  }

  efetuarLogin() {
    this.gerenteService.efetuarLogin(this.login).subscribe(
      (response: HttpResponse<LoginAcesso>) => {   
        if (response.status === 200 || response.status === 201) {
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

  forgetPassword() {
    this.statusMsg = 'forgot';
  }
}
