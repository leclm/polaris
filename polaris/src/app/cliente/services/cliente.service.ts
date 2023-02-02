import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private _http:HttpClient) { }

  getAuthData() {
    return this._http.get('http://localhost:8280/auth');
  }

  getAluguelData() {
    return this._http.get('http://localhost:8180/aluguel');
  }
}
