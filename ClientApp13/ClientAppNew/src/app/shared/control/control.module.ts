import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComboboxComponent } from './combobox/combobox.component';
import { RadioComponent } from './radio/radio.component';
import { CheckboxComponent } from './checkbox/checkbox.component';
import { ImageSliderComponent } from './image-slider/image-slider.component';
import { DateComponent } from './date/date.component';
import { DaterangeComponent } from './daterange/daterange.component';
import { TextareaComponent } from './textarea/textarea.component';
import { EmojiPopupComponent } from './emoji-popup/emoji-popup.component';
import { TextboxComponent } from './textbox/textbox.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatTooltipModule } from '@angular/material/tooltip';
import { TranslateModule } from '@ngx-translate/core';
import { FileComponent } from './file/file.component';



@NgModule({
  declarations: [
    TextboxComponent,
    ComboboxComponent,
    RadioComponent,
    CheckboxComponent,
    ImageSliderComponent,
    DateComponent,
    DaterangeComponent,
    EmojiPopupComponent,
    TextareaComponent,
    FileComponent   
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    MatTooltipModule,
    TranslateModule
  ],
  exports:[
    TextboxComponent,
    ComboboxComponent,
    RadioComponent,
    CheckboxComponent,
    ImageSliderComponent,
    DateComponent,
    DaterangeComponent,
    EmojiPopupComponent,
    TextareaComponent
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA]
})
export class ControlModule { }
