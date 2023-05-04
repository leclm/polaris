import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManterPrestacaoServicoComponent } from './manter-prestacao-servico.component';

describe('ManterPrestacaoServicoComponent', () => {
  let component: ManterPrestacaoServicoComponent;
  let fixture: ComponentFixture<ManterPrestacaoServicoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManterPrestacaoServicoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManterPrestacaoServicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
