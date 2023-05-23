import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarEstadoAluguelComponent } from './editar-estado-aluguel.component';

describe('EditarEstadoAluguelComponent', () => {
  let component: EditarEstadoAluguelComponent;
  let fixture: ComponentFixture<EditarEstadoAluguelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditarEstadoAluguelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarEstadoAluguelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
