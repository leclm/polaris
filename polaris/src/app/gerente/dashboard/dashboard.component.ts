import { Component, OnInit, ViewChild } from '@angular/core';
import {} from 'googlemaps';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  @ViewChild('map') mapElement: any;
  map!: google.maps.Map;
  private apiKey = '';
  
  constructor() { }

  ngAfterViewInit() {
    this.loadGoogleMapsScript(() => this.initializeMap());
  }

  ngOnInit(): void {
  }

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
    position: { lat: -25.363, lng: 120.044 },
    map,
    title: "Hello World!",
  });

  google.maps.event.addListener(marker, 'click', function() {
    window.location.href = 'http://www.google.com/';
    window.open('http://www.google.com/', '_blank');
  });
}}


