import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/shared/components/base-list/base-list.component';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent extends BaseListComponent implements OnInit {

  columns = [
    {
      name: "description", type: "text", width: 450,
      itemTemplate: function (value: any, item: any) {
        return `<div class="line-text-3 break-word" title="${value}">${value}</div>`;
      }
    },
    { name: "name", type: "text", width: 250 },
    { type: "control" }
  ]

  constructor() {
    super();
  }

  override ngOnInit(): void {
  }

  /**
   * Thêm quyền
   * vmhieu
   */
  addRole() {
    ;
  }

}
