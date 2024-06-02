import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MenuTooltbarComponent } from './menu-tooltbar/menu-tooltbar.component';
import { ButtonComponent } from './button/button.component';
import { FormListComponent } from './form-list/form-list.component';
import { GridComponent } from './grid/grid.component';
import { GridFilterComponent } from './grid-filter/grid-filter.component';
import { FormPopupComponent } from './form-popup/form-popup.component';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { TranslateModule } from '@ngx-translate/core';
import { MatTooltipModule} from '@angular/material/tooltip';
import { SlideToggleComponent } from '../control/slide-toggle/slide-toggle.component';
import { ControlModule } from '../control/control.module';



@NgModule({
  declarations: [
    MenuTooltbarComponent, 
    ButtonComponent,
    FormListComponent,
    GridComponent,
    GridFilterComponent,   
    SlideToggleComponent,
    FormPopupComponent,
     
  ],
  imports: [   
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    ControlModule,
    TranslateModule,
    PerfectScrollbarModule,
    MatTooltipModule,
    
  ],
  exports: [
    MenuTooltbarComponent, 
    ButtonComponent,
    FormListComponent,
    GridComponent,
    GridFilterComponent,   
    SlideToggleComponent,
    FormPopupComponent,    
  ]
})
export class ShareComponentModule { }
