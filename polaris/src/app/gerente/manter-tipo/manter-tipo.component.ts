import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manter-tipo',
  templateUrl: './manter-tipo.component.html',
  styleUrls: ['./manter-tipo.component.scss']
})
export class ManterTipoComponent implements OnInit {
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
