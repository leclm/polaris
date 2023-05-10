import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarHistoricoClienteComponent } from './visualizar-historico-cliente.component';

describe('VisualizarHistoricoClienteComponent', () => {
  let component: VisualizarHistoricoClienteComponent;
  let fixture: ComponentFixture<VisualizarHistoricoClienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarHistoricoClienteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarHistoricoClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
