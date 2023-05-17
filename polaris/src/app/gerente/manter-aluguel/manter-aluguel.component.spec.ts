import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManterAluguelComponent } from './manter-aluguel.component';

describe('ManterAluguelComponent', () => {
  let component: ManterAluguelComponent;
  let fixture: ComponentFixture<ManterAluguelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManterAluguelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManterAluguelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
