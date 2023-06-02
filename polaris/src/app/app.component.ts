import { Component } from '@angular/core';
import { LoginService } from './auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Polaris';
  status: boolean = false;
  
  constructor( private router: Router, private loginService: LoginService) { }
  // CERTO: GERENTE : CLIENTE
  logado = true;
  perfil = this.loginService.isGerente ? 'CLIENTE' : 'GERENTE';
  // perfil = this.loginService.isGerente ? 'GERENTE' : 'CLIENTE';

  clickEvent() {
    this.status = !this.status;
  }

  deleteFromLocalStorage() {
    this.loginService.deleteFromLocalStorage();
  }
}