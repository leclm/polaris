import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GerenteService } from '../services';
import { ActivatedRoute, Router } from '@angular/router';
import { Tipo } from 'src/app/models/tipo.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Categoria } from 'src/app/models/categoria.model';
import { Conteiner } from 'src/app/models/conteiner.model';
import { HttpResponse } from '@angular/common/http';
import { PrestacaoServico } from 'src/app/models/prestacaoServico.model';

enum EstadoConteiner {
  Cancelado = 0,
  Disponível = 1,
  Manutenção = 2,
  Limpeza = 3,
  Locado = 4,
  Atrasado = 5,
  Reservado = 6,
  Indisponível = 7,
  Vistoria = 8
};

@Component({
  selector: 'app-editar-conteiner',
  templateUrl: './editar-conteiner.component.html',
  styleUrls: ['./editar-conteiner.component.scss']
})
export class EditarConteinerComponent implements OnInit {
  public conteinerUuid: any;
  public conteinerData: any;
  public statusMsg!: string;
  public tiposCadastrados: Tipo[] = []; 
  public categoriasCadastradas: Categoria[] = []; 
  public terceirizadosCadastrados: Terceirizado[] = [];  
  public estadoConteiner = EstadoConteiner;
  public estadoSelecionado = 0;
  
  @ViewChild("formConteiner") formConteiner!: NgForm;
  
  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute, private router: Router ) { }

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

  public prestacaoServico: PrestacaoServico = {
    dataProcedimento: '',
    comentario: '',
    conteiner: '',
    terceirizado: '',
    servico: ''
  }

  ngOnInit(): void {
    this.conteinerUuid = this.activatedRoute.snapshot.params['id']; 
    this.gerenteService.getAllConteineres().subscribe( (res: any) => { this.conteinerData = res; });
    this.gerenteService.getAllTiposAtivos().subscribe( (res: any) => { this.tiposCadastrados = res; });
    this.gerenteService.getAllCategoriasAtivas().subscribe( (res: any) => { this.categoriasCadastradas = res; });
    this.gerenteService.getAllTerceirizadosAtivos().subscribe( (res: any) => { this.terceirizadosCadastrados = res;});  
    this.gerenteService.getConteinerById(this.conteinerUuid).subscribe( (res: any) => { 
      this.conteiner.conteinerUuid = res.conteinerUuid;
      this.conteiner.codigo = res.codigo;
      this.conteiner.fabricacao = res.fabricacao;
      this.conteiner.fabricante = res.fabricante;
      this.conteiner.material = res.material;
      this.conteiner.cor = res.cor;
      this.conteiner.categoria = res.categoriaConteiner.categoriaConteinerUuid;
      this.conteiner.tipo = res.tipoConteiner.tipoConteinerUuid;
    });    
  }

  alteraDisponibilidadeConteiner() {
    this.gerenteService.alteraDisponibilidadeConteiner(this.conteinerUuid, this.estadoSelecionado);
  }

  editar() {
    this.gerenteService.putConteiner(this.conteiner).subscribe(
      (response: HttpResponse<Conteiner>) => {   
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
  
  // Popula Estado Contêiner dropdown
  createRange(num: number){
    return new Array(num).fill(0).map((n, index) => index + 1);
  }

  public enumLength = Object.keys(this.estadoConteiner).length / 2;
  fakeArray = new Array(this.enumLength);
}
