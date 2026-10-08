import { Component, ViewChild } from '@angular/core'
import { environment } from '../../../../environments/environment'
import { BaseService } from '../../../service/base/base.service'
import { SendRequestService } from '../../../service/base/send-request.service'
import CustomStore from 'devextreme/data/custom_store'
import { ToastrService } from 'ngx-toastr'
import { DxDataGridComponent } from 'devextreme-angular'
import { PagePermission, PermissionService } from '../../../service/permission.service'
import { ExportingEvent } from 'devextreme/ui/data_grid'
import { exportGridToExcel } from 'src/app/shared/utils/exportGridToExcel'
import { errorToastOptions } from 'src/app/shared/utils/errorToastOption'
@Component({
  selector: 'app-user-group',
  templateUrl: './user-group.component.html',
  styleUrls: ['./user-group.component.scss'],
  providers: [BaseService]
})
export class UserGroupComponent {
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid1: DxDataGridComponent

  PageTitle: string = "User Group configuration"
  dataSource: CustomStore
  companyDataSource: any[]
  booleanDataSource: any[]
  pagePermission: PagePermission

  HistoryData: any
  historyLoadingIndicator: boolean = false
  historyPopupVisible: boolean = false

  constructor(
    public base: BaseService,
    private send: SendRequestService,
    private toastr: ToastrService,
    private permission: PermissionService) {
    this.historyIconClick = this.historyIconClick.bind(this)
    this.loadDataSource()
    this.booleanDataSource = this.base.getBooleanData()
  }

  loadDataSource() {
    let URL: string = `${environment.ServiceURL_Main}`
    this.dataSource = new CustomStore({
      key: "CFG_USER_GROUP_ID",
      loadMode: "raw",
      load: () => this.send.sendRequestDevExtreme(URL + "CfgUserGroup/GetCfgUserGroupDetail"),
      insert: (values) => this.send.sendRequestReturnLastInserted(URL + "CfgUserGroup", "POST", JSON.stringify(values)),
      update: (key, values) => this.send.sendRequestReturnLastInserted(URL + "CfgUserGroup", "PUT", JSON.stringify(values)),
      remove: (key) => this.send.sendRequestDevExtreme(URL + "CfgUserGroup/" + key, "DELETE", { key: key })
    })
  }

  ngOnInit() {
    this.pagePermission = this.permission.getUserPermissions()
    this.getCompany()
  }

  contentReady(e) {
    if (!e.component.getSelectedRowKeys().length)
      e.component.selectRowsByIndexes(0)
  }

  historyIconClick(e) {
    const ID = e.row.data.CFG_USER_GROUP_ID
    if (!ID) {
      this.toastr.error("Invalid/No ID", null, errorToastOptions)
      return
    }
    this.historyPopupVisible = true
    this.historyLoadingIndicator = true
    this.send.sendRequest(`${environment.ServiceURL_Main}CfgUserGroup/GetHistory/${ID}`, "GET", "").subscribe(
      data => {
        this.HistoryData = data
        this.historyLoadingIndicator = false
      },
      () => {
        this.historyLoadingIndicator = false
      })
  }

  getCompany() {
    this.send.sendRequest(`${environment.ServiceURL_Main}companymaster`, "GET", "").subscribe(
      data => {
        this.companyDataSource = data.sort((a, b) => a.COMPANY_NAME.localeCompare(b.COMPANY_NAME))
      }
    )
  }

  onTagBoxValueChanged(evt: any, data: any): void {
    data.setValue(evt.value)
  }

  postGridRow(e, action) {
    if (action == 'edit') {
      e.newData = { ...e.oldData, ...e.newData }
      e.newData.saCompany = ["32A0"]
    }

    if (action === 'create') {
      e.data.saMenu = []
      e.data.saCompany = ["32A0"]
    }
  }

  postedGridRow(e, action) {
    if (action == 'create') { this.toastr.success(this.base.getMessage('Record created successfully'), this.base.getMessage('Success!')) }
    if (action == 'edit') { this.toastr.success(this.base.getMessage('Record modified successfully'), this.base.getMessage('Success!')) }
    if (action == 'delete') { this.toastr.success(this.base.getMessage('Record deleted successfully'), this.base.getMessage('Success!')) }
  }

  onExporting(e: ExportingEvent, fileName: string) {
    exportGridToExcel(e, fileName)
  }
}
