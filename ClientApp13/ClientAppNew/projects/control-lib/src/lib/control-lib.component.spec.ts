import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ControlLibComponent } from './control-lib.component';

describe('ControlLibComponent', () => {
  let component: ControlLibComponent;
  let fixture: ComponentFixture<ControlLibComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ControlLibComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ControlLibComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
