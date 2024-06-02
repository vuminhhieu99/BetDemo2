import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { LocalStorageKey } from '../../constants/loca-storage-key';
import { LocalStorage } from '../../function/local-storage';
import { BaseFunction } from '../../function/function-base';
import { Router } from '@angular/router';
import { StatusCode } from '../../enumaration/status-code';
import { ResponseService } from '../../models/response-service';



@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService, private router: Router) { }

    /**
     * Kiểm tra nếu lỗi thì lấy về refreshToken
     * @param request 
     * @param next 
     * @returns 
     * vmhieu 11.3.2022
     */
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            if ([401, 403].includes(err.status)) {
                this.authenticationService.refreshToken().subscribe((res: ResponseService) => {
                    if (res && res.status !== StatusCode.Success) {
                        this.authenticationService.logout(window.location.pathname);
                    }
                })
            }

            const error = (err && err.error) || "ErrorInterceptor";
            console.error(err);
            return throwError(error);
        }))
    }
}