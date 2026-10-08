import { Component } from '@angular/core'
import { environment } from '../../../../environments/environment'
import { BaseService } from '../../../service/base/base.service'
import { SendRequestService } from '../../../service/base/send-request.service'
import CustomStore from 'devextreme/data/custom_store'
import { ToastrService } from 'ngx-toastr'
import { Router } from '@angular/router'
import { confirm } from 'devextreme/ui/dialog'
import { ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
@Component({
  selector: 'app-system-language',
  templateUrl: './system-language.component.html',
  styleUrls: ['./system-language.component.scss'],
  providers: [BaseService]
})
export class SystemLanguageComponent {

  PageTitle: string = this.base.getMessage("System Language Configuration");
  access = { toCreate: false, toRead: false, toUpdate: false, toDelete: false };
  dataSource: any

  UserPermission: any
  PermissionForCreate: any
  PermissionForEdit: any
  PermissionForView: any
  PermissionForDelete: any
  loading_indicator: boolean = false;
  HistoryData: any
  popupVisible: boolean = false;
  historyVisible: any
  userDataSource: any
  HistoryLoading: boolean = false;
  constructor(public base: BaseService, private send: SendRequestService, private toastr: ToastrService, private router: Router) {

    this.historyIconClick = this.historyIconClick.bind(this)
    let URL: string = `${environment.ServiceURL_Main}systemlanguage`
    this.dataSource = new CustomStore({
      key: "CFG_SYSTEM_LANGUAGE_ID",
      loadMode: "raw",
      load: () => this.send.sendRequestDevExtreme(URL),
      insert: (values) => this.send.sendRequestReturnLastInserted(URL, "POST", JSON.stringify(values)),
      update: (key, values) => this.send.sendRequestReturnLastInserted(URL + "/" + key, "PUT", JSON.stringify(values)),
      remove: (key) => this.send.sendRequestDevExtreme(URL + "/" + key, "DELETE", { key: key })
    })
  }

  ngOnInit() {
    // this.cratePermision=true
    this.UserPermission = this.base.getUserAccessPermission(this.router.url)//get permission for this page
    this.PermissionForCreate = false
    this.PermissionForEdit = false
    this.PermissionForView = false
    this.PermissionForDelete = false
    //check 'create' permission
    if (this.UserPermission !== null) {

      this.UserPermission.forEach(function (item) {
        if (item.access_right === 'Create') {
          this.PermissionForCreate = true
        }
        else if (item.access_right === 'Edit') {
          this.PermissionForEdit = true
        }
        else if (item.access_right === 'View') {
          this.PermissionForView = true
        }
        else if (item.access_right === 'Delete') {
          this.PermissionForDelete = true
        }


      }, this)
    }
    this.getUser()
  }

  getUser() {
    if (localStorage.getItem("localStorageUserList")) {

      let userList: any
      //setTimeout(() => { this.pageIsLoading = false; }, 1000);
      userList = JSON.parse(localStorage.getItem("localStorageUserList"))
      this.userDataSource = {
        store: new CustomStore({
          key: "USER_FULL_NAME",
          loadMode: "raw",
          load: () => userList,
        }),
        paginate: true,
        pageSize: 10,

      }
    }

    else {
      this.HistoryLoading = true
      let param = {
        "cfgUserList": []
      }
      let URL: string = `${environment.ServiceURL_Main}user/GetUserOnlyDistinctByUserId`
      this.send.sendRequest(URL, "POST", param).subscribe(
        data => {
          let userList: any
          this.HistoryLoading = false
          userList = data
          localStorage.setItem("localStorageUserList", JSON.stringify(data))
          this.userDataSource = {
            store: new CustomStore({
              key: "USER_FULL_NAME",
              loadMode: "raw",
              load: () => userList,
            }),
            paginate: true,
            pageSize: 10,

          }
        },
        error => {

          this.toastr.error(this.base.getMessage(error.message), this.base.getMessage('Error!'), errorToastOptions)
        }
      )
    }

  }
  postGridRow(e, action) {
    if (action == 'edit') { e.newData = Object.assign(e.oldData, e.newData) }
  }

  postedGridRow(e, action) {
    if (action == 'create') { this.toastr.success(this.base.getMessage('Record created successfully'), this.base.getMessage('Success!')) }
    if (action == 'edit') { this.toastr.success(this.base.getMessage('Record modified successfully'), this.base.getMessage('Success!')) }
    if (action == 'delete') { this.toastr.success(this.base.getMessage('Record deleted successfully'), this.base.getMessage('Success!')) }

  }


  historyIconClick(e) {


    this.popupVisible = true
    this.loading_indicator = true

    this.send.sendRequest(`${environment.ServiceURL_Main}CfgSysLanguage/GetHistory/` + e.row.data.CFG_SYSTEM_LANGUAGE_ID, "GET", "").subscribe(
      data => {
        this.HistoryData = data
        this.loading_indicator = false
      },
      error => {

        this.toastr.error(this.base.getMessage(error.message), this.base.getMessage('Error!'), errorToastOptions)
      })

  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
