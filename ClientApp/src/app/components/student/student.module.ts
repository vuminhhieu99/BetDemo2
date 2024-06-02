import { StudentComponent } from './student.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentRoutingModule } from './student-routing.module';
import { ShareComponentModule } from 'src/app/shared/components/share-component.module';


@NgModule({
  declarations: [StudentComponent],
  imports: [
    CommonModule,
    StudentRoutingModule,
    ShareComponentModule
  ]
})
export class StudentModule { }
