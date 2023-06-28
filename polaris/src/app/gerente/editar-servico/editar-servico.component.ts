import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Servico } from 'src/app/models/servico.model';
import { GerenteService } from '../services';
import { CustomvalidationService } from 'src/app/shared';

@Component({
  selector: 'app-editar-servico',
  templateUrl: './editar-servico.component.html',
  styleUrls: ['./editar-servico.component.scss']
})
export class EditarServicoComponent implements OnInit {
  public statusMsg!: string;
  public servicoUuid: any;
  public servicoData: any;

  public servico: Servico = {
    servicoUuid: '',
    nome: '',
    checked: true
  }

  @ViewChild("formservico") formservico!: NgForm;
  constructor( private CustomvalidationService: CustomvalidationService,private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.servicoUuid = this.activatedRoute.snapshot.params['id'];
    this.gerenteService.getAllServicos().subscribe( (res: any) => { this.servicoData = res; });
    this.gerenteService.getServicoById(this.servicoUuid).subscribe( (res: any) => { 
      this.servico = res; 
      this.servico.nome = this.CustomvalidationService.camelize(this.servico.nome);
    });
  }

  editar() {
    this.gerenteService.editarServico(this.servico).subscribe(
      (response: HttpResponse<Servico>) => {   
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
  };
}
