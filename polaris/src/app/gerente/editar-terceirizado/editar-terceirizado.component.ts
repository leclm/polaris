import { Component, OnInit } from '@angular/core';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-editar-terceirizado',
  templateUrl: './editar-terceirizado.component.html',
  styleUrls: ['./editar-terceirizado.component.scss']
})
export class EditarTerceirizadoComponent implements OnInit {
  public status!: string;
  public terceirizadoUuid: any;
  public terceirizadoData: any;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.terceirizadoUuid = this.activatedRoute.snapshot.params['id'];
    
    this.gerenteService.getAllTerceirizados().subscribe( (res: any) => {
        this.terceirizadoData = res;
        console.log(this.terceirizadoData);
      }
    )
  }
  // mock para mensagem
  editar(): any {
    var code = "200";
    if ( code == "200") {
      this.status = 'success';
    } else {
      this.status = 'fail';
    }
  }
}
