import { HttpClient, HttpContext, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,  } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseService } from '../../models/response-service';

export interface IRequestOptions {
  headers?: HttpHeaders;
  context?: HttpContext;
  observe? : "body";
  params? : HttpParams | {};
  reportProgress? : boolean;
  responseType?: "json";
  withCredentials?: boolean;

}

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { 
    this.headers.set('Content-Type', 'application/json; charset=utf-8');
  }

  headers: HttpHeaders = new HttpHeaders();

  /**
   * Lấy request get
   * @param enpoint 
   * @param params 
   * @returns 
   * vmhieu 11.3.2022
   */
  get(enpoint: string, options?: IRequestOptions):  Observable<ResponseService>{
    if(options){
      options.headers = this.headers;
    }
    else{
      options = {headers :  this.headers}
    }
    return this.http.get(enpoint, options);
  }

  /**
   * Lấy request post
   * @param enpoint 
   * @param params 
   * @returns 
   * vmhieu 11.3.2022
   */
  post(enpoint: string,body: any, options?: IRequestOptions ) : Observable<ResponseService>{
    return this.http.post(enpoint, body, options);
  }

  /**
   * Lấy request put
   * @param enpoint 
   * @param params 
   * @returns 
   * vmhieu 11.3.2022
   */
  put(enpoint: string,body: any, options?: IRequestOptions ) : Observable<ResponseService>{
    return this.http.put(enpoint, body, options);
  }

  /**
   * Lấy request delete
   * @param enpoint 
   * @param params 
   * @returns 
   * vmhieu 11.3.2022
   */
  delete(enpoint: string, options?: IRequestOptions ) : Observable<ResponseService>{
    return this.http.delete(enpoint, options );
  }
}
