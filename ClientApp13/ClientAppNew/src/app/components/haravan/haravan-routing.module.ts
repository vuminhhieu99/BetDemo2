import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HaravanComponent } from './haravan.component';

const routes: Routes = [
  {
    path: '',
    component:  HaravanComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HaravanRoutingModule { }
