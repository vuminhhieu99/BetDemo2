import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AhGridFilterComponent } from './grid-filter.component';

describe('AhGridFilterComponent', () => {
  let component: AhGridFilterComponent;
  let fixture: ComponentFixture<AhGridFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AhGridFilterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AhGridFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
