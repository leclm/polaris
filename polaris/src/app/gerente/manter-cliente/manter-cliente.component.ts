import { Component, OnInit } from '@angular/core';
import { ViaCepService } from 'src/app/shared';

@Component({
  selector: 'app-manter-cliente',
  templateUrl: './manter-cliente.component.html',
  styleUrls: ['./manter-cliente.component.scss']
})
export class ManterClienteComponent implements OnInit {
  cep!: string;
  address: any;

  constructor( private viaCepService: ViaCepService ) { }

  ngOnInit(): void {
  }

  searchAddress() {
    
  }

  onInput(event: any) {
    this.viaCepService.getAddressByCep(this.cep).subscribe(data => {
      this.address = data;
    });
  }
}
