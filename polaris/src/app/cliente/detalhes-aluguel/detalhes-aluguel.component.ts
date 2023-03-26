import { Component, OnInit } from '@angular/core';
import { ICreateOrderRequest, IPayPalConfig } from 'ngx-paypal';
import { environment } from 'src/environments/environment';
import { ClienteService } from '../services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalhes-aluguel',
  templateUrl: './detalhes-aluguel.component.html',
  styleUrls: ['./detalhes-aluguel.component.scss']
})
export class DetalhesAluguelComponent implements OnInit {
  public payPalConfig?: IPayPalConfig;
  public authData: any;
  public aluguelData: any;
  public aluguelId: any;

  constructor( private _clienteServiceAPI: ClienteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.initConfig();

    this.aluguelId = this.activatedRoute.snapshot.params['id'];
    
    this._clienteServiceAPI.getAuthData().subscribe( (res: any) => {
        this.authData = res;
      }
    )

    this._clienteServiceAPI.getAluguelData().subscribe( (res: any) => {
        this.aluguelData = res;
        this.getTotal(this.aluguelData);
      }
    )
  }

  private getTotal(aluguel?: any): any {
    let total = 0;
    for (let i = 0; i < aluguel.content.length; i++) {
      if ( this.aluguelId == aluguel.content[i].id ) {
        total = aluguel.content[i].valorTotalAluguel - aluguel.content[i].desconto;
      }
    }
    return total;
  }

  private initConfig(): void {
    this.payPalConfig = {
      currency: 'BRL',
      clientId: environment.clientId,
      createOrderOnClient: (data) => <ICreateOrderRequest> {
        intent: 'CAPTURE',
        purchase_units: [{
          amount: {
            currency_code: 'BRL',
            value: this.getTotal(this.aluguelData).toString(),
            breakdown: {
              item_total: {
                currency_code: 'BRL',
                value: this.getTotal(this.aluguelData).toString()
              }
            }
          },
          items: [{
            name: 'Enterprise Subscription',
            quantity: '1',
            category: 'DIGITAL_GOODS',
            unit_amount: {
              currency_code: 'BRL',
              value: this.getTotal(this.aluguelData).toString()
            },
          }]
        }]
      },
      advanced: {
        commit: 'true'
      },
      style: {
        label: 'paypal',
        layout: 'vertical'
      },
      onApprove: (data, actions) => {
        console.log('onApprove - transaction was approved, but not authorized', data, actions);
        actions.order.get().then((details: any) => {
          console.log('onApprove - you can get full order details inside onApprove: ', details);
        });
      },
      onClientAuthorization: (data) => {
        console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', data);
      },
      onCancel: (data, actions) => {
        console.log('OnCancel', data, actions);
      },
      onError: err => {
        console.log('OnError', err);
      },
      onClick: (data, actions) => {
        console.log('onClick', data, actions);
      }
    };
  }
}
