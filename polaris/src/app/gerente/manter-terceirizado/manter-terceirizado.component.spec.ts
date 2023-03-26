import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManterTerceirizadoComponent } from './manter-terceirizado.component';

describe('ManterTerceirizadoComponent', () => {
  let component: ManterTerceirizadoComponent;
  let fixture: ComponentFixture<ManterTerceirizadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManterTerceirizadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManterTerceirizadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
