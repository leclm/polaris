import { Component, OnInit, ViewChild } from '@angular/core';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';
import { Categoria } from 'src/app/models/categoria.model';
import { HttpResponse } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-editar-categoria',
  templateUrl: './editar-categoria.component.html',
  styleUrls: ['./editar-categoria.component.scss']
})
export class EditarCategoriaComponent implements OnInit {
  public statusMsg!: string;
  public categoriaConteinerUuid: any;
  public categoriaData: any;

  public categoria: Categoria = {
    categoriaConteinerUuid: '',
    nome: '',
    status: true
  }

  @ViewChild("formCategoria") formCategoria!: NgForm;
  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.categoriaConteinerUuid = this.activatedRoute.snapshot.params['id'];
    this.gerenteService.getAllCategorias().subscribe( (res: any) => { this.categoriaData = res; });
    this.gerenteService.getCategoriaById(this.categoriaConteinerUuid).subscribe( (res: any) => { this.categoria = res; });
  }

  editar() {
    this.gerenteService.editarCategoria(this.categoria).subscribe(
      (response: HttpResponse<Categoria>) => {   
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
