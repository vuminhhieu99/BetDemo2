import { Component, OnInit, Input, forwardRef, Output, EventEmitter } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { BaseControl } from '../../base/_control/base-control';
import { TypeTextBox } from '../../enumaration/type-control';

@Component({
  selector: 'app-textbox',
  templateUrl: './textbox.component.html',
  styleUrls: ['./textbox.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => TextboxComponent),
      multi: true
    }
  ]
})
export class TextboxComponent extends BaseControl implements  ControlValueAccessor,OnInit {
    
  @Input() type: TypeTextBox = TypeTextBox.Default;
  onChange = (value: any)=>{};

  onTouched = (value: any)=>{};
  constructor() {
    super();
  }
  
  writeValue(obj: any): void {
    switch(this.type){
      case TypeTextBox.Text:
        
        break;
    }
    this.value = obj;
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn
  }

  override ngOnInit(): void {
    super.ngOnInit();
  }

}
