import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarTerceirizadoComponent } from './editar-terceirizado.component';

describe('EditarTerceirizadoComponent', () => {
  let component: EditarTerceirizadoComponent;
  let fixture: ComponentFixture<EditarTerceirizadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditarTerceirizadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarTerceirizadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
