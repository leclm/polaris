import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Categoria } from 'src/app/models/categoria.model';
import { Servico } from 'src/app/models/servico.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Tipo } from 'src/app/models/tipo.model';

@Injectable({
  providedIn: 'root'
})
export class GerenteService {
  allTerceirizadosURL = 'http://localhost:44352/Terceirizados';
  terceirizadoAtivosURL = 'http://localhost:44352/Terceirizados/terceirizados-ativos';
  inativaTerceririzado = 'http://localhost:44352/Terceirizados/alterar-status/';
  
  servicoURL = 'http://localhost:44352/servicos';
  allCategoriasURL = 'http://localhost:44387/CategoriasConteineres';
  allTiposURL = 'http://localhost:44387/TiposConteineres';
  conteinerURL = 'https://localhost:44387/Conteineres';

  constructor( private http: HttpClient ) { } 
  
  // Terceirizado
  getAllTerceirizadosAtivos(): Observable<Terceirizado[]> {
    return this.http.get<Terceirizado[]>(this.terceirizadoAtivosURL);
  }

  getAllTerceirizados(): Observable<Terceirizado[]> {
    return this.http.get<Terceirizado[]>(this.allTerceirizadosURL);
  }

  getTerceirizadoById(id: string): Observable<Terceirizado> {
    const terceirizadoByIdURL = `${this.allTerceirizadosURL}/${id}`;
    return this.http.get<Terceirizado>(terceirizadoByIdURL);
  }

  putTerceirizado(terceirizado: Terceirizado): Observable<HttpResponse<Terceirizado>> {
    const url = this.allTerceirizadosURL;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<Terceirizado>(url, terceirizado, { headers, observe: 'response' });
  }
  
  addTerceirizado(terceirizado: Terceirizado): Observable<HttpResponse<Terceirizado>> {
    const url = this.allTerceirizadosURL;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Terceirizado>(url, terceirizado, { headers, observe: 'response' });
  }

  deleteTerceirizado(id: string, status: string): Observable<Terceirizado> {
    const inativaTerceririzado = `${this.inativaTerceririzado}/${id}/${status}`;
    return this.http.delete<Terceirizado>(inativaTerceririzado);
  }

  // Categoria
  getAllCategorias(): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this.allCategoriasURL);
  }

  addCategoria(categoria: Categoria): Observable<HttpResponse<Categoria>> {
    const url = this.allCategoriasURL;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Categoria>(url, categoria, { headers, observe: 'response' });
  }

  // Tipo
  getAllTipos(): Observable<Tipo[]> {
    return this.http.get<Tipo[]>(this.allTiposURL);
  }

  addTipo(tipo: Tipo): Observable<HttpResponse<Tipo>> {
    const url = this.allTiposURL;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Tipo>(url, tipo, { headers, observe: 'response' });
  }


  // Serviço
  getAllServicos(): Observable<Servico[]> {
    return this.http.get<Servico[]>(this.servicoURL);
  }

  // old
  getClienteData() {
    return this.http.get('http://localhost:8283/cliente');
  }

  getAluguelData() {
    return this.http.get('http://localhost:8180/aluguel');
  }
  
  /*updateTerceirizado(terceirizado: Terceirizado): Observable<Terceirizado> {
    const url = `${this.allTerceirizadosURL}`;
    return this.http.put<Terceirizado>(url, terceirizado);
  }*/
}
