import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PrestacaoServicoAtualizacao } from 'src/app/models/prestacaoServicoAtualizacao.model';
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
    
  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.prestacaoDeServicoUuid = this.activatedRoute.snapshot.params['id']; 
    this.getAllPrestacaoServicos();
    this.getPrestacaoServicoById();    
  }

  editar() {
    this.prestacaoServicoAtualizacao.prestacaoDeServicoUuid = this.prestacaoDeServicoUuid;
    this.prestacaoServicoAtualizacao.estadoPrestacaoServico = parseInt(this.estadoPrestacaoServicoSelecionada.toString());
    this.alteraDisponibilidadeConteiner();
    this.gerenteService.alterarEstadoPrestacaoServico(this.prestacaoServicoAtualizacao).subscribe(
      (response: HttpResponse<PrestacaoServicoAtualizacao>) => {   
        if (response.status === 200 || response.status === 201) {
          this.statusMsg = 'success';
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
      this.prestacaoServicoAtualizacao.estadoPrestacaoServico = response.estadoPrestacaoServico;
      this.prestacaoServicoAtualizacao.comentario = response.comentario;
      
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

  // Popula EstadoConteiner e EstadoPrestacaoServico dropdown
  public enumPrestacaoServicoLength = Object.keys(this.estadoPrestacaoServico).length / 2;
  fakeArrayPrestacaoServico = new Array(this.enumPrestacaoServicoLength);

  public enumConteinerLength = Object.keys(this.estadoConteiner).length / 2;
  fakeArrayConteiner = new Array(this.enumConteinerLength);
}
