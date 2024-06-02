import { Component, forwardRef, OnInit, AfterViewInit, ElementRef, ViewChild, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { BaseControl } from '../../base/_control/base-control';
import { BaseFunction } from '../../function/function-base';

declare const $: any;
@Component({
  selector: 'app-combobox',
  templateUrl: './combobox.component.html',
  styleUrls: ['./combobox.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ComboboxComponent),
      multi: true
    }
  ]
})
export class ComboboxComponent extends BaseControl implements  ControlValueAccessor, OnInit, AfterViewInit {


  /**
   * Phần tử element của input
   */
  private element!: any;

  /**
   * Tên hiển thị trên options
   */
  displayName: string = 'Text';


  /**
   * Giá trị trên options
   */
  valueName: string = 'ID';

  /**
   * Giá trị của options
   */
  data: Array<any> = [];

  /**
   * linh dữ liệu trên options
   */
  url: string = ''; //

  @ViewChild("input", {static : true, read : ElementRef}) input!: ElementRef;

  @Input() placeholder: string = ''; //
  @Input() multiple: boolean = false;


  constructor() {
    super();
  }
  writeValue(obj: any): void {
    throw new Error('Method not implemented.');
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
  }

  ngAfterViewInit(): void {
    const me = this;
    me.element = $(me.input.nativeElement);
    me.element.select2({
      placeholder : me.placeholder,
      multiple : me.multiple,
      disabled : me.disabled,
      data: me.data.map(item=>{
        const id = me.valueName || "id";
        const text = me.displayName || "text";
        const newItem = BaseFunction.cloneDeepData(item);
        newItem.id = item[id];
        newItem.text = item[text];
        return newItem;
      })
    });
  }
}
