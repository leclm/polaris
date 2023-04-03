import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VisualizarTiposComponent } from './visualizar-tipos.component';

describe('VisualizarTiposComponent', () => {
  let component: VisualizarTiposComponent;
  let fixture: ComponentFixture<VisualizarTiposComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VisualizarTiposComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VisualizarTiposComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
