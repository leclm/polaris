import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manter-categoria',
  templateUrl: './manter-categoria.component.html',
  styleUrls: ['./manter-categoria.component.scss']
})
export class ManterCategoriaComponent implements OnInit {
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
