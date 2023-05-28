import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { GerenteService } from '../services';
import {} from 'googlemaps';

enum EstadoConteiner {
  Cancelado = 0,
  Disponível = 1,
  "Em Manutenção" = 2,
  Limpeza = 3,
  Locado = 4,
  Atrasado = 5,
  Reservado = 6,
  Indisponível = 7,
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
  public loginUuid!: string;
  
  dataOne = [
    { label: 'apple', y: 10 },
    { label: 'orange', y: 15 },
    { label: 'banana', y: 25 },
    { label: 'mango', y: 30 },
    { label: 'grape', y: 28 }
  ]
  dataTwo = [
    { label: 'apple', y: 10 },
    { label: 'orange', y: 15 },
    { label: 'banana', y: 25 },
    { label: 'mango', y: 30 },
    { label: 'grape', y: 28 }
  ]
  dataThree = [
    { label: 'apple', y: 10 },
    { label: 'orange', y: 15 },
    { label: 'banana', y: 25 },
    { label: 'mango', y: 30 },
    { label: 'grape', y: 28 }
  ]

  columnChartOptions = {
    animationEnabled: true,
    title: {
      text: 'Angular Column Chart in Bootstrap Tabs',
    },
    data: [{
        type: 'column',
        dataPoints: this.dataOne
    }]
  };
  lineChartOptions = {
    animationEnabled: true,
    title: {
      text: 'Angular Line Chart in Bootstrap Tabs',
    },
    data: [{
        type: 'line',
        dataPoints: this.dataTwo
      }]
  };
  pieChartOptions = {
    animationEnabled: true,
    title: {
      text: 'Angular Pie Chart in Bootstrap Tabs',
    },
    data: [{
        type: 'pie',
        dataPoints: this.dataThree
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

  public conteinerData: any;
  @ViewChild('map') mapElement: any;
  map!: google.maps.Map;
  private apiKey = 'AIzaSyDT7c9WiX0QDvFDopYb6gPLLFE1hi6eXnE';
  
  constructor( private gerenteService: GerenteService ) { }

  ngAfterViewInit() {
    this.loadGoogleMapsScript(() => this.initializeMap());
    this.showChart = true;
  }

  ngOnInit(): void {
    this.getAllClientesAtivos();
    this.loadData();
  }
  getAllClientesAtivos() {
    this.gerenteService.getAllClientesAtivos().subscribe( (res: any) => {
        this.clienteData = res;
      }
    );
  }
  
  loadData() {
    this.gerenteService.getAllClientesAtivos().subscribe( (res: any) => {
      this.clienteData = res;
      console.log(this.clienteData)
      console.log("aqui")
      this.getEndereco(this.clienteData);
    })
  };

  getEndereco(data: any) {
    for (let i = 0; i < data.length; i++) {
      let endereco = data[i].endereco;
console.log(endereco)
    }
  };

  private loadGoogleMapsScript(callback: () => void) {
    const script = document.createElement('script');
    script.src = `https://maps.googleapis.com/maps/api/js?key=${this.apiKey}`;
    script.onload = callback;
    document.body.appendChild(script);
  }

  getAdress(data: any) {

  };

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

/////////////////////////////////////////////////

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


