import { Component, OnInit } from '@angular/core';
import { ICreateOrderRequest, IPayPalConfig } from 'ngx-paypal';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';
import { GerenteService } from 'src/app/gerente/services';

@Component({
  selector: 'app-detalhes-aluguel',
  templateUrl: './detalhes-aluguel.component.html',
  styleUrls: ['./detalhes-aluguel.component.scss']
})
export class DetalhesAluguelComponent implements OnInit {
  public payPalConfig?: IPayPalConfig;
  public aluguelData: any;
  public aluguelUuid: any;
  public totalDays!: number;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

  ngOnInit(): void {
    this.aluguelUuid = this.activatedRoute.snapshot.params['id'];
    this.initConfig();
    this.getAllAlugueis();
    this.getAluguelById();
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
        console.log(res);
        let dataInicioString = this.convertStringToDate(res.dataInicio);
        let dataDevolucaoString = this.convertStringToDate(res.dataDevolucao);    
        this.totalDays = this.calculateDaysBetweenDates(dataInicioString, dataDevolucaoString);
      }
    );
  }

  private getTotal(aluguel?: any): any {
    let total = 0;
    for (let i = 0; i < aluguel.content.length; i++) {
      if ( this.aluguelUuid == aluguel.content[i].id ) {
        total = aluguel.content[i].valorTotalAluguel - aluguel.content[i].desconto;
      }
    }
    return total;
  }

  private initConfig(): void {
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
