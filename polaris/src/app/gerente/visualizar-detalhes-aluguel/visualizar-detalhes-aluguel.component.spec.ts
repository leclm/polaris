import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarDetalhesAluguelComponent } from './visualizar-detalhes-aluguel.component';

describe('VisualizarDetalhesAluguelComponent', () => {
  let component: VisualizarDetalhesAluguelComponent;
  let fixture: ComponentFixture<VisualizarDetalhesAluguelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarDetalhesAluguelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarDetalhesAluguelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
