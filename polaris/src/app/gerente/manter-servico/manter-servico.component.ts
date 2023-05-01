import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Servico } from 'src/app/models/servico.model';
import { GerenteService } from '../services';

@Component({
  selector: 'app-manter-servico',
  templateUrl: './manter-servico.component.html',
  styleUrls: ['./manter-servico.component.scss']
})
export class ManterServicoComponent implements OnInit {
  public statusMsg!: string;
  
  public servico: Servico = {
    servicoUuid: '',
    nome: '',
    checked: true
  }

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
  }

  cadastrar() {
    this.gerenteService.addServico(this.servico).subscribe(
      (response: HttpResponse<Servico>) => {   
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
