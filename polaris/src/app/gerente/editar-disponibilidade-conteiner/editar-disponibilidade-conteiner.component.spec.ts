import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarDisponibilidadeConteinerComponent } from './editar-disponibilidade-conteiner.component';

describe('EditarDisponibilidadeConteinerComponent', () => {
  let component: EditarDisponibilidadeConteinerComponent;
  let fixture: ComponentFixture<EditarDisponibilidadeConteinerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditarDisponibilidadeConteinerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarDisponibilidadeConteinerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
