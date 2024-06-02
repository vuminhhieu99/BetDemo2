import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AhEmojiPopupComponent } from './emoji-popup.component';

describe('AhEmojiPopupComponent', () => {
  let component: AhEmojiPopupComponent;
  let fixture: ComponentFixture<AhEmojiPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AhEmojiPopupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AhEmojiPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
