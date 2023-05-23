import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Aluguel } from 'src/app/models/aluguel.model';
import { Categoria } from 'src/app/models/categoria.model';
import { Cliente } from 'src/app/models/cliente.model';
import { ClienteLogin } from 'src/app/models/clienteLogin.model';
import { Conteiner } from 'src/app/models/conteiner.model';
import { ConteinerEstado } from 'src/app/models/conteinerEstado.model';
import { Login } from 'src/app/models/login.model';
import { LoginAcesso } from 'src/app/models/loginAcesso.model';
import { PrestacaoServico } from 'src/app/models/prestacaoServico.model';
import { PrestacaoServicoAtualizacao } from 'src/app/models/prestacaoServicoAtualizacao.model';
import { PrestacaoServicoEstado } from 'src/app/models/prestacaoServicoEstado.model';
import { Servico } from 'src/app/models/servico.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Tipo } from 'src/app/models/tipo.model';

@Injectable({
  providedIn: 'root'
})
export class GerenteService {
  servicoURL = 'https://localhost:44352';
  conteinerURL = 'https://localhost:44387';
  loginURL = 'https://localhost:57361';
  aluguelURL = 'https://localhost:44444';
  
  constructor( private http: HttpClient ) { } 
  // Login 
  alterarSenha(login: Login): Observable<HttpResponse<Login>> {
    const url = `${this.loginURL}/Logins/alterar-senha`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.put<Login>(url, login, { headers, observe: 'response' });
  }

  alterarStatusLoginCliente(uuid: string): Observable<HttpResponse<Login>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.loginURL}/Logins/alterar-status/${uuid}/false`;
    return this.http.put<Login>(url, null, { headers, observe: 'response' });
  }

  efetuarLogin(login: LoginAcesso): Observable<HttpResponse<LoginAcesso>> {
    const url = `${this.loginURL}/Logins/logar`;
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<LoginAcesso>(url, login, { headers, observe: 'response' });
  }

  // Cliente
  addCliente(cliente: Cliente): Observable<HttpResponse<Cliente>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.loginURL}/Clientes`;
    return this.http.post<Cliente>(url, cliente, { headers, observe: 'response' });
  }

  getAllClientes(): Observable<Cliente[]> {
    const url = `${this.loginURL}/Clientes`;
    return this.http.get<Cliente[]>(url);
  }

  getAllClientesAtivos(): Observable<Cliente[]> {
    const url = `${this.loginURL}/Clientes/clientes-ativos`;
    return this.http.get<Cliente[]>(url);
  } 

  getClienteById(id: string): Observable<Cliente> {
    const url = `${this.loginURL}/Clientes/${id}`;
    return this.http.get<Cliente>(url);
  }
  
  getClienteByIdLogin(id: string): Observable<ClienteLogin> {
    const url = `${this.loginURL}/Clientes/${id}`;
    return this.http.get<ClienteLogin>(url);
  }

  editarCliente(cliente: Cliente): Observable<HttpResponse<Cliente>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.loginURL}/Clientes`;
    return this.http.put<Cliente>(url, cliente, { headers, observe: 'response' });
  }

  deleteCliente(uuid: string): Observable<HttpResponse<Cliente>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.loginURL}/Clientes/alterar-status/${uuid}/false`;
    return this.http.put<Cliente>(url, null, { headers, observe: 'response' });
  }

  // Terceirizado
  getAllTerceirizados(): Observable<Terceirizado[]> {
    const url = `${this.servicoURL}/Terceirizados`;
    return this.http.get<Terceirizado[]>(url);
  }

  getAllTerceirizadosAtivos(): Observable<Terceirizado[]> {
    const url = `${this.servicoURL}/Terceirizados/terceirizados-ativos`;
    return this.http.get<Terceirizado[]>(url);
  }  

  getTerceirizadoById(id: string): Observable<Terceirizado> {
    const url = `${this.servicoURL}/Terceirizados/${id}`;
    return this.http.get<Terceirizado>(url);
  }
  
  addTerceirizado(terceirizado: Terceirizado): Observable<HttpResponse<Terceirizado>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.servicoURL}/Terceirizados`;
    return this.http.post<Terceirizado>(url, terceirizado, { headers, observe: 'response' });
  }
  
  editarTerceirizado(terceirizado: Terceirizado): Observable<HttpResponse<Terceirizado>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.servicoURL}/Terceirizados`;
    return this.http.put<Terceirizado>(url, terceirizado, { headers, observe: 'response' });
  }

  deleteTerceirizado(uuid: string): Observable<HttpResponse<Terceirizado>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.servicoURL}/Terceirizados/alterar-status/${uuid}/false`;
    return this.http.put<Terceirizado>(url, null, { headers, observe: 'response' });
  }

  // Serviços
  addServico(servico: Servico): Observable<HttpResponse<Servico>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.servicoURL}/servicos`;
    return this.http.post<Servico>(url, servico, { headers, observe: 'response' });
  }

  getAllServicosAtivos(): Observable<Servico[]> {
    const url = `${this.servicoURL}/servicos/servicos-ativos`;
    return this.http.get<Servico[]>(url);
  }

  getAllServicos(): Observable<Servico[]> {
    const url = `${this.servicoURL}/servicos`;
    return this.http.get<Servico[]>(url);
  }

  getServicoById(id: string): Observable<Servico> {
    const url = `${this.servicoURL}/servicos/${id}`;
    return this.http.get<Servico>(url);
  }

  editarServico(servico: Servico): Observable<HttpResponse<Servico>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.servicoURL}/servicos`;
    return this.http.put<Servico>(url, servico, { headers, observe: 'response' });
  }

  deleteServico(uuid: string): Observable<HttpResponse<Servico>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.servicoURL}/servicos/alterar-status/${uuid}/false`;
    return this.http.put<Servico>(url, null, { headers, observe: 'response' });
  }

  // Prestação de Serviços
  getAllPrestacaoServicos(): Observable<PrestacaoServico[]> {
    const url = `${this.conteinerURL}/PrestacoesServicos`;
    return this.http.get<PrestacaoServico[]>(url);
  }

  getPrestacaoServicoById(id: string): Observable<PrestacaoServicoEstado> {
    const url = `${this.conteinerURL}/PrestacoesServicos/${id}`;
    return this.http.get<PrestacaoServicoEstado>(url);
  }

  getPrestacaoServicoByConteiner(id: string): Observable<PrestacaoServicoEstado> {
    const url = `${this.conteinerURL}/PrestacoesServicos/Conteiner/${id}`;
    return this.http.get<PrestacaoServicoEstado>(url);
  }
  
  addPrestacaoServico(prestacaoServico: PrestacaoServico): Observable<HttpResponse<PrestacaoServico>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/PrestacoesServicos`;
    return this.http.post<PrestacaoServico>(url, prestacaoServico, { headers, observe: 'response' });
  }
  
  alterarEstadoPrestacaoServico(prestacaoServicoAtualizacao: PrestacaoServicoAtualizacao): Observable<HttpResponse<PrestacaoServicoAtualizacao>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/PrestacoesServicos/alterar-estado`;
    return this.http.put<PrestacaoServicoAtualizacao>(url, prestacaoServicoAtualizacao, { headers, observe: 'response' });
  }

  // Categoria
  getAllCategorias(): Observable<Categoria[]> {
    const url = `${this.conteinerURL}/categoriasconteineres`;
    return this.http.get<Categoria[]>(url);
  }

  getAllCategoriasAtivas(): Observable<Categoria[]> {
    const url = `${this.conteinerURL}/categoriasconteineres/categorias-ativas`;
    return this.http.get<Categoria[]>(url);
  }

  getCategoriaById(id: string): Observable<Categoria> {
    const url = `${this.conteinerURL}/categoriasconteineres/${id}`;
    return this.http.get<Categoria>(url);
  }

  addCategoria(categoria: Categoria): Observable<HttpResponse<Categoria>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/categoriasconteineres`;
    return this.http.post<Categoria>(url, categoria, { headers, observe: 'response' });
  }

  editarCategoria(categoria: Categoria): Observable<HttpResponse<Categoria>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/categoriasconteineres`;
    return this.http.put<Categoria>(url, categoria, { headers, observe: 'response' });
  }

  deleteCategoria(uuid: string): Observable<HttpResponse<Categoria>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/categoriasconteineres/alterar-status/${uuid}/false`;
    return this.http.put<Categoria>(url, null, { headers, observe: 'response' });
  }

  // Tipo
  getAllTipos(): Observable<Tipo[]> {
    const url = `${this.conteinerURL}/tiposconteineres`;
    return this.http.get<Tipo[]>(url);
  }

  getAllTiposAtivos(): Observable<Tipo[]> {
    const url = `${this.conteinerURL}/tiposconteineres/tipos-ativos`;
    return this.http.get<Tipo[]>(url);
  }

  getTipoById(id: string): Observable<Tipo> {
    const url = `${this.conteinerURL}/tiposconteineres/${id}`;
    return this.http.get<Tipo>(url);
  }

  addTipo(tipo: Tipo): Observable<HttpResponse<Tipo>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/tiposconteineres`;
    return this.http.post<Tipo>(url, tipo, { headers, observe: 'response' });
  }

  editarTipo(tipo: Tipo): Observable<HttpResponse<Tipo>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/tiposconteineres`;
    return this.http.put<Tipo>(url, tipo, { headers, observe: 'response' });
  }

  deleteTipo(uuid: string): Observable<HttpResponse<Tipo>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/tiposconteineres/alterar-status/${uuid}/false`;
    return this.http.put<Tipo>(url, null, { headers, observe: 'response' });
  }

  // Contêiner
  getAllConteineres(): Observable<Conteiner[]> {
    const url = `${this.conteinerURL}/Conteineres`;
    return this.http.get<Conteiner[]>(url);
  }

  getAllConteineresAtivos(): Observable<Conteiner[]> {
    const url = `${this.conteinerURL}/Conteineres/conteineres-ativos`;
    return this.http.get<Conteiner[]>(url);
  }

  getConteinerById(id: string): Observable<Conteiner> {
    const url = `${this.conteinerURL}/Conteineres/${id}`;
    return this.http.get<Conteiner>(url);
  }

  getConteinerByIdEstado(id: string): Observable<ConteinerEstado> {
    const url = `${this.conteinerURL}/Conteineres/${id}`;
    return this.http.get<ConteinerEstado>(url);
  }

  getConteineresByTipoCategoria(categoriaUuid: string, tipoUuid: string): Observable<Conteiner[]> {
    const url = `${this.conteinerURL}/Conteineres/conteineres-ativos-disponiveis/categoria/${categoriaUuid}/tipo/${tipoUuid}`;
    return this.http.get<Conteiner[]>(url);
  }

  addConteiner(conteiner: Conteiner): Observable<HttpResponse<Conteiner>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/Conteineres`;
    return this.http.post<Conteiner>(url, conteiner, { headers, observe: 'response' });
  }

  putConteiner(conteiner: Conteiner): Observable<HttpResponse<Conteiner>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/Conteineres`;
    return this.http.put<Conteiner>(url, conteiner, { headers, observe: 'response' });
  }

  deleteConteiner(uuid: string): Observable<HttpResponse<Conteiner>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/Conteineres/alterar-status/${uuid}/false`;
    return this.http.put<Conteiner>(url, null, { headers, observe: 'response' });
  }

  alteraDisponibilidadeConteiner(uuid: string, estado: any): Observable<HttpResponse<ConteinerEstado>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.conteinerURL}/Conteineres/alterar-disponibilidade/${uuid}/${estado}`;
    return this.http.put<ConteinerEstado>(url, estado, { headers, observe: 'response' });
  }

  // Aluguel
  addAluguel(aluguel: Aluguel): Observable<HttpResponse<Aluguel>> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${this.aluguelURL}/alugueis`;
    return this.http.post<Aluguel>(url, aluguel, { headers, observe: 'response' });
  }

  // old
  getAluguelData() {
    return this.http.get('http://localhost:8180/aluguel');
  }
}
