import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HaravanRoutingModule } from './haravan-routing.module';
import { HaravanComponent } from './haravan.component';
import { TranslateModule } from '@ngx-translate/core';
import { ControlModule } from 'src/app/shared/control/control.module';
import { ShareComponentModule } from 'src/app/shared/components/share-component.module';


@NgModule({
  declarations: [HaravanComponent],
  imports: [
    CommonModule,
    HaravanRoutingModule,
    TranslateModule,
    ControlModule,
    ShareComponentModule
  ]
})
export class HaravanModule { }
