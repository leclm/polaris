import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManterServicoComponent } from './manter-servico.component';

describe('ManterServicoComponent', () => {
  let component: ManterServicoComponent;
  let fixture: ComponentFixture<ManterServicoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManterServicoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManterServicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
