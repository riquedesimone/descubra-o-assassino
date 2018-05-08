import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DescubraComponent } from './descubra.component';

describe('DescubraComponent', () => {
  let component: DescubraComponent;
  let fixture: ComponentFixture<DescubraComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DescubraComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DescubraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
