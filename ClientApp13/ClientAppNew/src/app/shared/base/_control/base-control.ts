import {OnInit, Input, Output, EventEmitter, Directive } from '@angular/core';

@Directive()
export class BaseControl implements  OnInit {

  /**
   * Control cho form view
   */
  @Input()
  isView: boolean = false;

  /**
   * Có cho phép chỉnh sửa nội dung khi ở form view
   */
  @Input()
  isAllowEdit: boolean = false;

  @Input()
  isHorizontal: boolean = false;

  @Input()
  isShowLabel: boolean = true;

  @Input()
  label: string ='';

  @Input() 
  name: string = "";

  @Input()
  public value: any;

  

  @Output()
  valueChange = new EventEmitter<any>();

  @Input()
  error: any = {
    isError: false,
    text: ''
  }
  @Input()
  icon : string = '';

  @Input()
  iconRight: boolean = false;

  @Input()
  iconLeft: boolean = false;

  /**
   * Có disabled control
   */
  @Input()
  disabled: boolean = false;
  
  constructor(){

  }

  ngOnInit(): void {

  }

  dataChanged(value: any){
    this.valueChange.emit(value);
  }

}
