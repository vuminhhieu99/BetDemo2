import { HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, EventEmitter, NgZone, OnDestroy, OnInit, Output } from '@angular/core';
import { Subject } from 'rxjs';
import { AppVariable } from '../../constants/app-variable';
import { LocalStorageKey } from '../../constants/loca-storage-key';
import { BaseFunction } from '../../function/function-base';
import { LocalStorage } from '../../function/local-storage';

declare const $: any;

@Component({
  selector: 'app-emoji-popup',
  templateUrl: './emoji-popup.component.html',
  styleUrls: ['./emoji-popup.component.scss']
})
export class EmojiPopupComponent implements OnInit, OnDestroy {

  public _onDestroySub: Subject<any> = new Subject();

  emojiList: Array<any>  = [];
  // Danh sách các loại emoji
  emojiCategoryList:  Array<any>  = [];

  @Output()
  dataEmit = new EventEmitter<any>();

  constructor(private zone: NgZone, private el: ElementRef) { }

  ngOnInit(): void {
    this.getEmoij();
  }

  private getEmoij(): void {
    const me = this;
    if(LocalStorage.get(LocalStorageKey.EmojiText)){
      let data = JSON.parse(LocalStorage.get(LocalStorageKey.EmojiText) || "");
      me.emojiList = data;
      me.emojiCategoryList = []
      for(let item of data){
        me.emojiCategoryList.push({
          name: item['type'],
          text: item['data'][0]
        })
      }
    }
    else{
      const contentHeader = new HttpHeaders({ "Content-Type": "application/json"});
      contentHeader.set("Access-Control-Allow-Origin", "*");
      contentHeader.set("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Origin, Accept");
      let apiAddress = `${AppVariable.Emoji}`;
      this.zone.runOutsideAngular(()=>{
        $.get(apiAddress, function (response: any){
          if (response){
            const data = JSON.parse(JSON.stringify(response));
            if(data){
              me.emojiList = data;
              for(let item of data){
                me.emojiCategoryList.push({
                  name: item['type'],
                  text: item['data'][0]
                })
              }
            }
            LocalStorage.set(LocalStorageKey.EmojiText, JSON.stringify(data));
          }
          me.zone.run(()=>{ });
        });
      });
    }
  }

  choose(data: string){
    this.dataEmit.emit(data);
  }

  scrollCategory(category: string){
    var element = "#" + category;
    if($(element).lenght > 0){
      $(element)[0].scrollCategory(category);
    }
  }

  ngOnDestroy(): void {
      BaseFunction.unDestroy(this._onDestroySub)
  }

}
