import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Tipo } from 'src/app/models/tipo.model';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { CustomvalidationService } from 'src/app/shared';

@Component({
  selector: 'app-editar-tipo',
  templateUrl: './editar-tipo.component.html',
  styleUrls: ['./editar-tipo.component.scss']
})
export class EditarTipoComponent implements OnInit {
  public statusMsg!: string;
  public tipoConteinerUuid: any;
  public tipoData: any;
  
  public tipo: Tipo = {
    tipoConteinerUuid: '',
    nome: '',
    largura: 0,
    comprimento: 0,
    volume: 0,
    pesoMaximo: 0,
    altura: 0,
    valorDiaria: 0,
    valorMensal: 0,
    status: true
  }
  
  @ViewChild("formTipo") formTipo!: NgForm;
  constructor( private CustomvalidationService: CustomvalidationService,private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.tipoConteinerUuid = this.activatedRoute.snapshot.params['id'];
    this.gerenteService.getAllTipos().subscribe( (res: any) => { this.tipoData = res; });
    this.gerenteService.getTipoById(this.tipoConteinerUuid).subscribe( (res: any) => { 
      this.tipo = res;
      this.tipo.nome = this.CustomvalidationService.camelize(this.tipo.nome);

     });
  }

  public tipoVar: any
  public valueNotValid = false;

  changeCents(event: any) {
    this.tipoVar
    let valor = JSON.stringify(this.tipo.valorDiaria)
    
    if(valor=="0"){this.valueNotValid=true}else {this.valueNotValid=false}
    console.log(JSON.stringify(this.tipo.valorDiaria))
    console.log(this.valueNotValid)
    this.valueNotValid
}

  editar() {
    this.gerenteService.editarTipo(this.tipo).subscribe(
      (response: HttpResponse<Tipo>) => {   
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
}
