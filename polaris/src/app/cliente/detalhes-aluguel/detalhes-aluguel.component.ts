import { Component, OnInit } from '@angular/core';
import { ICreateOrderRequest, IPayPalConfig } from 'ngx-paypal';
import { environment } from 'src/environments/environment';
import { ClienteService } from '../services';

@Component({
  selector: 'app-detalhes-aluguel',
  templateUrl: './detalhes-aluguel.component.html',
  styleUrls: ['./detalhes-aluguel.component.scss']
})
export class DetalhesAluguelComponent implements OnInit {

  public payPalConfig?: IPayPalConfig;
  public authData: any;
  public aluguelData: any;

  constructor( private _clienteServiceAPI: ClienteService ) { }

  ngOnInit(): void {
    this.initConfig();
    
    this._clienteServiceAPI.getAuthData().subscribe( (res: any) => {
        this.authData = res;
      }
    )

    this._clienteServiceAPI.getAluguelData().subscribe( (res: any) => {
        this.aluguelData = res;
      }
    )
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
            value: '3690',
            breakdown: {
              item_total: {
                currency_code: 'BRL',
                value: '3690'
              }
            }
          },
          items: [{
            name: 'Enterprise Subscription',
            quantity: '1',
            category: 'DIGITAL_GOODS',
            unit_amount: {
              currency_code: 'BRL',
              value: '3690',
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
