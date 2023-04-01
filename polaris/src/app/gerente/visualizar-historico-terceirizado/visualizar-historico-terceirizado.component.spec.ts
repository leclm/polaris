import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarHistoricoTerceirizadoComponent } from './visualizar-historico-terceirizado.component';

describe('VisualizarHistoricoTerceirizadoComponent', () => {
  let component: VisualizarHistoricoTerceirizadoComponent;
  let fixture: ComponentFixture<VisualizarHistoricoTerceirizadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarHistoricoTerceirizadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarHistoricoTerceirizadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
