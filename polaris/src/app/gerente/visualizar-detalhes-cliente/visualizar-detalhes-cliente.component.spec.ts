import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarDetalhesClienteComponent } from './visualizar-detalhes-cliente.component';

describe('VisualizarDetalhesClienteComponent', () => {
  let component: VisualizarDetalhesClienteComponent;
  let fixture: ComponentFixture<VisualizarDetalhesClienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarDetalhesClienteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarDetalhesClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
