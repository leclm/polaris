import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PrestacaoServicoAtualizacao } from 'src/app/models/prestacaoServicoAtualizacao.model';
import { Servico } from 'src/app/models/servico.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { GerenteService } from '../services';
import { CustomvalidationService } from 'src/app/shared';

enum EstadoConteiner {
  Cancelado = 0,
  Disponível = 1,
  "Em Manutenção" = 2,
  Limpeza = 3,
  Locado = 4,
  Atrasado = 5,
  Reservado = 6,
  Indisponível = 7,
  "Em Vistoria" = 8
};

enum EstadoPrestacaoServico {
  Cancelado = 0,
  Finalizado = 1,
  "Em Andamento" = 2
};
@Component({
  selector: 'app-editar-prestacao-servico',
  templateUrl: './editar-prestacao-servico.component.html',
  styleUrls: ['./editar-prestacao-servico.component.scss']
})

export class EditarPrestacaoServicoComponent implements OnInit {
  public prestacaoDeServicoUuid: any;
  public prestacaoDeServicoData: any;
  public conteinerUuid!: string;
  public statusMsg!: string;
  public terceirizadosCadastrados: Terceirizado[] = [];
  public servicosCadastrados: Servico[] = [];
  public bkpDate!: string;

  public estadoConteiner = EstadoConteiner;
  public estadoPrestacaoServico = EstadoPrestacaoServico;
  public estadoConteinerSelecionado = 0;
  public estadoPrestacaoServicoSelecionada = 0;
  
  public prestacaoServicoAtualizacao: PrestacaoServicoAtualizacao = {
    prestacaoDeServicoUuid: '',
    dataProcedimento: '',
    estadoPrestacaoServico: 0,
    comentario: '',
  }
    
  constructor( private CustomvalidationService: CustomvalidationService, private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.prestacaoDeServicoUuid = this.activatedRoute.snapshot.params['id']; 
    this.getAllPrestacaoServicos();
    this.getPrestacaoServicoById();    
  }

  public dataVar = this.prestacaoServicoAtualizacao.dataProcedimento;

  valuechange(date: any) {
    let day: any;
    let month: any;
    if((JSON.stringify(date.day).length)==1){
      day = "0"+JSON.stringify(date.day)
    } else {day = date.day}
    if((JSON.stringify(date.month).length)==1){
      month = "0"+JSON.stringify(date.month)
    } else {month = date.month}
    this.prestacaoServicoAtualizacao.dataProcedimento = `${date.year}-${month}-${day}`;
    this.dataVar = `${date.day}-${date.month}-${date.year}`;
  }

  editar() {
    this.prestacaoServicoAtualizacao.prestacaoDeServicoUuid = this.prestacaoDeServicoUuid;
    this.prestacaoServicoAtualizacao.estadoPrestacaoServico = parseInt(this.estadoPrestacaoServicoSelecionada.toString());
    this.alteraDisponibilidadeConteiner();

    if ( this.prestacaoServicoAtualizacao.dataProcedimento.charAt(2) === '-' ) {
      this.bkpDate = this.prestacaoServicoAtualizacao.dataProcedimento 
      this.prestacaoServicoAtualizacao.dataProcedimento = this.convertDateToMakePut(this.prestacaoServicoAtualizacao.dataProcedimento);
    } 
      
    this.gerenteService.alterarEstadoPrestacaoServico(this.prestacaoServicoAtualizacao).subscribe(
      (response: HttpResponse<PrestacaoServicoAtualizacao>) => {   
        if (response.status === 200 || response.status === 201) {
          this.statusMsg = 'success';
          this.prestacaoServicoAtualizacao.dataProcedimento = this.bkpDate;
          console.log('Put request successful');
        } else {
          console.log('Put request failed');
        }
      },
      (error) => {
        console.error('Error:', error);
        this.statusMsg = 'fail';
      }
    );
  }

  getAllPrestacaoServicos() {
    this.gerenteService.getAllPrestacaoServicos().subscribe( response => {
      this.prestacaoDeServicoData = response;
    })
  }

  getPrestacaoServicoById() {
    this.gerenteService.getPrestacaoServicoById(this.prestacaoDeServicoUuid).subscribe( response => {
      this.prestacaoServicoAtualizacao.dataProcedimento = response.dataProcedimento;
      let dataNasc = this.prestacaoServicoAtualizacao.dataProcedimento;
      let dataArr = dataNasc.split("T");
      dataArr = dataArr[0].split("-")
      this.prestacaoServicoAtualizacao.dataProcedimento = `${dataArr[2]}-${dataArr[1]}-${dataArr[0]}`;
      this.dataVar = this.prestacaoServicoAtualizacao.dataProcedimento;

      this.prestacaoServicoAtualizacao.estadoPrestacaoServico = response.estadoPrestacaoServico;
      this.prestacaoServicoAtualizacao.comentario = this.CustomvalidationService.camelize(response.comentario);
      
      this.estadoPrestacaoServicoSelecionada = this.prestacaoServicoAtualizacao.estadoPrestacaoServico;      
      
      this.estadoConteinerSelecionado = response.conteiner.estado;        
      this.conteinerUuid = response.conteiner.conteinerUuid;
      this.getConteinerUuid(this.conteinerUuid);
    })
  } 

  getConteinerUuid(conteinerUuid: string) {
    return this.conteinerUuid = conteinerUuid;
  }

  alteraDisponibilidadeConteiner() {
    this.gerenteService.alteraDisponibilidadeConteiner(this.conteinerUuid, this.estadoConteinerSelecionado).subscribe();
  }

  convertDateToMakePut(dateString: string): string {
    const parts = dateString.split('-');
    const year = parts[2];
    const month = parts[1];
    const day = parts[0];
    const isoDate = `${year}-${month}-${day}T00:00:00.000Z`;
    return isoDate;
  }

  // Popula EstadoConteiner e EstadoPrestacaoServico dropdown
  public enumPrestacaoServicoLength = Object.keys(this.estadoPrestacaoServico).length / 2;
  fakeArrayPrestacaoServico = new Array(this.enumPrestacaoServicoLength);

  public enumConteinerLength = Object.keys(this.estadoConteiner).length / 2;
  fakeArrayConteiner = new Array(this.enumConteinerLength);
}
