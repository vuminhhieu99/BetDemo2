import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AhCheckboxComponent } from './checkbox.component';

describe('AhCheckboxComponent', () => {
  let component: AhCheckboxComponent;
  let fixture: ComponentFixture<AhCheckboxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AhCheckboxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AhCheckboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
