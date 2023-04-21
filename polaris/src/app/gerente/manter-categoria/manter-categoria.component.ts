import { Component, OnInit } from '@angular/core';
import { Categoria } from 'src/app/models/categoria.model';
import { GerenteService } from '../services';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-manter-categoria',
  templateUrl: './manter-categoria.component.html',
  styleUrls: ['./manter-categoria.component.scss']
})
export class ManterCategoriaComponent implements OnInit {
  public statusMsg!: string;
  
  public categoria: Categoria = {
    categoriaConteinerUuid: '',
    nome: '',
    status: true
  }

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
  }

  cadastrar() {
    this.gerenteService.addCategoria(this.categoria).subscribe(
      (response: HttpResponse<Categoria>) => {   
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
