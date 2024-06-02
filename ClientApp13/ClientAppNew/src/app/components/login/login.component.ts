import { first, takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomValidators } from 'src/app/shared/function/custom_validators';
import { FormBase} from 'src/app/shared/function/form_base';
import { BaseFunction } from 'src/app/shared/function/function-base';
import { AuthenticationService } from 'src/app/shared/services/authentication/authentication.service';
import { Router } from '@angular/router';
import { Notify } from 'src/app/shared/function/notify';
import { TranslateService } from '@ngx-translate/core';
import { ResponseService } from 'src/app/shared/models/response-service';
import { LocalStorage } from 'src/app/shared/function/local-storage';
import { LocalStorageKey } from 'src/app/shared/constants/loca-storage-key';
import { StatusCode } from 'src/app/shared/enumaration/status-code';
import { ConfigService } from 'src/app/shared/services/config/config.service';

declare const window: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private _unDestroy: Subject<any> = new Subject<any>();
  public loginFormGroup!: FormGroup;
  constructor(
    public form: FormBuilder,
    private authenticationService: AuthenticationService,
    private router: Router,
    private translate: TranslateService,
    private configService: ConfigService
  ) { 
    // chuyển đến dashboard nếu đã login
  //   if (this.authenticationService.currentUserValue || LocalStorage.get(LocalStorageKey.Token)) { 
  //     this.router.navigate(['/']);
  // }
  }

  public formErrors = {
    username: '',
    password: ''
  };

  public formLoginData: any = {
    username: '',
    password: ''
  };

  submitted = false;
  isLoading = false;
  ngOnInit(): void {
    // reset login status
    //this.authenticationService.logout();
    this.buildForm();
  }
  
  // build the user edit form
  public buildForm() {
    const me = this;
    this.loginFormGroup = this.form.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],

    });
    this.loginFormGroup.valueChanges.pipe(takeUntil(this._unDestroy)).subscribe((change: any) => {
      for (const prop of Object.keys(change)) {
        if (me.formLoginData.hasOwnProperty(prop)) {
          me.formLoginData[prop] = change[prop];
        }
      }
      this.formErrors = FormBase.validateForm(this.loginFormGroup, this.formErrors, true)
    });
  }

  ngOnDestroy(): void {
    BaseFunction.unDestroy(this._unDestroy);
  }

  get f() { return this.loginFormGroup.controls; }

  /**
   * Đăng nhập hệ thống 7.3.2022
   * @returns 
   * vmhieu
   */
  login() {
    this.submitted = true;
    const me = this;    
    if (this.loginFormGroup.invalid) {
      return;
    }

    this.isLoading = true;
    this.authenticationService.login(this.f['username'].value, this.f['password'].value)
      .pipe(first())
      .subscribe(
        (res: ResponseService) => {
          this.isLoading = false;
          if(!res.status || res.status != StatusCode.Success){
            Notify.notifyLauchDanger(me.translate.instant("Login.Fail"));          
          }          
        });
  }

  /**
   * đăng ký tài khoản 
   */
  register(){
    ;
  }

  /**
   * Đăng nhập với facebook
   * vmhieu 2.4.2022
   */
  loginFacebook(){
      const me= this;
      const fbOAuth = this.configService.getConfig("FacebookOauthSetting");
      const urlFb = `${fbOAuth.Url}?client_id=${fbOAuth.ClientId}&response_type=token&state=${fbOAuth.State}&redirect_uri=${fbOAuth.RedirecUri}&scope=${fbOAuth.Scope}`
      window.OAuthCallback = function ProcessCallbackData(success: boolean, access_token: string){
        console.log("success" +success + " | access_token" + access_token);
        if(success){
          const param = {
              AccessToken: access_token
          };
          me.register();
        }
      }

      window.open(
        urlFb,
        "FBSDK",
        `width=800,height=600, left=${window.screen.width / 2 - 400},top=${window.screen.height / 2 - 300}, scrollbars, resizable`
      )
  }

}
