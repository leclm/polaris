import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-editar-tipo',
  templateUrl: './editar-tipo.component.html',
  styleUrls: ['./editar-tipo.component.scss']
})
export class EditarTipoComponent implements OnInit {
  public status!: string;

  constructor() { }

  ngOnInit(): void {
  }

  // mock para mensagem
  cadastrar(): any {
    var code = "200";
    if ( code == "200") {
      this.status = 'success';
    } else {
      this.status = 'fail';
    }
  }
}
