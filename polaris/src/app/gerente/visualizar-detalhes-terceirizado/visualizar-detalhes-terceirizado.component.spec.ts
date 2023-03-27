import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarDetalhesTerceirizadoComponent } from './visualizar-detalhes-terceirizado.component';

describe('VisualizarDetalhesTerceirizadoComponent', () => {
  let component: VisualizarDetalhesTerceirizadoComponent;
  let fixture: ComponentFixture<VisualizarDetalhesTerceirizadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarDetalhesTerceirizadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarDetalhesTerceirizadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
