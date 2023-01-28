import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarAluguelComponent } from './visualizar-aluguel.component';

describe('VisualizarAluguelComponent', () => {
  let component: VisualizarAluguelComponent;
  let fixture: ComponentFixture<VisualizarAluguelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarAluguelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarAluguelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
