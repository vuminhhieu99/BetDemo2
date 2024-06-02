import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { LocalStorageKey } from '../../constants/loca-storage-key';
import { HttpService } from '../http/http.service';
import { ResponseService, StatusResponse } from '../../models/response-service';
import { StatusCode } from '../../enumaration/status-code';
import { UserLogin } from '../../models/user-login';
import { LocalStorage } from '../../function/local-storage';
import { Router } from '@angular/router';
import { HttpParams } from '@angular/common/http';
import { BaseFunction } from '../../function/function-base';
import { environment } from 'src/environments/environment';



@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private token: string = '';  
    private currentUserSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
    public currentUser: Observable<UserLogin>;
    private redirectUrl: string = '';
    private host = environment.baseUrlServer;
    constructor(private http: HttpService, private router : Router) {   
        this.token =  String(localStorage.getItem(LocalStorageKey.Token)); 
        this.currentUser = this.currentUserSubject.asObservable();
       
    }

    public get currentUserValue(): UserLogin {
        return this.currentUserSubject.value;
    }

    login(userName: string, password: string) {
        const me= this;
        return this.http.post(`${this.host}/Auth/login`, { userName, password })
            .pipe(map((res: ResponseService) => {              
                if (res && res.status == StatusCode.Success) {                   
                    LocalStorage.set(LocalStorageKey.Token, (res.data as UserLogin).token || "");
                    LocalStorage.set(LocalStorageKey.RefreshToken, (res.data as UserLogin).refreshToken || "");
                    LocalStorage.set(LocalStorageKey.UserID, (res.data as UserLogin).id || "");
                    me.currentUserSubject.next(res.data);
                    me.startRefreshTokenTimer();
                    if(me.redirectUrl){
                        this.router.navigate(['/tournament']);
                    }
                    else{                        
                            this.router.navigate(['/dashboard']);  
                        }
                }
                else{

                }
                return res;
            }));
    }
    
    /**
     * Đăng xuất phần mềm
     */
    logout(redirectUrl:any ="") {        
        LocalStorage.remove(LocalStorageKey.Token);        
        this.stopRefreshTokenTimer();
        this.currentUserSubject.next(null);
        this.redirectUrl = redirectUrl;
        this.router.navigate(['/Auth/login'], { queryParams: { redirectUrl: redirectUrl } });
    }

    private refreshTokenTimeout: any;

    // thực hiện vòng đời của fresh token
    private startRefreshTokenTimer(){     
        const jwtToken = JSON.parse(decodeURIComponent(atob((this.currentUserValue.token || '').split('.')[1].replace(/-/g, '+').replace(/_/g, '/')).split('').map(function(c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join('')));

        // set a timeout to refresh the token a minute before it expires
        const expires = new Date(jwtToken.exp * 1000);
        const timeout = expires.getTime() - Date.now() - 5000;
        console.log('expired token:' + timeout/1000);
        const me = this;
        this.refreshTokenTimeout = setTimeout(() =>{
            me.refreshToken().subscribe((res : ResponseService) =>{
                if(res && res.status !== StatusCode.Success) {
                    me.logout();
                }
            })
            me.stopRefreshTokenTimer();
        }, timeout);
    }

    //refresh Token
    refreshToken() {    
        var refreshToken = LocalStorage.get(LocalStorageKey.RefreshToken);      
        refreshToken = refreshToken ? refreshToken.toString(): "";
        let queryParams = new HttpParams();
        queryParams = queryParams.append('refreshToken', refreshToken);
        if(!BaseFunction.IsNullOrEmpty(refreshToken)){
            return this.http.get(`${this.host}/Auth/refresh-token`,{ params : queryParams})
            .pipe(map((res : ResponseService) => {
                if(res.data && res.data.token){
                    LocalStorage.set(LocalStorageKey.Token, res.data.token);
                    this.currentUserValue.token = res.data.token;
                    this.startRefreshTokenTimer();
                }
                return res;
            }));  
        }
        else{
            const res = new ResponseService();
            res.status = StatusCode.Fail;
            return of(res);
        }
              
    }

    private stopRefreshTokenTimer() {
        clearTimeout(this.refreshTokenTimeout);
    }
}