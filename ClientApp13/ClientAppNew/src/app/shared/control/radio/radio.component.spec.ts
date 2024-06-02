import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AhRadioComponent } from './radio.component';

describe('AhRadioComponent', () => {
  let component: AhRadioComponent;
  let fixture: ComponentFixture<AhRadioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AhRadioComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AhRadioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
