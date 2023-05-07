import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { GerenteService } from 'src/app/gerente/services';
import { NovoCliente } from 'src/app/models/novoCliente.model';

@Component({
  selector: 'app-solicitar-contato',
  templateUrl: './solicitar-contato.component.html',
  styleUrls: ['./solicitar-contato.component.scss']
})
export class SolicitarContatoComponent implements OnInit {
  public statusMsg!: string;

  constructor( private gerenteService: GerenteService ) { }

  public novoCliente: NovoCliente = {
    nome: '',
    email: '',
    telefone: ''
  }

  ngOnInit(): void {
  }

  cadastrar() {
    console.log('cadastrar');
  }

/*  cadastrar() {
    this.gerenteService.addTerceirizado(this.novoCliente).subscribe(
      (response: HttpResponse<NovoCliente>) => {   
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
  }*/
}