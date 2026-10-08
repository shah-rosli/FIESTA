import { Component, HostListener, ViewChild } from '@angular/core'
import { environment } from '../../../../environments/environment'
import { BaseService } from '../../../service/base/base.service'
import { SendRequestService } from '../../../service/base/send-request.service'
import { ToastrService } from 'ngx-toastr'
import { DxDataGridComponent } from 'devextreme-angular'
import { PagePermission, PermissionService } from '../../../service/permission.service'
import { ExportingEvent, InitNewRowEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
import DataSource from 'devextreme/data/data_source'
import { finalize } from 'rxjs'

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
  providers: [BaseService]
})
export class UserComponent {
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent
  PageTitle: string = "User configuration"
  dataSource: DataSource
  companyDataSource: any[]
  booleanDataSource: any[]
  timezoneDataSource: any[]
  userGroupDataSource: any[]
  dateDataSource: any[]
  timeDataSource: any[]
  datetimeDataSource: any[]
  languageDataSource: any[]
  pagePermission: PagePermission
  createPopupOpen: boolean = false
  loading: boolean = false
  massInsertPopupVisible: boolean = false
  massInsertFormData = {
    emails: ""
  }
  massInsertDataSource: any[]

  HistoryData: any
  historyLoadingIndicator: boolean = false
  historyPopupVisible: boolean = false

  massInsertButtonOptions = {
    text: "Search Users",
    type: "success",
    width: "100%",
    onClick: () => this.massInsertSearchUsers()
  }

  constructor(
    public base: BaseService,
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService
  ) {
    this.onEditingHidden = this.onEditingHidden.bind(this)
    this.historyIconClick = this.historyIconClick.bind(this)
    this.booleanDataSource = this.base.getBooleanData()
    this.timezoneDataSource = this.base.getParamData("System_Timezone")
    this.dateDataSource = this.base.getParamData("System_Dateformat")
    this.timeDataSource = this.base.getParamData("System_Timeformat")
    this.languageDataSource = this.base.getParamData("System_Language")
    this.datetimeDataSource = this.base.getParamData("System_DateTimeformat")
  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
    this.getCompanyMaster()
    this.getUserGroup()
  }

  setDataSource() {
    const url = `${environment.ServiceURL_Main}User`
    this.dataSource = new DataSource({
      store: this.send.sendRequestVirtualConfigurable({
        key: "CFG_USER_ID",
        loadUrl: url + "/GetAll",
        insertUrl: url,
        updateUrl: url,
      })
    })
  }

  getCompanyMaster() {
    this.send.sendRequest(`${environment.ServiceURL_Main}companymaster`, "GET", "").subscribe(
      data => {
        this.companyDataSource = data.sort((a, b) => a.COMPANY_NAME.localeCompare(b.COMPANY_NAME))
      }
    )
  }

  getUserGroup() {
    this.send.sendRequest(`${environment.ServiceURL_Main}CfgUserGroup/GetCfgUserGroupDetail`, "GET", "").subscribe(
      data => {
        this.userGroupDataSource = data
          .filter(item => item.ACTIVE === "Yes")
          .sort((a, b) => a.USER_GROUP_NAME.localeCompare(b.USER_GROUP_NAME))
        this.userGroupDataSource
          .forEach(item => item.CFG_USER_GROUP_ID_STRING = item.CFG_USER_GROUP_ID.toString())
        this.setDataSource()
      }
    )
  }

  historyIconClick(e) {
    const ID = e.row.data.USER_ID
    if (!ID) {
      this.toastr.error("Invalid/No ID", null, errorToastOptions)
      return
    }
    this.historyPopupVisible = true
    this.historyLoadingIndicator = true
    this.send.sendRequest(`${environment.ServiceURL_Main}CfgUser/GetHistory/${ID}`, "GET", "").subscribe(
      data => {
        this.HistoryData = data
        this.historyLoadingIndicator = false
      },
      () => {
        this.historyLoadingIndicator = false
      })
  }

  postGridRow(e, action) {
    if (action == 'edit') { e.newData = { ...e.oldData, ...e.newData } }
  }

  postedGridRow(e, action) {
    if (action == 'create') { this.toastr.success('Record created successfully', 'Success!') }
    if (action == 'edit') { this.toastr.success('Record modified successfully', 'Success!') }
    if (action == 'delete') { this.toastr.success('Record deleted successfully', 'Success!') }
  }

  getUserGroupDisplay(userId: string) {
    const foundGroup = this.userGroupDataSource.find(group => group.CFG_USER_GROUP_ID_STRING === userId)
    if (foundGroup) {
      return foundGroup.CFG_USER_GROUP_ID_STRING + " - " + foundGroup.USER_GROUP_NAME
    }
    return userId
  }

  getEditUserGroupDisplay(row) {
    return row.CFG_USER_GROUP_ID_STRING + " - " + row.USER_GROUP_NAME
  }

  onUserGroupValueChange(userGroupArray, cellRef) {
    for (let i = 0; i < userGroupArray.length; i++) {
      const userId = userGroupArray[i]
      const foundGroup = this.userGroupDataSource.find(group => group.CFG_USER_GROUP_ID_STRING === userId)
      if (!foundGroup) {
        userGroupArray.splice(i, 1)
      }
    }
    cellRef.setValue(userGroupArray)
  }

  onInitNewRow(e: InitNewRowEvent) {
    if (this.booleanDataSource.some(item => item.Value === "Yes")) {
      e.data.ACTIVE = "Yes"
    }
    const defaultUserGroup = this.userGroupDataSource.find(item => item.USER_GROUP_NAME === "Standard User")
    if (defaultUserGroup) {
      e.data.saUserGroupId = [defaultUserGroup.CFG_USER_GROUP_ID_STRING]
    }
    if (this.companyDataSource.some(item => item.COMPANY_NAME === "REPG")) {
      e.data.USER_COMPANY_CODE = "32A0"
    }
  }

  @HostListener('document:keydown.n', ['$event'])
  openCreatePopup(e: KeyboardEvent) {
    const isEventFromInputElement = (e: KeyboardEvent) => {
      console.log(e)
      if (e.target instanceof Node) {
        switch (e.target.nodeName) {
          case 'INPUT':
          case 'SELECT':
          case 'TEXTAREA':
            return true
          default:
            return false
        }
      }
      return false
    }

    const isPopupClosed = !this.createPopupOpen
    const isEventNotFromInputElement = !isEventFromInputElement(e)

    if (isEventNotFromInputElement && isPopupClosed) {
      e.preventDefault()
      this.dataGrid.instance.addRow()
      this.createPopupOpen = true
    }
  }

  onEditingHidden() {
    this.createPopupOpen = false
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }

  massInsertSearchUsers() {
    const parseTextArea = (value) => {
      const parsed = value
        .split('\n')
        .filter(singleSearchValue => singleSearchValue.trim() !== "")
        .map(singleSearchValue => singleSearchValue.trim())
        .map(singleSearchValue => singleSearchValue.toLowerCase())

      return [...new Set(parsed)]
    }

    const emails = parseTextArea(this.massInsertFormData.emails)

    this.loading = true
    this.send.sendRequest(`${environment.ServiceURL_Main}User/MassInsertSearchUser`, "POST", emails)
      .pipe(finalize(() => this.loading = false))
      .subscribe({
        next: (response) => {
          this.toastr.success(response.Message)
          this.massInsertDataSource = response.Data
        },
        error: (error) => {
          const message = error?.error?.Message || "Something went wrong"
          this.toastr.error(message, "Error!", errorToastOptions)
        }
      })
  }

  massInsertUser() {
    if (!this.massInsertDataSource || this.massInsertDataSource.length === 0) {
      this.toastr.error("No user to insert, please find users first.")
      return
    }

    if (this.massInsertDataSource.some(item => item.Ok === false)) {
      this.toastr.error("Please make sure that all rows are 'Ok' before proceeding.")
      return
    }

    const payload = this.massInsertDataSource

    this.loading = true
    this.send.sendRequest(`${environment.ServiceURL_Main}User/MassInsert`, "POST", payload)
      .pipe(finalize(() => this.loading = false))
      .subscribe({
        next: (response) => {
          this.toastr.success(response.Message)
          this.massInsertPopupVisible = false
          this.dataSource.reload()
        },
        error: (error) => {
          const message = error?.error?.Message || "Something went wrong"
          this.toastr.error(message, "Error!", errorToastOptions)
        }
      })
  }

  onMassInsertPopupHidden() {
    this.massInsertFormData.emails = ""
    this.massInsertDataSource = []
  }

  refreshUserDetail() {
    this.loading = true
    this.send.sendRequest(`${environment.ServiceURL_Main}User/RefreshUserDetail`, "POST")
      .pipe(finalize(() => this.loading = false))
      .subscribe({
        next: (response) => {
          this.toastr.success(response.Message)
          this.dataSource.reload()
        },
        error: (error) => {
          const message = error?.error?.Message || "Something went wrong"
          this.toastr.error(message, "Error!", errorToastOptions)
        }
      })
  }
}
