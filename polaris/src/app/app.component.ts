import { Component } from '@angular/core';
import { LoginService } from './auth';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Polaris';
  status: boolean = false;

  constructor( private loginService: LoginService ) { }

  clickEvent(){
    this.status = !this.status;       
  }

  deleteFromLocalStorage() {
    this.loginService.deleteFromLocalStorage();
  }
}