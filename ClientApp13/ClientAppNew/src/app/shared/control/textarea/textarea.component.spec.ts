import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AhTextareaComponent } from './textarea.component';

describe('AhTextareaComponent', () => {
  let component: AhTextareaComponent;
  let fixture: ComponentFixture<AhTextareaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AhTextareaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AhTextareaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
