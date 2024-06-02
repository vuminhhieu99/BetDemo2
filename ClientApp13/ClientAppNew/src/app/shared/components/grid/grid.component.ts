import { HttpParams } from '@angular/common/http';
import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { ModuleCode } from '../../enumaration/module-code';
import { StatusCode } from '../../enumaration/status-code';
import { BaseFunction } from '../../function/function-base';
import { ResponseService, StatusResponse } from '../../models/response-service';
import { HttpService, IRequestOptions } from '../../services/http/http.service';
import { environment } from 'src/environments/environment';
declare const $: any;

@Component({
  selector: 'app-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})
export class GridComponent implements OnInit, AfterViewInit {

  private _unDestroy: Subject<any> = new Subject<any>();

  @ViewChild('jsGridDom', { static: true }) jsGrid!: ElementRef;


  @Input() moduleCode: ModuleCode = ModuleCode.Dashboard;

  pageSize: number = 10;

  //Cấu hình đầu vào của JS grid
  @Input() columns: any;

  @Input() customUrl: string = '';


  total: number = 0;
  total_pages: number = 0;

  pageIndex: number = 1;
  
  order_by: string = 'asc';

  @Input('searchText')
  search_name: string = '';


  @Input()
  method: string = "POST";

  /**
   * body của request post
   */
  @Input()
  bodyParams: any = {};

  // @Input()
  // rendercolumn

  constructor(private httpService: HttpService) { }

  ngOnInit(): void {
    this.configGrid();
  }
  ngAfterViewInit(): void {
    // this.configGrid();
  }

  ngOnDestroy(): void {
    BaseFunction.unDestroy(this._unDestroy);
  }

  pageSizeChange(e: any) {  
    $(this.jsGrid.nativeElement).jsGrid("loadData");
  }

  //Cấu hình grid
  configGrid() {
    const me = this;
    $(this.jsGrid.nativeElement).jsGrid({
      height: "auto",
      width: "100%",
      filtering: false,
      sorting: false,
      autoload: true,
      paging: true,
      pageLoading: true,

      pageIndex: 1,
      pageSize: this.pageSize,
      pageButtonCount: 15,
      pagerFormat: "Show: {pageIndex} &nbsp;&nbsp; {first} {prev} {pages} {next} {last} &nbsp;&nbsp; total pages: {pageCount}",
      pagePrevText: "<",
      pageNextText: ">",
      pageFirstText: "<<",
      pageLastText: ">>",
      loadIndication: true,
      loadIndicationDelay: 200,
      loadMessage: "Please, wait...",     

      fields: me.columns,
      controller: {
        // Lấy dữ liệu từ grid
        loadData: function (filter: any) {
          var d = $.Deferred();
          if (filter.pageIndex <= 0) {
            filter.pageIndex = 1;
          }
          me.pageIndex = filter.pageIndex;
          let enpoint = '';
          if (!me.customUrl && me.moduleCode) {
            enpoint = `${environment.baseUrlServer}/${me.moduleCode}`;
          }
          else {
            enpoint = me.customUrl;
          }
          let params: any;
          params = {};          
          if (me.pageIndex) {
            params["pageIndex"] = me.pageIndex;
          }          
          if (me.pageSize > 0) {
            params["PageSize"] = me.pageSize;
          }
          // if(me.page_number > 0){
          //   params.append("page_number", me.page_number.toString());
          // }
          if (!BaseFunction.IsNullOrEmpty(me.order_by)) {
            params["OrderBy"] = me.order_by;
          }
          if (!BaseFunction.IsNullOrEmpty(me.search_name)) {
            params["SearchName"] = me.search_name;
          }

          
          if (!BaseFunction.IsNullOrEmpty(enpoint)) {
            me.total = 0;
            if (me.method === "GET") {
              me.httpService.get(enpoint + BaseFunction.ConverParamUrl(params)).pipe(takeUntil(me._unDestroy)).subscribe((response: ResponseService) => {
                let da = {
                  data: [],
                  itemsCount : 0
                }                
                if (response.status == StatusCode.Success || response.message?.status == StatusResponse.success || response.data) {
                  da = {
                    data: response.data["items"],
                    itemsCount : response.data['totalRecord']
                  }                  
                  // d.resolve(response.data[me.moduleCode.toLowerCase()]);
                  me.total = response.data['totalRecord'];
                  //me.total_pages = response.data['total_pages'];
                }
                d.resolve(da);
              },
              (error)=>{
                d.resolve({
                  data: [],
                  itemsCount : 0
                });
              });
            }
            else{
              me.httpService.post(enpoint, params).pipe(takeUntil(me._unDestroy)).subscribe((response: ResponseService) => {
                let da = {
                  data: [],
                  itemsCount : 0
                }                
                if (response.status == StatusCode.Success || response.message?.status == StatusResponse.success || response.data) {
                  da = {
                    data: response.data["items"],
                    itemsCount : response.data['totalRecord']
                  }                 
                  // d.resolve(response.data[me.moduleCode.toLowerCase()]);
                  me.total = response.data['totalRecord'];
                  //me.total_pages = response.data['total_pages'];
                }
                d.resolve(da);
              }, (error)=>{
                d.resolve({
                  data: [],
                  itemsCount : 0
                });
              });
            }
          }
          return d.promise();
        },

        insertItem: $.noop,
        updateItem: $.noop,
        deleteItem: $.noop
      },
      rowClass: function (item: any, itemIndex: any) {

      },
      rowClick: function (args: any) { },
      rowDoubleClick: function (args: any) { },
    });
  }

  /**
   * Refresh lại dữ liệu
   */
  resetData(){
    $(this.jsGrid.nativeElement).jsGrid("reset");
  }
}
