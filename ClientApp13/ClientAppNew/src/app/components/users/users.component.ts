import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/shared/components/base-list/base-list.component';
import { ModuleCode } from 'src/app/shared/enumaration/module-code';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent extends BaseListComponent implements OnInit {

  public override module = ModuleCode.Users;

  columns = [
    {
      name: "question", type: "text", width: 350,
      itemTemplate: function (value: any, item: any) {
        return `<div class="line-text-3 break-word" title="${value}">${value}</div>`;
      },
    },
    {
      name: "answer", type: "text", width: 450,
      itemTemplate: function (value: any, item: any) {
        return `<div class="line-text-3 break-word" title="${value}">${value}</div>`;
      },
    },
    { type: "control" }
  ]
  constructor() {
    super();
  }

  override ngOnInit(): void {
  }

  /**
   * Thêm người dùng mới
   */
  addUser(){
    ;
  }

}
