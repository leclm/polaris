import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarEstoqueConteineresComponent } from './visualizar-estoque-conteineres.component';

describe('VisualizarEstoqueConteineresComponent', () => {
  let component: VisualizarEstoqueConteineresComponent;
  let fixture: ComponentFixture<VisualizarEstoqueConteineresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarEstoqueConteineresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarEstoqueConteineresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
