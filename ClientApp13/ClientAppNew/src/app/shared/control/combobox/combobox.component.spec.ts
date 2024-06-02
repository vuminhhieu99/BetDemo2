import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AhComboboxComponent } from './combobox.component';

describe('AhComboboxComponent', () => {
  let component: AhComboboxComponent;
  let fixture: ComponentFixture<AhComboboxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AhComboboxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AhComboboxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
