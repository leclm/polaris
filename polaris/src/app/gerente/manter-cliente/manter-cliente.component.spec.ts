import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManterClienteComponent } from './manter-cliente.component';

describe('ManterClienteComponent', () => {
  let component: ManterClienteComponent;
  let fixture: ComponentFixture<ManterClienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManterClienteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManterClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
