import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GerenteService {

  constructor( private _http: HttpClient ) { }

  getClienteData() {
    return this._http.get('http://localhost:8283/cliente');
  }

  getAluguelData() {
    return this._http.get('http://localhost:8180/aluguel');
  }

  getServicoData() {
    return this._http.get('http://localhost:44352/Servicos');
  }

  getTerceirizadoData() {
    return this._http.get('http://localhost:44352/Terceirizados');
  }
}
