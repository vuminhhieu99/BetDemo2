import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AhSlideToggleComponent } from './slide-toggle.component';

describe('AhSlideToggleComponent', () => {
  let component: AhSlideToggleComponent;
  let fixture: ComponentFixture<AhSlideToggleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AhSlideToggleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AhSlideToggleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
