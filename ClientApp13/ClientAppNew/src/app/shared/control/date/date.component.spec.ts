import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AhDateComponent } from './date.component';

describe('AhDateComponent', () => {
  let component: AhDateComponent;
  let fixture: ComponentFixture<AhDateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AhDateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AhDateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
