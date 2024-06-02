import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/shared/components/base-list/base-list.component';
import { ModuleCode } from 'src/app/shared/enumaration/module-code';
import {MatDialog} from '@angular/material/dialog';
import { TournamentAddPopupComponent } from './tournament-add-popup/tournament-add-popup.component';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-tournament',
  templateUrl: './tournament.component.html',
  styleUrls: ['./tournament.component.scss']
})
export class TournamentComponent extends BaseListComponent implements OnInit {

  public override module = ModuleCode.Tournament;

  public urlList: string = `${environment.baseUrlServer}/${ModuleCode.Tournament}/Paging`;
  columns = [
    {
      name: "name", type: "text", width: 350,
      itemTemplate: function (value: any, item: any) {
        return `<div class="line-text-3 break-word" title="${value}">${value}</div>`;
      },
    },
    {
      name: "modifiedDate", type: "text", width: 450,
      itemTemplate: function (value: any, item: any) {
        return `<div class="line-text-3 break-word" title="${value}">${value}</div>`;
      },
    },
    { type: "control" }
  ]
  constructor(public dialog: MatDialog) {
    super();
  }

  override ngOnInit(): void {
    super.ngOnInit();
  }

  /**
   * Thêm giải đấu mới
   */
   addTournament(){
    const config = {
      height: '400px',
      width: '600px',
    }
    const dialogRef = this.dialog.open(TournamentAddPopupComponent, config);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

}
