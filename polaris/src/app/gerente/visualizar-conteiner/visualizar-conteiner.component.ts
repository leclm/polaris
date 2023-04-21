import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-visualizar-conteiner',
  templateUrl: './visualizar-conteiner.component.html',
  styleUrls: ['./visualizar-conteiner.component.scss']
})
export class VisualizarConteinerComponent implements OnInit {
  public conteinerUuid: any;
  public conteineresData: any;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.conteinerUuid = this.activatedRoute.snapshot.params['id'];
    
    this.gerenteService.getAllConteineresAtivos().subscribe( (res: any) => {
        this.conteineresData = res;
      }
    )
  }
}
