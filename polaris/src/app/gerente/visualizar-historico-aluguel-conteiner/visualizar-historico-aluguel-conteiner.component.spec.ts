import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarHistoricoAluguelConteinerComponent } from './visualizar-historico-aluguel-conteiner.component';

describe('VisualizarHistoricoAluguelConteinerComponent', () => {
  let component: VisualizarHistoricoAluguelConteinerComponent;
  let fixture: ComponentFixture<VisualizarHistoricoAluguelConteinerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarHistoricoAluguelConteinerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarHistoricoAluguelConteinerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
