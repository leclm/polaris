import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarTerceirizadosComponent } from './visualizar-terceirizados.component';

describe('VisualizarTerceirizadosComponent', () => {
  let component: VisualizarTerceirizadosComponent;
  let fixture: ComponentFixture<VisualizarTerceirizadosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarTerceirizadosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarTerceirizadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
