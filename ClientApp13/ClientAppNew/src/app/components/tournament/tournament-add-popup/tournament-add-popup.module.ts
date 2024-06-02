import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TournamentAddPopupComponent } from './tournament-add-popup.component';
import { ShareComponentModule } from 'src/app/shared/components/share-component.module';
import { TranslateModule } from '@ngx-translate/core';
import { ControlModule } from 'src/app/shared/control/control.module';



@NgModule({
  declarations: [TournamentAddPopupComponent],

  imports: [
    CommonModule,
    TranslateModule,
    ControlModule,
    ShareComponentModule
  ],
  exports: [TournamentAddPopupComponent]
})
export class TournamentAddPopupModule { }
