import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManterTipoComponent } from './manter-tipo.component';

describe('ManterTipoComponent', () => {
  let component: ManterTipoComponent;
  let fixture: ComponentFixture<ManterTipoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManterTipoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManterTipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
