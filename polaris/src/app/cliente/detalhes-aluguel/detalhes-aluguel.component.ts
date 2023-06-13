import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GerenteService } from 'src/app/gerente/services';
import * as dropin from 'braintree-web-drop-in';

@Component({
  selector: 'app-detalhes-aluguel',
  templateUrl: './detalhes-aluguel.component.html',
  styleUrls: ['./detalhes-aluguel.component.scss']
})
export class DetalhesAluguelComponent implements OnInit {
  public aluguelData: any;
  public aluguelUuid: any;
  public jwt: any;
  public totalDays!: number;
  public statusMsg!: string;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.aluguelUuid = this.activatedRoute.snapshot.params['id'];
    this.jwt = localStorage.getItem("jwt");    
    this.getAllAlugueis();
    this.getAluguelById();    
  }

  initConfig(): void {
    const form = document.getElementById('payment-form') as HTMLFormElement;
    const button = document.getElementById("payment-btn") as HTMLElement;
    const span = button.querySelector("span") as HTMLElement;
    span.textContent = "Confirmar pagamento";
       
    dropin.create(
      {
        authorization: 'sandbox_zj93f58t_82khbmzjndf9jkm2',
        container: '#bt-dropin',
        paypal: { flow: 'vault' }
      },
      (dropinErr: any, instance: any) => {
        if (dropinErr) {
          console.error('Error creating Drop-in instance:', dropinErr);
          return;
        }

        form.addEventListener('submit', (event: Event) => {
          event.preventDefault();

          instance?.requestPaymentMethod((err: any, payload: any) => {
            if (err) {
              console.log('Error', err);
              return;
            }

            const request = {
              aluguelUuid: this.aluguelUuid,
              token: this.jwt,
              nonce: payload.nonce
            };

            const xhr = new XMLHttpRequest();
            xhr.open('POST', 'http://localhost:44444/Pagamento');
            xhr.setRequestHeader('Content-Type', 'application/json');
            xhr.setRequestHeader('Authorization', 'Bearer ' + request.token);

            xhr.send(JSON.stringify({
              aluguelUuid: request.aluguelUuid,
              nonce: request.nonce
            }));

            xhr.onload = () => {
              if (xhr.status === 201) {
                this.statusMsg = 'success';
              }
            };
          });
        });
    });
  }

  getAllAlugueis() {
    this.gerenteService.getAllAlugueis().subscribe( (res: any) => {
        this.aluguelData = res;
      }
    )
  }

  convertStringToDate(dateString: string) {
    const dateParts = dateString.split(/[-/\.]/); // Split by "-" or "/" or "."
    const year = parseInt(dateParts[0]);
    const month = parseInt(dateParts[1]) - 1; // Subtract 1 as month index is zero-based
    const day = parseInt(dateParts[2]);
    const date = new Date(year, month, day);
    return date;
  }  

  calculateDaysBetweenDates(startDate: Date, endDate: Date): number {
    const oneDay = 24 * 60 * 60 * 1000; // Number of milliseconds in a day
    const start = new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDate());
    const end = new Date(endDate.getFullYear(), endDate.getMonth(), endDate.getDate());
    const diffInDays = Math.round(Math.abs((start.getTime() - end.getTime()) / oneDay));
    return diffInDays;
  }

  getAluguelById() {
    this.gerenteService.getAluguelById(this.aluguelUuid)
      .subscribe( (res: any) => {
        let dataInicioString = this.convertStringToDate(res.dataInicio);
        let dataDevolucaoString = this.convertStringToDate(res.dataDevolucao);    
        this.totalDays = this.calculateDaysBetweenDates(dataInicioString, dataDevolucaoString);
      }
    );
  }

  getTotal(aluguel?: any): any {
    let total = 0;
    for (let i = 0; i < aluguel.length; i++) {
      if (this.aluguelUuid == aluguel[i].aluguelUuid) {
        total = aluguel[i].valorTotalAluguel - aluguel[i].desconto;
      }
    }
    return total;
  }

  /*private initConfig(): void {
    this.payPalConfig = {
      currency: 'BRL',
      clientId: environment.clientIdPayPal,
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
          this.statusMsg = 'success';
        });
      },
      onClientAuthorization: (data) => {
        console.log('onClientAuthorization - you should probably inform your server about completed transaction at this point', data);
      },
      onCancel: (data, actions) => {
        this.statusMsg = 'cancel';
        console.log('OnCancel', data, actions);
      },
      onError: err => {
        this.statusMsg = 'fail';
        console.log('OnError', err);
      },
      onClick: (data, actions) => {
        console.log('onClick', data, actions);
      }
    };
  }*/
}