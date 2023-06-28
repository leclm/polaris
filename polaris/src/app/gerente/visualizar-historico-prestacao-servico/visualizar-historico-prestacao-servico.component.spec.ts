import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarHistoricoPrestacaoServicoComponent } from './visualizar-historico-prestacao-servico.component';

describe('VisualizarHistoricoPrestacaoServicoComponent', () => {
  let component: VisualizarHistoricoPrestacaoServicoComponent;
  let fixture: ComponentFixture<VisualizarHistoricoPrestacaoServicoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarHistoricoPrestacaoServicoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarHistoricoPrestacaoServicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
