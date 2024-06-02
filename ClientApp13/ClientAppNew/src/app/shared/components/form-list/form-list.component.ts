import { Component, Input, OnInit, TemplateRef } from '@angular/core';

@Component({
  selector: 'app-form-list',
  templateUrl: './form-list.component.html',
  styleUrls: ['./form-list.component.scss']
})
export class FormListComponent implements OnInit {

  // các lựa chọn cho grid
  @Input()
  toolbar!: TemplateRef<any>;

  /**
   * các  lựa chọn cho grid khi check box
   */
  @Input()
  toolbarCheckbox!: TemplateRef<any>;

  /**
   * grid
   */
  @Input()
  grid!: TemplateRef<any>;

  /**
   * Thông tin sidebarRight
   */
  @Input()
  sidebarRight!: TemplateRef<any>;
  constructor() { }

  /**
   * Người dùng có đang tích 1 bản ghi
   */
  @Input()
  isCheckboxList: boolean = false;

  /**
   * Show sidebar
   */
  isShowSideBarRight: boolean = true;
  ngOnInit(): void {
  }
  

}
