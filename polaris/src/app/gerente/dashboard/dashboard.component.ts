import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { GerenteService } from '../services';
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

  dataThree = [
    { label: 'teste 1', y: 0 },
    { label: 'teste 2', y: 0 }
  ]

  constructor( private gerenteService: GerenteService ) { }

  ngOnInit(): void {
    this.loadData();
  }

  ngAfterViewInit() {
    this.loadGoogleMapsScript(() => this.initializeMap());
    this.showChart = true;
    setInterval(() => this.showChart = true, 1000);
    
  }
  
  loadData() {
    
    this.gerenteService.getAllConteineresAtivos().subscribe( (res: any) => {
      this.conteinerData = res;
      this.getEstadoConteiner(this.conteinerData);
    });

    this.gerenteService.getAllAlugueis().subscribe( (res: any) => {
      this.aluguelData = res;
      this.getEstadoAluguel(this.aluguelData);
      this.getEnderecoAluguel(this.aluguelData);
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
      console.log("teste de endereco")
      console.log(endereco)
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

  initializeMap() {

  const myLatLng = { lat: -25.363, lng: 131.044 };
  const map = new google.maps.Map(this.mapElement.nativeElement, {
    zoom: 3,
    center: myLatLng,
  });

  var marker = new google.maps.Marker({
    position: { lat: -25.363, lng: 125.044 },
    map,
    title: "Contêiner 1",
  });

  google.maps.event.addListener(marker, 'click', function() {
    window.location.href = 'https://www.google.com/';
    window.open('https://www.google.com/', '_blank');
  });

  var marker = new google.maps.Marker({
    position: { lat: -20.363, lng: 120.044 },
    map,
    title: "Contêiner 2",
  });

  google.maps.event.addListener(marker, 'click', function() {
    window.location.href = 'https://www.google.com/';
    window.open('https://www.google.com/', '_blank');
  });


}

/*
initialize() {
  var contactLatitude = 42;
  var contactLongitude = -72;
  var mapCanvas = document.getElementById('map_canvas2');
  var myLatLng = {
    lat: contactLatitude,
    lng: contactLongitude
  };
  var mapOptions = {
    center: new google.maps.LatLng(contactLatitude, contactLongitude),
    zoom: 8,
    mapTypeId: google.maps.MapTypeId.ROADMAP
  }
  var map = new google.maps.Map(mapCanvas, mapOptions);
  this.addMarker(myLatLng, map);
}

addMarker(location:any, map:any) {
  var marker = new google.maps.Marker({
    position: location,
    title: 'Home Center',
    map: map
  });
}

*/

}


