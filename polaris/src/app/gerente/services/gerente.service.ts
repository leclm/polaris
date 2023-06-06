import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Aluguel } from 'src/app/models/aluguel.model';
import { AluguelEstado } from 'src/app/models/aluguelEstado.model';
import { Categoria } from 'src/app/models/categoria.model';
import { Cliente } from 'src/app/models/cliente.model';
import { ClienteEdicao } from 'src/app/models/clienteEdicao.model';
import { ClienteLogin } from 'src/app/models/clienteLogin.model';
import { Conteiner } from 'src/app/models/conteiner.model';
import { ConteinerEstado } from 'src/app/models/conteinerEstado.model';
import { Login } from 'src/app/models/login.model';
import { PrestacaoServico } from 'src/app/models/prestacaoServico.model';
import { PrestacaoServicoAtualizacao } from 'src/app/models/prestacaoServicoAtualizacao.model';
import { PrestacaoServicoEstado } from 'src/app/models/prestacaoServicoEstado.model';
import { Servico } from 'src/app/models/servico.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Tipo } from 'src/app/models/tipo.model';
import { LoginService } from 'src/app/auth';

@Injectable({
  providedIn: 'root'
})

export class GerenteService {
  servicoURL = 'http://localhost:44352';
  conteinerURL = 'http://localhost:44387';
  loginURL = 'http://localhost:57361';
  aluguelURL = 'http://localhost:44444';
  
  constructor( private http: HttpClient, private loginService: LoginService ) { } 
  // Login 
  alterarStatusLoginCliente(uuid: string): Observable<HttpResponse<Login>> {
    this.loginService.buildHeaderToken();
    const url = `${this.loginURL}/Logins/alterar-status/${uuid}/false`;
    return this.http.put<Login>(url, null, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  // Cliente
  addCliente(cliente: Cliente): Observable<HttpResponse<Cliente>> {
    this.loginService.buildHeaderToken();
    const url = `${this.loginURL}/Clientes`;
    return this.http.post<Cliente>(url, cliente, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  getAllClientes(): Observable<Cliente[]> {  
    this.loginService.buildHeaderToken();  
    const url = `${this.loginURL}/Clientes`;
    return this.http.get<Cliente[]>(url, this.loginService.httpOptions);
  }

  getAllClientesAtivos(): Observable<Cliente[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.loginURL}/Clientes/clientes-ativos`;
    return this.http.get<Cliente[]>(url, this.loginService.httpOptions);
  } 

  getClienteById(id: string): Observable<Cliente> {
    this.loginService.buildHeaderToken();
    const url = `${this.loginURL}/Clientes/${id}`;
    return this.http.get<Cliente>(url, this.loginService.httpOptions);
  }
  
  // arrumar isso, esse endpoint nao existe
  getClienteByIdLogin(clienteUuid: string): Observable<ClienteLogin> {
    this.loginService.buildHeaderToken();
    const url = `${this.loginURL}/Clientes/${clienteUuid}`;
    return this.http.get<ClienteLogin>(url, this.loginService.httpOptions);
  }

  editarCliente(cliente: ClienteEdicao): Observable<HttpResponse<ClienteEdicao>> {
    this.loginService.buildHeaderToken();
    const url = `${this.loginURL}/Clientes`;
    return this.http.put<ClienteEdicao>(url, cliente, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  deleteCliente(uuid: string): Observable<HttpResponse<Cliente>> {
    this.loginService.buildHeaderToken();
    const url = `${this.loginURL}/Clientes/alterar-status/${uuid}/false`;
    return this.http.put<Cliente>(url, null, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  // Terceirizado
  getAllTerceirizados(): Observable<Terceirizado[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/Terceirizados`;
    return this.http.get<Terceirizado[]>(url, this.loginService.httpOptions);
  }

  getAllTerceirizadosAtivos(): Observable<Terceirizado[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/Terceirizados/terceirizados-ativos`;
    return this.http.get<Terceirizado[]>(url, this.loginService.httpOptions);
  }  

  getTerceirizadoById(id: string): Observable<Terceirizado> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/Terceirizados/${id}`;
    return this.http.get<Terceirizado>(url, this.loginService.httpOptions);
  }
  
  addTerceirizado(terceirizado: Terceirizado): Observable<HttpResponse<Terceirizado>> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/Terceirizados`;
    return this.http.post<Terceirizado>(url, terceirizado, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }
  
  editarTerceirizado(terceirizado: Terceirizado): Observable<HttpResponse<Terceirizado>> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/Terceirizados`;
    return this.http.put<Terceirizado>(url, terceirizado, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  deleteTerceirizado(uuid: string): Observable<HttpResponse<Terceirizado>> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/Terceirizados/alterar-status/${uuid}/false`;
    return this.http.put<Terceirizado>(url, null, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  // Serviços
  addServico(servico: Servico): Observable<HttpResponse<Servico>> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/servicos`;
    return this.http.post<Servico>(url, servico, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  getAllServicosAtivos(): Observable<Servico[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/servicos/servicos-ativos`;
    return this.http.get<Servico[]>(url, this.loginService.httpOptions);
  }

  getAllServicos(): Observable<Servico[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/servicos`;
    return this.http.get<Servico[]>(url, this.loginService.httpOptions);
  }

  getServicoById(id: string): Observable<Servico> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/servicos/${id}`;
    return this.http.get<Servico>(url, this.loginService.httpOptions);
  }

  editarServico(servico: Servico): Observable<HttpResponse<Servico>> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/servicos`;
    return this.http.put<Servico>(url, servico, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  deleteServico(uuid: string): Observable<HttpResponse<Servico>> {
    this.loginService.buildHeaderToken();
    const url = `${this.servicoURL}/servicos/alterar-status/${uuid}/false`;
    return this.http.put<Servico>(url, null, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  // Prestação de Serviços
  getAllPrestacaoServicos(): Observable<PrestacaoServico[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/PrestacoesServicos`;
    return this.http.get<PrestacaoServico[]>(url, this.loginService.httpOptions);
  }

  getPrestacaoServicoById(id: string): Observable<PrestacaoServicoEstado> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/PrestacoesServicos/${id}`;
    return this.http.get<PrestacaoServicoEstado>(url, this.loginService.httpOptions);
  }

  getPrestacaoServicoByConteiner(id: string): Observable<PrestacaoServicoEstado> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/PrestacoesServicos/Conteiner/${id}`;
    return this.http.get<PrestacaoServicoEstado>(url, this.loginService.httpOptions);
  }
  
  addPrestacaoServico(prestacaoServico: PrestacaoServico): Observable<HttpResponse<PrestacaoServico>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/PrestacoesServicos`;
    return this.http.post<PrestacaoServico>(url, prestacaoServico, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }
  
  alterarEstadoPrestacaoServico(prestacaoServicoAtualizacao: PrestacaoServicoAtualizacao): Observable<HttpResponse<PrestacaoServicoAtualizacao>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/PrestacoesServicos/alterar-estado`;
    return this.http.put<PrestacaoServicoAtualizacao>(url, prestacaoServicoAtualizacao, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  // Categoria
  getAllCategorias(): Observable<Categoria[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/categoriasconteineres`;
    return this.http.get<Categoria[]>(url, this.loginService.httpOptions);
  }

  getAllCategoriasAtivas(): Observable<Categoria[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/categoriasconteineres/categorias-ativas`;
    return this.http.get<Categoria[]>(url, this.loginService.httpOptions);
  }

  getCategoriaById(id: string): Observable<Categoria> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/categoriasconteineres/${id}`;
    return this.http.get<Categoria>(url, this.loginService.httpOptions);
  }

  addCategoria(categoria: Categoria): Observable<HttpResponse<Categoria>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/categoriasconteineres`;
    return this.http.post<Categoria>(url, categoria, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  editarCategoria(categoria: Categoria): Observable<HttpResponse<Categoria>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/categoriasconteineres`;
    return this.http.put<Categoria>(url, categoria, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  deleteCategoria(uuid: string): Observable<HttpResponse<Categoria>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/categoriasconteineres/alterar-status/${uuid}/false`;
    return this.http.put<Categoria>(url, null, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  // Tipo
  getAllTipos(): Observable<Tipo[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/tiposconteineres`;
    return this.http.get<Tipo[]>(url, this.loginService.httpOptions);
  }

  getAllTiposAtivos(): Observable<Tipo[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/tiposconteineres/tipos-ativos`;
    return this.http.get<Tipo[]>(url, this.loginService.httpOptions);
  }

  getTipoById(id: string): Observable<Tipo> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/tiposconteineres/${id}`;
    return this.http.get<Tipo>(url, this.loginService.httpOptions);
  }

  addTipo(tipo: Tipo): Observable<HttpResponse<Tipo>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/tiposconteineres`;
    return this.http.post<Tipo>(url, tipo, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  editarTipo(tipo: Tipo): Observable<HttpResponse<Tipo>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/tiposconteineres`;
    return this.http.put<Tipo>(url, tipo, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  deleteTipo(uuid: string): Observable<HttpResponse<Tipo>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/tiposconteineres/alterar-status/${uuid}/false`;
    return this.http.put<Tipo>(url, null, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  // Contêiner
  getAllConteineres(): Observable<Conteiner[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/Conteineres`;
    return this.http.get<Conteiner[]>(url, this.loginService.httpOptions);
  }

  getAllConteineresAtivos(): Observable<Conteiner[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/Conteineres/conteineres-ativos`;
    return this.http.get<Conteiner[]>(url, this.loginService.httpOptions);
  }

  getConteinerById(id: string): Observable<Conteiner> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/Conteineres/${id}`;
    return this.http.get<Conteiner>(url, this.loginService.httpOptions);
  }

  getConteinerByIdEstado(id: string): Observable<ConteinerEstado> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/Conteineres/${id}`;
    return this.http.get<ConteinerEstado>(url, this.loginService.httpOptions);
  }

  getConteineresByTipoCategoria(categoriaUuid: string, tipoUuid: string): Observable<Conteiner[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/Conteineres/conteineres-ativos-disponiveis/categoria/${categoriaUuid}/tipo/${tipoUuid}`;
    return this.http.get<Conteiner[]>(url, this.loginService.httpOptions);
  }

  addConteiner(conteiner: Conteiner): Observable<HttpResponse<Conteiner>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/Conteineres`;
    return this.http.post<Conteiner>(url, conteiner, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  putConteiner(conteiner: Conteiner): Observable<HttpResponse<Conteiner>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/Conteineres`;
    return this.http.put<Conteiner>(url, conteiner, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  deleteConteiner(uuid: string): Observable<HttpResponse<Conteiner>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/Conteineres/alterar-status/${uuid}/false`;
    return this.http.put<Conteiner>(url, null, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  alteraDisponibilidadeConteiner(uuid: string, estado: any): Observable<HttpResponse<ConteinerEstado>> {
    this.loginService.buildHeaderToken();
    const url = `${this.conteinerURL}/Conteineres/alterar-disponibilidade/${uuid}/${estado}`;
    return this.http.put<ConteinerEstado>(url, estado, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  // Aluguel
  addAluguel(aluguel: Aluguel): Observable<HttpResponse<Aluguel>> {
    this.loginService.buildHeaderToken();
    const url = `${this.aluguelURL}/alugueis`;
    return this.http.post<Aluguel>(url, aluguel, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  getAllAlugueis(): Observable<Aluguel[]> {
    this.loginService.buildHeaderToken();
    const url = `${this.aluguelURL}/Alugueis`;
    return this.http.get<Aluguel[]>(url, this.loginService.httpOptions);
  }

  getAluguelById(aluguelUuid: string): Observable<Aluguel> {
    this.loginService.buildHeaderToken();
    const url = `${this.aluguelURL}/Alugueis/${aluguelUuid}`;
    return this.http.get<Aluguel>(url, this.loginService.httpOptions);
  }

  alteraEstadoAluguel(aluguelUuid: string, estado: any): Observable<HttpResponse<AluguelEstado>> {
    this.loginService.buildHeaderToken();
    const url = `${this.aluguelURL}/alugueis/alterar-disponibilidade/${aluguelUuid}/${estado}`;
    return this.http.put<AluguelEstado>(url, estado, { headers: this.loginService.httpOptions.headers, observe: 'response' });
  }

  getAlugueisByCPFClient(cpf: string): Observable<Aluguel> {
    this.loginService.buildHeaderToken();
    const url = `${this.aluguelURL}/Alugueis/clientes?cpf=${cpf}`;
    return this.http.get<Aluguel>(url, this.loginService.httpOptions);
  }

  getAlugueisByConteiner(codigo: string): Observable<Aluguel> {
    this.loginService.buildHeaderToken();
    const url = `${this.aluguelURL}/Alugueis/conteineres?codigo=${codigo}`;
    return this.http.get<Aluguel>(url, this.loginService.httpOptions);
  }
}
