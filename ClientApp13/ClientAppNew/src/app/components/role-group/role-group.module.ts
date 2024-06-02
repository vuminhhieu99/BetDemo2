import { RoleGroupComponent } from './role-group.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RoleGroupRoutingModule } from './role-group-routing.module';
import { ShareComponentModule } from 'src/app/shared/components/share-component.module';
import { TranslateModule } from '@ngx-translate/core';
import { ControlModule } from 'src/app/shared/control/control.module';


@NgModule({
  declarations: [RoleGroupComponent],
  imports: [
    CommonModule,
    RoleGroupRoutingModule,
    TranslateModule,
    ControlModule,
    ShareComponentModule
  ]
})
export class RoleGroupModule { }
