import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { LoginAcesso } from 'src/app/models/loginAcesso.model';

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  loginURL = 'http://localhost:57361';
  token: string | null = null;
  isGerente: boolean | null = null;
  loginUuid: string = '';
  httpOptions = { headers: new HttpHeaders({ "Content-Type": "application/json"})};
  
  constructor( private http: HttpClient ) { }

  saveTokenToLocalStorage(token: string): void {
    localStorage.setItem('jwt', token);
  }
  
  deleteFromLocalStorage(): void {
    const key = 'jwt';

    if (localStorage.getItem(key)) {
      localStorage.removeItem(key);
      console.log('Key and value removed from local storage.');
    } else {
      console.log('Key not found in local storage.');
    }
  }

  buildHeaderToken() {    
    this.token = localStorage.getItem('jwt');
    this.httpOptions = { headers: new HttpHeaders({ "Authorization": "Bearer " + this.token, "Content-Type": "application/json"})};
  }
  
  efetuarLogin(login: LoginAcesso): Observable<HttpResponse<LoginAcesso>> {
    this.buildHeaderToken();
    const url = `${this.loginURL}/Logins/logar`;
    return this.http.post<LoginAcesso>(url, login, { headers: this.httpOptions.headers, observe: 'response' })
      .pipe(
        tap((response: HttpResponse<LoginAcesso>) => {
          this.isGerente = response.body?.isGerente ?? null;
          this.loginUuid = response.body?.loginUuid ?? '';
          console.log(response.body);
          const token = response.body?.token;
          if (token) {
            this.saveTokenToLocalStorage(token);
            return token;
          }
          return null;
        })
      );
  }
}
