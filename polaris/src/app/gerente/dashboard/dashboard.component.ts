import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { GerenteService } from '../services';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import {} from 'googlemaps';

enum EstadoAluguel {
  "Solicitado" = 0,
  "Em Andamento" = 1,
  "Pagamento Atrasado" = 2,
  "Devolução Atrasada" = 3,
  "Cancelado" = 4,
  "Aguardando Retirada do Contêiner" = 5,
  "Finalizado" = 6
}

enum EstadoConteiner {
  "Cancelado" = 0,
  "Disponível" = 1,
  "Em Manutenção" = 2,
  "Limpeza" = 3,
  "Locado" = 4,
  "Atrasado" = 5,
  "Reservado" = 6,
  "Indisponível" = 7,
  "Em Vistoria" = 8
};

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})

export class DashboardComponent implements OnInit,AfterViewInit {
  
  active = 1;
  chart: any;
  showChart: Boolean = false;
  public clienteData: any;
  public conteinerData: any;
  public aluguelData: any;
  public estadoAluguel = EstadoAluguel;

  @ViewChild('map') mapElement: any;
  map!: google.maps.Map;
  private apiKey = 'AIzaSyDT7c9WiX0QDvFDopYb6gPLLFE1hi6eXnE';

  dataConteiner = [
    { label: 'Cancelado', y: 5 },
    { label: 'Disponível', y: 0 },
    { label: 'Em Manutenção', y: 0 },
    { label: 'Limpeza', y: 0 },
    { label: 'Locado', y: 0 },
    { label: 'Atrasado', y: 0 },
    { label: 'Reservado', y: 0 },
    { label: 'Indisponível', y: 0 },
    { label: 'Em Vistoria', y: 0 }
  ]

  dataAluguel = [
    { label: 'Solicitado', y: 5 },
    { label: 'Em Andamento', y: 0 },
    { label: 'Pagamento Atrasado', y: 0 },
    { label: 'Devolução Atrasada', y: 0 },
    { label: 'Cancelado', y: 0 },
    { label: 'Aguardando Retirada', y: 0 },
    { label: 'Finalizado', y: 0 }
  ]

  constructor( private gerenteService: GerenteService, private activatedRoute: ActivatedRoute, private http: HttpClient ) { }

  async ngOnInit() { 
    await this.loadData();
    
    setTimeout(() => this.showChart = true, 200); 
  }

 ngAfterViewInit() {
    //setTimeout(() => this.loadGoogleMapsScript(() => this.initializeMap()), 200);
    //setTimeout(() => this.showChart = true, 200); 
  }
  
 async loadData() {
    this.gerenteService.getAllConteineresAtivos().subscribe( (res: any) => {
      this.conteinerData = res;
      this.getEstadoConteiner(this.conteinerData);
    });

    this.gerenteService.getAllAlugueis().subscribe( (res: any) => {
      this.aluguelData = res;
      this.getEstadoAluguel(this.aluguelData);
      this.loadGoogleMapsScript(() => this.initializeMap(this.aluguelData))
    })

  };

  getEstadoConteiner(data: any) {
    for (let i = 0; i < data.length; i++) {
      let estado = data[i].estado;
      let estadoData = EstadoConteiner[estado]
      for (let dataO of this.dataConteiner ) {
        if (dataO.label === estadoData) { 
          dataO.y = dataO.y+1;  
       }}}
  };

  getEstadoAluguel(data: any) {
    for (let i = 0; i < data.length; i++) {
      let estado = data[i].estadoAluguel;
      let estadoData = EstadoAluguel[estado]
      for (let dataO of this.dataAluguel ) {
        if (dataO.label === estadoData) { 
          dataO.y = dataO.y+1;    
       }}}
  };

  getEnderecoAluguel(data: any) {
    for (let i = 0; i < data.length; i++) {
      let endereco = data[i].endereco;
      let cep = JSON.stringify(endereco.cep)
      let logradouro = JSON.stringify(endereco.logradouro)
      let numero = JSON.stringify(endereco.numero) 
      console.log( `${cep} ${logradouro} ${numero}`)
    }
  };

  //GRAFICO

  columnChartOptions = {
    animationEnabled: true,
    title: {
      text: 'Aluguéis',
    },
    data: [{
        type: 'column',
        dataPoints: this.dataAluguel
    }]
  };

  lineChartOptions = {
    animationEnabled: true,
    title: {
      text: 'Tipos de conteineres alugados',
    },
    data: [{
        type: 'line',
        dataPoints: this.dataConteiner 
      }]
  };

  pieChartOptions = {
    animationEnabled: true,
    title: {
      text: 'Contêineres',
    },
    data: [{
        type: 'pie',
        dataPoints: this.dataConteiner 
    }]
  };

  getChartInstance(chart: object) {
    this.chart = chart;
  }
  navChangeEvent(e: any) {
    this.showChart = true;
  }
  navHiddenEvent(e: any) {
    this.showChart = false;
  }

  //MAPA

  private loadGoogleMapsScript(callback: () => void) {
    const script = document.createElement('script');
    script.src = `https://maps.googleapis.com/maps/api/js?key=${this.apiKey}`;
    script.onload = callback;
    document.body.appendChild(script);
  }

  async initializeMap(data: any) {

  const myLatLng = { lat: -25.4555189, lng: -49.2351974 };
  const map = new google.maps.Map(this.mapElement.nativeElement, {
    zoom: 10,
    center: myLatLng,
  });

  for (let i = 0; i < data.length; i++) {
    let idAluguel = data[i].aluguelUuid;
    let clienteCpf = data[i].cliente.cpf
    let endereco = data[i].endereco;
    let cep = JSON.stringify(endereco.cep)
    let logradouro = JSON.stringify(endereco.logradouro)
    let numero = JSON.stringify(endereco.numero) 
    let address =  `${cep} ${logradouro} ${numero}`;
    console.log(address)
    this.getLatLngFromAddress(address, idAluguel, clienteCpf, map) 
  }
}

async getLatLngFromAddress(address: string, id:string, cpf:string,map: any) {

  fetch(`https://maps.googleapis.com/maps/api/geocode/json?address=${address}&key=${this.apiKey}`)
  .then((response) => {
      return response.json();
  }).then(jsonData => {

    let lat = jsonData.results[0].geometry.location.lat;
    let lng = jsonData.results[0].geometry.location.lng;
      var marker = new google.maps.Marker({
        position: { lat: lat, lng: lng},
        map,
        title: cpf,
      });
    
      google.maps.event.addListener(marker, 'click', function() {
        window.location.href = `gerente/visualizar-detalhes-aluguel/${id}`;
        window.open(`gerente/visualizar-detalhes-aluguel/${id}`, '_blank');
      });

  })
  .catch(error => {
      console.log(error);
  })
}
}


