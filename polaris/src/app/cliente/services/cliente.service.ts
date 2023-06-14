import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginService } from 'src/app/auth';
import { Aluguel } from 'src/app/models/aluguel.model';
import { ClienteLogin } from 'src/app/models/clienteLogin.model';
import { Login } from 'src/app/models/login.model';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  aluguelURL = "http://localhost:44444";
  loginURL = 'http://localhost:57361';

  constructor( private http: HttpClient, private loginService: LoginService ) { }

  getAlugueisByCPFClient(cpf: string): Observable<Aluguel> {
    this.loginService.buildHeaderToken();
    const url = `${this.aluguelURL}/Alugueis/clientes?cpf=${cpf}`;
    return this.http.get<Aluguel>(url, this.loginService.httpOptions);
  }

  getAllClientesComLogin(): Observable<ClienteLogin[]> {  
    this.loginService.buildHeaderToken();  
    const url = `${this.loginURL}/Clientes`;
    return this.http.get<ClienteLogin[]>(url, this.loginService.httpOptions);
  }
  
  alterarSenha(login: Login): Observable<HttpResponse<Login>> {
    this.loginService.buildHeaderToken();
    const url = `${this.loginURL}/Logins/alterar-senha`;
    return this.http.put<Login>(url, login, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }
}


