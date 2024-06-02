import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TournamentAddPopupComponent } from './tournament-add-popup.component';

describe('TournamentAddPopupComponent', () => {
  let component: TournamentAddPopupComponent;
  let fixture: ComponentFixture<TournamentAddPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TournamentAddPopupComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TournamentAddPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
