import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { LoginAcesso } from 'src/app/models/loginAcesso.model';
import { LoginService } from '../services';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

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
    senha: '',
    token: ''
  }

  @ViewChild('formLogin') formLogin!: NgForm;

  constructor (private loginService: LoginService, private router: Router, private route: ActivatedRoute ) { }

  ngOnInit(): void { }
  
  efetuarLogin() {    
    if (this.formLogin.form.valid) {
      this.loginService.efetuarLogin(this.login).subscribe(
        (response: HttpResponse<LoginAcesso>) => {
          if (response.status === 200 || response.status === 201) {
            console.log('Put request successful');
            this.router.navigate(["/gerente/dashboard"]);
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
  };

  forgetPassword() {
    this.statusMsg = 'forgot';
  }
}
