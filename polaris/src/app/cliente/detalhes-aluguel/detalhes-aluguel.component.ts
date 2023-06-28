import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GerenteService } from 'src/app/gerente/services';
import { ContractPdfService } from 'src/app/shared';
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
  public pago!: string;

  constructor( private ContractPdfService: ContractPdfService, private gerenteService: GerenteService, private activatedRoute: ActivatedRoute ) { }

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
        this.pago = res.estadoAluguel.toString();
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

  generatePdf(){
    this.gerenteService.getAluguelById(this.aluguelUuid).subscribe( (res: any) => {
      this.ContractPdfService.generatePdfService(res)   
    }
  )
  }


}