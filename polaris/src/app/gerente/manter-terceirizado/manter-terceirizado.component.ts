import { Component, HostListener, OnInit } from '@angular/core';
import { ViaCepService } from 'src/app/shared';

@Component({
  selector: 'app-manter-terceirizado',
  templateUrl: './manter-terceirizado.component.html',
  styleUrls: ['./manter-terceirizado.component.scss']
})
export class ManterTerceirizadoComponent implements OnInit {
  public cep!: string;
  public address: any;
  public status!: string;
  
  constructor( private viaCepService: ViaCepService ) { }

  ngOnInit(): void { }

  searchAddress(event: any) {
    this.viaCepService.getAddressByCep(this.cep).subscribe(data => {
      this.address = data;
    });
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
