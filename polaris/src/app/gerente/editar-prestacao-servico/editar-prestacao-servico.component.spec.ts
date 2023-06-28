import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarPrestacaoServicoComponent } from './editar-prestacao-servico.component';

describe('EditarPrestacaoServicoComponent', () => {
  let component: EditarPrestacaoServicoComponent;
  let fixture: ComponentFixture<EditarPrestacaoServicoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditarPrestacaoServicoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarPrestacaoServicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
