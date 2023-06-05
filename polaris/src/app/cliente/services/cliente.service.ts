import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginService } from 'src/app/auth';
import { Aluguel } from 'src/app/models/aluguel.model';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  aluguelURL = "http://localhost:44444"

  constructor( private http: HttpClient, private loginService: LoginService ) { }

  getAlugueisByCPFClient(cpf: string): Observable<Aluguel> {
    this.loginService.buildHeaderToken();
    const url = `${this.aluguelURL}/Alugueis/clientes?cpf=${cpf}`;
    return this.http.get<Aluguel>(url, this.loginService.httpOptions);
  }

  getAluguelData() {
    return this.http.get('http://localhost:8180/aluguel');
  }
}


