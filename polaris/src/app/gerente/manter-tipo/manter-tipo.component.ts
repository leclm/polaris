import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';
import { HttpResponse } from '@angular/common/http';
import { Tipo } from 'src/app/models/tipo.model';
import { CustomvalidationService } from 'src/app/shared';

@Component({
  selector: 'app-manter-tipo',
  templateUrl: './manter-tipo.component.html',
  styleUrls: ['./manter-tipo.component.scss']
})
export class ManterTipoComponent implements OnInit {
  public statusMsg!: string;

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

  constructor( private CustomvalidationService: CustomvalidationService, private gerenteService: GerenteService ) { }

  ngOnInit(): void { }

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

  cadastrar() {

    this.CustomvalidationService.camelize(this.tipo.nome)
    this.gerenteService.addTipo(this.tipo).subscribe(
      (response: HttpResponse<Tipo>) => {   
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
