import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarHistoricoAlugueisComponent } from './visualizar-historico-alugueis.component';

describe('VisualizarHistoricoAlugueisComponent', () => {
  let component: VisualizarHistoricoAlugueisComponent;
  let fixture: ComponentFixture<VisualizarHistoricoAlugueisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarHistoricoAlugueisComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarHistoricoAlugueisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
