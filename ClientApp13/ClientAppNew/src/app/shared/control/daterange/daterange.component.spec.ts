import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AhDaterangeComponent } from './daterange.component';

describe('AhDaterangeComponent', () => {
  let component: AhDaterangeComponent;
  let fixture: ComponentFixture<AhDaterangeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AhDaterangeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AhDaterangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
