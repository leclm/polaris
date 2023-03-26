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
}
