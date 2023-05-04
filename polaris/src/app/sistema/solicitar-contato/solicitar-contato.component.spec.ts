import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SolicitarContatoComponent } from './solicitar-contato.component';

describe('SolicitarContatoComponent', () => {
  let component: SolicitarContatoComponent;
  let fixture: ComponentFixture<SolicitarContatoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SolicitarContatoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SolicitarContatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
