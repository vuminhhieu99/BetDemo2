import { Component, Directive, Input, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { ModuleCode } from '../../enumaration/module-code';
import { BaseFunction } from '../../function/function-base';

@Directive()
export abstract class BaseListComponent implements OnInit, OnDestroy {

  private _unDestroy: Subject<any> = new Subject<any>();

  public moduleCode = ModuleCode;

  public module: any;
  @Input()
  isCheckboxList = false;

  // tìm kiếm của màn hình danh sách
  searchText = '123';

  constructor() { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    BaseFunction.unDestroy(this._unDestroy);
  }
}
