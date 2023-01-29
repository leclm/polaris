import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesAluguelComponent } from './detalhes-aluguel.component';

describe('DetalhesAluguelComponent', () => {
  let component: DetalhesAluguelComponent;
  let fixture: ComponentFixture<DetalhesAluguelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetalhesAluguelComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhesAluguelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
