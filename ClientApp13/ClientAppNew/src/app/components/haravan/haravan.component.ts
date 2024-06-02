import { Component, OnInit } from '@angular/core';
import { BaseListComponent } from 'src/app/shared/components/base-list/base-list.component';
import { ModuleCode } from 'src/app/shared/enumaration/module-code';
import { ConfigService } from 'src/app/shared/services/config/config.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-haravan',
  templateUrl: './haravan.component.html',
  styleUrls: ['./haravan.component.scss']
})
export class HaravanComponent  extends BaseListComponent implements OnInit {

  public override module = ModuleCode.Haravan;

  public urlList: string = `${environment.baseUrlServer}/${ModuleCode.Haravan}/Paging`;
  columns = [
    {
      name: "name", type: "text", width: 350,
      itemTemplate: function (value: any, item: any) {
        return `<div class="line-text-3 break-word" title="${value}">${value}</div>`;
      },
    },
    {
      name: "modifiedDate", type: "text", width: 450,
      itemTemplate: function (value: any, item: any) {
        return `<div class="line-text-3 break-word" title="${value}">${value}</div>`;
      },
    },
    { type: "control" }
  ];

  constructor(private configSV: ConfigService) {
    super();
  }

  override ngOnInit(): void {
    super.ngOnInit();
  }

  connect(){
    const me =this;
    const haravanOAuth = me.configSV.getConfig("HaravanOAuth");

  }
}
