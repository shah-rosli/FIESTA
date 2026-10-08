import { Component } from '@angular/core'
import { Router } from '@angular/router'
import { environment } from '../../../../../environments/environment'
import { BaseService } from '../../../../service/base/base.service'
import { SendRequestService } from '../../../../service/base/send-request.service'
import { HttpClient } from '@angular/common/http'
import { ToastrService } from 'ngx-toastr'
import { confirm } from 'devextreme/ui/dialog'
import CustomStore from 'devextreme/data/custom_store'
import { CookieService } from 'ngx-cookie-service'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'

@Component({
  selector: 'app-user-deligation',
  templateUrl: './user-deligation.component.html',
  styleUrls: ['./user-deligation.component.scss']
})
export class UserDeligationComponent {
  userList: any
  Deligatee: any
  requestorOpened: false
  DeligateeName: null
  booleanDataSource: any
  Active: any
  DATE_FROM: null
  DATE_TO: null
  userListStore: any
  DATE_TODAY = new Date();
  pageIsLoading: boolean = false;
  SelectedRequestor: any[] = [];
  PageTitle: string = this.base.getMessage("User Delegation");
  buttonOptions: any = {
    text: "Submit",
    type: "success",
    useSubmitBehavior: true,
    width: "100%",
    onClick: this.SaveDeligation.bind(this)
  }

  constructor(public base: BaseService, private router: Router,
    private send: SendRequestService, private toastr: ToastrService, private cookieService: CookieService) { }

  ngOnInit() {
    this.pageIsLoading = true
    this.getDelegationtData()
    this.getUserListData()
    this.booleanDataSource = this.base.getBooleanData()
  }

  getDelegationtData() {
    this.send.sendRequest(`${environment.ServiceURL_Main}CfgUserDelegation/GetDelegationFilterByUserId?user_id=` + this.base.getUserInfo("USER_ID"), "GET", "").subscribe(
      data => {

        if (data) {
          this.Deligatee = data.DELEGATEE_USER_ID
          this.Active = data.ACTIVE

          this.DATE_TO = null
          if (data.END_DATETIME) {
            let tempEND_DATETIME = new Date(data.END_DATETIME)
            if (tempEND_DATETIME.getFullYear() > 2019) {
              this.DATE_TO = data.END_DATETIME
            }
          }

          this.DATE_FROM = null
          if (data.START_DATETIME) {
            let tempSTART_DATETIME = new Date(data.START_DATETIME)
            if (tempSTART_DATETIME.getFullYear() > 2019) {
              this.DATE_FROM = data.START_DATETIME
            }
          }


          this.SetdropDownUserListItems()


        }
      },
      error => {

        this.toastr.error(this.base.getMessage(error.message), this.base.getMessage('Error!'), errorToastOptions)
      }
    )

  }

  openDelegationHisotry() {
    this.router.navigate(['/UserDelegation-report'])
  }

  getUserListData() {

    if (localStorage.getItem("localStorageUserList")) {
      setTimeout(() => { this.pageIsLoading = false }, 1000)
      this.userList = JSON.parse(localStorage.getItem("localStorageUserList"))
      this.SetdropDownUserListItems()
    } else {
      let param = {
        "cfgUserList": []
      }
      let URL: string = `${environment.ServiceURL_Main}user/GetUserOnlyDistinctByUserId`
      this.send.sendRequest(URL, "POST", param).subscribe(
        data => {
          this.pageIsLoading = false
          this.userList = data
          localStorage.setItem("localStorageUserList", JSON.stringify(data))
          this.SetdropDownUserListItems()
        },
        error => {

          this.toastr.error(this.base.getMessage(error.message), this.base.getMessage('Error!'), errorToastOptions)
        }
      )
    }


  }

  SetdropDownUserListItems() {

    let tempSelectedRequstor = this.userList.filter(filter => filter.USER_ID == this.Deligatee)
    if (tempSelectedRequstor.length) {
      this.SelectedRequestor = []
      this.SelectedRequestor.push(this.Deligatee)
    }

    this.userListStore = {
      store: new CustomStore({
        key: "USER_ID",
        loadMode: "raw",
        load: () => this.userList,
      }),
      paginate: true,
      pageSize: 10,

    }


  }


  SaveDeligation() {

    let user = JSON.parse(this.cookieService.get('UserInfo'))
    if (user !== null) {

      if (this.Active == "No ") {

        let result = confirm(this.base.getMessage("Are you sure save on  not active?"), this.base.getMessage("Confirm changes"))
        result.then((dialogResult) => {

          if (dialogResult === true) { this.saveResult(user) }
          else { return false }
        })
      }
      else {

        this.saveResult(user)
      }
    }
    else {
      this.toastr.info(this.base.getMessage("current User details not get"))
    }

  }


  saveResult(user) {
    let obj = {}
    obj["USER_ID"] = user.USER_ID
    obj["DELEGATEE_USER_ID"] = this.Deligatee
    obj["START_DATETIME"] = this.DATE_FROM
    obj["END_DATETIME"] = this.DATE_TO
    obj["ACTIVE"] = this.Active

    this.send.sendRequest(`${environment.ServiceURL_Main}CfgUserDelegation`, "POST", obj).subscribe(
      data => {
        this.toastr.success(this.base.getMessage("Record modified successfully"), this.base.getMessage('Success!'))

      },
      error => {

        this.toastr.error(this.base.getMessage(error.message), this.base.getMessage('Error!'), errorToastOptions)

      }
    )
  }


  onRequestorChange(e) {
    this.Deligatee = e.selectedRowsData[0].USER_ID
    this.SelectedRequestor = []
    this.SelectedRequestor.push(this.Deligatee)
    this.requestorOpened = false
  }

  getUserDisplayExpr(item) {
    if (!item) {
      return ""
    }
    return item.USER_FULL_NAME
  }


}
