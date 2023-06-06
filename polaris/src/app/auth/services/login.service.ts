import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { LoginAcesso } from 'src/app/models/loginAcesso.model';

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  loginURL = 'http://localhost:57361';
  token: string | null = null;
  role: string = '';
  loginUuid: string = '';  
  usuario: string = '';  
  httpOptions = { headers: new HttpHeaders({ "Content-Type": "application/json"})};
  
  private loginStatus = new BehaviorSubject<boolean>(this.checkLoginStatus());
  
  constructor( private http: HttpClient ) { }

  saveTokenToLocalStorage(token: string): void {
    localStorage.setItem('jwt', token);
  }
  
  deleteFromLocalStorage(): void {
    const key = 'jwt';

    if (localStorage.getItem(key)) {
      this.loginStatus.next(false);
      localStorage.removeItem(key);
      localStorage.setItem('loginStatus', '0');
      localStorage.removeItem('loginUuid');
      localStorage.removeItem('usuario');
      console.log('Key and value removed from local storage.');
    } else {
      console.log('Key not found in local storage.');
    }
  }

  buildHeaderToken() {    
    this.token = localStorage.getItem('jwt');
    if (this.token !== null) {
      this.httpOptions = { headers: new HttpHeaders({ "Authorization": "Bearer " + this.token, "Content-Type": "application/json"})};
    } else {
      console.log('Token not found in local storage.');
    }
  }
  
  efetuarLogin(login: LoginAcesso): Observable<HttpResponse<LoginAcesso>> {
    this.buildHeaderToken();
    const url = `${this.loginURL}/Logins/logar`;
    return this.http.post<LoginAcesso>(url, login, { headers: this.httpOptions.headers, observe: 'response' })
      .pipe(
        tap((response: HttpResponse<LoginAcesso>) => {          
          this.role = response.body?.role ?? '';
          this.loginUuid = response.body?.loginUuid ?? '';
          this.usuario = response.body?.usuario ?? '';
          
          this.loginStatus.next(true);     
          localStorage.setItem('loginStatus', '1');
          localStorage.setItem('loginUuid', this.loginUuid);
          localStorage.setItem('usuario', this.usuario); 
          const token = response.body?.token;
          if (token) {
            this.saveTokenToLocalStorage(token);
            return token;
          }
          return null;
        })
      );
  }

  checkLoginStatus(): boolean {
    let loginCookie = localStorage.getItem("loginStatus");
    if (loginCookie == "1") {
      return true;
    }
    return false;
  }

  get isLoggesIn() 
  {
      return this.loginStatus.asObservable();
  }
}
