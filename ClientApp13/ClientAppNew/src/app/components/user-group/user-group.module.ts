import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserGroupRoutingModule } from './user-group-routing.module';
import { UserGroupComponent } from './user-group.component';
import { ShareComponentModule } from 'src/app/shared/components/share-component.module';


@NgModule({
  declarations: [UserGroupComponent],
  imports: [
    CommonModule,
    UserGroupRoutingModule,
    ShareComponentModule
  ]
})
export class UserGroupModule { }
