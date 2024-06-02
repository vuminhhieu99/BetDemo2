import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Tournament } from 'src/app/shared/models/tournament/tournament';

@Component({
  selector: 'app-tournament-add-popup',
  templateUrl: './tournament-add-popup.component.html',
  styleUrls: ['./tournament-add-popup.component.scss']
})
export class TournamentAddPopupComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<TournamentAddPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Object) { }

  /**
   * Trạng thái popup
   */
  isView : boolean = false;

  currentData :Tournament = new Tournament;
  ngOnInit(): void {
  }

  onClose(): void {
    this.dialogRef.close();
  }
}
