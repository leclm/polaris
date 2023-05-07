import { Component, OnInit } from '@angular/core';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-pagina-inicial',
  templateUrl: './pagina-inicial.component.html',
  styleUrls: ['./pagina-inicial.component.scss'],
})
export class PaginaInicialComponent implements OnInit {
  images = [    
    {
      "path": "../../../assets/images/png/conteiner/conteiner-escritorio.jpeg",
      "altText": "Contêiner Habitável - Escritório",
      "type": "Escritório",
      "width": 900,
      "height": 500
    },
    {
      "path": "../../../assets/images/png/conteiner/conteiner-almoxarifado.jpeg",
      "altText": "Contêiner Habitável - Almoxarifado",
      "type": "Almoxarifado",
      "width": 900,
      "height": 500
    },
    {
      "path": "../../../assets/images/png/conteiner/conteiner-alojamento.jpeg",
      "altText": "Contêiner Habitável - Alojamento",
      "type": "Alojamento",
      "width": 900,
      "height": 500
    },
    {
      "path": "../../../assets/images/png/conteiner/conteiner-camarim.jpeg",
      "altText": "Contêiner Habitável - Camarim",
      "type": "Camarim",
      "width": 900,
      "height": 500
    },
    {
      "path": "../../../assets/images/png/conteiner/conteiner-refeitorio.jpeg",
      "altText": "Contêiner Habitável - Refeitório",
      "type": "Refeitório",
      "width": 900,
      "height": 500
    },
    {
      "path": "../../../assets/images/png/conteiner/conteiner-toalete.jpeg",
      "altText": "Contêiner Habitável - Toalete",
      "type": "Toalete",
      "width": 900,
      "height": 500
    },
    {
      "path": "../../../assets/images/png/conteiner/conteiner-educacional.jpeg",
      "altText": "Contêiner Habitável - Educacional",
      "type": "Educacional",
      "width": 900,
      "height": 500
    },
    {
      "path": "../../../assets/images/png/conteiner/conteiner-guarita.jpeg",
      "altText": "Contêiner Habitável - Guarita",
      "type": "Guarita",
      "width": 900,
      "height": 500
    }
  ]

  paused = false;
	unpauseOnArrow = false;
	pauseOnIndicator = false;
	pauseOnHover = true;
	pauseOnFocus = true;

  constructor(config: NgbCarouselConfig) {
    config.interval = 2000;
    config.keyboard = true;
    config.pauseOnHover = true;
    config.wrap = true;
    config.showNavigationIndicators = true;
  }

  ngOnInit(): void {
  }
}
