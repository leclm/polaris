import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';
import { Tipo } from 'src/app/models/tipo.model';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { Categoria } from 'src/app/models/categoria.model';
import { Conteiner } from 'src/app/models/conteiner.model';
import { HttpResponse } from '@angular/common/http';
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
  
  @ViewChild("formConteiner") formConteiner!: NgForm;
  
  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

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

  ngOnInit(): void {
    this.conteinerUuid = this.activatedRoute.snapshot.params['id']; 
    this.getAllConteineres();
    this.getAllTiposAtivos();
    this.getAllCategoriasAtivas();
    this.getAllTerceirizadosAtivos();    
    this.getConteinerById();
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

  getAllConteineres() {
    this.gerenteService.getAllConteineres().subscribe( (res: any) => { this.conteinerData = res; }); 
  }

  getAllTiposAtivos() {
    this.gerenteService.getAllTiposAtivos().subscribe( (res: any) => { this.tiposCadastrados = res; });
  }
  
  getAllCategoriasAtivas() {
    this.gerenteService.getAllCategoriasAtivas().subscribe( (res: any) => { this.categoriasCadastradas = res; });
  }
  getAllTerceirizadosAtivos() {
    this.gerenteService.getAllTerceirizadosAtivos().subscribe( (res: any) => { this.terceirizadosCadastrados = res;}); 
  }     

  getConteinerById() {
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
}
