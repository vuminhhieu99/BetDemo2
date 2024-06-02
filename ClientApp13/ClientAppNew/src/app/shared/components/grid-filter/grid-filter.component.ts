import { Component, Input, OnInit } from '@angular/core';
import { Operator } from '../../enumaration/operator';

@Component({
  selector: 'app-grid-filter',
  templateUrl: './grid-filter.component.html',
  styleUrls: ['./grid-filter.component.scss']
})
export class GridFilterComponent implements OnInit {

  constructor() { }

  @Input()
  columns: any;

  filterTreeObject: any = {
    operator : Operator.Add,
    items : []
  };
   

  ngOnInit(): void {
  }

}
