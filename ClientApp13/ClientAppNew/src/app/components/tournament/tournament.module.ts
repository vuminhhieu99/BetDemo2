import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TournamentRoutingModule } from './tournament-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { ShareComponentModule } from 'src/app/shared/components/share-component.module';
import { TournamentComponent } from './tournament.component';
import { TournamentAddPopupModule } from './tournament-add-popup/tournament-add-popup.module';
import { MatDialogModule } from '@angular/material/dialog';
import { ControlModule } from 'src/app/shared/control/control.module';




@NgModule({
  declarations: [TournamentComponent],
  imports: [
    CommonModule,
    MatDialogModule,
    TournamentRoutingModule,
    TranslateModule,
    ControlModule,
    ShareComponentModule,
    TournamentAddPopupModule    
  ]  
})
export class TournamentModule { }
