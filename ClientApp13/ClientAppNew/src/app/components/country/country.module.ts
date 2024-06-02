import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CountryRoutingModule } from './country-routing.module';
import { TranslateModule } from '@ngx-translate/core';
import { ControlModule } from 'src/app/shared/control/control.module';
import { ShareComponentModule } from 'src/app/shared/components/share-component.module';
import { CountryComponent } from './country.component';
import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [CountryComponent],
  imports: [
    CommonModule,
    CountryRoutingModule,
    TranslateModule,
    MatDialogModule,
    ControlModule,
    ShareComponentModule,
  ]
})
export class CountryModule { }
