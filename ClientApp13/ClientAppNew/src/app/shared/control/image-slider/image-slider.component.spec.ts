import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AhImageSliderComponent } from './image-slider.component';

describe('AhImageSliderComponent', () => {
  let component: AhImageSliderComponent;
  let fixture: ComponentFixture<AhImageSliderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AhImageSliderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AhImageSliderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
