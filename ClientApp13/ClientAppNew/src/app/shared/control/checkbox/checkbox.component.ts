import { Component, forwardRef, Input, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { BaseControl } from '../../base/_control/base-control';
import { BaseFunction } from '../../function/function-base';

@Component({
  selector: 'app-checkbox',
  templateUrl: './checkbox.component.html',
  styleUrls: ['./checkbox.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CheckboxComponent),
      multi: true
    }
  ]
})
export class CheckboxComponent extends BaseControl implements ControlValueAccessor, OnInit {

  /**
   * Text phía sau checkbox
   */
  @Input()
  lableAfterCheck: string = "";  

   /**
   *Kiểu button lấy theo boostrap
   */
 
   private _type = '';
   @Input()
   get Type(){
     return this._type;
   }
   set Type(value: any){
     if(!value){
      value = '';
     }     
     this._type =`icheck-${value}`;
   }
  constructor() {
    super();
  }
  writeValue(obj: any): void {
    if(BaseFunction.IsNullOrEmpty(obj)){
      this.value = false;
    }
    else{
      this.value = Boolean(obj);
    }
  }
  registerOnChange(fn: any): void {
    throw new Error('Method not implemented.');
  }
  registerOnTouched(fn: any): void {
    throw new Error('Method not implemented.');
  }
  setDisabledState?(isDisabled: boolean): void {
    throw new Error('Method not implemented.');
  }

  override ngOnInit(): void {
    super.ngOnInit();
  }

}
