import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { HttpService } from 'src/app/shared/services/http/http.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor(private httpService: HttpService, private translate : TranslateService) { }

  ngOnInit(): void {
  //   this.httpService.get("admin/forms")     
  //     .subscribe(
  //       (res: ResponseService) => {                  

  //         Notify.notifyLauchDanger(this.translate.instant("ErrorService"));

  //       });
  // }
  }

}
