import { Component, OnInit, ViewChild } from '@angular/core';
import { GerenteService } from '../services';
import { ActivatedRoute, Router } from '@angular/router';
import { Terceirizado } from 'src/app/models/terceirizado.model';
import { NgForm } from '@angular/forms';
import { Servico } from 'src/app/models/servico.model';
import { HttpResponse } from '@angular/common/http';
import { Endereco } from 'src/app/models/endereco.model';

@Component({
  selector: 'app-editar-terceirizado',
  templateUrl: './editar-terceirizado.component.html',
  styleUrls: ['./editar-terceirizado.component.scss']
})
export class EditarTerceirizadoComponent implements OnInit {
  public terceirizadoUuid: any;
  public terceirizadoById!: Terceirizado;
  public servicosCadastrados: Servico[] = [];  
  public terceirizadoData: any;
  public statusMsg!: string;

  public servico: Servico = {
    servicoUuid: '',
    nome: '',
    checked: false
  }
  
  @ViewChild("formTerceirizado") formTerceirizado!: NgForm;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute, private router: Router ) { }

  ngOnInit(): void {
    this.terceirizadoUuid = this.activatedRoute.snapshot.params['id']; 

    this.gerenteService.getAllTerceirizados().subscribe( (res: any) => {
        this.terceirizadoData = res;
      }
    )

    this.gerenteService.getTerceirizadoById(this.terceirizadoUuid).subscribe( (res: any) => {
        this.terceirizadoById = res;
        console.log(this.terceirizadoById);
      }
    )

    this.gerenteService.getAllServicos().subscribe( (res: any) => {
        this.servicosCadastrados = res;
      }
    )
  }

  editar() {
    this.terceirizadoById.listaServicos = [this.servico.servicoUuid];
    console.log(this.terceirizadoById);
    this.gerenteService.putTerceirizado(this.terceirizadoById).subscribe(
      (response: HttpResponse<Terceirizado>) => {   
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
