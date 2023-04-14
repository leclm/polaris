import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Servico } from 'src/app/models/servico.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';

@Injectable({
  providedIn: 'root'
})
export class GerenteService {
  terceirizadoURL = 'http://localhost:44352/terceirizados';
  servicoURL = 'http://localhost:44352/servicos';

  constructor( private http: HttpClient ) { } 
  // curso post
  getAllServicos(): Observable<Servico[]> {
    return this.http.get<Servico[]>(this.servicoURL);
  }

  getAllTerceirizados(): Observable<Terceirizado[]> {
    return this.http.get<Terceirizado[]>(this.terceirizadoURL);
  }

  addTerceirizado(terceirizado: Terceirizado): Observable<HttpResponse<Terceirizado>> {
    const url = this.terceirizadoURL;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Terceirizado>(url, terceirizado, { headers, observe: 'response' });
  }

  // old
  getClienteData() {
    return this.http.get('http://localhost:8283/cliente');
  }

  getAluguelData() {
    return this.http.get('http://localhost:8180/aluguel');
  }
}
