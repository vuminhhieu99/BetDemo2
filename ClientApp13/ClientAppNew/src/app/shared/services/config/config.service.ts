import { HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { AppVariable } from '../../constants/app-variable';
import { Appsettings } from '../../models/appseting';
import { HttpService } from '../http/http.service';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  private readonly urlConfig: string = AppVariable.UrlConfig;
  private config: any;
  constructor(private http: HttpService) { }

  getConfig(key: string){
    const split = key.split(".");
    let data = null;
    if(this.config && this.config.hasOwnProperty(split[0])){
      data = this.config[split[0]];
    }
    for(let i = 1; i < split.length; i++){
      data = data[split[i]];
    }
    return data;
  }

  public loadConfig(){
    return this.http.get(this.urlConfig).toPromise().then((data: any) =>{
      this.config = data;
    }).catch(this.handleError);
  };

  private handleError(error: HttpResponse<any> | any){
    let errMsg : string;
    if(error instanceof HttpResponse){
      const currentError: any = error;
      const body = currentError.json() || "";
      const err = body.error || JSON .stringify(body);
      errMsg = `${error.status} - ${error.statusText || ""} ${err}`;
    }
    else{
      errMsg = error.message ? error.message : error.toString();
    }
    return new Promise((resolve) =>{
      resolve(errMsg);
    });
  }
}
