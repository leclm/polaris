import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManterConteinerComponent } from './manter-conteiner.component';

describe('ManterConteinerComponent', () => {
  let component: ManterConteinerComponent;
  let fixture: ComponentFixture<ManterConteinerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManterConteinerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManterConteinerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
