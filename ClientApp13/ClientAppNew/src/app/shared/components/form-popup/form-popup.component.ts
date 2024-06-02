import { Component, EventEmitter, Input, OnInit, Output, TemplateRef } from '@angular/core';

@Component({
  selector: 'app-form-popup',
  templateUrl: './form-popup.component.html',
  styleUrls: ['./form-popup.component.scss']
})
export class FormPopupComponent implements OnInit {

  @Input()
  title: string = '';

  @Input()
  itemHead! : TemplateRef<any>;

  @Input()
  content! : TemplateRef<any>;

  @Input()
  footer! : TemplateRef<any>;

  @Output()
  closePopup: EventEmitter<any> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  close(e: any): void {
    this.closePopup.emit(e);
  }

}
