import { Component } from '@angular/core'
import { CookieService } from 'ngx-cookie-service'
import { BaseService } from '../../../../service/base/base.service'

@Component({
  selector: 'app-page-error401',
  templateUrl: './page-error401.component.html',
  styleUrls: ['./page-error401.component.scss'],
  providers: [BaseService]
})
export class PageError401Component {

  PageTitle: string = this.base.getMessage("Page Error 401");
  msToken: String = this.cookieService.get("msToken");

  constructor(public base: BaseService, private cookieService: CookieService) { }

  ngOnInit() {

  }

  onClickLogin() {
    this.base.reLogin()

  }

}
