import { Component } from '@angular/core'
import { BaseService } from '../../../service/base/base.service'

@Component({
  selector: 'app-header-user',
  templateUrl: './header-user.component.html',
  styleUrls: ['./header-user.component.scss'],
  providers: [BaseService]
})
export class HeaderUserComponent {

  UserName: string = "";
  UserHeaderName: string = "";
  deligateeShow: boolean = false;
  UserEmail: string = "";
  UserId: string = "";
  UserPosition: string = "";
  UserCompany: string = "";
  DelegateeUserHeaderName: string = "";

  constructor(public base: BaseService) { }

  ngOnInit() {
    this.UserName = this.base.getUserInfo("USER_FULL_NAME")
    this.UserId = this.base.getUserInfo("USER_ID")
    this.UserPosition = this.base.getUserInfo("USER_GLOBAL_TITLE")
    this.UserEmail = this.base.getUserInfo("USER_EMAIL")
    this.UserHeaderName = this.UserName
    if (localStorage.getItem("DeligationActiveFlag") === "true") {
      this.deligateeShow = true
      this.DelegateeUserHeaderName = "(Deligatee: " + localStorage.getItem("DeligaterName") + ")"
    }
  }

  relogin() {
    this.base.reLogin()
  }

  goToLink(url: string) {
    window.open(url, "_blank")
  }
}
