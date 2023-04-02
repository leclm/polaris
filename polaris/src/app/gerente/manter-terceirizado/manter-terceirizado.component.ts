import { Component, OnInit } from '@angular/core';
import { ViaCepService } from 'src/app/shared';

@Component({
  selector: 'app-manter-terceirizado',
  templateUrl: './manter-terceirizado.component.html',
  styleUrls: ['./manter-terceirizado.component.scss']
})
export class ManterTerceirizadoComponent implements OnInit {
  cep!: string;
  address: any;

  constructor( private viaCepService: ViaCepService ) { }

  ngOnInit(): void { }

  searchAddress(event: any) {
    this.viaCepService.getAddressByCep(this.cep).subscribe(data => {
      this.address = data;
    });
  }
}
