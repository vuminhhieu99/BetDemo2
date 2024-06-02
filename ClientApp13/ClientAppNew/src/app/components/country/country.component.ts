import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BaseListComponent } from 'src/app/shared/components/base-list/base-list.component';
import { ModuleCode } from 'src/app/shared/enumaration/module-code';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss']
})
export class CountryComponent extends BaseListComponent implements OnInit {
  public override module = ModuleCode.Country;
  constructor(public dialog: MatDialog) {
    super();
  }

  override ngOnInit(): void {
    super.ngOnInit();
  }
}
