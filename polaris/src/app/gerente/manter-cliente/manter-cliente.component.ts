import { Component, OnInit } from '@angular/core';
import { ViaCepService } from 'src/app/shared';

@Component({
  selector: 'app-manter-cliente',
  templateUrl: './manter-cliente.component.html',
  styleUrls: ['./manter-cliente.component.scss']
})
export class ManterClienteComponent implements OnInit {
  public cep!: string;
  public address: any;
  public status!: string;

  constructor( private viaCepService: ViaCepService ) { }

  ngOnInit(): void {
  }
  
  searchAddress(event: any) {
    this.viaCepService.getAddressByCep(this.cep).subscribe(data => {
      this.address = data;
    });
  }

  /*
  * ENVIAR SENHA COMO DATA DE NASCIMENTO: 03091995
  */


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
