import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-editar-categoria',
  templateUrl: './editar-categoria.component.html',
  styleUrls: ['./editar-categoria.component.scss']
})
export class EditarCategoriaComponent implements OnInit {
  public status!: string;
  
  constructor() { }

  ngOnInit(): void {
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
