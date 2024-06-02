import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenticationService } from '../../services/authentication/authentication.service';
import { LocalStorageKey } from '../../constants/loca-storage-key';
import { LocalStorage } from '../../function/local-storage';
import { baseFunction } from '../../function/function-base';



@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            if ([401, 403].includes(err.status) && this.authenticationService.currentUserValue) {               
                var refreshToken = LocalStorage.get(LocalStorageKey.RefreshToken);
       
                if(baseFunction.IsNullOrEmpty(refreshToken)){
                    this.authenticationService.refreshToken();
                }
                
            }

            const error = (err && err.error) || "ErrorInterceptor";
            console.error(err);
            return throwError(error);
        }))
    }
}