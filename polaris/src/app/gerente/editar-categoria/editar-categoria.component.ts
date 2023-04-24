import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-editar-categoria',
  templateUrl: './editar-categoria.component.html',
  styleUrls: ['./editar-categoria.component.scss']
})
export class EditarCategoriaComponent implements OnInit {
  public status!: string;
  public categoriaUuid: any;
  public categoriaData: any;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.categoriaUuid = this.activatedRoute.snapshot.params['id'];
    
    this.gerenteService.getAllCategorias().subscribe( (res: any) => {
        this.categoriaData = res;
      }
    )
  }

  // mock para mensagem
  editar(): any {
    var code = "200";
    if (code == "200") {
      this.status = 'success';
    } else {
      this.status = 'fail';
    }
  }
}
