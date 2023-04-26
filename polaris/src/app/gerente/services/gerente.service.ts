import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Categoria } from 'src/app/models/categoria.model';
import { Conteiner } from 'src/app/models/conteiner.model';
import { Servico } from 'src/app/models/servico.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Tipo } from 'src/app/models/tipo.model';

@Injectable({
  providedIn: 'root'
})
export class GerenteService {
  terceirizadoURL = 'http://localhost:44352/terceirizados';
  servicoURL = 'http://localhost:44352/servicos';
  categoriaURL = 'http://localhost:44387/categoriasconteineres';
  tipoURL = 'http://localhost:44387/tiposconteineres';
  conteinerURL = 'http://localhost:44387/Conteineres';

  constructor( private http: HttpClient ) { } 
  
  // Terceirizado
  getAllTerceirizados(): Observable<Terceirizado[]> {
    return this.http.get<Terceirizado[]>(this.terceirizadoURL);
  }

  getAllTerceirizadosAtivos(): Observable<Terceirizado[]> {
    const url = `${this.terceirizadoURL}/terceirizados-ativos`;
    return this.http.get<Terceirizado[]>(url);
  }  

  getTerceirizadoById(id: string): Observable<Terceirizado> {
    const url = `${this.terceirizadoURL}/${id}`;
    return this.http.get<Terceirizado>(url);
  }
  
  addTerceirizado(terceirizado: Terceirizado): Observable<HttpResponse<Terceirizado>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Terceirizado>(this.terceirizadoURL, terceirizado, { headers, observe: 'response' });
  }
  
  editarTerceirizado(terceirizado: Terceirizado): Observable<HttpResponse<Terceirizado>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<Terceirizado>(this.terceirizadoURL, terceirizado, { headers, observe: 'response' });
  }

  deleteTerceirizado(uuid: string): Observable<HttpResponse<Terceirizado>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.terceirizadoURL}/alterar-status/${uuid}/false`;
    return this.http.put<Terceirizado>(url, null, { headers, observe: 'response' });
  }

  // Categoria
  getAllCategorias(): Observable<Categoria[]> {
    return this.http.get<Categoria[]>(this.categoriaURL);
  }

  getAllCategoriasAtivas(): Observable<Categoria[]> {
    const url = `${this.categoriaURL}/categorias-ativas`;
    return this.http.get<Categoria[]>(url);
  }

  getCategoriaById(id: string): Observable<Categoria> {
    const url = `${this.categoriaURL}/${id}`;
    return this.http.get<Categoria>(url);
  }

  addCategoria(categoria: Categoria): Observable<HttpResponse<Categoria>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Categoria>(this.categoriaURL, categoria, { headers, observe: 'response' });
  }

  editarCategoria(categoria: Categoria): Observable<HttpResponse<Categoria>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<Categoria>(this.categoriaURL, categoria, { headers, observe: 'response' });
  }

  deleteCategoria(uuid: string): Observable<HttpResponse<Categoria>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.categoriaURL}/alterar-status/${uuid}/false`;
    return this.http.put<Categoria>(url, null, { headers, observe: 'response' });
  }

  // Tipo
  getAllTipos(): Observable<Tipo[]> {
    return this.http.get<Tipo[]>(this.tipoURL);
  }

  getAllTiposAtivos(): Observable<Tipo[]> {
    const url = `${this.tipoURL}/tipos-ativos`;
    return this.http.get<Tipo[]>(url);
  }

  getTipoById(id: string): Observable<Tipo> {
    const url = `${this.tipoURL}/${id}`;
    return this.http.get<Tipo>(url);
  }

  addTipo(tipo: Tipo): Observable<HttpResponse<Tipo>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Tipo>(this.tipoURL, tipo, { headers, observe: 'response' });
  }

  editarTipo(tipo: Tipo): Observable<HttpResponse<Tipo>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<Tipo>(this.tipoURL, tipo, { headers, observe: 'response' });
  }

  deleteTipo(uuid: string): Observable<HttpResponse<Tipo>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.tipoURL}/alterar-status/${uuid}/false`;
    return this.http.put<Tipo>(url, null, { headers, observe: 'response' });
  }

  // Contêiner
  getAllConteineres(): Observable<Conteiner[]> {
    return this.http.get<Conteiner[]>(this.conteinerURL);
  }

  getAllConteineresAtivos(): Observable<Conteiner[]> {
    const url = `${this.conteinerURL}/conteineres-ativos`;
    return this.http.get<Conteiner[]>(url);
  }

  getConteinerById(id: string): Observable<Conteiner> {
    const url = `${this.conteinerURL}/${id}`;
    return this.http.get<Conteiner>(url);
  }

  addConteiner(conteiner: Conteiner): Observable<HttpResponse<Conteiner>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<Conteiner>(this.conteinerURL, conteiner, { headers, observe: 'response' });
  }

  putConteiner(conteiner: Conteiner): Observable<HttpResponse<Conteiner>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<Conteiner>(this.conteinerURL, conteiner, { headers, observe: 'response' });
  }

  deleteConteiner(uuid: string): Observable<HttpResponse<Conteiner>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/alterar-status/${uuid}/false`;
    return this.http.put<Conteiner>(url, null, { headers, observe: 'response' });
  }

  alteraDisponibilidadeConteiner(uuid: string, estado: number): Observable<HttpResponse<Conteiner>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/alterar-disponibilidade/${uuid}/${estado}`;
    return this.http.put<Conteiner>(url, null, { headers, observe: 'response' });
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
}
