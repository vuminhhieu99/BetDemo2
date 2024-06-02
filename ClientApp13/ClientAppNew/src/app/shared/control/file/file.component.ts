import { Component, Input, OnInit, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { BaseControl } from '../../base/_control/base-control';
import { TypeTextBox } from '../../enumaration/type-control';

@Component({
  selector: 'app-file',
  templateUrl: './file.component.html',
  styleUrls: ['./file.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => FileComponent),
      multi: true
    }
  ]
})
export class FileComponent extends BaseControl implements  ControlValueAccessor,OnInit{
  @Input() type: TypeTextBox = TypeTextBox.Default;
  onChange = (value: any)=>{};

  onTouched = (value: any)=>{};
  constructor() {
    super();
  }
  
  writeValue(obj: any): void {    
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
