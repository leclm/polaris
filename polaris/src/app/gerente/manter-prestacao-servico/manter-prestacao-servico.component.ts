import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Conteiner } from 'src/app/models/conteiner.model';
import { PrestacaoServico } from 'src/app/models/prestacaoServico.model';
import { Servico } from 'src/app/models/servico.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { GerenteService } from '../services';

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

@Component({
  selector: 'app-manter-prestacao-servico',
  templateUrl: './manter-prestacao-servico.component.html',
  styleUrls: ['./manter-prestacao-servico.component.scss']
})
export class ManterPrestacaoServicoComponent implements OnInit {
  public statusMsg!: string;
  public terceirizadosCadastrados: Terceirizado[] = [];
  public conteineresCadastrados: Conteiner[] = [];  
  public servicosCadastrados: Servico[] = [];
  public conteinerUuid: any;
  public estadoConteiner = EstadoConteiner;
  public estadoConteinerSelecionado = 0;
  public conteinerData: any;

  public prestacaoServico: PrestacaoServico = {
    dataProcedimento: '',
    comentario: '',
    conteiner: '',
    terceirizado: '',
    servico: ''
  }
  
  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.conteinerUuid = this.activatedRoute.snapshot.params['id']; 
    this.prestacaoServico.conteiner = this.conteinerUuid;

    this.getAllConteineresAtivos(); 
    this.getAllServicosAtivos(); 
    this.getAllTerceirizadosAtivos();
    this.getConteinerById();
  }
  public dataVar = 'dd-mm-aaaa';

  valuechange(date: any) {

    let day: any;
    let month: any;
    if((JSON.stringify(date.day).length)==1){
      day = "0"+JSON.stringify(date.day)
    } else {day = date.day}
    if((JSON.stringify(date.month).length)==1){
      month = "0"+JSON.stringify(date.month)
    } else {month = date.month}
    
    this.prestacaoServico.dataProcedimento = `${date.year}-${month}-${day}`;
    console.log(this.prestacaoServico.dataProcedimento)
    this.dataVar = `${date.day}-${date.month}-${date.year}`;
  }
  cadastrar() {
    this.alteraDisponibilidadeConteiner();
    this.gerenteService.addPrestacaoServico(this.prestacaoServico).subscribe(
      (response: HttpResponse<PrestacaoServico>) => {   
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
  
  alteraDisponibilidadeConteiner() {
    this.gerenteService.alteraDisponibilidadeConteiner(this.conteinerUuid, this.estadoConteinerSelecionado).subscribe();
  }

  getAllConteineresAtivos() {
    this.gerenteService.getAllConteineresAtivos()
    .subscribe( response => {
      this.conteineresCadastrados = response;
    })
  }

  getAllServicosAtivos() {
    this.gerenteService.getAllServicosAtivos()
    .subscribe( response => {
      this.servicosCadastrados = response;
    })
  }

  getAllTerceirizadosAtivos() {
    this.gerenteService.getAllTerceirizadosAtivos()
    .subscribe( response => {
      this.terceirizadosCadastrados = response;
    })
  }

  getConteinerById() {
    this.gerenteService.getConteinerById(this.conteinerUuid)
    .subscribe( response => {
      this.conteinerData = response;
      this.estadoConteinerSelecionado = this.conteinerData.estado;
    })
  }

  // Popula EstadoConteiner dropdown
  public enumConteinerLength = Object.keys(this.estadoConteiner).length / 2;
  fakeArrayConteiner = new Array(this.enumConteinerLength);
}
