import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Tipo } from 'src/app/models/tipo.model';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';

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
  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.tipoConteinerUuid = this.activatedRoute.snapshot.params['id'];
    this.gerenteService.getAllTipos().subscribe( (res: any) => { this.tipoData = res; });
    this.gerenteService.getTipoById(this.tipoConteinerUuid).subscribe( (res: any) => { this.tipo = res; });
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
