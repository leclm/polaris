import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarServicosComponent } from './visualizar-servicos.component';

describe('VisualizarServicosComponent', () => {
  let component: VisualizarServicosComponent;
  let fixture: ComponentFixture<VisualizarServicosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarServicosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarServicosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
