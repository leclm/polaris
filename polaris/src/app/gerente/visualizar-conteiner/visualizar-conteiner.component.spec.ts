import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarConteinerComponent } from './visualizar-conteiner.component';

describe('VisualizarConteinerComponent', () => {
  let component: VisualizarConteinerComponent;
  let fixture: ComponentFixture<VisualizarConteinerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarConteinerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarConteinerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
