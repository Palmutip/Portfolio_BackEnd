import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VariacoesComponent } from './variacoes.component';

describe('VariacoesComponent', () => {
  let component: VariacoesComponent;
  let fixture: ComponentFixture<VariacoesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VariacoesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VariacoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
