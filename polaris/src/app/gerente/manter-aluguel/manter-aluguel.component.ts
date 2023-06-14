import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Aluguel } from 'src/app/models/aluguel.model';
import { Categoria } from 'src/app/models/categoria.model';
import { Cliente } from 'src/app/models/cliente.model';
import { Conteiner } from 'src/app/models/conteiner.model';
import { ConteinerEstado } from 'src/app/models/conteinerEstado.model';
import { Endereco } from 'src/app/models/endereco.model';
import { Tipo } from 'src/app/models/tipo.model';
import { ViaCepService } from 'src/app/shared';
import { GerenteService } from '../services';

@Component({
  selector: 'app-manter-aluguel',
  templateUrl: './manter-aluguel.component.html',
  styleUrls: ['./manter-aluguel.component.scss']
})
export class ManterAluguelComponent implements OnInit {
  public statusMsg!: string;
  public selectedOptions: string[] = [];
  public categoriasCadastradas: Categoria[] = [];  
  public tiposCadastrados: Tipo[] = [];
  public conteineresCadastrados: Conteiner[] = [];
  public carrinho: ConteinerEstado[] = [];
  public conteinerUuid!: string;
  public clientesCadastrados: Cliente[] = [];
  public clienteUuid!: string;
  public conteinerData: any;
  public totalDays!: number;
  public valorTotalAluguel!: number;
  public cepNotValid = false;
  public dataIni = 'dd-mm-aaaa';
  public dataDev = 'dd-mm-aaaa';
  public dataIniNotValidNotify = false;
  public dataDevNotValidNotify = false;

  public endereco: Endereco = {
    cep: '',
    cidade: '',
    estado: '',
    logradouro: '',
    complemento: '',
    numero: NaN
  }

  public enderecoLocacao: Endereco = {
    cep: '',
    cidade: '',
    estado: '',
    logradouro: '',
    complemento: '',
    numero: NaN
  }

  public conteiner: Conteiner = {
    conteinerUuid: '',
    codigo: 0,
    fabricacao: '',
    fabricante: '',
    material: '',
    cor: '',
    categoria: '',
    tipo: ''
  }

  public cliente: Cliente = {
    clienteUuid: '',
    nome: '',
    sobrenome: '',
    cpf: '',
    dataNascimento: '',
    email: '',
    telefone: '',
    endereco: this.endereco
  }

  public aluguel: Aluguel = {
    dataInicio: '',
    dataDevolucao: '',
    tipoLocacao: 0,
    endereco: this.enderecoLocacao,
    clienteUuid: '',
    conteineresUuid: [],
    valorTotalAluguel: 0,
    desconto: 0
  }
  
  constructor( private viaCepService: ViaCepService, private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.getAllClientesAtivos();
    this.getAllCategoriasAtivas(); 
    this.getAllTiposAtivos();
  }
  closeDatepicker(id: { close: () => void; }){
    id.close();
  }
  valuechangeIni(date: any) {
    let day: any;
    let month: any;
    if((JSON.stringify(date.day).length)==1){
      day = "0"+JSON.stringify(date.day)
    } else {day = date.day}
    if((JSON.stringify(date.month).length)==1){
      month = "0"+JSON.stringify(date.month)
    } else {month = date.month}
    
    this.aluguel.dataInicio = `${date.year}-${month}-${day}`;
    this.dataIni = `${date.day}-${date.month}-${date.year}`;
    this.VerifyValidDate(); 
  }

  valuechangeDev(date: any) {
    let day: any;
    let month: any;

    if((JSON.stringify(date.day).length)==1){
      day = "0"+JSON.stringify(date.day)
    } else {day = date.day}
    if((JSON.stringify(date.month).length)==1){
      month = "0"+JSON.stringify(date.month)
    } else {month = date.month}
    
    this.aluguel.dataDevolucao = `${date.year}-${month}-${day}`;
    this.dataDev = `${date.day}-${date.month}-${date.year}`;
    this.VerifyValidDate(); 
  }

  VerifyValidDate(){
    if(this.dataIni == 'dd-mm-aaaa'){
      this.dataIniNotValidNotify = true;
    } else {this.dataIniNotValidNotify = false;}
    if(this.dataDev == 'dd-mm-aaaa'){
      this.dataDevNotValidNotify = true;
    } else {this.dataDevNotValidNotify = false;}
  }

  getAllClientesAtivos() {
    this.gerenteService.getAllClientesAtivos()
    .subscribe( response => {
      this.clientesCadastrados = response;
    })
  }
   
  fillClientObject(event: any) {
    this.gerenteService.getClienteById(this.clienteUuid)
    .subscribe( response => {
      this.cliente = response;
      this.aluguel.clienteUuid = response.clienteUuid;
    })
  }

  searchAddress(event: any) {
    this.viaCepService.getAddressByCep(this.enderecoLocacao.cep).subscribe(data => {
      this.enderecoLocacao.cidade = data.localidade;
      this.enderecoLocacao.estado = data.uf;
      this.enderecoLocacao.logradouro = data.logradouro;
      if(data.uf==undefined){
        this.cepNotValid = true;
      } else{
        this.cepNotValid = false;
      }    
      this.VerifyValidDate();  
    });
  }

  getAllCategoriasAtivas() {
    this.gerenteService.getAllCategoriasAtivas()
    .subscribe( response => {
      this.categoriasCadastradas = response;
    })
  }

  getAllTiposAtivos() {
    this.gerenteService.getAllTiposAtivos()
    .subscribe( response => {
      this.tiposCadastrados = response;
    })
  }

  findContainers() {
    this.gerenteService.getConteineresByTipoCategoria(this.conteiner.categoria, this.conteiner.tipo)
    .subscribe( response => {
      this.conteineresCadastrados = response;
    })
  }
 
  calculateDaysBetweenDates(startDate: Date, endDate: Date): number {
    const oneDay = 24 * 60 * 60 * 1000; // Number of milliseconds in a day
    const start = new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDate());
    const end = new Date(endDate.getFullYear(), endDate.getMonth(), endDate.getDate());
    const diffInDays = Math.round(Math.abs((start.getTime() - end.getTime()) / oneDay));
    return diffInDays;
  }

  convertStringToDate(dateString: string) {
    const dateParts = dateString.split(/[-/\.]/); // Split by "-" or "/" or "."
    const year = parseInt(dateParts[0]);
    const month = parseInt(dateParts[1]) - 1; // Subtract 1 as month index is zero-based
    const day = parseInt(dateParts[2]);
    const date = new Date(year, month, day);
    return date;
  }
  
  addConteiner(event: any) {
    this.gerenteService.getConteinerByIdEstado(this.conteinerUuid)
    .subscribe( response => {
      const existingValue = this.carrinho.find(obj => obj.conteinerUuid === response.conteinerUuid);
      if (!existingValue) {
        this.carrinho.push(response);
        this.aluguel.conteineresUuid.push(response.conteinerUuid);
        
        let dataInicio = this.convertStringToDate(this.aluguel.dataInicio);
        let dataDevolucao = this.convertStringToDate(this.aluguel.dataDevolucao);    
        this.totalDays = this.calculateDaysBetweenDates(dataInicio, dataDevolucao);

        let valorTotal = 0;
        for (const element of this.carrinho) {
          const valorDiaria = element.tipoConteiner.valorDiaria;
          const multipliedValue = valorDiaria * this.totalDays;
          valorTotal += multipliedValue;
        }
        this.aluguel.valorTotalAluguel = valorTotal;
      }
    });
  }

  removeConteiner(conteiner: string) {
    this.carrinho = this.carrinho.filter(obj => obj.conteinerUuid !== conteiner);
    this.aluguel.conteineresUuid = this.aluguel.conteineresUuid.filter(obj => obj !== conteiner);
  }
  
  cadastrar() {
    this.gerenteService.addAluguel(this.aluguel).subscribe(
      (response: HttpResponse<Aluguel>) => {   
        if (response.status === 200 || response.status === 201) {
          this.statusMsg = 'success';
          console.log('Post request successful');
        } else {
          console.log('Post request failed');
        }
      },
      (error) => {
        console.error('Error:', error);
        this.statusMsg = 'fail';
      }
    );
  }
}
