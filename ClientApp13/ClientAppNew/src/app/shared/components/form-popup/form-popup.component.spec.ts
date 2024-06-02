import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AhFormPopupComponent } from './form-popup.component';

describe('AhFormPopupComponent', () => {
  let component: AhFormPopupComponent;
  let fixture: ComponentFixture<AhFormPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AhFormPopupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AhFormPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
