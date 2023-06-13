import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { Cliente } from 'src/app/models/cliente.model';
import { Endereco } from 'src/app/models/endereco.model';
import { CustomvalidationService, ViaCepService } from 'src/app/shared';
import { GerenteService } from '../services';


@Component({
  selector: 'app-manter-cliente',
  templateUrl: './manter-cliente.component.html',
  styleUrls: ['./manter-cliente.component.scss']
})
export class ManterClienteComponent implements OnInit {
  public statusMsg!: string;

  public endereco: Endereco = {
    cep: '',
    cidade: '',
    estado: '',
    logradouro: '',
    complemento: '',
    numero: NaN
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

  constructor( private viaCepService: ViaCepService, private CustomvalidationService: CustomvalidationService, private gerenteService: GerenteService ) { }

  ngOnInit(): void {

  }
  
  public dataVar = 'dd-mm-aaaa';
  public dataNotValidNotify = false;

  VerifyValidDate(){
    if(this.dataVar == 'dd-mm-aaaa'){
      this.dataNotValidNotify = true;
    } else {this.dataNotValidNotify = false;}
  }

  valuechange(date: any) {
    let day: any;
    let month: any;
    if((JSON.stringify(date.day).length)==1){
      day = "0"+JSON.stringify(date.day)
    } else {day = date.day}
    if((JSON.stringify(date.month).length)==1){
      month = "0"+JSON.stringify(date.month)
    } else {month = date.month}
    
    this.cliente.dataNascimento = `${date.year}-${month}-${day}`;
    this.dataVar = `${date.day}-${date.month}-${date.year}`;

  }

  cadastrar() {

      this.CustomvalidationService.camelize(this.cliente.nome)
      this.CustomvalidationService.camelize(this.cliente.sobrenome)
      console.log(this.cliente)

    this.gerenteService.addCliente(this.cliente).subscribe(

      (response: HttpResponse<Cliente>) => {   
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
 
  public cpfNotValid = false;
  public cepNotValid = false;
  
  validateCpf(event: any) {
    this.cpfNotValid =  this.CustomvalidationService.ValidaCpf(this.cliente.cpf)
    console.log(this.cpfNotValid)
    console.log(this.cliente)
  }

  searchAddress(event: any) {
    this.viaCepService.getAddressByCep(this.endereco.cep).subscribe(data => {
      this.endereco.cidade = data.localidade;
      this.endereco.estado = data.uf;
      this.endereco.logradouro = data.logradouro;
      if(data.uf==undefined){
        this.cepNotValid = true;
      } else{
        this.cepNotValid = false;
      }
      this.VerifyValidDate(); 
    });
  }
}
