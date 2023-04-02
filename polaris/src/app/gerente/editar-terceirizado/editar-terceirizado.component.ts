import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-editar-terceirizado',
  templateUrl: './editar-terceirizado.component.html',
  styleUrls: ['./editar-terceirizado.component.scss']
})
export class EditarTerceirizadoComponent implements OnInit {
  public status!: string;
  
  constructor() { }

  ngOnInit(): void {
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
