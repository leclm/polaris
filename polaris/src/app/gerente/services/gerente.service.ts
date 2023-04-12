import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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

  addTerceirizado(terceirizado: Terceirizado): Observable<Terceirizado> {
    terceirizado.id = '000000000-0000-0000-0000-000000000000';
    return this.http.post<Terceirizado>(this.terceirizadoURL, terceirizado);
  }

  // old
  getClienteData() {
    return this.http.get('http://localhost:8283/cliente');
  }

  getAluguelData() {
    return this.http.get('http://localhost:8180/aluguel');
  }
}
