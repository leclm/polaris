import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AluguelEstado } from 'src/app/models/aluguelEstado.model';
import { GerenteService } from '../services';

enum EstadoAluguel {
  Solicitado = 0,
  "Em Andamento" = 1,
  "Pagamento Atrasado" = 2,
  "Devolução Atrasada" = 3,
  Cancelado = 4,
  "Aguardando Retirada do Contêiner" = 5,
  Finalizado = 6
}

@Component({
  selector: 'app-editar-estado-aluguel',
  templateUrl: './editar-estado-aluguel.component.html',
  styleUrls: ['./editar-estado-aluguel.component.scss']
})
export class EditarEstadoAluguelComponent implements OnInit {
  public aluguelUuid: any;
  public aluguelData: any;
  public estadoAluguel = EstadoAluguel;
  public estadoAluguelSelecionado = 0;
  public statusMsg!: string;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.aluguelUuid = this.activatedRoute.snapshot.params['id']; 
    this.getAllAlugueis();  
    this.getAluguelById();
  }

  getAllAlugueis() {
    this.gerenteService.getAllAlugueis().subscribe( (res: any) => { this.aluguelData = res; }); 
  }

  getAluguelById() {
    this.gerenteService.getAluguelById(this.aluguelUuid).subscribe( (res: any) => { 
      this.estadoAluguelSelecionado = res.estadoAluguel;
    });   
  }

  editar() {
    this.gerenteService.alteraEstadoAluguel(this.aluguelUuid, this.estadoAluguelSelecionado).subscribe(
      (response: HttpResponse<AluguelEstado>) => {   
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

  // Popula EstadoAluguel dropdown
  public enumAluguelLength = Object.keys(this.estadoAluguel).length / 2;
  fakeArrayAluguel = new Array(this.enumAluguelLength);
}
