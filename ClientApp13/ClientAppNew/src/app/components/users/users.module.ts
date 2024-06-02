import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './users.component';
import { ShareComponentModule } from 'src/app/shared/components/share-component.module';
import { TranslateModule } from '@ngx-translate/core';
import { ControlModule } from 'src/app/shared/control/control.module';


@NgModule({
  declarations: [UsersComponent],
  imports: [
    CommonModule,
    UsersRoutingModule,
    TranslateModule,
    ControlModule,
    ShareComponentModule
  ]
})
export class UsersModule { }
