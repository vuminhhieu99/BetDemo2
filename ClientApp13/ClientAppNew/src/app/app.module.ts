import { observable, Observable } from 'rxjs';
import { APP_INITIALIZER, Injectable, Injector, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DirectiveExampleDirective } from './shared/directives/directive-example.directive';
import { PageHeaderComponent } from './shared/modules/page-header/page-header.component';
import { PageSidebarComponent } from './shared/modules/page-sidebar/page-sidebar.component';
import { HttpClient, HttpClientModule, HttpHeaders, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TranslateLoader, TranslateModule, TranslateService } from '@ngx-translate/core';
import { LocalStorageKey } from './shared/constants/loca-storage-key';
import { LocalStorage } from './shared/function/local-storage';
import { AppVariable } from './shared/constants/app-variable';
import { map } from 'rxjs/operators';
import { APP_BASE_HREF, LOCATION_INITIALIZED } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/login/login.component';
import { AuthenticationService } from './shared/services/authentication/authentication.service';
import { ReactiveFormsModule } from '@angular/forms';
import { JwtInterceptor } from './shared/base/_jwt.interceptor/jwt.interceptor';
import { TournamentComponent } from './components/tournament/tournament.component';
import { ErrorInterceptor } from './shared/base/_error.interceptor/error.interceptor';
import { ConfigService } from './shared/services/config/config.service';

/**
 * Cấu hình translate
 * vmhieu 11.3.2022
 */
 @Injectable()
export class TranslationService implements TranslateLoader {

  contentHeader = new HttpHeaders({ "Content-Type": "application/json", "Access-Control-Allow-Origin" : "*" });
  constructor(private http: HttpClient) { }

  getTranslation(lang: string = "vi-VN"): Observable<any> {
    const language = LocalStorage.get(LocalStorageKey.Language) || lang;
    const apiAddress = `${AppVariable.UrlI18n}/${language}.json`;
   
    return Observable.create((ob : any) => {
      this.http.get(apiAddress, { headers: this.contentHeader }).pipe(
        map(response => { 
          return JSON.parse(JSON.stringify(response));
        })).subscribe((response) => {
          ob.next(response);
          ob.complete();
        });
    }) 
  }
}

export function appInitializerFactory(
  translate: TranslateService,
  injector: Injector,
  config: ConfigService,
  locale: string
) {
  return () =>
    new Promise<any>((resolve: any) => {
      const locationInitialized = injector.get(
        LOCATION_INITIALIZED,
        Promise.resolve(null)
      );
      locationInitialized.then(() => {
        const langToSet = 'vi-VN';
        translate.setDefaultLang('vi-VN');
        translate.use(langToSet).subscribe(
          () => {
            console.log(`Successfully initialized '${langToSet}' language.'`);
          },
          err => {
            console.error(
              `Problem with '${langToSet}' language initialization.'`
            );
          },
          () => {
            resolve(null);
          }
        );
      });
      config.loadConfig().then(() => {
        console.log(`Successfully initialized config`);
      });
    });
}

@NgModule({
  declarations: [
    AppComponent,
    DirectiveExampleDirective,
    PageSidebarComponent,
    PageHeaderComponent,
    LoginComponent    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslationService,
        deps: [HttpClient]
      }
    }),
    BrowserAnimationsModule
  ],
  providers: [{
    provide: APP_INITIALIZER,
    useFactory: appInitializerFactory,
    deps: [TranslateService, Injector, ConfigService, LOCALE_ID],
    multi: true
  },
  { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
