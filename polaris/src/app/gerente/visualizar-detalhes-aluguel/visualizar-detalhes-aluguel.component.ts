import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { GerenteService } from '../services';

@Component({
  selector: 'app-visualizar-detalhes-aluguel',
  templateUrl: './visualizar-detalhes-aluguel.component.html',
  styleUrls: ['./visualizar-detalhes-aluguel.component.scss']
})
export class VisualizarDetalhesAluguelComponent implements OnInit {
  public aluguelUuid: any;
  public aluguelData: any;
  public totalDays!: number;

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute, private location: Location ) { }

  ngOnInit(): void {
    this.aluguelUuid = this.activatedRoute.snapshot.params['id'];
    this.getAllAlugueis();
    this.getAluguelById();
  }
  
  getAllAlugueis() {
    this.gerenteService.getAllAlugueis()
      .subscribe( (res: any) => {
        this.aluguelData = res;
      }
    );
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

  goBack(): void {
    this.location.back();
  }
}
