import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarConteinerComponent } from './editar-conteiner.component';

describe('EditarConteinerComponent', () => {
  let component: EditarConteinerComponent;
  let fixture: ComponentFixture<EditarConteinerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditarConteinerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarConteinerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
